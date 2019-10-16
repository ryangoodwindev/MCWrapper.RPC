using MCWrapper.RPC.Connection;
using MCWrapper.RPC.Extensions;
using MCWrapper.RPC.Ledger.Actions;
using MCWrapper.RPC.Ledger.Models.Network;
using MCWrapper.RPC.Options;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Threading.Tasks;

namespace MCWrapper.RPC.Ledger.Clients.Network
{
    /// <summary>
    /// 
    /// MutliChain methods implemented by the concrete NetworkRPCClient class:
    /// 
    /// addnode, getaddednodeinfo, getchunkqueueinfo, getchunkqueuetotals, 
    /// getconnectioncount, getnettotals, getnetworkinfo, getpeerinfo, ping
    /// 
    /// <para>Inherits from an RPCClient and implements the INetworkRPC contract</para>
    /// 
    /// </summary>
    public class NetworkRpcClient : RpcConnection
    {
        public NetworkRpcClient(HttpClient client, IOptions<BlockchainProfileOptions> options) 
            : base(client, options) { }


        public async Task<RpcResponse<object>> AddNodeAsync(string blockchainName, string id, string node, string action)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, NetworkAction.AddNodeMethod, id, node, action);

            return response;
        }

        public Task<RpcResponse<object>> AddNodeAsync(string node, string action)
        {
            return AddNodeAsync(BlockchainOptions.ChainName, UUID.NoHyphens, node, action);
        }


        public async Task<RpcResponse<GetAddNodeInfoResult[]>> GetAddedNodeInfoAsync(string blockchainName, string id, bool dns, string node)
        {
            var response = await TransactAsync<RpcResponse<GetAddNodeInfoResult[]>>(blockchainName, NetworkAction.GetAddedNodeInfoMethod, id, dns, node);

            return response;
        }

        public Task<RpcResponse<GetAddNodeInfoResult[]>> GetAddedNodeInfoAsync(bool dns, string node)
        {
            return GetAddedNodeInfoAsync(BlockchainOptions.ChainName, UUID.NoHyphens, dns, node);
        }


        public async Task<RpcResponse<object>> GetChunkQueueInfoAsync(string blockchainName, string id)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, NetworkAction.GetChunkQueueInfoMethod, id);

            return response;
        }

        public Task<RpcResponse<object>> GetChunkQueueInfoAsync()
        {
            return GetChunkQueueInfoAsync(BlockchainOptions.ChainName, UUID.NoHyphens);
        }


        public async Task<RpcResponse<object>> GetChunkQueueTotalsAsync(string blockchainName, string id)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, NetworkAction.GetChunkQueueTotalsMethod, id);

            return response;
        }

        public Task<RpcResponse<object>> GetChunkQueueTotalsAsync()
        {
            return GetChunkQueueTotalsAsync(BlockchainOptions.ChainName, UUID.NoHyphens);
        }


        public async Task<RpcResponse<object>> GetConnectionCountAsync(string blockchainName, string id)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, NetworkAction.GetConnectionCountMethod, id);

            return response;
        }

        public Task<RpcResponse<object>> GetConnectionCountAsync()
        {
            return GetConnectionCountAsync(BlockchainOptions.ChainName, UUID.NoHyphens);
        }


        public async Task<RpcResponse<object>> GetNetTotalsAsync(string blockchainName, string id)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, NetworkAction.GetNetTotalsMethod, id);

            return response;
        }

        public Task<RpcResponse<object>> GetNetTotalsAsync()
        {
            return GetNetTotalsAsync(BlockchainOptions.ChainName, UUID.NoHyphens);
        }


        public async Task<RpcResponse<GetNetworkInfoResult>> GetNetworkInfoAsync(string blockchainName, string id)
        {
            var response = await TransactAsync<RpcResponse<GetNetworkInfoResult>>(blockchainName, NetworkAction.GetNetworkInfoMethod, id);

            return response;
        }

        public Task<RpcResponse<GetNetworkInfoResult>> GetNetworkInfoAsync()
        {
            return GetNetworkInfoAsync(BlockchainOptions.ChainName, UUID.NoHyphens);
        }


        public async Task<RpcResponse<object>> GetPeerInfoAsync(string blockchainName, string id)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, NetworkAction.GetPeerInfoMethod, id);

            return response;
        }

        public Task<RpcResponse<object>> GetPeerInfoAsync()
        {
            return GetPeerInfoAsync(BlockchainOptions.ChainName, UUID.NoHyphens);
        }


        public async Task<RpcResponse<object>> PingAsync(string blockchainName, string id)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, NetworkAction.PingMethod, id);

            return response;
        }

        public Task<RpcResponse<object>> PingAsync()
        {
            return PingAsync(BlockchainOptions.ChainName, UUID.NoHyphens);
        }
    }
}
