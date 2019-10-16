using MCWrapper.RPC.Connection;
using MCWrapper.RPC.Extensions;
using MCWrapper.RPC.Ledger.Actions;
using MCWrapper.RPC.Options;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Threading.Tasks;

namespace MCWrapper.RPC.Ledger.Clients.Mining
{
    /// <summary>
    /// 
    /// MutliChain methods implemented by the concrete MineRPCClient class:
    /// 
    /// getblocktemplate, getmininginfo, getnetworkhashps, 
    /// prioritisetransaction, submitblock
    /// 
    /// <para>Inherits from an RPCClient and implements the IMineRPC contract</para>
    /// 
    /// </summary>
    public class MiningRpcClient : RpcConnection
    {
        public MiningRpcClient(HttpClient client, IOptions<BlockchainProfileOptions> options) 
            : base(client, options) { }


        public async Task<RpcResponse<object>> GetBlockTemplateAsync(string blockchainName, string id, string json_request_object)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, MiningAction.GetBlockTemplateMethod, id, json_request_object);

            return response;
        }

        public Task<RpcResponse<object>> GetBlockTemplateAsync(string json_request_object)
        {
            return GetBlockTemplateAsync(BlockchainOptions.ChainName, UUID.NoHyphens, json_request_object);
        }


        public async Task<RpcResponse<object>> GetMiningInfoAsync(string blockchainName, string id)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, MiningAction.GetMiningInfoMethod, id);

            return response;
        }

        public Task<RpcResponse<object>> GetMiningInfoAsync()
        {
            return GetMiningInfoAsync(BlockchainOptions.ChainName, UUID.NoHyphens);
        }


        public async Task<RpcResponse<object>> GetNetworkHashPsAsync(string blockchainName, string id, int blocks, int height)
        {
            RpcResponse<object> response;
            if (blocks == 0 && height == 0)
                response = await TransactAsync<RpcResponse<object>>(blockchainName, MiningAction.GetNetworkHashPsMethod, id);
            else if (blocks != 0 && height == 0)
                response = await TransactAsync<RpcResponse<object>>(blockchainName, MiningAction.GetNetworkHashPsMethod, id, blocks);
            else
                response = await TransactAsync<RpcResponse<object>>(blockchainName, MiningAction.GetNetworkHashPsMethod, id, blocks, height);

            return response;
        }

        public Task<RpcResponse<object>> GetNetworkHashPsAsync(int blocks, int height)
        {
            return GetNetworkHashPsAsync(BlockchainOptions.ChainName, UUID.NoHyphens, blocks, height);
        }


        public async Task<RpcResponse<object>> PrioritiseTransactionAsync(string blockchainName, string id, string txid, double priority_delta, double fee_delta)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, MiningAction.PrioritiseTransactionMethod, id, txid, priority_delta, fee_delta);

            return response;
        }

        public Task<RpcResponse<object>> PrioritiseTransactionAsync(string txid, double priority_delta, double fee_delta)
        {
            return PrioritiseTransactionAsync(BlockchainOptions.ChainName, UUID.NoHyphens, txid, priority_delta, fee_delta);
        }


        public async Task<RpcResponse<object>> SubmitBlockAsync(string blockchainName, string id, object hex_data, string json_parameters_object = "")
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, MiningAction.SubmitBlockMethod, id, hex_data, json_parameters_object);

            return response;
        }

        public Task<RpcResponse<object>> SubmitBlockAsync(object hex_data, string json_parameters_object = "")
        {
            return SubmitBlockAsync(BlockchainOptions.ChainName, UUID.NoHyphens, hex_data, json_parameters_object);
        }
    }
}
