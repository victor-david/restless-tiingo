using Restless.Tiingo.Core;
using System;
using System.Text.Json.Serialization;

namespace Restless.Tiingo.Data
{
    /// <summary>
    /// Represents a single news item
    /// </summary>
    public class NewsItem
    {
        [JsonPropertyName(JsonId.ArticleId)]
        public long ArticleId { get; set; }

        [JsonPropertyName(JsonId.Title)]
        public string Title { get; set; }

        [JsonPropertyName(JsonId.Url)]
        public string Url { get; set; }

        [JsonPropertyName(JsonId.Description)]
        public string Description { get; set; }

        [JsonPropertyName(JsonId.PublishedDate)]
        public DateTime PublishedDate { get; set; }

        [JsonPropertyName(JsonId.CrawlDate)]
        public DateTime CrawlDate { get; set; }

        [JsonPropertyName(JsonId.NewsSource)]
        public string NewsSource { get; set; }

        [JsonPropertyName(JsonId.Tickers)]
        public string[] Tickers { get; set; }

        [JsonPropertyName(JsonId.Tags)]
        public string[] Tags { get; set; }
    }
}