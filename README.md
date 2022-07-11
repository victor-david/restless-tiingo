# Restless Tiingo

**Restless Tiingo** is a .Net standard library that enables you to access financial data from the Tiingo service.
You can access the data via the REST api or via web sockets. There are two assemblies:

### Restless.Tiingo
[![Nuget](https://img.shields.io/nuget/v/Restless.Tiingo.svg?style=flat-square)](https://www.nuget.org/packages/Restless.Tiingo/)

This assembly provides access to Tiingo REST services. You can get:

- Ticker meta data and prices
- Forex bids and prices
- Crypto meta data and prices
- Tiingo news feed

You can also access the Tiingo search query endpoint to obtain supported symbols, etc.

### Restless.Tiingo.Socket
[![Nuget](https://img.shields.io/nuget/v/Restless.Tiingo.Socket.svg?style=flat-square)](https://www.nuget.org/packages/Restless.Tiingo.Socket/)

This assembly provides access to Tiingo web socket services. You can get streaming data for:

- Forex quotes
- Crypto quotes and trades
- IEX quotes and trades

## Usage examples (REST)

~~~c#
using Restless.Tiingo.Client;
using Restless.Tiingo.Core;
using Restless.Tiingo.Data;
~~~

~~~c#
// Create a client (other Create() overloads available)
TiingoClient client = TiingoClient.Create("apiToken");

// Get ticker meta data
TickerMetaData tickerMeta = await client.Ticker.GetMetaDataAsync("msft");
if (tickerMeta.ExchangeCode == "NYSE")
{
}

// Get price data points for a ticker
TickerDataPointCollection tickerData = await client.Ticker.GetDataPointsAsync(new TickerParameters()
{
    Ticker = "msft",
    StartDate = new DateTime(2022, 1, 1),
    Frequency = FrequencyUnit.Week,
    FrequencyValue = 1
});

tickerData.ForEach(item =>
{
    if (item.AdjustedClose > item.AdjustedOpen)
    {
    }
});

// Get supported forex pairs
ForexMetaDataCollection forexMeta = await client.Forex.GetSupportedMetaDataAsync();
forexMeta.ForEach(item =>
{
    // Note: Tiingo delivers some symbols upper case, some lower
    if (item.BaseCurrency.ToLowerInvariant() == "usd")
    {
    }
});

// Get all available daily forex rates for USD/MXN
ForexDataPointCollection forexData = await client.Forex.GetDataPointsAsync(new ForexParameters()
{
    Tickers = new TickerPair[]
    {
        new TickerPair("usd", "mxn"),
    },
    StartDate = DateTime.MinValue,
    Frequency = FrequencyUnit.Day,
    FrequencyValue = 1
});

forexData.ForEach(item =>
{
});

// dispose of client
client.Dispose();
~~~

Note: In a production app, the client should not be so short lived. Normally, its something you create
at application startup and dispose of during application shut down. This article has more info:

https://docs.microsoft.com/en-us/dotnet/fundamentals/networking/httpclient-guidelines

## Usage examples (socket)
~~~c#
using Restless.Tiingo.Socket.Client;
using Restless.Tiingo.Socket.Core;
using Restless.Tiingo.Socket.Data;
using System.Diagnostics;
~~~

### Forex
~~~c#
using (TiingoClient client = TiingoClient.Create("apitoken"))
{
    await client.Forex.GetAsync(new ForexParameters()
    {
        // this is the default
        MessageType = MessageType.All,
        // this is the default
        Threshold = ForexThreshold.LastQuote,
        // receive only specified tickers. Default is all tickers
        Tickers = new string[] { "usdmxn" }
    }, result =>
    {
        if (result is SubscriptionMessage sub)
        {
            // save subscription id
        }
        if (result is ForexQuoteMessage quote)
        {
            Debug.WriteLine($"{quote.Timestamp} {quote.BidPrice} {quote.MidPrice}");
        }

        if (result is SocketClosedMessage)
        {
            Debug.WriteLine("Closed the socket. Good bye");
        }
    });
}
~~~

### Crypto

~~~c#
using (TiingoClient client = TiingoClient.Create("apitoken"))
{
    await client.Crypto.GetAsync(new CryptoParameters()
    {
        // Only surface data update messages (no subscription message, etc.)
        MessageType = MessageType.DataUpdate,
        Threshold = CryptoThreshold.OnlyLastTrade,
        Tickers = new string[] {"btcusd"}
    }, result =>
    {
        if (result is CryptoTradeMessage trade)
        {
            Debug.WriteLine($"{trade.Exchange} {trade.Timestamp} {trade.LastPrice}");
        }
    });
}
~~~

## Questions
If you have any questions or see something that isn't right, feel free to open an issue.
Although the majority of the pieces are working, this is still currently a work in progress
