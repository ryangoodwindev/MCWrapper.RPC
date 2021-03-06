﻿using MCWrapper.RPC.Connection;
using MCWrapper.RPC.Options;
using Microsoft.Extensions.Options;
using Myndblock.MultiChain.Actions;
using Myndblock.MultiChain.Entities.Extensions;
using Myndblock.MultiChain.Models.Raw;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace MCWrapper.RPC.Ledger.Clients
{
    /// <summary>
    /// 
    /// <para>MutliChain Core methods implemented by the MultiChainRpcRawClient concrete class</para>
    ///
    /// appendrawchange, appendrawdata, appendrawtransaction,
    /// createrawtransaction, decoderawtransaction, decodescript,
    /// getrawtransaction, sendrawtransaction, signrawtransaction
    /// 
    /// </summary>
    public class MultiChainRpcRawClient : MultiChainRpcClient, IMultiChainRpcRaw
    {
        /// <summary>
        /// Create a new MultiChainRpcRawClient instance
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="options"></param>
        public MultiChainRpcRawClient(HttpClient httpClient, IOptions<RpcOptions> options)
            : base(httpClient, options) { }

        /// <summary>
        ///
        /// <para>Appends change output to raw transaction, containing any remaining assets / native currency in the inputs that are not already sent to other outputs.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="tx_hex">The hex string of the raw transaction)</param>
        /// <param name="address">The address to send the change to</param>
        /// <param name="native_fee">Native currency value deducted from that amount so it becomes a transaction fee. Default - calculated automatically</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> AppendRawChangeAsync(string blockchainName, string id, string tx_hex, string address, [Optional] double native_fee) =>
            TransactAsync<string>(blockchainName, RawAction.AppendRawChangeMethod, id, tx_hex, address, native_fee);

        /// <summary>
        ///
        /// <para>Appends change output to raw transaction, containing any remaining assets / native currency in the inputs that are not already sent to other outputs.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="tx_hex">The hex string of the raw transaction)</param>
        /// <param name="address">The address to send the change to</param>
        /// <param name="native_fee">Native currency value deducted from that amount so it becomes a transaction fee. Default - calculated automatically</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> AppendRawChangeAsync(string tx_hex, string address, [Optional] double native_fee) =>
            AppendRawChangeAsync(RpcOptions.ChainName, UUID.NoHyphens, tx_hex, address, native_fee);

        /// <summary>
        ///
        /// <para>Appends new OP_RETURN output to existing raw transaction</para>
        /// <para>Returns hex-encoded raw transaction.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="tx_hex">(string, required) The transaction hex string</param>
        /// <param name="data">(string or object, required) Data, see help data-all for details</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> AppendRawDataAsync(string blockchainName, string id, string tx_hex, object data) =>
            TransactAsync<string>(blockchainName, RawAction.AppendRawDataMethod, id, tx_hex, data);

        /// <summary>
        ///
        /// <para>Appends new OP_RETURN output to existing raw transaction</para>
        /// <para>Returns hex-encoded raw transaction.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="tx_hex">(string, required) The transaction hex string</param>
        /// <param name="data">(string or object, required) Data, see help data-all for details</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> AppendRawDataAsync(string tx_hex, object data) =>
            AppendRawDataAsync(RpcOptions.ChainName, UUID.NoHyphens, tx_hex, data);

        /// <summary>
        ///
        /// <para>Append inputs and outputs to raw transaction</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="tx_hex">Source transaction hex string</param>
        /// <param name="transactions">A json array of json objects</param>
        /// <param name="addresses">Object with addresses as keys, see help addresses-all for details</param>
        /// <param name="data">Array of hexadecimal strings or data objects, see help data-all for details</param>
        /// <param name="action">Additional actions: "lock", "sign", "lock,sign", "sign,lock", "send"</param>
        /// <returns></returns>
        public Task<RpcResponse> AppendRawTransactionAsync(string blockchainName, string id, string tx_hex, object[] transactions, object addresses, [Optional] object[] data, string action = "") =>
            TransactAsync(blockchainName, RawAction.AppendRawTransactionMethod, id, tx_hex, transactions, addresses, data, action);

        /// <summary>
        ///
        /// <para>Append inputs and outputs to raw transaction</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="tx_hex">Source transaction hex string</param>
        /// <param name="transactions">A json array of json objects</param>
        /// <param name="addresses">Object with addresses as keys, see help addresses-all for details</param>
        /// <param name="data">Array of hexadecimal strings or data objects, see help data-all for details</param>
        /// <param name="action">Additional actions: "lock", "sign", "lock,sign", "sign,lock", "send"</param>
        public Task<RpcResponse> AppendRawTransactionAsync(string tx_hex, object[] transactions, object addresses, [Optional] object[] data, string action = "") =>
            AppendRawTransactionAsync(RpcOptions.ChainName, UUID.NoHyphens, tx_hex, transactions, addresses, data, action);

        /// <summary>
        ///
        /// <para>Create a transaction spending the given inputs.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="transactions">A json array of json objects</param>
        /// <param name="assets">Object with addresses as keys, see help addresses-all for details</param>
        /// <param name="data">Array of hexadecimal strings or data objects, see help data-all for details</param>
        /// <param name="action">Additional actions: "lock", "sign", "lock,sign", "sign,lock", "send"</param>
        /// <returns></returns>
        public Task<RpcResponse> CreateRawTransactionAsync(string blockchainName, string id, object[] transactions, object assets, [Optional] object[] data, string action = "") =>
            TransactAsync(blockchainName, RawAction.CreateRawTransactionMethod, id, transactions, assets, data, action);

        /// <summary>
        ///
        /// <para>Create a transaction spending the given inputs.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="transactions">A json array of json objects</param>
        /// <param name="assets">Object with addresses as keys, see help addresses-all for details</param>
        /// <param name="data">Array of hexadecimal strings or data objects, see help data-all for details</param>
        /// <param name="action">Additional actions: "lock", "sign", "lock,sign", "sign,lock", "send"</param>
        public Task<RpcResponse> CreateRawTransactionAsync(object[] transactions, object assets, [Optional] object[] data, string action = "") =>
            CreateRawTransactionAsync(RpcOptions.ChainName, UUID.NoHyphens, transactions, assets, data, action);

        /// <summary>
        /// Return a JSON object representing the serialized, hex-encoded transaction.
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="tx_hex">The transaction hex string</param>
        /// <returns></returns>
        public Task<RpcResponse<DecodeRawTransactionResult>> DecodeRawTransactionAsync(string blockchainName, string id, string tx_hex) =>
            TransactAsync<DecodeRawTransactionResult>(blockchainName, RawAction.DecodeRawTransactionMethod, id, tx_hex);

        /// <summary>
        ///
        /// <para>Return a JSON object representing the serialized, hex-encoded transaction.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="tx_hex">The transaction hex string</param>
        /// <returns></returns>
        public Task<RpcResponse<DecodeRawTransactionResult>> DecodeRawTransactionAsync(string tx_hex) =>
            DecodeRawTransactionAsync(RpcOptions.ChainName, UUID.NoHyphens, tx_hex);

        /// <summary>
        ///
        /// <para>Decode a hex-encoded script.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="script_hex">The hex encoded script</param>
        /// <returns></returns>
        public Task<RpcResponse<DecodeScriptResult>> DecodeScriptAsync(string blockchainName, string id, string script_hex) =>
            TransactAsync<DecodeScriptResult>(blockchainName, RawAction.DecodeScriptMethod, id, script_hex);

        /// <summary>
        ///
        /// <para>Decode a hex-encoded script.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="script_hex">The hex encoded script</param>
        /// <returns></returns>
        public Task<RpcResponse<DecodeScriptResult>> DecodeScriptAsync(string script_hex) =>
            DecodeScriptAsync(RpcOptions.ChainName, UUID.NoHyphens, script_hex);

        /// <summary>
        ///
        /// <para>
        ///     NOTE: By default this function only works sometimes. This is when the tx is in the mempool or there is an unspent
        ///     output in the utxo for this transaction. To make it always work, you need to maintain a transaction index, using the -txindex command line option.
        /// </para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="txid">(string, required) The transaction id</param>
        /// <param name="verbose">(numeric or boolean, optional, default=0(false)) If 0, return a string, other return a json object</param>
        /// <returns></returns>
        public Task<RpcResponse> GetRawTransactionAsync(string blockchainName, string id, string txid, [Optional] object verbose) =>
            TransactAsync(blockchainName, RawAction.GetRawTransactionMethod, id, txid, verbose);

        /// <summary>
        ///
        /// <para>
        ///     NOTE: By default this function only works sometimes. This is when the tx is in the mempool or there is an unspent
        ///     output in the utxo for this transaction. To make it always work, you need to maintain a transaction index, using the -txindex command line option.
        /// </para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="txid">(string, required) The transaction id</param>
        /// <param name="verbose">(numeric or boolean, optional, default=0(false)) If 0, return a string, other return a json object</param>
        /// <returns></returns>
        public Task<RpcResponse> GetRawTransactionAsync(string txid, [Optional] object verbose) =>
            GetRawTransactionAsync(RpcOptions.ChainName, UUID.NoHyphens, txid, verbose);

        /// <summary>
        ///
        /// <para>Submits raw transaction (serialized, hex-encoded) to local node and network.</para>
        /// <para>Also see createrawtransaction and signrawtransaction calls.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="tx_hex">The hex string of the raw transaction)</param>
        /// <param name="allow_high_fees">Allow high fees</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> SendRawTransactionAsync(string blockchainName, string id, string tx_hex, bool allow_high_fees = false) =>
            TransactAsync<string>(blockchainName, RawAction.SendRawTransactionMethod, id, tx_hex, allow_high_fees);

        /// <summary>
        ///
        /// <para>Submits raw transaction (serialized, hex-encoded) to local node and network.</para>
        /// <para>Also see createrawtransaction and signrawtransaction calls.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="tx_hex">The hex string of the raw transaction)</param>
        /// <param name="allow_high_fees">Allow high fees</param>
        public Task<RpcResponse<string>> SendRawTransactionAsync(string tx_hex, bool allow_high_fees = false) =>
            SendRawTransactionAsync(RpcOptions.ChainName, UUID.NoHyphens, tx_hex, allow_high_fees);

        /// <summary>
        ///
        /// <para>Sign inputs for raw transaction (serialized, hex-encoded).</para>
        /// <para>
        ///     The second optional argument (may be null) is an array of previous transaction outputs that
        ///     this transaction depends on but may not yet be in the block chain.
        /// </para>
        ///
        /// <para>
        ///      The third optional argument (may be null) is an array of base58-encoded private
        ///     keys that, if given, will be the only keys used to sign the transaction.
        /// </para>
        ///
        /// <para>Requires wallet passphrase to be set with walletpassphrase call.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="tx_hex">The transaction hex string</param>
        /// <param name="prevtxs">An json array of previous dependent transaction outputs</param>
        /// <param name="privatekeys">A json array of base58-encoded private keys for signing</param>
        /// <param name="sighashtype">The signature hash type. Must be one of: "All", "NONE", "SINGLE", "ALL|ANYONECANPAY", "NONE|ANYONECANPAY", "SINGLE|ANYONECANPAY"</param>
        /// <returns></returns>
        public Task<RpcResponse<SignRawTransactionResult>> SignRawTransactionAsync(string blockchainName, string id, string tx_hex, [Optional] object[] prevtxs, [Optional] object[] privatekeys, [Optional] string sighashtype) =>
            TransactAsync<SignRawTransactionResult>(blockchainName, RawAction.SignRawTransactionMethod, id, tx_hex, prevtxs, privatekeys, sighashtype);

        /// <summary>
        ///
        /// <para>Sign inputs for raw transaction (serialized, hex-encoded).</para>
        /// <para>
        ///     The second optional argument (may be null) is an array of previous transaction outputs that
        ///     this transaction depends on but may not yet be in the block chain.
        /// </para>
        ///
        /// <para>
        ///      The third optional argument (may be null) is an array of base58-encoded private
        ///     keys that, if given, will be the only keys used to sign the transaction.
        /// </para>
        ///
        /// <para>Requires wallet passphrase to be set with walletpassphrase call.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="tx_hex">The transaction hex string</param>
        /// <param name="prevtxs">An json array of previous dependent transaction outputs</param>
        /// <param name="privatekeys">A json array of base58-encoded private keys for signing</param>
        /// <param name="sighashtype">The signature hash type. Must be one of: "All", "NONE", "SINGLE", "ALL|ANYONECANPAY", "NONE|ANYONECANPAY", "SINGLE|ANYONECANPAY"</param>
        /// <returns></returns>
        public Task<RpcResponse<SignRawTransactionResult>> SignRawTransactionAsync(string tx_hex, [Optional] object[] prevtxs, [Optional] object[] privatekeys, [Optional] string sighashtype) =>
            SignRawTransactionAsync(RpcOptions.ChainName, UUID.NoHyphens, tx_hex, prevtxs, privatekeys, sighashtype);
    }
}