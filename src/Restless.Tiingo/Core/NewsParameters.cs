namespace Restless.Tiingo.Core
{
    public class NewsParameters : ApiParameters
    {
        public int Limit { get; set; }
        public string[] Sources { get; set; }
        public string[] Tags { get; set; }
        public string[] Tickers { get; set; }
    }
}