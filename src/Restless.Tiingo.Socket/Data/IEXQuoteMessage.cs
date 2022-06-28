using Restless.Tiingo.Socket.Core;

namespace Restless.Tiingo.Socket.Data
{
    /// <summary>
    /// Represents an IEX quote message
    /// </summary>
    public class IEXQuoteMessage : SocketDataQuoteMessage
    {
        public bool AfterHours { get; private set; }
        public bool Halted { get; private set; }
        public long Nanoseconds { get; private set; }

        private IEXQuoteMessage() : base(ServiceCode.IEX, UpdateMessageType.Quote)
        {
        }

        internal static IEXQuoteMessage Create(RawDataMessage raw)
        {
            raw.ValidateData(DataIndex.MinimumSize.IEX);

            return new IEXQuoteMessage()
            {
                AfterHours = raw.GetNumericAt(DataIndex.IEX.Quote.AfterHours) > 0,
                AskPrice = raw.GetNumericAt(DataIndex.IEX.Quote.AskPrice),
                AskSize = raw.GetNumericAt(DataIndex.IEX.Quote.AskSize),
                BidPrice = raw.GetNumericAt(DataIndex.IEX.Quote.BidPrice),
                BidSize = raw.GetNumericAt(DataIndex.IEX.Quote.BidSize),
                Halted = raw.GetNumericAt(DataIndex.IEX.Quote.Halted) > 0,
                Nanoseconds = (long)raw.GetNumericAt(DataIndex.IEX.Quote.Nanoseconds),
                MidPrice = raw.GetNumericAt(DataIndex.IEX.Quote.MidPrice),
                Ticker = raw.GetStringAt(DataIndex.IEX.Quote.Ticker),
                Timestamp = raw.GetDateTimeAt(DataIndex.IEX.Quote.Timestamp),
            };
        }
    }
}