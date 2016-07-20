using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Web.Http;
using WebTestsTools.Results;

namespace WebTestsTools.Controllers
{
    public class CertificateController : ApiController
    {
        private static bool InternalCallback(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            WebRequest request = sender as WebRequest;

            Certificate cert = new Certificate();
            certificates.Add(request, cert);

            cert.ExpirationDate = certificate.GetExpirationDateString();
            cert.IssuerName = certificate.Issuer;
            cert.Subject = certificate.Subject;

            return true;
        }

        static CertificateController()
        {
            ServicePointManager.ServerCertificateValidationCallback += InternalCallback;
        }

        private static ConditionalWeakTable<WebRequest, Certificate> certificates = new ConditionalWeakTable<WebRequest, Certificate>(); 

        [Route("certificate/{ip}")]
        public Certificate Get(string ip)
        {
            var request = (WebRequest)HttpWebRequest.Create("https://" + ip);

            bool certificateError = false;
            try
            {
                request.GetResponse();
            }
            catch (Exception exc)
            {
                certificateError = true;
            }

            Certificate cert;
            if (certificates.TryGetValue(request, out cert))
            {
                cert.Error = certificateError;
            }

            var date = Convert.ToDateTime(cert.ExpirationDate);
            cert.ExpiresIn10Days = date.AddDays(-10) < DateTime.Now;


            return cert;
        }
    }
}
