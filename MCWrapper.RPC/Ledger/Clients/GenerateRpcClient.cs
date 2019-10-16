using MCWrapper.RPC.Connection;
using MCWrapper.RPC.Extensions;
using MCWrapper.RPC.Ledger.Actions;
using MCWrapper.RPC.Options;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Threading.Tasks;

namespace MCWrapper.RPC.Ledger.Clients.Generate
{
    /// <summary>
    /// 
    /// MutliChain methods implemented by the concrete GenerateRPCClient class:
    /// 
    /// getgenerate, gethashespersec, setgenerate
    /// 
    /// <para>Inherits from an RPCClient and implements the IGenerateRPC contract</para>
    /// 
    /// </summary>
    public class GenerateRpcClient : RpcConnection
    {
        public GenerateRpcClient(HttpClient client, IOptions<BlockchainProfileOptions> options) 
            : base(client, options) { }

        public async Task<RpcResponse<bool>> GetGenerateAsync(string blockchainName, string id)
        {
            var response = await TransactAsync<RpcResponse<bool>>(blockchainName, GenerateAction.GetGenerateMethod, id);

            return response;
        }

        public Task<RpcResponse<bool>> GetGenerateAsync()
        {
            return GetGenerateAsync(BlockchainOptions.ChainName, UUID.NoHyphens);
        }


        public async Task<RpcResponse<int>> GetHashesPerSecAsync(string blockchainName, string id)
        {
            var response = await TransactAsync<RpcResponse<int>>(blockchainName, GenerateAction.GetHashesPerSecMethod, id);

            return response;
        }

        public Task<RpcResponse<int>> GetHashesPerSecAsync()
        {
            return GetHashesPerSecAsync(BlockchainOptions.ChainName, UUID.NoHyphens);
        }


        public async Task<RpcResponse<object>> SetGenerateAsync(string blockchainName, string id, bool generate, int gen_proc_limit)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, GenerateAction.SetGenerateMethod, id, generate, gen_proc_limit);

            return response;
        }

        public Task<RpcResponse<object>> SetGenerateAsync(bool generate, int gen_proc_limit)
        {
            return SetGenerateAsync(BlockchainOptions.ChainName, UUID.NoHyphens, generate, gen_proc_limit);
        }
    }
}
