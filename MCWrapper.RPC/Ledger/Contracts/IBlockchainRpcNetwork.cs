using MCWrapper.Data.Models.Network;
using MCWrapper.RPC.Connection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace MCWrapper.RPC.Ledger.Clients
{
    public interface IBlockchainRpcNetwork : IRpcContract
    {
        Task<RpcResponse<object>> AddNodeAsync(string node, string action);
        Task<RpcResponse<object>> AddNodeAsync(string blockchainName, string id, string node, string action);
        Task<RpcResponse<GetAddNodeInfoResult[]>> GetAddedNodeInfoAsync(bool dns, [Optional] string node);
        Task<RpcResponse<GetAddNodeInfoResult[]>> GetAddedNodeInfoAsync(string blockchainName, string id, bool dns, [Optional] string node);
        Task<RpcResponse<object>> GetChunkQueueInfoAsync();
        Task<RpcResponse<object>> GetChunkQueueInfoAsync(string blockchainName, string id);
        Task<RpcResponse<object>> GetChunkQueueTotalsAsync();
        Task<RpcResponse<object>> GetChunkQueueTotalsAsync(string blockchainName, string id);
        Task<RpcResponse<object>> GetConnectionCountAsync();
        Task<RpcResponse<object>> GetConnectionCountAsync(string blockchainName, string id);
        Task<RpcResponse<object>> GetNetTotalsAsync();
        Task<RpcResponse<object>> GetNetTotalsAsync(string blockchainName, string id);
        Task<RpcResponse<GetNetworkInfoResult>> GetNetworkInfoAsync();
        Task<RpcResponse<GetNetworkInfoResult>> GetNetworkInfoAsync(string blockchainName, string id);
        Task<RpcResponse<object>> GetPeerInfoAsync();
        Task<RpcResponse<object>> GetPeerInfoAsync(string blockchainName, string id);
        Task<RpcResponse<object>> PingAsync();
        Task<RpcResponse<object>> PingAsync(string blockchainName, string id);
    }
}