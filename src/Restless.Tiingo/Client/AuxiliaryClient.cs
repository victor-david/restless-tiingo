using Restless.Tiingo.Core;
using Restless.Tiingo.Data;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace Restless.Tiingo.Client
{
    /// <summary>
    /// Represents the base class for auxiliary clients such as stocks and forex
    /// </summary>
    public abstract class AuxiliaryClient
    {
        private readonly string apiToken;

        protected IHttpClientWrapper Client
        {
            get;
        }

        protected AuxiliaryClient(IHttpClientWrapper client, string apiToken)
        {
            Client = client ?? throw new ArgumentNullException(nameof(client));
            this.apiToken = apiToken;
        }

        #region Protected methods
        /// <summary>
        /// Gets a raw json response from the specified url
        /// </summary>
        /// <param name="url">The url</param>
        /// <returns></returns>
        protected async Task<string> GetRawJsonAsync(string url)
        {
            using (HttpRequestMessage request = new(HttpMethod.Get, url))
            {
                AddStandardRequestHeaders(request, Values.JsonContent);
                AddAuthorizationHeader(request);

                HttpResponseMessage response = await Client.SendAsync(request).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();

                string json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                return GetErrorResponse(ref json) is ErrorResponse error ? throw new ApiException(error.Message) : json;
            }
        }

        protected async Task<byte[]> GetRawByteArrayAsync(string url)
        {
            using (HttpRequestMessage request = new(HttpMethod.Get, url))
            {
                AddStandardRequestHeaders(request, Values.OctetStreamContent);

                HttpResponseMessage response = await Client.SendAsync(request).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
            }
        }
        #endregion

        #region Private methods
        private void AddStandardRequestHeaders(HttpRequestMessage request, string contentType)
        {
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(contentType));
            request.Headers.Host = request.RequestUri.Host;
            request.Headers.Add("Connection", "Close");
            //request.Headers.Add("User-Agent", UserAgent);
            request.Headers.Date = new DateTimeOffset(DateTime.Now);
            request.Headers.Add("Accept-Language", "en-us");
            request.Headers.Add("Cache-Control", "no-cache");
        }

        private void AddAuthorizationHeader(HttpRequestMessage request)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Token", apiToken);
        }


        private ErrorResponse GetErrorResponse(ref string json)
        {
            try
            {
                return json.StartsWith(Values.ErrorDetailJson) ? JsonSerializer.Deserialize<ErrorResponse>(json) : null;
            }
            catch
            {
                return null;
            }
        }
        #endregion
    }
}