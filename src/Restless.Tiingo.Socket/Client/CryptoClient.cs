using Restless.Tiingo.Socket.Core;
using Restless.Tiingo.Socket.Data;
using System;
using System.Threading.Tasks;

namespace Restless.Tiingo.Socket.Client
{
    public class CryptoClient : BaseClient
    {
        private const string EntryPoint = "crypto";

        internal CryptoClient(string apiToken) : base(apiToken)
        {
        }

        public async Task GetAsync(CryptoParameters parms, Action<SocketMessage> callback)
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
                "T" => CryptoTradeMessage.Create(raw),
                "Q" => CryptoQuoteMessage.Create(raw),
                _ => null
            };
        }
    }
}