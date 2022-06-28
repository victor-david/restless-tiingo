using Restless.Tiingo.Socket.Core;
using System.Text.Json;

namespace Restless.Tiingo.Socket.Data
{
    /// <summary>
    /// Provides IEX message analysis used in development
    /// </summary>
    public class IEXAnalysisMessage : SocketMessage
    {
        private readonly RawDataMessage raw;

        public string UpdateMessageType { get; }

        public bool[] HasValue { get; }

        private IEXAnalysisMessage(RawDataMessage raw)
        {
            this.raw = raw;

            UpdateMessageType = raw.UpdateMessageType;
            HasValue = new bool[DataIndex.MinimumSize.IEX];

            for (int idx = 0; idx < DataIndex.MinimumSize.IEX; idx ++)
            {
                HasValue[idx] = JsonElementAt(idx) != null;
            }
        }

        internal static IEXAnalysisMessage Create(RawDataMessage raw)
        {
            return new IEXAnalysisMessage(raw);
        }

        private JsonElement? JsonElementAt(int index)
        {
            return raw.Data[index] != null ? (JsonElement)raw.Data[index] : null;
        }
    }
}