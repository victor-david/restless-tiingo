﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Restless.Tiingo.Core
{
    internal class UrlBuilder
    {
        private readonly string root;
        private readonly ParmDictionary parms;

        /// <summary>
        /// Gets the constructed url
        /// </summary>
        public string Url => ToString();

        #region Constructors
        public static UrlBuilder Create(string root)
        {
            return new UrlBuilder(root);
        }

        private UrlBuilder(string root)
        {
            if (string.IsNullOrWhiteSpace(root))
            {
                throw new ArgumentException("Invalid root value");
            }

            this.root = root;
            parms = new ParmDictionary();
        }
        #endregion

        #region Public methods
        public UrlBuilder AddFormat(string format)
        {
            parms.AddIfValid(Values.ResultFormatParm, format);
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

        public UrlBuilder AddValue(string parmName, int value)
        {
            parms.AddIfValid(parmName, value.ToString());
            return this;
        }

        public UrlBuilder AddValue(string parmName, string value)
        {
            parms.AddIfValid(parmName, value);
            return this;
        }

        public UrlBuilder AddArray(string parmName, string[] values)
        {
            parms.AddIfValid(parmName, StringArrayToParm(values));
            return this;
        }

        public override string ToString()
        {
            return $"{root}{parms}";
        }
        #endregion

        #region Private methods
        private string SortOptionToSortParm(SortOption sort)
        {
            return sort switch
            {
                SortOption.DateAscending => "date",
                SortOption.DateDescending => "-date",
                _ => string.Empty
            };
        }
        private string StringArrayToParm(string[] values)
        {
            StringBuilder builder = new();
            int count = 0;
            foreach (string value in values ?? new string[] { })
            {
                builder.Append(count++ == 0 ? string.Empty : ",");
                builder.Append(value);
            }

            return builder.ToString();
        }
        #endregion
    }
}