using Restless.Tiingo.Core;
using Restless.Tiingo.Data;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace Restless.Tiingo.Client
{
    /// <summary>
    /// Represents a client for obtaining ticker information (meta data, prices)
    /// </summary>
    public class TickerClient : AuxiliaryClient
    {
        internal TickerClient(IHttpClientWrapper client, string apiToken)  :base(client, apiToken)
        {
        }

        /// <summary>
        /// Gets meta data for the specified ticker
        /// </summary>
        /// <param name="ticker">The ticker</param>
        /// <returns></returns>
        public async Task<TickerMetaData> GetMetaDataAsync(string ticker)
        {
            UrlBuilder builder =
                UrlBuilder.Create($"{Values.ApiRoot}/daily/{ticker}")
                .AddFormat(Values.JsonFormat);

            string json = await GetRawJsonAsync(builder.Url);
            return JsonSerializer.Deserialize<TickerMetaData>(json);
        }

        /// <summary>
        /// Gets a collection of ticker data points for the specified ticker
        /// </summary>
        /// <param name="ticker">The ticker</param>
        /// <param name="parms">The operation options</param>
        /// <returns>A <see cref="TickerDataPointCollection"/></returns>
        public async Task<TickerDataPointCollection> GetDataPointsAsync(string ticker, TickerParameters parms)
        {
            _ = parms ?? throw new ArgumentNullException(nameof(parms));

            UrlBuilder builder =
                UrlBuilder.Create($"{Values.ApiRoot}/daily/{ticker}/prices")
                .AddFormat(Values.JsonFormat)
                .AddDate(Values.StartDateParm, parms.StartDate)
                .AddDate(Values.EndDateParm, parms.EndDate)
                .AddValue(Values.FrequencyParm, parms.GetFrequencyParameter())
                .AddValue(Values.SortParm, parms.GetSortParameter());

            string json = await GetRawJsonAsync(builder.Url);
            return JsonSerializer.Deserialize<TickerDataPointCollection>(json);
        }
    }
}