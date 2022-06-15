using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Restless.Tiingo.Client
{
    /// <summary>
    /// Represents a client for obtaining crypto information
    /// </summary>
    public class CryptoClient : AuxiliaryClient
    {
        internal CryptoClient(IHttpClientWrapper client, string apiToken) : base(client, apiToken)
        {
        }
    }
}