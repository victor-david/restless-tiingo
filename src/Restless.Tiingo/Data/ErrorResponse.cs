using System.Text.Json.Serialization;

namespace Restless.Tiingo.Data
{
    public class ErrorResponse
    {
        [JsonPropertyName("detail")]
        public string Message { get; set; }
    }
}