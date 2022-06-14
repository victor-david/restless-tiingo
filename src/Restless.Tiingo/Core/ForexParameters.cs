using System;

namespace Restless.Tiingo.Core
{
    public class ForexParameters : ApiParameters
    {
        internal string GetFrequencyParameter()
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