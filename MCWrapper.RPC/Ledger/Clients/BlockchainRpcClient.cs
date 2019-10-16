using MCWrapper.RPC.Connection;
using MCWrapper.RPC.Extensions;
using MCWrapper.RPC.Ledger.Actions;
using MCWrapper.RPC.Ledger.Models.Blockchain;
using MCWrapper.RPC.Options;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MCWrapper.RPC.Ledger.Clients.Blockchain
{
    /// <summary>
    /// 
    /// MutliChain methods implemented by the concrete BlockchainRPCClient class:
    /// 
    /// getassetinfo, getbestblockhash, getblock, getblockchaininfo, 
    /// getblockcount, getblockhash, getchaintips, getdifficulty, 
    /// getfiltercode, getlastblockinfo, getmempoolinfo, getrawmempool,
    /// getstreaminfo, gettxout, gettxoutsetinfo, listassets, listblocks,
    /// listpermissions, liststreamfilters, liststreams, listtxfilters, 
    /// listupgrades, runstreamfilter, runtxfilter, teststreamfilter, 
    /// testtxfilter, verifychain, verifypermission
    /// 
    /// <para>Inherits from an RPCClient and implements the IBlockchainRPC contract</para>
    /// 
    /// </summary>
    public class BlockchainRpcClient : RpcConnection
    {
        public BlockchainRpcClient(HttpClient client, IOptions<BlockchainProfileOptions> options) 
            : base(client, options) { }


        public async Task<RpcResponse<GetAssetInfoResult>> GetAssetInfoAsync(string blockchainName, string id, string asset_identifier, bool verbose)
        {
            var response = await TransactAsync<RpcResponse<GetAssetInfoResult>>(blockchainName, BlockchainAction.GetAssetInfoMethod, id, asset_identifier, verbose);

            return response;
        }

        public Task<RpcResponse<GetAssetInfoResult>> GetAssetInfoAsync(string asset_identifier, bool verbose)
        {
            return GetAssetInfoAsync(BlockchainOptions.ChainName, UUID.NoHyphens, asset_identifier, verbose);
        }


        public async Task<RpcResponse<GetBlockchainInfoResult>> GetBlockchainInfoAsync(string blockchainName, string id)
        {
            var response = await TransactAsync<RpcResponse<GetBlockchainInfoResult>>(blockchainName, BlockchainAction.GetBlockChainInfoMethod, id);

            return response;
        }

        public Task<RpcResponse<GetBlockchainInfoResult>> GetBlockchainInfoAsync()
        {
            return GetBlockchainInfoAsync(BlockchainOptions.ChainName, UUID.NoHyphens);
        }


        public async Task<RpcResponse<string>> GetBestBlockHashAsync(string blockchainName, string id)
        {
            var response = await TransactAsync<RpcResponse<string>>(blockchainName, BlockchainAction.GetBestBlockHashMethod, id);

            return response;
        }

        public Task<RpcResponse<string>> GetBestBlockHashAsync()
        {
            return GetBestBlockHashAsync(BlockchainOptions.ChainName, UUID.NoHyphens);
        }


        public async Task<T> GetBlockAsync<T>(string blockchainName, string id, object hash_or_height, object verbose)
        {
            var response = await TransactAsync<T>(blockchainName, BlockchainAction.GetBlockMethod, id, hash_or_height, verbose);

            return response;
        }

        public Task<T> GetBlockAsync<T>(object hash_or_height, object verbose)
        {
            return GetBlockAsync<T>(BlockchainOptions.ChainName, UUID.NoHyphens, hash_or_height, verbose);
        }


        public async Task<RpcResponse<long>> GetBlockCountAsync(string blockchainName, string id)
        {
            var response = await TransactAsync<RpcResponse<Int64>>(blockchainName, BlockchainAction.GetBlockCountMethod, id);

            return response;
        }

        public Task<RpcResponse<long>> GetBlockCountAsync()
        {
            return GetBlockCountAsync(BlockchainOptions.ChainName, UUID.NoHyphens);
        }


        public async Task<RpcResponse<string>> GetBlockHashAsync(string blockchainName, string id, int index)
        {
            var response = await TransactAsync<RpcResponse<string>>(blockchainName, BlockchainAction.GetBlockHashMethod, id, index);

            return response;
        }

        public Task<RpcResponse<string>> GetBlockHashAsync(int index)
        {
            return GetBlockHashAsync(BlockchainOptions.ChainName, UUID.NoHyphens, index);
        }


        public async Task<RpcResponse<GetChainTipsResult[]>> GetChainTipsAsync(string blockchainName, string id)
        {
            var response = await TransactAsync<RpcResponse<GetChainTipsResult[]>>(blockchainName, BlockchainAction.GetChainTipsMethod, id);

            return response;
        }

        public Task<RpcResponse<GetChainTipsResult[]>> GetChainTipsAsync()
        {
            return GetChainTipsAsync(BlockchainOptions.ChainName, UUID.NoHyphens);
        }


        public async Task<RpcResponse<double>> GetDifficultyAsync(string blockchainName, string id)
        {
            var response = await TransactAsync<RpcResponse<double>>(blockchainName, BlockchainAction.GetDifficultyMethod, id);

            return response;
        }

        public Task<RpcResponse<double>> GetDifficultyAsync()
        {
            return GetDifficultyAsync(BlockchainOptions.ChainName, UUID.NoHyphens);
        }


        public async Task<RpcResponse<string>> GetFilterCodeAsync(string blockchainName, string id, string filter_identifier)
        {
            var response = await TransactAsync<RpcResponse<string>>(blockchainName, BlockchainAction.GetFilterCodeMethod, id, filter_identifier);

            return response;
        }

        public Task<RpcResponse<string>> GetFilterCodeAsync(string filter_identifier)
        {
            return GetFilterCodeAsync(BlockchainOptions.ChainName, UUID.NoHyphens, filter_identifier);
        }


        public async Task<RpcResponse<GetLastBlockInfoResult>> GetLastBlockInfoAsync(string blockchainName, string id, int skip)
        {
            var response = await TransactAsync<RpcResponse<GetLastBlockInfoResult>>(blockchainName, BlockchainAction.GetLastBlockInfoMethod, id, skip);

            return response;
        }

        public Task<RpcResponse<GetLastBlockInfoResult>> GetLastBlockInfoAsync(int skip)
        {
            return GetLastBlockInfoAsync(BlockchainOptions.ChainName, UUID.NoHyphens, skip);
        }


        public async Task<RpcResponse<GetMemPoolInfoResult>> GetMemPoolInfoAsync(string blockchainName, string id)
        {
            var response = await TransactAsync<RpcResponse<GetMemPoolInfoResult>>(blockchainName, BlockchainAction.GetMemPoolInfoMethod, id);

            return response;
        }

        public Task<RpcResponse<GetMemPoolInfoResult>> GetMemPoolInfoAsync()
        {
            return GetMemPoolInfoAsync(BlockchainOptions.ChainName, UUID.NoHyphens);
        }


        public async Task<RpcResponse<GetRawMemPoolResult>> GetRawMemPoolAsync(string blockchainName, string id, bool verbose)
        {
            var response = await TransactAsync<RpcResponse<GetRawMemPoolResult>>(blockchainName, BlockchainAction.GetRawMemPoolMethod, id, verbose);

            return response;
        }

        public Task<RpcResponse<GetRawMemPoolResult>> GetRawMemPoolAsync(bool verbose)
        {
            return GetRawMemPoolAsync(BlockchainOptions.ChainName, UUID.NoHyphens, verbose);
        }


        public async Task<RpcResponse<GetStreamInfoResult>> GetStreamInfoAsync(string blockchainName, string id, string stream_identifier, bool verbose)
        {
            var response = await TransactAsync<RpcResponse<GetStreamInfoResult>>(blockchainName, BlockchainAction.GetStreamInfoMethod, id, stream_identifier, verbose);

            return response;
        }

        public Task<RpcResponse<GetStreamInfoResult>> GetStreamInfoAsync(string stream_identifier, bool verbose)
        {
            return GetStreamInfoAsync(BlockchainOptions.ChainName, UUID.NoHyphens, stream_identifier, verbose);
        }


        public async Task<RpcResponse<GetTxOutResult>> GetTxOutAsync(string blockchainName, string id, string txid, int n, bool include_mem_pool)
        {
            var response = await TransactAsync<RpcResponse<GetTxOutResult>>(blockchainName, BlockchainAction.GetTxOutMethod, id, txid, n, include_mem_pool);

            return response;
        }

        public Task<RpcResponse<GetTxOutResult>> GetTxOutAsync(string txid, int n, bool include_mem_pool)
        {
            return GetTxOutAsync(BlockchainOptions.ChainName, UUID.NoHyphens, txid, n, include_mem_pool);
        }


        public async Task<RpcResponse<GetTxOutSetInfoResult>> GetTxOutSetInfoAsync(string blockchainName, string id)
        {
            var response = await TransactAsync<RpcResponse<GetTxOutSetInfoResult>>(blockchainName, BlockchainAction.GetTxOutSetInfoMethod, id);

            return response;
        }

        public Task<RpcResponse<GetTxOutSetInfoResult>> GetTxOutSetInfoAsync()
        {
            return GetTxOutSetInfoAsync(BlockchainOptions.ChainName, UUID.NoHyphens);
        }


        public async Task<RpcResponse<ListAssetsResult[]>> ListAssetsAsync(string blockchainName, string id, object asset_identifiers, bool verbose, int count, int start)
        {
            var response = await TransactAsync<RpcResponse<ListAssetsResult[]>>(blockchainName, BlockchainAction.ListAssetsMethod, id, asset_identifiers, verbose, count, start);

            return response;
        }

        public Task<RpcResponse<ListAssetsResult[]>> ListAssetsAsync(object asset_identifiers, bool verbose, int count, int start)
        {
            return ListAssetsAsync(BlockchainOptions.ChainName, UUID.NoHyphens, asset_identifiers, verbose, count, start);
        }


        public async Task<RpcResponse<ListBlocksResult[]>> ListBlocksAsync(string blockchainName, string id, object block_set_identifier, bool verbose)
        {
            var response = await TransactAsync<RpcResponse<ListBlocksResult[]>>(blockchainName, BlockchainAction.ListBlocksMethod, id, block_set_identifier, verbose);

            return response;
        }

        public Task<RpcResponse<ListBlocksResult[]>> ListBlocksAsync(object block_set_identifier, bool verbose)
        {
            return ListBlocksAsync(BlockchainOptions.ChainName, UUID.NoHyphens, block_set_identifier, verbose);
        }


        public async Task<RpcResponse<ListPermissionsResult[]>> ListPermissionsAsync(string blockchainName, string id, string permissions, object addresses, bool verbose)
        {
            var response = await TransactAsync<RpcResponse<ListPermissionsResult[]>>(blockchainName, BlockchainAction.ListPermissionsMethod, id, permissions, addresses, verbose);

            return response;
        }

        public Task<RpcResponse<ListPermissionsResult[]>> ListPermissionsAsync(string permissions, object addresses, bool verbose)
        {
            return ListPermissionsAsync(BlockchainOptions.ChainName, UUID.NoHyphens, permissions, addresses, verbose);
        }


        public async Task<RpcResponse<ListStreamFiltersResult[]>> ListStreamFiltersAsync(string blockchainName, string id, object filter_identifers, bool verbose)
        {
            var response = await TransactAsync<RpcResponse<ListStreamFiltersResult[]>>(blockchainName, BlockchainAction.ListStreamFiltersMethod, id, filter_identifers, verbose);

            return response;
        }

        public Task<RpcResponse<ListStreamFiltersResult[]>> ListStreamFiltersAsync(object filter_identifers, bool verbose)
        {
            return ListStreamFiltersAsync(BlockchainOptions.ChainName, UUID.NoHyphens, filter_identifers, verbose);
        }


        public async Task<RpcResponse<ListStreamsResult[]>> ListStreamsAsync(string blockchainName, string id, object stream_identifiers, bool verbose, int count, int start)
        {
            var response = await TransactAsync<RpcResponse<ListStreamsResult[]>>(blockchainName, BlockchainAction.ListStreamsMethod, id, stream_identifiers, verbose, count, start);

            return response;
        }

        public Task<RpcResponse<ListStreamsResult[]>> ListStreamsAsync(object stream_identifiers, bool verbose, int count, int start)
        {
            return ListStreamsAsync(BlockchainOptions.ChainName, UUID.NoHyphens, stream_identifiers, verbose, count, start);
        }


        public async Task<RpcResponse<ListTxFiltersResult[]>> ListTxFiltersAsync(string blockchainName, string id, object filter_identifiers, bool verbose)
        {
            var response = await TransactAsync<RpcResponse<ListTxFiltersResult[]>>(blockchainName, BlockchainAction.ListTxFiltersMethod, id, filter_identifiers, verbose);

            return response;
        }

        public Task<RpcResponse<ListTxFiltersResult[]>> ListTxFiltersAsync(object filter_identifiers, bool verbose)
        {
            return ListTxFiltersAsync(BlockchainOptions.ChainName, UUID.NoHyphens, filter_identifiers, verbose);
        }


        public async Task<RpcResponse<object>> ListUpgradesAsync(string blockchainName, string id, object upgrade_identifiers)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, BlockchainAction.ListUpgradesMethod, id, upgrade_identifiers);

            return response;
        }

        public Task<RpcResponse<object>> ListUpgradesAsync(object upgrade_identifiers)
        {
            return ListUpgradesAsync(BlockchainOptions.ChainName, UUID.NoHyphens, upgrade_identifiers);
        }


        public async Task<RpcResponse<RunStreamFilterResult>> RunStreamFilterAsync(string blockchainName, string id, string filter_identifier, string tx_hex, int vout)
        {
            var response = await TransactAsync<RpcResponse<RunStreamFilterResult>>(blockchainName, BlockchainAction.RunStreamFilterMethod, id, filter_identifier, tx_hex, vout);

            return response;
        }

        public Task<RpcResponse<RunStreamFilterResult>> RunStreamFilterAsync(string filter_identifier, string tx_hex, int vout)
        {
            return RunStreamFilterAsync(BlockchainOptions.ChainName, UUID.NoHyphens, filter_identifier, tx_hex, vout);
        }


        public async Task<RpcResponse<RunTxFilterResult>> RunTxFilterAsync(string blockchainName, string id, string filter_identifier, string tx_hex)
        {
            var response = await TransactAsync<RpcResponse<RunTxFilterResult>>(blockchainName, BlockchainAction.RunTxFilterMethod, id, filter_identifier, tx_hex);

            return response;
        }

        public Task<RpcResponse<RunTxFilterResult>> RunTxFilterAsync(string filter_identifier, string tx_hex)
        {
            return RunTxFilterAsync(BlockchainOptions.ChainName, UUID.NoHyphens, filter_identifier, tx_hex);
        }


        public async Task<RpcResponse<TestStreamFilterResult>> TestStreamFilterAsync(string blockchainName, string id, object restrictions, string javascript_code, string tx_hex, int vout)
        {
            var response = await TransactAsync<RpcResponse<TestStreamFilterResult>>(blockchainName, BlockchainAction.TestStreamFilterMethod, id, restrictions, javascript_code, tx_hex, vout);

            return response;
        }

        public Task<RpcResponse<TestStreamFilterResult>> TestStreamFilterAsync(object restrictions, string javascript_code, string tx_hex, int vout)
        {
            return TestStreamFilterAsync(BlockchainOptions.ChainName, UUID.NoHyphens, restrictions, javascript_code, tx_hex, vout);
        }


        public async Task<RpcResponse<TestTxFilterResult>> TestTxFilterAsync(string blockchainName, string id, object restrictions, string javascript_code, string tx_hex)
        {
            var response = await TransactAsync<RpcResponse<TestTxFilterResult>>(blockchainName, BlockchainAction.TestTxFilterMethod, id, restrictions, javascript_code, tx_hex);

            return response;
        }

        public Task<RpcResponse<TestTxFilterResult>> TestTxFilterAsync(object restrictions, string javascript_code, string tx_hex)
        {
            return TestTxFilterAsync(BlockchainOptions.ChainName, UUID.NoHyphens, restrictions, javascript_code, tx_hex);
        }


        public async Task<RpcResponse<bool>> VerifyChainAsync(string blockchainName, string id, int check_level, int num_blocks)
        {
            var response = await TransactAsync<RpcResponse<bool>>(blockchainName, BlockchainAction.VerifyChainMethod, id, check_level, num_blocks);

            return response;
        }

        public Task<RpcResponse<bool>> VerifyChainAsync(int check_level, int num_blocks)
        {
            return VerifyChainAsync(BlockchainOptions.ChainName, UUID.NoHyphens, check_level, num_blocks);
        }


        public async Task<RpcResponse<bool>> VerifyPermissionAsync(string blockchainName, string id, string address, string permission)
        {
            var response = await TransactAsync<RpcResponse<bool>>(blockchainName, BlockchainAction.VerifyPermissionMethod, id, address, permission);

            return response;
        }

        public Task<RpcResponse<bool>> VerifyPermissionAsync(string address, string permission)
        {
            return VerifyPermissionAsync(BlockchainOptions.ChainName, UUID.NoHyphens, address, permission);
        }
    }
}
