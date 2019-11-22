using MCWrapper.Ledger.Actions;
using MCWrapper.Ledger.Entities.Extensions;
using MCWrapper.RPC.Connection;
using MCWrapper.RPC.Options;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Threading.Tasks;

namespace MCWrapper.RPC.Ledger.Clients
{
    /// <summary>
    /// MutliChain methods implemented:
    /// 
    /// purgepublisheditems, purgestreamitems, retrievestreamitems
    /// 
    /// OffChain services to support MultiChain Enterprise users
    /// I do not have access to an Enterprise version of MultiChain 
    /// so no unit testing can be performed against these methods
    /// </summary>
    public class OffChainRpcClient : RpcClient, IBlockchainRpcOffChain
    {
        /// <summary>
        /// Create a OffChain RPC client
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="options"></param>
        public OffChainRpcClient(HttpClient httpClient, IOptions<RpcOptions> options)
            : base(httpClient, options) { }

        /// <summary>
        /// 
        /// <para>Available only in Enterprise Edition.</para>
        /// <para>Purges offchain items published by this node</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="items">
        ///     <para>1. "txids" (string, required) "all" or list of transactions, comma delimited</para>
        ///     <paa>or</paa>
        ///     <para>1. txids (array, required) Array of transactions IDs</para>
        ///     <para>or</para>
        ///     <para>1. txouts (array, required) Array of transaction outputs</para>
        ///     <para>or</para>
        ///     <para>1. blocks                           (object, required) List of transactions in block range</para>
        /// </param>
        /// <returns></returns>
        public Task<RpcResponse<object>> PurgePublishedItemsAsync(string blockchainName, string id, object items) =>
            TransactAsync<RpcResponse<object>>(blockchainName, OffChainAction.PurgePublishedItems, id, items);

        /// <summary>
        /// 
        /// <para>Available only in Enterprise Edition.</para>
        /// <para>Purges offchain items published by this node</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="items">
        ///     <para>1. "txids" (string, required) "all" or list of transactions, comma delimited</para>
        ///     <paa>or</paa>
        ///     <para>1. txids (array, required) Array of transactions IDs</para>
        ///     <para>or</para>
        ///     <para>1. txouts (array, required) Array of transaction outputs</para>
        ///     <para>or</para>
        ///     <para>1. blocks                           (object, required) List of transactions in block range</para>
        /// </param>
        /// <returns></returns>
        public Task<RpcResponse<object>> PurgePublishedItemsAsync(object items) =>
            PurgePublishedItemsAsync(RpcOptions.ChainName, UUID.NoHyphens, items);

        /// <summary>
        /// 
        /// <para>Available only in Enterprise Edition.</para>
        /// <para>Purges offchain data for specific items in the stream.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        /// 
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="stream">One of: create txid, stream reference, stream name</param>
        /// <param name="items">
        ///     <para>"txids" (string, required) "all" or list of transactions, comma delimited</para>
        ///     <para>or</para>
        ///     <para>txids (array, required) Array of transactions IDs</para>
        ///     <para>or</para>
        ///     <para>txouts (array, required) Array of transaction outputs</para>
        ///     <para>or</para>
        ///     <para>blocks (object, required) List of transactions in block range</para>
        ///     <para>or</para>
        ///     <para>query (object, required) Query (AND logic)</para>
        /// </param>
        /// <returns></returns>
        public Task<RpcResponse<object>> PurgeStreamItemsAsync(string blockchainName, string id, string stream, object items) =>
            TransactAsync<RpcResponse<object>>(blockchainName, OffChainAction.PurgeStreamItems, id, stream, items);

        /// <summary>
        /// 
        /// <para>Available only in Enterprise Edition.</para>
        /// <para>Purges offchain data for specific items in the stream.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        /// 
        /// </summary>
        /// <param name="stream">One of: create txid, stream reference, stream name</param>
        /// <param name="items">
        ///     <para>"txids" (string, required) "all" or list of transactions, comma delimited</para>
        ///     <para>or</para>
        ///     <para>txids (array, required) Array of transactions IDs</para>
        ///     <para>or</para>
        ///     <para>txouts (array, required) Array of transaction outputs</para>
        ///     <para>or</para>
        ///     <para>blocks (object, required) List of transactions in block range</para>
        ///     <para>or</para>
        ///     <para>query (object, required) Query (AND logic)</para>
        /// </param>
        /// <returns></returns>
        public Task<RpcResponse<object>> PurgeStreamItemsAsync(string stream, object items) =>
            PurgeStreamItemsAsync(RpcOptions.ChainName, UUID.NoHyphens, stream, items);

        /// <summary>
        ///
        /// <para>Available only in Enterprise Edition.</para>
        /// <para>Schedules retrieval of offchain data for specific items in the stream</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        /// 
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="stream">One of: create txid, stream reference, stream name</param>
        /// <param name="items">
        ///     <para>"txids" (string, required) "all" or list of transactions, comma delimited</para>
        ///     <para>or</para>
        ///     <para>txids (array, required) Array of transactions IDs</para>
        ///     <para>or</para>
        ///     <para>txouts (array, required) Array of transaction outputs</para>
        ///     <para>or</para>
        ///     <para>blocks (object, required) List of transactions in block range</para>
        ///     <para>or</para>
        ///     <para>query (object, required) Query (AND logic)</para>
        /// </param>
        /// <returns></returns>
        public Task<RpcResponse<object>> RetrieveStreamItemsAsync(string blockchainName, string id, string stream, object items) =>
            TransactAsync<RpcResponse<object>>(blockchainName, OffChainAction.RetrieveStreamItems, id, stream, items);

        /// <summary>
        ///
        /// <para>Available only in Enterprise Edition.</para>
        /// <para>Schedules retrieval of offchain data for specific items in the stream</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        /// 
        /// </summary>
        /// <param name="stream">One of: create txid, stream reference, stream name</param>
        /// <param name="items">
        ///     <para>"txids" (string, required) "all" or list of transactions, comma delimited</para>
        ///     <para>or</para>
        ///     <para>txids (array, required) Array of transactions IDs</para>
        ///     <para>or</para>
        ///     <para>txouts (array, required) Array of transaction outputs</para>
        ///     <para>or</para>
        ///     <para>blocks (object, required) List of transactions in block range</para>
        ///     <para>or</para>
        ///     <para>query (object, required) Query (AND logic)</para>
        /// </param>
        /// <returns></returns>
        public Task<RpcResponse<object>> RetrieveStreamItemsAsync(string stream, object items) =>
            RetrieveStreamItemsAsync(RpcOptions.ChainName, UUID.NoHyphens, stream, items);
    }
}