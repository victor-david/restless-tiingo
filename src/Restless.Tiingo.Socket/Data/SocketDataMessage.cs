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
        [DataIndex(0, "FOREX:Quote, CRYPTO/IEX: Quote or Trade")]
        public UpdateMessageType UpdateMessageType { get; }

        /// <summary>
        /// Ticker related to the asset.
        /// </summary>
        [DataIndex(1, "FOREX/CRYPTO")]
        [DataIndex(3, "IEX")]
        public string Ticker { get; protected set; }

        /// <summary>
        /// Date / time of the price update
        /// </summary>
        [DataIndex(1, "IEX")]
        [DataIndex(2, "FOREX/CRYPTO")]
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