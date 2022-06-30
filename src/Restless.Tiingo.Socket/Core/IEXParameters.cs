namespace Restless.Tiingo.Socket.Core
{
    /// <summary>
    /// Represents parameters used for an IEX socket operation
    /// </summary>
    public class IEXParameters : SocketParameters
    {
        /// <summary>
        /// Gets or sets the threshold level.
        /// Default is <see cref="IEXThreshold.LastTradeAndMajorQuote"/>
        /// </summary>
        public IEXThreshold Threshold { get; set; }

        public IEXParameters()
        {
            Threshold = IEXThreshold.LastTradeAndMajorQuote;
        }
    }
}