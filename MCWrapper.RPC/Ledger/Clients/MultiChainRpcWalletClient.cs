﻿using MCWrapper.RPC.Connection;
using MCWrapper.RPC.Options;
using Microsoft.Extensions.Options;
using Myndblock.MultiChain.Actions;
using Myndblock.MultiChain.Entities;
using Myndblock.MultiChain.Entities.Constants;
using Myndblock.MultiChain.Entities.Extensions;
using Myndblock.MultiChain.Models.Wallet;
using Myndblock.MultiChain.Models.Wallet.CustomModels;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace MCWrapper.RPC.Ledger.Clients
{
    /// <summary>
    ///
    /// <para>MutliChain Core methods implemented by the MultiChainRpcWalletClient concrete class</para>
    ///
    /// addmultisigaddress, appendrawexchange, approvefrom, backupwallet,
    /// combineunspent, completerawexchange, create, createfrom,
    /// createrawexchange, createrawsendfrom, decoderawexchange,
    /// disablerawtransaction, dumpprivkey, dumpwallet, encryptwallet,
    /// getaccount, getaccountaddress, getaddressbalances, getaddresses,
    /// getaddressesbyaccount, getaddresstransaction, getassetbalances,
    /// getassettransaction, getbalance, getmultibalances, getnewaddress,
    /// getrawchangeaddress, getreceivedbyaccount, getreceivedbyaddress,
    /// getstreamitem, getstreamkeysummary, getstreampublishersummary,
    /// gettotalbalances, gettransaction, gettxoutdata, getunconfirmedbalance,
    /// getwalletinfo, getwallettransaction, grant, grantfrom, grantwithdata,
    /// grantwithdatafrom, importaddress, importprivkey, importwallet, issue,
    /// issuefrom, issuemore, issuemorefrom, keypoolrefill, listaccounts,
    /// listaddresses, listaddressgroupings, listaddresstransactions,
    /// listassettransactions, listlockunspent, listreceivedbyaccount,
    /// listreceivedbyaddress, listsinceblock, liststreamblockitems,
    /// liststreamitems, liststreamkeyitems, liststreamkeys, liststreampublisheritems,
    /// liststreampublishers, liststreamqueryitems, liststreamtxitems,
    /// listtransactions, listunspent, listwallettransactions, lockunspent,
    /// move, preparelockunspent, preparelockunspentfrom, publish, publishfrom,
    /// publishmulti, publishmultifrom, purgepublisheditems, purgestreamitems,
    /// resendwallettransactions, retrievestreamitems, revoke, revokefrom, send,
    /// sendasset, sendassetfrom, sendfrom, sendfromaccount, sendmany, sendwithdata,
    /// sendwithdatafrom, setaccount, settxfee, signmessage, subscribe, trimsubscribe,
    /// txouttobinarycache, unsubscribe, walletlock, walletpassphrase,
    /// walletpassphrasechange,
    ///
    /// </summary>
    public class MultiChainRpcWalletClient : MultiChainRpcClient, IMultiChainRpcWallet
    {
        /// <summary>
        /// Create a new MultiChainRpcWalletClient instance
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="options"></param>
        public MultiChainRpcWalletClient(HttpClient httpClient, IOptions<RpcOptions> options)
            : base(httpClient, options) { }

        /// <summary>
        ///
        /// <para>Add a nrequired-to-sign multisignature address to the wallet.</para>>
        /// <para>Each key is a address or hex-encoded public key.</para>
        /// <para> If 'account' is specified, assign address to that account.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="n_required">The number of required signatures out of the n keys or addresses</param>
        /// <param name="keys">A json array of addresses or hex-encoded public keys</param>
        /// <param name="account">An account to assign the addresses to. Accounts are not supported with the current version of MultiChain Core.</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> AddMultiSigAddressAsync(string blockchainName, string id, int n_required, string[] keys, [Optional] string account)
        {
            if (string.IsNullOrEmpty(account))
                return TransactAsync<string>(blockchainName, WalletAction.AddMultiSigAddressMethod, id, n_required, keys);
            else
                return TransactAsync<string>(blockchainName, WalletAction.AddMultiSigAddressMethod, id, n_required, keys, account);
        }

        /// <summary>
        ///
        /// <para>Add a nrequired-to-sign multisignature address to the wallet.</para>>
        /// <para>Each key is a address or hex-encoded public key.</para>
        /// <para> If 'account' is specified, assign address to that account.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="n_required">The number of required signatures out of the n keys or addresses</param>
        /// <param name="keys">A json array of addresses or hex-encoded public keys</param>
        /// <param name="account">An account to assign the addresses to. Accounts are not supported with the current version of MultiChain Core.</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> AddMultiSigAddressAsync(int n_required, string[] keys, [Optional] string account) =>
            AddMultiSigAddressAsync(RpcOptions.ChainName, UUID.NoHyphens, n_required, keys, account);

        /// <summary>
        ///
        /// <para>Adds to the raw atomic exchange transaction in tx-hex given by a previous call to createrawexchange or appendrawexchange.</para>
        /// <para>Requires wallet passphrase to be set with walletpassphrase call.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="hex">The transaction hex string</param>
        /// <param name="txid">Transaction ID of the output prepared by preparelockunspent</param>
        /// <param name="vout">Output index</param>
        /// <param name="ask_assets">
        ///     A json object of assets to ask
        ///     <para>{ "asset-identifier" : asset-quantity, ...  }</para>
        /// </param>
        /// <returns></returns>
        public Task<RpcResponse<AppendRawExchangeResult>> AppendRawExchangeAsync(string blockchainName, string id, string hex, string txid, int vout, object ask_assets) =>
            TransactAsync<AppendRawExchangeResult>(blockchainName, WalletAction.AppendRawExchangeMethod, id, hex, txid, vout, ask_assets);

        /// <summary>
        ///
        /// <para>Adds to the raw atomic exchange transaction in tx-hex given by a previous call to createrawexchange or appendrawexchange.</para>
        /// <para>Requires wallet passphrase to be set with walletpassphrase call.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="hex">The transaction hex string</param>
        /// <param name="txid">Transaction ID of the output prepared by preparelockunspent</param>
        /// <param name="vout">Output index</param>
        /// <param name="ask_assets">
        ///     A json object of assets to ask
        ///     <para>{ "asset-identifier" : asset-quantity, ...  }</para>
        /// </param>
        /// <returns></returns>
        public Task<RpcResponse<AppendRawExchangeResult>> AppendRawExchangeAsync(string hex, string txid, int vout, object ask_assets) =>
            AppendRawExchangeAsync(RpcOptions.ChainName, UUID.NoHyphens, hex, txid, vout, ask_assets);

        /// <summary>
        ///
        /// <para>Approve upgrade, tx filter, or stream filter using specific address.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="fromAddress">Address used for approval</param>
        /// <param name="entityIdentifier">
        ///     <para>Upgrade identifier - one of: create txid, upgrade name.</para>
        ///     <para>or</para>
        ///     <para>Tx Filter identifier - one of: create txid, filter reference, filter name.</para>
        ///     <para>or</para>
        ///     <para>Stream Filter identifier - one of: create txid, filter reference, filter name.</para>
        /// </param>
        /// <param name="approve">
        ///     <para>(boolean, required)  Approve or disapprove</para>
        ///     <para>or</para>
        ///     <para>(object, required)  Approve or disapprove</para>
        ///     <para>{ "approve" : approve  (boolean, required) Approve or disapprove "for" : "stream-identifier"   (string, required)  Stream identifier - one of: create txid, stream reference, stream name. }</para>
        /// </param>
        /// <returns></returns>
        public Task<RpcResponse<string>> ApproveFromAsync(string blockchainName, string id, string fromAddress, string entityIdentifier, object approve) =>
            TransactAsync<string>(blockchainName, WalletAction.ApproveFromMethod, id, fromAddress, entityIdentifier, approve);

        /// <summary>
        ///
        /// <para>Approve upgrade, tx filter, or stream filter using specific address.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="fromAddress">Address used for approval</param>
        /// <param name="entityIdentifier">
        ///     <para>Upgrade identifier - one of: create txid, upgrade name.</para>
        ///     <para>or</para>
        ///     <para>Tx Filter identifier - one of: create txid, filter reference, filter name.</para>
        ///     <para>or</para>
        ///     <para>Stream Filter identifier - one of: create txid, filter reference, filter name.</para>
        /// </param>
        /// <param name="approve">
        ///     <para>(boolean, required)  Approve or disapprove</para>
        ///     <para>or</para>
        ///     <para>(object, required)  Approve or disapprove</para>
        ///     <para>{ "approve" : approve  (boolean, required) Approve or disapprove "for" : "stream-identifier"   (string, required)  Stream identifier - one of: create txid, stream reference, stream name. }</para>
        /// </param>
        /// <returns></returns>
        public Task<RpcResponse<string>> ApproveFromAsync(string fromAddress, string entityIdentifier, object approve) =>
            ApproveFromAsync(RpcOptions.ChainName, UUID.NoHyphens, fromAddress, entityIdentifier, approve);

        /// <summary>
        ///
        /// <para>Safely copies wallet.dat to destination, which can be a directory or a path with filename.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="destination">The destination directory or file</param>
        public Task<RpcResponse> BackupWalletAsync(string blockchainName, string id, string destination) =>
            TransactAsync(blockchainName, WalletAction.BackupWalletMethod, id, destination);

        /// <summary>
        ///
        /// <para>Safely copies wallet.dat to destination, which can be a directory or a path with filename.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="destination">The destination directory or file</param>
        /// <returns></returns>
        public Task<RpcResponse> BackupWalletAsync(string destination) =>
            BackupWalletAsync(RpcOptions.ChainName, UUID.NoHyphens, destination);

        /// <summary>
        ///
        /// <para>Optimizes wallet performance by combining unspent txouts.</para>
        /// <para>Requires wallet passphrase to be set with walletpassphrase call.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="addresses">Addresses to optimize (comma delimited). Default - "*", all</param>
        /// <param name="min_conf">The minimum confirmations to filter. Default - 1</param>
        /// <param name="max_combines">Maximal number of transactions to send. Default - 100</param>
        /// <param name="min_inputs">Minimal number of txouts to combine in one transaction. Default - 2</param>
        /// <param name="max_inputs">Maximal number of txouts to combine in one transaction. Default - 100</param>
        /// <param name="max_time">Maximal time for creating combining transactions, at least one transaction will be sent. Default - 15s</param>
        /// <returns></returns>
        public Task<RpcResponse<IList<string>>> CombineUnspentAsync(string blockchainName, string id, [Optional] string addresses,
                                                                   [Optional] int min_conf, [Optional] int max_combines, [Optional] int min_inputs,
                                                                   [Optional] int max_inputs, [Optional] int max_time) =>
            TransactAsync<IList<string>>(blockchainName, WalletAction.CombineUnspentMethod, id, addresses, min_conf, max_combines, min_inputs, max_inputs, max_time);

        /// <summary>
        ///
        /// <para>Optimizes wallet performance by combining unspent txouts.</para>
        /// <para>Requires wallet passphrase to be set with walletpassphrase call.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="addresses">Addresses to optimize (comma delimited). Default - "*", all</param>
        /// <param name="min_conf">The minimum confirmations to filter. Default - 1</param>
        /// <param name="max_combines">Maximal number of transactions to send. Default - 100</param>
        /// <param name="min_inputs">Minimal number of txouts to combine in one transaction. Default - 2</param>
        /// <param name="max_inputs">Maximal number of txouts to combine in one transaction. Default - 100</param>
        /// <param name="max_time">Maximal time for creating combining transactions, at least one transaction will be sent. Default - 15s</param>
        /// <returns></returns>
        public Task<RpcResponse<IList<string>>> CombineUnspentAsync([Optional] string addresses,
                                                             [Optional] int min_conf, [Optional] int max_combines, [Optional] int min_inputs,
                                                             [Optional] int max_inputs, [Optional] int max_time) =>
            CombineUnspentAsync(RpcOptions.ChainName, UUID.NoHyphens, addresses, min_conf, max_combines, min_inputs, max_inputs, max_time);

        /// <summary>
        ///
        /// <para>Completes existing exchange transaction, adds fee if needed</para>
        /// <para>Returns hex-encoded raw transaction.</para>
        /// <para>Requires wallet passphrase to be set with walletpassphrase call.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="hex">The transaction hex string</param>
        /// <param name="txid">Transaction ID of the output prepared by preparelockunspent</param>
        /// <param name="vout">Output index</param>
        /// <param name="ask_assets">A json object of assets to ask; { "asset-identifier" : asset-quantity, ... }</param>
        /// <param name="data">Data, see help data-with for details</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> CompleteRawExchangeAsync(string blockchainName, string id, string hex, string txid, int vout, object ask_assets, [Optional] object data) =>
            TransactAsync<string>(blockchainName, WalletAction.CompleteRawExchangeMethod, id, hex, txid, vout, ask_assets, data);

        /// <summary>
        ///
        /// <para>Completes existing exchange transaction, adds fee if needed</para>
        /// <para>Returns hex-encoded raw transaction.</para>
        /// <para>Requires wallet passphrase to be set with walletpassphrase call.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="hex">The transaction hex string</param>
        /// <param name="txid">Transaction ID of the output prepared by preparelockunspent</param>
        /// <param name="vout">Output index</param>
        /// <param name="ask_assets">A json object of assets to ask; { "asset-identifier" : asset-quantity, ... }</param>
        /// <param name="data">Data, see help data-with for details</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> CompleteRawExchangeAsync(string hex, string txid, int vout, object ask_assets, [Optional] object data) =>
            CompleteRawExchangeAsync(RpcOptions.ChainName, UUID.NoHyphens, hex, txid, vout, ask_assets, data);

        /// <summary>
        ///
        /// <para>Creates stream or upgrade</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="entity_type">One of stream, upgrade, tx filter, stream filter</param>
        /// <param name="entity_name">The unique name of the stream, upgrade, tx filter, stream filter</param>
        /// <param name="restrictions_or_open">A json object with optional stream, upgrade, or filter restrictions</param>
        /// <param name="custom_fields">Custom fields objects or JavaScript code string</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> CreateAsync(string blockchainName, string id, string entity_type, string entity_name, object restrictions_or_open, [Optional] object custom_fields) =>
            TransactAsync<string>(blockchainName, WalletAction.CreateMethod, id, entity_type, entity_name, restrictions_or_open, custom_fields);

        /// <summary>
        ///
        /// <para>Creates stream or upgrade</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="entity_type">One of stream, upgrade, tx filter, stream filter</param>
        /// <param name="entity_name">The unique name of the stream, upgrade, tx filter, stream filter</param>
        /// <param name="restrictions_or_open">A json object with optional stream, upgrade, or filter restrictions</param>
        /// <param name="custom_fields">Custom fields objects or JavaScript code string</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> CreateAsync(string entity_type, string entity_name, object restrictions_or_open, [Optional] object custom_fields) =>
            CreateAsync(RpcOptions.ChainName, UUID.NoHyphens, entity_type, entity_name, restrictions_or_open, custom_fields);

        /// <summary>
        ///
        /// <para>Creates stream or upgrade using specific address</para>
        /// <para>Requires wallet passphrase to be set with walletpassphrase call.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="from_address">Address used for creating</param>
        /// <param name="entity_type">One of stream, upgrade, tx filter, stream filter</param>
        /// <param name="entity_name">The unique name of the stream, upgrade, tx filter, stream filter</param>
        /// <param name="restrictions_or_open">A json object with optional stream, upgrade, or filter restrictions</param>
        /// <param name="custom_fields">Custom fields objects or JavaScript code string</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> CreateFromAsync(string blockchainName, string id, string from_address, string entity_type, string entity_name, object restrictions_or_open, [Optional] object custom_fields) =>
            TransactAsync<string>(blockchainName, WalletAction.CreateFromMethod, id, from_address, entity_type, entity_name, restrictions_or_open, custom_fields);

        /// <summary>
        ///
        /// <para>Creates stream or upgrade using specific address</para>
        /// <para>Requires wallet passphrase to be set with walletpassphrase call.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="from_address">Address used for creating</param>
        /// <param name="entity_type">One of stream, upgrade, tx filter, stream filter</param>
        /// <param name="entity_name">The unique name of the stream, upgrade, tx filter, stream filter</param>
        /// <param name="restrictions_or_open">A json object with optional stream, upgrade, or filter restrictions</param>
        /// <param name="custom_fields">Custom fields objects or JavaScript code string</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> CreateFromAsync(string from_address, string entity_type, string entity_name, object restrictions_or_open, [Optional] object custom_fields) =>
            CreateFromAsync(RpcOptions.ChainName, UUID.NoHyphens, from_address, entity_type, entity_name, restrictions_or_open, custom_fields);

        /// <summary>
        ///
        /// <para>Creates new exchange transaction</para>
        /// <para>Note that the transaction should be completed by appendrawexchange</para>
        /// <para>Requires wallet passphrase to be set with walletpassphrase call.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="txid">Transaction ID of the output prepared by preparelockunspent</param>
        /// <param name="vout">Output index</param>
        /// <param name="ask_assets">A json object of assets to ask</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> CreateRawExchangeAsync(string blockchainName, string id, string txid, int vout, object ask_assets) =>
            TransactAsync<string>(blockchainName, WalletAction.CreateRawExchangeMethod, id, txid, vout, ask_assets);

        /// <summary>
        ///
        /// <para>Creates new exchange transaction</para>
        /// <para>Note that the transaction should be completed by appendrawexchange</para>
        /// <para>Requires wallet passphrase to be set with walletpassphrase call.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="txid">Transaction ID of the output prepared by preparelockunspent</param>
        /// <param name="vout">Output index</param>
        /// <param name="ask_assets">A json object of assets to ask</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> CreateRawExchangeAsync(string txid, int vout, object ask_assets) =>
            CreateRawExchangeAsync(RpcOptions.ChainName, UUID.NoHyphens, txid, vout, ask_assets);

        /// <summary>
        ///
        /// <para>Create a transaction using the given sending address.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="from_address">Address to send from</param>
        /// <param name="addresses">Object with addresses as keys, see help addresses-all for details</param>
        /// <param name="data">Array of hexadecimal strings or data objects, see help data-all for details</param>
        /// <param name="action">Default is "". Additional actions: "lock", "sign", "lock,sign", "sign,lock", "send"</param>
        /// <returns></returns>
        public Task<RpcResponse> CreateRawSendFromAsync(string blockchainName, string id, string from_address, object addresses, [Optional] object[] data, [Optional] string action) =>
            TransactAsync(blockchainName, WalletAction.CreateRawSendFromMethod, id, from_address, addresses, data, action);

        /// <summary>
        ///
        /// <para>Create a transaction using the given sending address.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="from_address">Address to send from</param>
        /// <param name="addresses">Object with addresses as keys, see help addresses-all for details</param>
        /// <param name="data">Array of hexadecimal strings or data objects, see help data-all for details</param>
        /// <param name="action">Default is "". Additional actions: "lock", "sign", "lock,sign", "sign,lock", "send"</param>
        /// <returns></returns>
        public Task<RpcResponse> CreateRawSendFromAsync(string from_address, object addresses, [Optional] object[] data, [Optional] string action) =>
            CreateRawSendFromAsync(RpcOptions.ChainName, UUID.NoHyphens, from_address, addresses, data, action);

        /// <summary>
        ///
        /// <para>Return a JSON object representing the serialized, hex-encoded exchange transaction.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="tx_hex">The exchange transaction hex string</param>
        /// <param name="verbose">If true, returns array of all exchanges created by createrawexchange or appendrawexchange</param>
        /// <returns></returns>
        public Task<RpcResponse<DecodeRawExchangeResult>> DecodeRawExchangeAsync(string blockchainName, string id, string tx_hex, bool verbose = false) =>
            TransactAsync<DecodeRawExchangeResult>(blockchainName, WalletAction.DecodeRawExchangeMethod, id, tx_hex, verbose);

        /// <summary>
        ///
        /// <para>Return a JSON object representing the serialized, hex-encoded exchange transaction.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="tx_hex">The exchange transaction hex string</param>
        /// <param name="verbose">If true, returns array of all exchanges created by createrawexchange or appendrawexchange</param>
        /// <returns></returns>
        public Task<RpcResponse<DecodeRawExchangeResult>> DecodeRawExchangeAsync(string tx_hex, bool verbose = false) =>
            DecodeRawExchangeAsync(RpcOptions.ChainName, UUID.NoHyphens, tx_hex, verbose);

        /// <summary>
        ///
        /// <para>Disable raw transaction by spending one of its inputs and sending it back to the wallet.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="tx_hex">The transaction hex string</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> DisableRawTransactionAsync(string blockchainName, string id, string tx_hex) =>
            TransactAsync<string>(blockchainName, WalletAction.DisableRawTransactionMethod, id, tx_hex);

        /// <summary>
        ///
        /// <para>Disable raw transaction by spending one of its inputs and sending it back to the wallet.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="tx_hex">The transaction hex string</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> DisableRawTransactionAsync(string tx_hex) =>
            DisableRawTransactionAsync(RpcOptions.ChainName, UUID.NoHyphens, tx_hex);

        /// <summary>
        ///
        /// <para>Reveals the private key corresponding to 'address'.</para>
        /// <para>Then the importprivkey can be used with this output</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="address">The MultiChain address for the private key</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> DumpPrivKeyAsync(string blockchainName, string id, string address) =>
            TransactAsync<string>(blockchainName, WalletAction.DumpPrivKeyMethod, id, address);

        /// <summary>
        ///
        /// <para>Reveals the private key corresponding to 'address'.</para>
        /// <para>Then the importprivkey can be used with this output</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="address">The MultiChain address for the private key</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> DumpPrivKeyAsync(string address) =>
            DumpPrivKeyAsync(RpcOptions.ChainName, UUID.NoHyphens, address);

        /// <summary>
        ///
        /// <para>Dumps all wallet keys in a human-readable format.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="filename">The filename</param>
        /// <returns></returns>
        public Task<RpcResponse> DumpWalletAsync(string blockchainName, string id, string filename) =>
            TransactAsync(blockchainName, WalletAction.DumpWalletMethod, id, filename);

        /// <summary>
        ///
        /// <para>Dumps all wallet keys in a human-readable format.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="filename">The filename</param>
        /// <returns></returns>
        public Task<RpcResponse> DumpWalletAsync(string filename) =>
            DumpWalletAsync(RpcOptions.ChainName, UUID.NoHyphens, filename);

        /// <summary>
        /// <para>Encrypts the wallet with 'passphrase'. This is for first time encryption.</para>
        /// <para>
        ///     After this, any calls that interact with private keys such as sending or signing
        ///     will require the passphrase to be set prior the making these calls.
        ///     Use the walletpassphrase call for this, and then walletlock call.
        ///     If the wallet is already encrypted, use the walletpassphrasechange call.
        ///     Note that this will shutdown the server.
        /// </para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="passphrase">The pass phrase to encrypt the wallet with. It must be at least 1 character, but should be long</param>
        /// <returns></returns>
        public Task<RpcResponse> EncryptWalletAsync(string blockchainName, string id, string passphrase) =>
            TransactAsync(blockchainName, WalletAction.EncryptWalletMethod, id, passphrase);

        /// <summary>
        /// <para>Encrypts the wallet with 'passphrase'. This is for first time encryption.</para>
        /// <para>
        ///     After this, any calls that interact with private keys such as sending or signing
        ///     will require the passphrase to be set prior the making these calls.
        ///     Use the walletpassphrase call for this, and then walletlock call.
        ///     If the wallet is already encrypted, use the walletpassphrasechange call.
        ///     Note that this will shutdown the server.
        /// </para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="passphrase">The pass phrase to encrypt the wallet with. It must be at least 1 character, but should be long</param>
        /// <returns></returns>
        public Task<RpcResponse> EncryptWalletAsync(string passphrase) =>
            EncryptWalletAsync(RpcOptions.ChainName, UUID.NoHyphens, passphrase);

        /// <summary>
        ///
        /// <para>Returns the account associated with the targeted address.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="address">The address for account lookup</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> GetAccountAsync(string blockchainName, string id, string address) =>
            TransactAsync<string>(blockchainName, WalletAction.GetAccountMethod, id, address);

        /// <summary>
        ///
        /// <para>Returns the account associated with the targeted address.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="address">The address for account lookup</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> GetAccountAsync(string address) =>
            GetAccountAsync(RpcOptions.ChainName, UUID.NoHyphens, address);

        /// <summary>
        ///
        /// <para>Returns the current address for receiving payments to this account.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="account">The account name for the address. It can also be set to the empty string "" to represent the default account. The account does not need to exist, it will be created and a new address created if there is no account by the given name.</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> GetAccountAddressAsync(string blockchainName, string id, string account = "") =>
            TransactAsync<string>(blockchainName, WalletAction.GetAccountAddressMethod, id, account);

        /// <summary>
        ///
        /// <para>Returns the current address for receiving payments to this account.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="account">The account name for the address. It can also be set to the empty string "" to represent the default account. The account does not need to exist, it will be created and a new address created if there is no account by the given name.</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> GetAccountAddressAsync(string account = "") =>
            GetAccountAddressAsync(RpcOptions.ChainName, UUID.NoHyphens, account);

        /// <summary>
        ///
        /// <para>Returns asset balances for specified address</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="address">Address to return balance for</param>
        /// <param name="min_conf">Only include transactions confirmed at least this many times</param>
        /// <param name="include_locked">Also take locked outputs into account</param>
        /// <returns></returns>
        public Task<RpcResponse<IList<GetAddressBalancesResult>>> GetAddressBalancesAsync(string blockchainName, string id, string address, int min_conf = 1, bool include_locked = false) =>
            TransactAsync<IList<GetAddressBalancesResult>>(blockchainName, WalletAction.GetAddressBalancesMethod, id, address, min_conf, include_locked);

        /// <summary>
        ///
        /// <para>Returns asset balances for specified address</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="address">Address to return balance for</param>
        /// <param name="min_conf">Only include transactions confirmed at least this many times</param>
        /// <param name="include_locked">Also take locked outputs into account</param>
        /// <returns></returns>
        public Task<RpcResponse<IList<GetAddressBalancesResult>>> GetAddressBalancesAsync(string address, int min_conf = 1, bool include_locked = false) =>
            GetAddressBalancesAsync(RpcOptions.ChainName, UUID.NoHyphens, address, min_conf, include_locked);

        /// <summary>
        ///
        /// <para>Returns the list of all addresses in the wallet.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="verbose">The account name</param>
        /// <returns></returns>
        public Task<RpcResponse<IList<GetAddressesResult>>> GetAddressesAsync(string blockchainName, string id, bool verbose = false) =>
            TransactAsync<IList<GetAddressesResult>>(blockchainName, WalletAction.GetAddressesMethod, id, verbose);

        /// <summary>
        ///
        /// <para>Returns the list of all addresses in the wallet.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="verbose">The account name</param>
        /// <returns></returns>
        public Task<RpcResponse<IList<GetAddressesResult>>> GetAddressesAsync(bool verbose = false) =>
            GetAddressesAsync(RpcOptions.ChainName, UUID.NoHyphens, verbose);

        /// <summary>
        ///
        /// <para>Returns the list of addresses for the given account.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="account">The account name</param>
        /// <returns></returns>
        public Task<RpcResponse<IList<string>>> GetAddressesByAccountAsync(string blockchainName, string id, string account) =>
            TransactAsync<IList<string>>(blockchainName, WalletAction.GetAddressesByAccountMethod, id, account);

        /// <summary>
        ///
        /// <para>Returns the list of addresses for the given account.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="account">The account name</param>
        /// <returns></returns>
        public Task<RpcResponse<IList<string>>> GetAddressesByAccountAsync(string account) =>
            GetAddressesByAccountAsync(RpcOptions.ChainName, UUID.NoHyphens, account);

        /// <summary>
        ///
        /// <para>Provides information about transaction txid related to address in this node's wallet</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="address">Address used for balance calculation</param>
        /// <param name="txid">The transaction id</param>
        /// <param name="verbose">If true, returns detailed array of inputs and outputs and raw hex of transactions</param>
        /// <returns></returns>
        public Task<RpcResponse<GetAddressTransactionResult>> GetAddressTransactionAsync(string blockchainName, string id, string address, string txid, bool verbose = false) =>
            TransactAsync<GetAddressTransactionResult>(blockchainName, WalletAction.GetAddressTransactionMethod, id, address, txid, verbose);

        /// <summary>
        ///
        /// <para>Provides information about transaction txid related to address in this node's wallet</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="address">Address used for balance calculation</param>
        /// <param name="txid">The transaction id</param>
        /// <param name="verbose">If true, returns detailed array of inputs and outputs and raw hex of transactions</param>
        /// <returns></returns>
        public Task<RpcResponse<GetAddressTransactionResult>> GetAddressTransactionAsync(string address, string txid, bool verbose = false) =>
            GetAddressTransactionAsync(RpcOptions.ChainName, UUID.NoHyphens, address, txid, verbose);

        /// <summary>
        ///
        /// <para>If account is not specified, returns the server's total available asset balances.</para>
        /// <para>If account is specified, returns the balances in the account.</para>
        /// <para>Note that the account "" is not the same as leaving the parameter out.</para>
        /// <para>The server total may be different to the balance in the default "" account.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="account">The selected account, or "*" for entire wallet. It may be the default account using ""</param>
        /// <param name="min_conf">Only include transactions confirmed at least this many times</param>
        /// <param name="include_watch_only">Also include balance in watchonly addresses (see 'importaddress')</param>
        /// <param name="include_locked">Also take locked outputs into account</param>
        /// <returns></returns>
        public Task<RpcResponse<IList<object>>> GetAssetBalancesAsync(string blockchainName, string id, [Optional] string account, [Optional] int min_conf, [Optional] bool include_watch_only, [Optional] bool include_locked) =>
            TransactAsync<IList<object>>(blockchainName, WalletAction.GetAssetBalancesMethod, id, account, min_conf, include_watch_only, include_locked);

        /// <summary>
        ///
        /// <para>If account is not specified, returns the server's total available asset balances.</para>
        /// <para>If account is specified, returns the balances in the account.</para>
        /// <para>Note that the account "" is not the same as leaving the parameter out.</para>
        /// <para>The server total may be different to the balance in the default "" account.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="account">The selected account, or "*" for entire wallet. It may be the default account using ""</param>
        /// <param name="min_conf">Only include transactions confirmed at least this many times</param>
        /// <param name="include_watch_only">Also include balance in watchonly addresses (see 'importaddress')</param>
        /// <param name="include_locked">Also take locked outputs into account</param>
        /// <returns></returns>
        public Task<RpcResponse<IList<object>>> GetAssetBalancesAsync([Optional] string account, [Optional] int min_conf, [Optional] bool include_watch_only, [Optional] bool include_locked) =>
            GetAssetBalancesAsync(RpcOptions.ChainName, UUID.NoHyphens, account, min_conf, include_watch_only, include_locked);

        /// <summary>
        ///
        /// <para>Retrieves a specific transaction txid involving asset.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="asset_identifier">One of the following: asset txid, asset reference, asset name</param>
        /// <param name="txid">The transaction id</param>
        /// <param name="verbose">If true, returns information about item transaction</param>
        /// <returns></returns>
        public Task<RpcResponse<GetAssetTransactionResult>> GetAssetTransactionAsync(string blockchainName, string id, string asset_identifier, string txid, bool verbose = false) =>
            TransactAsync<GetAssetTransactionResult>(blockchainName, WalletAction.GetAssetTransactionMethod, id, asset_identifier, txid, verbose);

        /// <summary>
        ///
        /// <para>Retrieves a specific transaction txid involving asset.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="asset_identifier">One of the following: asset txid, asset reference, asset name</param>
        /// <param name="txid">The transaction id</param>
        /// <param name="verbose">If true, returns information about item transaction</param>
        /// <returns></returns>
        public Task<RpcResponse<GetAssetTransactionResult>> GetAssetTransactionAsync(string asset_identifier, string txid, bool verbose = false) =>
            GetAssetTransactionAsync(RpcOptions.ChainName, UUID.NoHyphens, asset_identifier, txid, verbose);

        /// <summary>
        ///
        /// <para>If account is not specified, returns the server's total available balance.</para>
        /// <para>If account is specified, returns the balance in the account.</para>
        /// <para>Note that the account "" is not the same as leaving the parameter out.</para>
        /// <para>The server total may be different to the balance in the default "" account.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="account">The selected account, or "*" for entire wallet. It may be the default account using ""</param>
        /// <param name="min_conf">Only include transactions confirmed at least this many times</param>
        /// <param name="include_watch_only">Also include balance in watchonly addresses (see 'importaddress')</param>
        /// <returns></returns>
        public Task<RpcResponse<double>> GetBalanceAsync(string blockchainName, string id, [Optional] string account, [Optional] int min_conf, [Optional] bool include_watch_only) =>
            TransactAsync<double>(blockchainName, WalletAction.GetBalanceMethod, id, account, min_conf, include_watch_only);

        /// <summary>
        ///
        /// <para>If account is not specified, returns the server's total available balance.</para>
        /// <para>If account is specified, returns the balance in the account.</para>
        /// <para>Note that the account "" is not the same as leaving the parameter out.</para>
        /// <para>The server total may be different to the balance in the default "" account.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="account">The selected account, or "*" for entire wallet. It may be the default account using ""</param>
        /// <param name="min_conf">Only include transactions confirmed at least this many times</param>
        /// <param name="include_watch_only">Also include balance in watchonly addresses (see 'importaddress')</param>
        /// <returns></returns>
        public Task<RpcResponse<double>> GetBalanceAsync([Optional] string account, [Optional] int min_conf, [Optional] bool include_watch_only) =>
            GetBalanceAsync(RpcOptions.ChainName, UUID.NoHyphens, account, min_conf, include_watch_only);

        /// <summary>
        ///
        /// <para>Returns asset balances for specified address</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="addresses">Address(es) to return balance for, comma delimited. Default - all or A json array of addresses to return balance for</param>
        /// <param name="assets">Single asset identifier to return balance for, default "*" or Json array of asset identifiers to return balance for</param>
        /// <param name="min_conf">Only include transactions confirmed at least this many times</param>
        /// <param name="include_locked">Include transactions to watchonly addresses (see 'importaddress')</param>
        /// <param name="include_watch_only">Also take locked outputs into account</param>
        /// <returns></returns>
        public Task<RpcResponse> GetMultiBalancesAsync(string blockchainName, string id, [Optional] object addresses, [Optional] object assets, [Optional] int min_conf, [Optional] bool include_locked, [Optional] bool include_watch_only) =>
            TransactAsync(blockchainName, WalletAction.GetMultiBalancesMethod, id, addresses, assets, min_conf, include_locked, include_watch_only);

        /// <summary>
        ///
        /// <para>Returns asset balances for specified address</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="addresses">Address(es) to return balance for, comma delimited. Default - all or A json array of addresses to return balance for</param>
        /// <param name="assets">Single asset identifier to return balance for, default "*" or Json array of asset identifiers to return balance for</param>
        /// <param name="min_conf">Only include transactions confirmed at least this many times</param>
        /// <param name="include_locked">Include transactions to watchonly addresses (see 'importaddress')</param>
        /// <param name="include_watch_only">Also take locked outputs into account</param>
        /// <returns></returns>
        public Task<RpcResponse> GetMultiBalancesAsync([Optional] object addresses, [Optional] object assets, [Optional] int min_conf, [Optional] bool include_locked, [Optional] bool include_watch_only) =>
            GetMultiBalancesAsync(RpcOptions.ChainName, UUID.NoHyphens, addresses, assets, min_conf, include_locked, include_watch_only);

        /// <summary>
        ///
        /// <para> Returns a new address for receiving payments.</para>
        /// <para>If 'account' is specified (deprecated), it is added to the address book so payments received with the address will be credited to 'account'.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="account">The account name for the address to be linked to. If not provided, the default account "" is used. It can also be set to the empty string "" to represent the default account. The account does not need to exist, it will be created if there is no account by the given name.</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> GetNewAddressAsync(string blockchainName, string id, [Optional] string account)
        {
            if (string.IsNullOrEmpty(account))
                return TransactAsync<string>(blockchainName, WalletAction.GetNewAddressMethod, id);
            else
                return TransactAsync<string>(blockchainName, WalletAction.GetNewAddressMethod, id, account);
        }

        /// <summary>
        ///
        /// <para> Returns a new address for receiving payments.</para>
        /// <para>If 'account' is specified (deprecated), it is added to the address book so payments received with the address will be credited to 'account'.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="account">The account name for the address to be linked to. If not provided, the default account "" is used. It can also be set to the empty string "" to represent the default account. The account does not need to exist, it will be created if there is no account by the given name.</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> GetNewAddressAsync([Optional]string account) =>
            GetNewAddressAsync(RpcOptions.ChainName, UUID.NoHyphens, account);

        /// <summary>
        ///
        /// <para>Returns a new address, for receiving change.</para>
        /// <para>This is for use with raw transactions, NOT normal use.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> GetRawChangeAddressAsync(string blockchainName, string id) =>
            TransactAsync<string>(blockchainName, WalletAction.GetRawChangeAddressMethod, id);

        /// <summary>
        ///
        /// <para>Returns a new address, for receiving change.</para>
        /// <para>This is for use with raw transactions, NOT normal use.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <returns></returns>
        public Task<RpcResponse<string>> GetRawChangeAddressAsync() =>
            GetRawChangeAddressAsync(RpcOptions.ChainName, UUID.NoHyphens);

        /// <summary>
        ///
        /// <para>Returns the total amount received by addresses with account in transactions with at least [minconf] confirmations.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="account">The selected account, may be the default account using ""</param>
        /// <param name="min_conf">Only include transactions confirmed at least this many times</param>
        /// <returns></returns>
        public Task<RpcResponse<double>> GetReceivedByAccountAsync(string blockchainName, string id, string account, int min_conf = 1) =>
            TransactAsync<double>(blockchainName, WalletAction.GetReceivedByAccountMethod, id, account, min_conf);

        /// <summary>
        ///
        /// <para>Returns the total amount received by addresses with account in transactions with at least [minconf] confirmations.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="account">The selected account, may be the default account using ""</param>
        /// <param name="min_conf">Only include transactions confirmed at least this many times</param>
        /// <returns></returns>
        public Task<RpcResponse<double>> GetReceivedByAccountAsync(string account, int min_conf = 1) =>
            GetReceivedByAccountAsync(RpcOptions.ChainName, UUID.NoHyphens, account, min_conf);

        /// <summary>
        ///
        /// <para>Returns the total amount received by the given address in transactions with at least minconf confirmations.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="address">The address for transactions</param>
        /// <param name="min_conf">Only include transactions confirmed at least this many times</param>
        /// <returns></returns>
        public Task<RpcResponse<double>> GetReceivedByAddressAsync(string blockchainName, string id, string address, int min_conf = 1) =>
            TransactAsync<double>(blockchainName, WalletAction.GetReceivedByAddressMethod, id, address, min_conf);

        /// <summary>
        ///
        /// <para>Returns the total amount received by the given address in transactions with at least minconf confirmations.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="address">The address for transactions</param>
        /// <param name="min_conf">Only include transactions confirmed at least this many times</param>
        /// <returns></returns>
        public Task<RpcResponse<double>> GetReceivedByAddressAsync(string address, int min_conf = 1) =>
            GetReceivedByAddressAsync(RpcOptions.ChainName, UUID.NoHyphens, address, min_conf);

        /// <summary>
        ///
        /// <para>Returns stream item.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="stream_identifier">One of the following: stream txid, stream reference, stream name</param>
        /// <param name="txid">id</param>
        /// <param name="verbose">If true, returns information about item transaction</param>
        /// <returns></returns>
        public Task<RpcResponse<GetStreamItemResult>> GetStreamItemAsync(string blockchainName, string id, string stream_identifier, string txid, bool verbose = false) =>
            TransactAsync<GetStreamItemResult>(blockchainName, WalletAction.GetStreamItemMethod, id, stream_identifier, txid, verbose);

        /// <summary>
        ///
        /// <para>Returns stream item.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="stream_identifier">One of the following: stream txid, stream reference, stream name</param>
        /// <param name="txid">id</param>
        /// <param name="verbose">If true, returns information about item transaction</param>
        /// <returns></returns>
        public Task<RpcResponse<GetStreamItemResult>> GetStreamItemAsync(string stream_identifier, string txid, bool verbose = false) =>
            GetStreamItemAsync(RpcOptions.ChainName, UUID.NoHyphens, stream_identifier, txid, verbose);

        /// <summary>
        ///
        /// <para>Returns stream json object items summary for specific key.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="stream_identifier">One of the following: stream txid, stream reference, stream name</param>
        /// <param name="key">Stream key</param>
        /// <param name="mode">
        ///     <para>
        ///         Comma delimited list of the following: jsonobjectmerge (required) - merge json objects, recursive - merge json sub-objects recursively,
        ///         noupdate -  preserve first value for each key instead of taking the last, omitnull - omit keys with null values,
        ///         ignoreother - ignore items that cannot be included in summary (otherwise returns an error),
        ///         ignoremissing - ignore missing offchain items (otherwise returns an error),
        ///         firstpublishersany - only summarize items by a publisher of first item with this key,
        ///         firstpublishersall - only summarize items by all publishers of first item with this key
        ///     </para>
        /// </param>
        /// <returns></returns>
        public Task<RpcResponse> GetStreamKeySummaryAsync(string blockchainName, string id, string stream_identifier, string key, string mode) =>
            TransactAsync(blockchainName, WalletAction.GetStreamKeySummaryMethod, id, stream_identifier, key, mode);

        /// <summary>
        ///
        /// <para>Returns stream json object items summary for specific key.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="stream_identifier">One of the following: stream txid, stream reference, stream name</param>
        /// <param name="key">Stream key</param>
        /// <param name="mode">
        ///     <para>
        ///         Comma delimited list of the following:
        ///         jsonobjectmerge (required) - merge json objects,
        ///         recursive - merge json sub-objects recursively,
        ///         noupdate -  preserve first value for each key instead of taking the last, omitnull - omit keys with null values,
        ///         ignoreother - ignore items that cannot be included in summary (otherwise returns an error),
        ///         ignoremissing - ignore missing offchain items (otherwise returns an error),
        ///         firstpublishersany - only summarize items by a publisher of first item with this key,
        ///         firstpublishersall - only summarize items by all publishers of first item with this key
        ///     </para>
        /// </param>
        /// <returns></returns>
        public Task<RpcResponse> GetStreamKeySummaryAsync(string stream_identifier, string key, string mode) =>
            GetStreamKeySummaryAsync(RpcOptions.ChainName, UUID.NoHyphens, stream_identifier, key, mode);

        /// <summary>
        ///
        /// <para>Returns stream json object items summary for specific publisher.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="stream_identifier">one of the following: stream txid, stream reference, stream name</param>
        /// <param name="address">Publisher address</param>
        /// <param name="mode">
        ///     <para>
        ///         Comma delimited list of the following:
        ///         jsonobjectmerge (required) - merge json objects,
        ///         recursive - merge json sub-objects recursively,
        ///         noupdate -  preserve first value for each key instead of taking the last, omitnull - omit keys with null values,
        ///         ignoreother - ignore items that cannot be included in summary (otherwise returns an error),
        ///         ignoremissing - ignore missing offchain items (otherwise returns an error),
        ///     </para>
        /// </param>
        /// <returns></returns>
        public Task<RpcResponse> GetStreamPublisherSummaryAsync(string blockchainName, string id, string stream_identifier, string address, string mode) =>
            TransactAsync(blockchainName, WalletAction.GetStreamPublisherSummaryMethod, id, stream_identifier, address, mode);

        /// <summary>
        ///
        /// <para>Returns stream json object items summary for specific publisher.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="stream_identifier">one of the following: stream txid, stream reference, stream name</param>
        /// <param name="address">Publisher address</param>
        /// <param name="mode">
        ///     <para>
        ///         Comma delimited list of the following:
        ///         jsonobjectmerge (required) - merge json objects,
        ///         recursive - merge json sub-objects recursively,
        ///         noupdate -  preserve first value for each key instead of taking the last, omitnull - omit keys with null values,
        ///         ignoreother - ignore items that cannot be included in summary (otherwise returns an error),
        ///         ignoremissing - ignore missing offchain items (otherwise returns an error),
        ///     </para>
        /// </param>
        /// <returns></returns>
        public Task<RpcResponse> GetStreamPublisherSummaryAsync(string stream_identifier, string address, string mode) =>
            GetStreamPublisherSummaryAsync(RpcOptions.ChainName, UUID.NoHyphens, stream_identifier, address, mode);

        /// <summary>
        ///
        /// <para>Returns a list of all the asset balances in this nodeΓÇÖs wallet, with at least minconf confirmations.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="min_conf">Only include transactions confirmed at least this many times</param>
        /// <param name="include_watch_only">Also include balance in watchonly addresses (see 'importaddress')</param>
        /// <param name="include_locked">Also take locked outputs into account</param>
        /// <returns></returns>
        public Task<RpcResponse<IList<GetTotalBalancesResult>>> GetTotalBalancesAsync(string blockchainName, string id, int min_conf = 1, bool include_watch_only = false, bool include_locked = false) =>
            TransactAsync<IList<GetTotalBalancesResult>>(blockchainName, WalletAction.GetTotalBalancesMethod, id, min_conf, include_watch_only, include_locked);

        /// <summary>
        ///
        /// <para>Returns a list of all the asset balances in this nodeΓÇÖs wallet, with at least minconf confirmations.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="min_conf">Only include transactions confirmed at least this many times</param>
        /// <param name="include_watch_only">Also include balance in watchonly addresses (see 'importaddress')</param>
        /// <param name="include_locked">Also take locked outputs into account</param>
        /// <returns></returns>
        public Task<RpcResponse<IList<GetTotalBalancesResult>>> GetTotalBalancesAsync(int min_conf = 1, bool include_watch_only = false, bool include_locked = false) =>
            GetTotalBalancesAsync(RpcOptions.ChainName, UUID.NoHyphens, min_conf, include_watch_only, include_locked);

        /// <summary>
        ///
        /// <para>Get detailed information about in-wallet transaction txid</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="txid">The transaction id</param>
        /// <param name="include_watch_only">Whether to include watchonly addresses in balance calculation and details[]</param>
        /// <returns></returns>
        public Task<RpcResponse<GetTransactionResult>> GetTransactionAsync(string blockchainName, string id, string txid, bool include_watch_only = false) =>
            TransactAsync<GetTransactionResult>(blockchainName, WalletAction.GetTransactionMethod, id, txid, include_watch_only);

        /// <summary>
        ///
        /// <para>Get detailed information about in-wallet transaction txid</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="txid">The transaction id</param>
        /// <param name="include_watch_only">Whether to include watchonly addresses in balance calculation and details[]</param>
        /// <returns></returns>
        public Task<RpcResponse<GetTransactionResult>> GetTransactionAsync(string txid, bool include_watch_only = false) =>
            GetTransactionAsync(RpcOptions.ChainName, UUID.NoHyphens, txid, include_watch_only);

        /// <summary>
        ///
        /// <para>Returns metadata of transaction output.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="txid">The transaction id</param>
        /// <param name="vout">vout value</param>
        /// <param name="count_bytes">Number of bytes to return</param>
        /// <param name="start_byte">Start from specific byte</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> GetTxOutDataAsync(string blockchainName, string id, string txid, int vout, [Optional] int count_bytes, [Optional] int start_byte)
        {
            if (count_bytes > 0)
                return TransactAsync<string>(blockchainName, WalletAction.GetTxOutDataMethod, id, txid, vout, count_bytes, start_byte);
            else
                return TransactAsync<string>(blockchainName, WalletAction.GetTxOutDataMethod, id, txid, vout);
        }

        /// <summary>
        ///
        /// <para>Returns metadata of transaction output.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="txid">The transaction id</param>
        /// <param name="vout">vout value</param>
        /// <param name="count_bytes">Number of bytes to return</param>
        /// <param name="start_byte">Start from specific byte</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> GetTxOutDataAsync(string txid, int vout, [Optional] int count_bytes, [Optional] int start_byte) =>
            GetTxOutDataAsync(RpcOptions.ChainName, UUID.NoHyphens, txid, vout, count_bytes, start_byte);

        /// <summary>
        ///
        /// <para>Returns the server's total unconfirmed balance</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <returns></returns>
        public Task<RpcResponse<double>> GetUnconfirmedBalanceAsync(string blockchainName, string id) =>
            TransactAsync<double>(blockchainName, WalletAction.GetUnconfirmedBalanceMethod, id);

        /// <summary>
        ///
        /// <para>Returns the server's total unconfirmed balance</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <returns></returns>
        public Task<RpcResponse<double>> GetUnconfirmedBalanceAsync() =>
            GetUnconfirmedBalanceAsync(RpcOptions.ChainName, UUID.NoHyphens);

        /// <summary>
        ///
        /// <para>Returns an object containing various wallet state info.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <returns></returns>
        public Task<RpcResponse<GetWalletInfoResult>> GetWalletInfoAsync(string blockchainName, string id) =>
            TransactAsync<GetWalletInfoResult>(blockchainName, WalletAction.GetwalletinfoMethod, id);

        /// <summary>
        ///
        /// <para>Returns an object containing various wallet state info.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <returns></returns>
        public Task<RpcResponse<GetWalletInfoResult>> GetWalletInfoAsync() =>
            GetWalletInfoAsync(RpcOptions.ChainName, UUID.NoHyphens);

        /// <summary>
        ///
        /// <para>Get detailed information about in-wallet transaction txid</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="txid">The transaction id</param>
        /// <param name="include_watch_only">Whether to include watchonly addresses in balance calculation and details[]</param>
        /// <param name="verbose">If true, returns detailed array of inputs and outputs and raw hex of transactions</param>
        /// <returns></returns>
        public Task<RpcResponse<GetWalletTransactionResult>> GetWalletTransactionAsync(string blockchainName, string id, string txid, bool include_watch_only = false, bool verbose = false) =>
            TransactAsync<GetWalletTransactionResult>(blockchainName, WalletAction.GetWalletTransactionMethod, id, txid, include_watch_only, verbose);

        /// <summary>
        ///
        /// <para>Get detailed information about in-wallet transaction txid</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="txid">The transaction id</param>
        /// <param name="include_watch_only">Whether to include watchonly addresses in balance calculation and details[]</param>
        /// <param name="verbose">If true, returns detailed array of inputs and outputs and raw hex of transactions</param>
        /// <returns></returns>
        public Task<RpcResponse<GetWalletTransactionResult>> GetWalletTransactionAsync(string txid, bool include_watch_only = false, bool verbose = false) =>
            GetWalletTransactionAsync(RpcOptions.ChainName, UUID.NoHyphens, txid, include_watch_only, verbose);

        /// <summary>
        ///
        /// <para>Requires wallet passphrase to be set with walletpassphrase call.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="addresses">The multichain addresses to send to (comma delimited)</param>
        /// <param name="permissions">
        ///     Permission strings, comma delimited.
        ///     <para>
        ///         Global: connect,send,receive,issue,mine,admin,activate,creat
        ///     </para>
        ///     <para>
        ///         or per-asset: asset-identifier.issue,admin,activate,send,receive
        ///     </para>
        ///     <para>
        ///         or per-stream: stream-identifier.write,activate,admin
        ///     </para>
        /// </param>
        /// <param name="native_amount">Native currency amount to send. eg 0.1. Default - 0.0</param>
        /// <param name="start_block">Block to apply permissions from (inclusive). Default - 0</param>
        /// <param name="end_block">Block to apply permissions to (exclusive). Default - 4294967295; If -1 is specified default value is used.</param>
        /// <param name="comment">A comment used to store what the transaction is for. This is not part of the transaction, just kept in your wallet.</param>
        /// <param name="comment_to"> A comment to store the name of the person or organization to which you're sending the transaction. This is not part of the transaction, just kept in your wallet.</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> GrantAsync(string blockchainName, string id, string addresses, string permissions, decimal native_amount = 0, int start_block = 0, uint end_block = Permission.MaxEndblock, string comment = "", string comment_to = "")
        {
            if (native_amount == 0 && start_block == 0 && end_block == 0)
                return TransactAsync<string>(blockchainName, WalletAction.GrantMethod, id, addresses, permissions);
            else if (start_block == 0 && end_block == 0)
                return TransactAsync<string>(blockchainName, WalletAction.GrantMethod, id, addresses, permissions, native_amount);
            else if (end_block == 0)
                return TransactAsync<string>(blockchainName, WalletAction.GrantMethod, id, addresses, permissions, native_amount, start_block);
            else
                return TransactAsync<string>(blockchainName, WalletAction.GrantMethod, id, addresses, permissions, native_amount, start_block, end_block, comment, comment_to);
        }

        /// <summary>
        ///
        /// <para>Requires wallet passphrase to be set with walletpassphrase call.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="addresses">The multichain addresses to send to (comma delimited)</param>
        /// <param name="permissions">
        ///     Permission strings, comma delimited.
        ///     <para>
        ///         Global: connect,send,receive,issue,mine,admin,activate,creat
        ///     </para>
        ///     <para>
        ///         or per-asset: asset-identifier.issue,admin,activate,send,receive
        ///     </para>
        ///     <para>
        ///         or per-stream: stream-identifier.write,activate,admin
        ///     </para>
        /// </param>
        /// <param name="native_amount">Native currency amount to send. eg 0.1. Default - 0.0</param>
        /// <param name="start_block">Block to apply permissions from (inclusive). Default - 0</param>
        /// <param name="end_block">Block to apply permissions to (exclusive). Default - 4294967295; If -1 is specified default value is used.</param>
        /// <param name="comment">A comment used to store what the transaction is for. This is not part of the transaction, just kept in your wallet.</param>
        /// <param name="comment_to"> A comment to store the name of the person or organization to which you're sending the transaction. This is not part of the transaction, just kept in your wallet.</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> GrantAsync(string addresses, string permissions, decimal native_amount = 0, int start_block = 0, uint end_block = Permission.MaxEndblock, string comment = "", string comment_to = "") =>
            GrantAsync(RpcOptions.ChainName, UUID.NoHyphens, addresses, permissions, native_amount, start_block, end_block, comment, comment_to);

        /// <summary>
        /// Grant permission using specific address.
        ///
        /// Requires wallet passphrase to be set with walletpassphrase call.
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="from_address">Address used for grant</param>
        /// <param name="addresses">The multichain addresses to send to (comma delimited)</param>
        /// <param name="permissions">
        ///     Permission strings, comma delimited.
        ///     <para>
        ///         Global: connect,send,receive,issue,mine,admin,activate,creat
        ///     </para>
        ///     <para>
        ///         or per-asset: asset-identifier.issue,admin,activate,send,receive
        ///     </para>
        ///     <para>
        ///         or per-stream: stream-identifier.write,activate,admin
        ///     </para>
        /// </param>
        /// <param name="native_amount">Native currency amount to send. eg 0.1. Default - 0.0</param>
        /// <param name="start_block">Block to apply permissions from (inclusive). Default - 0</param>
        /// <param name="end_block">Block to apply permissions to (exclusive). Default - 4294967295; If -1 is specified default value is used.</param>
        /// <param name="comment">A comment used to store what the transaction is for. This is not part of the transaction, just kept in your wallet.</param>
        /// <param name="comment_to"> A comment to store the name of the person or organization to which you're sending the transaction. This is not part of the transaction, just kept in your wallet.</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> GrantFromAsync(string blockchainName, string id, string from_address, string addresses, string permissions, decimal native_amount = 0, int start_block = 0, uint end_block = Permission.MaxEndblock, string comment = "", string comment_to = "")
        {
            if (native_amount == 0 && start_block == 0 && end_block == 0)
                return TransactAsync<string>(blockchainName, WalletAction.GrantFromMethod, id, from_address, addresses, permissions);
            else if (start_block == 0 && end_block == 0)
                return TransactAsync<string>(blockchainName, WalletAction.GrantFromMethod, id, from_address, addresses, permissions, native_amount);
            else if (end_block == 0)
                return TransactAsync<string>(blockchainName, WalletAction.GrantFromMethod, id, from_address, addresses, permissions, native_amount, start_block);
            else
                return TransactAsync<string>(blockchainName, WalletAction.GrantFromMethod, id, from_address, addresses, permissions, native_amount, start_block, end_block, comment, comment_to);
        }

        /// <summary>
        /// Grant permission using specific address.
        ///
        /// Requires wallet passphrase to be set with walletpassphrase call.
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="from_address">Address used for grant</param>
        /// <param name="addresses">The multichain addresses to send to (comma delimited)</param>
        /// <param name="permissions">
        ///     Permission strings, comma delimited.
        ///     <para>
        ///         Global: connect,send,receive,issue,mine,admin,activate,creat
        ///     </para>
        ///     <para>
        ///         or per-asset: asset-identifier.issue,admin,activate,send,receive
        ///     </para>
        ///     <para>
        ///         or per-stream: stream-identifier.write,activate,admin
        ///     </para>
        /// </param>
        /// <param name="native_amount">Native currency amount to send. eg 0.1. Default - 0.0</param>
        /// <param name="start_block">Block to apply permissions from (inclusive). Default - 0</param>
        /// <param name="end_block">Block to apply permissions to (exclusive). Default - 4294967295; If -1 is specified default value is used.</param>
        /// <param name="comment">A comment used to store what the transaction is for. This is not part of the transaction, just kept in your wallet.</param>
        /// <param name="comment_to"> A comment to store the name of the person or organization to which you're sending the transaction. This is not part of the transaction, just kept in your wallet.</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> GrantFromAsync(string from_address, string addresses, string permissions, decimal native_amount = 0, int start_block = 0, uint end_block = Permission.MaxEndblock, string comment = "", string comment_to = "") =>
            GrantFromAsync(RpcOptions.ChainName, UUID.NoHyphens, from_address, addresses, permissions, native_amount, start_block, end_block, comment, comment_to);

        /// <summary>
        ///
        /// <para>Grant permission(s) with metadata to a given address.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="addresses">The multichain addresses to send to (comma delimited)</param>
        /// <param name="permissions">
        ///     Permission strings, comma delimited.
        ///     <para>
        ///         Global: connect,send,receive,issue,mine,admin,activate,creat
        ///     </para>
        ///     <para>
        ///         or per-asset: asset-identifier.issue,admin,activate,send,receive
        ///     </para>
        ///     <para>
        ///         or per-stream: stream-identifier.write,activate,admin
        ///     </para>
        /// </param>
        /// <param name="object_or_hex">(string or object, required) Data, see help data-with for details.</param>
        /// <param name="native_amount">Native currency amount to send. eg 0.1. Default - 0.0</param>
        /// <param name="start_block">Block to apply permissions from (inclusive). Default - 0</param>
        /// <param name="end_block">Block to apply permissions to (exclusive). Default - 4294967295; If -1 is specified default value is used.</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> GrantWithDataAsync(string blockchainName, string id, string addresses, string permissions, object object_or_hex, decimal native_amount = 0, int start_block = 0, uint end_block = Permission.MaxEndblock) =>
            TransactAsync<string>(blockchainName, WalletAction.GrantWithDataMethod, id, addresses, permissions, object_or_hex, native_amount, start_block, end_block);

        /// <summary>
        ///
        /// <para>Grant permission(s) with metadata to a given address.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="addresses">The multichain addresses to send to (comma delimited)</param>
        /// <param name="permissions">
        ///     Permission strings, comma delimited.
        ///     <para>
        ///         Global: connect,send,receive,issue,mine,admin,activate,creat
        ///     </para>
        ///     <para>
        ///         or per-asset: asset-identifier.issue,admin,activate,send,receive
        ///     </para>
        ///     <para>
        ///         or per-stream: stream-identifier.write,activate,admin
        ///     </para>
        /// </param>
        /// <param name="object_or_hex">(string or object, required) Data, see help data-with for details.</param>
        /// <param name="native_amount">Native currency amount to send. eg 0.1. Default - 0.0</param>
        /// <param name="start_block">Block to apply permissions from (inclusive). Default - 0</param>
        /// <param name="end_block">Block to apply permissions to (exclusive). Default - 4294967295; If -1 is specified default value is used.</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> GrantWithDataAsync(string addresses, string permissions, object object_or_hex, decimal native_amount = 0, int start_block = 0, uint end_block = Permission.MaxEndblock) =>
            GrantWithDataAsync(RpcOptions.ChainName, UUID.NoHyphens, addresses, permissions, object_or_hex, native_amount, start_block, end_block);

        /// <summary>
        ///
        /// <para>Grant permission with metadata using specific address.</para>
        /// <para>Requires wallet passphrase to be set with walletpassphrase call.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="from_address">Address used for grant</param>
        /// <param name="to_addresses">The multichain addresses to send to (comma delimited)</param>
        /// <param name="permissions">
        ///     Permission strings, comma delimited.
        ///     <para>
        ///         Global: connect,send,receive,issue,mine,admin,activate,creat
        ///     </para>
        ///     <para>
        ///         or per-asset: asset-identifier.issue,admin,activate,send,receive
        ///     </para>
        ///     <para>
        ///         or per-stream: stream-identifier.write,activate,admin
        ///     </para>
        /// </param>
        /// <param name="object_or_hex">(string or object, required) Data, see help data-with for details.</param>
        /// <param name="native_amount">Native currency amount to send. eg 0.1. Default - 0.0</param>
        /// <param name="start_block">Block to apply permissions from (inclusive). Default - 0</param>
        /// <param name="end_block">Block to apply permissions to (exclusive). Default - 4294967295; If -1 is specified default value is used.</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> GrantWithDataFromAsync(string blockchainName, string id, string from_address, string to_addresses, string permissions, object object_or_hex, decimal native_amount = 0, int start_block = 0, uint end_block = Permission.MaxEndblock) =>
            TransactAsync<string>(blockchainName, WalletAction.GrantWithDataFromMethod, id, from_address, to_addresses, permissions, object_or_hex, native_amount, start_block, end_block);

        /// <summary>
        ///
        /// <para>Grant permission with metadata using specific address.</para>
        /// <para>Requires wallet passphrase to be set with walletpassphrase call.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="from_address">Address used for grant</param>
        /// <param name="to_addresses">The multichain addresses to send to (comma delimited)</param>
        /// <param name="permissions">
        ///     Permission strings, comma delimited.
        ///     <para>
        ///         Global: connect,send,receive,issue,mine,admin,activate,creat
        ///     </para>
        ///     <para>
        ///         or per-asset: asset-identifier.issue,admin,activate,send,receive
        ///     </para>
        ///     <para>
        ///         or per-stream: stream-identifier.write,activate,admin
        ///     </para>
        /// </param>
        /// <param name="object_or_hex">(string or object, required) Data, see help data-with for details.</param>
        /// <param name="native_amount">Native currency amount to send. eg 0.1. Default - 0.0</param>
        /// <param name="start_block">Block to apply permissions from (inclusive). Default - 0</param>
        /// <param name="end_block">Block to apply permissions to (exclusive). Default - 4294967295; If -1 is specified default value is used.</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> GrantWithDataFromAsync(string from_address, string to_addresses, string permissions, object object_or_hex, decimal native_amount = 0, int start_block = 0, uint end_block = Permission.MaxEndblock) =>
            GrantWithDataFromAsync(RpcOptions.ChainName, UUID.NoHyphens, from_address, to_addresses, permissions, object_or_hex, native_amount, start_block, end_block);

        /// <summary>
        ///
        /// <para>Adds an address or script (in hex) that can be watched as if it were in your wallet but cannot be used to spend.</para>
        /// <para>Note: This call can take minutes to complete if rescan is true.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="addresses">The addresses, comma delimited or a json array of addresses</param>
        /// <param name="label">An optional label</param>
        /// <param name="rescan">(boolean or integer, optional, default=true) Rescan the wallet for transactions. If integer rescan from block, if negative - from the end</param>
        /// <returns></returns>
        public Task<RpcResponse> ImportAddressAsync(string blockchainName, string id, object addresses, [Optional] string label, [Optional] object rescan) =>
            TransactAsync(blockchainName, WalletAction.ImportAddressMethod, id, addresses, label, rescan);

        /// <summary>
        ///
        /// <para>Adds an address or script (in hex) that can be watched as if it were in your wallet but cannot be used to spend.</para>
        /// <para>Note: This call can take minutes to complete if rescan is true.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="addresses">The addresses, comma delimited or a json array of addresses</param>
        /// <param name="label">An optional label</param>
        /// <param name="rescan">(boolean or integer, optional, default=true) Rescan the wallet for transactions. If integer rescan from block, if negative - from the end</param>
        /// <returns></returns>
        public Task<RpcResponse> ImportAddressAsync(object addresses, [Optional] string label, [Optional] object rescan) =>
            ImportAddressAsync(RpcOptions.ChainName, UUID.NoHyphens, addresses, label, rescan);

        /// <summary>
        ///
        /// <para>Adds a private key (as returned by dumpprivkey) to your wallet.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="priv_keys">(string, required) The private key (see dumpprivkey), comma delimited or (array, optional) A json array of private keys</param>
        /// <param name="label">An optional label</param>
        /// <param name="rescan">(boolean or integer, optional, default=true) Rescan the wallet for transactions. If integer rescan from block, if negative - from the end</param>
        /// <returns></returns>
        public Task<RpcResponse> ImportPrivKeyAsync(string blockchainName, string id, object priv_keys, [Optional] string label, [Optional] object rescan) =>
            TransactAsync(blockchainName, WalletAction.ImportPrivKeyMethod, id, priv_keys, label, rescan);

        /// <summary>
        ///
        /// <para>Adds a private key (as returned by dumpprivkey) to your wallet.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="priv_keys">(string, required) The private key (see dumpprivkey), comma delimited or (array, optional) A json array of private keys</param>
        /// <param name="label">An optional label</param>
        /// <param name="rescan">(boolean or integer, optional, default=true) Rescan the wallet for transactions. If integer rescan from block, if negative - from the end</param>
        /// <returns></returns>
        public Task<RpcResponse> ImportPrivKeyAsync(object priv_keys, [Optional] string label, [Optional] object rescan) =>
            ImportPrivKeyAsync(RpcOptions.ChainName, UUID.NoHyphens, priv_keys, label, rescan);

        /// <summary>
        ///
        /// <para>Imports keys from a wallet dump file (see dumpwallet).</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="filename">The wallet file</param>
        /// <param name="rescan">(boolean or integer, optional, default=true) Rescan the wallet for transactions. If integer rescan from block, if negative - from the end.</param>
        /// <returns></returns>
        public Task<RpcResponse> ImportWalletAsync(string blockchainName, string id, string filename, [Optional] object rescan) =>
            TransactAsync(blockchainName, WalletAction.ImportWalletMethod, id, filename, rescan);

        /// <summary>
        ///
        /// <para>Imports keys from a wallet dump file (see dumpwallet).</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="filename">The wallet file</param>
        /// <param name="rescan">(boolean or integer, optional, default=true) Rescan the wallet for transactions. If integer rescan from block, if negative - from the end.</param>
        /// <returns></returns>
        public Task<RpcResponse> ImportWalletAsync(string filename, [Optional] object rescan) =>
            ImportWalletAsync(RpcOptions.ChainName, UUID.NoHyphens, filename, rescan);


        /// <summary>
        ///
        /// <para>Issue a new AssetEntity model to an address on the blockchain network.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="toAddress">The address to send newly created asset to</param>
        /// <param name="assetParams">(AssetEntity type, required) A strongly typed object with asset params (string)name, (bool)open, and (string, comma delimited)restrict</param>
        /// <param name="quantity">The asset total amount in display units. eg. 1234.56</param>
        /// <param name="smallestUnit">Number of raw units in one displayed unit, eg 0.01 for cents. Default value is 1</param>
        /// <param name="nativeCurrencyAmount">native currency amount to send. eg 0.1, Default: minimum-per-output.</param>
        /// <param name="customFields">a dictionary object with custom fields. { "param-name": "param-value"   (strings, required) The key is the parameter name, the value is parameter value, ,... }</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> IssueAsync(string blockchainName,
                                                    string id,
                                                    string toAddress,
                                                    AssetEntity assetParams,
                                                    int quantity,
                                                    double smallestUnit = 1,
                                                    decimal nativeCurrencyAmount = 0,
                                                    Dictionary<string, string>? customFields = null) =>
            TransactAsync<string>(blockchainName, WalletAction.IssueMethod, id, toAddress, assetParams, quantity, smallestUnit, nativeCurrencyAmount, customFields ?? new Dictionary<string, string>());

        /// <summary>
        ///
        /// <para>Issue a new AssetEntity model to an address on the blockchain network.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="toAddress">The address to send newly created asset to</param>
        /// <param name="assetParams">(AssetEntity type, required) A strongly typed object with asset params (string)name, (bool)open, and (string, comma delimited)restrict</param>
        /// <param name="quantity">The asset total amount in display units. eg. 1234.56</param>
        /// <param name="smallestUnit">Number of raw units in one displayed unit, eg 0.01 for cents. Default value is 1</param>
        /// <param name="nativeCurrencyAmount">native currency amount to send. eg 0.1, Default: minimum-per-output.</param>
        /// <param name="customFields">a json object with custom fields. { "param-name": "param-value"   (strings, required) The key is the parameter name, the value is parameter value, ,... }</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> IssueAsync(string blockchainName,
                                                    string id,
                                                    string toAddress,
                                                    AssetEntity assetParams,
                                                    int quantity,
                                                    double smallestUnit = 1,
                                                    decimal nativeCurrencyAmount = 0,
                                                    object? customFields = null) =>
            TransactAsync<string>(blockchainName, WalletAction.IssueMethod, id, toAddress, assetParams, quantity, smallestUnit, nativeCurrencyAmount, customFields ?? new { });

        /// <summary>
        ///
        /// <para>Issue a new Asset using object params to an address on the blockchain network.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="toAddress">The address to send newly created asset to</param>
        /// <param name="assetParams">(object type, required) A generic object that must include asset params (string)name, (bool)open, and (string, comma delimited)restrict</param>
        /// <param name="quantity">The asset total amount in display units. eg. 1234.56</param>
        /// <param name="smallestUnit">Number of raw units in one displayed unit, eg 0.01 for cents. Default value is 1</param>
        /// <param name="nativeCurrencyAmount">native currency amount to send. eg 0.1, Default: minimum-per-output.</param>
        /// <param name="customFields">a dictionary object with custom fields. { "param-name": "param-value"   (strings, required) The key is the parameter name, the value is parameter value, ,... }</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> IssueAsync(string blockchainName,
                                                    string id,
                                                    string toAddress,
                                                    object assetParams,
                                                    int quantity,
                                                    double smallestUnit = 1,
                                                    decimal nativeCurrencyAmount = 0,
                                                    Dictionary<string, string>? customFields = null) =>
            TransactAsync<string>(blockchainName, WalletAction.IssueMethod, id, toAddress, assetParams, quantity, smallestUnit, nativeCurrencyAmount, customFields ?? new Dictionary<string, string>());

        /// <summary>
        ///
        /// <para>Issue a new Asset using object params to an address on the blockchain network.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="toAddress">The address to send newly created asset to</param>
        /// <param name="assetParams">(object type, required) A generic object that must include asset params (string)name, (bool)open, and (string, comma delimited)restrict</param>
        /// <param name="quantity">The asset total amount in display units. eg. 1234.56</param>
        /// <param name="smallestUnit">Number of raw units in one displayed unit, eg 0.01 for cents. Default value is 1</param>
        /// <param name="nativeCurrencyAmount">native currency amount to send. eg 0.1, Default: minimum-per-output.</param>
        /// <param name="customFields">a json object with custom fields. { "param-name": "param-value"   (strings, required) The key is the parameter name, the value is parameter value, ,... }</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> IssueAsync(string blockchainName,
                                                    string id,
                                                    string toAddress,
                                                    object assetParams,
                                                    int quantity,
                                                    double smallestUnit = 1,
                                                    decimal nativeCurrencyAmount = 0,
                                                    object? customFields = null) =>
            TransactAsync<string>(blockchainName, WalletAction.IssueMethod, id, toAddress, assetParams, quantity, smallestUnit, nativeCurrencyAmount, customFields ?? new { });

        /// <summary>
        ///
        /// <para>Issue a new Asset by name to an address on the blockchain network.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="toAddress">The address to send newly created asset to</param>
        /// <param name="assetName"> (string, required) Asset name, if not "" should be unique</param>
        /// <param name="quantity">The asset total amount in display units. eg. 1234.56</param>
        /// <param name="smallestUnit">Number of raw units in one displayed unit, eg 0.01 for cents. Default value is 1</param>
        /// <param name="nativeCurrencyAmount">native currency amount to send. eg 0.1, Default: minimum-per-output.</param>
        /// <param name="customFields">a dictionary object with custom fields. { "param-name": "param-value"   (strings, required) The key is the parameter name, the value is parameter value, ,... }</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> IssueAsync(string blockchainName,
                                                    string id,
                                                    string toAddress,
                                                    string assetName,
                                                    int quantity,
                                                    double smallestUnit = 1,
                                                    decimal nativeCurrencyAmount = 0,
                                                    Dictionary<string, string>? customFields = null) =>
            TransactAsync<string>(blockchainName, WalletAction.IssueMethod, id, toAddress, assetName, quantity, smallestUnit, nativeCurrencyAmount, customFields ?? new Dictionary<string, string>());

        /// <summary>
        ///
        /// <para>Issue a new Asset by name to an address on the blockchain network.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="toAddress">The address to send newly created asset to</param>
        /// <param name="assetName"> (string, required) Asset name, if not "" should be unique</param>
        /// <param name="quantity">The asset total amount in display units. eg. 1234.56</param>
        /// <param name="smallestUnit">Number of raw units in one displayed unit, eg 0.01 for cents. Default value is 1</param>
        /// <param name="nativeCurrencyAmount">native currency amount to send. eg 0.1, Default: minimum-per-output.</param>
        /// <param name="customFields">a json object with custom fields. { "param-name": "param-value"   (strings, required) The key is the parameter name, the value is parameter value, ,... }</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> IssueAsync(string blockchainName,
                                                    string id,
                                                    string toAddress,
                                                    string assetName,
                                                    int quantity,
                                                    double smallestUnit = 1,
                                                    decimal nativeCurrencyAmount = 0,
                                                    object? customFields = null) =>
            TransactAsync<string>(blockchainName, WalletAction.IssueMethod, id, toAddress, assetName, quantity, smallestUnit, nativeCurrencyAmount, customFields ?? new { });

        /// <summary>
        ///
        /// <para>Issue a new AssetEntity model to an address on the blockchain network.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="toAddress">The address to send newly created asset to</param>
        /// <param name="assetParams">(AssetEntity type, required) A strongly typed object with asset params (string)name, (bool)open, and (string, comma delimited)restrict</param>
        /// <param name="quantity">The asset total amount in display units. eg. 1234.56</param>
        /// <param name="smallestUnit">Number of raw units in one displayed unit, eg 0.01 for cents. Default value is 1</param>
        /// <param name="nativeCurrencyAmount">native currency amount to send. eg 0.1, Default: minimum-per-output.</param>
        /// <param name="customFields">a dictionary object with custom fields. { "param-name": "param-value"   (strings, required) The key is the parameter name, the value is parameter value, ,... }</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> IssueAsync(string toAddress,
                                                    AssetEntity assetParams,
                                                    int quantity,
                                                    double smallestUnit = 1,
                                                    decimal nativeCurrencyAmount = 0,
                                                    Dictionary<string, string>? customFields = null) =>
            IssueAsync(RpcOptions.ChainName, UUID.NoHyphens, toAddress, assetParams, quantity, smallestUnit, nativeCurrencyAmount, customFields ?? new Dictionary<string, string>());

        /// <summary>
        ///
        /// <para>Issue a new AssetEntity model to an address on the blockchain network.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="toAddress">The address to send newly created asset to</param>
        /// <param name="assetParams">(AssetEntity type, required) A strongly typed object with asset params (string)name, (bool)open, and (string, comma delimited)restrict</param>
        /// <param name="quantity">The asset total amount in display units. eg. 1234.56</param>
        /// <param name="smallestUnit">Number of raw units in one displayed unit, eg 0.01 for cents. Default value is 1</param>
        /// <param name="nativeCurrencyAmount">native currency amount to send. eg 0.1, Default: minimum-per-output.</param>
        /// <param name="customFields">a json object with custom fields. { "param-name": "param-value"   (strings, required) The key is the parameter name, the value is parameter value, ,... }</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> IssueAsync(string toAddress,
                                                    AssetEntity assetParams,
                                                    int quantity,
                                                    double smallestUnit = 1,
                                                    decimal nativeCurrencyAmount = 0,
                                                    object? customFields = null) =>
            IssueAsync(RpcOptions.ChainName, UUID.NoHyphens, toAddress, assetParams, quantity, smallestUnit, nativeCurrencyAmount, customFields ?? new { });

        /// <summary>
        ///
        /// <para>Issue a new Asset using object params to an address on the blockchain network.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="toAddress">The address to send newly created asset to</param>
        /// <param name="assetParams">(object type, required) A generic object that must include asset params (string)name, (bool)open, and (string, comma delimited)restrict</param>
        /// <param name="quantity">The asset total amount in display units. eg. 1234.56</param>
        /// <param name="smallestUnit">Number of raw units in one displayed unit, eg 0.01 for cents. Default value is 1</param>
        /// <param name="nativeCurrencyAmount">native currency amount to send. eg 0.1, Default: minimum-per-output.</param>
        /// <param name="customFields">a dictionary object with custom fields. { "param-name": "param-value"   (strings, required) The key is the parameter name, the value is parameter value, ,... }</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> IssueAsync(string toAddress,
                                                    object assetParams,
                                                    int quantity,
                                                    double smallestUnit = 1,
                                                    decimal nativeCurrencyAmount = 0,
                                                    Dictionary<string, string>? customFields = null) =>
            IssueAsync(RpcOptions.ChainName, UUID.NoHyphens, toAddress, assetParams, quantity, smallestUnit, nativeCurrencyAmount, customFields ?? new Dictionary<string, string>());

        /// <summary>
        ///
        /// <para>Issue a new Asset using object params to an address on the blockchain network.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="toAddress">The address to send newly created asset to</param>
        /// <param name="assetParams">(object type, required) A generic object that must include asset params (string)name, (bool)open, and (string, comma delimited)restrict</param>
        /// <param name="quantity">The asset total amount in display units. eg. 1234.56</param>
        /// <param name="smallestUnit">Number of raw units in one displayed unit, eg 0.01 for cents. Default value is 1</param>
        /// <param name="nativeCurrencyAmount">native currency amount to send. eg 0.1, Default: minimum-per-output.</param>
        /// <param name="customFields">a json object with custom fields. { "param-name": "param-value"   (strings, required) The key is the parameter name, the value is parameter value, ,... }</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> IssueAsync(string toAddress,
                                                    object assetParams,
                                                    int quantity,
                                                    double smallestUnit = 1,
                                                    decimal nativeCurrencyAmount = 0,
                                                    object? customFields = null) =>
            IssueAsync(RpcOptions.ChainName, UUID.NoHyphens, toAddress, assetParams, quantity, smallestUnit, nativeCurrencyAmount, customFields ?? new { });

        /// <summary>
        ///
        /// <para>Issue a new Asset by name to an address on the blockchain network.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="toAddress">The address to send newly created asset to</param>
        /// <param name="assetName">(string, required) Asset name, if not "" should be unique</param>
        /// <param name="quantity">The asset total amount in display units. eg. 1234.56</param>
        /// <param name="smallestUnit">Number of raw units in one displayed unit, eg 0.01 for cents. Default value is 1</param>
        /// <param name="nativeCurrencyAmount">native currency amount to send. eg 0.1, Default: minimum-per-output.</param>
        /// <param name="customFields">a dictionary object with custom fields. { "param-name": "param-value"   (strings, required) The key is the parameter name, the value is parameter value, ,... }</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> IssueAsync(string toAddress,
                                                    string assetName,
                                                    int quantity,
                                                    double smallestUnit = 1,
                                                    decimal nativeCurrencyAmount = 0,
                                                    Dictionary<string, string>? customFields = null) =>
            IssueAsync(RpcOptions.ChainName, UUID.NoHyphens, toAddress, assetName, quantity, smallestUnit, nativeCurrencyAmount, customFields ?? new Dictionary<string, string>());

        /// <summary>
        ///
        /// <para>Issue a new Asset by name to an address on the blockchain network.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="toAddress">The address to send newly created asset to</param>
        /// <param name="assetName">(string, required) Asset name, if not "" should be unique</param>
        /// <param name="quantity">The asset total amount in display units. eg. 1234.56</param>
        /// <param name="smallestUnit">Number of raw units in one displayed unit, eg 0.01 for cents. Default value is 1</param>
        /// <param name="nativeCurrencyAmount">native currency amount to send. eg 0.1, Default: minimum-per-output.</param>
        /// <param name="customFields">a json object with custom fields. { "param-name": "param-value"   (strings, required) The key is the parameter name, the value is parameter value, ,... }</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> IssueAsync(string toAddress,
                                                    string assetName,
                                                    int quantity,
                                                    double smallestUnit = 1,
                                                    decimal nativeCurrencyAmount = 0,
                                                    object? customFields = null) =>
            IssueAsync(RpcOptions.ChainName, UUID.NoHyphens, toAddress, assetName, quantity, smallestUnit, nativeCurrencyAmount, customFields ?? new { });


        /// <summary>
        ///
        /// <para>Issue a new AssetEntity model to an address on the blockchain network.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="fromAddress">Address used for issuing</param>
        /// <param name="toAddress">The address to send newly created asset to</param>
        /// <param name="assetParams">(AssetEntity type, required) A strongly typed object with asset params (string)name, (bool)open, and (string, comma delimited)restrict</param>
        /// <param name="quantity">The asset total amount in display units. eg. 1234.56</param>
        /// <param name="smallestUnit">Number of raw units in one displayed unit, eg 0.01 for cents. Default value is 1</param>
        /// <param name="nativeCurrencyAmount">native currency amount to send. eg 0.1, Default: minimum-per-output.</param>
        /// <param name="customFields">a dictionary object with custom fields. { "param-name": "param-value"   (strings, required) The key is the parameter name, the value is parameter value, ,... }</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> IssueFromAsync(string blockchainName,
                                                        string id,
                                                        string fromAddress,
                                                        string toAddress,
                                                        AssetEntity assetParams,
                                                        int quantity,
                                                        double smallestUnit = 1,
                                                        decimal nativeCurrencyAmount = 0,
                                                        Dictionary<string, string>? customFields = null) =>
            TransactAsync<string>(blockchainName, WalletAction.IssueFromMethod, id, fromAddress, toAddress, assetParams, quantity, smallestUnit, nativeCurrencyAmount, customFields ?? new Dictionary<string, string>());

        /// <summary>
        ///
        /// <para>Issue a new AssetEntity model to an address on the blockchain network.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="fromAddress">Address used for issuing</param>
        /// <param name="toAddress">The address to send newly created asset to</param>
        /// <param name="assetParams">(AssetEntity type, required) A strongly typed object with asset params (string)name, (bool)open, and (string, comma delimited)restrict</param>
        /// <param name="quantity">The asset total amount in display units. eg. 1234.56</param>
        /// <param name="smallestUnit">Number of raw units in one displayed unit, eg 0.01 for cents. Default value is 1</param>
        /// <param name="nativeCurrencyAmount">native currency amount to send. eg 0.1, Default: minimum-per-output.</param>
        /// <param name="customFields">a json object with custom fields. { "param-name": "param-value"   (strings, required) The key is the parameter name, the value is parameter value, ,... }</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> IssueFromAsync(string blockchainName,
                                                        string id,
                                                        string fromAddress,
                                                        string toAddress,
                                                        AssetEntity assetParams,
                                                        int quantity,
                                                        double smallestUnit = 1,
                                                        decimal nativeCurrencyAmount = 0,
                                                        object? customFields = null) =>
            TransactAsync<string>(blockchainName, WalletAction.IssueFromMethod, id, fromAddress, toAddress, assetParams, quantity, smallestUnit, nativeCurrencyAmount, customFields ?? new { });

        /// <summary>
        ///
        /// <para>Issue a new Asset using object params to an address on the blockchain network.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="fromAddress">Address used for issuing</param>
        /// <param name="toAddress">The address to send newly created asset to</param>
        /// <param name="assetParams">(object type, required) A generic object that must include asset params (string)name, (bool)open, and (string, comma delimited)restrict</param>
        /// <param name="quantity">The asset total amount in display units. eg. 1234.56</param>
        /// <param name="smallestUnit">Number of raw units in one displayed unit, eg 0.01 for cents. Default value is 1</param>
        /// <param name="nativeCurrencyAmount">native currency amount to send. eg 0.1, Default: minimum-per-output.</param>
        /// <param name="customFields">a dictionary object with custom fields. { "param-name": "param-value"   (strings, required) The key is the parameter name, the value is parameter value, ,... }</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> IssueFromAsync(string blockchainName,
                                                        string id,
                                                        string fromAddress,
                                                        string toAddress,
                                                        object assetParams,
                                                        int quantity,
                                                        double smallestUnit = 1,
                                                        decimal nativeCurrencyAmount = 0,
                                                        Dictionary<string, string>? customFields = null) =>
            TransactAsync<string>(blockchainName, WalletAction.IssueFromMethod, id, fromAddress, toAddress, assetParams, quantity, smallestUnit, nativeCurrencyAmount, customFields ?? new Dictionary<string, string>());

        /// <summary>
        ///
        /// <para>Issue a new Asset using object params to an address on the blockchain network.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="fromAddress">Address used for issuing</param>
        /// <param name="toAddress">The address to send newly created asset to</param>
        /// <param name="assetParams">(object type, required) A generic object that must include asset params (string)name, (bool)open, and (string, comma delimited)restrict</param>
        /// <param name="quantity">The asset total amount in display units. eg. 1234.56</param>
        /// <param name="smallestUnit">Number of raw units in one displayed unit, eg 0.01 for cents. Default value is 1</param>
        /// <param name="nativeCurrencyAmount">native currency amount to send. eg 0.1, Default: minimum-per-output.</param>
        /// <param name="customFields">a json object with custom fields. { "param-name": "param-value"   (strings, required) The key is the parameter name, the value is parameter value, ,... }</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> IssueFromAsync(string blockchainName,
                                                        string id,
                                                        string fromAddress,
                                                        string toAddress,
                                                        object assetParams,
                                                        int quantity,
                                                        double smallestUnit = 1,
                                                        decimal nativeCurrencyAmount = 0,
                                                        object? customFields = null) =>
            TransactAsync<string>(blockchainName, WalletAction.IssueFromMethod, id, fromAddress, toAddress, assetParams, quantity, smallestUnit, nativeCurrencyAmount, customFields ?? new { });

        /// <summary>
        ///
        /// <para>Issue a new Asset by name to an address on the blockchain network.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="fromAddress">Address used for issuing</param>
        /// <param name="toAddress">The address to send newly created asset to</param>
        /// <param name="assetName">(string, required) Asset name, if not "" should be unique</param>
        /// <param name="quantity">The asset total amount in display units. eg. 1234.56</param>
        /// <param name="smallestUnit">Number of raw units in one displayed unit, eg 0.01 for cents. Default value is 1</param>
        /// <param name="nativeCurrencyAmount">native currency amount to send. eg 0.1, Default: minimum-per-output.</param>
        /// <param name="customFields">a dictionary object with custom fields. { "param-name": "param-value"   (strings, required) The key is the parameter name, the value is parameter value, ,... }</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> IssueFromAsync(string blockchainName,
                                                        string id,
                                                        string fromAddress,
                                                        string toAddress,
                                                        string assetName,
                                                        int quantity,
                                                        double smallestUnit = 1,
                                                        decimal nativeCurrencyAmount = 0,
                                                        Dictionary<string, string>? customFields = null) =>
            TransactAsync<string>(blockchainName, WalletAction.IssueFromMethod, id, fromAddress, toAddress, assetName, quantity, smallestUnit, nativeCurrencyAmount, customFields ?? new Dictionary<string, string>());

        /// <summary>
        ///
        /// <para>Issue a new Asset by name to an address on the blockchain network.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="fromAddress">Address used for issuing</param>
        /// <param name="toAddress">The address to send newly created asset to</param>
        /// <param name="assetName">(string, required) Asset name, if not "" should be unique</param>
        /// <param name="quantity">The asset total amount in display units. eg. 1234.56</param>
        /// <param name="smallestUnit">Number of raw units in one displayed unit, eg 0.01 for cents. Default value is 1</param>
        /// <param name="nativeCurrencyAmount">native currency amount to send. eg 0.1, Default: minimum-per-output.</param>
        /// <param name="customFields">a json object with custom fields. { "param-name": "param-value"   (strings, required) The key is the parameter name, the value is parameter value, ,... }</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> IssueFromAsync(string blockchainName,
                                                        string id,
                                                        string fromAddress,
                                                        string toAddress,
                                                        string assetName,
                                                        int quantity,
                                                        double smallestUnit = 1,
                                                        decimal nativeCurrencyAmount = 0,
                                                        object? customFields = null) =>
            TransactAsync<string>(blockchainName, WalletAction.IssueFromMethod, id, fromAddress, toAddress, assetName, quantity, smallestUnit, nativeCurrencyAmount, customFields ?? new { });

        /// <summary>
        ///
        /// <para>Issue a new AssetEntity model to an address on the blockchain network.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="fromAddress">Address used for issuing</param>
        /// <param name="toAddress">The address to send newly created asset to</param>
        /// <param name="assetParams">(AssetEntity type, required) A strongly typed object with asset params (string)name, (bool)open, and (string, comma delimited)restrict</param>
        /// <param name="quantity">The asset total amount in display units. eg. 1234.56</param>
        /// <param name="smallestUnit">Number of raw units in one displayed unit, eg 0.01 for cents. Default value is 1</param>
        /// <param name="nativeCurrencyAmount">native currency amount to send. eg 0.1, Default: minimum-per-output.</param>
        /// <param name="customFields">a dictionary object with custom fields. { "param-name": "param-value"   (strings, required) The key is the parameter name, the value is parameter value, ,... }</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> IssueFromAsync(string fromAddress,
                                                        string toAddress,
                                                        AssetEntity assetParams,
                                                        int quantity,
                                                        double smallestUnit = 1,
                                                        decimal nativeCurrencyAmount = 0,
                                                        Dictionary<string, string>? customFields = null) =>
            IssueFromAsync(RpcOptions.ChainName, UUID.NoHyphens, fromAddress, toAddress, assetParams, quantity, smallestUnit, nativeCurrencyAmount, customFields ?? new Dictionary<string, string>());

        /// <summary>
        ///
        /// <para>Issue a new AssetEntity model to an address on the blockchain network.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="fromAddress">Address used for issuing</param>
        /// <param name="toAddress">The address to send newly created asset to</param>
        /// <param name="assetParams">(AssetEntity type, required) A strongly typed object with asset params (string)name, (bool)open, and (string, comma delimited)restrict</param>
        /// <param name="quantity">The asset total amount in display units. eg. 1234.56</param>
        /// <param name="smallestUnit">Number of raw units in one displayed unit, eg 0.01 for cents. Default value is 1</param>
        /// <param name="nativeCurrencyAmount">native currency amount to send. eg 0.1, Default: minimum-per-output.</param>
        /// <param name="customFields">a json object with custom fields. { "param-name": "param-value"   (strings, required) The key is the parameter name, the value is parameter value, ,... }</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> IssueFromAsync(string fromAddress,
                                                        string toAddress,
                                                        AssetEntity assetParams,
                                                        int quantity,
                                                        double smallestUnit = 1,
                                                        decimal nativeCurrencyAmount = 0,
                                                        object? customFields = null) =>
            IssueFromAsync(RpcOptions.ChainName, UUID.NoHyphens, fromAddress, toAddress, assetParams, quantity, smallestUnit, nativeCurrencyAmount, customFields ?? new { });

        /// <summary>
        ///
        /// <para>Issue a new Asset using object params to an address on the blockchain network.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="fromAddress">Address used for issuing</param>
        /// <param name="toAddress">The address to send newly created asset to</param>
        /// <param name="assetParams">(object type, required) A generic object that must include asset params (string)name, (bool)open, and (string, comma delimited)restrict</param>
        /// <param name="quantity">The asset total amount in display units. eg. 1234.56</param>
        /// <param name="smallestUnit">Number of raw units in one displayed unit, eg 0.01 for cents. Default value is 1</param>
        /// <param name="nativeCurrencyAmount">native currency amount to send. eg 0.1, Default: minimum-per-output.</param>
        /// <param name="customFields">a dictionary object with custom fields. { "param-name": "param-value"   (strings, required) The key is the parameter name, the value is parameter value, ,... }</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> IssueFromAsync(string fromAddress,
                                                        string toAddress,
                                                        object assetParams,
                                                        int quantity,
                                                        double smallestUnit = 1,
                                                        decimal nativeCurrencyAmount = 0,
                                                        Dictionary<string, string>? customFields = null) =>
            IssueFromAsync(RpcOptions.ChainName, UUID.NoHyphens, fromAddress, toAddress, assetParams, quantity, smallestUnit, nativeCurrencyAmount, customFields ?? new Dictionary<string, string>());

        /// <summary>
        ///
        /// <para>Issue a new Asset using object params to an address on the blockchain network.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="fromAddress">Address used for issuing</param>
        /// <param name="toAddress">The address to send newly created asset to</param>
        /// <param name="assetParams">(object type, required) A generic object that must include asset params (string)name, (bool)open, and (string, comma delimited)restrict</param>
        /// <param name="quantity">The asset total amount in display units. eg. 1234.56</param>
        /// <param name="smallestUnit">Number of raw units in one displayed unit, eg 0.01 for cents. Default value is 1</param>
        /// <param name="nativeCurrencyAmount">native currency amount to send. eg 0.1, Default: minimum-per-output.</param>
        /// <param name="customFields">a json object with custom fields. { "param-name": "param-value"   (strings, required) The key is the parameter name, the value is parameter value, ,... }</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> IssueFromAsync(string fromAddress,
                                                        string toAddress,
                                                        object assetParams,
                                                        int quantity,
                                                        double smallestUnit = 1,
                                                        decimal nativeCurrencyAmount = 0,
                                                        object? customFields = null) =>
            IssueFromAsync(RpcOptions.ChainName, UUID.NoHyphens, fromAddress, toAddress, assetParams, quantity, smallestUnit, nativeCurrencyAmount, customFields ?? new { });

        /// <summary>
        ///
        /// <para>Issue a new Asset by name to an address on the blockchain network.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="fromAddress">Address used for issuing</param>
        /// <param name="toAddress">The address to send newly created asset to</param>
        /// <param name="assetName">(string, required) Asset name, if not "" should be unique</param>
        /// <param name="quantity">The asset total amount in display units. eg. 1234.56</param>
        /// <param name="smallestUnit">Number of raw units in one displayed unit, eg 0.01 for cents. Default value is 1</param>
        /// <param name="nativeCurrencyAmount">native currency amount to send. eg 0.1, Default: minimum-per-output.</param>
        /// <param name="customFields">a dictionary object with custom fields. { "param-name": "param-value"   (strings, required) The key is the parameter name, the value is parameter value, ,... }</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> IssueFromAsync(string fromAddress,
                                                        string toAddress,
                                                        string assetName,
                                                        int quantity,
                                                        double smallestUnit = 1,
                                                        decimal nativeCurrencyAmount = 0,
                                                        Dictionary<string, string>? customFields = null) =>
            IssueFromAsync(RpcOptions.ChainName, UUID.NoHyphens, fromAddress, toAddress, assetName, quantity, smallestUnit, nativeCurrencyAmount, customFields ?? new Dictionary<string, string>());

        /// <summary>
        ///
        /// <para>Issue a new Asset by name to an address on the blockchain network.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="fromAddress">Address used for issuing</param>
        /// <param name="toAddress">The address to send newly created asset to</param>
        /// <param name="assetName">(string, required) Asset name, if not "" should be unique</param>
        /// <param name="quantity">The asset total amount in display units. eg. 1234.56</param>
        /// <param name="smallestUnit">Number of raw units in one displayed unit, eg 0.01 for cents. Default value is 1</param>
        /// <param name="nativeCurrencyAmount">native currency amount to send. eg 0.1, Default: minimum-per-output.</param>
        /// <param name="customFields">a json object with custom fields. { "param-name": "param-value"   (strings, required) The key is the parameter name, the value is parameter value, ,... }</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> IssueFromAsync(string fromAddress,
                                                        string toAddress,
                                                        string assetName,
                                                        int quantity,
                                                        double smallestUnit = 1,
                                                        decimal nativeCurrencyAmount = 0,
                                                        object? customFields = null) =>
            IssueFromAsync(RpcOptions.ChainName, UUID.NoHyphens, fromAddress, toAddress, assetName, quantity, smallestUnit, nativeCurrencyAmount, customFields ?? new { });

        /// <summary>
        ///
        /// <para>Create more units for asset</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="toAddress">The address to send newly created asset to</param>
        /// <param name="assetIdentifier">One of the following: issue txid, asset reference, asset name</param>
        /// <param name="quantity">The asset total amount in display units. eg. 1234.56</param>
        /// <param name="nativeCurrencyAmount">native currency amount to send. eg 0.1, Default: minimum-per-output.</param>
        /// <param name="customFields">a dictionary object with custom fields. { "param-name": "param-value"   (strings, required) The key is the parameter name, the value is parameter value, ,... }</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> IssueMoreAsync(string blockchainName,
                                                        string id,
                                                        string toAddress,
                                                        string assetIdentifier,
                                                        int quantity,
                                                        decimal nativeCurrencyAmount = 0,
                                                        Dictionary<string, string>? customFields = null) =>
            TransactAsync<string>(blockchainName, WalletAction.IssueMoreMethod, id, toAddress, assetIdentifier, quantity, nativeCurrencyAmount, customFields ?? new Dictionary<string, string>());

        /// <summary>
        ///
        /// <para>Create more units for asset</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="toAddress">The address to send newly created asset to</param>
        /// <param name="assetIdentifier">One of the following: issue txid, asset reference, asset name</param>
        /// <param name="quantity">The asset total amount in display units. eg. 1234.56</param>
        /// <param name="nativeCurrencyAmount">native currency amount to send. eg 0.1, Default: minimum-per-output.</param>
        /// <param name="customFields">a json object with custom fields. { "param-name": "param-value"   (strings, required) The key is the parameter name, the value is parameter value, ,... }</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> IssueMoreAsync(string blockchainName,
                                                        string id,
                                                        string toAddress,
                                                        string assetIdentifier,
                                                        int quantity,
                                                        decimal nativeCurrencyAmount = 0,
                                                        object? customFields = null) =>
            TransactAsync<string>(blockchainName, WalletAction.IssueMoreMethod, id, toAddress, assetIdentifier, quantity, nativeCurrencyAmount, customFields ?? new { });

        /// <summary>
        ///
        /// <para>Create more units for asset</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="toAddress">The address to send newly created asset to</param>
        /// <param name="assetIdentifier">One of the following: issue txid, asset reference, asset name</param>
        /// <param name="quantity">The asset total amount in display units. eg. 1234.56</param>
        /// <param name="nativeCurrencyAmount">native currency amount to send. eg 0.1, Default: minimum-per-output.</param>
        /// <param name="customFields">a dictionary object with custom fields. { "param-name": "param-value"   (strings, required) The key is the parameter name, the value is parameter value, ,... }</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> IssueMoreAsync(string toAddress,
                                                        string assetIdentifier,
                                                        int quantity,
                                                        decimal nativeCurrencyAmount = 0,
                                                        Dictionary<string, string>? customFields = null) =>
            IssueMoreAsync(RpcOptions.ChainName, UUID.NoHyphens, toAddress, assetIdentifier, quantity, nativeCurrencyAmount, customFields ?? new Dictionary<string, string>());

        /// <summary>
        ///
        /// <para>Create more units for asset</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="toAddress">The address to send newly created asset to</param>
        /// <param name="assetIdentifier">One of the following: issue txid, asset reference, asset name</param>
        /// <param name="quantity">The asset total amount in display units. eg. 1234.56</param>
        /// <param name="nativeCurrencyAmount">native currency amount to send. eg 0.1, Default: minimum-per-output.</param>
        /// <param name="customFields">a json object with custom fields. { "param-name": "param-value"   (strings, required) The key is the parameter name, the value is parameter value, ,... }</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> IssueMoreAsync(string toAddress,
                                                        string assetIdentifier,
                                                        int quantity,
                                                        decimal nativeCurrencyAmount = 0,
                                                        object? customFields = null) =>
            IssueMoreAsync(RpcOptions.ChainName, UUID.NoHyphens, toAddress, assetIdentifier, quantity, nativeCurrencyAmount, customFields ?? new { });

        /// <summary>
        ///
        /// <para>Create more units for asset from specific address</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="fromAddress">Address used for issuing</param>
        /// <param name="toAddress">The address to send newly created asset to</param>
        /// <param name="assetIdentifier">One of the following: issue txid, asset reference, asset name</param>
        /// <param name="quantity">The asset total amount in display units. eg. 1234.56</param>
        /// <param name="nativeCurrencyAmount">native currency amount to send. eg 0.1, Default: minimum-per-output.</param>
        /// <param name="customFields">a dictionary object with custom fields. { "param-name": "param-value"   (strings, required) The key is the parameter name, the value is parameter value, ,... }</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> IssueMoreFromAsync(string blockchainName,
                                                            string id,
                                                            string fromAddress,
                                                            string toAddress,
                                                            string assetIdentifier,
                                                            int quantity,
                                                            decimal nativeCurrencyAmount = 0,
                                                            Dictionary<string, string>? customFields = null) =>
            TransactAsync<string>(blockchainName, WalletAction.IssueMoreFromMethod, id, fromAddress, toAddress, assetIdentifier, quantity, nativeCurrencyAmount, customFields ?? new Dictionary<string, string>());

        /// <summary>
        ///
        /// <para>Create more units for asset from specific address</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="fromAddress">Address used for issuing</param>
        /// <param name="toAddress">The address to send newly created asset to</param>
        /// <param name="assetIdentifier">One of the following: issue txid, asset reference, asset name</param>
        /// <param name="quantity">The asset total amount in display units. eg. 1234.56</param>
        /// <param name="nativeCurrencyAmount">native currency amount to send. eg 0.1, Default: minimum-per-output.</param>
        /// <param name="customFields">a json object with custom fields. { "param-name": "param-value"   (strings, required) The key is the parameter name, the value is parameter value, ,... }</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> IssueMoreFromAsync(string blockchainName,
                                                            string id,
                                                            string fromAddress,
                                                            string toAddress,
                                                            string assetIdentifier,
                                                            int quantity,
                                                            decimal nativeCurrencyAmount = 0,
                                                            object? customFields = null) =>
            TransactAsync<string>(blockchainName, WalletAction.IssueMoreFromMethod, id, fromAddress, toAddress, assetIdentifier, quantity, nativeCurrencyAmount, customFields ?? new { });

        /// <summary>
        ///
        /// <para>Create more units for asset from specific address</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="fromAddress">Address used for issuing</param>
        /// <param name="toAddress">The address to send newly created asset to</param>
        /// <param name="assetIdentifier">One of the following: issue txid, asset reference, asset name</param>
        /// <param name="quantity">The asset total amount in display units. eg. 1234.56</param>
        /// <param name="nativeCurrencyAmount">native currency amount to send. eg 0.1, Default: minimum-per-output.</param>
        /// <param name="customFields">a dictionary object with custom fields. { "param-name": "param-value"   (strings, required) The key is the parameter name, the value is parameter value, ,... }</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> IssueMoreFromAsync(string fromAddress,
                                                            string toAddress,
                                                            string assetIdentifier,
                                                            int quantity,
                                                            decimal nativeCurrencyAmount = 0,
                                                            Dictionary<string, string>? customFields = null) =>
            IssueMoreFromAsync(RpcOptions.ChainName, UUID.NoHyphens, fromAddress, toAddress, assetIdentifier, quantity, nativeCurrencyAmount, customFields ?? new Dictionary<string, string>());

        /// <summary>
        ///
        /// <para>Create more units for asset from specific address</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="fromAddress">Address used for issuing</param>
        /// <param name="toAddress">The address to send newly created asset to</param>
        /// <param name="assetIdentifier">One of the following: issue txid, asset reference, asset name</param>
        /// <param name="quantity">The asset total amount in display units. eg. 1234.56</param>
        /// <param name="nativeCurrencyAmount">native currency amount to send. eg 0.1, Default: minimum-per-output.</param>
        /// <param name="customFields">a json object with custom fields. { "param-name": "param-value"   (strings, required) The key is the parameter name, the value is parameter value, ,... }</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> IssueMoreFromAsync(string fromAddress,
                                                            string toAddress,
                                                            string assetIdentifier,
                                                            int quantity,
                                                            decimal nativeCurrencyAmount = 0,
                                                            object? customFields = null) =>
            IssueMoreFromAsync(RpcOptions.ChainName, UUID.NoHyphens, fromAddress, toAddress, assetIdentifier, quantity, nativeCurrencyAmount, customFields ?? new { });

        /// <summary>
        ///
        /// <para>Fills the keypool.</para>
        /// <para>Requires wallet passphrase to be set with walletpassphrase call.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="new_size">The new keypool size</param>
        /// <returns></returns>
        public Task<RpcResponse> KeyPoolRefillAsync(string blockchainName, string id, int new_size = 100) =>
            TransactAsync(blockchainName, WalletAction.KeyPoolRefillMethod, id, new_size);

        /// <summary>
        ///
        /// <para>Fills the keypool.</para>
        /// <para>Requires wallet passphrase to be set with walletpassphrase call.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="new_size">The new keypool size</param>
        /// <returns></returns>
        public Task<RpcResponse> KeyPoolRefillAsync(int new_size = 100) =>
            KeyPoolRefillAsync(RpcOptions.ChainName, UUID.NoHyphens, new_size);

        /// <summary>
        ///
        /// <para>Returns Object that has account names as keys, account balances as values.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="min_conf"> Only include transactions with at least this many confirmations</param>
        /// <param name="include_watch_only">Include balances in watchonly addresses (see 'importaddress')</param>
        /// <returns></returns>
        public Task<RpcResponse<Dictionary<string, double>>> ListAccountsAsync(string blockchainName, string id, int min_conf = 1, bool include_watch_only = false) =>
            TransactAsync<Dictionary<string, double>>(blockchainName, WalletAction.ListAccountsMethod, id, min_conf, include_watch_only);

        /// <summary>
        ///
        /// <para>Returns Object that has account names as keys, account balances as values.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="min_conf"> Only include transactions with at least this many confirmations</param>
        /// <param name="include_watch_only">Include balances in watchonly addresses (see 'importaddress')</param>
        /// <returns></returns>
        public Task<RpcResponse<Dictionary<string, double>>> ListAccountsAsync(int min_conf = 1, bool include_watch_only = false) =>
            ListAccountsAsync(RpcOptions.ChainName, UUID.NoHyphens, min_conf, include_watch_only);

        /// <summary>
        ///
        /// Returns asset balances for specified address
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="addresses">(string, optional, default *) Address(es) to return information for, comma delimited. Default - all or (array, optional) A json array of addresses to return information for</param>
        /// <param name="verbose">If true return more information about address.</param>
        /// <param name="count">The number of addresses to display</param>
        /// <param name="start">Start from specific address, 0 based, if negative - from the end</param>
        /// <returns></returns>
        public Task<RpcResponse<IList<ListAddressesResult>>> ListAddressesAsync(string blockchainName, string id, [Optional] object addresses, [Optional] bool verbose, [Optional] int count, [Optional] int start) =>
            TransactAsync<IList<ListAddressesResult>>(blockchainName, WalletAction.ListAddressesMethod, id, addresses, verbose, count, start);

        /// <summary>
        ///
        /// Returns asset balances for specified address
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="addresses">(string, optional, default *) Address(es) to return information for, comma delimited. Default - all or (array, optional) A json array of addresses to return information for</param>
        /// <param name="verbose">If true return more information about address.</param>
        /// <param name="count">The number of addresses to display</param>
        /// <param name="start">Start from specific address, 0 based, if negative - from the end</param>
        /// <returns></returns>
        public Task<RpcResponse<IList<ListAddressesResult>>> ListAddressesAsync([Optional] object addresses, [Optional] bool verbose, [Optional] int count, [Optional] int start) =>
            ListAddressesAsync(RpcOptions.ChainName, UUID.NoHyphens, addresses, verbose, count, start);

        /// <summary>
        ///
        /// <para>Lists groups of addresses which have had their common ownership made public by common use as inputs or as the resulting change in past transactions</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <returns></returns>
        public Task<RpcResponse<IList<object>>> ListAddressGroupingsAsync(string blockchainName, string id) =>
            TransactAsync<IList<object>>(blockchainName, WalletAction.ListAddressGroupingsMethod, id);

        /// <summary>
        ///
        /// <para>Lists groups of addresses which have had their common ownership made public by common use as inputs or as the resulting change in past transactions</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <returns></returns>
        public Task<RpcResponse<IList<object>>> ListAddressGroupingsAsync() =>
            ListAddressGroupingsAsync(RpcOptions.ChainName, UUID.NoHyphens);

        /// <summary>
        ///
        /// Lists information about the count most recent transactions related to address in this nodeΓÇÖs wallet.
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="address">Address to list transactions for</param>
        /// <param name="count">The number of transactions to return</param>
        /// <param name="skip">The number of transactions to skip</param>
        /// <param name="verbose">If true, returns detailed array of inputs and outputs and raw hex of transactions</param>
        /// <returns></returns>
        public Task<RpcResponse<IList<ListAddressTransactionsResult>>> ListAddressTransactionsAsync(string blockchainName, string id, string address, int count = 10, int skip = 0, bool verbose = false) =>
            TransactAsync<IList<ListAddressTransactionsResult>>(blockchainName, WalletAction.ListAddressTransactionsMethod, id, address, count, skip, verbose);

        /// <summary>
        ///
        /// Lists information about the count most recent transactions related to address in this nodeΓÇÖs wallet.
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="address">Address to list transactions for</param>
        /// <param name="count">The number of transactions to return</param>
        /// <param name="skip">The number of transactions to skip</param>
        /// <param name="verbose">If true, returns detailed array of inputs and outputs and raw hex of transactions</param>
        /// <returns></returns>
        public Task<RpcResponse<IList<ListAddressTransactionsResult>>> ListAddressTransactionsAsync(string address, int count = 10, int skip = 0, bool verbose = false) =>
            ListAddressTransactionsAsync(RpcOptions.ChainName, UUID.NoHyphens, address, count, skip, verbose);

        /// <summary>
        ///
        /// Lists transactions involving asset.
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="asset_identifier">One of the following: asset txid, asset reference, asset name</param>
        /// <param name="verbose">If true, returns information about transaction</param>
        /// <param name="count">The number of transactions to display</param>
        /// <param name="start">Start from specific transaction, 0 based, if negative - from the end</param>
        /// <param name="local_ordering">If true, transactions appear in the order they were processed by the wallet, if false - in the order they appear in blockchain</param>
        /// <returns></returns>
        public Task<RpcResponse<IList<ListAssetTransactionsResult>>> ListAssetTransactionsAsync(string blockchainName, string id, string asset_identifier, bool verbose = false, int count = 10, int start = 0, bool local_ordering = false) =>
            TransactAsync<IList<ListAssetTransactionsResult>>(blockchainName, WalletAction.ListAssetTransactionsMethod, id, asset_identifier, verbose, count, start, local_ordering);

        /// <summary>
        ///
        /// Lists transactions involving asset.
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="asset_identifier">One of the following: asset txid, asset reference, asset name</param>
        /// <param name="verbose">If true, returns information about transaction</param>
        /// <param name="count">The number of transactions to display</param>
        /// <param name="start">Start from specific transaction, 0 based, if negative - from the end</param>
        /// <param name="local_ordering">If true, transactions appear in the order they were processed by the wallet, if false - in the order they appear in blockchain</param>
        /// <returns></returns>
        public Task<RpcResponse<IList<ListAssetTransactionsResult>>> ListAssetTransactionsAsync(string asset_identifier, bool verbose = false, int count = 10, int start = 0, bool local_ordering = false) =>
            ListAssetTransactionsAsync(RpcOptions.ChainName, UUID.NoHyphens, asset_identifier, verbose, count, start, local_ordering);

        /// <summary>
        ///
        /// Returns list of temporarily unspendable outputs.
        /// <para>See the lockunspent call to lock and unlock transactions for spending.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <returns></returns>
        public Task<RpcResponse<IList<Transaction>>> ListLockUnspentAsync(string blockchainName, string id) =>
            TransactAsync<IList<Transaction>>(blockchainName, WalletAction.ListLockUnspentMethod, id);

        /// <summary>
        ///
        /// Returns list of temporarily unspendable outputs.
        /// <para>See the lockunspent call to lock and unlock transactions for spending.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <returns></returns>
        public Task<RpcResponse<IList<Transaction>>> ListLockUnspentAsync() =>
            ListLockUnspentAsync(RpcOptions.ChainName, UUID.NoHyphens);

        /// <summary>
        ///
        /// List balances by account.
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="min_conf">The minimum number of confirmations before payments are included</param>
        /// <param name="include_empty">Whether to include accounts that haven't received any payments</param>
        /// <param name="include_watch_only">Whether to include watchonly addresses (see 'importaddress')</param>
        /// <returns></returns>
        public Task<RpcResponse<IList<object>>> ListReceivedByAccountAsync(string blockchainName, string id, int min_conf = 1, bool include_empty = false, bool include_watch_only = false) =>
            TransactAsync<IList<object>>(blockchainName, WalletAction.ListReceivedByAccountMethod, id, min_conf, include_empty, include_watch_only);

        /// <summary>
        ///
        /// List balances by account.
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="min_conf">The minimum number of confirmations before payments are included</param>
        /// <param name="include_empty">Whether to include accounts that haven't received any payments</param>
        /// <param name="include_watch_only">Whether to include watchonly addresses (see 'importaddress')</param>
        /// <returns></returns>
        public Task<RpcResponse<IList<object>>> ListReceivedByAccountAsync(int min_conf = 1, bool include_empty = false, bool include_watch_only = false) =>
            ListReceivedByAccountAsync(RpcOptions.ChainName, UUID.NoHyphens, min_conf, include_empty, include_watch_only);

        /// <summary>
        ///
        /// List balances by receiving address.
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="min_conf">The minimum number of confirmations before payments are included</param>
        /// <param name="include_empty">Whether to include accounts that haven't received any payments</param>
        /// <param name="include_watch_only">Whether to include watchonly addresses (see 'importaddress')</param>
        /// <returns></returns>
        public Task<RpcResponse<IList<object>>> ListReceivedByAddressAsync(string blockchainName, string id, int min_conf = 1, bool include_empty = false, bool include_watch_only = false) =>
            TransactAsync<IList<object>>(blockchainName, WalletAction.ListReceivedByAddressMethod, id, min_conf, include_empty, include_watch_only);

        /// <summary>
        ///
        /// List balances by receiving address.
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="min_conf">The minimum number of confirmations before payments are included</param>
        /// <param name="include_empty">Whether to include accounts that haven't received any payments</param>
        /// <param name="include_watch_only">Whether to include watchonly addresses (see 'importaddress')</param>
        /// <returns></returns>
        public Task<RpcResponse<IList<object>>> ListReceivedByAddressAsync(int min_conf = 1, bool include_empty = false, bool include_watch_only = false) =>
            ListReceivedByAddressAsync(RpcOptions.ChainName, UUID.NoHyphens, min_conf, include_empty, include_watch_only);

        /// <summary>
        ///
        /// Get all transactions in blocks since block [blockhash], or all transactions if omitted
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="block_hash">The block hash to list transactions since</param>
        /// <param name="target_confirmations">The confirmations required, must be 1 or more</param>
        /// <param name="include_watch_only">Include transactions to watchonly addresses (see 'importaddress')</param>
        /// <returns></returns>
        public Task<RpcResponse> ListSinceBlockAsync(string blockchainName, string id, [Optional] string block_hash, [Optional] int target_confirmations, [Optional] bool include_watch_only) =>
            TransactAsync(blockchainName, WalletAction.ListSinceBlockMethod, id, block_hash, target_confirmations, include_watch_only);

        /// <summary>
        ///
        /// Get all transactions in blocks since block [blockhash], or all transactions if omitted
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="block_hash">The block hash to list transactions since</param>
        /// <param name="target_confirmations">The confirmations required, must be 1 or more</param>
        /// <param name="include_watch_only">Include transactions to watchonly addresses (see 'importaddress')</param>
        /// <returns></returns>
        public Task<RpcResponse> ListSinceBlockAsync([Optional] string block_hash, [Optional] int target_confirmations, [Optional] bool include_watch_only) =>
            ListSinceBlockAsync(RpcOptions.ChainName, UUID.NoHyphens, block_hash, target_confirmations, include_watch_only);

        /// <summary>
        ///
        /// Returns stream items in certain block range.
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="stream_identifier">(string, required) Stream identifier - one of the following: stream txid, stream reference, stream name</param>
        /// <param name="block_set_identifier">(string, required) Comma delimited list of block identifiers or A json array of block identifiers or A json object with time range</param>
        /// <param name="verbose">If true, returns information about item transaction</param>
        /// <param name="count">The number of items to display</param>
        /// <param name="start">Start from specific item, 0 based, if negative - from the end</param>
        /// <returns></returns>
        public Task<RpcResponse<IList<object>>> ListStreamBlockItemsAsync(string blockchainName, string id, string stream_identifier, object block_set_identifier, [Optional] bool verbose, [Optional] int count, [Optional] int start) =>
            TransactAsync<IList<object>>(blockchainName, WalletAction.ListStreamBlockItemsMethod, id, stream_identifier, block_set_identifier, verbose, count, start);

        /// <summary>
        ///
        /// Returns stream items in certain block range.
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="stream_identifier">(string, required) Stream identifier - one of the following: stream txid, stream reference, stream name</param>
        /// <param name="block_set_identifier">(string, required) Comma delimited list of block identifiers or A json array of block identifiers or A json object with time range</param>
        /// <param name="verbose">If true, returns information about item transaction</param>
        /// <param name="count">The number of items to display</param>
        /// <param name="start">Start from specific item, 0 based, if negative - from the end</param>
        /// <returns></returns>
        public Task<RpcResponse<IList<object>>> ListStreamBlockItemsAsync(string stream_identifier, object block_set_identifier, [Optional] bool verbose, [Optional] int count, [Optional] int start) =>
            ListStreamBlockItemsAsync(RpcOptions.ChainName, UUID.NoHyphens, stream_identifier, block_set_identifier, verbose, count, start);

        /// <summary>
        ///
        /// Returns stream items.
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="stream_identifier">One of the following: stream txid, stream reference, stream name</param>
        /// <param name="verbose">If true, returns information about item transaction</param>
        /// <param name="count">The number of items to display</param>
        /// <param name="start">Start from specific item, 0 based, if negative - from the end</param>
        /// <param name="local_ordering">If true, items appear in the order they were processed by the wallet, if false - in the order they appear in blockchain</param>
        /// <returns></returns>
        public Task<RpcResponse<IList<ListStreamItemsResult>>> ListStreamItemsAsync(string blockchainName, string id, string stream_identifier, [Optional] bool verbose, [Optional] int count, [Optional] int start, [Optional] bool local_ordering) =>
            TransactAsync<IList<ListStreamItemsResult>>(blockchainName, WalletAction.ListStreamItemsMethod, id, stream_identifier, verbose, count, start, local_ordering);

        /// <summary>
        ///
        /// Returns stream items.
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="stream_identifier">One of the following: stream txid, stream reference, stream name</param>
        /// <param name="verbose">If true, returns information about item transaction</param>
        /// <param name="count">The number of items to display</param>
        /// <param name="start">Start from specific item, 0 based, if negative - from the end</param>
        /// <param name="local_ordering">If true, items appear in the order they were processed by the wallet, if false - in the order they appear in blockchain</param>
        /// <returns></returns>
        public Task<RpcResponse<IList<ListStreamItemsResult>>> ListStreamItemsAsync(string stream_identifier, [Optional] bool verbose, [Optional] int count, [Optional] int start, [Optional] bool local_ordering) =>
            ListStreamItemsAsync(RpcOptions.ChainName, UUID.NoHyphens, stream_identifier, verbose, count, start, local_ordering);

        /// <summary>
        ///
        /// Returns stream items for specific key.
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="stream_identifier">One of the following: stream txid, stream reference, stream name</param>
        /// <param name="key">Stream key</param>
        /// <param name="verbose">If true, returns information about item transaction</param>
        /// <param name="count">The number of items to display</param>
        /// <param name="start">Start from specific item, 0 based, if negative - from the end</param>
        /// <param name="local_ordering">If true, items appear in the order they were processed by the wallet, if false - in the order they appear in blockchain</param>
        /// <returns></returns>
        public Task<RpcResponse<IList<ListStreamKeyItemsResult>>> ListStreamKeyItemsAsync(string blockchainName, string id, string stream_identifier, string key, [Optional] bool verbose, [Optional] int count, [Optional] int start, [Optional] bool local_ordering) =>
            TransactAsync<IList<ListStreamKeyItemsResult>>(blockchainName, WalletAction.ListStreamKeyItemsMethod, id, stream_identifier, key, verbose, count, start, local_ordering);

        /// <summary>
        ///
        /// Returns stream items for specific key.
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="stream_identifier">One of the following: stream txid, stream reference, stream name</param>
        /// <param name="key">Stream key</param>
        /// <param name="verbose">If true, returns information about item transaction</param>
        /// <param name="count">The number of items to display</param>
        /// <param name="start">Start from specific item, 0 based, if negative - from the end</param>
        /// <param name="local_ordering">If true, items appear in the order they were processed by the wallet, if false - in the order they appear in blockchain</param>
        /// <returns></returns>
        public Task<RpcResponse<IList<ListStreamKeyItemsResult>>> ListStreamKeyItemsAsync(string stream_identifier, string key, [Optional] bool verbose, [Optional] int count, [Optional] int start, [Optional] bool local_ordering) =>
            ListStreamKeyItemsAsync(RpcOptions.ChainName, UUID.NoHyphens, stream_identifier, key, verbose, count, start, local_ordering);

        /// <summary>
        ///
        /// Returns stream keys.
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="stream_identifier">One of the following: stream txid, stream reference, stream name</param>
        /// <param name="keys">Stream key or a json array of stream keys</param>
        /// <param name="verbose">If true, returns information about item transaction</param>
        /// <param name="count">The number of items to display</param>
        /// <param name="start">Start from specific item, 0 based, if negative - from the end</param>
        /// <param name="local_ordering">If true, items appear in the order they were processed by the wallet, if false - in the order they appear in blockchain</param>
        /// <returns></returns>
        public Task<RpcResponse<IList<ListStreamKeysResult>>> ListStreamKeysAsync(string blockchainName, string id, string stream_identifier, object keys, [Optional] bool verbose, [Optional] int count, [Optional] int start, [Optional] bool local_ordering) =>
            TransactAsync<IList<ListStreamKeysResult>>(blockchainName, WalletAction.ListStreamKeysMethod, id, stream_identifier, keys, verbose, count, start, local_ordering);

        /// <summary>
        ///
        /// Returns stream keys.
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="stream_identifier">One of the following: stream txid, stream reference, stream name</param>
        /// <param name="keys">Stream key or a json array of stream keys</param>
        /// <param name="verbose">If true, returns information about item transaction</param>
        /// <param name="count">The number of items to display</param>
        /// <param name="start">Start from specific item, 0 based, if negative - from the end</param>
        /// <param name="local_ordering">If true, items appear in the order they were processed by the wallet, if false - in the order they appear in blockchain</param>
        /// <returns></returns>
        public Task<RpcResponse<IList<ListStreamKeysResult>>> ListStreamKeysAsync(string stream_identifier, object keys, [Optional] bool verbose, [Optional] int count, [Optional] int start, [Optional] bool local_ordering) =>
            ListStreamKeysAsync(RpcOptions.ChainName, UUID.NoHyphens, stream_identifier, keys, verbose, count, start, local_ordering);

        /// <summary>
        ///
        /// Returns stream items for specific publisher.
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="stream_identifiers">One of the following: stream txid, stream reference, stream name</param>
        /// <param name="address">Publisher address</param>
        /// <param name="verbose">If true, returns information about item transaction</param>
        /// <param name="count">The number of items to display</param>
        /// <param name="start">Start from specific item, 0 based, if negative - from the end</param>
        /// <param name="local_ordering">If true, items appear in the order they were processed by the wallet, if false - in the order they appear in blockchain</param>
        /// <returns></returns>
        public Task<RpcResponse<IList<ListStreamPublisherItemsResult>>> ListStreamPublisherItemsAsync(string blockchainName, string id, string stream_identifiers, string address, [Optional] bool verbose, [Optional] int count, [Optional] int start, [Optional] bool local_ordering) =>
            TransactAsync<IList<ListStreamPublisherItemsResult>>(blockchainName, WalletAction.ListStreamPublisherItemsMethod, id, stream_identifiers, address, verbose, count, start, local_ordering);

        /// <summary>
        ///
        /// Returns stream items for specific publisher.
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="stream_identifiers">One of the following: stream txid, stream reference, stream name</param>
        /// <param name="address">Publisher address</param>
        /// <param name="verbose">If true, returns information about item transaction</param>
        /// <param name="count">The number of items to display</param>
        /// <param name="start">Start from specific item, 0 based, if negative - from the end</param>
        /// <param name="local_ordering">If true, items appear in the order they were processed by the wallet, if false - in the order they appear in blockchain</param>
        /// <returns></returns>
        public Task<RpcResponse<IList<ListStreamPublisherItemsResult>>> ListStreamPublisherItemsAsync(string stream_identifiers, string address, [Optional] bool verbose, [Optional] int count, [Optional] int start, [Optional] bool local_ordering) =>
            ListStreamPublisherItemsAsync(RpcOptions.ChainName, UUID.NoHyphens, stream_identifiers, address, verbose, count, start, local_ordering);

        /// <summary>
        ///
        /// Returns stream publishers.
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="stream_identifier">One of the following: stream txid, stream reference, stream name</param>
        /// <param name="addresses">Publisher addresses, comma delimited or a json array of publisher addresses</param>
        /// <param name="verbose">If true, returns information about item transaction</param>
        /// <param name="count">The number of items to display</param>
        /// <param name="start">Start from specific item, 0 based, if negative - from the end</param>
        /// <param name="local_ordering">If true, items appear in the order they were processed by the wallet, if false - in the order they appear in blockchain</param>
        /// <returns></returns>
        public Task<RpcResponse<IList<ListStreamPublishersResult>>> ListStreamPublishersAsync(string blockchainName, string id, string stream_identifier, object addresses, [Optional] bool verbose, [Optional] int count, [Optional] int start, [Optional] bool local_ordering) =>
            TransactAsync<IList<ListStreamPublishersResult>>(blockchainName, WalletAction.ListStreamPublishersMethod, id, stream_identifier, addresses, verbose, count, start, local_ordering);

        /// <summary>
        ///
        /// Returns stream publishers.
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="stream_identifier">One of the following: stream txid, stream reference, stream name</param>
        /// <param name="addresses">Publisher addresses, comma delimited or a json array of publisher addresses</param>
        /// <param name="verbose">If true, returns information about item transaction</param>
        /// <param name="count">The number of items to display</param>
        /// <param name="start">Start from specific item, 0 based, if negative - from the end</param>
        /// <param name="local_ordering">If true, items appear in the order they were processed by the wallet, if false - in the order they appear in blockchain</param>
        /// <returns></returns>
        public Task<RpcResponse<IList<ListStreamPublishersResult>>> ListStreamPublishersAsync(string stream_identifier, object addresses, [Optional] bool verbose, [Optional] int count, [Optional] int start, [Optional] bool local_ordering) =>
            ListStreamPublishersAsync(RpcOptions.ChainName, UUID.NoHyphens, stream_identifier, addresses, verbose, count, start, local_ordering);

        /// <summary>
        ///
        /// Returns stream items for specific query.
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="stream_identifier">One of the following: stream txid, stream reference, stream name</param>
        /// <param name="query">Query { "key" : "key" (string, optional, default: "") Item key, or "keys" : keys (array, optional) Item keys, array of strings, and or  "publisher" : "publisher" (string, optional, default: "") Publisher or "publishers" : publishers (array, optional) Publishers, array of strings }</param>
        /// <param name="verbose">If true, returns information about item transaction</param>
        /// <returns></returns>
        public Task<RpcResponse<IList<object>>> ListStreamQueryItemsAsync(string blockchainName, string id, string stream_identifier, object query, bool verbose = false) =>
            TransactAsync<IList<object>>(blockchainName, WalletAction.ListStreamQueryItemsMethod, id, stream_identifier, query, verbose);

        /// <summary>
        ///
        /// Returns stream items for specific query.
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="stream_identifier">One of the following: stream txid, stream reference, stream name</param>
        /// <param name="query">Query { "key" : "key" (string, optional, default: "") Item key, or "keys" : keys (array, optional) Item keys, array of strings, and or  "publisher" : "publisher" (string, optional, default: "") Publisher or "publishers" : publishers (array, optional) Publishers, array of strings }</param>
        /// <param name="verbose">If true, returns information about item transaction</param>
        /// <returns></returns>
        public Task<RpcResponse<IList<object>>> ListStreamQueryItemsAsync(string stream_identifier, object query, bool verbose = false) =>
            ListStreamQueryItemsAsync(RpcOptions.ChainName, UUID.NoHyphens, stream_identifier, query, verbose);

        /// <summary>
        ///
        /// Returns stream items.
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="stream_identifiers">One of the following: stream txid, stream reference, stream name</param>
        /// <param name="txids"> Transaction IDs, comma delimited or Array of transaction IDs</param>
        /// <param name="verbose">If true, returns information about item transaction</param>
        /// <returns></returns>
        public Task<RpcResponse<IList<object>>> ListStreamTxItemsAsync(string blockchainName, string id, string stream_identifiers, object txids, bool verbose = false) =>
            TransactAsync<IList<object>>(blockchainName, WalletAction.ListStreamTxItemsMethod, id, stream_identifiers, txids, verbose);

        /// <summary>
        ///
        /// Returns stream items.
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="stream_identifiers">One of the following: stream txid, stream reference, stream name</param>
        /// <param name="txids"> Transaction IDs, comma delimited or Array of transaction IDs</param>
        /// <param name="verbose">If true, returns information about item transaction</param>
        /// <returns></returns>
        public Task<RpcResponse<IList<object>>> ListStreamTxItemsAsync(string stream_identifiers, object txids, bool verbose = false) =>
            ListStreamTxItemsAsync(RpcOptions.ChainName, UUID.NoHyphens, stream_identifiers, txids, verbose);

        /// <summary>
        ///
        /// Returns up to 'count' most recent transactions skipping the first 'from' transactions for account 'account'.
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="account">The account name. If not included, it will list all transactions for all accounts. If "" is set, it will list transactions for the default account.</param>
        /// <param name="count">The number of transactions to return</param>
        /// <param name="from">The number of transactions to skip</param>
        /// <param name="include_watch_only">Include transactions to watchonly addresses (see 'importaddress')</param>
        /// <returns></returns>
        public Task<RpcResponse<IList<ListTransactionsResult>>> ListTransactionsAsync(string blockchainName, string id, [Optional] string account, [Optional] int count, [Optional] int from, [Optional] bool include_watch_only) =>
            TransactAsync<IList<ListTransactionsResult>>(blockchainName, WalletAction.ListTransactionsMethod, id, account, count, from, include_watch_only);

        /// <summary>
        ///
        /// Returns up to 'count' most recent transactions skipping the first 'from' transactions for account 'account'.
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="account">The account name. If not included, it will list all transactions for all accounts. If "" is set, it will list transactions for the default account.</param>
        /// <param name="count">The number of transactions to return</param>
        /// <param name="from">The number of transactions to skip</param>
        /// <param name="include_watch_only">Include transactions to watchonly addresses (see 'importaddress')</param>
        /// <returns></returns>
        public Task<RpcResponse<IList<ListTransactionsResult>>> ListTransactionsAsync([Optional] string account, [Optional] int count, [Optional] int from, [Optional] bool include_watch_only) =>
            ListTransactionsAsync(RpcOptions.ChainName, UUID.NoHyphens, account, count, from, include_watch_only);

        /// <summary>
        ///
        /// Returns array of unspent transaction outputs with between minconf and maxconf (inclusive) confirmations.
        ///
        /// <para>Optionally filter to only include txouts paid to specified addresses.</para>
        /// <para>Results are an array of Objects, each of which has: {txid, vout, scriptPubKey, amount, confirmations}</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="min_conf">The minimum confirmations to filter</param>
        /// <param name="max_conf">The maximum confirmations to filter</param>
        /// <param name="addresses">A json array of addresses to filter</param>
        /// <returns></returns>
        public Task<RpcResponse<IList<ListUnspentResult>>> ListUnspentAsync(string blockchainName, string id, [Optional] int min_conf, [Optional] int max_conf, [Optional] object addresses) =>
            TransactAsync<IList<ListUnspentResult>>(blockchainName, WalletAction.ListUnspentMethod, id, min_conf, max_conf, addresses);

        /// <summary>
        ///
        /// Returns array of unspent transaction outputs with between minconf and maxconf (inclusive) confirmations.
        ///
        /// <para>Optionally filter to only include txouts paid to specified addresses.</para>
        /// <para>Results are an array of Objects, each of which has: {txid, vout, scriptPubKey, amount, confirmations}</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="min_conf">The minimum confirmations to filter</param>
        /// <param name="max_conf">The maximum confirmations to filter</param>
        /// <param name="addresses">A json array of addresses to filter</param>
        /// <returns></returns>
        public Task<RpcResponse<IList<ListUnspentResult>>> ListUnspentAsync([Optional] int min_conf, [Optional] int max_conf, [Optional] object addresses) =>
            ListUnspentAsync(RpcOptions.ChainName, UUID.NoHyphens, min_conf, max_conf, addresses);

        /// <summary>
        ///
        /// Lists information about the count most recent transactions in this nodeΓÇÖs wallet.
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="count">The number of transactions to return</param>
        /// <param name="skip">The number of transactions to skip</param>
        /// <param name="include_watch_only">Include transactions to watchonly addresses (see 'importaddress')</param>
        /// <param name="verbose">If true, returns detailed array of inputs and outputs and raw hex of transactions</param>
        /// <returns></returns>
        public Task<RpcResponse<IList<ListWalletTransactionsResult>>> ListWalletTransactionsAsync(string blockchainName, string id, int count = 10, int skip = 0, bool include_watch_only = false, bool verbose = false) =>
            TransactAsync<IList<ListWalletTransactionsResult>>(blockchainName, WalletAction.ListWalletTransactionsMethod, id, count, skip, include_watch_only, verbose);

        /// <summary>
        ///
        /// Lists information about the count most recent transactions in this nodeΓÇÖs wallet.
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="count">The number of transactions to return</param>
        /// <param name="skip">The number of transactions to skip</param>
        /// <param name="include_watch_only">Include transactions to watchonly addresses (see 'importaddress')</param>
        /// <param name="verbose">If true, returns detailed array of inputs and outputs and raw hex of transactions</param>
        /// <returns></returns>
        public Task<RpcResponse<IList<ListWalletTransactionsResult>>> ListWalletTransactionsAsync(int count = 10, int skip = 0, bool include_watch_only = false, bool verbose = false) =>
            ListWalletTransactionsAsync(RpcOptions.ChainName, UUID.NoHyphens, count, skip, include_watch_only, verbose);

        /// <summary>
        ///
        /// Updates list of temporarily unspendable outputs.
        /// <para>Temporarily lock (unlock=false) or unlock (unlock=true) specified transaction outputs.</para>
        /// <para>A locked transaction output will not be chosen by automatic coin selection, when spending assetss.</para>
        /// Locks are stored in memory only. Nodes start with zero locked outputs, and the locked output list is always cleared (by virtue of process exit) when a node stops or fails.
        /// <para>Also see the listunspent call</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="unlock">Whether to unlock (true) or lock (false) the specified transactions</param>
        /// <param name="transactions">A json array of objects. Each object should have the the txid (string) vout (numeric)</param>
        /// <returns></returns>
        public Task<RpcResponse<bool>> LockUnspentAsync(string blockchainName, string id, bool unlock, Transaction[] transactions) =>
            TransactAsync<bool>(blockchainName, WalletAction.LockUnspentMethod, id, unlock, transactions);

        /// <summary>
        ///
        /// Updates list of temporarily unspendable outputs.
        /// <para>Temporarily lock (unlock=false) or unlock (unlock=true) specified transaction outputs.</para>
        /// <para>A locked transaction output will not be chosen by automatic coin selection, when spending assetss.</para>
        /// Locks are stored in memory only. Nodes start with zero locked outputs, and the locked output list is always cleared (by virtue of process exit) when a node stops or fails.
        /// <para>Also see the listunspent call</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="unlock">Whether to unlock (true) or lock (false) the specified transactions</param>
        /// <param name="transactions">A json array of objects. Each object should have the the txid (string) vout (numeric)</param>
        /// <returns></returns>
        public Task<RpcResponse<bool>> LockUnspentAsync(bool unlock, Transaction[] transactions) =>
            LockUnspentAsync(RpcOptions.ChainName, UUID.NoHyphens, unlock, transactions);

        /// <summary>
        ///
        /// Move a specified amount from one account in your wallet to another.
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="from_account">The name of the account to move funds from. May be the default account using ""</param>
        /// <param name="to_account">The name of the account to move funds to. May be the default account using ""</param>
        /// <param name="amount">Number to move</param>
        /// <param name="min_conf">Only use funds with at least this many confirmations</param>
        /// <param name="comment">An optional comment, stored in the wallet only</param>
        /// <returns></returns>
        public Task<RpcResponse<bool>> MoveAsync(string blockchainName, string id, string from_account, string to_account, object amount, [Optional] int min_conf, [Optional] string comment) =>
            TransactAsync<bool>(blockchainName, WalletAction.MoveMethod, id, from_account, to_account, amount, min_conf, comment);

        /// <summary>
        ///
        /// Move a specified amount from one account in your wallet to another.
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="from_account">The name of the account to move funds from. May be the default account using ""</param>
        /// <param name="to_account">The name of the account to move funds to. May be the default account using ""</param>
        /// <param name="amount">Number to move</param>
        /// <param name="min_conf">Only use funds with at least this many confirmations</param>
        /// <param name="comment">An optional comment, stored in the wallet only</param>
        /// <returns></returns>
        public Task<RpcResponse<bool>> MoveAsync(string from_account, string to_account, object amount, [Optional] int min_conf, [Optional] string comment) =>
            MoveAsync(RpcOptions.ChainName, UUID.NoHyphens, from_account, to_account, amount, min_conf, comment);

        /// <summary>
        ///
        /// Prepares exchange transaction output for createrawexchange, appendrawexchange
        /// <para>Requires wallet passphrase to be set with walletpassphrase call.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="asset_quantities">A json object of assets to send</param>
        /// <param name="_lock">Lock prepared unspent output. Default is true</param>
        /// <returns></returns>
        public Task<RpcResponse<PrepareLockUnspentResult>> PrepareLockUnspentAsync(string blockchainName, string id, object asset_quantities, bool _lock = true) =>
            TransactAsync<PrepareLockUnspentResult>(blockchainName, WalletAction.PrepareLockUnspentMethod, id, asset_quantities, _lock);

        /// <summary>
        ///
        /// Prepares exchange transaction output for createrawexchange, appendrawexchange
        /// <para>Requires wallet passphrase to be set with walletpassphrase call.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="asset_quantities">A json object of assets to send</param>
        /// <param name="_lock">Lock prepared unspent output. Default is true</param>
        /// <returns></returns>
        public Task<RpcResponse<PrepareLockUnspentResult>> PrepareLockUnspentAsync(object asset_quantities, bool _lock = true) =>
            PrepareLockUnspentAsync(RpcOptions.ChainName, UUID.NoHyphens, asset_quantities, _lock);

        /// <summary>
        ///
        /// Prepares exchange transaction output for createrawexchange, appendrawexchange using specific address
        /// <para>Requires wallet passphrase to be set with walletpassphrase call.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="from_address">Address to send from</param>
        /// <param name="asset_quantities">A json object of assets to send</param>
        /// <param name="_lock">Lock prepared unspent output</param>
        /// <returns></returns>
        public Task<RpcResponse<PrepareLockUnspentFromResult>> PrepareLockUnspentFromAsync(string blockchainName, string id, string from_address, object asset_quantities, bool _lock = true) =>
            TransactAsync<PrepareLockUnspentFromResult>(blockchainName, WalletAction.PrepareLockUnspentFromMethod, id, from_address, asset_quantities, _lock);

        /// <summary>
        ///
        /// Prepares exchange transaction output for createrawexchange, appendrawexchange using specific address
        /// <para>Requires wallet passphrase to be set with walletpassphrase call.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="from_address">Address to send from</param>
        /// <param name="asset_quantities">A json object of assets to send</param>
        /// <param name="_lock">Lock prepared unspent output</param>
        /// <returns></returns>
        public Task<RpcResponse<PrepareLockUnspentFromResult>> PrepareLockUnspentFromAsync(string from_address, object asset_quantities, bool _lock = true) =>
            PrepareLockUnspentFromAsync(RpcOptions.ChainName, UUID.NoHyphens, from_address, asset_quantities, _lock);

        /// <summary>
        ///
        /// Publishes stream item. Requires wallet passphrase to be set with walletpassphrase call.
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="stream_identifier">One of the following: stream txid, stream reference, stream name</param>
        /// <param name="keys">Item key or Array of item keys</param>
        /// <param name="data_hex_or_object">Data hex string or JSON data object or Text data object or Binary raw data created with appendbinarycache</param>
        /// <param name="options">Should be "offchain" or omitted</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> PublishAsync(string blockchainName, string id, string stream_identifier, object keys, object data_hex_or_object, [Optional] string options)
        {
            if (string.IsNullOrEmpty(options))
                return TransactAsync<string>(blockchainName, WalletAction.PublishMethod, id, stream_identifier, keys, data_hex_or_object);
            else
                return TransactAsync<string>(blockchainName, WalletAction.PublishMethod, id, stream_identifier, keys, data_hex_or_object, options);
        }

        /// <summary>
        ///
        /// Publishes stream item. Requires wallet passphrase to be set with walletpassphrase call.
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="stream_identifier">One of the following: stream txid, stream reference, stream name</param>
        /// <param name="keys">Item key or Array of item keys</param>
        /// <param name="data_hex_or_object">Data hex string or JSON data object or Text data object or Binary raw data created with appendbinarycache</param>
        /// <param name="options">Should be "offchain" or omitted</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> PublishAsync(string stream_identifier, object keys, object data_hex_or_object, [Optional] string options) =>
            PublishAsync(RpcOptions.ChainName, UUID.NoHyphens, stream_identifier, keys, data_hex_or_object, options);

        /// <summary>
        ///
        /// Publishes stream item from specific address. Requires wallet passphrase to be set with walletpassphrase call.
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="from_address">Address used for issuing</param>
        /// <param name="stream_identifier">One of the following: stream txid, stream reference, stream name</param>
        /// <param name="keys">Item key or Array of item keys</param>
        /// <param name="data_hex_or_object">Data hex string or JSON data object or Text data object or Binary raw data created with appendbinarycache</param>
        /// <param name="options">Should be "offchain" or omitted</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> PublishFromAsync(string blockchainName, string id, string from_address, string stream_identifier, object keys, object data_hex_or_object, [Optional] string options)
        {
            if (string.IsNullOrEmpty(options))
                return TransactAsync<string>(blockchainName, WalletAction.PublishFromMethod, id, from_address, stream_identifier, keys, data_hex_or_object);
            else
                return TransactAsync<string>(blockchainName, WalletAction.PublishFromMethod, id, from_address, stream_identifier, keys, data_hex_or_object, options);
        }

        /// <summary>
        ///
        /// Publishes stream item from specific address. Requires wallet passphrase to be set with walletpassphrase call.
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="from_address">Address used for issuing</param>
        /// <param name="stream_identifier">One of the following: stream txid, stream reference, stream name</param>
        /// <param name="keys">Item key or Array of item keys</param>
        /// <param name="data_hex_or_object">Data hex string or JSON data object or Text data object or Binary raw data created with appendbinarycache</param>
        /// <param name="options">Should be "offchain" or omitted</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> PublishFromAsync(string from_address, string stream_identifier, object keys, object data_hex_or_object, [Optional] string options) =>
            PublishFromAsync(RpcOptions.ChainName, UUID.NoHyphens, from_address, stream_identifier, keys, data_hex_or_object, options);

        /// <summary>
        ///
        /// Publishes several stream items.
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="stream_identifier">One of: create txid, stream reference, stream name. Default for items if "for" field is omitted</param>
        /// <param name="items">Array of stream items.</param>
        /// <param name="options">Should be "offchain" or omitted. Default for items if "options" field is omitted</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> PublishMultiAsync(string blockchainName, string id, string stream_identifier, object[] items, [Optional] string options)
        {
            if (string.IsNullOrEmpty(options))
                return TransactAsync<string>(blockchainName, WalletAction.PublishMultiMethod, id, stream_identifier, items);
            else
                return TransactAsync<string>(blockchainName, WalletAction.PublishMultiMethod, id, stream_identifier, items, options);
        }

        /// <summary>
        ///
        /// Publishes several stream items.
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="stream_identifier">One of: create txid, stream reference, stream name. Default for items if "for" field is omitted</param>
        /// <param name="items">Array of stream items.</param>
        /// <param name="options">Should be "offchain" or omitted. Default for items if "options" field is omitted</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> PublishMultiAsync(string stream_identifier, object[] items, [Optional] string options) =>
            PublishMultiAsync(RpcOptions.ChainName, UUID.NoHyphens, stream_identifier, items, options);

        /// <summary>
        ///
        /// Publishes several stream items
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="from_address"> Address used for publishing</param>
        /// <param name="stream_identifier">One of: create txid, stream reference, stream name. Default for items if "for" field is omitted</param>
        /// <param name="items">Array of stream items.</param>
        /// <param name="options">Should be "offchain" or omitted. Default for items if "options" field is omitted</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> PublishMultiFromAsync(string blockchainName, string id, string from_address, string stream_identifier, object[] items, [Optional] string options)
        {
            if (string.IsNullOrEmpty(options))
                return TransactAsync<string>(blockchainName, WalletAction.PublishMultiFromMethod, id, from_address, stream_identifier, items);
            else
                return TransactAsync<string>(blockchainName, WalletAction.PublishMultiFromMethod, id, from_address, stream_identifier, items, options);
        }

        /// <summary>
        ///
        /// Publishes several stream items
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="from_address"> Address used for publishing</param>
        /// <param name="stream_identifier">One of: create txid, stream reference, stream name. Default for items if "for" field is omitted</param>
        /// <param name="items">Array of stream items.</param>
        /// <param name="options">Should be "offchain" or omitted. Default for items if "options" field is omitted</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> PublishMultiFromAsync(string from_address, string stream_identifier, object[] items, [Optional] string options) =>
            PublishMultiFromAsync(RpcOptions.ChainName, UUID.NoHyphens, from_address, stream_identifier, items, options);

        /// <summary>
        ///
        /// Resends wallet transactions
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <returns></returns>
        public Task<RpcResponse> ResendWalletTransactionsAsync(string blockchainName, string id) =>
            TransactAsync(blockchainName, WalletAction.ResendWalletTransactionsMethod, id);

        /// <summary>
        ///
        /// Resends wallet transactions
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <returns></returns>
        public Task<RpcResponse> ResendWalletTransactionsAsync() =>
            ResendWalletTransactionsAsync(RpcOptions.ChainName, UUID.NoHyphens);

        /// <summary>
        ///
        /// Revoke permission from a given address. The amount is a real. Requires wallet passphrase to be set with walletpassphrase call.
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="addresses">The addresses(es) to revoke permissions from</param>
        /// <param name="permissions">
        ///     <para>
        ///         Permission strings, comma delimited. Global: connect,send,receive,issue,mine,admin,activate,create or per-asset: asset-identifier.issue,admin,activate,send,receive or per-stream: stream-identifier.write,activate,admin
        ///     </para>
        /// </param>
        /// <param name="native_amount">native currency amount to send. eg 0.1. Default - 0</param>
        /// <param name="comment">A comment used to store what the transaction is for. This is not part of the transaction, just kept in your wallet.</param>
        /// <param name="comment_to">A comment to store the name of the person or organization to which you're sending the transaction. This is not part of the transaction, just kept in your wallet.</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> RevokeAsync(string blockchainName, string id, string addresses, string permissions, [Optional] double native_amount, [Optional] string comment, [Optional] string comment_to) =>
            TransactAsync<string>(blockchainName, WalletAction.RevokeMethod, id, addresses, permissions, native_amount, comment, comment_to);

        /// <summary>
        ///
        /// Revoke permission from a given address. The amount is a real. Requires wallet passphrase to be set with walletpassphrase call.
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="addresses">The addresses(es) to revoke permissions from</param>
        /// <param name="permissions">
        ///     <para>
        ///         Permission strings, comma delimited. Global: connect,send,receive,issue,mine,admin,activate,create or per-asset: asset-identifier.issue,admin,activate,send,receive or per-stream: stream-identifier.write,activate,admin
        ///     </para>
        /// </param>
        /// <param name="native_amount">native currency amount to send. eg 0.1. Default - 0</param>
        /// <param name="comment">A comment used to store what the transaction is for. This is not part of the transaction, just kept in your wallet.</param>
        /// <param name="comment_to">A comment to store the name of the person or organization to which you're sending the transaction. This is not part of the transaction, just kept in your wallet.</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> RevokeAsync(string addresses, string permissions, [Optional] double native_amount, [Optional] string comment, [Optional] string comment_to) =>
            RevokeAsync(RpcOptions.ChainName, UUID.NoHyphens, addresses, permissions, native_amount, comment, comment_to);

        /// <summary>
        ///
        /// Revoke permissions using specific address. Requires wallet passphrase to be set with walletpassphrase call.
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="from_address">Addresses used for revoke.</param>
        /// <param name="to_addresses">The addresses(es) to revoke permissions from</param>
        /// <param name="permissions">
        ///     <para>
        ///         Permission strings, comma delimited. Global: connect,send,receive,issue,mine,admin,activate,create or per-asset: asset-identifier.issue,admin,activate,send,receive or per-stream: stream-identifier.write,activate,admin
        ///     </para>
        /// </param>
        /// <param name="native_amount">native currency amount to send. eg 0.1. Default - 0</param>
        /// <param name="comment">A comment used to store what the transaction is for. This is not part of the transaction, just kept in your wallet.</param>
        /// <param name="comment_to">A comment to store the name of the person or organization to which you're sending the transaction. This is not part of the transaction, just kept in your wallet.</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> RevokeFromAsync(string blockchainName, string id, string from_address, string to_addresses, string permissions, [Optional] double native_amount, [Optional] string comment, [Optional] string comment_to) =>
            TransactAsync<string>(blockchainName, WalletAction.RevokeFromMethod, id, from_address, to_addresses, permissions, native_amount, comment, comment_to);

        /// <summary>
        ///
        /// Revoke permissions using specific address. Requires wallet passphrase to be set with walletpassphrase call.
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="from_address">Addresses used for revoke.</param>
        /// <param name="to_addresses">The addresses(es) to revoke permissions from</param>
        /// <param name="permissions">
        ///     <para>
        ///         Permission strings, comma delimited. Global: connect,send,receive,issue,mine,admin,activate,create or per-asset: asset-identifier.issue,admin,activate,send,receive or per-stream: stream-identifier.write,activate,admin
        ///     </para>
        /// </param>
        /// <param name="native_amount">native currency amount to send. eg 0.1. Default - 0</param>
        /// <param name="comment">A comment used to store what the transaction is for. This is not part of the transaction, just kept in your wallet.</param>
        /// <param name="comment_to">A comment to store the name of the person or organization to which you're sending the transaction. This is not part of the transaction, just kept in your wallet.</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> RevokeFromAsync(string from_address, string to_addresses, string permissions, [Optional] double native_amount, [Optional] string comment, [Optional] string comment_to) =>
            RevokeFromAsync(RpcOptions.ChainName, UUID.NoHyphens, from_address, to_addresses, permissions, native_amount, comment, comment_to);

        /// <summary>
        ///
        /// Send an amount (or several asset amounts) to a given address. The amount is a real and is rounded to the nearest 0.00000001. Requires wallet passphrase to be set with walletpassphrase call.
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="to_address">The address to send to</param>
        /// <param name="amount_or_asset_quantities">(numeric, required) The amount in native currency to send. eg 0.1 or (object, required) A json object of assets to send</param>
        /// <param name="comment">A comment used to store what the transaction is for. This is not part of the transaction, just kept in your wallet.</param>
        /// <param name="comment_to">A comment to store the name of the person or organization to which you're sending the transaction. This is not part of the transaction, just kept in your wallet.</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> SendAsync(string blockchainName, string id, string to_address, object amount_or_asset_quantities, [Optional] string comment, [Optional] string comment_to) =>
            TransactAsync<string>(blockchainName, WalletAction.SendMethod, id, to_address, amount_or_asset_quantities, comment, comment_to);

        /// <summary>
        ///
        /// Send an amount (or several asset amounts) to a given address. The amount is a real and is rounded to the nearest 0.00000001. Requires wallet passphrase to be set with walletpassphrase call.
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="to_address">The address to send to</param>
        /// <param name="amount_or_asset_quantities">(numeric, required) The amount in native currency to send. eg 0.1 or (object, required) A json object of assets to send</param>
        /// <param name="comment">A comment used to store what the transaction is for. This is not part of the transaction, just kept in your wallet.</param>
        /// <param name="comment_to">A comment to store the name of the person or organization to which you're sending the transaction. This is not part of the transaction, just kept in your wallet.</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> SendAsync(string to_address, object amount_or_asset_quantities, [Optional] string comment, [Optional] string comment_to) =>
            SendAsync(RpcOptions.ChainName, UUID.NoHyphens, to_address, amount_or_asset_quantities, comment, comment_to);

        /// <summary>
        ///
        /// Send asset amount to a given address. The amounts are real. Requires wallet passphrase to be set with walletpassphrase call.
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="to_address">The address to send to</param>
        /// <param name="asset_identifier">One of the following: issue txid, asset reference, asset name</param>
        /// <param name="asset_quantity">Asset quantity to send. eg 0.1</param>
        /// <param name="native_amount">native currency amount to send. eg 0.1, Default: minimum-per-output</param>
        /// <param name="comment">A comment used to store what the transaction is for. This is not part of the transaction, just kept in your wallet.</param>
        /// <param name="comment_to">A comment to store the name of the person or organization to which you're sending the transaction. This is not part of the transaction, just kept in your wallet.</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> SendAssetAsync(string blockchainName, string id, string to_address, string asset_identifier, int asset_quantity, [Optional] double native_amount, [Optional] string comment, [Optional] string comment_to) =>
            TransactAsync<string>(blockchainName, WalletAction.SendAssetMethod, id, to_address, asset_identifier, asset_quantity, native_amount, comment, comment_to);

        /// <summary>
        ///
        /// Send asset amount to a given address. The amounts are real. Requires wallet passphrase to be set with walletpassphrase call.
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="to_address">The address to send to</param>
        /// <param name="asset_identifier">One of the following: issue txid, asset reference, asset name</param>
        /// <param name="asset_quantity">Asset quantity to send. eg 0.1</param>
        /// <param name="native_amount">native currency amount to send. eg 0.1, Default: minimum-per-output</param>
        /// <param name="comment">A comment used to store what the transaction is for. This is not part of the transaction, just kept in your wallet.</param>
        /// <param name="comment_to">A comment to store the name of the person or organization to which you're sending the transaction. This is not part of the transaction, just kept in your wallet.</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> SendAssetAsync(string to_address, string asset_identifier, int asset_quantity, [Optional] double native_amount, [Optional] string comment, [Optional] string comment_to) =>
            SendAssetAsync(RpcOptions.ChainName, UUID.NoHyphens, to_address, asset_identifier, asset_quantity, native_amount, comment, comment_to);

        /// <summary>
        ///
        /// Send an asset amount using specific address. Requires wallet passphrase to be set with walletpassphrase call.
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="from_address">Address to send from</param>
        /// <param name="to_address">The address to send to</param>
        /// <param name="asset_identifier">One of the following: issue txid, asset reference, asset name</param>
        /// <param name="asset_quantity">Asset quantity to send. eg 0.1</param>
        /// <param name="native_amount">native currency amount to send. eg 0.1, Default: minimum-per-output</param>
        /// <param name="comment">A comment used to store what the transaction is for. This is not part of the transaction, just kept in your wallet.</param>
        /// <param name="comment_to">A comment to store the name of the person or organization to which you're sending the transaction. This is not part of the transaction, just kept in your wallet.</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> SendAssetFromAsync(string blockchainName, string id, string from_address, string to_address, string asset_identifier, int asset_quantity, [Optional] double native_amount, [Optional] string comment, [Optional] string comment_to) =>
            TransactAsync<string>(blockchainName, WalletAction.SendAssetFromMethod, id, from_address, to_address, asset_identifier, asset_quantity, native_amount, comment, comment_to);

        /// <summary>
        ///
        /// Send an asset amount using specific address. Requires wallet passphrase to be set with walletpassphrase call.
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="from_address">Address to send from</param>
        /// <param name="to_address">The address to send to</param>
        /// <param name="asset_identifier">One of the following: issue txid, asset reference, asset name</param>
        /// <param name="asset_quantity">Asset quantity to send. eg 0.1</param>
        /// <param name="native_amount">native currency amount to send. eg 0.1, Default: minimum-per-output</param>
        /// <param name="comment">A comment used to store what the transaction is for. This is not part of the transaction, just kept in your wallet.</param>
        /// <param name="comment_to">A comment to store the name of the person or organization to which you're sending the transaction. This is not part of the transaction, just kept in your wallet.</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> SendAssetFromAsync(string from_address, string to_address, string asset_identifier, int asset_quantity, [Optional] double native_amount, [Optional] string comment, [Optional] string comment_to) =>
            SendAssetFromAsync(RpcOptions.ChainName, UUID.NoHyphens, from_address, to_address, asset_identifier, asset_quantity, native_amount, comment, comment_to);

        /// <summary>
        ///
        /// Send an amount (or several asset amounts) using specific address. Requires wallet passphrase to be set with walletpassphrase call.
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="from_address">Address to send from</param>
        /// <param name="to_address">The address to send to</param>
        /// <param name="amount_or_asset_quantities">(numeric, required) The amount in native currency to send. eg 0.1 or (object, required) A json object of assets to send</param>
        /// <param name="comment">A comment used to store what the transaction is for. This is not part of the transaction, just kept in your wallet.</param>
        /// <param name="comment_to">A comment to store the name of the person or organization to which you're sending the transaction. This is not part of the transaction, just kept in your wallet.</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> SendFromAsync(string blockchainName, string id, string from_address, string to_address, object amount_or_asset_quantities, [Optional] string comment, [Optional] string comment_to) =>
            TransactAsync<string>(blockchainName, WalletAction.SendFromMethod, id, from_address, to_address, amount_or_asset_quantities, comment, comment_to);

        /// <summary>
        ///
        /// Send an amount (or several asset amounts) using specific address. Requires wallet passphrase to be set with walletpassphrase call.
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="from_address">Address to send from</param>
        /// <param name="to_address">The address to send to</param>
        /// <param name="amount_or_asset_quantities">(numeric, required) The amount in native currency to send. eg 0.1 or (object, required) A json object of assets to send</param>
        /// <param name="comment">A comment used to store what the transaction is for. This is not part of the transaction, just kept in your wallet.</param>
        /// <param name="comment_to">A comment to store the name of the person or organization to which you're sending the transaction. This is not part of the transaction, just kept in your wallet.</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> SendFromAsync(string from_address, string to_address, object amount_or_asset_quantities, [Optional] string comment, [Optional] string comment_to) =>
            SendFromAsync(RpcOptions.ChainName, UUID.NoHyphens, from_address, to_address, amount_or_asset_quantities, comment, comment_to);

        /// <summary>
        ///
        /// Sent an amount from an account to a address. The amount is a real and is rounded to the nearest 0.00000001. Requires wallet passphrase to be set with walletpassphrase call.
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="from_account">The name of the account to send funds from. May be the default account using "".</param>
        /// <param name="to_address">The address to send funds to</param>
        /// <param name="amount">The amount in native currency. (transaction fee is added on top)</param>
        /// <param name="min_conf">Only use funds with at least this many confirmations</param>
        /// <param name="comment">A comment used to store what the transaction is for. This is not part of the transaction, just kept in your wallet.</param>
        /// <param name="comment_to">A comment to store the name of the person or organization to which you're sending the transaction. This is not part of the transaction, just kept in your wallet.</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> SendFromAccountAsync(string blockchainName, string id, string from_account, string to_address, object amount, [Optional] int min_conf, [Optional] string comment, [Optional] string comment_to) =>
            TransactAsync<string>(blockchainName, WalletAction.SendFromAccountMethod, id, from_account, to_address, amount, min_conf, comment, comment_to);

        /// <summary>
        ///
        /// Sent an amount from an account to a address. The amount is a real and is rounded to the nearest 0.00000001. Requires wallet passphrase to be set with walletpassphrase call.
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="from_account">The name of the account to send funds from. May be the default account using "".</param>
        /// <param name="to_address">The address to send funds to</param>
        /// <param name="amount">The amount in native currency. (transaction fee is added on top)</param>
        /// <param name="min_conf">Only use funds with at least this many confirmations</param>
        /// <param name="comment">A comment used to store what the transaction is for. This is not part of the transaction, just kept in your wallet.</param>
        /// <param name="comment_to">A comment to store the name of the person or organization to which you're sending the transaction. This is not part of the transaction, just kept in your wallet.</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> SendFromAccountAsync(string from_account, string to_address, object amount, [Optional] int min_conf, [Optional] string comment, [Optional] string comment_to) =>
            SendFromAccountAsync(RpcOptions.ChainName, UUID.NoHyphens, from_account, to_address, amount, min_conf, comment, comment_to);

        /// <summary>
        ///
        /// Send multiple times. Amounts are double-precision floating point numbers. Requires wallet passphrase to be set with walletpassphrase call.
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="from_account">The account to send the funds from, can be "" for the default account</param>
        /// <param name="amounts">A json object with addresses and amounts</param>
        /// <param name="min_conf">Only use the balance confirmed at least this many times</param>
        /// <param name="comment">A comment</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> SendManyAsync(string blockchainName, string id, string from_account, object[] amounts, [Optional] int min_conf, [Optional] string comment) =>
            TransactAsync<string>(blockchainName, WalletAction.SendManyMethod, id, from_account, amounts, min_conf, comment);

        /// <summary>
        ///
        /// Send multiple times. Amounts are double-precision floating point numbers. Requires wallet passphrase to be set with walletpassphrase call.
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="from_account">The account to send the funds from, can be "" for the default account</param>
        /// <param name="amounts">A json object with addresses and amounts</param>
        /// <param name="min_conf">Only use the balance confirmed at least this many times</param>
        /// <param name="comment">A comment</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> SendManyAsync(string from_account, object[] amounts, [Optional] int min_conf, [Optional] string comment) =>
            SendManyAsync(RpcOptions.ChainName, UUID.NoHyphens, from_account, amounts, min_conf, comment);

        /// <summary>
        ///
        /// Send an amount (or several asset amounts) to a given address with appended metadata. Requires wallet passphrase to be set with walletpassphrase call.
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="to_address">The address to send to</param>
        /// <param name="amount_or_asset_quantities">The amount in native currency to send. eg 0.1 or a json object of assets to send</param>
        /// <param name="data_or_publish_new_stream_item">(string or object, required) Data, see help data-with for details.</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> SendWithDataAsync(string blockchainName, string id, string to_address, object amount_or_asset_quantities, object data_or_publish_new_stream_item) =>
            TransactAsync<string>(blockchainName, WalletAction.SendWithDataMethod, id, to_address, amount_or_asset_quantities, data_or_publish_new_stream_item);

        /// <summary>
        ///
        /// Send an amount (or several asset amounts) to a given address with appended metadata. Requires wallet passphrase to be set with walletpassphrase call.
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="to_address">The address to send to</param>
        /// <param name="amount_or_asset_quantities">The amount in native currency to send. eg 0.1 or a json object of assets to send</param>
        /// <param name="data_or_publish_new_stream_item">(string or object, required) Data, see help data-with for details.</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> SendWithDataAsync(string to_address, object amount_or_asset_quantities, object data_or_publish_new_stream_item) =>
            SendWithDataAsync(RpcOptions.ChainName, UUID.NoHyphens, to_address, amount_or_asset_quantities, data_or_publish_new_stream_item);

        /// <summary>
        ///
        /// Send an amount (or several asset amounts) using specific address. Requires wallet passphrase to be set with walletpassphrase call.
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="from_address">Address to send from.</param>
        /// <param name="to_address">The address to send to</param>
        /// <param name="amount_or_asset_quantities">The amount in native currency to send. eg 0.1 or a json object of assets to send</param>
        /// <param name="data_or_publish_new_stream_item">(string or object, required) Data, see help data-with for details.</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> SendWithDataFromAsync(string blockchainName, string id, string from_address, string to_address, object amount_or_asset_quantities, object data_or_publish_new_stream_item) =>
            TransactAsync<string>(blockchainName, WalletAction.SendWithDataFromMethod, id, from_address, to_address, amount_or_asset_quantities, data_or_publish_new_stream_item);

        /// <summary>
        ///
        /// Send an amount (or several asset amounts) using specific address. Requires wallet passphrase to be set with walletpassphrase call.
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="from_address">Address to send from.</param>
        /// <param name="to_address">The address to send to</param>
        /// <param name="amount_or_asset_quantities">The amount in native currency to send. eg 0.1 or a json object of assets to send</param>
        /// <param name="data_or_publish_new_stream_item">(string or object, required) Data, see help data-with for details.</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> SendWithDataFromAsync(string from_address, string to_address, object amount_or_asset_quantities, object data_or_publish_new_stream_item) =>
            SendWithDataFromAsync(RpcOptions.ChainName, UUID.NoHyphens, from_address, to_address, amount_or_asset_quantities, data_or_publish_new_stream_item);

        /// <summary>
        ///
        /// Sets the account associated with the given address.
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="address">The address to be associated with an account</param>
        /// <param name="account">The account to assign the address to</param>
        /// <returns></returns>
        public Task<RpcResponse> SetAccountAsync(string blockchainName, string id, string address, string account) =>
            TransactAsync(blockchainName, WalletAction.SetAccountMethod, id, address, account);

        /// <summary>
        ///
        /// Sets the account associated with the given address.
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="address">The address to be associated with an account</param>
        /// <param name="account">The account to assign the address to</param>
        /// <returns></returns>
        public Task<RpcResponse> SetAccountAsync(string address, string account) =>
            SetAccountAsync(RpcOptions.ChainName, UUID.NoHyphens, address, account);

        /// <summary>
        ///
        /// Set the transaction fee per kB.
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="amount">The transaction fee in native currency/kB rounded to the nearest 0.00000001</param>
        /// <returns></returns>
        public Task<RpcResponse<bool>> SetTxFeeAsync(string blockchainName, string id, double amount) =>
            TransactAsync<bool>(blockchainName, WalletAction.SetTxFeeMethod, id, amount);

        /// <summary>
        ///
        /// Set the transaction fee per kB.
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="amount">The transaction fee in native currency/kB rounded to the nearest 0.00000001</param>
        /// <returns></returns>
        public Task<RpcResponse<bool>> SetTxFeeAsync(double amount) =>
            SetTxFeeAsync(RpcOptions.ChainName, UUID.NoHyphens, amount);

        /// <summary>
        ///
        /// Sign a message with the private key of an address. Requires wallet passphrase to be set with walletpassphrase call.
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="address_or_privkey">The address to use for the private key or the private key (see dumpprivkey and createkeypairs)</param>
        /// <param name="message">The message to create a signature of</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> SignMessageAsync(string blockchainName, string id, string address_or_privkey, string message) =>
            TransactAsync<string>(blockchainName, WalletAction.SignMessageMethod, id, address_or_privkey, message);

        /// <summary>
        ///
        /// Sign a message with the private key of an address. Requires wallet passphrase to be set with walletpassphrase call.
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="address_privkey">The address to use for the private key or the private key (see dumpprivkey and createkeypairs)</param>
        /// <param name="message">The message to create a signature of</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> SignMessageAsync(string address_privkey, string message) =>
            SignMessageAsync(RpcOptions.ChainName, UUID.NoHyphens, address_privkey, message);

        /// <summary>
        ///
        /// <para>Subscribes to a stream or asset.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="entity_identifiers">One of: create txid, stream reference, stream name or one of: issue txid, asset reference, asset name or A json array of stream or asset identifiers</param>
        /// <param name="rescan">Rescan the wallet for transactions. Default true</param>
        /// <param name="parameters">Available only in Enterprise Edition</param>
        /// <returns></returns>
        public Task<RpcResponse> SubscribeAsync(string blockchainName, string id, object entity_identifiers, bool rescan = true, string parameters = "")
        {
            if (string.IsNullOrEmpty(parameters))
                return TransactAsync(blockchainName, WalletAction.SubscribeMethod, id, entity_identifiers, rescan);
            else
                return TransactAsync(blockchainName, WalletAction.SubscribeMethod, id, entity_identifiers, rescan, parameters);
        }

        /// <summary>
        ///
        /// <para>Subscribes to a stream or asset.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="entity_identifiers">One of: create txid, stream reference, stream name or one of: issue txid, asset reference, asset name or A json array of stream or asset identifiers</param>
        /// <param name="rescan">Rescan the wallet for transactions. Default true</param>
        /// <param name="parameters">Available only in Enterprise Edition</param>
        /// <returns></returns>
        public Task<RpcResponse> SubscribeAsync(object entity_identifiers, bool rescan = true, string parameters = "") =>
            SubscribeAsync(RpcOptions.ChainName, UUID.NoHyphens, entity_identifiers, rescan, parameters);

        /// <summary>
        ///
        /// Available only in Enterprise Edition. Removes indexes from subscriptions to the stream.
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="streams">One of: create txid, stream reference, stream name or a json array of stream identifiers</param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Task<RpcResponse> TrimSubscribeAsync(string blockchainName, string id, object streams, string parameters) =>
            TransactAsync(blockchainName, WalletAction.TrimSubscribeMethod, id, streams, parameters);

        /// <summary>
        ///
        /// Available only in Enterprise Edition. Removes indexes from subscriptions to the stream.
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="streams">One of: create txid, stream reference, stream name or a json array of stream identifiers</param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Task<RpcResponse> TrimSubscribeAsync(object streams, string parameters) =>
            TrimSubscribeAsync(RpcOptions.ChainName, UUID.NoHyphens, streams, parameters);

        /// <summary>
        ///
        /// Stores metadata of transaction output in binary cache.
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="identifier">Binary cache item identifier</param>
        /// <param name="txid">The transaction id</param>
        /// <param name="vout">vout value</param>
        /// <param name="count_bytes">Number of bytes to return</param>
        /// <param name="start_byte">start from specific byte</param>
        /// <returns></returns>
        public Task<RpcResponse<double>> TxOutToBinaryCacheAsync(string blockchainName, string id, string identifier, string txid, int vout, [Optional] int count_bytes, [Optional] int start_byte) =>
            TransactAsync<double>(blockchainName, WalletAction.TxOutToBinaryCacheMethod, id, identifier, txid, vout, count_bytes, start_byte);

        /// <summary>
        ///
        /// Stores metadata of transaction output in binary cache.
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="identifier">Binary cache item identifier</param>
        /// <param name="txid">The transaction id</param>
        /// <param name="vout">vout value</param>
        /// <param name="count_bytes">Number of bytes to return</param>
        /// <param name="start_byte">start from specific byte</param>
        /// <returns></returns>
        public Task<RpcResponse<double>> TxOutToBinaryCacheAsync(string identifier, string txid, int vout, [Optional] int count_bytes, [Optional] int start_byte) =>
            TxOutToBinaryCacheAsync(RpcOptions.ChainName, UUID.NoHyphens, identifier, txid, vout, count_bytes, start_byte);

        /// <summary>
        ///
        /// Unsubscribes from the stream.
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="entity_identifiers">Stream identifier - one of the following: stream txid, stream reference, stream name or Asset identifier - one of the following: asset txid, asset reference, asset name or a json array of stream or asset identifiers </param>
        /// <param name="purge"> Purge all offchain data for the stream</param>
        /// <returns></returns>
        public Task<RpcResponse> UnsubscribeAsync(string blockchainName, string id, object entity_identifiers, bool purge = false) =>
            TransactAsync(blockchainName, WalletAction.UnsubscribeMethod, id, entity_identifiers, purge);

        /// <summary>
        ///
        /// Unsubscribes from the stream.
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="entity_identifiers">Stream identifier - one of the following: stream txid, stream reference, stream name or Asset identifier - one of the following: asset txid, asset reference, asset name or a json array of stream or asset identifiers </param>
        /// <param name="purge"> Purge all offchain data for the stream</param>
        /// <returns></returns>
        public Task<RpcResponse> UnsubscribeAsync(object entity_identifiers, bool purge = false) =>
            UnsubscribeAsync(RpcOptions.ChainName, UUID.NoHyphens, entity_identifiers, purge);

        /// <summary>
        ///
        /// Removes the wallet encryption key from memory, locking the wallet.
        /// <para>After calling this method, you will need to call walletpassphrase again before being able to call any methods which require the wallet to be unlocked.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <returns></returns>
        public Task<RpcResponse> WalletLockAsync(string blockchainName, string id) =>
            TransactAsync(blockchainName, WalletAction.WalletLockMethod, id);

        /// <summary>
        ///
        /// Removes the wallet encryption key from memory, locking the wallet.
        /// <para>After calling this method, you will need to call walletpassphrase again before being able to call any methods which require the wallet to be unlocked.</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <returns></returns>
        public Task<RpcResponse> WalletLockAsync() =>
            WalletLockAsync(RpcOptions.ChainName, UUID.NoHyphens);

        /// <summary>
        ///
        /// Stores the wallet decryption key in memory for 'timeout' seconds.
        /// <para>This is needed prior to performing transactions related to private keys such as sending assets</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="passphrase">The wallet passphrase</param>
        /// <param name="time_out">The time to keep the decryption key in seconds.</param>
        /// <returns></returns>
        public Task<RpcResponse> WalletPassphraseAsync(string blockchainName, string id, string passphrase, int time_out) =>
            TransactAsync(blockchainName, WalletAction.WalletPassphraseMethod, id, passphrase, time_out);

        /// <summary>
        ///
        /// Stores the wallet decryption key in memory for 'timeout' seconds.
        /// <para>This is needed prior to performing transactions related to private keys such as sending assets</para>
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="passphrase">The wallet passphrase</param>
        /// <param name="time_out">The time to keep the decryption key in seconds.</param>
        /// <returns></returns>
        public Task<RpcResponse> WalletPassphraseAsync(string passphrase, int time_out) =>
            WalletPassphraseAsync(RpcOptions.ChainName, UUID.NoHyphens, passphrase, time_out);

        /// <summary>
        ///
        /// Changes the wallet passphrase from 'oldpassphrase' to 'newpassphrase'.
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="old_passphrase">The current passphrase</param>
        /// <param name="new_passphrase">The new passphrase</param>
        /// <returns></returns>
        public Task<RpcResponse> WalletPassphraseChangeAsync(string blockchainName, string id, string old_passphrase, string new_passphrase) =>
            TransactAsync(blockchainName, WalletAction.WalletPassphraseChangeMethod, id, old_passphrase, new_passphrase);

        /// <summary>
        ///
        /// Changes the wallet passphrase from 'oldpassphrase' to 'newpassphrase'.
        /// <para>Blockchain name is inferred from BlockchainRpcOptions properties.</para>
        ///
        /// </summary>
        /// <param name="old_passphrase">The current passphrase</param>
        /// <param name="new_passphrase">The new passphrase</param>
        /// <returns></returns>
        public Task<RpcResponse> WalletPassphraseChangeAsync(string old_passphrase, string new_passphrase) =>
            WalletPassphraseChangeAsync(RpcOptions.ChainName, UUID.NoHyphens, old_passphrase, new_passphrase);
    }
}