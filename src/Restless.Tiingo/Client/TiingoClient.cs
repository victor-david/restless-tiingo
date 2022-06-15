using System;
using System.Net.Http;

namespace Restless.Tiingo.Client
{
    public class TiingoClient : IDisposable
    {
        #region Private
        private readonly IHttpClientWrapper client;
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new instance of the <see cref="TiingoClient"/> class
        /// with the default client wrapper and the default timeout
        /// </summary>
        /// <param name="apiToken">The api token</param>
        /// <returns>An instance of <see cref="TiingoClient"/></returns>
        public static TiingoClient Create(string apiToken)
        {
            return new TiingoClient(apiToken, new TimeSpan(0,0,30));
        }

        /// <summary>
        /// Creates a new instance of the <see cref="TiingoClient"/> class
        /// with the default client wrapper and the specified timeout
        /// </summary>
        /// <param name="apiToken">The api token</param>
        /// <param name="timeout">The desired timeout</param>
        /// <returns>An instance of <see cref="TiingoClient"/></returns>
        public static TiingoClient Create(string apiToken, TimeSpan timeout)
        {
            return new TiingoClient(apiToken, timeout);
        }

        private TiingoClient(string apiToken, TimeSpan timeout)
        {
            client = new DefaultHttpClientWrapper(new HttpClient());
            client.SetTimeOut(timeout);
            _ = ValidateApiToken(apiToken);
            Ticker = new TickerClient(client, apiToken);
            Forex = new ForexClient(client, apiToken);
            Crypto = new CryptoClient(client, apiToken);
            News = new NewsClient(client, apiToken);
            TickerData = new TickerDataClient(client, apiToken);
            Search = new SearchClient(client, apiToken);
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the tickers client
        /// </summary>
        public TickerClient Ticker { get; }

        /// <summary>
        /// Gets the forex client
        /// </summary>
        public ForexClient Forex { get; }

        /// <summary>
        /// Gets the crypto client
        /// </summary>
        public CryptoClient Crypto { get; }

        /// <summary>
        /// Gets the news client
        /// </summary>
        public NewsClient News { get; }

        /// <summary>
        /// Gets the tickers client
        /// </summary>
        public TickerDataClient TickerData { get; }

        /// <summary>
        /// Gets the search client
        /// </summary>
        public SearchClient Search { get; }
        #endregion

        #region IDisposable
        /// <summary>
        /// Disposes the underlying client
        /// </summary>
        public void Dispose()
        {
            client?.Dispose();
        }
        #endregion

        #region Private methods
        private string ValidateApiToken(string token)
        {
            return string.IsNullOrWhiteSpace(token) ? throw new ArgumentException("Invalid api token") : token;
        }
        #endregion
    }
}