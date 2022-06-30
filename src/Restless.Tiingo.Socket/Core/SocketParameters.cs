namespace Restless.Tiingo.Socket.Core
{
    /// <summary>
    /// Represents the base class for socket parameters.
    /// All socket parameters derive from this type.
    /// </summary>
    public abstract class SocketParameters
    {
        /// <summary>
        /// Gets or sets the bit-mapped enumeration of message type(s) to surface to the caller. 
        /// The default is <see cref="MessageType.All"/>
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