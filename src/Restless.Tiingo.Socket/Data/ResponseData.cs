using System.Text.Json.Serialization;

namespace Restless.Tiingo.Socket.Data
{
    /// <summary>
    /// "response": {"message": "HeartBeat", "code": 200}
    /// </summary>
    public class ResponseData
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("code")]
        public int Code { get; set; }

        public override string ToString()
        {
            return $"Message: {Message} Code: {Code}";
        }
    }
}