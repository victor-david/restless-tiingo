using Restless.Tiingo.Core;
using Restless.Tiingo.Data;
using System.Text.Json;
using System.Threading.Tasks;

namespace Restless.Tiingo.Client
{
    /// <summary>
    /// Represents a client for obtaining crypto information
    /// </summary>
    public class CryptoClient : BaseClient
    {
        internal CryptoClient(IHttpClientWrapper client, string apiToken) : base(client, apiToken)
        {
        }

        /// <summary>
        /// Gets a collection of supported crypto symbol pairs
        /// </summary>
        /// <returns>A <see cref="CryptoSymbolPairCollection"/></returns>
        public async Task<CryptoSymbolPairCollection> GetSupportedSymbolPairsAsync()
        {
            UrlBuilder builder =
                UrlBuilder.Create($"{Values.ApiRoot}/crypto")
                .AddFormat(Values.JsonFormat);

            string json = await GetRawJsonAsync(builder.Url);
            return JsonSerializer.Deserialize<CryptoSymbolPairCollection>(json);
        }

        /// <summary>
        /// Gets a collection of <see cref="CryptoTopData"/> objects
        /// </summary>
        /// <param name="parms"></param>
        /// <returns>A <see cref="CryptoTopDataCollection"/></returns>
        public async Task<CryptoTopDataCollection> GetTopOfBookAsync(CryptoParameters parms)
        {
            ValidateParms(parms);

            UrlBuilder builder =
                UrlBuilder.Create($"{Values.ApiRoot}/crypto/top")
                .AddFormat(Values.JsonFormat)
                .AddArray(Values.TickersParm, parms.Tickers);

            string json = await GetRawJsonAsync(builder.Url);
            return JsonSerializer.Deserialize<CryptoTopDataCollection>(json);
        }

        /// <summary>
        /// Gets a collection of crypto data
        /// </summary>
        /// <param name="parms">The operation parameters</param>
        /// <returns>A <see cref="CryptoDataCollection"/></returns>
        public async Task<CryptoDataCollection> GetDataPointsAsync(CryptoParameters parms)
        {
            ValidateParms(parms);

            UrlBuilder builder =
                UrlBuilder.Create($"{Values.ApiRoot}/crypto/prices")
                .AddFormat(Values.JsonFormat)
                .AddArray(Values.TickersParm, parms.Tickers)
                .AddDate(Values.StartDateParm, parms.StartDate)
                .AddDate(Values.EndDateParm, parms.EndDate)
                .AddValue(Values.FrequencyParm, parms.GetFrequencyParameter());

            string json = await GetRawJsonAsync(builder.Url);
            return JsonSerializer.Deserialize<CryptoDataCollection>(json);
        }
    }
}