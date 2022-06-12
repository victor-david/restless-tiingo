using System;

namespace Restless.Tiingo.Core
{
    public class OperationOptions
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public ResampleFrequency Frequency { get; set; }
        public SortOption Sort { get; set; }

        public OperationOptions()
        {
            Frequency = ResampleFrequency.Daily;
            StartDate = null;
            EndDate = null;
            Sort = SortOption.None;
        }
    }
}