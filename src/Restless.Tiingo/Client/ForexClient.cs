namespace Restless.Tiingo.Client
{
    /// <summary>
    /// Represents a client for obtaining forex information
    /// </summary>
    public class ForexClient : AuxiliaryClient
    {
        internal ForexClient(IHttpClientWrapper client, string apiToken) : base(client, apiToken)
        {
        }
    }
}