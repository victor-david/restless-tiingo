using Restless.Tiingo.Socket.Core;

//namespace Restless.Tiingo.Socket.Data
//{
//    public class IEXSocketMessage : SocketDataMessage
//    {
//        private const int MinDataLength = 1;

//        private IEXSocketMessage(UpdateMessageType updateMessageType) : base(ServiceCode.IEX, updateMessageType)
//        {
//            MessageType = TypeDataUpdate;
//        }

//        //           Type Date                                   Nanoseconds          Tic   BS   BP     MP
//        // {"data": ["Q", "2022-06-27T10:13:49.018242920-04:00", 1656339229018242920, "bp", 200, 28.61, 28.615, 28.62, 903, null, null, 0, 0, null, null, null]
//        internal static IEXSocketMessage Create(UpdateMessageType updateMessageType, RawDataMessage raw)
//        {
//            raw.ValidateData(MinDataLength);

//            return new IEXSocketMessage(updateMessageType)
//            {

//            };
//        }
//    }
//}