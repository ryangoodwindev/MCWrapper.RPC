using MCWrapper.Data.Models.Blockchain;
using MCWrapper.RPC.Connection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace MCWrapper.RPC.Ledger.Clients
{
    public interface IBlockchainRpc : IRpcContract
    {
        Task<RpcResponse<GetAssetInfoResult>> GetAssetInfoAsync(string asset_identifier, bool verbose = false);
        Task<RpcResponse<GetAssetInfoResult>> GetAssetInfoAsync(string blockchainName, string id, string asset_identifier, bool verbose = false);
        Task<RpcResponse<string>> GetBestBlockHashAsync();
        Task<RpcResponse<string>> GetBestBlockHashAsync(string blockchainName, string id);
        Task<T> GetBlockAsync<T>(object hash_or_height, [Optional] object verbose);
        Task<T> GetBlockAsync<T>(string blockchainName, string id, object hash_or_height, [Optional] object verbose);
        Task<RpcResponse<GetBlockchainInfoResult>> GetBlockchainInfoAsync();
        Task<RpcResponse<GetBlockchainInfoResult>> GetBlockchainInfoAsync(string blockchainName, string id);
        Task<RpcResponse<long>> GetBlockCountAsync();
        Task<RpcResponse<long>> GetBlockCountAsync(string blockchainName, string id);
        Task<RpcResponse<string>> GetBlockHashAsync(int index);
        Task<RpcResponse<string>> GetBlockHashAsync(string blockchainName, string id, int index);
        Task<RpcResponse<GetChainTipsResult[]>> GetChainTipsAsync();
        Task<RpcResponse<GetChainTipsResult[]>> GetChainTipsAsync(string blockchainName, string id);
        Task<RpcResponse<double>> GetDifficultyAsync();
        Task<RpcResponse<double>> GetDifficultyAsync(string blockchainName, string id);
        Task<RpcResponse<string>> GetFilterCodeAsync(string filter_identifier);
        Task<RpcResponse<string>> GetFilterCodeAsync(string blockchainName, string id, string filter_identifier);
        Task<RpcResponse<GetLastBlockInfoResult>> GetLastBlockInfoAsync(int skip = 0);
        Task<RpcResponse<GetLastBlockInfoResult>> GetLastBlockInfoAsync(string blockchainName, string id, int skip = 0);
        Task<RpcResponse<GetMemPoolInfoResult>> GetMemPoolInfoAsync();
        Task<RpcResponse<GetMemPoolInfoResult>> GetMemPoolInfoAsync(string blockchainName, string id);
        Task<RpcResponse<GetRawMemPoolResult>> GetRawMemPoolAsync(bool verbose = false);
        Task<RpcResponse<GetRawMemPoolResult>> GetRawMemPoolAsync(string blockchainName, string id, bool verbose = false);
        Task<RpcResponse<GetStreamInfoResult>> GetStreamInfoAsync(string stream_identifier, bool verbose = false);
        Task<RpcResponse<GetStreamInfoResult>> GetStreamInfoAsync(string blockchainName, string id, string stream_identifier, bool verbose = false);
        Task<RpcResponse<GetTxOutResult>> GetTxOutAsync(string txid, int n, bool include_mem_pool = true);
        Task<RpcResponse<GetTxOutResult>> GetTxOutAsync(string blockchainName, string id, string txid, int n, bool include_mem_pool = true);
        Task<RpcResponse<GetTxOutSetInfoResult>> GetTxOutSetInfoAsync();
        Task<RpcResponse<GetTxOutSetInfoResult>> GetTxOutSetInfoAsync(string blockchainName, string id);
        Task<RpcResponse<ListAssetsResult[]>> ListAssetsAsync([Optional] object asset_identifiers, [Optional] bool verbose, [Optional] int count, [Optional] int start);
        Task<RpcResponse<ListAssetsResult[]>> ListAssetsAsync(string blockchainName, string id, [Optional] object asset_identifiers, [Optional] bool verbose, [Optional] int count, [Optional] int start);
        Task<RpcResponse<ListBlocksResult[]>> ListBlocksAsync(object block_set_identifier, bool verbose = false);
        Task<RpcResponse<ListBlocksResult[]>> ListBlocksAsync(string blockchainName, string id, object block_set_identifier, bool verbose = false);
        Task<RpcResponse<ListPermissionsResult[]>> ListPermissionsAsync([Optional] string permissions, [Optional] object addresses, [Optional] bool verbose);
        Task<RpcResponse<ListPermissionsResult[]>> ListPermissionsAsync(string blockchainName, string id, [Optional] string permissions, [Optional] object addresses, [Optional] bool verbose);
        Task<RpcResponse<ListStreamFiltersResult[]>> ListStreamFiltersAsync([Optional] object filter_identifers, [Optional] bool verbose);
        Task<RpcResponse<ListStreamFiltersResult[]>> ListStreamFiltersAsync(string blockchainName, string id, [Optional] object filter_identifers, [Optional] bool verbose);
        Task<RpcResponse<ListStreamsResult[]>> ListStreamsAsync([Optional] object stream_identifiers, [Optional] bool verbose, [Optional] int count, [Optional] int start);
        Task<RpcResponse<ListStreamsResult[]>> ListStreamsAsync(string blockchainName, string id, [Optional] object stream_identifiers, [Optional] bool verbose, [Optional] int count, [Optional] int start);
        Task<RpcResponse<ListTxFiltersResult[]>> ListTxFiltersAsync([Optional] object filter_identifiers, [Optional] bool verbose);
        Task<RpcResponse<ListTxFiltersResult[]>> ListTxFiltersAsync(string blockchainName, string id, [Optional] object filter_identifiers, [Optional] bool verbose);
        Task<RpcResponse<object>> ListUpgradesAsync([Optional] object upgrade_identifiers);
        Task<RpcResponse<object>> ListUpgradesAsync(string blockchainName, string id, [Optional] object upgrade_identifiers);
        Task<RpcResponse<RunStreamFilterResult>> RunStreamFilterAsync(string filter_identifier, [Optional] string tx_hex, [Optional] int vout);
        Task<RpcResponse<RunStreamFilterResult>> RunStreamFilterAsync(string blockchainName, string id, string filter_identifier, [Optional] string tx_hex, [Optional] int vout);
        Task<RpcResponse<RunTxFilterResult>> RunTxFilterAsync([Optional] string filter_identifier, [Optional] string tx_hex);
        Task<RpcResponse<RunTxFilterResult>> RunTxFilterAsync(string blockchainName, string id, [Optional] string filter_identifier, [Optional] string tx_hex);
        Task<RpcResponse<TestStreamFilterResult>> TestStreamFilterAsync(object restrictions, string javascript_code, [Optional] string tx_hex, [Optional] int vout);
        Task<RpcResponse<TestStreamFilterResult>> TestStreamFilterAsync(string blockchainName, string id, object restrictions, string javascript_code, [Optional] string tx_hex, [Optional] int vout);
        Task<RpcResponse<TestTxFilterResult>> TestTxFilterAsync(object restrictions, string javascript_code, [Optional] string tx_hex);
        Task<RpcResponse<TestTxFilterResult>> TestTxFilterAsync(string blockchainName, string id, object restrictions, string javascript_code, [Optional] string tx_hex);
        Task<RpcResponse<bool>> VerifyChainAsync([Optional] int check_level, [Optional] int num_blocks);
        Task<RpcResponse<bool>> VerifyChainAsync(string blockchainName, string id, [Optional] int check_level, [Optional] int num_blocks);
        Task<RpcResponse<bool>> VerifyPermissionAsync(string address, string permission);
        Task<RpcResponse<bool>> VerifyPermissionAsync(string blockchainName, string id, string address, string permission);
    }
}