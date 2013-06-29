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
        [OperationContract(AsyncPattern = true)]
        IAsyncResult BeginProcessRequest(long requestId, AsyncCallback callback, object state);
        bool EndProcessRequest(IAsyncResult r);

        [OperationContract(AsyncPattern = true)]
        IAsyncResult BeginProcessNewRequests(AsyncCallback callback, object state);
        bool EndProcessNewRequests(IAsyncResult r);

    }
}
