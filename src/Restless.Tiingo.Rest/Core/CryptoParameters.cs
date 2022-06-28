using Restless.Tiingo.Rest.Data;
using System;

namespace Restless.Tiingo.Rest.Core
{
    /// <summary>
    /// Represents parameters used in a crypto operation
    /// </summary>
    public class CryptoParameters : FrequencyParameters, IValidator
    {
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