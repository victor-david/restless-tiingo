using Restless.Tiingo.Core;
using System;
using System.Text.Json.Serialization;

namespace Restless.Tiingo.Data
{
    /// <summary>
    /// Represents a single ticker data price point.
    /// </summary>
    public class TickerDataPoint
    {
        [JsonPropertyName(JsonId.AdjustedClose)]
        public double AdjustedClose { get; set; }

        [JsonPropertyName(JsonId.AdjustedHigh)]
        public double AdjustedHigh { get; set; }

        [JsonPropertyName(JsonId.AdjustedLow)]
        public double AdjustedLow { get; set; }

        [JsonPropertyName(JsonId.AdjustedOpen)]
        public double AdjustedOpen { get; set; }

        [JsonPropertyName(JsonId.AdjustedVolume)]
        public long AdjustedVolume { get; set; }

        [JsonPropertyName(JsonId.ClosePrice)]
        public double Close { get; set; }

        [JsonPropertyName(JsonId.Date)]
        public DateTime Date { get; set; }

        [JsonPropertyName(JsonId.DividendCash)]
        public decimal DivCash { get; set; }

        [JsonPropertyName(JsonId.HighPrice)]
        public double High { get; set; }

        [JsonPropertyName(JsonId.LowPrice)]
        public double Low { get; set; }

        [JsonPropertyName(JsonId.OpenPrice)]
        public double Open { get; set; }

        [JsonPropertyName(JsonId.SplitFactor)]
        public decimal SplitFactor { get; set; }

        [JsonPropertyName(JsonId.Volume)]
        public long Volume { get; set; }
    }
}