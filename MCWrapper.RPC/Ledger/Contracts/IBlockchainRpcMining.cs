using MCWrapper.RPC.Connection;
using System.Threading.Tasks;

namespace MCWrapper.RPC.Ledger.Clients
{
    public interface IBlockchainRpcMining : IRpcContract
    {
        Task<RpcResponse<object>> GetBlockTemplateAsync(string json_request_object);
        Task<RpcResponse<object>> GetBlockTemplateAsync(string blockchainName, string id, string json_request_object);
        Task<RpcResponse<object>> GetMiningInfoAsync();
        Task<RpcResponse<object>> GetMiningInfoAsync(string blockchainName, string id);
        Task<RpcResponse<object>> GetNetworkHashPsAsync(int blocks = 120, int height = -1);
        Task<RpcResponse<object>> GetNetworkHashPsAsync(string blockchainName, string id, int blocks = 120, int height = -1);
        Task<RpcResponse<object>> PrioritiseTransactionAsync(string txid, double priority_delta, double fee_delta);
        Task<RpcResponse<object>> PrioritiseTransactionAsync(string blockchainName, string id, string txid, double priority_delta, double fee_delta);
        Task<RpcResponse<object>> SubmitBlockAsync(object hex_data, string json_parameters_object = "");
        Task<RpcResponse<object>> SubmitBlockAsync(string blockchainName, string id, object hex_data, string json_parameters_object = "");
    }
}