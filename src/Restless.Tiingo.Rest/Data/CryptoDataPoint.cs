using System.Text.Json.Serialization;

namespace Restless.Tiingo.Rest.Data
{
    public class CryptoDataPoint : DataPoint
    {
        [JsonPropertyName("tradesDone")]
        public decimal TradesDone { get; set; }

        [JsonPropertyName("volume")]
        public decimal Volume { get; set; }

        [JsonPropertyName("volumeNotional")]
        public decimal VolumeNotional { get; set; }
    }
}