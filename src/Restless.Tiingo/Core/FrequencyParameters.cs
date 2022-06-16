using System;

namespace Restless.Tiingo.Core
{
    /// <summary>
    /// Extends <see cref="ApiParameters"/> for parameters that handle frequency intervals
    /// </summary>
    public abstract class FrequencyParameters : ApiParameters
    {
        public FrequencyUnit Frequency { get; set; }
        public int FrequencyValue { get; set; }

        protected FrequencyParameters()
        {
            Frequency = FrequencyUnit.None;
            FrequencyValue = 0;
        }

        /// <summary>
        /// Gets a string value for a url according to the current values
        /// of <see cref="Frequency"/> and <see cref="FrequencyValue"/>
        /// </summary>
        /// <returns>A string</returns>
        /// <remarks>
        /// The base implemtation of this method returns a value suitable
        /// for forex queries and crypto queries. Override for other logic.
        /// </remarks>
        protected internal virtual string GetFrequencyParameter()
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