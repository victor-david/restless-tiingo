using Restless.Tiingo.Rest.Core;
using Restless.Tiingo.Rest.Data;
using System.Text.Json;
using System.Threading.Tasks;

namespace Restless.Tiingo.Rest.Client
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
        public async Task<SearchResultCollection> GetResultsAsync(SearchParameters parms)
        {
            ValidateParms(parms);

            UrlBuilder builder =
                UrlBuilder.Create($"{Values.ApiRoot}/utilities/search")
                .AddFormat(Values.JsonFormat)
                .AddValue(Values.QueryParm, parms.Query)
                .AddBoolean(Values.ExactTickerMatchParm, parms.ExactTickerMatch)
                .AddBoolean(Values.IncludeDelistedParm, parms.IncludeDelisted)
                .AddValue(Values.LimitParm, parms.Limit);              

            string json = await GetRawJsonAsync(builder.Url);
            return JsonSerializer.Deserialize<SearchResultCollection>(json);
        }
    }
}