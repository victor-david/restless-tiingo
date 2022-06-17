using System;
using System.Text.Json.Serialization;

namespace Restless.Tiingo.Data
{
    public abstract class DataPoint
    {
        [JsonPropertyName("close")]
        public decimal Close { get; set; }

        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("high")]
        public decimal High { get; set; }

        [JsonPropertyName("low")]
        public decimal Low { get; set; }

        [JsonPropertyName("open")]
        public decimal Open { get; set; }
    }
}