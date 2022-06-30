using Restless.Tiingo.Socket.Data;

namespace Restless.Tiingo.Socket.Core
{
    /// <summary>
    /// Provides an enumeration of update message types.
    /// A value from this enumeration is passed back to the caller
    /// in a <see cref="SocketDataMessage"/>.
    /// </summary>
    public enum UpdateMessageType
    {
        /// <summary>
        ///  Last trade message. Used by crypto, iex
        /// </summary>
        Trade,
        /// <summary>
        ///  Top-of-book quote. Used by forex, crypto, iex
        /// </summary>
        Quote,
        /// <summary>
        /// Break message. Used by iex
        /// </summary>
        Break,
    }
}