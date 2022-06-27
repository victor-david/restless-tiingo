namespace Restless.Tiingo.Socket.Core
{
    public class ForexParameters : SocketParameters
    {
        public ForexThreshold Threshold { get; set; }

        public ForexParameters()
        {
            Threshold = ForexThreshold.LastQuote;
        }
    }
}