using System.Text.Json.Serialization;

namespace Restless.Tiingo.Socket.Data
{
    /// <summary>
    /// Represents a heart beat message which is sent by the server
    /// at regular intervals. Observation shows every two minutes. 
    /// </summary>
    /// <remarks>
    /// {"messageType": "H", "response": {"message": "HeartBeat", "code": 200}}
    /// </remarks>
    public class HeartBeatMessage : SocketMessage
    {
        [JsonPropertyName("response")]
        public ResponseData Response { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()} {Response}";
        }
    }
}