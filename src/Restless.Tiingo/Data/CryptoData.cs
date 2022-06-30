using Restless.Tiingo.Core;
using System;
using System.Text.Json.Serialization;

namespace Restless.Tiingo.Data
{
    /// <summary>
    /// Represents a single crypto data response;
    /// it includes an array of <see cref="CryptoDataPoint"/> objects.
    /// </summary>
    public class CryptoData
    {
        [JsonPropertyName(JsonId.BaseCurrency)]
        public string BaseCurrency { get; set; }

        [JsonPropertyName(JsonId.PriceData)]
        public CryptoDataPoint[] Prices { get; set; }

        [JsonPropertyName(JsonId.QuoteCurrency)]
        public string QuoteCurrency { get; set; }

        [JsonPropertyName(JsonId.Ticker)]
        public string Ticker { get; set; }
    }

    /// <summary>
    /// Represents a single crypto price data point.
    /// Crypto price points arrive in the <see cref="CryptoData.Prices"/> array.
    /// </summary>
    public class CryptoDataPoint
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

        [JsonPropertyName(JsonId.TradesDone)]
        public double TradesDone { get; set; }

        [JsonPropertyName(JsonId.Volume)]
        public double Volume { get; set; }

        [JsonPropertyName(JsonId.VolumeNotional)]
        public double VolumeNotional { get; set; }
    }
}