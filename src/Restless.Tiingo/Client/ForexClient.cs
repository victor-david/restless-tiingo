using Restless.Tiingo.Core;
using Restless.Tiingo.Data;
using System.Text.Json;
using System.Threading.Tasks;

namespace Restless.Tiingo.Client
{
    /// <summary>
    /// Represents a client for obtaining forex information
    /// </summary>
    public class ForexClient : BaseClient
    {
        internal ForexClient(IHttpClientWrapper client, string apiToken) : base(client, apiToken)
        {
        }

        /// <summary>
        /// Gets a collection of forex meta data for all supported forex pairs
        /// </summary>
        /// <returns>A <see cref="ForexSymbolPairCollection"/></returns>
        public async Task<ForexSymbolPairCollection> GetSupportedSymbolPairsAsync()
        {
            UrlBuilder builder =
                UrlBuilder.Create($"{Values.ApiRoot}/fx")
                .AddFormat(Values.JsonFormat);

            string json = await GetRawJsonAsync(builder.Url);
            return JsonSerializer.Deserialize<ForexSymbolPairCollection>(json);
        }

        /// <summary>
        /// Gets a collection of forex top data points for the specified symbols
        /// </summary>
        /// <param name="parms">The operation parameters</param>
        /// <returns>A <see cref="ForexTopDataPointCollection"/></returns>
        public async Task<ForexTopDataPointCollection> GetTopOfBookAsync(ForexParameters parms)
        {
            ValidateParms(parms);

            UrlBuilder builder =
                UrlBuilder.Create($"{Values.ApiRoot}/fx/top")
                .AddFormat(Values.JsonFormat)
                .AddArray(Values.TickersParm, parms.Tickers);

            string json = await GetRawJsonAsync(builder.Url);

            return JsonSerializer.Deserialize<ForexTopDataPointCollection>(json);
        }

        /// <summary>
        /// Gets a collection of forex data points for the specified symbol
        /// </summary>
        /// <param name="parms">The operation parameters</param>
        /// <returns>A <see cref="ForexDataPointCollection"/></returns>
        /// <remarks>
        /// This method accepts <see cref="ForexParameters"/> which can specify
        /// multiple symbol pairs. Only the first symbol pair is used
        /// </remarks>
        public async Task<ForexDataPointCollection> GetDataPointsAsync(ForexParameters parms)
        {
            ValidateParms(parms);

            UrlBuilder builder =
                UrlBuilder.Create($"{Values.ApiRoot}/fx/{parms.Tickers[0]}/prices")
                .AddFormat(Values.JsonFormat)
                .AddDate(Values.StartDateParm, parms.StartDate)
                .AddDate(Values.EndDateParm, parms.EndDate)
                .AddValue(Values.FrequencyParm, parms.GetFrequencyParameter());

            string json = await GetRawJsonAsync(builder.Url);
            return JsonSerializer.Deserialize<ForexDataPointCollection>(json);
        }
    }
}