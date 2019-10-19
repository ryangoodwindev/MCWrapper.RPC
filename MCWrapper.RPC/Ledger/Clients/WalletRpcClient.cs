﻿using MCWrapper.RPC.Connection;
using MCWrapper.RPC.Extensions;
using MCWrapper.RPC.Ledger.Actions;
using MCWrapper.RPC.Ledger.Models.Wallet;
using MCWrapper.RPC.Options;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace MCWrapper.RPC.Ledger.Clients.Wallet
{
    /// <summary>
    /// 
    /// MutliChain methods implemented by the concrete WalletRPCClient class:
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
    /// <para>Inherits from an RPCClient and implements the IWalletRPC contract</para>
    /// 
    /// </summary>
    public class WalletRpcClient : RpcConnection
    {
        /// <summary>
        /// Create a new Wallet RPC client
        /// </summary>
        /// <param name="client"></param>
        /// <param name="options"></param>
        public WalletRpcClient(HttpClient client, IOptions<BlockchainProfileOptions> options)
            : base(client, options) { }


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
        public async Task<RpcResponse<object>> AddMultiSigAddressAsync(string blockchainName, string id, int n_required, string[] keys, string account)
        {
            RpcResponse<object> response;
            if (string.IsNullOrEmpty(account))
                response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.AddMultiSigAddressMethod, id, n_required, keys);
            else
                response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.AddMultiSigAddressMethod, id, n_required, keys, account);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Add a nrequired-to-sign multisignature address to the wallet.</para>>
        /// <para>Each key is a address or hex-encoded public key.</para>
        /// <para> If 'account' is specified, assign address to that account.</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        ///
        /// </summary>
        /// <param name="n_required">The number of required signatures out of the n keys or addresses</param>
        /// <param name="keys">A json array of addresses or hex-encoded public keys</param>
        /// <param name="account">An account to assign the addresses to. Accounts are not supported with the current version of MultiChain Core.</param>
        /// <returns></returns>
        public Task<RpcResponse<object>> AddMultiSigAddressAsync(int n_required, string[] keys, string account)
        {
            return AddMultiSigAddressAsync(BlockchainOptions.ChainName, UUID.NoHyphens, n_required, keys, account);
        }


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
        public async Task<RpcResponse<AppendRawExchangeResult>> AppendRawExchangeAsync(string blockchainName, string id, string hex, string txid, int vout, object ask_assets)
        {
            var response = await TransactAsync<RpcResponse<AppendRawExchangeResult>>(blockchainName, WalletAction.AppendRawExchangeMethod, id, hex, txid, vout, ask_assets);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Adds to the raw atomic exchange transaction in tx-hex given by a previous call to createrawexchange or appendrawexchange.</para>
        /// <para>Requires wallet passphrase to be set with walletpassphrase call.</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
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
        public Task<RpcResponse<AppendRawExchangeResult>> AppendRawExchangeAsync(string hex, string txid, int vout, object ask_assets)
        {
            return AppendRawExchangeAsync(BlockchainOptions.ChainName, UUID.NoHyphens, hex, txid, vout, ask_assets);
        }


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
        public async Task<RpcResponse<object>> ApproveFromAsync(string blockchainName, string id, string fromAddress, string entityIdentifier, object approve)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.ApproveFromMethod, id, fromAddress, entityIdentifier, approve);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Approve upgrade, tx filter, or stream filter using specific address.</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
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
        public Task<RpcResponse<object>> ApproveFromAsync(string fromAddress, string entityIdentifier, object approve)
        {
            return ApproveFromAsync(BlockchainOptions.ChainName, UUID.NoHyphens, fromAddress, entityIdentifier, approve);
        }


        /// <summary>
        /// 
        /// <para>Safely copies wallet.dat to destination, which can be a directory or a path with filename.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        /// 
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="destination">The destination directory or file</param>
        public async Task<RpcResponse<object>> BackupWalletAsync(string blockchainName, string id, string destination)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.BackupWalletMethod, id, destination);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Safely copies wallet.dat to destination, which can be a directory or a path with filename.</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        /// 
        /// </summary>
        /// <param name="destination">The destination directory or file</param>
        /// <returns></returns>
        public Task<RpcResponse<object>> BackupWalletAsync(string destination)
        {
            return BackupWalletAsync(BlockchainOptions.ChainName, UUID.NoHyphens, destination);
        }


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
        public async Task<RpcResponse<object>> CombineUnspentAsync(string blockchainName, string id, string addresses, int min_conf, int max_combines, int min_inputs, int max_inputs, int max_time)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.CombineUnspentMethod, id, addresses, min_conf, max_combines, min_inputs, max_inputs, max_time);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Optimizes wallet performance by combining unspent txouts.</para>
        /// <para>Requires wallet passphrase to be set with walletpassphrase call.</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        ///
        /// </summary>
        /// <param name="addresses">Addresses to optimize (comma delimited). Default - "*", all</param>
        /// <param name="min_conf">The minimum confirmations to filter. Default - 1</param>
        /// <param name="max_combines">Maximal number of transactions to send. Default - 100</param>
        /// <param name="min_inputs">Minimal number of txouts to combine in one transaction. Default - 2</param>
        /// <param name="max_inputs">Maximal number of txouts to combine in one transaction. Default - 100</param>
        /// <param name="max_time">Maximal time for creating combining transactions, at least one transaction will be sent. Default - 15s</param>
        /// <returns></returns>
        public Task<RpcResponse<object>> CombineUnspentAsync(string addresses, int min_conf, int max_combines, int min_inputs, int max_inputs, int max_time)
        {
            return CombineUnspentAsync(BlockchainOptions.ChainName, UUID.NoHyphens, addresses, min_conf, max_combines, min_inputs, max_inputs, max_time);
        }


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
        public async Task<RpcResponse<object>> CompleteRawExchangeAsync(string blockchainName, string id, string hex, string txid, int vout, object ask_assets, object data)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.CompleteRawExchangeMethod, id, hex, txid, vout, ask_assets, data);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Completes existing exchange transaction, adds fee if needed</para>
        /// <para>Returns hex-encoded raw transaction.</para>
        /// <para>Requires wallet passphrase to be set with walletpassphrase call.</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        /// 
        /// </summary>
        /// <param name="hex">The transaction hex string</param>
        /// <param name="txid">Transaction ID of the output prepared by preparelockunspent</param>
        /// <param name="vout">Output index</param>
        /// <param name="ask_assets">A json object of assets to ask; { "asset-identifier" : asset-quantity, ... }</param>
        /// <param name="data">Data, see help data-with for details</param>
        /// <returns></returns>
        public Task<RpcResponse<object>> CompleteRawExchangeAsync(string hex, string txid, int vout, object ask_assets, object data)
        {
            return CompleteRawExchangeAsync(BlockchainOptions.ChainName, UUID.NoHyphens, hex, txid, vout, ask_assets, data);
        }


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
        public async Task<RpcResponse<string>> CreateAsync(string blockchainName, string id, string entity_type, string entity_name, object restrictions_or_open, object custom_fields)
        {
            var response = await TransactAsync<RpcResponse<string>>(blockchainName, WalletAction.CreateMethod, id, entity_type, entity_name, restrictions_or_open, custom_fields);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Creates stream or upgrade</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        /// 
        /// </summary>
        /// <param name="entity_type">One of stream, upgrade, tx filter, stream filter</param>
        /// <param name="entity_name">The unique name of the stream, upgrade, tx filter, stream filter</param>
        /// <param name="restrictions_or_open">A json object with optional stream, upgrade, or filter restrictions</param>
        /// <param name="custom_fields">Custom fields objects or JavaScript code string</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> CreateAsync(string entity_type, string entity_name, object restrictions_or_open, object custom_fields)
        {
            return CreateAsync(BlockchainOptions.ChainName, UUID.NoHyphens, entity_type, entity_name, restrictions_or_open, custom_fields);
        }


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
        public async Task<RpcResponse<string>> CreateFromAsync(string blockchainName, string id, string from_address, string entity_type, string entity_name, object restrictions_or_open, object custom_fields)
        {
            var response = await TransactAsync<RpcResponse<string>>(blockchainName, WalletAction.CreateFromMethod, id, from_address, entity_type, entity_name, restrictions_or_open, custom_fields);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Creates stream or upgrade using specific address</para>
        /// <para>Requires wallet passphrase to be set with walletpassphrase call.</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        ///
        /// </summary>
        /// <param name="from_address">Address used for creating</param>
        /// <param name="entity_type">One of stream, upgrade, tx filter, stream filter</param>
        /// <param name="entity_name">The unique name of the stream, upgrade, tx filter, stream filter</param>
        /// <param name="restrictions_or_open">A json object with optional stream, upgrade, or filter restrictions</param>
        /// <param name="custom_fields">Custom fields objects or JavaScript code string</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> CreateFromAsync(string from_address, string entity_type, string entity_name, object restrictions_or_open, object custom_fields)
        {
            return CreateFromAsync(BlockchainOptions.ChainName, UUID.NoHyphens, from_address, entity_type, entity_name, restrictions_or_open, custom_fields);
        }


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
        public async Task<RpcResponse<string>> CreateRawExchangeAsync(string blockchainName, string id, string txid, int vout, object ask_assets)
        {
            var response = await TransactAsync<RpcResponse<string>>(blockchainName, WalletAction.CreateRawExchangeMethod, id, txid, vout, ask_assets);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Creates new exchange transaction</para>
        /// <para>Note that the transaction should be completed by appendrawexchange</para>
        /// <para>Requires wallet passphrase to be set with walletpassphrase call.</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        ///
        /// </summary>
        /// <param name="txid">Transaction ID of the output prepared by preparelockunspent</param>
        /// <param name="vout">Output index</param>
        /// <param name="ask_assets">A json object of assets to ask</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> CreateRawExchangeAsync(string txid, int vout, object ask_assets)
        {
            return CreateRawExchangeAsync(BlockchainOptions.ChainName, UUID.NoHyphens, txid, vout, ask_assets);
        }


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
        public async Task<RpcResponse<object>> CreateRawSendFromAsync(string blockchainName, string id, string from_address, object addresses, object[] data, string action)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.CreateRawSendFromMethod, id, from_address, addresses, data, action);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Create a transaction using the given sending address.</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        /// 
        /// </summary>
        /// <param name="from_address">Address to send from</param>
        /// <param name="addresses">Object with addresses as keys, see help addresses-all for details</param>
        /// <param name="data">Array of hexadecimal strings or data objects, see help data-all for details</param>
        /// <param name="action">Default is "". Additional actions: "lock", "sign", "lock,sign", "sign,lock", "send"</param>
        /// <returns></returns>
        public Task<RpcResponse<object>> CreateRawSendFromAsync(string from_address, object addresses, object[] data, string action)
        {
            return CreateRawSendFromAsync(BlockchainOptions.ChainName, UUID.NoHyphens, from_address, addresses, data, action);
        }


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
        public async Task<RpcResponse<DecodeRawExchangeResult>> DecodeRawExchangeAsync(string blockchainName, string id, string tx_hex, bool verbose)
        {
            var response = await TransactAsync<RpcResponse<DecodeRawExchangeResult>>(blockchainName, WalletAction.DecodeRawExchangeMethod, id, tx_hex, verbose);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Return a JSON object representing the serialized, hex-encoded exchange transaction.</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        /// 
        /// </summary>
        /// <param name="tx_hex">The exchange transaction hex string</param>
        /// <param name="verbose">If true, returns array of all exchanges created by createrawexchange or appendrawexchange</param>
        /// <returns></returns>
        public Task<RpcResponse<DecodeRawExchangeResult>> DecodeRawExchangeAsync(string tx_hex, bool verbose)
        {
            return DecodeRawExchangeAsync(BlockchainOptions.ChainName, UUID.NoHyphens, tx_hex, verbose);
        }


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
        public async Task<RpcResponse<object>> DisableRawTransactionAsync(string blockchainName, string id, string tx_hex)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.DisableRawTransactionMethod, id, tx_hex);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Disable raw transaction by spending one of its inputs and sending it back to the wallet.</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        ///
        /// </summary>
        /// <param name="tx_hex">The transaction hex string</param>
        /// <returns></returns>
        public Task<RpcResponse<object>> DisableRawTransactionAsync(string tx_hex)
        {
            return DisableRawTransactionAsync(BlockchainOptions.ChainName, UUID.NoHyphens, tx_hex);
        }


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
        public async Task<RpcResponse<object>> DumpPrivKeyAsync(string blockchainName, string id, string address)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.DumpPrivKeyMethod, id, address);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Reveals the private key corresponding to 'address'.</para>
        /// <para>Then the importprivkey can be used with this output</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        /// 
        /// </summary>
        /// <param name="address">The MultiChain address for the private key</param>
        /// <returns></returns>
        public Task<RpcResponse<object>> DumpPrivKeyAsync(string address)
        {
            return DumpPrivKeyAsync(BlockchainOptions.ChainName, UUID.NoHyphens, address);
        }


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
        public async Task<RpcResponse<object>> DumpWalletAsync(string blockchainName, string id, string filename)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.DumpWalletMethod, id, filename);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Dumps all wallet keys in a human-readable format.</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        /// 
        /// </summary>
        /// <param name="filename">The filename</param>
        /// <returns></returns>
        public Task<RpcResponse<object>> DumpWalletAsync(string filename)
        {
            return DumpWalletAsync(BlockchainOptions.ChainName, UUID.NoHyphens, filename);
        }


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
        public async Task<RpcResponse<object>> EncryptWalletAsync(string blockchainName, string id, string passphrase)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.EncryptWalletMethod, id, passphrase);

            return response;
        }

        /// <summary>
        /// <para>Encrypts the wallet with 'passphrase'. This is for first time encryption.</para>
        /// <para>
        ///     After this, any calls that interact with private keys such as sending or signing
        ///     will require the passphrase to be set prior the making these calls.
        ///     Use the walletpassphrase call for this, and then walletlock call.
        ///     If the wallet is already encrypted, use the walletpassphrasechange call.
        ///     Note that this will shutdown the server.
        /// </para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        /// 
        /// </summary>
        /// <param name="passphrase">The pass phrase to encrypt the wallet with. It must be at least 1 character, but should be long</param>
        /// <returns></returns>
        public Task<RpcResponse<object>> EncryptWalletAsync(string passphrase)
        {
            return EncryptWalletAsync(BlockchainOptions.ChainName, UUID.NoHyphens, passphrase);
        }


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
        public async Task<RpcResponse<object>> GetAccountAsync(string blockchainName, string id, string address)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.GetAccountMethod, id, address);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Returns the account associated with the targeted address.</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        ///
        /// </summary>
        /// <param name="address">The address for account lookup</param>
        /// <returns></returns>
        public Task<RpcResponse<object>> GetAccountAsync(string address)
        {
            return GetAccountAsync(BlockchainOptions.ChainName, UUID.NoHyphens, address);
        }


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
        public async Task<RpcResponse<object>> GetAccountAddressAsync(string blockchainName, string id, string account)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.GetAccountAddressMethod, id, account);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Returns the current address for receiving payments to this account.</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        /// 
        /// </summary>
        /// <param name="account">The account name for the address. It can also be set to the empty string "" to represent the default account. The account does not need to exist, it will be created and a new address created if there is no account by the given name.</param>
        /// <returns></returns>
        public Task<RpcResponse<object>> GetAccountAddressAsync(string account)
        {
            return GetAccountAddressAsync(BlockchainOptions.ChainName, UUID.NoHyphens, account);
        }


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
        public async Task<RpcResponse<GetAddressBalancesResult[]>> GetAddressBalancesAsync(string blockchainName, string id, string address, int min_conf, bool include_locked)
        {
            var response = await TransactAsync<RpcResponse<GetAddressBalancesResult[]>>(blockchainName, WalletAction.GetAddressBalancesMethod, id, address, min_conf, include_locked);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Returns asset balances for specified address</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        /// 
        /// </summary>
        /// <param name="address">Address to return balance for</param>
        /// <param name="min_conf">Only include transactions confirmed at least this many times</param>
        /// <param name="include_locked">Also take locked outputs into account</param>
        /// <returns></returns>
        public Task<RpcResponse<GetAddressBalancesResult[]>> GetAddressBalancesAsync(string address, int min_conf, bool include_locked)
        {
            return GetAddressBalancesAsync(BlockchainOptions.ChainName, UUID.NoHyphens, address, min_conf, include_locked);
        }


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
        public async Task<RpcResponse<GetAddressesResult[]>> GetAddressesAsync(string blockchainName, string id, bool verbose)
        {
            var response = await TransactAsync<RpcResponse<GetAddressesResult[]>>(blockchainName, WalletAction.GetAddressesMethod, id, verbose);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Returns the list of all addresses in the wallet.</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        /// 
        /// </summary>
        /// <param name="verbose">The account name</param>
        /// <returns></returns>
        public Task<RpcResponse<GetAddressesResult[]>> GetAddressesAsync(bool verbose)
        {
            return GetAddressesAsync(BlockchainOptions.ChainName, UUID.NoHyphens, verbose);
        }


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
        public async Task<RpcResponse<object>> GetAddressesByAccountAsync(string blockchainName, string id, string account)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.GetAddressesByAccountMethod, id, account);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Returns the list of addresses for the given account.</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        /// 
        /// </summary>
        /// <param name="account">The account name</param>
        /// <returns></returns>
        public Task<RpcResponse<object>> GetAddressesByAccountAsync(string account)
        {
            return GetAddressesByAccountAsync(BlockchainOptions.ChainName, UUID.NoHyphens, account);
        }


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
        public async Task<RpcResponse<GetAddressTransactionResult>> GetAddressTransactionAsync(string blockchainName, string id, string address, string txid, bool verbose)
        {
            var response = await TransactAsync<RpcResponse<GetAddressTransactionResult>>(blockchainName, WalletAction.GetAddressTransactionMethod, id, address, txid, verbose);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Provides information about transaction txid related to address in this node's wallet</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        /// 
        /// </summary>
        /// <param name="address">Address used for balance calculation</param>
        /// <param name="txid">The transaction id</param>
        /// <param name="verbose">If true, returns detailed array of inputs and outputs and raw hex of transactions</param>
        /// <returns></returns>
        public Task<RpcResponse<GetAddressTransactionResult>> GetAddressTransactionAsync(string address, string txid, bool verbose)
        {
            return GetAddressTransactionAsync(BlockchainOptions.ChainName, UUID.NoHyphens, address, txid, verbose);
        }


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
        public async Task<RpcResponse<object>> GetAssetBalancesAsync(string blockchainName, string id, string account, int min_conf, bool include_watch_only, bool include_locked)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.GetAssetBalancesMethod, id, account, min_conf, include_watch_only, include_locked);

            return response;
        }

        /// <summary>
        /// 
        /// <para>If account is not specified, returns the server's total available asset balances.</para>
        /// <para>If account is specified, returns the balances in the account.</para>
        /// <para>Note that the account "" is not the same as leaving the parameter out.</para>
        /// <para>The server total may be different to the balance in the default "" account.</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        ///
        /// </summary>
        /// <param name="account">The selected account, or "*" for entire wallet. It may be the default account using ""</param>
        /// <param name="min_conf">Only include transactions confirmed at least this many times</param>
        /// <param name="include_watch_only">Also include balance in watchonly addresses (see 'importaddress')</param>
        /// <param name="include_locked">Also take locked outputs into account</param>
        /// <returns></returns>
        public Task<RpcResponse<object>> GetAssetBalancesAsync(string account, int min_conf, bool include_watch_only, bool include_locked)
        {
            return GetAssetBalancesAsync(BlockchainOptions.ChainName, UUID.NoHyphens, account, min_conf, include_watch_only, include_locked);
        }


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
        public async Task<RpcResponse<GetAssetTransactionResult>> GetAssetTransactionAsync(string blockchainName, string id, string asset_identifier, string txid, bool verbose)
        {
            var response = await TransactAsync<RpcResponse<GetAssetTransactionResult>>(blockchainName, WalletAction.GetAssetTransactionMethod, id, asset_identifier, txid, verbose);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Retrieves a specific transaction txid involving asset.</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        /// 
        /// </summary>
        /// <param name="asset_identifier">One of the following: asset txid, asset reference, asset name</param>
        /// <param name="txid">The transaction id</param>
        /// <param name="verbose">If true, returns information about item transaction</param>
        /// <returns></returns>
        public Task<RpcResponse<GetAssetTransactionResult>> GetAssetTransactionAsync(string asset_identifier, string txid, bool verbose)
        {
            return GetAssetTransactionAsync(BlockchainOptions.ChainName, UUID.NoHyphens, asset_identifier, txid, verbose);
        }


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
        public async Task<RpcResponse<object>> GetBalanceAsync(string blockchainName, string id, string account, int min_conf, bool include_watch_only)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.GetBalanceMethod, id, account, min_conf, include_watch_only);

            return response;
        }

        /// <summary>
        /// 
        /// <para>If account is not specified, returns the server's total available balance.</para>
        /// <para>If account is specified, returns the balance in the account.</para>
        /// <para>Note that the account "" is not the same as leaving the parameter out.</para>
        /// <para>The server total may be different to the balance in the default "" account.</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        /// 
        /// </summary>
        /// <param name="account">The selected account, or "*" for entire wallet. It may be the default account using ""</param>
        /// <param name="min_conf">Only include transactions confirmed at least this many times</param>
        /// <param name="include_watch_only">Also include balance in watchonly addresses (see 'importaddress')</param>
        /// <returns></returns>
        public Task<RpcResponse<object>> GetBalanceAsync(string account, int min_conf, bool include_watch_only)
        {
            return GetBalanceAsync(BlockchainOptions.ChainName, UUID.NoHyphens, account, min_conf, include_watch_only);
        }



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
        public async Task<RpcResponse<object>> GetMultiBalancesAsync(string blockchainName, string id, object addresses, object assets, int min_conf, bool include_locked, bool include_watch_only)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.GetMultiBalancesMethod, id, addresses, assets, min_conf, include_locked, include_watch_only);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Returns asset balances for specified address</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        /// 
        /// </summary>
        /// <param name="addresses">Address(es) to return balance for, comma delimited. Default - all or A json array of addresses to return balance for</param>
        /// <param name="assets">Single asset identifier to return balance for, default "*" or Json array of asset identifiers to return balance for</param>
        /// <param name="min_conf">Only include transactions confirmed at least this many times</param>
        /// <param name="include_locked">Include transactions to watchonly addresses (see 'importaddress')</param>
        /// <param name="include_watch_only">Also take locked outputs into account</param>
        /// <returns></returns>
        public Task<RpcResponse<object>> GetMultiBalancesAsync(object addresses, object assets, int min_conf, bool include_locked, bool include_watch_only)
        {
            return GetMultiBalancesAsync(BlockchainOptions.ChainName, UUID.NoHyphens, addresses, assets, min_conf, include_locked, include_watch_only);
        }


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
        public async Task<RpcResponse<string>> GetNewAddressAsync(string blockchainName, string id, string account)
        {
            RpcResponse<string> response;
            if (string.IsNullOrEmpty(account))
                response = await TransactAsync<RpcResponse<string>>(blockchainName, WalletAction.GetNewAddressMethod, id);
            else
                response = await TransactAsync<RpcResponse<string>>(blockchainName, WalletAction.GetNewAddressMethod, id, account);

            return response;
        }

        /// <summary>
        /// 
        /// <para> Returns a new address for receiving payments.</para>
        /// <para>If 'account' is specified (deprecated), it is added to the address book so payments received with the address will be credited to 'account'.</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        ///
        /// </summary>
        /// <param name="account">The account name for the address to be linked to. If not provided, the default account "" is used. It can also be set to the empty string "" to represent the default account. The account does not need to exist, it will be created if there is no account by the given name.</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> GetNewAddressAsync([Optional]string account)
        {
            return GetNewAddressAsync(BlockchainOptions.ChainName, UUID.NoHyphens, account);
        }


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
        public async Task<RpcResponse<object>> GetRawChangeAddressAsync(string blockchainName, string id)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.GetRawChangeAddressMethod, id);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Returns a new address, for receiving change.</para>
        /// <para>This is for use with raw transactions, NOT normal use.</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<RpcResponse<object>> GetRawChangeAddressAsync()
        {
            return GetRawChangeAddressAsync(BlockchainOptions.ChainName, UUID.NoHyphens);
        }


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
        public async Task<RpcResponse<object>> GetReceivedByAccountAsync(string blockchainName, string id, string account, int min_conf)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.GetReceivedByAccountMethod, id, account, min_conf);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Returns the total amount received by addresses with account in transactions with at least [minconf] confirmations.</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        /// 
        /// </summary>
        /// <param name="account">The selected account, may be the default account using ""</param>
        /// <param name="min_conf">Only include transactions confirmed at least this many times</param>
        /// <returns></returns>
        public Task<RpcResponse<object>> GetReceivedByAccountAsync(string account, int min_conf)
        {
            return GetReceivedByAccountAsync(BlockchainOptions.ChainName, UUID.NoHyphens, account, min_conf);
        }


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
        public async Task<RpcResponse<object>> GetReceivedByAddressAsync(string blockchainName, string id, string address, int min_conf)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.GetReceivedByAddressMethod, id, address, min_conf);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Returns the total amount received by the given address in transactions with at least minconf confirmations.</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        /// 
        /// </summary>
        /// <param name="address">The address for transactions</param>
        /// <param name="min_conf">Only include transactions confirmed at least this many times</param>
        /// <returns></returns>
        public Task<RpcResponse<object>> GetReceivedByAddressAsync(string address, int min_conf)
        {
            return GetReceivedByAddressAsync(BlockchainOptions.ChainName, UUID.NoHyphens, address, min_conf);
        }


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
        public async Task<RpcResponse<GetStreamItemResult>> GetStreamItemAsync(string blockchainName, string id, string stream_identifier, string txid, bool verbose)
        {
            var response = await TransactAsync<RpcResponse<GetStreamItemResult>>(blockchainName, WalletAction.GetStreamItemMethod, id, stream_identifier, txid, verbose);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Returns stream item.</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        ///
        /// </summary>
        /// <param name="stream_identifier">One of the following: stream txid, stream reference, stream name</param>
        /// <param name="txid">id</param>
        /// <param name="verbose">If true, returns information about item transaction</param>
        /// <returns></returns>
        public Task<RpcResponse<GetStreamItemResult>> GetStreamItemAsync(string stream_identifier, string txid, bool verbose)
        {
            return GetStreamItemAsync(BlockchainOptions.ChainName, UUID.NoHyphens, stream_identifier, txid, verbose);
        }


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
        public async Task<RpcResponse<object>> GetStreamKeySummaryAsync(string blockchainName, string id, string stream_identifier, string key, string mode)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.GetStreamKeySummaryMethod, id, stream_identifier, key, mode);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Returns stream json object items summary for specific key.</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
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
        public Task<RpcResponse<object>> GetStreamKeySummaryAsync(string stream_identifier, string key, string mode)
        {
            return GetStreamKeySummaryAsync(BlockchainOptions.ChainName, UUID.NoHyphens, stream_identifier, key, mode);
        }


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
        public async Task<RpcResponse<object>> GetStreamPublisherSummaryAsync(string blockchainName, string id, string stream_identifier, string address, string mode)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.GetStreamPublisherSummaryMethod, id, stream_identifier, address, mode);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Returns stream json object items summary for specific publisher.</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
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
        public Task<RpcResponse<object>> GetStreamPublisherSummaryAsync(string stream_identifier, string address, string mode)
        {
            return GetStreamPublisherSummaryAsync(BlockchainOptions.ChainName, UUID.NoHyphens, stream_identifier, address, mode);
        }


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
        public async Task<RpcResponse<GetTotalBalancesResult[]>> GetTotalBalancesAsync(string blockchainName, string id, int min_conf, bool include_watch_only, bool include_locked)
        {
            var response = await TransactAsync<RpcResponse<GetTotalBalancesResult[]>>(blockchainName, WalletAction.GetTotalBalancesMethod, id, min_conf, include_watch_only, include_locked);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Returns a list of all the asset balances in this nodeΓÇÖs wallet, with at least minconf confirmations.</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        /// 
        /// </summary>
        /// <param name="min_conf">Only include transactions confirmed at least this many times</param>
        /// <param name="include_watch_only">Also include balance in watchonly addresses (see 'importaddress')</param>
        /// <param name="include_locked">Also take locked outputs into account</param>
        /// <returns></returns>
        public Task<RpcResponse<GetTotalBalancesResult[]>> GetTotalBalancesAsync(int min_conf, bool include_watch_only, bool include_locked)
        {
            return GetTotalBalancesAsync(BlockchainOptions.ChainName, UUID.NoHyphens, min_conf, include_watch_only, include_locked);
        }


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
        public async Task<RpcResponse<GetTransactionResult>> GetTransactionAsync(string blockchainName, string id, string txid, bool include_watch_only)
        {
            var response = await TransactAsync<RpcResponse<GetTransactionResult>>(blockchainName, WalletAction.GetTransactionMethod, id, txid, include_watch_only);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Get detailed information about in-wallet transaction txid</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        /// 
        /// </summary>
        /// <param name="txid">The transaction id</param>
        /// <param name="include_watch_only">Whether to include watchonly addresses in balance calculation and details[]</param>
        /// <returns></returns>
        public Task<RpcResponse<GetTransactionResult>> GetTransactionAsync(string txid, bool include_watch_only)
        {
            return GetTransactionAsync(BlockchainOptions.ChainName, UUID.NoHyphens, txid, include_watch_only);
        }


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
        public async Task<RpcResponse<object>> GetTxOutDataAsync(string blockchainName, string id, string txid, int vout, int count_bytes, int start_byte)
        {
            RpcResponse<object> response;
            if (count_bytes > 0)
                response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.GetTxOutDataMethod, id, txid, vout, count_bytes, start_byte);
            else
                response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.GetTxOutDataMethod, id, txid, vout);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Returns metadata of transaction output.</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        /// 
        /// </summary>
        /// <param name="txid">The transaction id</param>
        /// <param name="vout">vout value</param>
        /// <param name="count_bytes">Number of bytes to return</param>
        /// <param name="start_byte">Start from specific byte</param>
        /// <returns></returns>
        public Task<RpcResponse<object>> GetTxOutDataAsync(string txid, int vout, int count_bytes, int start_byte)
        {
            return GetTxOutDataAsync(BlockchainOptions.ChainName, UUID.NoHyphens, txid, vout, count_bytes, start_byte);
        }


        /// <summary>
        /// 
        /// <para>Returns the server's total unconfirmed balance</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        /// 
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <returns></returns>
        public async Task<RpcResponse<object>> GetUnconfirmedBalanceAsync(string blockchainName, string id)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.GetUnconfirmedBalanceMethod, id);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Returns the server's total unconfirmed balance</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<RpcResponse<object>> GetUnconfirmedBalanceAsync()
        {
            return GetUnconfirmedBalanceAsync(BlockchainOptions.ChainName, UUID.NoHyphens);
        }


        /// <summary>
        /// 
        /// <para>Returns an object containing various wallet state info.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        /// 
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <returns></returns>
        public async Task<RpcResponse<GetWalletInfoResult>> GetWalletInfoAsync(string blockchainName, string id)
        {
            var response = await TransactAsync<RpcResponse<GetWalletInfoResult>>(blockchainName, WalletAction.GetwalletinfoMethod, id);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Returns an object containing various wallet state info.</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<RpcResponse<GetWalletInfoResult>> GetWalletInfoAsync()
        {
            return GetWalletInfoAsync(BlockchainOptions.ChainName, UUID.NoHyphens);
        }


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
        public async Task<RpcResponse<GetWalletTransactionResult>> GetWalletTransactionAsync(string blockchainName, string id, string txid, bool include_watch_only, bool verbose)
        {
            var response = await TransactAsync<RpcResponse<GetWalletTransactionResult>>(blockchainName, WalletAction.GetWalletTransactionMethod, id, txid, include_watch_only, verbose);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Get detailed information about in-wallet transaction txid</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        ///
        /// </summary>
        /// <param name="txid">The transaction id</param>
        /// <param name="include_watch_only">Whether to include watchonly addresses in balance calculation and details[]</param>
        /// <param name="verbose">If true, returns detailed array of inputs and outputs and raw hex of transactions</param>
        /// <returns></returns>
        public Task<RpcResponse<GetWalletTransactionResult>> GetWalletTransactionAsync(string txid, bool include_watch_only, bool verbose)
        {
            return GetWalletTransactionAsync(BlockchainOptions.ChainName, UUID.NoHyphens, txid, include_watch_only, verbose);
        }


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
        public async Task<RpcResponse<object>> GrantAsync(string blockchainName, string id, string addresses, string permissions, decimal native_amount, int start_block, uint end_block, string comment, string comment_to)
        {
            RpcResponse<object> response;
            if (native_amount == 0 && start_block == 0 && end_block == 0)
            {
                response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.GrantMethod, id, addresses, permissions);
            }
            else if (start_block == 0 && end_block == 0)
            {
                response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.GrantMethod, id, addresses, permissions, native_amount);
            }
            else if (end_block == 0)
            {
                response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.GrantMethod, id, addresses, permissions, native_amount, start_block);
            }
            else
            {
                response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.GrantMethod, id, addresses, permissions, native_amount, start_block, end_block, comment, comment_to);
            }

            return response;
        }

        /// <summary>
        /// 
        /// <para>Requires wallet passphrase to be set with walletpassphrase call.</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
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
        public Task<RpcResponse<object>> GrantAsync(string addresses, string permissions, decimal native_amount, int start_block, uint end_block, string comment, string comment_to)
        {
            return GrantAsync(BlockchainOptions.ChainName, UUID.NoHyphens, addresses, permissions, native_amount, start_block, end_block, comment, comment_to);
        }


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
        public async Task<RpcResponse<object>> GrantFromAsync(string blockchainName, string id, string from_address, string addresses, string permissions, decimal native_amount, int start_block, uint end_block, string comment, string comment_to)
        {
            RpcResponse<object> response;
            if (native_amount == 0 && start_block == 0 && end_block == 0)
            {
                response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.GrantFromMethod, id, from_address, addresses, permissions);
            }
            else if (start_block == 0 && end_block == 0)
            {
                response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.GrantFromMethod, id, from_address, addresses, permissions, native_amount);
            }
            else if (end_block == 0)
            {
                response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.GrantFromMethod, id, from_address, addresses, permissions, native_amount, start_block);
            }
            else
            {
                response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.GrantFromMethod, id, from_address, addresses, permissions, native_amount, start_block, end_block, comment, comment_to);
            }

            return response;
        }


        /// <summary>
        /// Grant permission using specific address.
        ///
        /// Requires wallet passphrase to be set with walletpassphrase call.
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
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
        public Task<RpcResponse<object>> GrantFromAsync(string from_address, string addresses, string permissions, decimal native_amount, int start_block, uint end_block, string comment, string comment_to)
        {
            return GrantFromAsync(BlockchainOptions.ChainName, UUID.NoHyphens, from_address, addresses, permissions, native_amount, start_block, end_block, comment, comment_to);
        }


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
        public async Task<RpcResponse<object>> GrantWithDataAsync(string blockchainName, string id, string addresses, string permissions, object object_or_hex, decimal native_amount, int start_block, uint end_block)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.GrantWithDataMethod, id, addresses, permissions, object_or_hex, native_amount, start_block, end_block);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Grant permission(s) with metadata to a given address.</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
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
        public Task<RpcResponse<object>> GrantWithDataAsync(string addresses, string permissions, object object_or_hex, decimal native_amount, int start_block, uint end_block)
        {
            return GrantWithDataAsync(BlockchainOptions.ChainName, UUID.NoHyphens, addresses, permissions, object_or_hex, native_amount, start_block, end_block);
        }


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
        public async Task<RpcResponse<object>> GrantWithDataFromAsync(string blockchainName, string id, string from_address, string to_addresses, string permissions, object object_or_hex, decimal native_amount, int start_block, uint end_block)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.GrantWithDataFromMethod, id, from_address, to_addresses, permissions, object_or_hex, native_amount, start_block, end_block);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Grant permission with metadata using specific address.</para>
        /// <para>Requires wallet passphrase to be set with walletpassphrase call.</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
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
        public Task<RpcResponse<object>> GrantWithDataFromAsync(string from_address, string to_addresses, string permissions, object object_or_hex, decimal native_amount, int start_block, uint end_block)
        {
            return GrantWithDataFromAsync(BlockchainOptions.ChainName, UUID.NoHyphens, from_address, to_addresses, permissions, object_or_hex, native_amount, start_block, end_block);
        }


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
        public async Task<RpcResponse<object>> ImportAddressAsync(string blockchainName, string id, object addresses, string label, object rescan)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.ImportAddressMethod, id, addresses, label, rescan);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Adds an address or script (in hex) that can be watched as if it were in your wallet but cannot be used to spend.</para>
        /// <para>Note: This call can take minutes to complete if rescan is true.</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        /// 
        /// </summary>
        /// <param name="addresses">The addresses, comma delimited or a json array of addresses</param>
        /// <param name="label">An optional label</param>
        /// <param name="rescan">(boolean or integer, optional, default=true) Rescan the wallet for transactions. If integer rescan from block, if negative - from the end</param>
        /// <returns></returns>
        public Task<RpcResponse<object>> ImportAddressAsync(object addresses, string label, object rescan)
        {
            return ImportAddressAsync(BlockchainOptions.ChainName, UUID.NoHyphens, addresses, label, rescan);
        }


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
        public async Task<RpcResponse<object>> ImportPrivKeyAsync(string blockchainName, string id, object priv_keys, string label, object rescan)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.ImportPrivKeyMethod, id, priv_keys, label, rescan);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Adds a private key (as returned by dumpprivkey) to your wallet.</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        /// 
        /// </summary>
        /// <param name="priv_keys">(string, required) The private key (see dumpprivkey), comma delimited or (array, optional) A json array of private keys</param>
        /// <param name="label">An optional label</param>
        /// <param name="rescan">(boolean or integer, optional, default=true) Rescan the wallet for transactions. If integer rescan from block, if negative - from the end</param>
        /// <returns></returns>
        public Task<RpcResponse<object>> ImportPrivKeyAsync(object priv_keys, string label, object rescan)
        {
            return ImportPrivKeyAsync(BlockchainOptions.ChainName, UUID.NoHyphens, priv_keys, label, rescan);
        }


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
        public async Task<RpcResponse<object>> ImportWalletAsync(string blockchainName, string id, string filename, object rescan)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.ImportWalletMethod, id, filename, rescan);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Imports keys from a wallet dump file (see dumpwallet).</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        /// 
        /// </summary>
        /// <param name="filename">The wallet file</param>
        /// <param name="rescan">(boolean or integer, optional, default=true) Rescan the wallet for transactions. If integer rescan from block, if negative - from the end.</param>
        /// <returns></returns>
        public Task<RpcResponse<object>> ImportWalletAsync(string filename, object rescan)
        {
            return ImportWalletAsync(BlockchainOptions.ChainName, UUID.NoHyphens, filename, rescan);
        }


        /// <summary>
        /// 
        /// <para>Issue a new Asset to an address on the blockchain network.</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        /// 
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="to_address">The address to send newly created asset to</param>
        /// <param name="asset_params"> (string, required) Asset name, if not "" should be unique or (object, required) A json object of with asset params</param>
        /// <param name="quantity">The asset total amount in display units. eg. 1234.56</param>
        /// <param name="units">Number of raw units in one displayed unit, eg 0.01 for cents. Default value is 1</param>
        /// <param name="native_amount">native currency amount to send. eg 0.1, Default: minimum-per-output.</param>
        /// <param name="metadata">a json object with custom fields. { "param-name": "param-value"   (strings, required) The key is the parameter name, the value is parameter value, ,... }</param>
        /// <returns></returns>
        public async Task<RpcResponse<string>> IssueAsync(string blockchainName, string id, string to_address, object asset_params, int quantity, double units, decimal native_amount, object metadata)
        {
            var response = await TransactAsync<RpcResponse<string>>(blockchainName, WalletAction.IssueMethod, id, to_address, asset_params, quantity, units, native_amount, metadata);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Issue a new Asset to an address on the blockchain network.</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        /// 
        /// </summary>
        /// <param name="to_address">The address to send newly created asset to</param>
        /// <param name="asset_params"> (string, required) Asset name, if not "" should be unique or (object, required) A json object of with asset params</param>
        /// <param name="quantity">The asset total amount in display units. eg. 1234.56</param>
        /// <param name="units">Number of raw units in one displayed unit, eg 0.01 for cents. Default value is 1</param>
        /// <param name="native_amount">native currency amount to send. eg 0.1, Default: minimum-per-output.</param>
        /// <param name="metadata">a json object with custom fields. { "param-name": "param-value"   (strings, required) The key is the parameter name, the value is parameter value, ,... }</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> IssueAsync(string to_address, object asset_params, int quantity, double units, decimal native_amount, object metadata)
        {
            return IssueAsync(BlockchainOptions.ChainName, UUID.NoHyphens, to_address, asset_params, quantity, units, native_amount, metadata);
        }


        /// <summary>
        /// 
        /// <para>Issue asset using specific address</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="from_address">Address used for issuing</param>
        /// <param name="to_address">The address to send newly created asset to</param>
        /// <param name="asset_params"> (string, required) Asset name, if not "" should be unique or (object, required) A json object of with asset params</param>
        /// <param name="quantity">The asset total amount in display units. eg. 1234.56</param>
        /// <param name="units">Number of raw units in one displayed unit, eg 0.01 for cents. Default value is 1</param>
        /// <param name="native_amount">native currency amount to send. eg 0.1, Default: minimum-per-output.</param>
        /// <param name="metadata">a json object with custom fields. { "param-name": "param-value"   (strings, required) The key is the parameter name, the value is parameter value, ,... }</param>
        /// <returns></returns>
        public async Task<RpcResponse<string>> IssueFromAsync(string blockchainName, string id, string from_address, string to_address, object asset_params, int quantity, double units, decimal native_amount, object metadata)
        {
            var response = await TransactAsync<RpcResponse<string>>(blockchainName, WalletAction.IssueFromMethod, id, from_address, to_address, asset_params, quantity, units, native_amount, metadata);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Issue asset using specific address</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        ///
        /// </summary>
        /// <param name="from_address">Address used for issuing</param>
        /// <param name="to_address">The address to send newly created asset to</param>
        /// <param name="asset_params"> (string, required) Asset name, if not "" should be unique or (object, required) A json object of with asset params</param>
        /// <param name="quantity">The asset total amount in display units. eg. 1234.56</param>
        /// <param name="units">Number of raw units in one displayed unit, eg 0.01 for cents. Default value is 1</param>
        /// <param name="native_amount">native currency amount to send. eg 0.1, Default: minimum-per-output.</param>
        /// <param name="metadata">a json object with custom fields. { "param-name": "param-value"   (strings, required) The key is the parameter name, the value is parameter value, ,... }</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> IssueFromAsync(string from_address, string to_address, object asset_params, int quantity, double units, decimal native_amount, object metadata)
        {
            return IssueFromAsync(BlockchainOptions.ChainName, UUID.NoHyphens, from_address, to_address, asset_params, quantity, units, native_amount, metadata);
        }


        /// <summary>
        /// 
        /// <para>Create more units for asset</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="to_address">The address to send newly created asset to</param>
        /// <param name="asset_identifier">One of the following: issue txid, asset reference, asset name</param>
        /// <param name="quantity">The asset total amount in display units. eg. 1234.56</param>
        /// <param name="native_amount">native currency amount to send. eg 0.1, Default: minimum-per-output.</param>
        /// <param name="custom_fields">a json object with custom fields</param>
        /// <returns></returns>
        public async Task<RpcResponse<object>> IssueMoreAsync(string blockchainName, string id, string to_address, string asset_identifier, int quantity, decimal native_amount, object custom_fields)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.IssueMoreMethod, id, to_address, asset_identifier, quantity, native_amount, custom_fields);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Create more units for asset</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        ///
        /// </summary>
        /// <param name="to_address">The address to send newly created asset to</param>
        /// <param name="asset_identifier">One of the following: issue txid, asset reference, asset name</param>
        /// <param name="quantity">The asset total amount in display units. eg. 1234.56</param>
        /// <param name="native_amount">native currency amount to send. eg 0.1, Default: minimum-per-output.</param>
        /// <param name="custom_fields">a json object with custom fields</param>
        /// <returns></returns>
        public Task<RpcResponse<object>> IssueMoreAsync(string to_address, string asset_identifier, int quantity, decimal native_amount, object custom_fields)
        {
            return IssueMoreAsync(BlockchainOptions.ChainName, UUID.NoHyphens, to_address, asset_identifier, quantity, native_amount, custom_fields);
        }


        /// <summary>
        /// 
        /// <para>Create more units for asset from specific address</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="from_address">Address used for issuing</param>
        /// <param name="to_address">The address to send newly created asset to</param>
        /// <param name="asset_identifier">One of the following: issue txid, asset reference, asset name</param>
        /// <param name="quantity">The asset total amount in display units. eg. 1234.56</param>
        /// <param name="native_amount">native currency amount to send. eg 0.1, Default: minimum-per-output.</param>
        /// <param name="custom_fields">a json object with custom fields</param>
        /// <returns></returns>
        public async Task<RpcResponse<object>> IssueMoreFromAsync(string blockchainName, string id, string from_address, string to_address, string asset_identifier, int quantity, decimal native_amount, object custom_fields)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.IssueMoreFromMethod, id, from_address, to_address, asset_identifier, quantity, native_amount, custom_fields);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Create more units for asset from specific address</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        ///
        /// </summary>
        /// <param name="from_address">Address used for issuing</param>
        /// <param name="to_address">The address to send newly created asset to</param>
        /// <param name="asset_identifier">One of the following: issue txid, asset reference, asset name</param>
        /// <param name="quantity">The asset total amount in display units. eg. 1234.56</param>
        /// <param name="native_amount">native currency amount to send. eg 0.1, Default: minimum-per-output.</param>
        /// <param name="custom_fields">a json object with custom fields</param>
        /// <returns></returns>
        public Task<RpcResponse<object>> IssueMoreFromAsync(string from_address, string to_address, string asset_identifier, int quantity, decimal native_amount, object custom_fields)
        {
            return IssueMoreFromAsync(BlockchainOptions.ChainName, UUID.NoHyphens, from_address, to_address, asset_identifier, quantity, native_amount, custom_fields);
        }


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
        public async Task<RpcResponse<object>> KeyPoolRefillAsync(string blockchainName, string id, int new_size)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.KeyPoolRefillMethod, id, new_size);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Fills the keypool.</para>
        /// <para>Requires wallet passphrase to be set with walletpassphrase call.</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        /// 
        /// </summary>
        /// <param name="new_size">The new keypool size</param>
        /// <returns></returns>
        public Task<RpcResponse<object>> KeyPoolRefillAsync(int new_size)
        {
            return KeyPoolRefillAsync(BlockchainOptions.ChainName, UUID.NoHyphens, new_size);
        }


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
        public async Task<RpcResponse<object>> ListAccountsAsync(string blockchainName, string id, int min_conf, bool include_watch_only)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.ListAccountsMethod, id, min_conf, include_watch_only);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Returns Object that has account names as keys, account balances as values.</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        /// 
        /// </summary>
        /// <param name="min_conf"> Only include transactions with at least this many confirmations</param>
        /// <param name="include_watch_only">Include balances in watchonly addresses (see 'importaddress')</param>
        /// <returns></returns>
        public Task<RpcResponse<object>> ListAccountsAsync(int min_conf, bool include_watch_only)
        {
            return ListAccountsAsync(BlockchainOptions.ChainName, UUID.NoHyphens, min_conf, include_watch_only);
        }


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
        public async Task<RpcResponse<ListAddressesResult[]>> ListAddressesAsync(string blockchainName, string id, object addresses, bool verbose, int count, int start)
        {
            var response = await TransactAsync<RpcResponse<ListAddressesResult[]>>(blockchainName, WalletAction.ListAddressesMethod, id, addresses, verbose, count, start);

            return response;
        }

        /// <summary>
        /// 
        /// Returns asset balances for specified address
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        ///
        /// </summary>
        /// <param name="addresses">(string, optional, default *) Address(es) to return information for, comma delimited. Default - all or (array, optional) A json array of addresses to return information for</param>
        /// <param name="verbose">If true return more information about address.</param>
        /// <param name="count">The number of addresses to display</param>
        /// <param name="start">Start from specific address, 0 based, if negative - from the end</param>
        /// <returns></returns>
        public Task<RpcResponse<ListAddressesResult[]>> ListAddressesAsync(object addresses, bool verbose, int count, int start)
        {
            return ListAddressesAsync(BlockchainOptions.ChainName, UUID.NoHyphens, addresses, verbose, count, start);
        }


        /// <summary>
        ///
        /// <para>Lists groups of addresses which have had their common ownership made public by common use as inputs or as the resulting change in past transactions</para>
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        /// 
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <returns></returns>
        public async Task<RpcResponse<object>> ListAddressGroupingsAsync(string blockchainName, string id)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.ListAddressGroupingsMethod, id);

            return response;
        }

        /// <summary>
        ///
        /// <para>Lists groups of addresses which have had their common ownership made public by common use as inputs or as the resulting change in past transactions</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<RpcResponse<object>> ListAddressGroupingsAsync()
        {
            return ListAddressGroupingsAsync(BlockchainOptions.ChainName, UUID.NoHyphens);
        }


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
        public async Task<RpcResponse<ListAddressTransactionsResult[]>> ListAddressTransactionsAsync(string blockchainName, string id, string address, int count, int skip, bool verbose)
        {
            var response = await TransactAsync<RpcResponse<ListAddressTransactionsResult[]>>(blockchainName, WalletAction.ListAddressTransactionsMethod, id, address, count, skip, verbose);

            return response;
        }

        /// <summary>
        /// 
        /// Lists information about the count most recent transactions related to address in this nodeΓÇÖs wallet.
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        ///
        /// </summary>
        /// <param name="address">Address to list transactions for</param>
        /// <param name="count">The number of transactions to return</param>
        /// <param name="skip">The number of transactions to skip</param>
        /// <param name="verbose">If true, returns detailed array of inputs and outputs and raw hex of transactions</param>
        /// <returns></returns>
        public Task<RpcResponse<ListAddressTransactionsResult[]>> ListAddressTransactionsAsync(string address, int count, int skip, bool verbose)
        {
            return ListAddressTransactionsAsync(BlockchainOptions.ChainName, UUID.NoHyphens, address, count, skip, verbose);
        }


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
        public async Task<RpcResponse<ListAssetTransactionsResult[]>> ListAssetTransactionsAsync(string blockchainName, string id, string asset_identifier, bool verbose, int count, int start, bool local_ordering)
        {
            var response = await TransactAsync<RpcResponse<ListAssetTransactionsResult[]>>(blockchainName, WalletAction.ListAssetTransactionsMethod, id, asset_identifier, verbose, count, start, local_ordering);

            return response;
        }

        /// <summary>
        /// 
        /// Lists transactions involving asset.
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        /// 
        /// </summary>
        /// <param name="asset_identifier">One of the following: asset txid, asset reference, asset name</param>
        /// <param name="verbose">If true, returns information about transaction</param>
        /// <param name="count">The number of transactions to display</param>
        /// <param name="start">Start from specific transaction, 0 based, if negative - from the end</param>
        /// <param name="local_ordering">If true, transactions appear in the order they were processed by the wallet, if false - in the order they appear in blockchain</param>
        /// <returns></returns>
        public Task<RpcResponse<ListAssetTransactionsResult[]>> ListAssetTransactionsAsync(string asset_identifier, bool verbose, int count, int start, bool local_ordering)
        {
            return ListAssetTransactionsAsync(BlockchainOptions.ChainName, UUID.NoHyphens, asset_identifier, verbose, count, start, local_ordering);
        }


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
        public async Task<RpcResponse<object>> ListLockUnspentAsync(string blockchainName, string id)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.ListLockUnspentMethod, id);

            return response;
        }

        /// <summary>
        /// 
        /// Returns list of temporarily unspendable outputs.
        /// <para>See the lockunspent call to lock and unlock transactions for spending.</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        ///
        /// </summary>
        /// <returns></returns>
        public Task<RpcResponse<object>> ListLockUnspentAsync()
        {
            return ListLockUnspentAsync(BlockchainOptions.ChainName, UUID.NoHyphens);
        }


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
        public async Task<RpcResponse<object>> ListReceivedByAccountAsync(string blockchainName, string id, int min_conf, bool include_empty, bool include_watch_only)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.ListReceivedByAccountMethod, id, min_conf, include_empty, include_watch_only);

            return response;
        }

        /// <summary>
        /// 
        /// List balances by account.
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        ///
        /// </summary>
        /// <param name="min_conf">The minimum number of confirmations before payments are included</param>
        /// <param name="include_empty">Whether to include accounts that haven't received any payments</param>
        /// <param name="include_watch_only">Whether to include watchonly addresses (see 'importaddress')</param>
        /// <returns></returns>
        public Task<RpcResponse<object>> ListReceivedByAccountAsync(int min_conf, bool include_empty, bool include_watch_only)
        {
            return ListReceivedByAccountAsync(BlockchainOptions.ChainName, UUID.NoHyphens, min_conf, include_empty, include_watch_only);
        }


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
        public async Task<RpcResponse<object>> ListReceivedByAddressAsync(string blockchainName, string id, int min_conf, bool include_empty, bool include_watch_only)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.ListReceivedByAddressMethod, id, min_conf, include_empty, include_watch_only);

            return response;
        }

        /// <summary>
        /// 
        /// List balances by receiving address.
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        ///
        /// </summary>
        /// <param name="min_conf">The minimum number of confirmations before payments are included</param>
        /// <param name="include_empty">Whether to include accounts that haven't received any payments</param>
        /// <param name="include_watch_only">Whether to include watchonly addresses (see 'importaddress')</param>
        /// <returns></returns>
        public Task<RpcResponse<object>> ListReceivedByAddressAsync(int min_conf, bool include_empty, bool include_watch_only)
        {
            return ListReceivedByAddressAsync(BlockchainOptions.ChainName, UUID.NoHyphens, min_conf, include_empty, include_watch_only);
        }


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
        public async Task<RpcResponse<object>> ListSinceBlockAsync(string blockchainName, string id, string block_hash, int target_confirmations, bool include_watch_only)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.ListSinceBlockMethod, id, block_hash, target_confirmations, include_watch_only);

            return response;
        }

        /// <summary>
        /// 
        /// Get all transactions in blocks since block [blockhash], or all transactions if omitted
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        /// 
        /// </summary>
        /// <param name="block_hash">The block hash to list transactions since</param>
        /// <param name="target_confirmations">The confirmations required, must be 1 or more</param>
        /// <param name="include_watch_only">Include transactions to watchonly addresses (see 'importaddress')</param>
        /// <returns></returns>
        public Task<RpcResponse<object>> ListSinceBlockAsync(string block_hash, int target_confirmations, bool include_watch_only)
        {
            return ListSinceBlockAsync(BlockchainOptions.ChainName, UUID.NoHyphens, block_hash, target_confirmations, include_watch_only);
        }


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
        public async Task<RpcResponse<object>> ListStreamBlockItemsAsync(string blockchainName, string id, string stream_identifier, object block_set_identifier, bool verbose, int count, int start)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.ListStreamBlockItemsMethod, id, stream_identifier, block_set_identifier, verbose, count, start);

            return response;
        }

        /// <summary>
        /// 
        /// Returns stream items in certain block range.
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        ///
        /// </summary>
        /// <param name="stream_identifier">(string, required) Stream identifier - one of the following: stream txid, stream reference, stream name</param>
        /// <param name="block_set_identifier">(string, required) Comma delimited list of block identifiers or A json array of block identifiers or A json object with time range</param>
        /// <param name="verbose">If true, returns information about item transaction</param>
        /// <param name="count">The number of items to display</param>
        /// <param name="start">Start from specific item, 0 based, if negative - from the end</param>
        /// <returns></returns>
        public Task<RpcResponse<object>> ListStreamBlockItemsAsync(string stream_identifier, object block_set_identifier, bool verbose, int count, int start)
        {
            return ListStreamBlockItemsAsync(BlockchainOptions.ChainName, UUID.NoHyphens, stream_identifier, block_set_identifier, verbose, count, start);
        }


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
        public async Task<RpcResponse<ListStreamItemsResult[]>> ListStreamItemsAsync(string blockchainName, string id, string stream_identifier, bool verbose, int count, int start, bool local_ordering)
        {
            var response = await TransactAsync<RpcResponse<ListStreamItemsResult[]>>(blockchainName, WalletAction.ListStreamItemsMethod, id, stream_identifier, verbose, count, start, local_ordering);

            return response;
        }

        /// <summary>
        /// 
        /// Returns stream items.
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        /// 
        /// </summary>
        /// <param name="stream_identifier">One of the following: stream txid, stream reference, stream name</param>
        /// <param name="verbose">If true, returns information about item transaction</param>
        /// <param name="count">The number of items to display</param>
        /// <param name="start">Start from specific item, 0 based, if negative - from the end</param>
        /// <param name="local_ordering">If true, items appear in the order they were processed by the wallet, if false - in the order they appear in blockchain</param>
        /// <returns></returns>
        public Task<RpcResponse<ListStreamItemsResult[]>> ListStreamItemsAsync(string stream_identifier, bool verbose, int count, int start, bool local_ordering)
        {
            return ListStreamItemsAsync(BlockchainOptions.ChainName, UUID.NoHyphens, stream_identifier, verbose, count, start, local_ordering);
        }


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
        public async Task<RpcResponse<ListStreamKeyItemsResult[]>> ListStreamKeyItemsAsync(string blockchainName, string id, string stream_identifier, string key, bool verbose, int count, int start, bool local_ordering)
        {
            var response = await TransactAsync<RpcResponse<ListStreamKeyItemsResult[]>>(blockchainName, WalletAction.ListStreamKeyItemsMethod, id, stream_identifier, key, verbose, count, start, local_ordering);

            return response;
        }

        /// <summary>
        /// 
        /// Returns stream items for specific key.
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        /// 
        /// </summary>
        /// <param name="stream_identifier">One of the following: stream txid, stream reference, stream name</param>
        /// <param name="key">Stream key</param>
        /// <param name="verbose">If true, returns information about item transaction</param>
        /// <param name="count">The number of items to display</param>
        /// <param name="start">Start from specific item, 0 based, if negative - from the end</param>
        /// <param name="local_ordering">If true, items appear in the order they were processed by the wallet, if false - in the order they appear in blockchain</param>
        /// <returns></returns>
        public Task<RpcResponse<ListStreamKeyItemsResult[]>> ListStreamKeyItemsAsync(string stream_identifier, string key, bool verbose, int count, int start, bool local_ordering)
        {
            return ListStreamKeyItemsAsync(BlockchainOptions.ChainName, UUID.NoHyphens, stream_identifier, key, verbose, count, start, local_ordering);
        }


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
        public async Task<RpcResponse<ListStreamKeysResult[]>> ListStreamKeysAsync(string blockchainName, string id, string stream_identifier, object keys, bool verbose, int count, int start, bool local_ordering)
        {
            var response = await TransactAsync<RpcResponse<ListStreamKeysResult[]>>(blockchainName, WalletAction.ListStreamKeysMethod, id, stream_identifier, keys, verbose, count, start, local_ordering);

            return response;
        }

        /// <summary>
        /// 
        /// Returns stream keys.
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        /// 
        /// </summary>
        /// <param name="stream_identifier">One of the following: stream txid, stream reference, stream name</param>
        /// <param name="keys">Stream key or a json array of stream keys</param>
        /// <param name="verbose">If true, returns information about item transaction</param>
        /// <param name="count">The number of items to display</param>
        /// <param name="start">Start from specific item, 0 based, if negative - from the end</param>
        /// <param name="local_ordering">If true, items appear in the order they were processed by the wallet, if false - in the order they appear in blockchain</param>
        /// <returns></returns>
        public Task<RpcResponse<ListStreamKeysResult[]>> ListStreamKeysAsync(string stream_identifier, object keys, bool verbose, int count, int start, bool local_ordering)
        {
            return ListStreamKeysAsync(BlockchainOptions.ChainName, UUID.NoHyphens, stream_identifier, keys, verbose, count, start, local_ordering);
        }


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
        public async Task<RpcResponse<ListStreamPublisherItemsResult[]>> ListStreamPublisherItemsAsync(string blockchainName, string id, string stream_identifiers, string address, bool verbose, int count, int start, bool local_ordering)
        {
            var response = await TransactAsync<RpcResponse<ListStreamPublisherItemsResult[]>>(blockchainName, WalletAction.ListStreamPublisherItemsMethod, id, stream_identifiers, address, verbose, count, start, local_ordering);

            return response;
        }

        /// <summary>
        /// 
        /// Returns stream items for specific publisher.
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        /// 
        /// </summary>
        /// <param name="stream_identifiers">One of the following: stream txid, stream reference, stream name</param>
        /// <param name="address">Publisher address</param>
        /// <param name="verbose">If true, returns information about item transaction</param>
        /// <param name="count">The number of items to display</param>
        /// <param name="start">Start from specific item, 0 based, if negative - from the end</param>
        /// <param name="local_ordering">If true, items appear in the order they were processed by the wallet, if false - in the order they appear in blockchain</param>
        /// <returns></returns>
        public Task<RpcResponse<ListStreamPublisherItemsResult[]>> ListStreamPublisherItemsAsync(string stream_identifiers, string address, bool verbose, int count, int start, bool local_ordering)
        {
            return ListStreamPublisherItemsAsync(BlockchainOptions.ChainName, UUID.NoHyphens, stream_identifiers, address, verbose, count, start, local_ordering);
        }


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
        public async Task<RpcResponse<ListStreamPublishersResult[]>> ListStreamPublishersAsync(string blockchainName, string id, string stream_identifier, object addresses, bool verbose, int count, int start, bool local_ordering)
        {
            var response = await TransactAsync<RpcResponse<ListStreamPublishersResult[]>>(blockchainName, WalletAction.ListStreamPublishersMethod, id, stream_identifier, addresses, verbose, count, start, local_ordering);

            return response;
        }

        /// <summary>
        /// 
        /// Returns stream publishers.
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        /// 
        /// </summary>
        /// <param name="stream_identifier">One of the following: stream txid, stream reference, stream name</param>
        /// <param name="addresses">Publisher addresses, comma delimited or a json array of publisher addresses</param>
        /// <param name="verbose">If true, returns information about item transaction</param>
        /// <param name="count">The number of items to display</param>
        /// <param name="start">Start from specific item, 0 based, if negative - from the end</param>
        /// <param name="local_ordering">If true, items appear in the order they were processed by the wallet, if false - in the order they appear in blockchain</param>
        /// <returns></returns>
        public Task<RpcResponse<ListStreamPublishersResult[]>> ListStreamPublishersAsync(string stream_identifier, object addresses, bool verbose, int count, int start, bool local_ordering)
        {
            return ListStreamPublishersAsync(BlockchainOptions.ChainName, UUID.NoHyphens, stream_identifier, addresses, verbose, count, start, local_ordering);
        }


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
        public async Task<RpcResponse<object>> ListStreamQueryItemsAsync(string blockchainName, string id, string stream_identifier, object query, bool verbose)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.ListStreamQueryItemsMethod, id, stream_identifier, query, verbose);

            return response;
        }

        /// <summary>
        /// 
        /// Returns stream items for specific query.
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        ///
        /// </summary>
        /// <param name="stream_identifier">One of the following: stream txid, stream reference, stream name</param>
        /// <param name="query">Query { "key" : "key" (string, optional, default: "") Item key, or "keys" : keys (array, optional) Item keys, array of strings, and or  "publisher" : "publisher" (string, optional, default: "") Publisher or "publishers" : publishers (array, optional) Publishers, array of strings }</param>
        /// <param name="verbose">If true, returns information about item transaction</param>
        /// <returns></returns>
        public Task<RpcResponse<object>> ListStreamQueryItemsAsync(string stream_identifier, object query, bool verbose)
        {
            return ListStreamQueryItemsAsync(BlockchainOptions.ChainName, UUID.NoHyphens, stream_identifier, query, verbose);
        }


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
        public async Task<RpcResponse<object>> ListStreamTxItemsAsync(string blockchainName, string id, string stream_identifiers, object txids, bool verbose)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.ListStreamTxItemsMethod, id, stream_identifiers, txids, verbose);

            return response;
        }

        /// <summary>
        /// 
        /// Returns stream items.
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        /// 
        /// </summary>
        /// <param name="stream_identifiers">One of the following: stream txid, stream reference, stream name</param>
        /// <param name="txids"> Transaction IDs, comma delimited or Array of transaction IDs</param>
        /// <param name="verbose">If true, returns information about item transaction</param>
        /// <returns></returns>
        public Task<RpcResponse<object>> ListStreamTxItemsAsync(string stream_identifiers, object txids, bool verbose)
        {
            return ListStreamTxItemsAsync(BlockchainOptions.ChainName, UUID.NoHyphens, stream_identifiers, txids, verbose);
        }


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
        public async Task<RpcResponse<ListTransactionsResult[]>> ListTransactionsAsync(string blockchainName, string id, string account, int count, int from, bool include_watch_only)
        {
            var response = await TransactAsync<RpcResponse<ListTransactionsResult[]>>(blockchainName, WalletAction.ListTransactionsMethod, id, account, count, from, include_watch_only);

            return response;
        }

        /// <summary>
        /// 
        /// Returns up to 'count' most recent transactions skipping the first 'from' transactions for account 'account'.
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        ///
        /// </summary>
        /// <param name="account">The account name. If not included, it will list all transactions for all accounts. If "" is set, it will list transactions for the default account.</param>
        /// <param name="count">The number of transactions to return</param>
        /// <param name="from">The number of transactions to skip</param>
        /// <param name="include_watch_only">Include transactions to watchonly addresses (see 'importaddress')</param>
        /// <returns></returns>
        public Task<RpcResponse<ListTransactionsResult[]>> ListTransactionsAsync(string account, int count, int from, bool include_watch_only)
        {
            return ListTransactionsAsync(BlockchainOptions.ChainName, UUID.NoHyphens, account, count, from, include_watch_only);
        }


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
        public async Task<RpcResponse<ListUnspentResult[]>> ListUnspentAsync(string blockchainName, string id, int min_conf, int max_conf, object addresses)
        {
            var response = await TransactAsync<RpcResponse<ListUnspentResult[]>>(blockchainName, WalletAction.ListUnspentMethod, id, min_conf, max_conf, addresses);

            return response;
        }

        /// <summary>
        /// 
        /// Returns array of unspent transaction outputs with between minconf and maxconf (inclusive) confirmations.
        /// 
        /// <para>Optionally filter to only include txouts paid to specified addresses.</para>
        /// <para>Results are an array of Objects, each of which has: {txid, vout, scriptPubKey, amount, confirmations}</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        /// 
        /// </summary>
        /// <param name="min_conf">The minimum confirmations to filter</param>
        /// <param name="max_conf">The maximum confirmations to filter</param>
        /// <param name="addresses">A json array of addresses to filter</param>
        /// <returns></returns>
        public Task<RpcResponse<ListUnspentResult[]>> ListUnspentAsync(int min_conf, int max_conf, object addresses)
        {
            return ListUnspentAsync(BlockchainOptions.ChainName, UUID.NoHyphens, min_conf, max_conf, addresses);
        }


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
        public async Task<RpcResponse<ListWalletTransactionsResult[]>> ListWalletTransactionsAsync(string blockchainName, string id, int count, int skip, bool include_watch_only, bool verbose)
        {
            var response = await TransactAsync<RpcResponse<ListWalletTransactionsResult[]>>(blockchainName, WalletAction.ListWalletTransactionsMethod, id, count, skip, include_watch_only, verbose);

            return response;
        }

        /// <summary>
        /// 
        /// Lists information about the count most recent transactions in this nodeΓÇÖs wallet.
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        ///
        /// </summary>
        /// <param name="count">The number of transactions to return</param>
        /// <param name="skip">The number of transactions to skip</param>
        /// <param name="include_watch_only">Include transactions to watchonly addresses (see 'importaddress')</param>
        /// <param name="verbose">If true, returns detailed array of inputs and outputs and raw hex of transactions</param>
        /// <returns></returns>
        public Task<RpcResponse<ListWalletTransactionsResult[]>> ListWalletTransactionsAsync(int count, int skip, bool include_watch_only, bool verbose)
        {
            return ListWalletTransactionsAsync(BlockchainOptions.ChainName, UUID.NoHyphens, count, skip, include_watch_only, verbose);
        }


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
        /// <param name="unspent">A json array of objects. Each object should have the the txid (string) vout (numeric)</param>
        /// <returns></returns>
        public async Task<RpcResponse<object>> LockUnspentAsync(string blockchainName, string id, bool unlock, object[] unspent)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.LockUnspentMethod, id, unlock, unspent);

            return response;
        }

        /// <summary>
        /// 
        /// Updates list of temporarily unspendable outputs.
        /// <para>Temporarily lock (unlock=false) or unlock (unlock=true) specified transaction outputs.</para>
        /// <para>A locked transaction output will not be chosen by automatic coin selection, when spending assetss.</para>
        /// Locks are stored in memory only. Nodes start with zero locked outputs, and the locked output list is always cleared (by virtue of process exit) when a node stops or fails.
        /// <para>Also see the listunspent call</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        /// 
        /// </summary>
        /// <param name="unlock">Whether to unlock (true) or lock (false) the specified transactions</param>
        /// <param name="unspent">A json array of objects. Each object should have the the txid (string) vout (numeric)</param>
        /// <returns></returns>
        public Task<RpcResponse<object>> LockUnspentAsync(bool unlock, object[] unspent)
        {
            return LockUnspentAsync(BlockchainOptions.ChainName, UUID.NoHyphens, unlock, unspent);
        }


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
        public async Task<RpcResponse<object>> MoveAsync(string blockchainName, string id, string from_account, string to_account, object amount, int min_conf, string comment)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.MoveMethod, id, from_account, to_account, amount, min_conf, comment);

            return response;
        }

        /// <summary>
        /// 
        /// Move a specified amount from one account in your wallet to another.
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        /// 
        /// </summary>
        /// <param name="from_account">The name of the account to move funds from. May be the default account using ""</param>
        /// <param name="to_account">The name of the account to move funds to. May be the default account using ""</param>
        /// <param name="amount">Number to move</param>
        /// <param name="min_conf">Only use funds with at least this many confirmations</param>
        /// <param name="comment">An optional comment, stored in the wallet only</param>
        /// <returns></returns>
        public Task<RpcResponse<object>> MoveAsync(string from_account, string to_account, object amount, int min_conf, string comment)
        {
            return MoveAsync(BlockchainOptions.ChainName, UUID.NoHyphens, from_account, to_account, amount, min_conf, comment);
        }


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
        public async Task<RpcResponse<PrepareLockUnspentResult>> PrepareLockUnspentAsync(string blockchainName, string id, object asset_quantities, bool _lock)
        {
            var response = await TransactAsync<RpcResponse<PrepareLockUnspentResult>>(blockchainName, WalletAction.PrepareLockUnspentMethod, id, asset_quantities, _lock);

            return response;
        }

        /// <summary>
        /// 
        /// Prepares exchange transaction output for createrawexchange, appendrawexchange
        /// <para>Requires wallet passphrase to be set with walletpassphrase call.</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        ///  
        /// </summary>
        /// <param name="asset_quantities">A json object of assets to send</param>
        /// <param name="_lock">Lock prepared unspent output. Default is true</param>
        /// <returns></returns>
        public Task<RpcResponse<PrepareLockUnspentResult>> PrepareLockUnspentAsync(object asset_quantities, bool _lock)
        {
            return PrepareLockUnspentAsync(BlockchainOptions.ChainName, UUID.NoHyphens, asset_quantities, _lock);
        }


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
        public async Task<RpcResponse<PrepareLockUnspentFromResult>> PrepareLockUnspentFromAsync(string blockchainName, string id, string from_address, object asset_quantities, bool _lock)
        {
            var response = await TransactAsync<RpcResponse<PrepareLockUnspentFromResult>>(blockchainName, WalletAction.PrepareLockUnspentFromMethod, id, from_address, asset_quantities, _lock);

            return response;
        }

        /// <summary>
        /// 
        /// Prepares exchange transaction output for createrawexchange, appendrawexchange using specific address
        /// <para>Requires wallet passphrase to be set with walletpassphrase call.</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        ///
        /// </summary>
        /// <param name="from_address">Address to send from</param>
        /// <param name="asset_quantities">A json object of assets to send</param>
        /// <param name="_lock">Lock prepared unspent output</param>
        /// <returns></returns>
        public Task<RpcResponse<PrepareLockUnspentFromResult>> PrepareLockUnspentFromAsync(string from_address, object asset_quantities, bool _lock)
        {
            return PrepareLockUnspentFromAsync(BlockchainOptions.ChainName, UUID.NoHyphens, from_address, asset_quantities, _lock);
        }


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
        public async Task<RpcResponse<string>> PublishAsync(string blockchainName, string id, string stream_identifier, object keys, object data_hex_or_object, string options)
        {
            RpcResponse<string> response;
            if (string.IsNullOrEmpty(options))
                response = await TransactAsync<RpcResponse<string>>(blockchainName, WalletAction.PublishMethod, id, stream_identifier, keys, data_hex_or_object);
            else
                response = await TransactAsync<RpcResponse<string>>(blockchainName, WalletAction.PublishMethod, id, stream_identifier, keys, data_hex_or_object, options);

            return response;
        }

        /// <summary>
        /// 
        /// Publishes stream item. Requires wallet passphrase to be set with walletpassphrase call.
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        ///
        /// </summary>
        /// <param name="stream_identifier">One of the following: stream txid, stream reference, stream name</param>
        /// <param name="keys">Item key or Array of item keys</param>
        /// <param name="data_hex_or_object">Data hex string or JSON data object or Text data object or Binary raw data created with appendbinarycache</param>
        /// <param name="options">Should be "offchain" or omitted</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> PublishAsync(string stream_identifier, object keys, object data_hex_or_object, string options)
        {
            return PublishAsync(BlockchainOptions.ChainName, UUID.NoHyphens, stream_identifier, keys, data_hex_or_object, options);
        }


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
        public async Task<RpcResponse<string>> PublishFromAsync(string blockchainName, string id, string from_address, string stream_identifier, object keys, object data_hex_or_object, string options)
        {
            RpcResponse<string> response;
            if (string.IsNullOrEmpty(options))
                response = await TransactAsync<RpcResponse<string>>(blockchainName, WalletAction.PublishFromMethod, id, from_address, stream_identifier, keys, data_hex_or_object);
            else
                response = await TransactAsync<RpcResponse<string>>(blockchainName, WalletAction.PublishFromMethod, id, from_address, stream_identifier, keys, data_hex_or_object, options);

            return response;
        }

        /// <summary>
        /// 
        /// Publishes stream item from specific address. Requires wallet passphrase to be set with walletpassphrase call.
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        ///
        /// </summary>
        /// <param name="from_address">Address used for issuing</param>
        /// <param name="stream_identifier">One of the following: stream txid, stream reference, stream name</param>
        /// <param name="keys">Item key or Array of item keys</param>
        /// <param name="data_hex_or_object">Data hex string or JSON data object or Text data object or Binary raw data created with appendbinarycache</param>
        /// <param name="options">Should be "offchain" or omitted</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> PublishFromAsync(string from_address, string stream_identifier, object keys, object data_hex_or_object, string options)
        {
            return PublishFromAsync(BlockchainOptions.ChainName, UUID.NoHyphens, from_address, stream_identifier, keys, data_hex_or_object, options);
        }


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
        public async Task<RpcResponse<string>> PublishMultiAsync(string blockchainName, string id, string stream_identifier, object[] items, string options)
        {
            RpcResponse<string> response;
            if (string.IsNullOrEmpty(options))
                response = await TransactAsync<RpcResponse<string>>(blockchainName, WalletAction.PublishMultiMethod, id, stream_identifier, items);
            else
                response = await TransactAsync<RpcResponse<string>>(blockchainName, WalletAction.PublishMultiMethod, id, stream_identifier, items, options);

            return response;
        }

        /// <summary>
        /// 
        /// Publishes several stream items.
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        /// 
        /// </summary>
        /// <param name="stream_identifier">One of: create txid, stream reference, stream name. Default for items if "for" field is omitted</param>
        /// <param name="items">Array of stream items.</param>
        /// <param name="options">Should be "offchain" or omitted. Default for items if "options" field is omitted</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> PublishMultiAsync(string stream_identifier, object[] items, string options)
        {
            return PublishMultiAsync(BlockchainOptions.ChainName, UUID.NoHyphens, stream_identifier, items, options);
        }


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
        public async Task<RpcResponse<string>> PublishMultiFromAsync(string blockchainName, string id, string from_address, string stream_identifier, object[] items, string options)
        {
            RpcResponse<string> response;
            if (string.IsNullOrEmpty(options))
                response = await TransactAsync<RpcResponse<string>>(blockchainName, WalletAction.PublishMultiFromMethod, id, from_address, stream_identifier, items);
            else
                response = await TransactAsync<RpcResponse<string>>(blockchainName, WalletAction.PublishMultiFromMethod, id, from_address, stream_identifier, items, options);

            return response;
        }

        /// <summary>
        /// 
        /// Publishes several stream items
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        /// 
        /// </summary>
        /// <param name="from_address"> Address used for publishing</param>
        /// <param name="stream_identifier">One of: create txid, stream reference, stream name. Default for items if "for" field is omitted</param>
        /// <param name="items">Array of stream items.</param>
        /// <param name="options">Should be "offchain" or omitted. Default for items if "options" field is omitted</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> PublishMultiFromAsync(string from_address, string stream_identifier, object[] items, string options)
        {
            return PublishMultiFromAsync(BlockchainOptions.ChainName, UUID.NoHyphens, from_address, stream_identifier, items, options);
        }


        /// <summary>
        /// 
        /// Resends wallet transactions
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        /// 
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <returns></returns>
        public async Task<RpcResponse<object>> ResendWalletTransactionsAsync(string blockchainName, string id)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.ResendWalletTransactionsMethod, id);

            return response;
        }

        /// <summary>
        /// 
        /// Resends wallet transactions
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<RpcResponse<object>> ResendWalletTransactionsAsync()
        {
            return ResendWalletTransactionsAsync(BlockchainOptions.ChainName, UUID.NoHyphens);
        }


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
        public async Task<RpcResponse<object>> RevokeAsync(string blockchainName, string id, string addresses, string permissions, double native_amount, string comment, string comment_to)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.RevokeMethod, id, addresses, permissions, native_amount, comment, comment_to);

            return response;
        }

        /// <summary>
        /// 
        /// Revoke permission from a given address. The amount is a real. Requires wallet passphrase to be set with walletpassphrase call.
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
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
        public Task<RpcResponse<object>> RevokeAsync(string addresses, string permissions, double native_amount, string comment, string comment_to)
        {
            return RevokeAsync(BlockchainOptions.ChainName, UUID.NoHyphens, addresses, permissions, native_amount, comment, comment_to);
        }


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
        public async Task<RpcResponse<object>> RevokeFromAsync(string blockchainName, string id, string from_address, string to_addresses, string permissions, double native_amount, string comment, string comment_to)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.RevokeFromMethod, id, from_address, to_addresses, permissions, native_amount, comment, comment_to);

            return response;
        }

        /// <summary>
        /// 
        /// Revoke permissions using specific address. Requires wallet passphrase to be set with walletpassphrase call.
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
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
        public Task<RpcResponse<object>> RevokeFromAsync(string from_address, string to_addresses, string permissions, double native_amount, string comment, string comment_to)
        {
            return RevokeFromAsync(BlockchainOptions.ChainName, UUID.NoHyphens, from_address, to_addresses, permissions, native_amount, comment, comment_to);
        }


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
        public async Task<RpcResponse<string>> SendAsync(string blockchainName, string id, string to_address, object amount_or_asset_quantities, string comment, string comment_to)
        {
            var response = await TransactAsync<RpcResponse<string>>(blockchainName, WalletAction.SendMethod, id, to_address, amount_or_asset_quantities, comment, comment_to);

            return response;
        }

        /// <summary>
        /// 
        /// Send an amount (or several asset amounts) to a given address. The amount is a real and is rounded to the nearest 0.00000001. Requires wallet passphrase to be set with walletpassphrase call.
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        /// 
        /// </summary>
        /// <param name="to_address">The address to send to</param>
        /// <param name="amount_or_asset_quantities">(numeric, required) The amount in native currency to send. eg 0.1 or (object, required) A json object of assets to send</param>
        /// <param name="comment">A comment used to store what the transaction is for. This is not part of the transaction, just kept in your wallet.</param>
        /// <param name="comment_to">A comment to store the name of the person or organization to which you're sending the transaction. This is not part of the transaction, just kept in your wallet.</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> SendAsync(string to_address, object amount_or_asset_quantities, string comment, string comment_to)
        {
            return SendAsync(BlockchainOptions.ChainName, UUID.NoHyphens, to_address, amount_or_asset_quantities, comment, comment_to);
        }


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
        public async Task<RpcResponse<object>> SendAssetAsync(string blockchainName, string id, string to_address, string asset_identifier, int asset_quantity, double native_amount, string comment, string comment_to)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.SendAssetMethod, id, to_address, asset_identifier, asset_quantity, native_amount, comment, comment_to);

            return response;
        }

        /// <summary>
        /// 
        /// Send asset amount to a given address. The amounts are real. Requires wallet passphrase to be set with walletpassphrase call.
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        /// 
        /// </summary>
        /// <param name="to_address">The address to send to</param>
        /// <param name="asset_identifier">One of the following: issue txid, asset reference, asset name</param>
        /// <param name="asset_quantity">Asset quantity to send. eg 0.1</param>
        /// <param name="native_amount">native currency amount to send. eg 0.1, Default: minimum-per-output</param>
        /// <param name="comment">A comment used to store what the transaction is for. This is not part of the transaction, just kept in your wallet.</param>
        /// <param name="comment_to">A comment to store the name of the person or organization to which you're sending the transaction. This is not part of the transaction, just kept in your wallet.</param>
        /// <returns></returns>
        public Task<RpcResponse<object>> SendAssetAsync(string to_address, string asset_identifier, int asset_quantity, double native_amount, string comment, string comment_to)
        {
            return SendAssetAsync(BlockchainOptions.ChainName, UUID.NoHyphens, to_address, asset_identifier, asset_quantity, native_amount, comment, comment_to);
        }


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
        public async Task<RpcResponse<object>> SendAssetFromAsync(string blockchainName, string id, string from_address, string to_address, string asset_identifier, int asset_quantity, double native_amount, string comment, string comment_to)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.SendAssetFromMethod, id, from_address, to_address, asset_identifier, asset_quantity, native_amount, comment, comment_to);

            return response;
        }

        /// <summary>
        /// 
        /// Send an asset amount using specific address. Requires wallet passphrase to be set with walletpassphrase call.
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
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
        public Task<RpcResponse<object>> SendAssetFromAsync(string from_address, string to_address, string asset_identifier, int asset_quantity, double native_amount, string comment, string comment_to)
        {
            return SendAssetFromAsync(BlockchainOptions.ChainName, UUID.NoHyphens, from_address, to_address, asset_identifier, asset_quantity, native_amount, comment, comment_to);
        }


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
        public async Task<RpcResponse<object>> SendFromAsync(string blockchainName, string id, string from_address, string to_address, object amount_or_asset_quantities, string comment, string comment_to)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.SendFromMethod, id, from_address, to_address, amount_or_asset_quantities, comment, comment_to);

            return response;
        }

        /// <summary>
        /// 
        /// Send an amount (or several asset amounts) using specific address. Requires wallet passphrase to be set with walletpassphrase call.
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        /// 
        /// </summary>
        /// <param name="from_address">Address to send from</param>
        /// <param name="to_address">The address to send to</param>
        /// <param name="amount_or_asset_quantities">(numeric, required) The amount in native currency to send. eg 0.1 or (object, required) A json object of assets to send</param>
        /// <param name="comment">A comment used to store what the transaction is for. This is not part of the transaction, just kept in your wallet.</param>
        /// <param name="comment_to">A comment to store the name of the person or organization to which you're sending the transaction. This is not part of the transaction, just kept in your wallet.</param>
        /// <returns></returns>
        public Task<RpcResponse<object>> SendFromAsync(string from_address, string to_address, object amount_or_asset_quantities, string comment, string comment_to)
        {
            return SendFromAsync(BlockchainOptions.ChainName, UUID.NoHyphens, from_address, to_address, amount_or_asset_quantities, comment, comment_to);
        }


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
        public async Task<RpcResponse<object>> SendFromAccountAsync(string blockchainName, string id, string from_account, string to_address, object amount, int min_conf, string comment, string comment_to)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.SendFromAccountMethod, id, from_account, to_address, amount, min_conf, comment, comment_to);

            return response;
        }

        /// <summary>
        /// 
        /// Sent an amount from an account to a address. The amount is a real and is rounded to the nearest 0.00000001. Requires wallet passphrase to be set with walletpassphrase call.
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        ///
        /// </summary>
        /// <param name="from_account">The name of the account to send funds from. May be the default account using "".</param>
        /// <param name="to_address">The address to send funds to</param>
        /// <param name="amount">The amount in native currency. (transaction fee is added on top)</param>
        /// <param name="min_conf">Only use funds with at least this many confirmations</param>
        /// <param name="comment">A comment used to store what the transaction is for. This is not part of the transaction, just kept in your wallet.</param>
        /// <param name="comment_to">A comment to store the name of the person or organization to which you're sending the transaction. This is not part of the transaction, just kept in your wallet.</param>
        /// <returns></returns>
        public Task<RpcResponse<object>> SendFromAccountAsync(string from_account, string to_address, object amount, int min_conf, string comment, string comment_to)
        {
            return SendFromAccountAsync(BlockchainOptions.ChainName, UUID.NoHyphens, from_account, to_address, amount, min_conf, comment, comment_to);
        }


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
        public async Task<RpcResponse<object>> SendManyAsync(string blockchainName, string id, string from_account, object[] amounts, int min_conf, string comment)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.SendManyMethod, id, from_account, amounts, min_conf, comment);

            return response;
        }

        /// <summary>
        /// 
        /// Send multiple times. Amounts are double-precision floating point numbers. Requires wallet passphrase to be set with walletpassphrase call.
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        ///
        /// </summary>
        /// <param name="from_account">The account to send the funds from, can be "" for the default account</param>
        /// <param name="amounts">A json object with addresses and amounts</param>
        /// <param name="min_conf">Only use the balance confirmed at least this many times</param>
        /// <param name="comment">A comment</param>
        /// <returns></returns>
        public Task<RpcResponse<object>> SendManyAsync(string from_account, object[] amounts, int min_conf, string comment)
        {
            return SendManyAsync(BlockchainOptions.ChainName, UUID.NoHyphens, from_account, amounts, min_conf, comment);
        }


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
        public async Task<RpcResponse<object>> SendWithDataAsync(string blockchainName, string id, string to_address, object amount_or_asset_quantities, object data_or_publish_new_stream_item)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.SendWithDataMethod, id, to_address, amount_or_asset_quantities, data_or_publish_new_stream_item);

            return response;
        }

        /// <summary>
        /// 
        /// Send an amount (or several asset amounts) to a given address with appended metadata. Requires wallet passphrase to be set with walletpassphrase call.
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        /// 
        /// </summary>
        /// <param name="to_address">The address to send to</param>
        /// <param name="amount_or_asset_quantities">The amount in native currency to send. eg 0.1 or a json object of assets to send</param>
        /// <param name="data_or_publish_new_stream_item">(string or object, required) Data, see help data-with for details.</param>
        /// <returns></returns>
        public Task<RpcResponse<object>> SendWithDataAsync(string to_address, object amount_or_asset_quantities, object data_or_publish_new_stream_item)
        {
            return SendWithDataAsync(BlockchainOptions.ChainName, UUID.NoHyphens, to_address, amount_or_asset_quantities, data_or_publish_new_stream_item);
        }


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
        public async Task<RpcResponse<object>> SendWithDataFromAsync(string blockchainName, string id, string from_address, string to_address, object amount_or_asset_quantities, object data_or_publish_new_stream_item)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.SendWithDataFromMethod, id, from_address, to_address, amount_or_asset_quantities, data_or_publish_new_stream_item);

            return response;
        }

        /// <summary>
        /// 
        /// Send an amount (or several asset amounts) using specific address. Requires wallet passphrase to be set with walletpassphrase call.
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        /// 
        /// </summary>
        /// <param name="from_address">Address to send from.</param>
        /// <param name="to_address">The address to send to</param>
        /// <param name="amount_or_asset_quantities">The amount in native currency to send. eg 0.1 or a json object of assets to send</param>
        /// <param name="data_or_publish_new_stream_item">(string or object, required) Data, see help data-with for details.</param>
        /// <returns></returns>
        public Task<RpcResponse<object>> SendWithDataFromAsync(string from_address, string to_address, object amount_or_asset_quantities, object data_or_publish_new_stream_item)
        {
            return SendWithDataFromAsync(BlockchainOptions.ChainName, UUID.NoHyphens, from_address, to_address, amount_or_asset_quantities, data_or_publish_new_stream_item);
        }


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
        public async Task<RpcResponse<object>> SetAccountAsync(string blockchainName, string id, string address, string account)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.SetAccountMethod, id, address, account);

            return response;
        }

        /// <summary>
        /// 
        /// Sets the account associated with the given address.
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        /// 
        /// </summary>
        /// <param name="address">The address to be associated with an account</param>
        /// <param name="account">The account to assign the address to</param>
        /// <returns></returns>
        public Task<RpcResponse<object>> SetAccountAsync(string address, string account)
        {
            return SetAccountAsync(BlockchainOptions.ChainName, UUID.NoHyphens, address, account);
        }


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
        public async Task<RpcResponse<object>> SetTxFeeAsync(string blockchainName, string id, double amount)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.SetTxFeeMethod, id, amount);

            return response;
        }

        /// <summary>
        /// 
        /// Set the transaction fee per kB.
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        /// 
        /// </summary>
        /// <param name="amount">The transaction fee in native currency/kB rounded to the nearest 0.00000001</param>
        /// <returns></returns>
        public Task<RpcResponse<object>> SetTxFeeAsync(double amount)
        {
            return SetTxFeeAsync(BlockchainOptions.ChainName, UUID.NoHyphens, amount);
        }


        /// <summary>
        /// 
        /// Sign a message with the private key of an address. Requires wallet passphrase to be set with walletpassphrase call.
        /// <para>Blockchain name is explicitly passed as parameter.</para>
        ///
        /// </summary>
        /// <param name="blockchainName">Name of target blockchain</param>
        /// <param name="id">String value to identify this transaction</param>
        /// <param name="address_privkey">The address to use for the private key or the private key (see dumpprivkey and createkeypairs)</param>
        /// <param name="message">The message to create a signature of</param>
        /// <returns></returns>
        public async Task<RpcResponse<string>> SignMessageAsync(string blockchainName, string id, string address_or_privkey, string message)
        {
            var response = await TransactAsync<RpcResponse<string>>(blockchainName, WalletAction.SignMessageMethod, id, address_or_privkey, message);

            return response;
        }

        /// <summary>
        /// 
        /// Sign a message with the private key of an address. Requires wallet passphrase to be set with walletpassphrase call.
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        ///
        /// </summary>
        /// <param name="address_privkey">The address to use for the private key or the private key (see dumpprivkey and createkeypairs)</param>
        /// <param name="message">The message to create a signature of</param>
        /// <returns></returns>
        public Task<RpcResponse<string>> SignMessageAsync(string address_privkey, string message)
        {
            return SignMessageAsync(BlockchainOptions.ChainName, UUID.NoHyphens, address_privkey, message);
        }


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
        public async Task<RpcResponse<object>> SubscribeAsync(string blockchainName, string id, object entity_identifiers, bool rescan, string parameters)
        {
            RpcResponse<object> response;
            if (string.IsNullOrEmpty(parameters))
                response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.SubscribeMethod, id, entity_identifiers, rescan);
            else
                response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.SubscribeMethod, id, entity_identifiers, rescan, parameters);

            return response;
        }

        /// <summary>
        /// 
        /// <para>Subscribes to a stream or asset.</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        /// 
        /// </summary>
        /// <param name="entity_identifiers">One of: create txid, stream reference, stream name or one of: issue txid, asset reference, asset name or A json array of stream or asset identifiers</param>
        /// <param name="rescan">Rescan the wallet for transactions. Default true</param>
        /// <param name="parameters">Available only in Enterprise Edition</param>
        /// <returns></returns>
        public Task<RpcResponse<object>> SubscribeAsync(object entity_identifiers, bool rescan, string parameters)
        {
            return SubscribeAsync(BlockchainOptions.ChainName, UUID.NoHyphens, entity_identifiers, rescan, parameters);
        }


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
        public async Task<RpcResponse<object>> TrimSubscribeAsync(string blockchainName, string id, object streams, string parameters)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.TrimSubscribeMethod, id, streams, parameters);

            return response;
        }

        /// <summary>
        /// 
        /// Available only in Enterprise Edition. Removes indexes from subscriptions to the stream.
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        /// 
        /// </summary>
        /// <param name="streams">One of: create txid, stream reference, stream name or a json array of stream identifiers</param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Task<RpcResponse<object>> TrimSubscribeAsync(object streams, string parameters)
        {
            return TrimSubscribeAsync(BlockchainOptions.ChainName, UUID.NoHyphens, streams, parameters);
        }


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
        public async Task<RpcResponse<double>> TxOutToBinaryCacheAsync(string blockchainName, string id, string identifier, string txid, int vout, int count_bytes, int start_byte)
        {
            var response = await TransactAsync<RpcResponse<double>>(blockchainName, WalletAction.TxOutToBinaryCacheMethod, id, identifier, txid, vout, count_bytes, start_byte);

            return response;
        }

        /// <summary>
        /// 
        /// Stores metadata of transaction output in binary cache.
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        /// 
        /// </summary>
        /// <param name="identifier">Binary cache item identifier</param>
        /// <param name="txid">The transaction id</param>
        /// <param name="vout">vout value</param>
        /// <param name="count_bytes">Number of bytes to return</param>
        /// <param name="start_byte">start from specific byte</param>
        /// <returns></returns>
        public Task<RpcResponse<double>> TxOutToBinaryCacheAsync(string identifier, string txid, int vout, int count_bytes, int start_byte)
        {
            return TxOutToBinaryCacheAsync(BlockchainOptions.ChainName, UUID.NoHyphens, identifier, txid, vout, count_bytes, start_byte);
        }


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
        public async Task<RpcResponse<object>> UnsubscribeAsync(string blockchainName, string id, object entity_identifiers, bool purge)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.UnsubscribeMethod, id, entity_identifiers, purge);

            return response;
        }

        /// <summary>
        /// 
        /// Unsubscribes from the stream.
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        /// 
        /// </summary>
        /// <param name="entity_identifiers">Stream identifier - one of the following: stream txid, stream reference, stream name or Asset identifier - one of the following: asset txid, asset reference, asset name or a json array of stream or asset identifiers </param>
        /// <param name="purge"> Purge all offchain data for the stream</param>
        /// <returns></returns>
        public Task<RpcResponse<object>> UnsubscribeAsync(object entity_identifiers, bool purge)
        {
            return UnsubscribeAsync(BlockchainOptions.ChainName, UUID.NoHyphens, entity_identifiers, purge);
        }


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
        public async Task<RpcResponse<object>> WalletLockAsync(string blockchainName, string id)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.WalletLockMethod, id);

            return response;
        }

        /// <summary>
        /// 
        /// Removes the wallet encryption key from memory, locking the wallet.
        /// <para>After calling this method, you will need to call walletpassphrase again before being able to call any methods which require the wallet to be unlocked.</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        ///
        /// </summary>
        /// <returns></returns>
        public Task<RpcResponse<object>> WalletLockAsync()
        {
            return WalletLockAsync(BlockchainOptions.ChainName, UUID.NoHyphens);
        }


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
        public async Task<RpcResponse<object>> WalletPassphraseAsync(string blockchainName, string id, string passphrase, int time_out)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.WalletPassphraseMethod, id, passphrase, time_out);

            return response;
        }

        /// <summary>
        /// 
        /// Stores the wallet decryption key in memory for 'timeout' seconds.
        /// <para>This is needed prior to performing transactions related to private keys such as sending assets</para>
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        /// 
        /// </summary>
        /// <param name="passphrase">The wallet passphrase</param>
        /// <param name="time_out">The time to keep the decryption key in seconds.</param>
        /// <returns></returns>
        public Task<RpcResponse<object>> WalletPassphraseAsync(string passphrase, int time_out)
        {
            return WalletPassphraseAsync(BlockchainOptions.ChainName, UUID.NoHyphens, passphrase, time_out);
        }


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
        public async Task<RpcResponse<object>> WalletPassphraseChangeAsync(string blockchainName, string id, string old_passphrase, string new_passphrase)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.WalletPassphraseChangeMethod, id, old_passphrase, new_passphrase);

            return response;
        }

        /// <summary>
        /// 
        /// Changes the wallet passphrase from 'oldpassphrase' to 'newpassphrase'.
        /// <para>Blockchain name is inferred from BlockchainProfileOptions properties.</para>
        /// 
        /// </summary>
        /// <param name="old_passphrase">The current passphrase</param>
        /// <param name="new_passphrase">The new passphrase</param>
        /// <returns></returns>
        public Task<RpcResponse<object>> WalletPassphraseChangeAsync(string old_passphrase, string new_passphrase)
        {
            return WalletPassphraseChangeAsync(BlockchainOptions.ChainName, UUID.NoHyphens, old_passphrase, new_passphrase);
        }
    }
}