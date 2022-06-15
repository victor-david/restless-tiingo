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

private async void GetInfo()
{
    using (TiiangoClient client = TiiangoClient.Create("apitoken"))
    {
        TickerMetaData data = await client.Ticker.GetMetaDataAsync("msft");

        TickerDataPointCollection points = await client.Ticker.GetDataPointsAsync("msft", new TickerParameters()
        {
            StartDate = new DateTime(2020, 5, 15),
        });

        NewsItemCollection news = await client.News.GetNewsAsync(new NewsParameters()
        {
            StartDate = new DateTime(2022, 6, 6),
            Tickers = new string[] { "msft", "sbux" },
            Sources = new string[] { "bloomberg.com" },
            Limit = 10
        });

        SearchResultCollection results = await client.Search.GetSearchResultsAsync("dow jones", new SearchParameters()
        {
            Limit = 50
        });
    }
}
~~~

Note: In a production app, the client should not be so short lived. Normally, its something you create
at application startup and dispose of during application shut down. This article has more info:

https://docs.microsoft.com/en-us/dotnet/fundamentals/networking/httpclient-guidelines
