# Restless Tiingo

Restless Tiiango is a .Net library that enables you to access financial data from the Tiiango service.

## Usage examples

~~~c#
using Restless.Tiingo.Client;
using Restless.Tiingo.Core;
using Restless.Tiingo.Data;

private async void GetInfo()
{
    using (TiiangoClient client = TiiangoClient.Create("apitoken"))
    {
        TickerMeta data = await client.Stocks.GetMetaAsync("msft");

        StockDataPointCollection result = await client.Stocks.GetDataPointsAsync("msft", new TickerParameters()
        {
            StartDate = new DateTime(2020, 5, 15),
        });

        NewsItemCollection news = await client.News.GetNewsAsync(new NewsParameters()
        {
            StartDate = new DateTime(2022, 6, 6),
            Tickers = new string[] {"msft","sbux" },
            Sources = new string[] { "bloomberg.com" },
            Limit = 10
        });
    }
}
~~~

Note: In a production app, the client should not be so short lived. Normally, its something you create
at application startup and dispose of during application shut down. This article has more info:

https://docs.microsoft.com/en-us/dotnet/fundamentals/networking/httpclient-guidelines
