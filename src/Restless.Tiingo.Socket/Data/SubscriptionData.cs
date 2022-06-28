using System.Text.Json.Serialization;

namespace Restless.Tiingo.Socket.Data
{
    /// <summary>
    /// Represents the subscription data carried by a <see cref="SubscriptionMessage"/>
    /// </summary>
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