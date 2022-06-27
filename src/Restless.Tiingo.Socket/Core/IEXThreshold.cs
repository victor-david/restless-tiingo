namespace Restless.Tiingo.Socket.Core
{
    public enum IEXThreshold
    {
        // A "thresholdLevel" of 0 means you will get ALL Top-of-Book AND Last Trade updates.
        // A "thresholdLevel" of 5 means you will get all Last Trade updates and only Quote updates that are deemed major updates by our system.
        TopOfBookAndLastTrade = 0,
        LastTradeAndMajorQuote = 5,
    }
}