using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Restless.Tiingo.Client
{
    public class DefaultHttpClientWrapper : IHttpClientWrapper
    {
        private readonly HttpClient client;

        public DefaultHttpClientWrapper(HttpClient httpClient)
        {
            client = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public void SetTimeOut(TimeSpan timeSpan)
        {
            client.Timeout = timeSpan;
        }

        public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
        {
            return client.SendAsync(request);
        }

        public void Dispose()
        {
            client.Dispose();
        }
    }
}