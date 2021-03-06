﻿using MCWrapper.RPC.Connection;
using MCWrapper.RPC.Options;
using Microsoft.Extensions.Options;
using Myndblock.MultiChain.Actions;
using Myndblock.MultiChain.Entities.Extensions;
using Myndblock.MultiChain.Models.Mining;
using System.Net.Http;
using System.Threading.Tasks;

namespace MCWrapper.RPC.Ledger.Clients
{
    /// <summary>
    /// 
    /// <para>MutliChain Core methods implemented by the MultiChainRpcMiningClient concrete class</para>
    ///
    /// getblocktemplate, getmininginfo, getnetworkhashps,
    /// prioritisetransaction, submitblock
    /// 
    /// </summary>
    public class MultiChainRpcMiningClient : MultiChainRpcClient, IMultiChainRpcMining
    {
        /// <summary>
        /// Create a new MultiChainRpcMiningClient instance
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="options"></param>
        public MultiChainRpcMiningClient(HttpClient httpClient, IOptions<RpcOptions> options)
            : base(httpClient, options) { }

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
        public Task<RpcResponse> GetBlockTemplateAsync(string blockchainName, string id, string json_request_object) =>
            TransactAsync(blockchainName, MiningAction.GetBlockTemplateMethod, id, json_request_object);

        /// <summary>
        /// <para>Deprecated for the current version of Multichain; Do Not Use;</para>
        /// <para>If the request parameters include a 'mode' key, that is used to explicitly select between the default 'template' request or a 'proposal'.</para>
        /// <para>It returns data needed to construct a block to work on.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
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
        public Task<RpcResponse> GetBlockTemplateAsync(string json_request_object) =>
            GetBlockTemplateAsync(RpcOptions.ChainName, UUID.NoHyphens, json_request_object);

        /// <summary>
        ///
        /// <para>Returns a json object containing mining-related information.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <returns></returns>
        public Task<RpcResponse<GetMiningInfoResult>> GetMiningInfoAsync(string blockchainName, string id) =>
            TransactAsync<GetMiningInfoResult>(blockchainName, MiningAction.GetMiningInfoMethod, id);

        /// <summary>
        ///
        /// <para>Returns a json object containing mining-related information.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <returns></returns>
        public Task<RpcResponse<GetMiningInfoResult>> GetMiningInfoAsync() =>
            GetMiningInfoAsync(RpcOptions.ChainName, UUID.NoHyphens);

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
        /// <param name="blocks">(numeric, optional, default=120) The number of blocks, or -1 for blocks since last difficulty change</param>
        /// <param name="height">(numeric, optional, default=-1) To estimate at the time of the given height</param>
        /// <returns></returns>
        public Task<RpcResponse<int>> GetNetworkHashPsAsync(string blockchainName, string id, int blocks = 120, int height = -1)
        {
            if (blocks == 0 && height == 0)
                return TransactAsync<int>(blockchainName, MiningAction.GetNetworkHashPsMethod, id);
            else if (blocks != 0 && height == 0)
                return TransactAsync<int>(blockchainName, MiningAction.GetNetworkHashPsMethod, id, blocks);
            else
                return TransactAsync<int>(blockchainName, MiningAction.GetNetworkHashPsMethod, id, blocks, height);
        }

        /// <summary>
        ///
        /// <para>Returns the estimated network hashes per second based on the last n blocks.</para>
        /// <para>Pass in [blocks] to override # of blocks, -1 specifies since last difficulty change.</para>
        /// <para>Pass in [height] to estimate the network speed at the time when a certain block was found.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="blocks">(numeric, optional, default=120) The number of blocks, or -1 for blocks since last difficulty change</param>
        /// <param name="height">(numeric, optional, default=-1) To estimate at the time of the given height</param>
        /// <returns></returns>
        public Task<RpcResponse<int>> GetNetworkHashPsAsync(int blocks = 120, int height = -1) =>
            GetNetworkHashPsAsync(RpcOptions.ChainName, UUID.NoHyphens, blocks, height);

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
        public Task<RpcResponse> PrioritiseTransactionAsync(string blockchainName, string id, string txid, double priority_delta, double fee_delta) =>
            TransactAsync(blockchainName, MiningAction.PrioritiseTransactionMethod, id, txid, priority_delta, fee_delta);

        /// <summary>
        ///
        /// <para>Accepts the transaction into mined blocks at a higher (or lower) priority</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
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
        public Task<RpcResponse> PrioritiseTransactionAsync(string txid, double priority_delta, double fee_delta) =>
            PrioritiseTransactionAsync(RpcOptions.ChainName, UUID.NoHyphens, txid, priority_delta, fee_delta);

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
        public Task<RpcResponse> SubmitBlockAsync(string blockchainName, string id, object hex_data, string json_parameters_object = "") =>
            TransactAsync(blockchainName, MiningAction.SubmitBlockMethod, id, hex_data, json_parameters_object);

        /// <summary>
        ///
        /// <para>Attempts to submit new block to network.</para>
        /// <para>The 'jsonparametersobject' parameter is currently ignored.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="hex_data">the hex-encoded block data to submit</param>
        /// <param name="json_parameters_object">
        ///     <para>object of optional parameters</para>
        ///     <para>{ "workid" : "id"               (string, optional) if the server provided a workid, it MUST be included with submissions }</para>
        /// </param>
        /// <returns></returns>
        public Task<RpcResponse> SubmitBlockAsync(object hex_data, string json_parameters_object = "") =>
            SubmitBlockAsync(RpcOptions.ChainName, UUID.NoHyphens, hex_data, json_parameters_object);
    }
}