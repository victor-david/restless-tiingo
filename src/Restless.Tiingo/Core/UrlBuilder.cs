using System;
using System.Text;

namespace Restless.Tiingo.Rest.Core
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

        public UrlBuilder AddBoolean(string parmName, bool value)
        {
            parms.AddIfValid(parmName, value ? "true" : "false");
            return this;
        }

        public UrlBuilder AddArray(string parmName, object[] values)
        {
            parms.AddIfValid(parmName, ArrayToParm(values));
            return this;
        }

        public override string ToString()
        {
            return $"{root}{parms}";
        }
        #endregion

        #region Private methods
        private string ArrayToParm(object[] values)
        {
            StringBuilder builder = new();
            builder.AppendJoin(",", values);
            return builder.ToString();
        }
        #endregion
    }
}