namespace Restless.Tiingo.Core
{
    public enum ResampleFrequency
    {
        /// <summary>
        /// Values returned as daily periods, with a holiday calendar
        /// </summary>
        Daily,

        /// <summary>
        /// Values returned as weekly data, with days ending on Friday
        /// </summary>
        Weekly,

        /// <summary>
        /// Values returned as monthly data, with days ending on the last standard business day (mon-fri) of each month
        /// </summary>
        Monthly,

        /// <summary>
        /// Values returned as annual data, with days ending on the last standard business day (mon-fri) of each year
        /// </summary>
        Annually,
    }
}