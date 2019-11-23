﻿using MCWrapper.Data.Models.Blockchain;
using MCWrapper.RPC.Connection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace MCWrapper.RPC.Ledger.Clients
{
    /// <summary>
    ///
    /// <para>MutliChain Core methods established by the IMultiChainRpcGeneral contract</para>
    ///
    /// getassetinfo, getbestblockhash, getblock, getblockchaininfo,
    /// getblockcount, getblockhash, getchaintips, getdifficulty,
    /// getfiltercode, getlastblockinfo, getmempoolinfo, getrawmempool,
    /// getstreaminfo, gettxout, gettxoutsetinfo, listassets, listblocks,
    /// listpermissions, liststreamfilters, liststreams, listtxfilters,
    /// listupgrades, runstreamfilter, runtxfilter, teststreamfilter,
    /// testtxfilter, verifychain, verifypermission
    ///
    /// </summary>
    public interface IMultiChainRpcGeneral : IMultiChainRpc
    {
        /// <summary>
        ///
        /// <para>Returns information about a single blockchain asset referenced by issue txid, asset reference, or asset name.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="asset_identifier">One of: issue txid, asset reference, asset name</param>
        /// <param name="verbose">If true, returns list of all issue transactions, including follow-ons</param>
        /// <returns></returns>
        Task<RpcResponse<GetAssetInfoResult>> GetAssetInfoAsync(string asset_identifier, bool verbose = false);

        /// <summary>
        ///
        /// <para>Returns information about a single blockchain asset referenced by issue txid, asset reference, or asset name.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="asset_identifier">One of: issue txid, asset reference, asset name</param>
        /// <param name="verbose">If true, returns list of all issue transactions, including follow-ons</param>
        /// <returns></returns>
        Task<RpcResponse<GetAssetInfoResult>> GetAssetInfoAsync(string blockchainName, string id, string asset_identifier, bool verbose = false);

        /// <summary>
        ///
        /// <para>Returns a hex encoded hash of the best (tip) block in the longest block chain.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <returns></returns>
        Task<RpcResponse<string>> GetBestBlockHashAsync();

        /// <summary>
        ///
        /// <para>Returns a hex encoded hash of the best (tip) block in the longest block chain.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <returns></returns>
        Task<RpcResponse<string>> GetBestBlockHashAsync(string blockchainName, string id);

        /// <summary>
        ///
        /// <para>Returns hex-encoded data or json object for block.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="hash_or_height">(string or numeric) The block hash or height in the active chain</param>
        /// <param name="verbose">(numeric or boolean, optional, default=1) 0(or false) - encoded data, 1(or true) - json object, 2 - with tx encoded data, 4 - with tx json object</param>
        /// <returns></returns>
        Task<T> GetBlockAsync<T>(object hash_or_height, [Optional] object verbose);

        /// <summary>
        ///
        /// <para>Returns hex-encoded data or json object for block.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="hash_or_height">(string or numeric) The block hash or height in the active chain</param>
        /// <param name="verbose">(numeric or boolean, optional, default=1) 0(or false) - encoded data, 1(or true) - json object, 2 - with tx encoded data, 4 - with tx json object</param>
        /// <returns></returns>
        Task<T> GetBlockAsync<T>(string blockchainName, string id, object hash_or_height, [Optional] object verbose);

        /// <summary>
        ///
        /// <para>Returns an object containing various state info regarding block chain processing.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <returns></returns>
        Task<RpcResponse<GetBlockchainInfoResult>> GetBlockchainInfoAsync();

        /// <summary>
        ///
        /// <para>Returns an object containing various state info regarding block chain processing.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <returns></returns>
        Task<RpcResponse<GetBlockchainInfoResult>> GetBlockchainInfoAsync(string blockchainName, string id);

        /// <summary>
        ///
        /// <para>Returns the number of blocks in the longest block chain.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <returns></returns>
        Task<RpcResponse<long>> GetBlockCountAsync();

        /// <summary>
        ///
        /// <para>Returns the number of blocks in the longest block chain.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <returns></returns>
        Task<RpcResponse<long>> GetBlockCountAsync(string blockchainName, string id);

        /// <summary>
        ///
        /// <para>Returns hash of block in best-block-chain at index provided.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="index">The integer block index</param>
        /// <returns></returns>
        Task<RpcResponse<string>> GetBlockHashAsync(int index);

        /// <summary>
        ///
        /// <para>Returns hash of block in best-block-chain at index provided.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="index">The integer block index</param>
        /// <returns></returns>
        Task<RpcResponse<string>> GetBlockHashAsync(string blockchainName, string id, int index);

        /// <summary>
        ///
        /// <para>Return information about all known tips in the block tree, including the main chain as well as orphaned branches.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <returns></returns>
        Task<RpcResponse<GetChainTipsResult[]>> GetChainTipsAsync();

        /// <summary>
        ///
        /// <para>Return information about all known tips in the block tree, including the main chain as well as orphaned branches.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <returns></returns>
        Task<RpcResponse<GetChainTipsResult[]>> GetChainTipsAsync(string blockchainName, string id);

        /// <summary>
        ///
        /// <para>Returns the proof-of-work difficulty as a multiple of the minimum difficulty.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <returns></returns>
        Task<RpcResponse<double>> GetDifficultyAsync();

        /// <summary>
        ///
        /// <para>Returns the proof-of-work difficulty as a multiple of the minimum difficulty.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <returns></returns>
        Task<RpcResponse<double>> GetDifficultyAsync(string blockchainName, string id);

        /// <summary>
        ///
        /// <para>Returns code for specified filter</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="filter_identifier">One of: create txid, filter reference, filter name</param>
        /// <returns></returns>
        Task<RpcResponse<string>> GetFilterCodeAsync(string filter_identifier);

        /// <summary>
        ///
        /// <para>Returns code for specified filter</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="filter_identifier">One of: create txid, filter reference, filter name</param>
        /// <returns></returns>
        Task<RpcResponse<string>> GetFilterCodeAsync(string blockchainName, string id, string filter_identifier);

        /// <summary>
        ///
        /// <para>Returns information about the last or recent blocks in the active chain.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="skip">The number of blocks back to skip. Default 0</param>
        /// <returns></returns>
        Task<RpcResponse<GetLastBlockInfoResult>> GetLastBlockInfoAsync(int skip = 0);

        /// <summary>
        ///
        /// <para>Returns information about the last or recent blocks in the active chain.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="skip">The number of blocks back to skip. Default 0</param>
        /// <returns></returns>
        Task<RpcResponse<GetLastBlockInfoResult>> GetLastBlockInfoAsync(string blockchainName, string id, int skip = 0);

        /// <summary>
        ///
        /// <para>Returns details on the active state of the TX memory pool.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <returns></returns>
        Task<RpcResponse<GetMemPoolInfoResult>> GetMemPoolInfoAsync();

        /// <summary>
        ///
        /// <para>Returns details on the active state of the TX memory pool.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <returns></returns>
        Task<RpcResponse<GetMemPoolInfoResult>> GetMemPoolInfoAsync(string blockchainName, string id);

        /// <summary>
        ///
        /// <para>Returns all transaction ids in memory pool as a json array of string transaction ids.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="verbose">true for a json object, false for array of transaction ids</param>
        /// <returns></returns>
        Task<RpcResponse<GetRawMemPoolResult>> GetRawMemPoolAsync(bool verbose = false);

        /// <summary>
        ///
        /// <para>Returns all transaction ids in memory pool as a json array of string transaction ids.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="verbose">true for a json object, false for array of transaction ids</param>
        /// <returns></returns>
        Task<RpcResponse<GetRawMemPoolResult>> GetRawMemPoolAsync(string blockchainName, string id, bool verbose = false);

        /// <summary>
        ///
        /// <para>Returns information about a single stream.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="stream_identifier">One of: create txid, stream reference, stream name</param>
        /// <param name="verbose">If true, returns list of creators</param>
        /// <returns></returns>
        Task<RpcResponse<GetStreamInfoResult>> GetStreamInfoAsync(string stream_identifier, bool verbose = false);

        /// <summary>
        ///
        /// <para>Returns information about a single stream.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="stream_identifier">One of: create txid, stream reference, stream name</param>
        /// <param name="verbose">If true, returns list of creators</param>
        /// <returns></returns>
        Task<RpcResponse<GetStreamInfoResult>> GetStreamInfoAsync(string blockchainName, string id, string stream_identifier, bool verbose = false);

        /// <summary>
        ///
        /// <para>Returns details about an unspent transaction output.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="txid">The transaction id</param>
        /// <param name="n">vout value</param>
        /// <param name="include_mem_pool">Whether to included the mem pool</param>
        /// <returns></returns>
        Task<RpcResponse<GetTxOutResult>> GetTxOutAsync(string txid, int n, bool include_mem_pool = true);

        /// <summary>
        ///
        /// <para>Returns details about an unspent transaction output.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="txid">The transaction id</param>
        /// <param name="n">vout value</param>
        /// <param name="include_mem_pool">Whether to included the mem pool</param>
        /// <returns></returns>
        Task<RpcResponse<GetTxOutResult>> GetTxOutAsync(string blockchainName, string id, string txid, int n, bool include_mem_pool = true);

        /// <summary>
        ///
        /// <para>Returns statistics about the unspent transaction output set. Note this call may take some time.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <returns></returns>
        Task<RpcResponse<GetTxOutSetInfoResult>> GetTxOutSetInfoAsync();

        /// <summary>
        ///
        /// <para>Returns statistics about the unspent transaction output set. Note this call may take some time.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <returns></returns>
        Task<RpcResponse<GetTxOutSetInfoResult>> GetTxOutSetInfoAsync(string blockchainName, string id);

        /// <summary>
        ///
        /// <para>Returns list of defined assets.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="asset_identifiers">(string, optional) Asset identifier - one of the following: issue txid, asset reference, asset name, or (array, optional) A json array of asset identifiers</param>
        /// <param name="verbose">If true, returns list of all issue transactions, including follow-ons</param>
        /// <param name="count">The number of assets to display</param>
        /// <param name="start">Start from specific asset, 0 based, if negative - from the end</param>
        /// <returns></returns>
        Task<RpcResponse<ListAssetsResult[]>> ListAssetsAsync([Optional] object asset_identifiers, [Optional] bool verbose, [Optional] int count, [Optional] int start);

        /// <summary>
        ///
        /// <para>Returns list of defined assets.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="asset_identifiers">(string, optional) Asset identifier - one of the following: issue txid, asset reference, asset name, or (array, optional) A json array of asset identifiers</param>
        /// <param name="verbose">If true, returns list of all issue transactions, including follow-ons</param>
        /// <param name="count">The number of assets to display</param>
        /// <param name="start">Start from specific asset, 0 based, if negative - from the end</param>
        /// <returns></returns>
        Task<RpcResponse<ListAssetsResult[]>> ListAssetsAsync(string blockchainName, string id, [Optional] object asset_identifiers, [Optional] bool verbose, [Optional] int count, [Optional] int start);

        /// <summary>
        ///
        /// <para>Returns list of block information objects</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="block_set_identifier">
        ///     <para>Comma delimited list of block identifiers: block height, block hash, block height range, e.g. block-from - block-to, number of last blocks in the active chain (if negative)</para>
        ///     <para>or</para>
        ///     <para>String that represents a "block-set-identifier"</para>
        ///     <para>or</para>
        ///     <para>A json array of block identifiers block-set-identifier</para>
        ///     <para>or</para>
        ///     <para>A json object with time range
        ///     {
        ///       "starttime" : start-time      (numeric,required) Start time.
        ///       "endtime" : end-time          (numeric,required) End time.
        ///     }</para>
        /// </param>
        /// <param name="verbose">If true, returns more information</param>
        /// <returns></returns>
        Task<RpcResponse<ListBlocksResult[]>> ListBlocksAsync(object block_set_identifier, bool verbose = false);

        /// <summary>
        ///
        /// <para>Returns list of block information objects</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="block_set_identifier">
        ///     <para>Comma delimited list of block identifiers: block height, block hash, block height range, e.g. block-from - block-to, number of last blocks in the active chain (if negative)</para>
        ///     <para>or</para>
        ///     <para>String that represents a "block-set-identifier"</para>
        ///     <para>or</para>
        ///     <para>A json array of block identifiers block-set-identifier</para>
        ///     <para>or</para>
        ///     <para>A json object with time range
        ///     {
        ///       "starttime" : start-time      (numeric,required) Start time.
        ///       "endtime" : end-time          (numeric,required) End time.
        ///     }</para>
        /// </param>
        /// <param name="verbose">If true, returns more information</param>
        /// <returns></returns>
        Task<RpcResponse<ListBlocksResult[]>> ListBlocksAsync(string blockchainName, string id, object block_set_identifier, bool verbose = false);

        /// <summary>
        ///
        /// <para>Returns a list of all permissions which have been explicitly granted to addresses.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="permissions">Permission strings, comma delimited. Possible values: connect,send,receive,issue,mine,admin,activate,create. Default: all</param>
        /// <param name="addresses">
        ///     <para>(string, optional, default "*") The addresses to retrieve permissions for. "*" for all addresses</para>
        ///     <para>or</para>
        ///     <para>(array, optional) A json array of addresses to return permissions for</para>
        /// </param>
        /// <param name="verbose">If true, returns list of pending grants</param>
        /// <returns></returns>
        Task<RpcResponse<ListPermissionsResult[]>> ListPermissionsAsync([Optional] string permissions, [Optional] object addresses, [Optional] bool verbose);

        /// <summary>
        ///
        /// <para>Returns a list of all permissions which have been explicitly granted to addresses.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="permissions">Permission strings, comma delimited. Possible values: connect,send,receive,issue,mine,admin,activate,create. Default: all</param>
        /// <param name="addresses">
        ///     <para>(string, optional, default "*") The addresses to retrieve permissions for. "*" for all addresses</para>
        ///     <para>or</para>
        ///     <para>(array, optional) A json array of addresses to return permissions for</para>
        /// </param>
        /// <param name="verbose">If true, returns list of pending grants</param>
        /// <returns></returns>
        Task<RpcResponse<ListPermissionsResult[]>> ListPermissionsAsync(string blockchainName, string id, [Optional] string permissions, [Optional] object addresses, [Optional] bool verbose);

        /// <summary>
        ///
        /// <para>Returns list of defined stream filters</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="filter_identifers">
        ///     <para> (string, optional, default=*) Filter identifier - one of: create txid, filter reference, filter name.</para>
        ///     <para>or</para>
        ///     <para>(array, optional) A json array of filter identifiers</para>
        /// </param>
        /// <param name="verbose">If true, returns list of creators and approval details</param>
        /// <returns></returns>
        Task<RpcResponse<ListStreamFiltersResult[]>> ListStreamFiltersAsync([Optional] object filter_identifers, [Optional] bool verbose);

        /// <summary>
        ///
        /// <para>Returns list of defined stream filters</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="filter_identifers">
        ///     <para> (string, optional, default=*) Filter identifier - one of: create txid, filter reference, filter name.</para>
        ///     <para>or</para>
        ///     <para>(array, optional) A json array of filter identifiers</para>
        /// </param>
        /// <param name="verbose">If true, returns list of creators and approval details</param>
        /// <returns></returns>
        Task<RpcResponse<ListStreamFiltersResult[]>> ListStreamFiltersAsync(string blockchainName, string id, [Optional] object filter_identifers, [Optional] bool verbose);

        /// <summary>
        ///
        /// <para>Returns list of defined streams</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="stream_identifiers">
        ///     <para>(string, optional, default=*, all streams) Stream identifier - one of the following: issue txid, stream reference, stream name</para>
        ///     <para>or</para>
        ///     <para>(array, optional) A json array of stream identifiers</para>
        /// </param>
        /// <param name="verbose">If true, returns stream list of creators</param>
        /// <param name="count">The number of streams to display</param>
        /// <param name="start">Start from specific stream, 0 based, if negative - from the end</param>
        /// <returns></returns>
        Task<RpcResponse<ListStreamsResult[]>> ListStreamsAsync([Optional] object stream_identifiers, [Optional] bool verbose, [Optional] int count, [Optional] int start);

        /// <summary>
        ///
        /// <para>Returns list of defined streams</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="stream_identifiers">
        ///     <para>(string, optional, default=*, all streams) Stream identifier - one of the following: issue txid, stream reference, stream name</para>
        ///     <para>or</para>
        ///     <para>(array, optional) A json array of stream identifiers</para>
        /// </param>
        /// <param name="verbose">If true, returns stream list of creators</param>
        /// <param name="count">The number of streams to display</param>
        /// <param name="start">Start from specific stream, 0 based, if negative - from the end</param>
        /// <returns></returns>
        Task<RpcResponse<ListStreamsResult[]>> ListStreamsAsync(string blockchainName, string id, [Optional] object stream_identifiers, [Optional] bool verbose, [Optional] int count, [Optional] int start);

        /// <summary>
        ///
        /// <para>Returns list of defined tx filters</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="filter_identifiers">
        ///     <para>(string, optional, default=*) Filter identifier - one of: create txid, filter reference, filter name</para>
        ///     <para>or</para>
        ///     <para>(array, optional) A json array of filter identifiers</para>
        /// </param>
        /// <param name="verbose">If true, returns list of creators and approval details</param>
        /// <returns></returns>
        Task<RpcResponse<ListTxFiltersResult[]>> ListTxFiltersAsync([Optional] object filter_identifiers, [Optional] bool verbose);

        /// <summary>
        ///
        /// <para>Returns list of defined tx filters</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="filter_identifiers">
        ///     <para>(string, optional, default=*) Filter identifier - one of: create txid, filter reference, filter name</para>
        ///     <para>or</para>
        ///     <para>(array, optional) A json array of filter identifiers</para>
        /// </param>
        /// <param name="verbose">If true, returns list of creators and approval details</param>
        /// <returns></returns>
        Task<RpcResponse<ListTxFiltersResult[]>> ListTxFiltersAsync(string blockchainName, string id, [Optional] object filter_identifiers, [Optional] bool verbose);

        /// <summary>
        ///
        /// <para>Returns list of defined upgrades</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="upgrade_identifiers">
        ///     <para>(string, optional, default=*, all upgrades) Upgrade identifier - one of the following: upgrade txid, upgrade name.</para>
        ///     <para>or</para>
        ///     <para>(array, optional) A json array of upgrade identifiers</para>
        /// </param>
        /// <returns></returns>
        Task<RpcResponse<object>> ListUpgradesAsync([Optional] object upgrade_identifiers);

        /// <summary>
        ///
        /// <para>Returns list of defined upgrades</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="upgrade_identifiers">
        ///     <para>(string, optional, default=*, all upgrades) Upgrade identifier - one of the following: upgrade txid, upgrade name.</para>
        ///     <para>or</para>
        ///     <para>(array, optional) A json array of upgrade identifiers</para>
        /// </param>
        /// <returns></returns>
        Task<RpcResponse<object>> ListUpgradesAsync(string blockchainName, string id, [Optional] object upgrade_identifiers);

        /// <summary>
        ///
        /// <para>Compile an existing filter and optionally test it on a transaction</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="filter_identifier">One of: create txid, filter reference, filter name</param>
        /// <param name="tx_hex">
        ///     <para>The transaction hex string to filter, otherwise filter compiled only</para>
        ///     <para>or</para>
        ///     <para>The transaction id</para>
        /// </param>
        /// <param name="vout">The output number, if omitted and txid/tx-hex is specified, found automatically</param>
        /// <returns></returns>
        Task<RpcResponse<RunStreamFilterResult>> RunStreamFilterAsync(string filter_identifier, [Optional] string tx_hex, [Optional] int vout);

        /// <summary>
        ///
        /// <para>Compile an existing filter and optionally test it on a transaction</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="filter_identifier">One of: create txid, filter reference, filter name</param>
        /// <param name="tx_hex">
        ///     <para>The transaction hex string to filter, otherwise filter compiled only</para>
        ///     <para>or</para>
        ///     <para>The transaction id</para>
        /// </param>
        /// <param name="vout">The output number, if omitted and txid/tx-hex is specified, found automatically</param>
        /// <returns></returns>
        Task<RpcResponse<RunStreamFilterResult>> RunStreamFilterAsync(string blockchainName, string id, string filter_identifier, [Optional] string tx_hex, [Optional] int vout);

        /// <summary>
        ///
        /// <para>Compile an existing filter and optionally test it on a transaction</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="filter_identifier">One of: create txid, filter reference, filter name</param>
        /// <param name="tx_hex">
        ///     <para>(string, optional) The transaction hex string to filter, otherwise filter compiled only</para>
        ///     <para>or</para>
        ///     <para>(string, optional) The transaction id</para>
        /// </param>
        /// <returns></returns>
        Task<RpcResponse<RunTxFilterResult>> RunTxFilterAsync([Optional] string filter_identifier, [Optional] string tx_hex);

        /// <summary>
        ///
        /// <para>Compile an existing filter and optionally test it on a transaction</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="filter_identifier">One of: create txid, filter reference, filter name</param>
        /// <param name="tx_hex">
        ///     <para>(string, optional) The transaction hex string to filter, otherwise filter compiled only</para>
        ///     <para>or</para>
        ///     <para>(string, optional) The transaction id</para>
        /// </param>
        /// <returns></returns>
        Task<RpcResponse<RunTxFilterResult>> RunTxFilterAsync(string blockchainName, string id, [Optional] string filter_identifier, [Optional] string tx_hex);

        /// <summary>
        ///
        /// <para>Compile a test filter and optionally test it on a transaction</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="restrictions">A json object with filter restrictions</param>
        /// <param name="javascript_code">JavaScript filter code, see help filter</param>
        /// <param name="tx_hex">
        ///     <para>(string, optional) The transaction hex string to filter, otherwise filter compiled only</para>
        ///     <para>or</para>
        ///     <para>(string, optional) The transaction id</para>
        /// </param>
        /// <param name="vout">The output number, if omitted and txid/tx-hex is specified, found automatically</param>
        /// <returns></returns>
        Task<RpcResponse<TestStreamFilterResult>> TestStreamFilterAsync(object restrictions, string javascript_code, [Optional] string tx_hex, [Optional] int vout);

        /// <summary>
        ///
        /// <para>Compile a test filter and optionally test it on a transaction</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="restrictions">A json object with filter restrictions</param>
        /// <param name="javascript_code">JavaScript filter code, see help filter</param>
        /// <param name="tx_hex">
        ///     <para>(string, optional) The transaction hex string to filter, otherwise filter compiled only</para>
        ///     <para>or</para>
        ///     <para>(string, optional) The transaction id</para>
        /// </param>
        /// <param name="vout">The output number, if omitted and txid/tx-hex is specified, found automatically</param>
        /// <returns></returns>
        Task<RpcResponse<TestStreamFilterResult>> TestStreamFilterAsync(string blockchainName, string id, object restrictions, string javascript_code, [Optional] string tx_hex, [Optional] int vout);

        /// <summary>
        ///
        /// <para>Compile a test filter and optionally test it on a transaction</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="restrictions">
        ///     <para>(object, required)  a json object with filter restrictions</para>
        ///     <para>{</para>
        ///       <para>"for": "entity-identifier"    (string, optional) Asset/stream identifier - one of: create txid, stream reference, stream name.</para>
        ///        <para> or</para>
        ///       <para>"for": entity-identifier(s)   (array, optional) A json array of asset/stream identifiers</para>
        ///     <para>}</para>
        /// </param>
        /// <param name="javascript_code">JavaScript filter code, see help filters</param>
        /// <param name="tx_hex">
        ///     <para> (string, optional) The transaction hex string to filter, otherwise filter compiled only</para>
        ///     <para>or</para>
        ///     <para>(string, optional) The transaction id</para></param>
        /// <returns></returns>
        Task<RpcResponse<TestTxFilterResult>> TestTxFilterAsync(object restrictions, string javascript_code, [Optional] string tx_hex);

        /// <summary>
        ///
        /// <para>Compile a test filter and optionally test it on a transaction</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="restrictions">
        ///     <para>(object, required)  a json object with filter restrictions</para>
        ///     <para>{</para>
        ///       <para>"for": "entity-identifier"    (string, optional) Asset/stream identifier - one of: create txid, stream reference, stream name.</para>
        ///        <para> or</para>
        ///       <para>"for": entity-identifier(s)   (array, optional) A json array of asset/stream identifiers</para>
        ///     <para>}</para>
        /// </param>
        /// <param name="javascript_code">JavaScript filter code, see help filters</param>
        /// <param name="tx_hex">
        ///     <para> (string, optional) The transaction hex string to filter, otherwise filter compiled only</para>
        ///     <para>or</para>
        ///     <para>(string, optional) The transaction id</para></param>
        /// <returns></returns>
        Task<RpcResponse<TestTxFilterResult>> TestTxFilterAsync(string blockchainName, string id, object restrictions, string javascript_code, [Optional] string tx_hex);

        /// <summary>
        ///
        /// <para>Verifies blockchain database.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="check_level">(numeric, optional, 0-4, default=3) How thorough the block verification is</param>
        /// <param name="num_blocks">(numeric, optional, default=288, 0=all) The number of blocks to check</param>
        /// <returns></returns>
        Task<RpcResponse<bool>> VerifyChainAsync([Optional] int check_level, [Optional] int num_blocks);

        /// <summary>
        ///
        /// <para>Verifies blockchain database.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="check_level">(numeric, optional, 0-4, default=3) How thorough the block verification is</param>
        /// <param name="num_blocks">(numeric, optional, default=288, 0=all) The number of blocks to check</param>
        /// <returns></returns>
        Task<RpcResponse<bool>> VerifyChainAsync(string blockchainName, string id, [Optional] int check_level, [Optional] int num_blocks);

        /// <summary>
        ///
        /// <para>Verify permissions on this blockchain</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="address">The address to verify permission for</param>
        /// <param name="permission">Permission string. Possible values: connect,send,receive,issue,mine,admin,activate,create</param>
        /// <returns></returns>
        Task<RpcResponse<bool>> VerifyPermissionAsync(string address, string permission);

        /// <summary>
        ///
        /// <para>Verify permissions on this blockchain</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="address">The address to verify permission for</param>
        /// <param name="permission">Permission string. Possible values: connect,send,receive,issue,mine,admin,activate,create</param>
        /// <returns></returns>
        Task<RpcResponse<bool>> VerifyPermissionAsync(string blockchainName, string id, string address, string permission);
    }
}