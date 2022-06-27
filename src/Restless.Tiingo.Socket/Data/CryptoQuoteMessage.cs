using Restless.Tiingo.Socket.Core;

namespace Restless.Tiingo.Socket.Data
{
    /// <summary>
    /// Represents a single socket message for a crypto quote
    /// </summary>
    public class CryptoQuoteMessage : SocketDataQuoteMessage
    {
        private const int MinDataLength = 9;

        /// <summary>
        /// The exchange the trade was done on.
        /// </summary>
        [DataIndex(3)]
        public string Exchange { get; protected set; }

        private CryptoQuoteMessage() : base(ServiceCode.Crypto, UpdateMessageType.Quote)
        {
            MessageType = TypeDataUpdate;
        }


        //          Type Ticker    Date                                Exchange  Bid Size    Bid P    Mid P     Ask Size    Ask Price
        // --------------------------------------------------------------------------------------------------------------------------
        // "data": ["Q", "btcusd", "2022-06-26T00:39:59.436052+00:00", "kraken", 0.06559046, 21407.1, 21407.15, 2.81161919, 21407.2]
        internal static CryptoQuoteMessage Create(RawDataMessage raw)
        {
            raw.ValidateData(MinDataLength);

            return new CryptoQuoteMessage()
            {
                AskPrice = raw.GetNumericAt(8),
                AskSize = raw.GetNumericAt(7),
                BidPrice = raw.GetNumericAt(5),
                BidSize = raw.GetNumericAt(4),
                Exchange = raw.GetStringAt(3),
                MidPrice = raw.GetNumericAt(6),
                Ticker = raw.GetStringAt(1),
                Timestamp = raw.GetDateTimeAt(2)
            };

        }
    }
}