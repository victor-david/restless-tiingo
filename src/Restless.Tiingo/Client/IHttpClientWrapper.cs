using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Restless.Tiingo.Client
{
    public interface IHttpClientWrapper : IDisposable
    {
        void SetTimeOut(TimeSpan timeSpan);
        Task<HttpResponseMessage> SendAsync(HttpRequestMessage request);
    }
}