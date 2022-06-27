namespace Restless.Tiingo.Socket.Core
{
    public class CryptoParameters : SocketParameters
    {
        public CryptoThreshold Threshold { get; set; }

        public CryptoParameters()
        {
            Threshold = CryptoThreshold.TopOfBookAndLastTrade;
        }
    }
}