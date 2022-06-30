using Restless.Tiingo.Socket.Data;

namespace Restless.Tiingo.Socket.Core
{
    /// <summary>
    /// Provides an enumeration of service codes.
    /// A value from this enumeration is passed back to the caller
    /// in a <see cref="SocketDataMessage"/>.
    /// </summary>
    public enum ServiceCode
    {
        /// <summary>
        /// Forex service
        /// </summary>
        Forex,
        /// <summary>
        /// Crypto service
        /// </summary>
        Crypto,
        /// <summary>
        /// IEX service.
        /// </summary>
        IEX,
    }
}