using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Restless.Tiingo.Socket.Data
{
    public class SubscribeData
    {
        private readonly JsonSerializerOptions jsonOptions;

        [JsonPropertyName("eventName")]
        public string EventName { get; set; }

        [JsonPropertyName("authorization")]
        public string Token { get; set; }

        [JsonPropertyName("eventData")]
        public EventData EventData { get; set; }

        internal SubscribeData(string token, EventData eventData)
        {
            EventName = "subscribe";
            Token = token;
            EventData = eventData ?? throw new ArgumentNullException(nameof(eventData));
            jsonOptions = new()
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };
        }

        internal string ToJson()
        {
            return JsonSerializer.Serialize(this, jsonOptions);
        }

    }
}
