using Restless.Tiingo.Data;
using System;

namespace Restless.Tiingo.Core
{
    public class SearchParameters : IValidator
    {
        private int limit;

        public const int MinLimit = 10;
        public const int MaxLimit = 100;
        public const int DefaultLimit = 25;

        /// <summary>
        /// The search query
        /// </summary>
        public string Query { get; set; }

        /// <summary>
        /// True to only include exact ticker matches based on the search query.
        /// If true, no partial matches will be included and asset names will not be searched.
        /// </summary>
        public bool ExactTickerMatch { get; set; }

        /// <summary>
        /// True to include delisted tickers and false (default) to exclude delisted tickers.
        /// </summary>
        public bool IncludeDelisted { get; set; }

        /// <summary>
        /// The maximum number of assets to return. 
        /// Clamped between 10 and 100.
        /// </summary>
        public int Limit
        {
            get => limit;
            set => limit = Math.Clamp(value, MinLimit, MaxLimit);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchParameters"/> class
        /// </summary>
        public SearchParameters()
        {
            Limit = DefaultLimit;
        }

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(Query))
            {
                throw new ArgumentException("Query must contain a value");
            }
        }
    }
}