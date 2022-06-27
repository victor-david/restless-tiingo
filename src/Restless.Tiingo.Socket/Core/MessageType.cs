using System;

namespace Restless.Tiingo.Socket.Core
{
    /// <summary>
    /// Provides a bit-mapped set of values that are used
    /// to specify which message types are surfaced to the client
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
        /// Close message
        /// </summary>
        Close = 8,
        /// <summary>
        /// All messages
        /// </summary>
        All = Subscription | HeartBeat | DataUpdate | Close
    }
}