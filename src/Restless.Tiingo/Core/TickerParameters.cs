using System;

namespace Restless.Tiingo.Core
{
    public class TickerParameters : ApiParameters
    {
        public ResampleFrequency Frequency { get; set; }
        public SortOption Sort { get; set; }

        public TickerParameters()
        {
            Frequency = ResampleFrequency.Daily;
            Sort = SortOption.None;
        }
    }
}