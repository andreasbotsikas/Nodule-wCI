using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Nodule_wCI.Worker
{
    [ServiceContract]
    public interface IProcessor
    {

        // Watch out for time out as the process of npm install is not that fast (depending on your host)
        [OperationContract(AsyncPattern = true)]
        IAsyncResult BeginProcessRequest(long requestId, AsyncCallback callback, object state);
        bool EndProcessRequest(IAsyncResult r);

        [OperationContract(AsyncPattern = true)]
        IAsyncResult BeginProcessNewRequests(AsyncCallback callback, object state);
        bool EndProcessNewRequests(IAsyncResult r);

        [OperationContract(IsOneWay = true)]
        void StartProcessRequest(long requestId);

        [OperationContract(IsOneWay = true)]
        void StartProcessNewRequests();

    }
}
