using Restless.Tiingo.Rest.Data;
using System;

namespace Restless.Tiingo.Rest.Core
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