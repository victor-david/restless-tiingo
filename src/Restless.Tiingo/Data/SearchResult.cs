using Restless.Tiingo.Core;
using System.Text.Json.Serialization;

namespace Restless.Tiingo.Data
{
    /// <summary>
    /// Represents a single search result
    /// </summary>
    public class SearchResult
    {
        [JsonPropertyName(JsonId.AssetType)]
        public string AssetType { get; set; }

        [JsonPropertyName(JsonId.CountryCode)]
        public string CountryCode { get; set; }

        [JsonPropertyName(JsonId.IsActive)]
        public bool IsActive { get; set; }

        [JsonPropertyName(JsonId.Name)]
        public string Name { get; set; }

        [JsonPropertyName(JsonId.OpenFIGIComposite)]
        public string OpenFigiComposite { get; set; }

        [JsonPropertyName(JsonId.PermaTicker)]
        public string PermaTicker { get; set; }

        [JsonPropertyName(JsonId.Ticker)]
        public string Ticker { get; set; }
    }
}