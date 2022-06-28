using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Restless.Tiingo.Rest.Data
{
    public class NewsItem
    {
        [JsonPropertyName("id")]
        public long ArticleId { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("publishedDate")]
        public DateTime PublishedDate { get; set; }

        [JsonPropertyName("crawlDate")]
        public DateTime CrawlDate { get; set; }

        [JsonPropertyName("source")]
        public string NewsSource { get; set; }

        [JsonPropertyName("tickers")]
        public string[] Tickers { get; set; }

        [JsonPropertyName("tags")]
        public string[] Tags { get; set; }
    }
}