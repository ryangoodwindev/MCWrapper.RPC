using MCWrapper.RPC.Connection;
using System.Threading.Tasks;

namespace MCWrapper.RPC.Ledger.Clients
{
    public interface IBlockchainRpcOffChain : IRpcContract
    {
        Task<RpcResponse<object>> PurgePublishedItemsAsync(object items);
        Task<RpcResponse<object>> PurgePublishedItemsAsync(string blockchainName, string id, object items);
        Task<RpcResponse<object>> PurgeStreamItemsAsync(string stream, object items);
        Task<RpcResponse<object>> PurgeStreamItemsAsync(string blockchainName, string id, string stream, object items);
        Task<RpcResponse<object>> RetrieveStreamItemsAsync(string stream, object items);
        Task<RpcResponse<object>> RetrieveStreamItemsAsync(string blockchainName, string id, string stream, object items);
    }
}