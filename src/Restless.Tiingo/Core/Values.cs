using System;
using System.Collections.Generic;
using System.Text;

namespace Restless.Tiingo.Core
{
    internal static class Values
    {
        public const string ApiRoot = "https://api.tiingo.com/tiingo";
        public const string JsonContent = "application/json";
        public const string Format = "format";
        public const string JsonFormat = "json";
        public const string CsvFormat = "csv";
        public const string StartDateParm = "startDate";
        public const string EndDateParm = "endDate";
        public const string FrequencyParm = "resampleFreq";
        public const string SortParm = "sort";
        public const string ErrorDetailJson = "{\"detail\":";
    }
}