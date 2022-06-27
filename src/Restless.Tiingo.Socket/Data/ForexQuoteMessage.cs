using Restless.Tiingo.Socket.Core;

namespace Restless.Tiingo.Socket.Data
{
    public class ForexQuoteMessage : SocketDataQuoteMessage
    {
        private ForexQuoteMessage() : base(ServiceCode.Forex, UpdateMessageType.Quote)
        {
            MessageType = TypeDataUpdate;
        }

        internal static ForexQuoteMessage Create(RawDataMessage raw)
        {
            raw.ValidateData(DataIndex.MinimumSize.ForexQuote);

            return new ForexQuoteMessage()
            {
                AskPrice = raw.GetNumericAt(DataIndex.Forex.Quote.AskPrice),
                AskSize = raw.GetNumericAt(DataIndex.Forex.Quote.AskSize),
                BidPrice = raw.GetNumericAt(DataIndex.Forex.Quote.BidPrice),
                BidSize = raw.GetNumericAt(DataIndex.Forex.Quote.BidSize),
                MidPrice = raw.GetNumericAt(DataIndex.Forex.Quote.MidPrice),
                Ticker = raw.GetStringAt(DataIndex.Forex.Quote.Ticker),
                Timestamp = raw.GetDateTimeAt(DataIndex.Forex.Quote.Timestamp)
            };
        }
    }
}