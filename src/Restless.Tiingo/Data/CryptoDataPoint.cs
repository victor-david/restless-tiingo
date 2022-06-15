using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Restless.Tiingo.Data
{
//    public abstract class DataPoint
//    {
//        [JsonPropertyName("close")]
//        public decimal Close { get; set; }

//        [JsonPropertyName("date")]
//        public DateTime Date { get; set; }

//        [JsonPropertyName("high")]
//        public decimal High { get; set; }

//        [JsonPropertyName("low")]
//        public decimal Low { get; set; }

//        [JsonPropertyName("open")]
//        public decimal Open { get; set; }
//    }

    public class CryptoDataPoint : DataPoint
    {
        [JsonPropertyName("tradesDone")]
        public decimal TradesDone { get; set; }

        [JsonPropertyName("volume")]
        public decimal Volume { get; set; }

        [JsonPropertyName("volumeNotional")]
        public decimal VolumeNotional { get; set; }
    }


    // {
    //             "close":32184.675174743374,
    // "volumeNotional":5772772584.556077,
    //                 "low":28966.56341899368,
    //                 "high":33348.09185688231,
    //                "date":"2021-01-02T00:00:00+00:00",
    //                  "open":29346.32038648604,
    //                "tradesDone":2556809.0,
    // "volume":179364.01573772},

}