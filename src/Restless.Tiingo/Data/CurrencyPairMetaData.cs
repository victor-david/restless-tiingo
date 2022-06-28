using System.Text.Json.Serialization;

namespace Restless.Tiingo.Rest.Data
{
    /// <summary>
    /// Represents common data for an operation that obtains supported currency pairs (forex, crypto)
    /// </summary>
    /// <remarks>
    /// This data structure is used when querying the api for supported currency pairs.
    /// It is used by <see cref="ForexMetaData"/> and <see cref="CryptoMetaData"/>
    /// when obtaining a list of their respective supported currency pairs.
    /// </remarks>
    public abstract class CurrencyPairMetaData
    {
        [JsonPropertyName("baseCurrency")]
        public string BaseCurrency { get; set; }

        [JsonPropertyName("quoteCurrency")]
        public string QuoteCurrency { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("ticker")]
        public string Ticker { get; set; }

        public override string ToString()
        {
            return $"{BaseCurrency.ToUpperInvariant()} => {QuoteCurrency.ToUpperInvariant()}";
        }
    }
}