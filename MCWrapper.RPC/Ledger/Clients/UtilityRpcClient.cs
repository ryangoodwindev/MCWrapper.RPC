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
        /// <summary>
        /// Create a new Utility RPC client
        /// </summary>
        /// <param name="client"></param>
        /// <param name="options"></param>
        public UtilityRpcClient(HttpClient client, IOptions<BlockchainProfileOptions> options) 
            : base(client, options) { }


        /// <summary>
        /// 
        /// <para>Appends data to binary cache.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        /// 
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="identifier">Binary cache item identifier</param>
        /// <param name="data_hex">The hex string to be added to binary cache item</param>
        /// <returns></returns>
        public async Task<RpcResponse<int>> AppendBinaryCacheAsync(string blockchainName, string id, string identifier, string data_hex)
        {
            var response = await TransactAsync<RpcResponse<int>>(blockchainName, UtilityAction.AppendBinaryCacheMethod, id, identifier, data_hex);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Appends data to binary cache.</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        /// 
        /// </summary>
        /// <param name="identifier">Binary cache item identifier</param>
        /// <param name="data_hex">The hex string to be added to binary cache item</param>
        public Task<RpcResponse<int>> AppendBinaryCacheAsync(string identifier, string data_hex)
        {
            return AppendBinaryCacheAsync(BlockchainOptions.ChainName, UUID.NoHyphens, identifier, data_hex);
        }


        /// <summary>
        /// 
        /// <para>Returns random string, which can be used as binary cache item identifier</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        /// 
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <returns></returns>
        public async Task<RpcResponse<string>> CreateBinaryCacheAsync(string blockchainName, string id)
        {
            var response = await TransactAsync<RpcResponse<string>>(blockchainName, UtilityAction.CreateBinaryCacheMethod, id);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Returns random string, which can be used as binary cache item identifier</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<RpcResponse<string>> CreateBinaryCacheAsync()
        {
            return CreateBinaryCacheAsync(BlockchainOptions.ChainName, UUID.NoHyphens);
        }


        /// <summary>
        /// 
        /// <para>Creates public/private key pairs. These key pairs are not stored in the wallet.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        /// 
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="count">Number of key pairs to generate</param>
        /// <returns></returns>
        public async Task<RpcResponse<CreateKeyPairsResult[]>> CreateKeyPairsAsync(string blockchainName, string id, int count)
        {
            var response = await TransactAsync<RpcResponse<CreateKeyPairsResult[]>>(blockchainName, UtilityAction.CreateKeyPairsMethod, id, count);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Creates public/private key pairs. These key pairs are not stored in the wallet.</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        /// 
        /// </summary>
        /// <param name="count">Number of key pairs to generate</param>
        /// <returns></returns>
        public Task<RpcResponse<CreateKeyPairsResult[]>> CreateKeyPairsAsync(int count)
        {
            return CreateKeyPairsAsync(BlockchainOptions.ChainName, UUID.NoHyphens, count);
        }


        /// <summary>
        /// 
        /// <para>Creates a multi-signature address with n signature of m keys required.</para>
        /// <para>It returns a json object with the address and redeemScript.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="n_required">The number of required signatures out of the n keys or addresses</param>
        /// <param name="keys">A json array of keys which are addresses or hex-encoded public keys</param>
        /// <returns></returns>
        public async Task<RpcResponse<CreateMultiSigResult>> CreateMultiSigAsync(string blockchainName, string id, int n_required, string[] keys)
        {
            var response = await TransactAsync<RpcResponse<CreateMultiSigResult>>(blockchainName, UtilityAction.CreateMultiSigMethod, id, n_required, keys);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Creates a multi-signature address with n signature of m keys required.</para>
        /// <para>It returns a json object with the address and redeemScript.</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        ///
        /// </summary>
        /// <param name="n_required">The number of required signatures out of the n keys or addresses</param>
        /// <param name="keys">A json array of keys which are addresses or hex-encoded public keys</param>
        /// <returns></returns>
        public Task<RpcResponse<CreateMultiSigResult>> CreateMultiSigAsync(int n_required, string[] keys)
        {
            return CreateMultiSigAsync(BlockchainOptions.ChainName, UUID.NoHyphens, n_required, keys);
        }


        /// <summary>
        /// 
        /// <para>Clear binary cache item</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="identifier">Binary cache item identifier, "*" - to clear all items</param>
        /// <returns></returns>
        public async Task<RpcResponse<object>> DeleteBinaryCacheAsync(string blockchainName, string id, string identifier)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, UtilityAction.DeleteBinaryCacheMethod, id, identifier);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Clear binary cache item</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        ///
        /// </summary>
        /// <param name="identifier">Binary cache item identifier, "*" - to clear all items</param>
        /// <returns></returns>
        public Task<RpcResponse<object>> DeleteBinaryCacheAsync(string identifier)
        {
            return DeleteBinaryCacheAsync(BlockchainOptions.ChainName, UUID.NoHyphens, identifier);
        }


        /// <summary>
        /// 
        /// <para>Estimates the approximate fee per kilobyte needed for a transaction to begin confirmation within nblocks blocks.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        /// 
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="n_blocks">Number of blocks to estimate fee for</param>
        /// <returns></returns>
        public async Task<RpcResponse<object>> EstimateFeeAsync(string blockchainName, string id, int n_blocks)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, UtilityAction.EstimateFeeMethod, id, n_blocks);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Estimates the approximate fee per kilobyte needed for a transaction to begin confirmation within nblocks blocks.</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        /// 
        /// </summary>
        /// <param name="n_blocks">Number of blocks to estimate fee for</param>
        /// <returns></returns>
        public Task<RpcResponse<object>> EstimateFeeAsync(int n_blocks)
        {
            return EstimateFeeAsync(BlockchainOptions.ChainName, UUID.NoHyphens, n_blocks);
        }


        /// <summary>
        /// 
        /// <para>Estimates the approximate priority  a zero-fee transaction needs to begin confirmation within nblocks blocks.</para>
        /// <para>-1.0 is returned if not enough transactions and blocks have been observed to make an estimate.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        /// 
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="n_blocks">Number of blocks to estimate priority for</param>
        /// <returns></returns>
        public async Task<RpcResponse<object>> EstimatePriorityAsync(string blockchainName, string id, int n_blocks)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, UtilityAction.EstimatePriorityMethod, id, n_blocks);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Estimates the approximate priority  a zero-fee transaction needs to begin confirmation within nblocks blocks.</para>
        /// <para>-1.0 is returned if not enough transactions and blocks have been observed to make an estimate.</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        /// 
        /// </summary>
        /// <param name="n_blocks">Number of blocks to estimate priority for</param>
        /// <returns></returns>
        public Task<RpcResponse<object>> EstimatePriorityAsync(int n_blocks)
        {
            return EstimatePriorityAsync(BlockchainOptions.ChainName, UUID.NoHyphens, n_blocks);
        }


        /// <summary>
        /// 
        /// <para>Return information about the given address or public key or private key.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="address_pubkey_privkey">
        ///     <para>1. "address" (string, required) The address to validate</para>
        ///     <para>or</para>
        ///     <para>1. "pubkey" (string, required) The public key (hexadecimal) to validate</para>
        ///     <para>or</para>
        ///     <para>1. "privkey" (string, required) The private key (see dumpprivkey) to validate</para>
        /// </param>
        /// <returns></returns>
        public async Task<RpcResponse<ValidateAddressResult>> ValidateAddressAsync(string blockchainName, string id, string address_or_pubkey_or_privkey)
        {
            var response = await TransactAsync<RpcResponse<ValidateAddressResult>>(blockchainName, UtilityAction.ValidateAddressMethod, id, address_or_pubkey_or_privkey);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Return information about the given address or public key or private key.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        /// 
        /// </summary>
        /// <param name="address_pubkey_privkey">
        ///     <para>1. "address" (string, required) The address to validate</para>
        ///     <para>or</para>
        ///     <para>1. "pubkey" (string, required) The public key (hexadecimal) to validate</para>
        ///     <para>or</para>
        ///     <para>1. "privkey" (string, required) The private key (see dumpprivkey) to validate</para>
        /// </param>
        /// <returns></returns>
        public Task<RpcResponse<ValidateAddressResult>> ValidateAddressAsync(string address_pubkey_privkey)
        {
            return ValidateAddressAsync(BlockchainOptions.ChainName, UUID.NoHyphens, address_pubkey_privkey);
        }


        /// <summary>
        /// 
        /// <para>Verify a signed message</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        /// 
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="address">The address to use for the signature</param>
        /// <param name="signature">The signature provided by the signer in base 64 encoding (see signmessage)</param>
        /// <param name="message">The message that was signed</param>
        /// <returns></returns>
        public async Task<RpcResponse<bool>> VerifyMessageAsync(string blockchainName, string id, string address, string signature, string message)
        {
            var response = await TransactAsync<RpcResponse<bool>>(blockchainName, UtilityAction.VerifyMessageMethod, id, address, signature, message);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Verify a signed message</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        /// 
        /// </summary>
        /// <param name="address">The address to use for the signature</param>
        /// <param name="signature">The signature provided by the signer in base 64 encoding (see signmessage)</param>
        /// <param name="message">The message that was signed</param>
        /// <returns></returns>
        public Task<RpcResponse<bool>> VerifyMessageAsync(string address, string signature, string message)
        {
            return VerifyMessageAsync(BlockchainOptions.ChainName, UUID.NoHyphens, address, signature, message);
        }
    }
}