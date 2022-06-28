using System.Text.Json.Serialization;

namespace Restless.Tiingo.Data
{
    public class CryptoData
    {
        [JsonPropertyName("baseCurrency")]
        public string BaseCurrency { get; set; }

        [JsonPropertyName("quoteCurrency")]
        public string QuoteCurrency { get; set; }

        [JsonPropertyName("ticker")]
        public string Ticker { get; set; }

        [JsonPropertyName("priceData")]
        public CryptoDataPoint[] Prices { get; set; }
    }
}