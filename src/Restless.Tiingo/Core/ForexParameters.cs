using Restless.Tiingo.Data;
using System;

namespace Restless.Tiingo.Core
{
    /// <summary>
    /// Represents parameters used in a forex operation
    /// </summary>
    public class ForexParameters : FrequencyParameters, IValidator
    {
        public TickerPair Ticker { get; set; }

        public void Validate()
        {
            _ = Ticker ?? throw new ArgumentNullException(nameof(Ticker));
        }
    }
}