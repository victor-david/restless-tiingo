namespace Restless.Tiingo.Socket.Data
{
    /// <summary>
    /// Represents a heart beat message which is sent by the server
    /// at regular intervals. Observation shows every two minutes. 
    /// </summary>
    /// <remarks>
    /// Example: {"messageType": "H", "response": {"message": "HeartBeat", "code": 200}}
    /// </remarks>
    public class HeartBeatMessage : SocketResponseMessage
    {
    }
}