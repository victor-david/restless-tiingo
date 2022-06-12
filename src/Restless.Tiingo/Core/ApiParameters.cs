using System;

namespace Restless.Tiingo.Core
{
    public abstract class ApiParameters
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        protected ApiParameters()
        {
        }
    }
}