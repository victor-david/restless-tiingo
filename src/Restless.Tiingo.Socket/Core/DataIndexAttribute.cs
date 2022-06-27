using System;

namespace Restless.Tiingo.Socket.Core
{
    /// <summary>
    /// Provides an attribute to annotate properties with their
    /// corresponding index position in the incoming data array
    /// </summary>
    /// <remarks>
    /// Currently this attribute is only used to document properties.
    /// </remarks>
    [AttributeUsage(AttributeTargets.Property,  AllowMultiple = true)]
    public class DataIndexAttribute : Attribute
    {
        public int Index { get; }
        public string Description { get; }
        public DataIndexAttribute(int index, string description = null)
        {
            Index = index;
            Description = description;
        }
    }
}