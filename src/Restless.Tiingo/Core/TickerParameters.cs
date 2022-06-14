namespace Restless.Tiingo.Core
{
    public class TickerParameters : ApiParameters
    {
        public TickerFrequency Frequency { get; set; }
        public SortOption Sort { get; set; }

        public TickerParameters()
        {
            Frequency = TickerFrequency.Daily;
            Sort = SortOption.None;
        }
    }
}