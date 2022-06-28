using Restless.Tiingo.Data;
using System;

namespace Restless.Tiingo.Core
{
    /// <summary>
    /// Represents parameters used in a crypto operation
    /// </summary>
    public class CryptoParameters : FrequencyParameters, IValidator
    {
        /// <summary>
        /// Gets or sets an array of ticker pairs to filter results
        /// </summary>
        public TickerPair[] Tickers { get; set; }

        #region IValidator
        public void Validate()
        {
            if ((Tickers?.Length ?? 0) == 0)
            {
                throw new ArgumentException("Tickers must contain at least one entry");
            }
        }
        #endregion

        /// <inheritdoc/>
        protected internal override string GetFrequencyParameter()
        {
            return (StartDate == null && EndDate == null) ? null : base.GetFrequencyParameter();
        }
    }
}