using System;
using System.Text;

namespace Restless.Tiingo.Core
{
    public abstract class ApiParameters
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public FrequencyUnit Frequency { get; set; }
        public int FrequencyValue { get; set; }

        protected ApiParameters()
        {
            Frequency = FrequencyUnit.None;
            FrequencyValue = 0;
        }

        /// <summary>
        /// When overriden in a derived class gets the text needed
        /// for the frequency parameter
        /// </summary>
        /// <returns>
        /// A string value according to the values of <see cref="Frequency"/>
        /// and <see cref="FrequencyValue"/>
        /// </returns>
        protected internal virtual string GetFrequencyParameter()
        {
            return null;
        }
    }
}