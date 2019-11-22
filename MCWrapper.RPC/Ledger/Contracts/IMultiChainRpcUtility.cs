using MCWrapper.Data.Models.Utility;
using MCWrapper.RPC.Connection;
using System.Threading.Tasks;

namespace MCWrapper.RPC.Ledger.Clients
{
    /// <summary>
    /// 
    /// MutliChain methods required by the IMultiChainRpcUtility contract:
    ///
    /// appendbinarycache, createbinarycache, createkeypairs,
    /// createmultisig, deletebinarycache, estimatefee, estimatepriority,
    /// validateaddress, verifymessage
    /// 
    /// </summary>
    public interface IMultiChainRpcUtility : IRpcContract
    {
        /// <summary>
        ///
        /// <para>Appends data to binary cache.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="identifier">Binary cache item identifier</param>
        /// <param name="data_hex">The hex string to be added to binary cache item</param>
        Task<RpcResponse<int>> AppendBinaryCacheAsync(string identifier, string data_hex);

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
        Task<RpcResponse<int>> AppendBinaryCacheAsync(string blockchainName, string id, string identifier, string data_hex);

        /// <summary>
        ///
        /// <para>Returns random string, which can be used as binary cache item identifier</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <returns></returns>
        Task<RpcResponse<string>> CreateBinaryCacheAsync();

        /// <summary>
        ///
        /// <para>Returns random string, which can be used as binary cache item identifier</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <returns></returns>
        Task<RpcResponse<string>> CreateBinaryCacheAsync(string blockchainName, string id);

        /// <summary>
        ///
        /// <para>Creates public/private key pairs. These key pairs are not stored in the wallet.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="count">Number of key pairs to generate</param>
        /// <returns></returns>
        Task<RpcResponse<CreateKeyPairsResult[]>> CreateKeyPairsAsync(int count = 1);

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
        Task<RpcResponse<CreateKeyPairsResult[]>> CreateKeyPairsAsync(string blockchainName, string id, int count = 1);

        /// <summary>
        ///
        /// <para>Creates a multi-signature address with n signature of m keys required.</para>
        /// <para>It returns a json object with the address and redeemScript.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="n_required">The number of required signatures out of the n keys or addresses</param>
        /// <param name="keys">A json array of keys which are addresses or hex-encoded public keys</param>
        /// <returns></returns>
        Task<RpcResponse<CreateMultiSigResult>> CreateMultiSigAsync(int n_required, string[] keys);

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
        Task<RpcResponse<CreateMultiSigResult>> CreateMultiSigAsync(string blockchainName, string id, int n_required, string[] keys);

        /// <summary>
        ///
        /// <para>Clear binary cache item</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="identifier">Binary cache item identifier, "*" - to clear all items</param>
        /// <returns></returns>
        Task<RpcResponse<object>> DeleteBinaryCacheAsync(string identifier);

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
        Task<RpcResponse<object>> DeleteBinaryCacheAsync(string blockchainName, string id, string identifier);

        /// <summary>
        ///
        /// <para>Estimates the approximate fee per kilobyte needed for a transaction to begin confirmation within nblocks blocks.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="n_blocks">Number of blocks to estimate fee for</param>
        /// <returns></returns>
        Task<RpcResponse<object>> EstimateFeeAsync(int n_blocks);

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
        Task<RpcResponse<object>> EstimateFeeAsync(string blockchainName, string id, int n_blocks);

        /// <summary>
        ///
        /// <para>Estimates the approximate priority  a zero-fee transaction needs to begin confirmation within nblocks blocks.</para>
        /// <para>-1.0 is returned if not enough transactions and blocks have been observed to make an estimate.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="n_blocks">Number of blocks to estimate priority for</param>
        /// <returns></returns>
        Task<RpcResponse<object>> EstimatePriorityAsync(int n_blocks);

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
        Task<RpcResponse<object>> EstimatePriorityAsync(string blockchainName, string id, int n_blocks);

        /// <summary>
        ///
        /// <para>Return information about the given address or public key or private key.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
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
        Task<RpcResponse<ValidateAddressResult>> ValidateAddressAsync(string address_pubkey_privkey);

        /// <summary>
        ///
        /// <para>Return information about the given address or public key or private key.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="address_or_pubkey_or_privkey">
        ///     <para>1. "address" (string, required) The address to validate</para>
        ///     <para>or</para>
        ///     <para>1. "pubkey" (string, required) The public key (hexadecimal) to validate</para>
        ///     <para>or</para>
        ///     <para>1. "privkey" (string, required) The private key (see dumpprivkey) to validate</para>
        /// </param>
        /// <returns></returns>
        Task<RpcResponse<ValidateAddressResult>> ValidateAddressAsync(string blockchainName, string id, string address_or_pubkey_or_privkey);

        /// <summary>
        ///
        /// <para>Verify a signed message</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="address">The address to use for the signature</param>
        /// <param name="signature">The signature provided by the signer in base 64 encoding (see signmessage)</param>
        /// <param name="message">The message that was signed</param>
        /// <returns></returns>
        Task<RpcResponse<bool>> VerifyMessageAsync(string address, string signature, string message);

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
        Task<RpcResponse<bool>> VerifyMessageAsync(string blockchainName, string id, string address, string signature, string message);
    }
}