using Restless.Tiingo.Core;
using Restless.Tiingo.Data;
using System.Text.Json;
using System.Threading.Tasks;

namespace Restless.Tiingo.Client
{
    /// <summary>
    /// Represents a client for obtaing search results
    /// </summary>
    public class SearchClient : AuxiliaryClient
    {
        internal SearchClient(IHttpClientWrapper client, string apiToken) : base(client, apiToken)
        {
        }

        /// <summary>
        /// Gets a collection of search results.
        /// </summary>
        /// <param name="search">The search query</param>
        /// <param name="parms">The search parameters</param>
        /// <returns>A <see cref="SearchResultCollection"/></returns>
        public async Task<SearchResultCollection> GetSearchResultsAsync(string search, SearchParameters parms)
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