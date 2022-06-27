using System.Text.Json.Serialization;

namespace Restless.Tiingo.Socket.Data
{
    /// <summary>
    /// Represents a heart beat message which is sent by the server
    /// at certain intervals when there isn't any data to send. 
    /// </summary>
    /// <remarks>
    /// A caller can request that this message is surfaced in order 
    /// to keep track of inactivity.
    /// 
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