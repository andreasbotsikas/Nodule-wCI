using System;
using System.Collections.Generic;
using System.Data.Services.Client;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Nodule_wCI.Worker.NoduleDb
{
    public partial class NoduleDbEntities
    {

        public NoduleDbEntities(Uri serviceUri, X509Certificate certificateToPresent) : base(serviceUri)
        {
            this.CertificateForDbService = certificateToPresent;
            this.SendingRequest += OnSendingRequest_AddCertificate;
        }

        private void OnSendingRequest_AddCertificate(object sender, SendingRequestEventArgs args)
        {
            var request = args.Request as HttpWebRequest;
            if (request != null && request.ClientCertificates.Count == 0 && CertificateForDbService != null)
                request.ClientCertificates.Add(CertificateForDbService);
        }

        public X509Certificate CertificateForDbService { get; private set; }

    }
}
