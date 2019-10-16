using MCWrapper.RPC.Connection;
using MCWrapper.RPC.Extensions;
using MCWrapper.RPC.Ledger.Actions;
using MCWrapper.RPC.Ledger.Models.Utility;
using MCWrapper.RPC.Options;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Threading.Tasks;

namespace MCWrapper.RPC.Ledger.Clients.Utility
{
    /// <summary>
    /// 
    /// MutliChain methods implemented by the concrete UtilityRPCClient class:
    /// 
    /// appendbinarycache, createbinarycache, createkeypairs, 
    /// createmultisig, deletebinarycache, estimatefee, estimatepriority,
    /// validateaddress, verifymessage
    /// 
    /// <para>Inherits from an RPCClient and implements the IUtilityRPC contract</para>
    /// 
    /// </summary>
    public class UtilityRpcClient : RpcConnection
    {
        public UtilityRpcClient(HttpClient client, IOptions<BlockchainProfileOptions> options) 
            : base(client, options) { }


        public async Task<RpcResponse<int>> AppendBinaryCacheAsync(string blockchainName, string id, string identifier, string data_hex)
        {
            var response = await TransactAsync<RpcResponse<int>>(blockchainName, UtilityAction.AppendBinaryCacheMethod, id, identifier, data_hex);

            return response;
        }

        public Task<RpcResponse<int>> AppendBinaryCacheAsync(string identifier, string data_hex)
        {
            return AppendBinaryCacheAsync(BlockchainOptions.ChainName, UUID.NoHyphens, identifier, data_hex);
        }


        public async Task<RpcResponse<string>> CreateBinaryCacheAsync(string blockchainName, string id)
        {
            var response = await TransactAsync<RpcResponse<string>>(blockchainName, UtilityAction.CreateBinaryCacheMethod, id);

            return response;
        }

        public Task<RpcResponse<string>> CreateBinaryCacheAsync()
        {
            return CreateBinaryCacheAsync(BlockchainOptions.ChainName, UUID.NoHyphens);
        }


        public async Task<RpcResponse<CreateKeyPairsResult[]>> CreateKeyPairsAsync(string blockchainName, string id, int count)
        {
            var response = await TransactAsync<RpcResponse<CreateKeyPairsResult[]>>(blockchainName, UtilityAction.CreateKeyPairsMethod, id, count);

            return response;
        }

        public Task<RpcResponse<CreateKeyPairsResult[]>> CreateKeyPairsAsync(int count)
        {
            return CreateKeyPairsAsync(BlockchainOptions.ChainName, UUID.NoHyphens, count);
        }


        public async Task<RpcResponse<CreateMultiSigResult>> CreateMultiSigAsync(string blockchainName, string id, int n_required, string[] keys)
        {
            var response = await TransactAsync<RpcResponse<CreateMultiSigResult>>(blockchainName, UtilityAction.CreateMultiSigMethod, id, n_required, keys);

            return response;
        }

        public Task<RpcResponse<CreateMultiSigResult>> CreateMultiSigAsync(int n_required, string[] keys)
        {
            return CreateMultiSigAsync(BlockchainOptions.ChainName, UUID.NoHyphens, n_required, keys);
        }


        public async Task<RpcResponse<object>> DeleteBinaryCacheAsync(string blockchainName, string id, string identifier)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, UtilityAction.DeleteBinaryCacheMethod, id, identifier);

            return response;
        }

        public Task<RpcResponse<object>> DeleteBinaryCacheAsync(string identifier)
        {
            return DeleteBinaryCacheAsync(BlockchainOptions.ChainName, UUID.NoHyphens, identifier);
        }


        public async Task<RpcResponse<object>> EstimateFeeAsync(string blockchainName, string id, int n_blocks)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, UtilityAction.EstimateFeeMethod, id, n_blocks);

            return response;
        }

        public Task<RpcResponse<object>> EstimateFeeAsync(int n_blocks)
        {
            return EstimateFeeAsync(BlockchainOptions.ChainName, UUID.NoHyphens, n_blocks);
        }


        public async Task<RpcResponse<object>> EstimatePriorityAsync(string blockchainName, string id, int n_blocks)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, UtilityAction.EstimatePriorityMethod, id, n_blocks);

            return response;
        }

        public Task<RpcResponse<object>> EstimatePriorityAsync(int n_blocks)
        {
            return EstimatePriorityAsync(BlockchainOptions.ChainName, UUID.NoHyphens, n_blocks);
        }


        public async Task<RpcResponse<ValidateAddressResult>> ValidateAddressAsync(string blockchainName, string id, string address_or_pubkey_or_privkey)
        {
            var response = await TransactAsync<RpcResponse<ValidateAddressResult>>(blockchainName, UtilityAction.ValidateAddressMethod, id, address_or_pubkey_or_privkey);

            return response;
        }

        public Task<RpcResponse<ValidateAddressResult>> ValidateAddressAsync(string address_pubkey_privkey)
        {
            return ValidateAddressAsync(BlockchainOptions.ChainName, UUID.NoHyphens, address_pubkey_privkey);
        }


        public async Task<RpcResponse<bool>> VerifyMessageAsync(string blockchainName, string id, string address, string signature, string message)
        {
            var response = await TransactAsync<RpcResponse<bool>>(blockchainName, UtilityAction.VerifyMessageMethod, id, address, signature, message);

            return response;
        }

        public Task<RpcResponse<bool>> VerifyMessageAsync(string address, string signature, string message)
        {
            return VerifyMessageAsync(BlockchainOptions.ChainName, UUID.NoHyphens, address, signature, message);
        }
    }
}
