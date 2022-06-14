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
    public enum FrequencyUnit
    {
        None,
        Minute,
        Hour,
        Day,
        Week,
        Month,
        Year
    }
}