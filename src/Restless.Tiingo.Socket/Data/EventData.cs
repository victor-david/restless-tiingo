using Restless.Tiingo.Socket.Core;
using System.Text.Json.Serialization;

namespace Restless.Tiingo.Socket.Data
{
    /// <summary>
    /// Represents event data that is sent when establishing a connection.
    /// This class cannot be instaniated outside of this assembly. It is
    /// only json serialized, not deserialized, so it does not require
    /// a public constructor
    /// </summary>
    public class EventData
    {
        [JsonPropertyName("thresholdLevel")]
        public int ThresholdLevel { get; set; }

        [JsonPropertyName("tickers")]
        public string[] Tickers { get; set; }

        private EventData()
        {
        }

        internal static EventData FromParms(ForexParameters parms)
        {
            return new EventData()
            {
                ThresholdLevel = (int)parms.Threshold,
                Tickers = parms.Tickers
            };
        }

        internal static EventData FromParms(CryptoParameters parms)
        {
            return new EventData()
            {
                ThresholdLevel = (int)parms.Threshold,
                Tickers = parms.Tickers
            };
        }

        internal static EventData FromParms(IEXParameters parms)
        {
            return new EventData()
            {
                ThresholdLevel = (int)parms.Threshold,
                Tickers = parms.Tickers
            };
        }
    }
}