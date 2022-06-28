using System.Text.Json.Serialization;

namespace Restless.Tiingo.Rest.Data
{
    public class ForexMetaData : CurrencyPairMetaData
    {
        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}