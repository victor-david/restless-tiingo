using System.Text.Json.Serialization;

namespace Restless.Tiingo.Socket.Data
{
    /// <summary>
    /// Represents a subscription message. A caller can request
    /// that this message is surfaced in order to capture the subscription id.
    /// </summary>
    public class SubscriptionMessage : HeartBeatMessage
    {
        [JsonPropertyName("data")]
        public SubscriptionData Data { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()} {Data}";
        }
    }

    public class SubscriptionData
    {
        [JsonPropertyName("subscriptionId")]
        public int SubscriptionId { get; set; }

        public override string ToString()
        {
            return $"Sub id: {SubscriptionId}";
        }
    }
}
