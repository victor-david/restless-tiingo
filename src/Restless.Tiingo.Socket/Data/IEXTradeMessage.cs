using Restless.Tiingo.Socket.Core;

namespace Restless.Tiingo.Socket.Data
{
    public class IEXTradeMessage : SocketDataMessage
    {
        private const int MinDataLength = 1;

        private IEXTradeMessage() : base(ServiceCode.IEX, UpdateMessageType.Trade)
        {
            MessageType = TypeDataUpdate;
        }

        //           Type Date
        // {"data": ["T", "2022-06-27T10:13:49.018115265-04:00", 1656339229018115265, "chk", null, null, null, null, null, 82.72, 50, null, 0, 1, 1, 0]
        internal static IEXTradeMessage Create(RawDataMessage raw)
        {
            raw.ValidateData(MinDataLength);

            return new IEXTradeMessage()
            {

            };
        }
    }
}