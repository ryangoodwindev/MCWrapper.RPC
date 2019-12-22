using MCWrapper.Data.Models.Blockchain;
using MCWrapper.Ledger.Actions;
using MCWrapper.Ledger.Entities.Extensions;
using MCWrapper.RPC.Connection;
using MCWrapper.RPC.Options;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace MCWrapper.RPC.Ledger.Clients
{
    /// <summary>
    ///
    /// <para>MutliChain Core methods implemented by the MultiChainRpcGeneralClient concrete class</para>
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
    public class MultiChainRpcGeneralClient : MultiChainRpcClient, IMultiChainRpcGeneral
    {
        /// <summary>
        /// Create a new MultiChainRpcGeneralClient instance
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="options"></param>
        public MultiChainRpcGeneralClient(HttpClient httpClient, IOptions<RpcOptions> options)
            : base(httpClient, options) { }

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
        public Task<RpcResponse<GetAssetInfoResult>> GetAssetInfoAsync(string blockchainName, string id,
                                                                       string asset_identifier, bool verbose = false) =>
            TransactAsync<RpcResponse<GetAssetInfoResult>>(blockchainName, BlockchainAction.GetAssetInfoMethod, id, asset_identifier, verbose);

        /// <summary>
        ///
        /// <para>Returns information about a single blockchain asset referenced by issue txid, asset reference, or asset name.</para>
        /// <para>Blockchain name is inferred from RpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="asset_identifier">One of: issue txid, asset reference, asset name</param>
        /// <param name="verbose">If true, returns list of all issue transactions, including follow-ons</param>
        /// <returns></returns>
        public Task<RpcResponse<GetAssetInfoResult>> GetAssetInfoAsync(string asset_identifier, bool verbose = false) =>
            GetAssetInfoAsync(RpcOptions.ChainName, UUID.NoHyphens, asset_identifier, verbose);

        /// <summary>
        ///
        /// <para>Returns a hex encoded hash of the best (tip) block in the longest block chain.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> GetBestBlockHashAsync(string blockchainName, string id) =>
            TransactAsync<RpcResponse<string>>(blockchainName, BlockchainAction.GetBestBlockHashMethod, id);

        /// <summary>
        ///
        /// <para>Returns a hex encoded hash of the best (tip) block in the longest block chain.</para>
        /// <para>Blockchain name is inferred from RpcOptions properties.</para>
        ///
        /// </summary>
        /// <returns></returns>
        public Task<RpcResponse<string>> GetBestBlockHashAsync() =>
            GetBestBlockHashAsync(RpcOptions.ChainName, UUID.NoHyphens);

        /// <summary>
        ///
        /// <para>Returns an object containing various state info regarding block chain processing.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <returns></returns>
        public Task<RpcResponse<GetBlockchainInfoResult>> GetBlockchainInfoAsync(string blockchainName, string id) =>
            TransactAsync<RpcResponse<GetBlockchainInfoResult>>(blockchainName, BlockchainAction.GetBlockChainInfoMethod, id);

        /// <summary>
        ///
        /// <para>Returns an object containing various state info regarding block chain processing.</para>
        /// <para>Blockchain name is inferred from RpcOptions properties.</para>
        ///
        /// </summary>
        /// <returns></returns>
        public Task<RpcResponse<GetBlockchainInfoResult>> GetBlockchainInfoAsync() =>
            GetBlockchainInfoAsync(RpcOptions.ChainName, UUID.NoHyphens);

        /// <summary>
        ///
        /// <para>Returns the number of blocks in the longest block chain.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <returns></returns>
        public Task<RpcResponse<long>> GetBlockCountAsync(string blockchainName, string id) =>
            TransactAsync<RpcResponse<long>>(blockchainName, BlockchainAction.GetBlockCountMethod, id);

        /// <summary>
        ///
        /// <para>Returns the number of blocks in the longest block chain.</para>
        /// <para>Blockchain name is inferred from RpcOptions properties.</para>
        ///
        /// </summary>
        /// <returns></returns>
        public Task<RpcResponse<long>> GetBlockCountAsync() =>
            GetBlockCountAsync(RpcOptions.ChainName, UUID.NoHyphens);

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
        public Task<RpcResponse<string>> GetBlockHashAsync(string blockchainName, string id, int index) =>
            TransactAsync<RpcResponse<string>>(blockchainName, BlockchainAction.GetBlockHashMethod, id, index);

        /// <summary>
        ///
        /// <para>Returns hash of block in best-block-chain at index provided.</para>
        /// <para>Blockchain name is inferred from RpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="index">The integer block index</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> GetBlockHashAsync(int index) =>
            GetBlockHashAsync(RpcOptions.ChainName, UUID.NoHyphens, index);

        /// <summary>
        /// 
        /// <para>Returns hex-encoded block.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        /// 
        /// </summary>
        /// <param name="blockchainName"></param>
        /// <param name="id"></param>
        /// <param name="hashOrHeight"></param>
        /// <returns></returns>
        public Task<RpcResponse<string>> GetBlockEncodedAsync(string blockchainName, string id, string hashOrHeight) =>
            TransactAsync<RpcResponse<string>>(blockchainName, BlockchainAction.GetBlockMethod, id, hashOrHeight, false);

        /// <summary>
        /// 
        /// <para>Returns hex-encoded block.</para>
        /// <para>Blockchain name is inferred from RpcOptions properties.</para>
        /// 
        /// </summary>
        /// <param name="hashOrHeight"></param>
        /// <returns></returns>
        public Task<RpcResponse<string>> GetBlockEncodedAsync(string hashOrHeight) =>
            GetBlockEncodedAsync(RpcOptions.ChainName, UUID.NoHyphens, hashOrHeight);

        /// <summary>
        /// 
        /// <para>Returns JSON object for block.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        /// 
        /// </summary>
        /// <param name="blockchainName"></param>
        /// <param name="id"></param>
        /// <param name="hashOrHeight"></param>
        /// <returns></returns>
        public Task<RpcResponse<GetBlockVerboseResult>> GetBlockVerboseAsync(string blockchainName, string id, string hashOrHeight) =>
            TransactAsync<RpcResponse<GetBlockVerboseResult>>(blockchainName, BlockchainAction.GetBlockMethod, id, hashOrHeight, true);

        /// <summary>
        /// 
        /// <para>Returns JSON object for block.</para>
        /// <para>Blockchain name is inferred from RpcOptions properties.</para>
        /// 
        /// </summary>
        /// <param name="hashOrHeight"></param>
        /// <returns></returns>
        public Task<RpcResponse<GetBlockVerboseResult>> GetBlockVerboseAsync(string hashOrHeight) =>
            GetBlockVerboseAsync(RpcOptions.ChainName, UUID.NoHyphens, hashOrHeight);

        /// <summary>
        /// 
        /// <para>Returns JSON object for block.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        /// 
        /// </summary>
        /// <param name="blockchainName"></param>
        /// <param name="id"></param>
        /// <param name="hashOrHeight"></param>
        /// <returns></returns>
        public Task<RpcResponse<GetBlockV1Result>> GetBlockV1Async(string blockchainName, string id, string hashOrHeight) =>
            TransactAsync<RpcResponse<GetBlockV1Result>>(blockchainName, BlockchainAction.GetBlockMethod, id, hashOrHeight, 1);

        /// <summary>
        /// 
        /// <para>Returns JSON object for block.</para>
        /// <para>Blockchain name is inferred from RpcOptions properties.</para>
        /// 
        /// </summary>
        /// <param name="hashOrHeight"></param>
        /// <returns></returns>
        public Task<RpcResponse<GetBlockV1Result>> GetBlockV1Async(string hashOrHeight) =>
            GetBlockV1Async(RpcOptions.ChainName, UUID.NoHyphens, hashOrHeight);

        /// <summary>
        /// 
        /// <para>Returns JSON object for block.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        /// 
        /// </summary>
        /// <param name="blockchainName"></param>
        /// <param name="id"></param>
        /// <param name="hashOrHeight"></param>
        /// <returns></returns>
        public Task<RpcResponse<GetBlockV2Result>> GetBlockV2Async(string blockchainName, string id, string hashOrHeight) =>
            TransactAsync<RpcResponse<GetBlockV2Result>>(blockchainName, BlockchainAction.GetBlockMethod, id, hashOrHeight, 2);

        /// <summary>
        /// 
        /// <para>Returns JSON object for block.</para>
        /// <para>Blockchain name is inferred from RpcOptions properties.</para>
        /// 
        /// </summary>
        /// <param name="hashOrHeight"></param>
        /// <returns></returns>
        public Task<RpcResponse<GetBlockV2Result>> GetBlockV2Async(string hashOrHeight) =>
            GetBlockV2Async(RpcOptions.ChainName, UUID.NoHyphens, hashOrHeight);

        /// <summary>
        /// 
        /// <para>Returns JSON object for block.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        /// 
        /// </summary>
        /// <param name="blockchainName"></param>
        /// <param name="id"></param>
        /// <param name="hashOrHeight"></param>
        /// <returns></returns>
        public Task<RpcResponse<GetBlockV3Result>> GetBlockV3Async(string blockchainName, string id, string hashOrHeight) =>
            TransactAsync<RpcResponse<GetBlockV3Result>>(blockchainName, BlockchainAction.GetBlockMethod, id, hashOrHeight, 3);

        /// <summary>
        /// 
        /// <para>Returns JSON object for block.</para>
        /// <para>Blockchain name is inferred from RpcOptions properties.</para>
        /// 
        /// </summary>
        /// <param name="hashOrHeight"></param>
        /// <returns></returns>
        public Task<RpcResponse<GetBlockV3Result>> GetBlockV3Async(string hashOrHeight) =>
            GetBlockV3Async(RpcOptions.ChainName, UUID.NoHyphens, hashOrHeight);

        /// <summary>
        /// 
        /// <para>Returns JSON object for block.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        /// 
        /// </summary>
        /// <param name="blockchainName"></param>
        /// <param name="id"></param>
        /// <param name="hashOrHeight"></param>
        /// <returns></returns>
        public Task<RpcResponse<GetBlockV4Result>> GetBlockV4Async(string blockchainName, string id, string hashOrHeight) =>
            TransactAsync<RpcResponse<GetBlockV4Result>>(blockchainName, BlockchainAction.GetBlockMethod, id, hashOrHeight, 4);

        /// <summary>
        /// 
        /// <para>Returns JSON object for block.</para>
        /// <para>Blockchain name is inferred from RpcOptions properties.</para>
        /// 
        /// </summary>
        /// <param name="hashOrHeight"></param>
        /// <returns></returns>
        public Task<RpcResponse<GetBlockV4Result>> GetBlockV4Async(string hashOrHeight) =>
            GetBlockV4Async(RpcOptions.ChainName, UUID.NoHyphens, hashOrHeight);

        /// <summary>
        ///
        /// <para>Return information about all known tips in the block tree, including the main chain as well as orphaned branches.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <returns></returns>
        public Task<RpcResponse<GetChainTipsResult[]>> GetChainTipsAsync(string blockchainName, string id) =>
            TransactAsync<RpcResponse<GetChainTipsResult[]>>(blockchainName, BlockchainAction.GetChainTipsMethod, id);

        /// <summary>
        ///
        /// <para>Return information about all known tips in the block tree, including the main chain as well as orphaned branches.</para>
        /// <para>Blockchain name is inferred from RpcOptions properties.</para>
        ///
        /// </summary>
        /// <returns></returns>
        public Task<RpcResponse<GetChainTipsResult[]>> GetChainTipsAsync() =>
            GetChainTipsAsync(RpcOptions.ChainName, UUID.NoHyphens);

        /// <summary>
        ///
        /// <para>Returns the proof-of-work difficulty as a multiple of the minimum difficulty.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <returns></returns>
        public Task<RpcResponse<double>> GetDifficultyAsync(string blockchainName, string id) =>
            TransactAsync<RpcResponse<double>>(blockchainName, BlockchainAction.GetDifficultyMethod, id);

        /// <summary>
        ///
        /// <para>Returns the proof-of-work difficulty as a multiple of the minimum difficulty.</para>
        /// <para>Blockchain name is inferred from RpcOptions properties.</para>
        ///
        /// </summary>
        /// <returns></returns>
        public Task<RpcResponse<double>> GetDifficultyAsync() =>
            GetDifficultyAsync(RpcOptions.ChainName, UUID.NoHyphens);

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
        public Task<RpcResponse<string>> GetFilterCodeAsync(string blockchainName, string id, string filter_identifier) =>
            TransactAsync<RpcResponse<string>>(blockchainName, BlockchainAction.GetFilterCodeMethod, id, filter_identifier);

        /// <summary>
        ///
        /// <para>Returns code for specified filter</para>
        /// <para>Blockchain name is inferred from RpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="filter_identifier">One of: create txid, filter reference, filter name</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> GetFilterCodeAsync(string filter_identifier) =>
            GetFilterCodeAsync(RpcOptions.ChainName, UUID.NoHyphens, filter_identifier);

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
        public Task<RpcResponse<GetLastBlockInfoResult>> GetLastBlockInfoAsync(string blockchainName, string id, int skip = 0) =>
            TransactAsync<RpcResponse<GetLastBlockInfoResult>>(blockchainName, BlockchainAction.GetLastBlockInfoMethod, id, skip);

        /// <summary>
        ///
        /// <para>Returns information about the last or recent blocks in the active chain.</para>
        /// <para>Blockchain name is inferred from RpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="skip">The number of blocks back to skip. Default 0</param>
        /// <returns></returns>
        public Task<RpcResponse<GetLastBlockInfoResult>> GetLastBlockInfoAsync(int skip = 0) =>
            GetLastBlockInfoAsync(RpcOptions.ChainName, UUID.NoHyphens, skip);

        /// <summary>
        ///
        /// <para>Returns details on the active state of the TX memory pool.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <returns></returns>
        public Task<RpcResponse<GetMemPoolInfoResult>> GetMemPoolInfoAsync(string blockchainName, string id) =>
            TransactAsync<RpcResponse<GetMemPoolInfoResult>>(blockchainName, BlockchainAction.GetMemPoolInfoMethod, id);

        /// <summary>
        ///
        /// <para>Returns details on the active state of the TX memory pool.</para>
        /// <para>Blockchain name is inferred from RpcOptions properties.</para>
        ///
        /// </summary>
        /// <returns></returns>
        public Task<RpcResponse<GetMemPoolInfoResult>> GetMemPoolInfoAsync() =>
            GetMemPoolInfoAsync(RpcOptions.ChainName, UUID.NoHyphens);

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
        public Task<RpcResponse<GetRawMemPoolResult>> GetRawMemPoolAsync(string blockchainName, string id, bool verbose = false) =>
            TransactAsync<RpcResponse<GetRawMemPoolResult>>(blockchainName, BlockchainAction.GetRawMemPoolMethod, id, verbose);

        /// <summary>
        ///
        /// <para>Returns all transaction ids in memory pool as a json array of string transaction ids.</para>
        /// <para>Blockchain name is inferred from RpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="verbose">true for a json object, false for array of transaction ids</param>
        /// <returns></returns>
        public Task<RpcResponse<GetRawMemPoolResult>> GetRawMemPoolAsync(bool verbose = false) =>
            GetRawMemPoolAsync(RpcOptions.ChainName, UUID.NoHyphens, verbose);

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
        public Task<RpcResponse<GetStreamInfoResult>> GetStreamInfoAsync(string blockchainName, string id,
                                                                         string stream_identifier, bool verbose = false) =>
            TransactAsync<RpcResponse<GetStreamInfoResult>>(blockchainName, BlockchainAction.GetStreamInfoMethod, id, stream_identifier, verbose);

        /// <summary>
        ///
        /// <para>Returns information about a single stream.</para>
        /// <para>Blockchain name is inferred from RpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="stream_identifier">One of: create txid, stream reference, stream name</param>
        /// <param name="verbose">If true, returns list of creators</param>
        /// <returns></returns>
        public Task<RpcResponse<GetStreamInfoResult>> GetStreamInfoAsync(string stream_identifier, bool verbose = false) =>
            GetStreamInfoAsync(RpcOptions.ChainName, UUID.NoHyphens, stream_identifier, verbose);

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
        public Task<RpcResponse<GetTxOutResult>> GetTxOutAsync(string blockchainName, string id, string txid, int n,
                                                               bool include_mem_pool = true) =>
            TransactAsync<RpcResponse<GetTxOutResult>>(blockchainName, BlockchainAction.GetTxOutMethod, id, txid, n, include_mem_pool);

        /// <summary>
        ///
        /// <para>Returns details about an unspent transaction output.</para>
        /// <para>Blockchain name is inferred from RpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="txid">The transaction id</param>
        /// <param name="n">vout value</param>
        /// <param name="include_mem_pool">Whether to included the mem pool</param>
        /// <returns></returns>
        public Task<RpcResponse<GetTxOutResult>> GetTxOutAsync(string txid, int n, bool include_mem_pool = true) =>
            GetTxOutAsync(RpcOptions.ChainName, UUID.NoHyphens, txid, n, include_mem_pool);

        /// <summary>
        ///
        /// <para>Returns statistics about the unspent transaction output set. Note this call may take some time.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <returns></returns>
        public Task<RpcResponse<GetTxOutSetInfoResult>> GetTxOutSetInfoAsync(string blockchainName, string id) =>
            TransactAsync<RpcResponse<GetTxOutSetInfoResult>>(blockchainName, BlockchainAction.GetTxOutSetInfoMethod, id);

        /// <summary>
        ///
        /// <para>Returns statistics about the unspent transaction output set. Note this call may take some time.</para>
        /// <para>Blockchain name is inferred from RpcOptions properties.</para>
        ///
        /// </summary>
        /// <returns></returns>
        public Task<RpcResponse<GetTxOutSetInfoResult>> GetTxOutSetInfoAsync() =>
            GetTxOutSetInfoAsync(RpcOptions.ChainName, UUID.NoHyphens);

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
        public Task<RpcResponse<ListAssetsResult[]>> ListAssetsAsync(string blockchainName, string id,
                                                                     [Optional] object asset_identifiers,
                                                                     [Optional] bool verbose, [Optional] int count,
                                                                     [Optional] int start) =>
            TransactAsync<RpcResponse<ListAssetsResult[]>>(blockchainName, BlockchainAction.ListAssetsMethod, id, asset_identifiers, verbose, count, start);

        /// <summary>
        ///
        /// <para>Returns list of defined assets.</para>
        /// <para>Blockchain name is inferred from RpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="asset_identifiers">(string, optional) Asset identifier - one of the following: issue txid, asset reference, asset name, or (array, optional) A json array of asset identifiers</param>
        /// <param name="verbose">If true, returns list of all issue transactions, including follow-ons</param>
        /// <param name="count">The number of assets to display</param>
        /// <param name="start">Start from specific asset, 0 based, if negative - from the end</param>
        /// <returns></returns>
        public Task<RpcResponse<ListAssetsResult[]>> ListAssetsAsync([Optional] object asset_identifiers,
                                                                     [Optional] bool verbose, [Optional] int count,
                                                                     [Optional] int start) =>
            ListAssetsAsync(RpcOptions.ChainName, UUID.NoHyphens, asset_identifiers, verbose, count, start);

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
        public Task<RpcResponse<ListBlocksResult[]>> ListBlocksAsync(string blockchainName, string id,
                                                                     object block_set_identifier, bool verbose = false) =>
            TransactAsync<RpcResponse<ListBlocksResult[]>>(blockchainName, BlockchainAction.ListBlocksMethod, id, block_set_identifier, verbose);

        /// <summary>
        ///
        /// <para>Returns list of block information objects</para>
        /// <para>Blockchain name is inferred from RpcOptions properties.</para>
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
        public Task<RpcResponse<ListBlocksResult[]>> ListBlocksAsync(object block_set_identifier, bool verbose = false) =>
            ListBlocksAsync(RpcOptions.ChainName, UUID.NoHyphens, block_set_identifier, verbose);

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
        public Task<RpcResponse<ListPermissionsResult[]>> ListPermissionsAsync(string blockchainName, string id,
                                                                               [Optional] string permissions,
                                                                               [Optional] object addresses,
                                                                               [Optional] bool verbose) =>
            TransactAsync<RpcResponse<ListPermissionsResult[]>>(blockchainName, BlockchainAction.ListPermissionsMethod, id, permissions, addresses, verbose);

        /// <summary>
        ///
        /// <para>Returns a list of all permissions which have been explicitly granted to addresses.</para>
        /// <para>Blockchain name is inferred from RpcOptions properties.</para>
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
        public Task<RpcResponse<ListPermissionsResult[]>> ListPermissionsAsync([Optional] string permissions,
                                                                               [Optional] object addresses,
                                                                               [Optional] bool verbose) =>
            ListPermissionsAsync(RpcOptions.ChainName, UUID.NoHyphens, permissions, addresses, verbose);

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
        public Task<RpcResponse<ListStreamFiltersResult[]>> ListStreamFiltersAsync(string blockchainName, string id,
                                                                                   [Optional] object filter_identifers,
                                                                                   [Optional] bool verbose) =>
            TransactAsync<RpcResponse<ListStreamFiltersResult[]>>(blockchainName, BlockchainAction.ListStreamFiltersMethod, id, filter_identifers, verbose);

        /// <summary>
        ///
        /// <para>Returns list of defined stream filters</para>
        /// <para>Blockchain name is inferred from RpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="filter_identifers">
        ///     <para> (string, optional, default=*) Filter identifier - one of: create txid, filter reference, filter name.</para>
        ///     <para>or</para>
        ///     <para>(array, optional) A json array of filter identifiers</para>
        /// </param>
        /// <param name="verbose">If true, returns list of creators and approval details</param>
        /// <returns></returns>
        public Task<RpcResponse<ListStreamFiltersResult[]>> ListStreamFiltersAsync([Optional] object filter_identifers, [Optional] bool verbose) =>
            ListStreamFiltersAsync(RpcOptions.ChainName, UUID.NoHyphens, filter_identifers, verbose);

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
        public Task<RpcResponse<ListStreamsResult[]>> ListStreamsAsync(string blockchainName, string id,
                                                                       [Optional] object stream_identifiers,
                                                                       [Optional] bool verbose, [Optional] int count,
                                                                       [Optional] int start) =>
            TransactAsync<RpcResponse<ListStreamsResult[]>>(blockchainName, BlockchainAction.ListStreamsMethod, id, stream_identifiers, verbose, count, start);

        /// <summary>
        ///
        /// <para>Returns list of defined streams</para>
        /// <para>Blockchain name is inferred from RpcOptions properties.</para>
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
        public Task<RpcResponse<ListStreamsResult[]>> ListStreamsAsync([Optional] object stream_identifiers,
                                                                       [Optional] bool verbose, [Optional] int count,
                                                                       [Optional] int start) =>
            ListStreamsAsync(RpcOptions.ChainName, UUID.NoHyphens, stream_identifiers, verbose, count, start);

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
        public Task<RpcResponse<ListTxFiltersResult[]>> ListTxFiltersAsync(string blockchainName, string id,
                                                                           [Optional] object filter_identifiers,
                                                                           [Optional] bool verbose) =>
            TransactAsync<RpcResponse<ListTxFiltersResult[]>>(blockchainName, BlockchainAction.ListTxFiltersMethod, id, filter_identifiers, verbose);

        /// <summary>
        ///
        /// <para>Returns list of defined tx filters</para>
        /// <para>Blockchain name is inferred from RpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="filter_identifiers">
        ///     <para>(string, optional, default=*) Filter identifier - one of: create txid, filter reference, filter name</para>
        ///     <para>or</para>
        ///     <para>(array, optional) A json array of filter identifiers</para>
        /// </param>
        /// <param name="verbose">If true, returns list of creators and approval details</param>
        /// <returns></returns>
        public Task<RpcResponse<ListTxFiltersResult[]>> ListTxFiltersAsync([Optional] object filter_identifiers, [Optional] bool verbose) =>
            ListTxFiltersAsync(RpcOptions.ChainName, UUID.NoHyphens, filter_identifiers, verbose);

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
        public Task<RpcResponse<object>> ListUpgradesAsync(string blockchainName, string id, [Optional] object upgrade_identifiers) =>
            TransactAsync<RpcResponse<object>>(blockchainName, BlockchainAction.ListUpgradesMethod, id, upgrade_identifiers);

        /// <summary>
        ///
        /// <para>Returns list of defined upgrades</para>
        /// <para>Blockchain name is inferred from RpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="upgrade_identifiers">
        ///     <para>(string, optional, default=*, all upgrades) Upgrade identifier - one of the following: upgrade txid, upgrade name.</para>
        ///     <para>or</para>
        ///     <para>(array, optional) A json array of upgrade identifiers</para>
        /// </param>
        /// <returns></returns>
        public Task<RpcResponse<object>> ListUpgradesAsync([Optional] object upgrade_identifiers) =>
            ListUpgradesAsync(RpcOptions.ChainName, UUID.NoHyphens, upgrade_identifiers);

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
        public Task<RpcResponse<RunStreamFilterResult>> RunStreamFilterAsync(string blockchainName, string id,
                                                                             string filter_identifier,
                                                                             [Optional] string tx_hex,
                                                                             [Optional] int vout) =>
            TransactAsync<RpcResponse<RunStreamFilterResult>>(blockchainName, BlockchainAction.RunStreamFilterMethod, id, filter_identifier, tx_hex, vout);

        /// <summary>
        ///
        /// <para>Compile an existing filter and optionally test it on a transaction</para>
        /// <para>Blockchain name is inferred from RpcOptions properties.</para>
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
        public Task<RpcResponse<RunStreamFilterResult>> RunStreamFilterAsync(string filter_identifier,
                                                                             [Optional] string tx_hex,
                                                                             [Optional] int vout) =>
            RunStreamFilterAsync(RpcOptions.ChainName, UUID.NoHyphens, filter_identifier, tx_hex, vout);

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
        public Task<RpcResponse<RunTxFilterResult>> RunTxFilterAsync(string blockchainName, string id,
                                                                     [Optional] string filter_identifier,
                                                                     [Optional] string tx_hex) =>
            TransactAsync<RpcResponse<RunTxFilterResult>>(blockchainName, BlockchainAction.RunTxFilterMethod, id, filter_identifier, tx_hex);

        /// <summary>
        ///
        /// <para>Compile an existing filter and optionally test it on a transaction</para>
        /// <para>Blockchain name is inferred from RpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="filter_identifier">One of: create txid, filter reference, filter name</param>
        /// <param name="tx_hex">
        ///     <para>(string, optional) The transaction hex string to filter, otherwise filter compiled only</para>
        ///     <para>or</para>
        ///     <para>(string, optional) The transaction id</para>
        /// </param>
        /// <returns></returns>
        public Task<RpcResponse<RunTxFilterResult>> RunTxFilterAsync([Optional] string filter_identifier, [Optional] string tx_hex) =>
            RunTxFilterAsync(RpcOptions.ChainName, UUID.NoHyphens, filter_identifier, tx_hex);

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
        public Task<RpcResponse<TestStreamFilterResult>> TestStreamFilterAsync(string blockchainName, string id,
                                                                               object restrictions,
                                                                               string javascript_code,
                                                                               [Optional] string tx_hex,
                                                                               [Optional] int vout) =>
            TransactAsync<RpcResponse<TestStreamFilterResult>>(blockchainName, BlockchainAction.TestStreamFilterMethod, id, restrictions, javascript_code, tx_hex, vout);

        /// <summary>
        ///
        /// <para>Compile a test filter and optionally test it on a transaction</para>
        /// <para>Blockchain name is inferred from RpcOptions properties.</para>
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
        public Task<RpcResponse<TestStreamFilterResult>> TestStreamFilterAsync(object restrictions,
                                                                               string javascript_code,
                                                                               [Optional] string tx_hex,
                                                                               [Optional] int vout) =>
            TestStreamFilterAsync(RpcOptions.ChainName, UUID.NoHyphens, restrictions, javascript_code, tx_hex, vout);

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
        public Task<RpcResponse<TestTxFilterResult>> TestTxFilterAsync(string blockchainName, string id,
                                                                       object restrictions, string javascript_code,
                                                                       [Optional] string tx_hex) =>
            TransactAsync<RpcResponse<TestTxFilterResult>>(blockchainName, BlockchainAction.TestTxFilterMethod, id, restrictions, javascript_code, tx_hex);

        /// <summary>
        ///
        /// <para>Compile a test filter and optionally test it on a transaction</para>
        /// <para>Blockchain name is inferred from RpcOptions properties.</para>
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
        public Task<RpcResponse<TestTxFilterResult>> TestTxFilterAsync(object restrictions, string javascript_code,
                                                                       [Optional] string tx_hex) =>
            TestTxFilterAsync(RpcOptions.ChainName, UUID.NoHyphens, restrictions, javascript_code, tx_hex);

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
        public Task<RpcResponse<bool>> VerifyChainAsync(string blockchainName, string id, [Optional] int check_level,
                                                        [Optional] int num_blocks) =>
            TransactAsync<RpcResponse<bool>>(blockchainName, BlockchainAction.VerifyChainMethod, id, check_level, num_blocks);

        /// <summary>
        ///
        /// <para>Verifies blockchain database.</para>
        /// <para>Blockchain name is inferred from RpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="check_level">(numeric, optional, 0-4, default=3) How thorough the block verification is</param>
        /// <param name="num_blocks">(numeric, optional, default=288, 0=all) The number of blocks to check</param>
        /// <returns></returns>
        public Task<RpcResponse<bool>> VerifyChainAsync([Optional] int check_level, [Optional] int num_blocks) =>
            VerifyChainAsync(RpcOptions.ChainName, UUID.NoHyphens, check_level, num_blocks);

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
        public Task<RpcResponse<bool>> VerifyPermissionAsync(string blockchainName, string id, string address, string permission) =>
            TransactAsync<RpcResponse<bool>>(blockchainName, BlockchainAction.VerifyPermissionMethod, id, address, permission);

        /// <summary>
        ///
        /// <para>Verify permissions on this blockchain</para>
        /// <para>Blockchain name is inferred from RpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="address">The address to verify permission for</param>
        /// <param name="permission">Permission string. Possible values: connect,send,receive,issue,mine,admin,activate,create</param>
        /// <returns></returns>
        public Task<RpcResponse<bool>> VerifyPermissionAsync(string address, string permission) =>
            VerifyPermissionAsync(RpcOptions.ChainName, UUID.NoHyphens, address, permission);
    }
}