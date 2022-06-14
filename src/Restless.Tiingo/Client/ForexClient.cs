using Restless.Tiingo.Core;
using Restless.Tiingo.Data;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace Restless.Tiingo.Client
{
    /// <summary>
    /// Represents a client for obtaining forex information
    /// </summary>
    public class ForexClient : AuxiliaryClient
    {
        internal ForexClient(IHttpClientWrapper client, string apiToken) : base(client, apiToken)
        {
        }

        /// <summary>
        /// Gets a collection of forex data points for the specified symbols
        /// </summary>
        /// <param name="fromSymbol">The from currency symbol</param>
        /// <param name="toSymbol">The to currency symbol</param>
        /// <param name="parms">The operation options</param>
        /// <returns>A <see cref="ForexDataPointCollection"/></returns>
        public async Task<ForexDataPointCollection> GetDataPointsAsync(string fromSymbol, string toSymbol, ForexParameters parms)
        {
            _ = parms ?? throw new ArgumentNullException(nameof(parms));

            UrlBuilder builder =
                UrlBuilder.Create($"{Values.ApiRoot}/fx/{fromSymbol}{toSymbol}/prices")
                .AddFormat(Values.JsonFormat)
                .AddDate(Values.StartDateParm, parms.StartDate)
                .AddDate(Values.EndDateParm, parms.EndDate)
                .AddValue(Values.FrequencyParm, parms.GetFrequencyParameter());

            string json = await GetRawJsonAsync(builder.Url);
            return JsonSerializer.Deserialize<ForexDataPointCollection>(json);
        }
    }
}