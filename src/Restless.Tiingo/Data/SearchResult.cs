using System.Text.Json.Serialization;

namespace Restless.Tiingo.Data
{
    /// <summary>
    /// Represents a single search result
    /// </summary>
    public class SearchResult
    {
        [JsonPropertyName("assetType")]
        public string AssetType { get; set; }

        [JsonPropertyName("countryCode")]
        public string CountryCode { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("openFIGIComposite")]
        public string OpenFigiComposite { get; set; }

        [JsonPropertyName("permaTicker")]
        public string PermaTicker { get; set; }

        [JsonPropertyName("ticker")]
        public string Ticker { get; set; }
    }
}