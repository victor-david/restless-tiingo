using Restless.Tiingo.Socket.Core;

namespace Restless.Tiingo.Socket.Data
{
    /// <summary>
    /// Represents a single socket message for a crypto quote
    /// </summary>
    public class CryptoQuoteMessage : SocketDataQuoteMessage
    {
        /// <summary>
        /// The exchange the trade was done on.
        /// </summary>
        public string Exchange { get; protected set; }

        private CryptoQuoteMessage() : base(ServiceCode.Crypto, UpdateMessageType.Quote)
        {
            MessageType = TypeDataUpdate;
        }

        internal static CryptoQuoteMessage Create(RawDataMessage raw)
        {
            raw.ValidateData(DataIndex.MinimumSize.CryptoQuote);

            return new CryptoQuoteMessage()
            {
                AskPrice = raw.GetNumericAt(DataIndex.Crypto.Quote.AskPrice),
                AskSize = raw.GetNumericAt(DataIndex.Crypto.Quote.AskSize),
                BidPrice = raw.GetNumericAt(DataIndex.Crypto.Quote.BidPrice),
                BidSize = raw.GetNumericAt(DataIndex.Crypto.Quote.BidSize),
                Exchange = raw.GetStringAt(DataIndex.Crypto.Quote.Exchange),
                MidPrice = raw.GetNumericAt(DataIndex.Crypto.Quote.MidPrice),
                Ticker = raw.GetStringAt(DataIndex.Crypto.Quote.Ticker),
                Timestamp = raw.GetDateTimeAt(DataIndex.Crypto.Quote.Timestamp)
            };

        }
    }
}