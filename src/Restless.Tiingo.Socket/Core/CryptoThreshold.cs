namespace Restless.Tiingo.Socket.Core
{
    public enum CryptoThreshold
    {
        // A "thresholdLevel" of 2 means you will get Top-of-Book AND Last Trade updates.
        // A "thresholdLevel" of 5 means you will get only Last Trade updates
        TopOfBookAndLastTrade = 2,
        OnlyLastTrade = 5
    }
}