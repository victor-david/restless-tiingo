using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Restless.Tiingo.Rest.Client
{
    public interface IHttpClientWrapper : IDisposable
    {
        void SetTimeOut(TimeSpan timeSpan);
        Task<HttpResponseMessage> SendAsync(HttpRequestMessage request);
    }
}