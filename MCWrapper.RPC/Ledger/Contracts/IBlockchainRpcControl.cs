using MCWrapper.Data.Models.Control;
using MCWrapper.RPC.Connection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace MCWrapper.RPC.Ledger.Clients
{
    public interface IBlockchainRpcControl : IRpcContract
    {
        Task<RpcResponse<string>> ClearMemPoolAsync();
        Task<RpcResponse<string>> ClearMemPoolAsync(string blockchainName, string id);
        Task<RpcResponse<GetBlockchainParamsResult>> GetBlockchainParamsAsync(bool display_names = false, bool with_upgrades = false);
        Task<RpcResponse<GetBlockchainParamsResult>> GetBlockchainParamsAsync(string blockchainName, string id, bool display_names = false, bool with_upgrades = false);
        Task<RpcResponse<GetInfoResult>> GetInfoAsync();
        Task<RpcResponse<GetInfoResult>> GetInfoAsync(string blockchainName, string id);
        Task<RpcResponse<GetRuntimeParamsResult>> GetRuntimeParamsAsync();
        Task<RpcResponse<GetRuntimeParamsResult>> GetRuntimeParamsAsync(string blockchainName, string id);
        Task<RpcResponse<object>> HelpAsync(string command = "getinfo");
        Task<RpcResponse<object>> HelpAsync(string blockchainName, string id, string command = "getinfo");
        Task<RpcResponse<object>> PauseAsync(string tasks = "incoming,mining");
        Task<RpcResponse<object>> PauseAsync(string blockchainName, string id, string tasks = "incoming,mining");
        Task<RpcResponse<object>> ResumeAsync(string tasks = "incoming,mining");
        Task<RpcResponse<object>> ResumeAsync(string blockchainName, string id, string tasks = "incoming,mining");
        Task<RpcResponse<object>> SetLastBlockAsync([Optional] object hash_or_height);
        Task<RpcResponse<object>> SetLastBlockAsync(string blockchainName, string id, [Optional] object hash_or_height);
        Task<RpcResponse<object>> SetRuntimeParamAsync(string runtimeParam, object parameter_value);
        Task<RpcResponse<object>> SetRuntimeParamAsync(string blockchainName, string id, string runtimeParam, object parameter_value);
        Task<RpcResponse<string>> StopAsync();
        Task<RpcResponse<string>> StopAsync(string blockchainName, string id);
    }
}