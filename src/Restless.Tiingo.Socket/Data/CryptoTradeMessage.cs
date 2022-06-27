using Restless.Tiingo.Socket.Core;

namespace Restless.Tiingo.Socket.Data
{
    /// <summary>
    /// Represents a single socket message for a crypto trade update
    /// </summary>
    public class CryptoTradeMessage : SocketDataMessage
    {
        /// <summary>
        /// The exchange the trade was done on.
        /// </summary>
        public string Exchange { get; private set; }

        /// <summary>
        /// The amount of crypto volume done at the last price in the base currency.
        /// </summary>
        public double LastSize { get; private set; }

        /// <summary>
        /// The last price the last trade was executed at.
        /// </summary>
        public double LastPrice { get; private set; }

        #region Constructors
        private CryptoTradeMessage() : base(ServiceCode.Crypto, UpdateMessageType.Trade)
        {
            MessageType = TypeDataUpdate;
        }

        internal static CryptoTradeMessage Create(RawDataMessage raw)
        {
            raw.ValidateData(DataIndex.MinimumSize.CryptoTrade);

            return new CryptoTradeMessage()
            {
                Exchange = raw.GetStringAt(DataIndex.Crypto.Trade.Exchange),
                LastPrice = raw.GetNumericAt(DataIndex.Crypto.Trade.LastPrice),
                LastSize = raw.GetNumericAt(DataIndex.Crypto.Trade.LastSize),
                Ticker = raw.GetStringAt(DataIndex.Crypto.Trade.Ticker),
                Timestamp = raw.GetDateTimeAt(DataIndex.Crypto.Trade.Timestamp)
            };
        }
        #endregion

        public override string ToString()
        {
            return $"{base.ToString()} {Exchange} {LastSize} {LastPrice}";
        }
    }
}