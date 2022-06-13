using System;
using System.Net.Http;

namespace Restless.Tiingo.Client
{
    public class TiiangoClient : IDisposable
    {
        #region Private
        private readonly IHttpClientWrapper client;
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new instance of the <see cref="TiiangoClient"/> class
        /// with the default client wrapper and the default timeout
        /// </summary>
        /// <param name="apiToken">The api token</param>
        /// <returns>An instance of <see cref="TiiangoClient"/></returns>
        public static TiiangoClient Create(string apiToken)
        {
            return new TiiangoClient(apiToken, new TimeSpan(0,0,30));
        }

        /// <summary>
        /// Creates a new instance of the <see cref="TiiangoClient"/> class
        /// with the default client wrapper and the specified timeout
        /// </summary>
        /// <param name="apiToken">The api token</param>
        /// <param name="timeout">The desired timeout</param>
        /// <returns>An instance of <see cref="TiiangoClient"/></returns>
        public static TiiangoClient Create(string apiToken, TimeSpan timeout)
        {
            return new TiiangoClient(apiToken, timeout);
        }

        private TiiangoClient(string apiToken, TimeSpan timeout)
        {
            client = new DefaultHttpClientWrapper(new HttpClient());
            client.SetTimeOut(timeout);
            _ = ValidateApiToken(apiToken);
            Stocks = new StocksClient(client, apiToken);
            Forex = new ForexClient(client, apiToken);
            News = new NewsClient(client, apiToken);
            Tickers = new TickersClient(client, apiToken);
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the stocks client
        /// </summary>
        public StocksClient Stocks { get; }

        /// <summary>
        /// Gets the forex client
        /// </summary>
        public ForexClient Forex { get; }

        /// <summary>
        /// Gets the news client
        /// </summary>
        public NewsClient News { get; }

        /// <summary>
        /// Gets the tickers client
        /// </summary>
        public TickersClient Tickers { get; }
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