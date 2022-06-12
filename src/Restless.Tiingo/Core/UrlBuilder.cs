using System;
using System.Collections.Generic;
using System.Text;

namespace Restless.Tiingo.Core
{
    internal class UrlBuilder
    {
        private readonly string root;
        private readonly ParmDictionary parms;

        private UrlBuilder(string root)
        {
            if (string.IsNullOrWhiteSpace(root))
            {
                throw new ArgumentException("Invalid root value");
            }

            this.root = root;
            parms = new ParmDictionary();
        }

        public static UrlBuilder Create(string root)
        {
            return new UrlBuilder(root);
        }

        public UrlBuilder AddFormat(string format)
        {
            parms.AddIfValid(Values.Format, format);
            return this;
        }

        public UrlBuilder AddDate(string parmName, DateTime? date)
        {
            if (date != null)
            {
                parms.AddIfValid(parmName, date.Value.ToString("yyyy-MM-dd"));
            }
            return this;
        }

        public UrlBuilder AddResampleFrequency(ResampleFrequency frequency)
        {
            parms.AddIfValid(Values.FrequencyParm, frequency.ToString().ToLowerInvariant());
            return this;
        }

        public UrlBuilder AddSort(SortOption sort)
        {
            parms.AddIfValid(Values.SortParm, SortOptionToSortParm(sort));
            return this;
        }

        public override string ToString()
        {
            return $"{root}{parms}";
        }

        private string SortOptionToSortParm(SortOption sort)
        {
            return sort switch
            {
                SortOption.DateAscending => "date",
                SortOption.DateDescending => "-date",
                _ => string.Empty
            };
        }
    }
}