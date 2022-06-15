using Restless.Tiingo.Core;
using Restless.Tiingo.Data;
using System.Text.Json;
using System.Threading.Tasks;

namespace Restless.Tiingo.Client
{
    /// <summary>
    /// Represents a client for obtaining crypto information
    /// </summary>
    public class CryptoClient : AuxiliaryClient
    {
        internal CryptoClient(IHttpClientWrapper client, string apiToken) : base(client, apiToken)
        {
        }

        public async Task GetTopOfBookAsync(CryptoParameters parms)
        {
            ValidateParms(parms);

            UrlBuilder builder =
                UrlBuilder.Create($"{Values.ApiRoot}/crypto/top")
                .AddFormat(Values.JsonFormat)
                .AddArray(Values.TickersParm, parms.Tickers);

            string json = await GetRawJsonAsync(builder.Url);
        }

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