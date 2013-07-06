using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Selectors;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace Nodule_wCI
{
    /// <summary>
    /// Allow only the clients with the already acquired certificate to connect. The cn is in the ClientCertificateName app setting
    /// </summary>
    public class AllowOnlySpecificCertificateAuthenticator : X509CertificateValidator
    {
        // Logger helper
        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Common certificate retrival function from LocalMachine--> My
        /// </summary>
        /// <param name="name">The CN to search for</param>
        /// <returns></returns>
        public static X509Certificate GetCertificateBySubjectName(string name)
        {
            X509Certificate output = null;
            X509Store store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            store.Open(OpenFlags.ReadOnly);
            var foundCertificates = store.Certificates.Find(X509FindType.FindBySubjectDistinguishedName, name, false);
            if (foundCertificates.Count == 1)
            {
                output = foundCertificates[0];
            }
            else if (foundCertificates.Count > 1)
            {
                Log.Warn(string.Format("More than one certificates found for {0}. Using first one.",name));
                output = foundCertificates[0];
            }
            store.Close();
            return output;
        }

        static AllowOnlySpecificCertificateAuthenticator()
        {
            var cert = GetCertificateBySubjectName(ConfigurationManager.AppSettings["ClientCertificateName"]);
            if (cert == null)
            {
                Log.Error(string.Format("Could not locate client's certificate with subject {0}", ConfigurationManager.AppSettings["ClientCertificateName"]));
                throw new ApplicationException("Client certificate not found in store");
            }
            AllowedThumbprint = cert.GetCertHashString();
        }

        private static string AllowedThumbprint { get; set; }

        public override void Validate(X509Certificate2 certificate)
        {
            if (certificate.GetCertHashString() != AllowedThumbprint)
                throw new Exception("Certificate is not the one we allow");
        }
    }

}