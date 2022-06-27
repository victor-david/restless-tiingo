namespace Restless.Tiingo.Socket.Core
{
    public class IEXParameters : SocketParameters
    {
        public IEXThreshold Threshold { get; set; }

        public IEXParameters()
        {
            Threshold = IEXThreshold.TopOfBookAndLastTrade;
        }
    }
}