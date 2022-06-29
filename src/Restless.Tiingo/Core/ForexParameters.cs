using Restless.Tiingo.Data;
using System;

namespace Restless.Tiingo.Core
{
    /// <summary>
    /// Represents parameters used in a forex operation
    /// </summary>
    public class ForexParameters : FrequencyParameters, IValidator
    {
        /// <summary>
        /// Gets or sets an array of ticker pairs to filter results
        /// </summary>
        public TickerPair[] Tickers { get; set; }

        public void Validate()
        {
            if ((Tickers?.Length ?? 0) == 0)
            {
                throw new ArgumentException("Tickers must contain at least one entry");
            }
        }
    }
}