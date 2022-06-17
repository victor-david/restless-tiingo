using Restless.Tiingo.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restless.Tiingo.Data
{
    public class DataPointCollection<T> : List<T> where T: DataPoint
    {

        internal DataPointCollection<T> UpdateInterval(long interval)
        {
            ForEach(item =>
            {
                item.Interval = interval;
            });
            
            return this;
        }
    }
}