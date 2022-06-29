using Restless.Tiingo.Core;
using System.Text.Json.Serialization;

namespace Restless.Tiingo.Data
{
    /// <summary>
    /// Represents a single result when querying for supported forex symbols
    /// </summary>
    public class ForexSymbolPair
    {
        [JsonPropertyName(JsonId.BaseCurrency)]
        public string BaseCurrency { get; set; }

        [JsonPropertyName(JsonId.Description)]
        public string Description { get; set; }

        [JsonPropertyName(JsonId.Name)]
        public string Name { get; set; }

        [JsonPropertyName(JsonId.QuoteCurrency)]
        public string QuoteCurrency { get; set; }

        [JsonPropertyName(JsonId.Ticker)]
        public string Ticker { get; set; }
    }
}