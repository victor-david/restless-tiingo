using Restless.Tiingo.Core;
using Restless.Tiingo.Data;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace Restless.Tiingo.Client
{
    /// <summary>
    /// Represents a client for obtaining stock information
    /// </summary>
    public class StocksClient : AuxiliaryClient
    {
        internal StocksClient(IHttpClientWrapper client, string apiToken)  :base(client, apiToken)
        {
        }

        /// <summary>
        /// Gets meta data for the specified ticker
        /// </summary>
        /// <param name="ticker">The ticker</param>
        /// <returns></returns>
        public async Task<TickerMeta> GetMetaAsync(string ticker)
        {
            UrlBuilder builder =
                UrlBuilder.Create($"{Values.ApiRoot}/daily/{ticker}");

            string json = await GetRawJsonAsync(builder.ToString());
            return JsonSerializer.Deserialize<TickerMeta>(json);
        }

        /// <summary>
        /// Gets a collection of stock data points for the specified ticker
        /// </summary>
        /// <param name="ticker">The ticker</param>
        /// <param name="ops">The operation options</param>
        /// <returns>A <see cref="StockDataPointCollection"/></returns>
        public async Task<StockDataPointCollection> GetDataPointsAsync(string ticker, OperationOptions ops)
        {
            _ = ops ?? throw new ArgumentNullException(nameof(ops));

            UrlBuilder builder =
                UrlBuilder.Create($"{Values.ApiRoot}/daily/{ticker}/prices")
                .AddFormat(Values.JsonFormat)
                .AddDate(Values.StartDateParm, ops.StartDate)
                .AddDate(Values.EndDateParm, ops.EndDate)
                .AddResampleFrequency(ops.Frequency)
                .AddSort(ops.Sort);

            string json = await GetRawJsonAsync(builder.ToString());
            return JsonSerializer.Deserialize<StockDataPointCollection>(json);
        }
    }
}