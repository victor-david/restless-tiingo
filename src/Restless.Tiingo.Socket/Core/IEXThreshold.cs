namespace Restless.Tiingo.Socket.Core
{
    /// <summary>
    /// Provides enumerated values for the threshold of <see cref="IEXParameters"/>
    /// </summary>
    public enum IEXThreshold
    {
        /// <summary>
        /// Receive ALL Top-of-Book AND Last Trade updates.
        /// </summary>
        TopOfBookAndLastTrade = 0,
        /// <summary>
        /// Receive all Last Trade updates  and only Quote updates 
        /// that are deemed major updates by Tiingo systems.
        /// </summary>
        LastTradeAndMajorQuote = 5,
    }
}