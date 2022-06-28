using Restless.Tiingo.Socket.Core;
using Restless.Tiingo.Socket.Data;
using System;
using System.Threading.Tasks;

namespace Restless.Tiingo.Socket.Client
{
    public class IEXClient : BaseClient
    {
        private const string EntryPoint = "iex";

        internal IEXClient(string apiToken) : base(apiToken)
        {
        }

        public async Task GetAsync(IEXParameters parms, Action<SocketMessage> callback)
        {
            if (await BeginOperationAsync(EntryPoint).ConfigureAwait(false))
            {
                await SubscribeAsync(EventData.FromParms(parms)).ConfigureAwait(false);
                await ReceiveDataAsync(json =>
                {
                    SocketMessage socketMessage = SocketMessage.Create(json);
                    if (socketMessage.IsMessageTypeIncluded(parms.MessageType))
                    {
                        callback(socketMessage.GetSocketMessage(GetSocketMessage));
                    }
                });
            }
        }

        private SocketMessage GetSocketMessage(RawDataMessage raw)
        {
            return raw.UpdateMessageType switch
            {
                "T" => IEXTradeMessage.Create(raw),
                "Q" => IEXQuoteMessage.Create(raw),
                "B" => IEXBreakMessage.Create(raw),
                _ => null
            };
        }
    }
}