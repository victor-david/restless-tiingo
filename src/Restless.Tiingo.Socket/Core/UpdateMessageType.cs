namespace Restless.Tiingo.Socket.Core
{
    public enum UpdateMessageType
    {
        /// <summary>
        ///  Last trade message. Used by crypto, iex
        /// </summary>
        Trade,
        /// <summary>
        ///  Top-of-book quote. Used by forex, crypto, iex
        /// </summary>
        Quote,
        /// <summary>
        /// Break message. Used by iex
        /// </summary>
        Break,
    }
}