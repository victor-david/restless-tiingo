using Restless.Tiingo.Core;
using System;
using System.Text.Json.Serialization;

namespace Restless.Tiingo.Data
{
    /// <summary>
    /// Represents a single crypto top data response;
    /// it includes an array of <see cref="CryptoTopDataPoint"/> objects.
    /// </summary>
    public class CryptoTopData
    {
        [JsonPropertyName(JsonId.BaseCurrency)]
        public string BaseCurrency { get; set; }

        [JsonPropertyName(JsonId.TopOfBookData)]
        public CryptoTopDataPoint[] Prices { get; set; }

        [JsonPropertyName(JsonId.QuoteCurrency)]
        public string QuoteCurrency { get; set; }

        [JsonPropertyName(JsonId.Ticker)]
        public string Ticker { get; set; }
    }

    /// <summary>
    /// Represents a single crypto top price data point.
    /// Crypto price points arrive in the <see cref="CryptoTopData.Prices"/> array.
    /// </summary>
    public class CryptoTopDataPoint
    {
        [JsonPropertyName(JsonId.AskExchange)]
        public string AskExchange { get; set; }

        [JsonPropertyName(JsonId.AskPrice)]
        public double AskPrice { get; set; }

        [JsonPropertyName(JsonId.AskSize)]
        public double AskSize { get; set; }

        [JsonPropertyName(JsonId.BidExchange)]
        public string BidExchange { get; set; }

        [JsonPropertyName(JsonId.BidPrice)]
        public double BidPrice { get; set; }

        [JsonPropertyName(JsonId.BidSize)]
        public double BidSize { get; set; }

        [JsonPropertyName(JsonId.LastExchange)]
        public string LastExchange { get; set; }

        [JsonPropertyName(JsonId.LastSaleTimestamp)]
        public DateTime LastSaleTimestamp { get; set; }

        [JsonPropertyName(JsonId.LastPrice)]
        public double LastPrice { get; set; }

        [JsonPropertyName(JsonId.LastSize)]
        public double LastSize { get; set; }

        [JsonPropertyName(JsonId.LastSizeNotional)]
        public double LastSizeNotional { get; set; }

        [JsonPropertyName(JsonId.QuoteTimestamp)]
        public DateTime QuoteTimestamp { get; set; }
    }
}