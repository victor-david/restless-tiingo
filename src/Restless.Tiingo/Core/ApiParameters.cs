using System;

namespace Restless.Tiingo.Rest.Core
{
    /// <summary>
    /// Represents the base class for api parameters
    /// </summary>
    public abstract class ApiParameters
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        protected ApiParameters()
        {
        }
    }
}