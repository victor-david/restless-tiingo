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

        public async Task<ForexDataPointCollection> GetDataPointsAsync(string fromSymbol, string toSymbol, ForexParameters parms)
        {
            _ = parms ?? throw new ArgumentNullException(nameof(parms));

            UrlBuilder builder =
                UrlBuilder.Create($"{Values.ApiRoot}/fx/{fromSymbol}{toSymbol}/prices")
                .AddFormat(Values.JsonFormat)
                .AddDate(Values.StartDateParm, parms.StartDate);
                //.AddDate(Values.EndDateParm, parms.EndDate)
                //.AddResampleFrequency(parms.Frequency)
                //.AddSort(parms.Sort);

            string json = await GetRawJsonAsync(builder.Url);
            return JsonSerializer.Deserialize<ForexDataPointCollection>(json);
        }
    }
}