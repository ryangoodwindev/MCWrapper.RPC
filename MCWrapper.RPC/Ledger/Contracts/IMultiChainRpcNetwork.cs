using MCWrapper.Data.Models.Network;
using MCWrapper.RPC.Connection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace MCWrapper.RPC.Ledger.Clients
{
    /// <summary>
    /// 
    /// MutliChain Core methods established by the IMultiChainRpcNetwork contract
    /// 
    /// addnode, getaddednodeinfo, getchunkqueueinfo, getchunkqueuetotals, 
    /// getconnectioncount, getnettotals, getnetworkinfo, getpeerinfo, ping
    /// 
    /// </summary>
    public interface IMultiChainRpcNetwork : IMultiChainRpc
    {
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
        Task<RpcResponse<object>> AddNodeAsync(string node, string action);

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
        Task<RpcResponse<object>> AddNodeAsync(string blockchainName, string id, string node, string action);

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
        Task<RpcResponse<GetAddNodeInfoResult[]>> GetAddedNodeInfoAsync(bool dns, [Optional] string node);

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
        Task<RpcResponse<GetAddNodeInfoResult[]>> GetAddedNodeInfoAsync(string blockchainName, string id, bool dns, [Optional] string node);

        /// <summary>
        ///
        /// <para>Returns data about each current chunk queue status.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<RpcResponse<object>> GetChunkQueueInfoAsync();

        /// <summary>
        ///
        /// <para>Returns data about each current chunk queue status.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        /// 
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <returns></returns>
        Task<RpcResponse<object>> GetChunkQueueInfoAsync(string blockchainName, string id);

        /// <summary>
        /// 
        /// <para>Returns chunks delivery statistics.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <returns></returns>
        Task<RpcResponse<object>> GetChunkQueueTotalsAsync();

        /// <summary>
        /// 
        /// <para>Returns chunks delivery statistics.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <returns></returns>
        Task<RpcResponse<object>> GetChunkQueueTotalsAsync(string blockchainName, string id);

        /// <summary>
        /// 
        /// <para>Returns the number of connections to other nodes.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <returns></returns>
        Task<RpcResponse<object>> GetConnectionCountAsync();

        /// <summary>
        /// 
        /// <para>Returns the number of connections to other nodes.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <returns></returns>
        Task<RpcResponse<object>> GetConnectionCountAsync(string blockchainName, string id);

        /// <summary>
        /// 
        /// <para>Returns information about network traffic, including bytes in, bytes out, and current time.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <returns></returns>
        Task<RpcResponse<object>> GetNetTotalsAsync();

        /// <summary>
        /// 
        /// <para>Returns information about network traffic, including bytes in, bytes out, and current time.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <returns></returns>
        Task<RpcResponse<object>> GetNetTotalsAsync(string blockchainName, string id);

        /// <summary>
        /// 
        /// <para>Returns an object containing various state info regarding P2P networking.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <returns></returns>
        Task<RpcResponse<GetNetworkInfoResult>> GetNetworkInfoAsync();

        /// <summary>
        /// 
        /// <para>Returns an object containing various state info regarding P2P networking.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <returns></returns>
        Task<RpcResponse<GetNetworkInfoResult>> GetNetworkInfoAsync(string blockchainName, string id);

        /// <summary>
        /// 
        /// <para>Returns data about each connected network node as a json array of objects.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <returns></returns>
        Task<RpcResponse<object>> GetPeerInfoAsync();

        /// <summary>
        /// 
        /// <para>Returns data about each connected network node as a json array of objects.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <returns></returns>
        Task<RpcResponse<object>> GetPeerInfoAsync(string blockchainName, string id);

        /// <summary>
        /// 
        /// <para>Requests that a ping be sent to all other nodes, to measure ping time.</para>
        /// <para>Results provided in getpeerinfo, pingtime and pingwait fields are decimal seconds.</para>
        /// <para>Ping command is handled in queue with all other commands, so it measures processing backlog, not just network ping.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<RpcResponse<object>> PingAsync();

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
        Task<RpcResponse<object>> PingAsync(string blockchainName, string id);
    }
}