namespace Restless.Tiingo.Core
{
    /// <summary>
    /// Provide frequency units for api calls that use them
    /// </summary>
    /// <remarks>
    /// <see cref="ApiParameters"/> contains properties for Frequency
    /// and FrequencyValue. Derived classes evaluate these properties
    /// when creating the frequency string that goes into the url; they will
    /// transform unsupported frequency units into a default.
    /// </remarks>
    public enum FrequencyUnit : long
    {
        None = 0,
        Minute = 1,
        Hour = 60,
        Day = 60 * 24,
        Week = 60 * 24 * 7,
        Month = 60 * 24 * 30,
        Year = 60 * 24 * 365
    }
}