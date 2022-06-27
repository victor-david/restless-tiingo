using Restless.Tiingo.Socket.Core;

namespace Restless.Tiingo.Socket.Data
{
    /// <summary>
    /// Represents a single socket message for a crypto trade update
    /// </summary>
    public class CryptoTradeMessage : SocketDataMessage
    {
        private const int MinDataLength = 6;

        /// <summary>
        /// The exchange the trade was done on.
        /// </summary>
        [DataIndex(3)]
        public string Exchange { get; private set; }

        /// <summary>
        /// The amount of crypto volume done at the last price in the base currency.
        /// </summary>
        [DataIndex(4)]
        public double LastSize { get; private set; }

        /// <summary>
        /// The last price the last trade was executed at.
        /// </summary>
        [DataIndex(5)]
        public double LastPrice { get; private set; }

        #region Constructors
        private CryptoTradeMessage() : base(ServiceCode.Crypto, UpdateMessageType.Trade)
        {
            MessageType = TypeDataUpdate;
        }

        // "data": ["T", "btcusd", "2022-06-25T18:53:28.331000+00:00", "binance", 0.018049164, 21110.12632]
        internal static CryptoTradeMessage Create(RawDataMessage raw)
        {
            raw.ValidateData(MinDataLength);

            return new CryptoTradeMessage()
            {
                Exchange = raw.GetStringAt(3),
                LastPrice = raw.GetNumericAt(5),
                LastSize = raw.GetNumericAt(4),
                Ticker = raw.GetStringAt(1),
                Timestamp = raw.GetDateTimeAt(2)
            };
        }
        #endregion

        public override string ToString()
        {
            return $"{base.ToString()} {Exchange} {LastSize} {LastPrice}";
        }
    }
}