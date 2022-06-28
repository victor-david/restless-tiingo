using System;
using System.Text.Json.Serialization;

namespace Restless.Tiingo.Rest.Data
{
    /// <summary>
    /// Represents meta data for a single ticker
    /// </summary>
    public class TickerMetaData
    {
        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("endDate")]
        public DateTime? EndDate { get; set; }

        [JsonPropertyName("exchangeCode")]
        public string ExchangeCode { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("startDate")]
        public DateTime? StartDate { get; set; }

        [JsonPropertyName("ticker")]
        public string Ticker { get; set; }
    }
}