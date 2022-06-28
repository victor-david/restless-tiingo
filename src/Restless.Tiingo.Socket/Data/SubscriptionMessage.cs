using System.Text.Json.Serialization;

namespace Restless.Tiingo.Socket.Data
{
    /// <summary>
    /// Represents a subscription message. A caller can request
    /// that this message is surfaced in order to capture the subscription id.
    /// </summary>
    public class SubscriptionMessage : SocketResponseMessage
    {
        [JsonPropertyName("data")]
        public SubscriptionData Data { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()} {Data}";
        }
    }
}