using Restless.Tiingo.Core;
using Restless.Tiingo.Data;
using System.Text.Json;
using System.Threading.Tasks;

namespace Restless.Tiingo.Client
{
    /// <summary>
    /// Represents a client for obtaining information from the news feed
    /// </summary>
    public class NewsClient : AuxiliaryClient
    {
        internal NewsClient(IHttpClientWrapper client, string apiToken) : base(client, apiToken)
        {
        }

        /// <summary>
        /// Gets a collection of news items
        /// </summary>
        /// <param name="parms">Parms for the operation</param>
        /// <returns>A <see cref="NewsItemCollection"/></returns>
        public async Task<NewsItemCollection> GetNewsAsync(NewsParameters parms)
        {
            ValidateParms(parms);

            UrlBuilder builder =
                UrlBuilder.Create($"{Values.ApiRoot}/news")
                .AddFormat(Values.JsonFormat)
                .AddDate(Values.StartDateParm, parms.StartDate)
                .AddDate(Values.EndDateParm, parms.EndDate)
                .AddArray(Values.TickersParm, parms.Tickers)
                .AddArray(Values.TagsParm, parms.Tags)
                .AddArray(Values.SourcesParm, parms.Sources)
                .AddValue(Values.LimitParm, parms.Limit);

            string json = await GetRawJsonAsync(builder.Url);
            return JsonSerializer.Deserialize<NewsItemCollection>(json);
        }
    }
}