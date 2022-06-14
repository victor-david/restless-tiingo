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
        public async Task<TickerMetaData> GetMetaAsync(string ticker)
        {
            UrlBuilder builder =
                UrlBuilder.Create($"{Values.ApiRoot}/daily/{ticker}")
                .AddFormat(Values.JsonFormat);

            string json = await GetRawJsonAsync(builder.Url);
            return JsonSerializer.Deserialize<TickerMetaData>(json);
        }

        /// <summary>
        /// Gets a collection of stock data points for the specified ticker
        /// </summary>
        /// <param name="ticker">The ticker</param>
        /// <param name="parms">The operation options</param>
        /// <returns>A <see cref="StockDataPointCollection"/></returns>
        public async Task<StockDataPointCollection> GetDataPointsAsync(string ticker, TickerParameters parms)
        {
            _ = parms ?? throw new ArgumentNullException(nameof(parms));

            UrlBuilder builder =
                UrlBuilder.Create($"{Values.ApiRoot}/daily/{ticker}/prices")
                .AddFormat(Values.JsonFormat)
                .AddDate(Values.StartDateParm, parms.StartDate)
                .AddDate(Values.EndDateParm, parms.EndDate)
                .AddResampleFrequency(parms.Frequency)
                .AddSort(parms.Sort);

            string json = await GetRawJsonAsync(builder.Url);
            return JsonSerializer.Deserialize<StockDataPointCollection>(json);
        }
    }
}