using Restless.Tiingo.Core;
using Restless.Tiingo.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Restless.Tiingo.Client
{
    public class SearchClient : AuxiliaryClient
    {
        internal SearchClient(IHttpClientWrapper client, string apiToken) : base(client, apiToken)
        {
        }


        public async Task<SearchResultCollection> GetSearchResults(string search, SearchParameters parms)
        {
            UrlBuilder builder =
                UrlBuilder.Create($"{Values.ApiRoot}/utilities/search/{search}")
                .AddFormat(Values.JsonFormat)
                .AddBoolean(Values.ExactTickerMatchParm, parms.ExactTickerMatch)
                .AddBoolean(Values.IncludeDelistedParm, parms.IncludeDelisted)
                .AddValue(Values.LimitParm, parms.Limit);              

            string json = await GetRawJsonAsync(builder.Url);
            return JsonSerializer.Deserialize<SearchResultCollection>(json);
        }
    }
}