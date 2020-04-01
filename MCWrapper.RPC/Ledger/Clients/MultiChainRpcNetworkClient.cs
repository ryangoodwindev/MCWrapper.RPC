using MCWrapper.RPC.Connection;
using MCWrapper.RPC.Options;
using Microsoft.Extensions.Options;
using Myndblock.MultiChain.Actions;
using Myndblock.MultiChain.Entities.Extensions;
using Myndblock.MultiChain.Models.Network;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace MCWrapper.RPC.Ledger.Clients
{
    /// <summary>
    /// 
    /// <para>MutliChain Core methods implemented by the MultiChainRpcNetworkClient concrete class</para>
    /// 
    /// addnode, getaddednodeinfo, getchunkqueueinfo, getchunkqueuetotals, 
    /// getconnectioncount, getnettotals, getnetworkinfo, getpeerinfo, ping
    /// 
    /// </summary>
    public class MultiChainRpcNetworkClient : MultiChainRpcClient, IMultiChainRpcNetwork
    {
        /// <summary>
        /// Create a new MultiChainRpcNetworkClient instance
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="options"></param>
        public MultiChainRpcNetworkClient(HttpClient httpClient, IOptions<RpcOptions> options)
            : base(httpClient, options) { }

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
        public Task<RpcResponse> AddNodeAsync(string blockchainName, string id, string node, string action) =>
            TransactAsync(blockchainName, NetworkAction.AddNodeMethod, id, node, action);

        /// <summary>
        /// 
        /// <para>Attempts add or remove a node from the addnode list.</para>
        /// <para>Or try a connection to a node once.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        /// 
        /// </summary>
        /// <param name="node">The node (see getpeerinfo for nodes)</param>
        /// <param name="action">'add' to add a node to the list, 'remove' to remove a node from the list, 'onetry' to try a connection to the node once</param>
        /// <returns></returns>
        public Task<RpcResponse> AddNodeAsync(string node, string action) =>
            AddNodeAsync(RpcOptions.ChainName, UUID.NoHyphens, node, action);

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
        public Task<RpcResponse<IList<GetAddNodeInfoResult>>> GetAddedNodeInfoAsync(string blockchainName, string id, bool dns, [Optional] string node) =>
            TransactAsync<IList<GetAddNodeInfoResult>>(blockchainName, NetworkAction.GetAddedNodeInfoMethod, id, dns, node);

        /// <summary>
        /// 
        /// <para>Returns information about the given added node, or all added nodes</para>
        /// <para>(note that onetry addnodes are not listed here)</para>
        /// <para>If dns is false, only a list of added nodes will be provided, otherwise connected information will also be available.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="dns">If false, only a list of added nodes will be provided, otherwise connected information will also be available</param>
        /// <param name="node">If provided, return information about this specific node,otherwise all nodes are returned</param>
        /// <returns></returns>
        public Task<RpcResponse<IList<GetAddNodeInfoResult>>> GetAddedNodeInfoAsync(bool dns, [Optional] string node) =>
            GetAddedNodeInfoAsync(RpcOptions.ChainName, UUID.NoHyphens, dns, node);

        /// <summary>
        ///
        /// <para>Returns data about each current chunk queue status.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        /// 
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <returns></returns>
        public Task<RpcResponse<GetChunkQueueInfoResult>> GetChunkQueueInfoAsync(string blockchainName, string id) =>
            TransactAsync<GetChunkQueueInfoResult>(blockchainName, NetworkAction.GetChunkQueueInfoMethod, id);

        /// <summary>
        ///
        /// <para>Returns data about each current chunk queue status.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<RpcResponse<GetChunkQueueInfoResult>> GetChunkQueueInfoAsync() =>
            GetChunkQueueInfoAsync(RpcOptions.ChainName, UUID.NoHyphens);

        /// <summary>
        /// 
        /// <para>Returns chunks delivery statistics.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <returns></returns>
        public Task<RpcResponse<GetChunkQueueInfoTotalsResult>> GetChunkQueueTotalsAsync(string blockchainName, string id) =>
            TransactAsync<GetChunkQueueInfoTotalsResult>(blockchainName, NetworkAction.GetChunkQueueTotalsMethod, id);

        /// <summary>
        /// 
        /// <para>Returns chunks delivery statistics.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <returns></returns>
        public Task<RpcResponse<GetChunkQueueInfoTotalsResult>> GetChunkQueueTotalsAsync() =>
            GetChunkQueueTotalsAsync(RpcOptions.ChainName, UUID.NoHyphens);

        /// <summary>
        /// 
        /// <para>Returns the number of connections to other nodes.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <returns></returns>
        public Task<RpcResponse<int>> GetConnectionCountAsync(string blockchainName, string id) =>
            TransactAsync<int>(blockchainName, NetworkAction.GetConnectionCountMethod, id);

        /// <summary>
        /// 
        /// <para>Returns the number of connections to other nodes.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <returns></returns>
        public Task<RpcResponse<int>> GetConnectionCountAsync() =>
            GetConnectionCountAsync(RpcOptions.ChainName, UUID.NoHyphens);

        /// <summary>
        /// 
        /// <para>Returns information about network traffic, including bytes in, bytes out, and current time.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <returns></returns>
        public Task<RpcResponse<GetNetTotalsResult>> GetNetTotalsAsync(string blockchainName, string id) =>
            TransactAsync<GetNetTotalsResult>(blockchainName, NetworkAction.GetNetTotalsMethod, id);

        /// <summary>
        /// 
        /// <para>Returns information about network traffic, including bytes in, bytes out, and current time.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <returns></returns>
        public Task<RpcResponse<GetNetTotalsResult>> GetNetTotalsAsync() =>
            GetNetTotalsAsync(RpcOptions.ChainName, UUID.NoHyphens);

        /// <summary>
        /// 
        /// <para>Returns an object containing various state info regarding P2P networking.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <returns></returns>
        public Task<RpcResponse<GetNetworkInfoResult>> GetNetworkInfoAsync(string blockchainName, string id) =>
            TransactAsync<GetNetworkInfoResult>(blockchainName, NetworkAction.GetNetworkInfoMethod, id);

        /// <summary>
        /// 
        /// <para>Returns an object containing various state info regarding P2P networking.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <returns></returns>
        public Task<RpcResponse<GetNetworkInfoResult>> GetNetworkInfoAsync() =>
            GetNetworkInfoAsync(RpcOptions.ChainName, UUID.NoHyphens);

        /// <summary>
        /// 
        /// <para>Returns data about each connected network node as a json array of objects.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <returns></returns>
        public Task<RpcResponse<IList<GetPeerInfoResult>>> GetPeerInfoAsync(string blockchainName, string id) =>
            TransactAsync<IList<GetPeerInfoResult>>(blockchainName, NetworkAction.GetPeerInfoMethod, id);

        /// <summary>
        /// 
        /// <para>Returns data about each connected network node as a json array of objects.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <returns></returns>
        public Task<RpcResponse<IList<GetPeerInfoResult>>> GetPeerInfoAsync() =>
            GetPeerInfoAsync(RpcOptions.ChainName, UUID.NoHyphens);

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
        public Task<RpcResponse> PingAsync(string blockchainName, string id) =>
            TransactAsync(blockchainName, NetworkAction.PingMethod, id);

        /// <summary>
        /// 
        /// <para>Requests that a ping be sent to all other nodes, to measure ping time.</para>
        /// <para>Results provided in getpeerinfo, pingtime and pingwait fields are decimal seconds.</para>
        /// <para>Ping command is handled in queue with all other commands, so it measures processing backlog, not just network ping.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<RpcResponse> PingAsync() =>
            PingAsync(RpcOptions.ChainName, UUID.NoHyphens);
    }
}