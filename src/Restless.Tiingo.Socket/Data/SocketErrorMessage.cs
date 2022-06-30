namespace Restless.Tiingo.Socket.Data
{
    /// <summary>
    /// Represents an API error response from the socket server
    /// </summary>
    /// <remarks>
    /// Example: {"response": {"code": 400, "message": "thresholdLevel not valid"}, "messageType": "E"}
    /// </remarks>
    public class SocketErrorMessage : SocketResponseMessage
    {
    }
}