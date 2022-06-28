using Restless.Tiingo.Socket.Core;

namespace Restless.Tiingo.Socket.Data
{
    /// <summary>
    /// Represents an IEX trade message
    /// </summary>
    public class IEXTradeMessage : SocketDataMessage
    {
        public bool AfterHours { get; private set; }
        public bool InterMarket { get; private set; }
        public double LastPrice { get; private set; }
        public double LastSize { get; private set; }
        public long Nanoseconds { get; private set; }
        public bool NmsRule611 { get; private set; }
        public bool OddLot { get; private set; }

        private IEXTradeMessage() : base(ServiceCode.IEX, UpdateMessageType.Trade)
        {
            MessageType = TypeDataUpdate;
        }

        internal static IEXTradeMessage Create(RawDataMessage raw)
        {
            raw.ValidateData(DataIndex.MinimumSize.IEX);
             
            return new IEXTradeMessage()
            {
                AfterHours = raw.GetNumericAt(DataIndex.IEX.Trade.AfterHours) > 0,
                InterMarket = raw.GetNumericAt(DataIndex.IEX.Trade.Intermarket) > 0,
                LastPrice = raw.GetNumericAt(DataIndex.IEX.Trade.LastPrice),
                LastSize = raw.GetNumericAt(DataIndex.IEX.Trade.LastSize),
                Nanoseconds = (long)raw.GetNumericAt(DataIndex.IEX.Trade.Nanoseconds),
                NmsRule611 = raw.GetNumericAt(DataIndex.IEX.Trade.NmsRule611) > 0,
                OddLot = raw.GetNumericAt(DataIndex.IEX.Trade.OddLot) > 0,
                Ticker = raw.GetStringAt(DataIndex.IEX.Trade.Ticker),
                Timestamp = raw.GetDateTimeAt(DataIndex.IEX.Trade.Timestamp)
            };
        }
    }
}