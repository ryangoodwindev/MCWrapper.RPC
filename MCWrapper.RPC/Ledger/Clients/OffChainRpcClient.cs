using MCWrapper.RPC.Connection;
using MCWrapper.RPC.Extensions;
using MCWrapper.RPC.Ledger.Actions;
using MCWrapper.RPC.Options;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Threading.Tasks;

namespace MCWrapper.RPC.Ledger.Clients.OffChain
{
    /// <summary>
    /// 
    /// MutliChain methods implemented by th concrete OffChainRPCClient class:
    /// 
    /// purgepublisheditems, purgestreamitems, retrievestreamitems
    /// 
    ///  OffChain services to support MultiChain Enterprise users
    /// I do not have access to an Enterprise version of MultiChain 
    /// so no unit testing can be performed against these methods
    /// 
    /// <para>Inherits from an RPCClient and implements the IOffChainRPC contract</para>
    /// 
    /// </summary>
    public class OffChainRpcClient : RpcConnection
    {
        public OffChainRpcClient(HttpClient client, IOptions<BlockchainProfileOptions> options) 
            : base(client, options) { }


        public async Task<RpcResponse<object>> PurgePublishedItemsAsync(string blockchainName, string id, object items)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, OffChainAction.PurgePublishedItems, id, items);

            return response;
        }

        public Task<RpcResponse<object>> PurgePublishedItemsAsync(object items)
        {
            return PurgePublishedItemsAsync(BlockchainOptions.ChainName, UUID.NoHyphens, items);
        }


        public async Task<RpcResponse<object>> PurgeStreamItemsAsync(string blockchainName, string id, string stream, object items)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, OffChainAction.PurgeStreamItems, id, stream, items);

            return response;
        }

        public Task<RpcResponse<object>> PurgeStreamItemsAsync(string stream, object items)
        {
            return PurgeStreamItemsAsync(BlockchainOptions.ChainName, UUID.NoHyphens, stream, items);
        }


        public async Task<RpcResponse<object>> RetrieveStreamItemsAsync(string blockchainName, string id, string stream, object items)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, OffChainAction.RetrieveStreamItems, id, stream, items);

            return response;
        }

        public Task<RpcResponse<object>> RetrieveStreamItemsAsync(string stream, object items)
        {
            return RetrieveStreamItemsAsync(BlockchainOptions.ChainName, UUID.NoHyphens, stream, items);
        }
    }
}
