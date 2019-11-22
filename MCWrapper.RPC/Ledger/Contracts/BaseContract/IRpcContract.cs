using MCWrapper.RPC.Options;
using System.Net.Http;

namespace MCWrapper.RPC.Ledger.Clients
{
    /// <summary>
    /// JSON-RPC Basic Contract
    /// </summary>
    public interface IRpcContract
    {
        /// <summary>
        /// Every JSON-RPC client should include a HttpClient which will support the HTTP/HTTPS connections required to interact with MultiChain Core
        /// </summary>
        HttpClient HttpClient { get; set; }

        /// <summary>
        /// Every JSON-RPC client should include RpcOptions which will support the IOptions pattern within the IConfiguration pipeline
        /// </summary>
        RpcOptions RpcOptions { get; }
    }
}