using Restless.Tiingo.Core;
using System;
using System.Text.Json.Serialization;

namespace Restless.Tiingo.Data
{
    /// <summary>
    /// Represents
    /// </summary>
    public class ForexTopDataPoint
    {
        [JsonPropertyName(JsonId.AskPrice)]
        public double AskPrice { get; set; }

        [JsonPropertyName(JsonId.AskSize)]
        public double AskSize { get; set; }

        [JsonPropertyName(JsonId.BidPrice)]
        public double BidPrice { get; set; }

        [JsonPropertyName(JsonId.BidSize)]
        public double BidSize { get; set; }

        [JsonPropertyName(JsonId.MidPrice)]
        public double MidPrice { get; set; }

        [JsonPropertyName(JsonId.Ticker)]
        public string Ticker { get; set; }

        [JsonPropertyName(JsonId.QuoteTimestamp)]
        public DateTime Timestamp { get; set; }
    }
}