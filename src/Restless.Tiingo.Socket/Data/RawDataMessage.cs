using Restless.Tiingo.Socket.Core;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Restless.Tiingo.Socket.Data
{
    /// <summary>
    /// Represents the data that arrives in a data message.
    /// </summary>
    /// <remarks>
    /// Data arrives in a json array that varies in length
    /// depending upon the service code and the data message type.
    /// This class obtains the json deserialization - and other classes
    /// (which are surfaced to the caller) use this class to obtain
    /// their property values from the documented indices where the data resides.
    /// See <see cref="DataIndex"/> for index values
    /// </remarks>
    public class RawDataMessage : SocketMessage
    {
        [JsonPropertyName("data")]
        public object[] Data { get; set; }

        internal string UpdateMessageType => GetStringAt(DataIndex.Common.UpdateMessageType);

        /// <summary>
        /// Validates that <see cref="Data"/> is present
        /// and has the specified minimum length
        /// </summary>
        /// <param name="minLength">The minimum length required</param>
        /// <exception cref="InvalidOperationException">
        /// <see cref="Data"/> is null or does not have the minimum required number of elements
        /// </exception>
        internal void ValidateData(int minLength)
        {
            if (Data == null || Data.Length < minLength)
            {
                throw new InvalidOperationException($"{nameof(Data)} is null or does not have enough elements");
            }
        }

        internal string GetStringAt(int index)
        {
            JsonElement? element = JsonElementAt(index);
            return element.HasValue ? element.Value.GetString() : null;
        }

        internal DateTime GetDateTimeAt(int index)
        {
            JsonElement? element = JsonElementAt(index);
            return element.HasValue && DateTime.TryParse(element.Value.GetString(), out DateTime result) ? result : DateTime.MinValue;
        }

        internal double GetNumericAt(int index)
        {
            JsonElement? element = JsonElementAt(index);
            return element.HasValue && element.Value.TryGetDouble(out double result) ? result : 0;
        }

        private JsonElement? JsonElementAt(int index)
        {
            return IsValidIndex(index) && Data[index] != null ? (JsonElement)Data[index] : null;
        }

        private bool IsValidIndex(int index)
        {
            return Data != null && Data.Length > index;
        }
    }
}