using Restless.Tiingo.Core;
using Restless.Tiingo.Data;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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
                string json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                return ValidateResponse(response, json);
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

        protected void ValidateParms(params object[] parms)
        {
            foreach (object parm in parms)
            {
                _ = parm ?? throw new ArgumentNullException(nameof(parm));
                if (parm is string str && string.IsNullOrWhiteSpace(str))
                {
                    throw new ArgumentException("Invalid parameter");
                }

                if (parm is IValidator item)
                {
                    item.Validate();
                }
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

        private string ValidateResponse(HttpResponseMessage response, string json)
        {
            if (!response.IsSuccessStatusCode)
            {
                throw new ApiException($"{(int)response.StatusCode} {response.ReasonPhrase} {ExtractErrorMessage(json)}");
            }

            return json;
        }

        private string ExtractErrorMessage(string json)
        {
            // Some errors return json (object) like this:
            //   {"detail": "An error message"};
            //
            // Others like this (array):
            //   ["Error: Tickers must be a comma-separated list of tickers, e.g. AAPL,TSLA if querying historical data"]

            return GetErrorResponse<string[]>(json) is string[] array
                ? StringArrayToString(array)
                : GetErrorResponse<ErrorResponse>(json) is ErrorResponse response ? response.Message : json;
        }

        private T GetErrorResponse<T>(string json) where T : class
        {
            try
            {
                return JsonSerializer.Deserialize<T>(json);
            }
            catch
            {
                return null;
            }
        }

        private string StringArrayToString(string[] values)
        {
            StringBuilder builder = new();
            return builder.AppendJoin(Environment.NewLine, values).ToString();
        }
        #endregion
    }
}