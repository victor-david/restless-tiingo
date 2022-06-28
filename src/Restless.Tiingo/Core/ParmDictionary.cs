using System.Collections.Generic;
using System.Text;

namespace Restless.Tiingo.Core
{
    /// <summary>
    /// Internal class used in building parms for the url
    /// </summary>
    internal class ParmDictionary : Dictionary<string, string>
    {
        /// <summary>
        /// Adds a key to the dictionary if <paramref name="key"/> is not already present
        /// and <paramref name="value"/> is not null or white space
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="value">The value</param>
        public void AddIfValid(string key, string value)
        {
            if (!ContainsKey(key) && !string.IsNullOrWhiteSpace(value))
            {
                Add(key, value);
            }
        }

        public override string ToString()
        {
            StringBuilder builder = new();
           
            int count = 0;
            foreach (KeyValuePair<string, string> pair in this)
            {
                builder.Append(count++ == 0 ? "?" : "&");
                builder.Append($"{pair.Key}={pair.Value}");
            }
            return builder.ToString();
        }
    }
}