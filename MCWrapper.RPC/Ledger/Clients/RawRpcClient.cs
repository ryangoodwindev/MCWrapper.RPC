using MCWrapper.RPC.Connection;
using MCWrapper.RPC.Extensions;
using MCWrapper.RPC.Ledger.Actions;
using MCWrapper.RPC.Ledger.Models.Raw;
using MCWrapper.RPC.Options;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace MCWrapper.RPC.Ledger.Clients.Raw
{
    /// <summary>
    /// 
    /// MutliChain methods implemented by the concrete RawRPCClient class:
    /// 
    /// appendrawchange, appendrawdata, appendrawtransaction, 
    /// createrawtransaction, decoderawtransaction, decodescript, 
    /// getrawtransaction, sendrawtransaction, signrawtransaction
    /// 
    /// <para>Inherits from an RPCClient and implements the IRawRPC contract</para>
    /// 
    /// </summary>
    public class RawRpcClient : RpcConnection
    {
        public RawRpcClient(HttpClient client, IOptions<BlockchainProfileOptions> options) 
            : base(client, options) { }


        public async Task<RpcResponse<object>> AppendRawChangeAsync(string blockchainName, string id, string tx_hex, string address, double native_fee)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, RawAction.AppendRawChangeMethod, id, tx_hex, address, native_fee);

            return response;
        }

        public Task<RpcResponse<object>> AppendRawChangeAsync(string tx_hex, string address, double native_fee)
        {
            return AppendRawChangeAsync(BlockchainOptions.ChainName, UUID.NoHyphens, tx_hex, address, native_fee);
        }


        public async Task<RpcResponse<object>> AppendRawDataAsync(string blockchainName, string id, string tx_hex, object data)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, RawAction.AppendRawDataMethod, id, tx_hex, data);

            return response;
        }

        public Task<RpcResponse<object>> AppendRawDataAsync(string tx_hex, object data)
        {
            return AppendRawDataAsync(BlockchainOptions.ChainName, UUID.NoHyphens, tx_hex, data);
        }


        public async Task<RpcResponse<object>> AppendRawTransactionAsync(string blockchainName, string id, string tx_hex, object[] transactions, object addresses, object[] data, string action)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, RawAction.AppendRawTransactionMethod, id, tx_hex, transactions, addresses, data, action);

            return response;
        }

        public Task<RpcResponse<object>> AppendRawTransactionAsync(string tx_hex, object[] transactions, object addresses, object[] data, string action)
        {
            return AppendRawTransactionAsync(BlockchainOptions.ChainName, UUID.NoHyphens, tx_hex, transactions, addresses, data, action);
        }


        public async Task<RpcResponse<object>> CreateRawTransactionAsync(string blockchainName, string id, object[] transactions, object assets, object[] data, string action)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, RawAction.CreateRawTransactionMethod, id, transactions, assets, data, action);

            return response;
        }

        public Task<RpcResponse<object>> CreateRawTransactionAsync(object[] transactions, object assets, object[] data, string action)
        {
            return CreateRawTransactionAsync(BlockchainOptions.ChainName, UUID.NoHyphens, transactions, assets, data, action);
        }


        public async Task<RpcResponse<DecodeRawTransactionResult>> DecodeRawTransactionAsync(string blockchainName, string id, string tx_hex)
        {
            var response = await TransactAsync<RpcResponse<DecodeRawTransactionResult>>(blockchainName, RawAction.DecodeRawTransactionMethod, id, tx_hex);

            return response;
        }

        public Task<RpcResponse<DecodeRawTransactionResult>> DecodeRawTransactionAsync(string tx_hex)
        {
            return DecodeRawTransactionAsync(BlockchainOptions.ChainName, UUID.NoHyphens, tx_hex);
        }


        public async Task<RpcResponse<object>> DecodeScriptAsync(string blockchainName, string id, string script_hex)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, RawAction.DecodeScriptMethod, id, script_hex);

            return response;
        }

        public Task<RpcResponse<object>> DecodeScriptAsync(string script_hex)
        {
            return DecodeScriptAsync(BlockchainOptions.ChainName, UUID.NoHyphens, script_hex);
        }


        public async Task<RpcResponse<object>> GetRawTransactionAsync(string blockchainName, string id, string txid, bool verbose)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, RawAction.GetRawTransactionMethod, id, txid, verbose);

            return response;
        }

        public Task<RpcResponse<object>> GetRawTransactionAsync(string txid, bool verbose)
        {
            return GetRawTransactionAsync(BlockchainOptions.ChainName, UUID.NoHyphens, txid, verbose);
        }


        public async Task<RpcResponse<object>> SendRawTransactionAsync(string blockchainName, string id, string tx_hex, bool allow_high_fees)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, RawAction.SendRawTransactionMethod, id, tx_hex, allow_high_fees);

            return response;
        }

        public Task<RpcResponse<object>> SendRawTransactionAsync(string tx_hex, bool allow_high_fees)
        {
            return SendRawTransactionAsync(BlockchainOptions.ChainName, UUID.NoHyphens, tx_hex, allow_high_fees);
        }


        public async Task<RpcResponse<SignRawTransactionResult>> SignRawTransactionAsync(string blockchainName, string id, string tx_hex, [Optional] object[] prevtxs, [Optional] object[] privatekeys, [Optional] string sighashtype)
        {
            var response = await TransactAsync<RpcResponse<SignRawTransactionResult>>(blockchainName, RawAction.SignRawTransactionMethod, id, tx_hex, prevtxs, privatekeys, sighashtype);

            return response;
        }

        public Task<RpcResponse<SignRawTransactionResult>> SignRawTransactionAsync(string tx_hex, [Optional] object[] prevtxs, [Optional] object[] privatekeys, [Optional] string sighashtype)
        {
            return SignRawTransactionAsync(BlockchainOptions.ChainName, UUID.NoHyphens, tx_hex, prevtxs, privatekeys, sighashtype);
        }
    }
}
