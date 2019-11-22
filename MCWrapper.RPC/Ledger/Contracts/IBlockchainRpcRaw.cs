using MCWrapper.Data.Models.Raw;
using MCWrapper.RPC.Connection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace MCWrapper.RPC.Ledger.Clients
{
    public interface IBlockchainRpcRaw : IRpcContract
    {
        Task<RpcResponse<object>> AppendRawChangeAsync(string tx_hex, string address, [Optional] double native_fee);
        Task<RpcResponse<object>> AppendRawChangeAsync(string blockchainName, string id, string tx_hex, string address, [Optional] double native_fee);
        Task<RpcResponse<object>> AppendRawDataAsync(string tx_hex, object data);
        Task<RpcResponse<object>> AppendRawDataAsync(string blockchainName, string id, string tx_hex, object data);
        Task<RpcResponse<object>> AppendRawTransactionAsync(string tx_hex, object[] transactions, object addresses, [Optional] object[] data, string action = "");
        Task<RpcResponse<object>> AppendRawTransactionAsync(string blockchainName, string id, string tx_hex, object[] transactions, object addresses, [Optional] object[] data, string action = "");
        Task<RpcResponse<object>> CreateRawTransactionAsync(object[] transactions, object assets, [Optional] object[] data, string action = "");
        Task<RpcResponse<object>> CreateRawTransactionAsync(string blockchainName, string id, object[] transactions, object assets, [Optional] object[] data, string action = "");
        Task<RpcResponse<DecodeRawTransactionResult>> DecodeRawTransactionAsync(string tx_hex);
        Task<RpcResponse<DecodeRawTransactionResult>> DecodeRawTransactionAsync(string blockchainName, string id, string tx_hex);
        Task<RpcResponse<object>> DecodeScriptAsync(string script_hex);
        Task<RpcResponse<object>> DecodeScriptAsync(string blockchainName, string id, string script_hex);
        Task<RpcResponse<object>> GetRawTransactionAsync(string txid, [Optional] object verbose);
        Task<RpcResponse<object>> GetRawTransactionAsync(string blockchainName, string id, string txid, [Optional] object verbose);
        Task<RpcResponse<object>> SendRawTransactionAsync(string tx_hex, bool allow_high_fees = false);
        Task<RpcResponse<object>> SendRawTransactionAsync(string blockchainName, string id, string tx_hex, bool allow_high_fees = false);
        Task<RpcResponse<SignRawTransactionResult>> SignRawTransactionAsync(string tx_hex, [Optional] object[] prevtxs, [Optional] object[] privatekeys, [Optional] string sighashtype);
        Task<RpcResponse<SignRawTransactionResult>> SignRawTransactionAsync(string blockchainName, string id, string tx_hex, [Optional] object[] prevtxs, [Optional] object[] privatekeys, [Optional] string sighashtype);
    }
}