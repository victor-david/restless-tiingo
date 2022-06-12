using Restless.Tiingo.Core;
using Restless.Tiingo.Data;
using System.Text.Json;
using System.Threading.Tasks;

namespace Restless.Tiingo.Client
{
    public class NewsClient : AuxiliaryClient
    {
        internal NewsClient(IHttpClientWrapper client, string apiToken) : base(client, apiToken)
        {
        }

        public async Task<NewsItemCollection> Get(NewsParameters parms)
        {
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