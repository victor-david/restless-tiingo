﻿using Restless.Tiingo.Core;
using Restless.Tiingo.Data;
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
        /// Gets a collection of forex meta data for all supported forex pairs
        /// </summary>
        /// <returns>A <see cref="ForexMetaDataCollection"/></returns>
        public async Task<ForexMetaDataCollection> GetSupportedMetaDataAsync()
        {
            UrlBuilder builder =
                UrlBuilder.Create($"{Values.ApiRoot}/fx")
                .AddFormat(Values.JsonFormat);

            string json = await GetRawJsonAsync(builder.Url);
            return JsonSerializer.Deserialize<ForexMetaDataCollection>(json);
        }

        /// <summary>
        /// Gets a collection of forex data points for the specified symbols
        /// </summary>
        /// <param name="parms">The operation options</param>
        /// <returns>A <see cref="ForexDataPointCollection"/></returns>
        public async Task<ForexDataPointCollection> GetDataPointsAsync(ForexParameters parms)
        {
            ValidateParms(parms);

            UrlBuilder builder =
                UrlBuilder.Create($"{Values.ApiRoot}/fx/{parms.Ticker}/prices")
                .AddFormat(Values.JsonFormat)
                .AddDate(Values.StartDateParm, parms.StartDate)
                .AddDate(Values.EndDateParm, parms.EndDate)
                .AddValue(Values.FrequencyParm, parms.GetFrequencyParameter());

            string json = await GetRawJsonAsync(builder.Url);
            return (ForexDataPointCollection)JsonSerializer.Deserialize<ForexDataPointCollection>(json).UpdateInterval(parms.Interval);
        }
    }
}