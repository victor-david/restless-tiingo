using Restless.Tiingo.Core;
using System.Text.Json.Serialization;

namespace Restless.Tiingo.Data
{
    public class ErrorResponse
    {
        [JsonPropertyName(JsonId.Detail)]
        public string Message { get; set; }
    }
}