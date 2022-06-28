namespace Restless.Tiingo.Rest.Core
{
    /// <summary>
    /// Represents parameters used in a ticker operation
    /// </summary>
    public class TickerParameters : FrequencyParameters
    {
        public string Ticker { get; set; }
        public SortOption Sort { get; set; }

        public TickerParameters()
        {
            Sort = SortOption.None;
        }

        /// <inheritdoc/>
        protected internal override string GetFrequencyParameter()
        {
            // resampleFreq must be in 'daily', 'weekly','monthly', 'annually'
            return Frequency switch
            {
                FrequencyUnit.Month => "monthly",
                FrequencyUnit.Week => "weekly",
                FrequencyUnit.Year => "annually",
                _ => "daily"
            };
        }

        internal string GetSortParameter()
        {
            return Sort switch
            {
                SortOption.DateAscending => "date",
                SortOption.DateDescending => "-date",
                _ => string.Empty
            };
        }
    }
}