using Restless.Tiingo.Data;
using System;

namespace Restless.Tiingo.Core
{
    public class CryptoParameters : ApiParameters, IValidator
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
            // resampleFreq must be in 'Day', 'Min', or 'Hour' only
            return Frequency switch
            {
                FrequencyUnit.Minute => $"{Math.Clamp(FrequencyValue, 1, 60)}min",
                FrequencyUnit.Hour => $"{Math.Clamp(FrequencyValue, 1, 24)}hour",
                FrequencyUnit.Day => $"{Math.Clamp(FrequencyValue, 1, 60)}day",
                _ => "1day"
            };
        }
    }
}