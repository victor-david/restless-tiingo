namespace Restless.Tiingo.Socket.Data
{
    /// <summary>
    /// Represents a pseudo close message
    /// </summary>
    /// <remarks>
    /// This is a pseudo message, generated when the socket is closed.
    /// A caller can request that this message is surfaced.
    /// </remarks>
    public class SocketClosedMessage : SocketMessage
    {
        internal const string Json = "{\"messageType\": \"X\"}";

        internal SocketClosedMessage()
        {
            MessageType = TypeSocketClosed;
        }

        public override string ToString()
        {
            return $"{base.ToString()} socket closed";
        }
    }
}