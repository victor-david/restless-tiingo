namespace Restless.Tiingo.Core
{
    /// <summary>
    /// Represents parameters used in a news operation
    /// </summary>
    public class NewsParameters : ApiParameters
    {
        /// <summary>
        /// Gets or sets the maximum number of results to return.
        /// Tiingo clamps this value to a maximum of 1000.
        /// </summary>
        public int Limit { get; set; }

        /// <summary>
        /// Gets or sets an arry of news sources used to filter news results.
        /// </summary>
        public string[] Sources { get; set; }

        /// <summary>
        /// Gets or sets an array of tags used to filter news results.
        /// </summary>
        public string[] Tags { get; set; }

        /// <summary>
        /// Gets or sets an array of tickers used to filter news results.
        /// </summary>
        public string[] Tickers { get; set; }

        public NewsParameters()
        {
            Limit = 100;
        }
    }
}