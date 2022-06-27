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

        public async Task GetAsync(IEXParameters parms, Action<string> callback)
        {
            if (await BeginOperationAsync(EntryPoint).ConfigureAwait(false))
            {
                await SubscribeAsync(EventData.FromParms(parms)).ConfigureAwait(false);
                await ReceiveDataAsync(callback);
            }
        }


//{"messageType": "I", "data": {"subscriptionId": 8003440}, "response": {"message": "Success", "code": 200}}
//{"messageType": "H", "response": {"message": "HeartBeat", "code": 200}}
//{ "service": "crypto_data", "messageType": "A", "data": ["T", "btcusd", "2022-06-25T18:53:28.331000+00:00", "binance", 0.018049164, 21110.12632]}
//{ "service": "crypto_data", "messageType": "A", "data": ["T", "btcusd", "2022-06-25T18:53:28.443000+00:00", "binance", 0.010553664, 21110.12632]}
//{ "service": "crypto_data", "messageType": "A", "data": ["T", "btcusd", "2022-06-25T18:49:58.395949+00:00", "gdax", 0.000906, 21097.25]}
//{ "service": "crypto_data", "messageType": "A", "data": ["T", "btcusd", "2022-06-25T18:49:58.596675+00:00", "gdax", 0.00024229, 21097.25]}
//{ "service": "crypto_data", "messageType": "A", "data": ["T", "btcusd", "2022-06-25T18:49:58.596675+00:00", "gdax", 6.702e-05, 21097.24]}






    }
}