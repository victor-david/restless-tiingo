# Restless Tiingo

**Restless Tiingo** is a .Net library that enables you to access financial data from the Tiingo service.
The following services are supported:

- Ticker - Provides ticker meta data and prices
- News - Provides access to the Tiingo news feed
- Search - Enables you to query the Tiingo service to obtain supported symbols, etc.
- Crypto - Provides access to crypto prices and meta data

## Usage examples


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
    Ticker = new TickerPair("usd", "mxn"),
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
