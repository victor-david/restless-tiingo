using System;
using System.Collections.Generic;
using System.Text;
using Restless.Tiingo.Socket.Core;

namespace Restless.Tiingo.Socket.Data
{
    public class IEXQuoteMessage : SocketDataQuoteMessage
    {
        private IEXQuoteMessage() : base(ServiceCode.IEX, UpdateMessageType.Quote)
        {
        }

        internal static IEXQuoteMessage Create(RawDataMessage raw)
        {
            raw.ValidateData(DataIndex.MinimumSize.IEX);

            return new IEXQuoteMessage()
            {
                AskPrice = raw.GetNumericAt(DataIndex.IEX.Quote.AskPrice),
                AskSize = raw.GetNumericAt(DataIndex.IEX.Quote.AskSize),
                BidPrice = raw.GetNumericAt(DataIndex.IEX.Quote.BidPrice),
                BidSize = raw.GetNumericAt(DataIndex.IEX.Quote.BidSize),
                MidPrice = raw.GetNumericAt(DataIndex.IEX.Quote.MidPrice),
                Ticker = raw.GetStringAt(DataIndex.IEX.Quote.Ticker),
                Timestamp = raw.GetDateTimeAt(DataIndex.IEX.Quote.Timestamp),
            };
        }
    }
}