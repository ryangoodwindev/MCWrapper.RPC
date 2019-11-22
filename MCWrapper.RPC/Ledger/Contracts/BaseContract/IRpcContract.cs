using MCWrapper.RPC.Options;
using System.Net.Http;

namespace MCWrapper.RPC.Ledger.Clients
{
    public interface IRpcContract
    {
        HttpClient HttpClient { get; set; }

        RpcOptions RpcOptions { get; }
    }
}
