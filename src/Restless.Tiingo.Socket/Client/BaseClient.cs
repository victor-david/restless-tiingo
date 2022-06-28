using Restless.Tiingo.Socket.Data;
using System;
using System.IO;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Restless.Tiingo.Socket.Client
{
    /// <summary>
    /// Represents the base client for all socket handlers
    /// </summary>
    /// <remarks>
    /// This class handles the underlying socket operations
    /// for the various user-surfaced clients (forex, crypto, and IEX)
    /// </remarks>
    public abstract class BaseClient : IDisposable
    {
        private const string ConnectionRoot = "wss://api.tiingo.com";
        private readonly string apiToken;
        private ClientWebSocket socket;
        private CancellationTokenSource tokenSource;

        protected BaseClient(string apiToken)
        {
            this.apiToken = apiToken;
            CreateSocket();
        }

        public void Cancel()
        {
            tokenSource?.Cancel();
        }

        public async Task CloseAsync()
        {
            if (socket.State == WebSocketState.Open)
            {
                await socket.CloseOutputAsync(WebSocketCloseStatus.NormalClosure, string.Empty, tokenSource.Token).ConfigureAwait(false);
            }
        }

        public void Dispose()
        {
            socket?.Dispose();
        }

        protected async Task<bool> BeginOperationAsync(string entryPoint)
        {
            bool isValidState = IsValidBeginState();
            if (isValidState)
            {
                tokenSource = new CancellationTokenSource();
                await socket.ConnectAsync(new Uri($"{ConnectionRoot}/{entryPoint}"), tokenSource.Token).ConfigureAwait(false);
            }
            return isValidState;
        }

        protected async Task SubscribeAsync(EventData data)
        {
            SubscribeData sub = new(apiToken, data);
            byte[] buffer = Encoding.UTF8.GetBytes(sub.ToJson());
            ArraySegment<byte> messageSegment = new(buffer);
            await socket.SendAsync(messageSegment, WebSocketMessageType.Text, true, tokenSource.Token).ConfigureAwait(false);
        }

        protected async Task ReceiveDataAsync(Action<string> callback)
        {
            ArraySegment<byte> buffer = new(new byte[2048]);
            do
            {
                WebSocketReceiveResult result;
                using (MemoryStream memStream = new())
                {
                    do
                    {
                        result = await socket.ReceiveAsync(buffer, tokenSource.Token).ConfigureAwait(false);
                        memStream.Write(buffer.Array, buffer.Offset, result.Count);

                    } while (!result.EndOfMessage);

                    if (result.MessageType == WebSocketMessageType.Close)
                    {
                        callback(SocketClosedMessage.Json);
                        if (socket.State == WebSocketState.CloseReceived)
                        {
                            await socket.CloseOutputAsync(WebSocketCloseStatus.NormalClosure, string.Empty, tokenSource.Token);
                        }
                        break;
                    }

                    memStream.Seek(0, SeekOrigin.Begin);

                    using (StreamReader reader = new(memStream, Encoding.UTF8))
                    {
                        string readResult = await reader.ReadToEndAsync().ConfigureAwait(false);
                        callback(readResult);
                    }
                }
            } while (!tokenSource.IsCancellationRequested);
        }

        private bool IsValidBeginState()
        {
            return socket.State switch
            {
                WebSocketState.Aborted => CreateSocket(),
                WebSocketState.Closed => CreateSocket(),
                WebSocketState.None => true,
                _ => false,
            };
        }

        private bool CreateSocket()
        {
            socket = new ClientWebSocket();
            return true;
        }
    }
}