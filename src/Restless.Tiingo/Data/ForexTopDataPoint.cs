using System;
using System.Text.Json.Serialization;

namespace Restless.Tiingo.Data
{
    public class ForexTopDataPoint
    {
        [JsonPropertyName("askPrice")]
        public decimal AskPrice { get; set; }

        [JsonPropertyName("askSize")]
        public decimal AskSize { get; set; }

        [JsonPropertyName("bidPrice")]
        public decimal BidPrice { get; set; }

        [JsonPropertyName("bidSize")]
        public decimal BidSize { get; set; }

        [JsonPropertyName("midPrice")]
        public decimal MidPrice { get; set; }

        [JsonPropertyName("ticker")]
        public string Ticker { get; set; }

        [JsonPropertyName("quoteTimestamp")]
        public DateTime Timestamp { get; set; }
    }
}