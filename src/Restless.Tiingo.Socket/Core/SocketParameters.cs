namespace Restless.Tiingo.Socket.Core
{
    /// <summary>
    /// Represents the base class for socket parameters
    /// </summary>
    public abstract class SocketParameters
    {
        /// <summary>
        /// Gets or sets the bit-mapped enumeration of message
        /// type(s) to surface to the client
        /// </summary>
        public MessageType MessageType { get; set; }

        /// <summary>
        /// Gets or sets an array of tickers
        /// </summary>
        public string[] Tickers { get; set; }

        protected SocketParameters()
        {
            MessageType = MessageType.All;
        }
    }
}