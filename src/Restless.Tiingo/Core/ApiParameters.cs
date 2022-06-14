using System;

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
    }
}