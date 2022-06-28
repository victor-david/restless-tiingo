using System.Text.Json.Serialization;

namespace Restless.Tiingo.Socket.Data
{
    /// <summary>
    /// Represents a socket response message. Does not carry data. 
    /// Used for <see cref="HeartBeatMessage"/> and <see cref="SubscriptionMessage"/>
    /// </summary>
    public abstract class SocketResponseMessage : SocketMessage
    {
        [JsonPropertyName("response")]
        public ResponseData Response { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()} {Response}";
        }
    }
}