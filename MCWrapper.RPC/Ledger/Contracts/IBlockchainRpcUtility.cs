using MCWrapper.Data.Models.Utility;
using MCWrapper.RPC.Connection;
using System.Threading.Tasks;

namespace MCWrapper.RPC.Ledger.Clients
{
    public interface IBlockchainRpcUtility : IRpcContract
    {
        Task<RpcResponse<int>> AppendBinaryCacheAsync(string identifier, string data_hex);
        Task<RpcResponse<int>> AppendBinaryCacheAsync(string blockchainName, string id, string identifier, string data_hex);
        Task<RpcResponse<string>> CreateBinaryCacheAsync();
        Task<RpcResponse<string>> CreateBinaryCacheAsync(string blockchainName, string id);
        Task<RpcResponse<CreateKeyPairsResult[]>> CreateKeyPairsAsync(int count = 1);
        Task<RpcResponse<CreateKeyPairsResult[]>> CreateKeyPairsAsync(string blockchainName, string id, int count = 1);
        Task<RpcResponse<CreateMultiSigResult>> CreateMultiSigAsync(int n_required, string[] keys);
        Task<RpcResponse<CreateMultiSigResult>> CreateMultiSigAsync(string blockchainName, string id, int n_required, string[] keys);
        Task<RpcResponse<object>> DeleteBinaryCacheAsync(string identifier);
        Task<RpcResponse<object>> DeleteBinaryCacheAsync(string blockchainName, string id, string identifier);
        Task<RpcResponse<object>> EstimateFeeAsync(int n_blocks);
        Task<RpcResponse<object>> EstimateFeeAsync(string blockchainName, string id, int n_blocks);
        Task<RpcResponse<object>> EstimatePriorityAsync(int n_blocks);
        Task<RpcResponse<object>> EstimatePriorityAsync(string blockchainName, string id, int n_blocks);
        Task<RpcResponse<ValidateAddressResult>> ValidateAddressAsync(string address_pubkey_privkey);
        Task<RpcResponse<ValidateAddressResult>> ValidateAddressAsync(string blockchainName, string id, string address_or_pubkey_or_privkey);
        Task<RpcResponse<bool>> VerifyMessageAsync(string address, string signature, string message);
        Task<RpcResponse<bool>> VerifyMessageAsync(string blockchainName, string id, string address, string signature, string message);
    }
}