using Restless.Tiingo.Socket.Core;

namespace Restless.Tiingo.Socket.Data
{
    public class ForexQuoteMessage : SocketDataQuoteMessage
    {
        private const int MinDataLength = 8;

        private ForexQuoteMessage() : base(ServiceCode.Forex, UpdateMessageType.Quote)
        {
            MessageType = TypeDataUpdate;
        }

        //          Type Ticker    Date                                Bid Size   Bid P     Mid P      Ask Size   Ask Price
        // ----------------------------------------------------------------------------------------------------------------
        // "data": ["Q", "usdmxn", "2022-06-27T00:36:26.892000+00:00", 1000000.0, 19.90169, 19.909185, 1000000.0, 19.91668]
        internal static ForexQuoteMessage Create(RawDataMessage raw)
        {
            raw.ValidateData(MinDataLength);

            return new ForexQuoteMessage()
            {
                AskPrice = raw.GetNumericAt(7),
                AskSize = raw.GetNumericAt(6),
                BidPrice = raw.GetNumericAt(4),
                BidSize = raw.GetNumericAt(3),
                MidPrice = raw.GetNumericAt(5),
                Ticker = raw.GetStringAt(1),
                Timestamp = raw.GetDateTimeAt(2)
            };
        }
    }
}