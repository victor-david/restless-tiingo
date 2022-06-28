using System;

namespace Restless.Tiingo.Rest.Data
{
    /// <summary>
    /// Represents a pair of ticker symbols
    /// </summary>
    public class TickerPair
    {
        public string FromSymbol { get; }
        public string ToSymbol { get; }

        public TickerPair(string fromSymbol, string toSymbol)
        {
            FromSymbol = ValidateParm(fromSymbol);
            ToSymbol = ValidateParm(toSymbol);
        }

        public override string ToString()
        {
            return $"{FromSymbol}{ToSymbol}";
        }

        private string ValidateParm(string value)
        {
            return 
                string.IsNullOrWhiteSpace(value) ?
                throw new ArgumentException("Invalid value for ticker pair") :
                value.ToLowerInvariant();
        }
    }
}