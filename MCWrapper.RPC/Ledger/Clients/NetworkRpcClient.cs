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
        /// <summary>
        /// Create a new Network RPC client
        /// </summary>
        /// <param name="client"></param>
        /// <param name="options"></param>
        public NetworkRpcClient(HttpClient client, IOptions<BlockchainRpcOptions> options) 
            : base(client, options) { }


        /// <summary>
        /// 
        /// <para>Attempts add or remove a node from the addnode list.</para>
        /// <para>Or try a connection to a node once.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        /// 
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="node">The node (see getpeerinfo for nodes)</param>
        /// <param name="action">'add' to add a node to the list, 'remove' to remove a node from the list, 'onetry' to try a connection to the node once</param>
        /// <returns></returns>
        public async Task<RpcResponse<object>> AddNodeAsync(string blockchainName, string id, string node, string action)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, NetworkAction.AddNodeMethod, id, node, action);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Attempts add or remove a node from the addnode list.</para>
        /// <para>Or try a connection to a node once.</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        /// 
        /// </summary>
        /// <param name="node">The node (see getpeerinfo for nodes)</param>
        /// <param name="action">'add' to add a node to the list, 'remove' to remove a node from the list, 'onetry' to try a connection to the node once</param>
        /// <returns></returns>
        public Task<RpcResponse<object>> AddNodeAsync(string node, string action)
        {
            return AddNodeAsync(BlockchainOptions.ChainName, UUID.NoHyphens, node, action);
        }


        /// <summary>
        /// 
        /// <para>Returns information about the given added node, or all added nodes</para>
        /// <para>(note that onetry addnodes are not listed here)</para>
        /// <para>If dns is false, only a list of added nodes will be provided, otherwise connected information will also be available.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="dns">If false, only a list of added nodes will be provided, otherwise connected information will also be available</param>
        /// <param name="node">If provided, return information about this specific node,otherwise all nodes are returned</param>
        /// <returns></returns>
        public async Task<RpcResponse<GetAddNodeInfoResult[]>> GetAddedNodeInfoAsync(string blockchainName, string id, bool dns, string node)
        {
            var response = await TransactAsync<RpcResponse<GetAddNodeInfoResult[]>>(blockchainName, NetworkAction.GetAddedNodeInfoMethod, id, dns, node);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Returns information about the given added node, or all added nodes</para>
        /// <para>(note that onetry addnodes are not listed here)</para>
        /// <para>If dns is false, only a list of added nodes will be provided, otherwise connected information will also be available.</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        ///
        /// </summary>
        /// <param name="dns">If false, only a list of added nodes will be provided, otherwise connected information will also be available</param>
        /// <param name="node">If provided, return information about this specific node,otherwise all nodes are returned</param>
        /// <returns></returns>
        public Task<RpcResponse<GetAddNodeInfoResult[]>> GetAddedNodeInfoAsync(bool dns, string node)
        {
            return GetAddedNodeInfoAsync(BlockchainOptions.ChainName, UUID.NoHyphens, dns, node);
        }


        /// <summary>
        ///
        /// <para>Returns data about each current chunk queue status.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        /// 
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <returns></returns>
        public async Task<RpcResponse<object>> GetChunkQueueInfoAsync(string blockchainName, string id)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, NetworkAction.GetChunkQueueInfoMethod, id);

            return response;
        }

        /// <summary>
        ///
        /// <para>Returns data about each current chunk queue status.</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<RpcResponse<object>> GetChunkQueueInfoAsync()
        {
            return GetChunkQueueInfoAsync(BlockchainOptions.ChainName, UUID.NoHyphens);
        }


        /// <summary>
        /// 
        /// <para>Returns chunks delivery statistics.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <returns></returns>
        public async Task<RpcResponse<object>> GetChunkQueueTotalsAsync(string blockchainName, string id)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, NetworkAction.GetChunkQueueTotalsMethod, id);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Returns chunks delivery statistics.</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        ///
        /// </summary>
        /// <returns></returns>
        public Task<RpcResponse<object>> GetChunkQueueTotalsAsync()
        {
            return GetChunkQueueTotalsAsync(BlockchainOptions.ChainName, UUID.NoHyphens);
        }


        /// <summary>
        /// 
        /// <para>Returns the number of connections to other nodes.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <returns></returns>
        public async Task<RpcResponse<object>> GetConnectionCountAsync(string blockchainName, string id)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, NetworkAction.GetConnectionCountMethod, id);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Returns the number of connections to other nodes.</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        ///
        /// </summary>
        /// <returns></returns>
        public Task<RpcResponse<object>> GetConnectionCountAsync()
        {
            return GetConnectionCountAsync(BlockchainOptions.ChainName, UUID.NoHyphens);
        }


        /// <summary>
        /// 
        /// <para>Returns information about network traffic, including bytes in, bytes out, and current time.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <returns></returns>
        public async Task<RpcResponse<object>> GetNetTotalsAsync(string blockchainName, string id)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, NetworkAction.GetNetTotalsMethod, id);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Returns information about network traffic, including bytes in, bytes out, and current time.</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        ///
        /// </summary>
        /// <returns></returns>
        public Task<RpcResponse<object>> GetNetTotalsAsync()
        {
            return GetNetTotalsAsync(BlockchainOptions.ChainName, UUID.NoHyphens);
        }


        /// <summary>
        /// 
        /// <para>Returns an object containing various state info regarding P2P networking.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <returns></returns>
        public async Task<RpcResponse<GetNetworkInfoResult>> GetNetworkInfoAsync(string blockchainName, string id)
        {
            var response = await TransactAsync<RpcResponse<GetNetworkInfoResult>>(blockchainName, NetworkAction.GetNetworkInfoMethod, id);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Returns an object containing various state info regarding P2P networking.</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        ///
        /// </summary>
        /// <returns></returns>
        public Task<RpcResponse<GetNetworkInfoResult>> GetNetworkInfoAsync()
        {
            return GetNetworkInfoAsync(BlockchainOptions.ChainName, UUID.NoHyphens);
        }


        /// <summary>
        /// 
        /// <para>Returns data about each connected network node as a json array of objects.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <returns></returns>
        public async Task<RpcResponse<object>> GetPeerInfoAsync(string blockchainName, string id)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, NetworkAction.GetPeerInfoMethod, id);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Returns data about each connected network node as a json array of objects.</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        ///
        /// </summary>
        /// <returns></returns>
        public Task<RpcResponse<object>> GetPeerInfoAsync()
        {
            return GetPeerInfoAsync(BlockchainOptions.ChainName, UUID.NoHyphens);
        }


        /// <summary>
        /// 
        /// <para>Requests that a ping be sent to all other nodes, to measure ping time.</para>
        /// <para>Results provided in getpeerinfo, pingtime and pingwait fields are decimal seconds.</para>
        /// <para>Ping command is handled in queue with all other commands, so it measures processing backlog, not just network ping.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        /// 
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <returns></returns>
        public async Task<RpcResponse<object>> PingAsync(string blockchainName, string id)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, NetworkAction.PingMethod, id);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Requests that a ping be sent to all other nodes, to measure ping time.</para>
        /// <para>Results provided in getpeerinfo, pingtime and pingwait fields are decimal seconds.</para>
        /// <para>Ping command is handled in queue with all other commands, so it measures processing backlog, not just network ping.</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<RpcResponse<object>> PingAsync()
        {
            return PingAsync(BlockchainOptions.ChainName, UUID.NoHyphens);
        }
    }
}