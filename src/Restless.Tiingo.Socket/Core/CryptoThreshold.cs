namespace Restless.Tiingo.Socket.Core
{
    /// <summary>
    /// Provides enumerated values for the threshold of <see cref="CryptoParameters"/>
    /// </summary>
    public enum CryptoThreshold
    {
        /// <summary>
        /// Receive top-of-book AND last trade updates.
        /// </summary>
        TopOfBookAndLastTrade = 2,
        /// <summary>
        /// Receive onlt last trade updates.
        /// </summary>
        OnlyLastTrade = 5
    }
}