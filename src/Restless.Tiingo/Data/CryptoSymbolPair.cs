using Restless.Tiingo.Core;
using System.Text.Json.Serialization;

namespace Restless.Tiingo.Data
{
    /// <summary>
    /// Represents a single result when querying for supported crypto symbols
    /// </summary>
    public class CryptoSymbolPair
    {
        [JsonPropertyName(JsonId.BaseCurrency)]
        public string BaseCurrency { get; set; }

        [JsonPropertyName(JsonId.Name)]
        public string Name { get; set; }

        [JsonPropertyName(JsonId.QuoteCurrency)]
        public string QuoteCurrency { get; set; }

        [JsonPropertyName(JsonId.Ticker)]
        public string Ticker { get; set; }
    }
}