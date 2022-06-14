using System.Text.Json.Serialization;

namespace Restless.Tiingo.Data
{
    public class TickerDataPoint : DataPoint
    {
        [JsonPropertyName("adjClose")]
        public decimal AdjustedClose { get; set; }

        [JsonPropertyName("adjHigh")]
        public decimal AdjustedHigh { get; set; }

        [JsonPropertyName("adjLow")]
        public decimal AdjustedLow { get; set; }

        [JsonPropertyName("adjOpen")]
        public decimal AdjustedOpen { get; set; }

        [JsonPropertyName("adjVolume")]
        public long AdjustedVolume { get; set; }
        
        [JsonPropertyName("divCash")]
        public decimal DivCash { get; set; }

        [JsonPropertyName("splitFactor")]
        public decimal SplitFactor { get; set; }

        [JsonPropertyName("volume")]
        public long Volume { get; set; }
    }
}