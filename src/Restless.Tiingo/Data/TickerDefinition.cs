using CsvHelper.Configuration.Attributes;
using Restless.Tiingo.Core;
using System;

namespace Restless.Tiingo.Data
{
    public class TickerDefinition
    {
        //ticker,exchange,assetType,priceCurrency,startDate,endDate
        // 1,SHE,Stock,CNY,1/4/2007,6/9/2022
        [Name("ticker")]
        public string Ticker { get; set; }

        [Name("exchange")]
        public string Exchange { get; set; }

        [Name("assetType")]
        public string AssetType { get; set; }

        [Name("priceCurrency")]
        public string Currency { get; set; }

        [Name("startDate")]
        public DateTime? StartDate { get; set; }

        [Name("endDate")]
        public DateTime? EndDate { get; set; }

        public override string ToString()
        {
            return $"Ticker:{Ticker} Exchange:{Exchange} Type:{AssetType} Currency:{Currency} Start:{StartDate} End:{EndDate}";
        }

        internal bool Include(TickerDefinitionParameters parms)
        {
            return
                Include(StartDate, parms.IgnoreNullDates) &&
                Include(EndDate, parms.IgnoreNullDates) &&
                Include(AssetType, parms.AssetType) &&
                IncludeStrict(Currency, parms.Currency) &&
                Include(Exchange, parms.Exchange) &&
                Include(Ticker, parms.Ticker);
        }

        private bool Include(string instanceValue, string parmValue)
        {
            return
                string.IsNullOrEmpty(instanceValue) ||
                string.IsNullOrEmpty(parmValue) ||
                instanceValue.ToLowerInvariant().StartsWith(parmValue.ToLowerInvariant());
        }

        private bool IncludeStrict(string instanceValue, string parmValue)
        {
            return
                string.IsNullOrEmpty(instanceValue) ||
                string.IsNullOrEmpty(parmValue) ||
                instanceValue.ToLowerInvariant() == parmValue.ToLowerInvariant();
        }

        private bool Include(DateTime? date, bool ignoreNull)
        {
            return date.HasValue || !ignoreNull;
        }
    }
}
