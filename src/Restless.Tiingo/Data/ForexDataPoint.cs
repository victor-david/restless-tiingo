using Restless.Tiingo.Core;
using System;
using System.Text.Json.Serialization;

namespace Restless.Tiingo.Data
{
    /// <summary>
    /// Represents a single forex data price point
    /// </summary>
    public class ForexDataPoint
    {
        [JsonPropertyName(JsonId.ClosePrice)]
        public double Close { get; set; }

        [JsonPropertyName(JsonId.Date)]
        public DateTime Date { get; set; }

        [JsonPropertyName(JsonId.HighPrice)]
        public double High { get; set; }

        [JsonPropertyName(JsonId.LowPrice)]
        public double Low { get; set; }

        [JsonPropertyName(JsonId.OpenPrice)]
        public double Open { get; set; }

        [JsonPropertyName(JsonId.Ticker)]
        public string Ticker { get; set; }
    }
}