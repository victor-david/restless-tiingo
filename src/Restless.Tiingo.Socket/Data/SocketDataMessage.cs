using Restless.Tiingo.Socket.Core;
using System;

namespace Restless.Tiingo.Socket.Data
{
    /// <summary>
    /// Represents the base class for a socket message that carries data
    /// </summary>
    public abstract class SocketDataMessage : SocketMessage
    {
        public ServiceCode ServiceCode { get; }

        /// <summary>
        /// Specifies what type of update this is.
        /// </summary>
        public UpdateMessageType UpdateMessageType { get; }

        /// <summary>
        /// Ticker related to the asset.
        /// </summary>
        public string Ticker { get; protected set; }

        /// <summary>
        /// Date / time of the price update
        /// </summary>
        public DateTime Timestamp { get; protected set; }

        protected SocketDataMessage(ServiceCode serviceCode, UpdateMessageType updateMessageType)
        {
            ServiceCode = serviceCode;
            UpdateMessageType = updateMessageType;
        }


        public override string ToString()
        {
            return $"{base.ToString()} {ServiceCode} {UpdateMessageType} {Ticker} {Timestamp}";
        }
    }
}