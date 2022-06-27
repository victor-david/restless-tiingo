using System;
using System.Collections.Generic;
using System.Text;
using Restless.Tiingo.Socket.Core;

namespace Restless.Tiingo.Socket.Data
{
    public class IEXBreakMessage : SocketDataMessage
    {
        private IEXBreakMessage() : base (ServiceCode.IEX, UpdateMessageType.Break)
        {

        }

        internal static IEXBreakMessage Create(RawDataMessage raw)
        {
            return new IEXBreakMessage()
            {

            };
        }
    }
}