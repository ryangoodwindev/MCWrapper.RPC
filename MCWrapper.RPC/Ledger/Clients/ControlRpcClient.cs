using MCWrapper.RPC.Connection;
using MCWrapper.RPC.Extensions;
using MCWrapper.RPC.Ledger.Actions;
using MCWrapper.RPC.Ledger.Models.Control;
using MCWrapper.RPC.Options;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Threading.Tasks;

namespace MCWrapper.RPC.Ledger.Clients.Control
{
    /// <summary>
    /// 
    /// MutliChain methods implemented by the concrete ControlRPCClient class:
    /// 
    /// clearmempool, getblockchainparams, getinfo, getruntimeparams,
    /// help, pause, resume, setlastblock, setruntimeparam, stop
    /// 
    /// <para>Inherits from an RPCClient and implements the IControlRPC contract</para>
    /// 
    /// </summary>
    public class ControlRpcClient : RpcConnection
    {
        public ControlRpcClient(HttpClient client, IOptions<BlockchainProfileOptions> options) 
            : base(client, options) { }

        public async Task<RpcResponse<string>> ClearMemPoolAsync(string blockchainName, string id)
        {
            var response = await TransactAsync<RpcResponse<string>>(blockchainName, ControlAction.ClearMemPoolMethod, id);

            return response;
        }

        public Task<RpcResponse<string>> ClearMemPoolAsync()
        {
            return ClearMemPoolAsync(BlockchainOptions.ChainName, UUID.NoHyphens);
        }


        public async Task<RpcResponse<GetBlockchainParamsResult>> GetBlockchainParamsAsync(string blockchainName, string id, bool display_names, bool with_upgrades)
        {
            var response = await TransactAsync<RpcResponse<GetBlockchainParamsResult>>(blockchainName, ControlAction.GetBlockchainParamsMethod, id, display_names, with_upgrades);

            return response;
        }

        public Task<RpcResponse<GetBlockchainParamsResult>> GetBlockchainParamsAsync(bool display_names, bool with_upgrades)
        {
            return GetBlockchainParamsAsync(BlockchainOptions.ChainName, UUID.NoHyphens, display_names, with_upgrades);
        }


        public async Task<RpcResponse<GetInfoResult>> GetInfoAsync(string blockchainName, string id)
        {
            var response = await TransactAsync<RpcResponse<GetInfoResult>>(blockchainName, ControlAction.GetInfoMethod, id);

            return response;
        }

        public Task<RpcResponse<GetInfoResult>> GetInfoAsync()
        {
            return GetInfoAsync(BlockchainOptions.ChainName, UUID.NoHyphens);
        }


        public async Task<RpcResponse<GetRuntimeParamsResult>> GetRuntimeParamsAsync(string blockchainName, string id)
        {
            var response = await TransactAsync<RpcResponse<GetRuntimeParamsResult>>(blockchainName, ControlAction.GetRuntimeParamsMethod, id);

            return response;
        }

        public Task<RpcResponse<GetRuntimeParamsResult>> GetRuntimeParamsAsync()
        {
            return GetRuntimeParamsAsync(BlockchainOptions.ChainName, UUID.NoHyphens);
        }


        public async Task<RpcResponse<object>> HelpAsync(string blockchainName, string id, string command)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, ControlAction.HelpMethod, id, command ?? string.Empty);

            return response;
        }

        public Task<RpcResponse<object>> HelpAsync(string command)
        {
            return HelpAsync(BlockchainOptions.ChainName, UUID.NoHyphens, command);
        }


        public async Task<RpcResponse<object>> PauseAsync(string blockchainName, string id, string tasks)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, ControlAction.PauseMethod, id, tasks);

            return response;
        }

        public Task<RpcResponse<object>> PauseAsync(string tasks)
        {
            return PauseAsync(BlockchainOptions.ChainName, UUID.NoHyphens, tasks);
        }


        public async Task<RpcResponse<object>> ResumeAsync(string blockchainName, string id, string tasks)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, ControlAction.ResumeMethod, id, tasks);

            return response;
        }

        public Task<RpcResponse<object>> ResumeAsync(string tasks)
        {
            return ResumeAsync(BlockchainOptions.ChainName, UUID.NoHyphens, tasks);
        }


        public async Task<RpcResponse<object>> SetLastBlockAsync(string blockchainName, string id, object hash_or_height)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, ControlAction.SetLastBlockMethod, id, hash_or_height);

            return response;
        }

        public Task<RpcResponse<object>> SetLastBlockAsync(object hash_or_height)
        {
            return SetLastBlockAsync(BlockchainOptions.ChainName, UUID.NoHyphens, hash_or_height);
        }


        public async Task<RpcResponse<object>> SetRuntimeParamAsync(string blockchainName, string id, string runtimeParam, object parameter_value)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, ControlAction.SetRuntimeParamMethod, id, runtimeParam, parameter_value);

            return response;
        }

        public Task<RpcResponse<object>> SetRuntimeParamAsync(string runtimeParam, object parameter_value)
        {
            return SetRuntimeParamAsync(BlockchainOptions.ChainName, UUID.NoHyphens, runtimeParam, parameter_value);
        }


        public async Task<RpcResponse<string>> StopAsync(string blockchainName, string id)
        {
            var response = await TransactAsync<RpcResponse<string>>(blockchainName, ControlAction.StopMethod, id);

            return response;
        }

        public Task<RpcResponse<string>> StopAsync()
        {
            return StopAsync(BlockchainOptions.ChainName, UUID.NoHyphens);
        }
    }
}
