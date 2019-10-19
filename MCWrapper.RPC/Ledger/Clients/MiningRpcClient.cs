using MCWrapper.RPC.Connection;
using MCWrapper.RPC.Extensions;
using MCWrapper.RPC.Ledger.Actions;
using MCWrapper.RPC.Options;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Threading.Tasks;

namespace MCWrapper.RPC.Ledger.Clients.Mining
{
    /// <summary>
    /// 
    /// MutliChain methods implemented by the concrete MineRPCClient class:
    /// 
    /// getblocktemplate, getmininginfo, getnetworkhashps, 
    /// prioritisetransaction, submitblock
    /// 
    /// <para>Inherits from an RPCClient and implements the IMineRPC contract</para>
    /// 
    /// </summary>
    public class MiningRpcClient : RpcConnection
    {
        public MiningRpcClient(HttpClient client, IOptions<BlockchainRpcOptions> options) 
            : base(client, options) { }


        /// <summary>
        /// 
        /// <para>Deprecated for the current version of Multichain; Do Not Use;</para>
        /// <para>If the request parameters include a 'mode' key, that is used to explicitly select between the default 'template' request or a 'proposal'.</para>
        /// <para>It returns data needed to construct a block to work on.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="json_request_object">
        ///     <para>(string, optional) A json object in the following spec</para>
        ///     <para>{ "mode":"template"            (string, optional) This must be set to "template" or omitted</para>
        ///     <para> "capabilities":[             (array, optional) A list of strings</para>
        ///     <para>"support"                (string) client side supported feature, 'longpoll', 'coinbasetxn', 'coinbasevalue', 'proposal', 'serverlist', 'workid'</para>
        ///     <para> ,...]}</para>
        /// </param>
        /// <returns></returns>
        public async Task<RpcResponse<object>> GetBlockTemplateAsync(string blockchainName, string id, string json_request_object)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, MiningAction.GetBlockTemplateMethod, id, json_request_object);

            return response;
        }

        /// <summary>
        /// <para>Deprecated for the current version of Multichain; Do Not Use;</para>
        /// <para>If the request parameters include a 'mode' key, that is used to explicitly select between the default 'template' request or a 'proposal'.</para>
        /// <para>It returns data needed to construct a block to work on.</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        ///
        /// </summary>
        /// <param name="json_request_object">
        ///     <para>(string, optional) A json object in the following spec</para>
        ///     <para>{ "mode":"template"            (string, optional) This must be set to "template" or omitted</para>
        ///     <para> "capabilities":[             (array, optional) A list of strings</para>
        ///     <para>"support"                (string) client side supported feature, 'longpoll', 'coinbasetxn', 'coinbasevalue', 'proposal', 'serverlist', 'workid'</para>
        ///     <para> ,...]}</para>
        /// </param>
        /// <returns></returns>
        public Task<RpcResponse<object>> GetBlockTemplateAsync(string json_request_object)
        {
            return GetBlockTemplateAsync(BlockchainOptions.ChainName, UUID.NoHyphens, json_request_object);
        }


        /// <summary>
        /// 
        /// <para>Returns a json object containing mining-related information.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        /// 
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <returns></returns>
        public async Task<RpcResponse<object>> GetMiningInfoAsync(string blockchainName, string id)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, MiningAction.GetMiningInfoMethod, id);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Returns a json object containing mining-related information.</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<RpcResponse<object>> GetMiningInfoAsync()
        {
            return GetMiningInfoAsync(BlockchainOptions.ChainName, UUID.NoHyphens);
        }


        /// <summary>
        /// 
        /// <para>Returns the estimated network hashes per second based on the last n blocks.</para>
        /// <para>Pass in [blocks] to override # of blocks, -1 specifies since last difficulty change.</para>
        /// <para>Pass in [height] to estimate the network speed at the time when a certain block was found.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="blocks">The number of blocks, or -1 for blocks since last difficulty change</param>
        /// <param name="height">To estimate at the time of the given height</param>
        /// <returns></returns>
        public async Task<RpcResponse<object>> GetNetworkHashPsAsync(string blockchainName, string id, int blocks, int height)
        {
            RpcResponse<object> response;
            if (blocks == 0 && height == 0)
                response = await TransactAsync<RpcResponse<object>>(blockchainName, MiningAction.GetNetworkHashPsMethod, id);
            else if (blocks != 0 && height == 0)
                response = await TransactAsync<RpcResponse<object>>(blockchainName, MiningAction.GetNetworkHashPsMethod, id, blocks);
            else
                response = await TransactAsync<RpcResponse<object>>(blockchainName, MiningAction.GetNetworkHashPsMethod, id, blocks, height);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Returns the estimated network hashes per second based on the last n blocks.</para>
        /// <para>Pass in [blocks] to override # of blocks, -1 specifies since last difficulty change.</para>
        /// <para>Pass in [height] to estimate the network speed at the time when a certain block was found.</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        ///
        /// </summary>
        /// <param name="blocks">The number of blocks, or -1 for blocks since last difficulty change</param>
        /// <param name="height">To estimate at the time of the given height</param>
        /// <returns></returns>
        public Task<RpcResponse<object>> GetNetworkHashPsAsync(int blocks, int height)
        {
            return GetNetworkHashPsAsync(BlockchainOptions.ChainName, UUID.NoHyphens, blocks, height);
        }


        /// <summary>
        /// 
        /// <para>Accepts the transaction into mined blocks at a higher (or lower) priority</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="txid">The transaction id</param>
        /// <param name="priority_delta">
        ///     The priority to add or subtract.
        ///     <para>The transaction selection algorithm considers the tx as it would have a higher priority.</para>
        ///     <para>(priority of a transaction is calculated: coinage * value_in_satoshis / txsize)</para>
        /// </param>
        /// <param name="fee_delta">
        ///     The fee value (in satoshis) to add (or subtract, if negative).
        ///     <para>The fee is not actually paid, only the algorithm for selecting transactions into a block considers the transaction as it would have paid a higher (or lower) fee</para>
        /// </param>
        /// <returns></returns>
        public async Task<RpcResponse<object>> PrioritiseTransactionAsync(string blockchainName, string id, string txid, double priority_delta, double fee_delta)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, MiningAction.PrioritiseTransactionMethod, id, txid, priority_delta, fee_delta);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Accepts the transaction into mined blocks at a higher (or lower) priority</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        ///
        /// </summary>
        /// <param name="txid">The transaction id</param>
        /// <param name="priority_delta">
        ///     The priority to add or subtract.
        ///     <para>The transaction selection algorithm considers the tx as it would have a higher priority.</para>
        ///     <para>(priority of a transaction is calculated: coinage * value_in_satoshis / txsize)</para>
        /// </param>
        /// <param name="fee_delta">
        ///     The fee value (in satoshis) to add (or subtract, if negative).
        ///     <para>he fee is not actually paid, only the algorithm for selecting transactions into a block considers the transaction as it would have paid a higher (or lower) fee</para>
        /// </param>
        /// <returns></returns>
        public Task<RpcResponse<object>> PrioritiseTransactionAsync(string txid, double priority_delta, double fee_delta)
        {
            return PrioritiseTransactionAsync(BlockchainOptions.ChainName, UUID.NoHyphens, txid, priority_delta, fee_delta);
        }


        /// <summary>
        /// 
        /// <para>Attempts to submit new block to network.</para>
        /// <para>The 'jsonparametersobject' parameter is currently ignored.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        /// 
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="hex_data">the hex-encoded block data to submit</param>
        /// <param name="json_parameters_object">
        ///     <para>object of optional parameters</para>
        ///     <para>{ "workid" : "id"               (string, optional) if the server provided a workid, it MUST be included with submissions }</para>
        /// </param>
        /// <returns></returns>
        public async Task<RpcResponse<object>> SubmitBlockAsync(string blockchainName, string id, object hex_data, string json_parameters_object = "")
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, MiningAction.SubmitBlockMethod, id, hex_data, json_parameters_object);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Attempts to submit new block to network.</para>
        /// <para>The 'jsonparametersobject' parameter is currently ignored.</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        /// 
        /// </summary>
        /// <param name="hex_data">the hex-encoded block data to submit</param>
        /// <param name="json_parameters_object">
        ///     <para>object of optional parameters</para>
        ///     <para>{ "workid" : "id"               (string, optional) if the server provided a workid, it MUST be included with submissions }</para>
        /// </param>
        /// <returns></returns>
        public Task<RpcResponse<object>> SubmitBlockAsync(object hex_data, string json_parameters_object = "")
        {
            return SubmitBlockAsync(BlockchainOptions.ChainName, UUID.NoHyphens, hex_data, json_parameters_object);
        }
    }
}