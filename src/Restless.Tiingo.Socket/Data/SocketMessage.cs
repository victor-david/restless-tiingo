using Restless.Tiingo.Socket.Core;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Restless.Tiingo.Socket.Data
{
    /// <summary>
    /// Represents the base socket message. All socket messages derive from this type
    /// </summary>
    /// <remarks>
    /// This is a base class, but an instance of this type is first obtained by deserializing the incoming json,
    /// which is why it isn't abstract and why <see cref="MessageType"/> is read/write.
    /// 
    /// Once the message type is determined (subscription, heartbeat, data update or close),
    /// another data type that derives from <see cref="SocketMessage"/> can be created and
    /// passed back to the caller.
    /// 
    /// For socket messages that carry data (TypeDataUpdate), the data arrives in a json array. The array
    /// is deserialized, then used to construct and populate the type that is passed back to the caller.
    /// 
    /// The caller receives all messages as the base type, <see cref="SocketMessage"/> and can cast
    /// appropiately as needed.
    /// </remarks>
    public class SocketMessage
    {
        private string json;

        public const string TypeSubscription = "I";
        public const string TypeHeartBeat = "H";
        public const string TypeDataUpdate = "A";
        public const string TypeError = "E";
        public const string TypeSocketClosed = "X";

        /// <summary>
        /// Gets the message type. There are five types:
        /// I = subscription message
        /// H = heartbeat message
        /// A = Data update message
        /// E = Api error message
        /// X = Socket closed message
        /// </summary>
        [JsonPropertyName("messageType")]
        public string MessageType { get; set; }

        internal static SocketMessage Create(string json)
        {
            SocketMessage socketMessage = JsonSerializer.Deserialize<SocketMessage>(json);
            socketMessage.json = json;
            return socketMessage;
        }

        internal bool IsMessageTypeIncluded(MessageType messageType)
        {
            return MessageType switch
            {
                TypeSubscription => messageType.HasFlag(Core.MessageType.Subscription),
                TypeHeartBeat => messageType.HasFlag(Core.MessageType.HeartBeat),
                TypeDataUpdate => messageType.HasFlag(Core.MessageType.DataUpdate),
                TypeError => messageType.HasFlag(Core.MessageType.Error),
                TypeSocketClosed => messageType.HasFlag(Core.MessageType.Close),
                _ => false
            };
        }

        internal SocketMessage GetSocketMessage(Func<RawDataMessage, SocketMessage> clientSpecificCallback)
        {
            if (MessageType == TypeSubscription)
            {
                return JsonSerializer.Deserialize<SubscriptionMessage>(json);
            }

            if (MessageType == TypeHeartBeat)
            {
                return JsonSerializer.Deserialize<HeartBeatMessage>(json);
            }

            if (MessageType == TypeDataUpdate)
            {
                RawDataMessage raw = JsonSerializer.Deserialize<RawDataMessage>(json);
                SocketMessage clientMessage = clientSpecificCallback(raw);
                return clientMessage ?? this;
            }

            if (MessageType == TypeError)
            {
                return JsonSerializer.Deserialize<SocketErrorMessage>(json);
            }

            if (MessageType == TypeSocketClosed)
            {
                return new SocketClosedMessage();
            }

            return this;
        }

        public override string ToString()
        {
            return $"Type {MessageType}";
        }
    }
}