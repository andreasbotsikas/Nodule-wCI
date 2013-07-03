using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace Nodule_wCI.Github
{
    // Various extensions for http client
    static class HttpClientExtensions
    {

        #region Sync verbs
        public static dynamic Get(this HttpClient client, string url)
        {
            HttpResponseMessage response = client.GetAsync(url).Result;  // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body. Blocking!
                var payload = response.Content.ReadAsStringAsync().Result;
                return Json.Decode(payload);
            }
            else
            {
                throw new ApplicationException(string.Format("Failed to do get {0} with code {1} and phrase {2}", url, response.StatusCode, response.ReasonPhrase));
            }
        }

        public static dynamic Post(this HttpClient client, string url, dynamic data)
        {
            HttpContent context = new StringContent(Json.Encode(data));
            HttpResponseMessage response = client.PostAsync(url, context).Result;  // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body. Blocking!
                var payload = response.Content.ReadAsStringAsync().Result;
                return Json.Decode(payload);
            }
            else
            {
                throw new ApplicationException(string.Format("Failed to do post {0} with code {1} and phrase {2}", url, response.StatusCode, response.ReasonPhrase));
            }
        }

        public static dynamic Patch(this HttpClient client, string url, dynamic data)
        {
            HttpContent context = new StringContent(Json.Encode(data));
            HttpResponseMessage response = client.PatchAsync(url, context).Result;  // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body. Blocking!
                var payload = response.Content.ReadAsStringAsync().Result;
                return Json.Decode(payload);
            }
            else
            {
                throw new ApplicationException(string.Format("Failed to do patch {0} with code {1} and phrase {2}", url, response.StatusCode, response.ReasonPhrase));
            }
        }
        #endregion

        #region Patch verd support
        public async static Task<HttpResponseMessage> PatchAsync(this HttpClient client, string requestUri, HttpContent content)
        {
            var method = new HttpMethod("PATCH");
            var request = new HttpRequestMessage(method, requestUri)
            {
                Content = content
            };
            return await client.SendAsync(request);
        }

        public async static Task<HttpResponseMessage> PatchAsync(this HttpClient client, Uri requestUri, HttpContent content)
        {
            var method = new HttpMethod("PATCH");
            var request = new HttpRequestMessage(method, requestUri)
            {
                Content = content
            };
            return await client.SendAsync(request);
        }

        public async static Task<HttpResponseMessage> PatchAsync(this HttpClient client, string requestUri, HttpContent content, CancellationToken cancellationToken)
        {
            var method = new HttpMethod("PATCH");
            var request = new HttpRequestMessage(method, requestUri)
            {
                Content = content
            };
            return await client.SendAsync(request, cancellationToken);
        }

        public async static Task<HttpResponseMessage> PatchAsync(this HttpClient client, Uri requestUri, HttpContent content, CancellationToken cancellationToken)
        {
            var method = new HttpMethod("PATCH");
            var request = new HttpRequestMessage(method, requestUri)
            {
                Content = content
            };
            return await client.SendAsync(request, cancellationToken);
        }
        #endregion

    }
}
