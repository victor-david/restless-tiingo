﻿using Restless.Tiingo.Core;
using System;
using System.Text.Json.Serialization;

namespace Restless.Tiingo.Data
{
    /// <summary>
    /// Represents meta data for a single ticker
    /// </summary>
    public class TickerMetaData
    {
        [JsonPropertyName(JsonId.Description)]
        public string Description { get; set; }

        [JsonPropertyName(JsonId.EndDate)]
        public DateTime? EndDate { get; set; }

        [JsonPropertyName(JsonId.ExchangeCode)]
        public string ExchangeCode { get; set; }

        [JsonPropertyName(JsonId.Name)]
        public string Name { get; set; }

        [JsonPropertyName(JsonId.StartDate)]
        public DateTime? StartDate { get; set; }

        [JsonPropertyName(JsonId.Ticker)]
        public string Ticker { get; set; }
    }
}