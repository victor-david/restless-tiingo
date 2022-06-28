using System;
using System.Net.Http;

namespace Restless.Tiingo.Rest.Client
{
    public class TiingoClient : IDisposable
    {
        #region Private
        private readonly IHttpClientWrapper client;
        #endregion

        #region Static fields
        /// <summary>
        /// Gets the default timeout (30 seconds)
        /// </summary>
        public static readonly TimeSpan DefaultTimeout = new(0, 0, 30);
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new instance of <see cref="TiingoClient"/> with the default 
        /// client wrapper and <see cref="DefaultTimeout"/>
        /// </summary>
        /// <param name="apiToken">The api token</param>
        /// <returns>An instance of <see cref="TiingoClient"/></returns>
        public static TiingoClient Create(string apiToken)
        {
            return new TiingoClient(apiToken, new DefaultHttpClientWrapper(new HttpClient()), DefaultTimeout);
        }

        /// <summary>
        /// Creates a new instance of <see cref="TiingoClient"/> with the default
        /// client wrapper and the specified timeout
        /// </summary>
        /// <param name="apiToken">The api token</param>
        /// <param name="timeout">The desired timeout</param>
        /// <returns>An instance of <see cref="TiingoClient"/></returns>
        public static TiingoClient Create(string apiToken, TimeSpan timeout)
        {
            return new TiingoClient(apiToken, new DefaultHttpClientWrapper(new HttpClient()), timeout);
        }

        /// <summary>
        /// Creates a new instance of <see cref="TiingoClient"/> with the specified
        /// http client and <see cref="DefaultTimeout"/>
        /// </summary>
        /// <param name="apiToken">The api token</param>
        /// <param name="httpClient">The http client</param>
        /// <returns>An instance of <see cref="TiingoClient"/></returns>
        public static TiingoClient Create(string apiToken, HttpClient httpClient)
        {
            return new TiingoClient(apiToken, new DefaultHttpClientWrapper(httpClient), DefaultTimeout);
        }

        /// <summary>
        /// Creates a new instance of <see cref="TiingoClient"/> with the specified
        /// http client wrapper and <see cref="DefaultTimeout"/>
        /// </summary>
        /// <param name="apiToken">The api token</param>
        /// <param name="clientWrapper">The http client wrapper</param>
        /// <returns>An instance of <see cref="TiingoClient"/></returns>
        public static TiingoClient Create(string apiToken, IHttpClientWrapper clientWrapper)
        {
            return new TiingoClient(apiToken, clientWrapper, DefaultTimeout);
        }

        private TiingoClient(string apiToken, IHttpClientWrapper clientWrapper, TimeSpan timeout)
        {
            client = clientWrapper ?? throw new ArgumentNullException(nameof(clientWrapper));
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