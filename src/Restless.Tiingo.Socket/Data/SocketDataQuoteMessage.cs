using Restless.Tiingo.Socket.Core;

namespace Restless.Tiingo.Socket.Data
{
    /// <summary>
    /// Represents a single socket message for a crypto quote
    /// </summary>
    public abstract class SocketDataQuoteMessage : SocketDataMessage
    {
        /// <summary>
        /// The current lowest ask price.
        /// </summary>
        public double AskPrice { get; protected set; }

        /// <summary>
        /// The amount of the instrument at the ask price in the base currency.
        /// </summary>
        public double AskSize { get; protected set; }

        /// <summary>
        /// The current highest bid price.
        /// </summary>
        public double BidPrice { get; protected set; }


        /// <summary>
        /// The amount of the instrument at the bid price in the base currency.
        /// </summary>
        public double BidSize { get; protected set; }


        /// <summary>
        /// The mid price of the current timestamp when both <see cref="BidPrice"/> and "askPrice" are not-null. 
        /// In mathematical terms: mid = (bidPrice + askPrice) / 2.0
        /// </summary>
        public double MidPrice { get; protected set; }


        protected SocketDataQuoteMessage(ServiceCode serviceCode, UpdateMessageType updateMessageType) : base(serviceCode, updateMessageType)
        {
        }

        public override string ToString()
        {
            return $"{base.ToString()} Ask {AskSize}/{AskPrice} Bid {BidSize}/{BidPrice} Mid {MidPrice}";
        }
    }
}