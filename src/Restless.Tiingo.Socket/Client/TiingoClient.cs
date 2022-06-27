using System;
using System.Threading.Tasks;

namespace Restless.Tiingo.Socket.Client
{
    public class TiingoClient : IDisposable
    {
        #region Constructors
        /// <summary>
        /// Creates a new instance of <see cref="TiingoClient"/>
        /// </summary>
        /// <param name="apiToken">The api token</param>
        /// <returns>An instance of <see cref="TiingoClient"/></returns>
        public static TiingoClient Create(string apiToken)
        {
            return new TiingoClient(apiToken);
        }

        private TiingoClient(string apiToken)
        {
            _ = ValidateApiToken(apiToken);
            Forex = new ForexClient(apiToken);
            Crypto = new CryptoClient(apiToken);
            IEX = new IEXClient(apiToken);
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the forex client
        /// </summary>
        public ForexClient Forex { get; }

        /// <summary>
        /// Gets the crypto client
        /// </summary>
        public CryptoClient Crypto { get; }

        /// <summary>
        /// Gets the IEX client
        /// </summary>
        public IEXClient IEX { get; }
        #endregion

        #region IDisposable
        /// <summary>
        /// Disposes the underlying clients
        /// </summary>
        public void Dispose()
        {
            Forex.Dispose();
            Crypto.Dispose();
            IEX.Dispose();
        }
        #endregion

        public async Task CloseAllAsync()
        {
            await Forex.CloseAsync().ConfigureAwait(false);
            await Crypto.CloseAsync().ConfigureAwait(false);
            await IEX.CloseAsync().ConfigureAwait(false);
        }

        #region Private methods
        private string ValidateApiToken(string token)
        {
            return string.IsNullOrWhiteSpace(token) ? throw new ArgumentException("Invalid api token") : token;
        }
        #endregion
    }
}