using System;

namespace Restless.Tiingo.Socket.Core
{
    /// <summary>
    /// Provides a bit-mapped set of values that are used to specify
    /// which message types are surfaced to the caller. Callers specify
    /// which message types they want to receive in <see cref="SocketParameters"/>
    /// </summary>
    [Flags]
    public enum MessageType
    {
        /// <summary>
        /// No messages
        /// </summary>
        None = 0,
        /// <summary>
        /// Subscription message
        /// </summary>
        Subscription = 1,
        /// <summary>
        /// Heart beat message
        /// </summary>
        HeartBeat = 2,
        /// <summary>
        /// Data update message
        /// </summary>
        DataUpdate = 4,
        /// <summary>
        /// Api error message
        /// </summary>
        Error = 8,
        /// <summary>
        /// Close message
        /// </summary>
        Close = 16,
        /// <summary>
        /// All messages
        /// </summary>
        All = Subscription | HeartBeat | DataUpdate | Error | Close
    }
}