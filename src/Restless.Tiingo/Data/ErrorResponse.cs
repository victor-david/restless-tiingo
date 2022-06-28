using System.Text.Json.Serialization;

namespace Restless.Tiingo.Rest.Data
{
    public class ErrorResponse
    {
        [JsonPropertyName("detail")]
        public string Message { get; set; }
    }
}