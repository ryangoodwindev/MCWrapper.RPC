using MCWrapper.RPC.Connection;
using System.Threading.Tasks;

namespace MCWrapper.RPC.Ledger.Clients
{
    public interface IBlockchainRpcGenerate : IRpcContract
    {
        Task<RpcResponse<bool>> GetGenerateAsync();
        Task<RpcResponse<bool>> GetGenerateAsync(string blockchainName, string id);
        Task<RpcResponse<int>> GetHashesPerSecAsync();
        Task<RpcResponse<int>> GetHashesPerSecAsync(string blockchainName, string id);
        Task<RpcResponse<object>> SetGenerateAsync(bool generate, int gen_proc_limit);
        Task<RpcResponse<object>> SetGenerateAsync(string blockchainName, string id, bool generate, int gen_proc_limit);
    }
}