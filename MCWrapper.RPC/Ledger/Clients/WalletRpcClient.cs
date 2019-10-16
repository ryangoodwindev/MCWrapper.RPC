using MCWrapper.RPC.Connection;
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
        public WalletRpcClient(HttpClient client, IOptions<BlockchainProfileOptions> options)
            : base(client, options) { }

        public async Task<RpcResponse<object>> AddMultiSigAddressAsync(string blockchainName, string id, int n_required, string[] keys, string account)
        {
            RpcResponse<object> response;
            if (string.IsNullOrEmpty(account))
                response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.AddMultiSigAddressMethod, id, n_required, keys);
            else
                response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.AddMultiSigAddressMethod, id, n_required, keys, account);

            return response;
        }

        public Task<RpcResponse<object>> AddMultiSigAddressAsync(int n_required, string[] keys, string account)
        {
            return AddMultiSigAddressAsync(BlockchainOptions.ChainName, UUID.NoHyphens, n_required, keys, account);
        }


        public async Task<RpcResponse<AppendRawExchangeResult>> AppendRawExchangeAsync(string blockchainName, string id, string hex, string txid, int vout, object ask_assets)
        {
            var response = await TransactAsync<RpcResponse<AppendRawExchangeResult>>(blockchainName, WalletAction.AppendRawExchangeMethod, id, hex, txid, vout, ask_assets);

            return response;
        }
        public Task<RpcResponse<AppendRawExchangeResult>> AppendRawExchangeAsync(string hex, string txid, int vout, object ask_assets)
        {
            return AppendRawExchangeAsync(BlockchainOptions.ChainName, UUID.NoHyphens, hex, txid, vout, ask_assets);
        }


        public async Task<RpcResponse<object>> ApproveFromAsync(string blockchainName, string id, string fromAddress, string entityIdentifier, object approve)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.ApproveFromMethod, id, fromAddress, entityIdentifier, approve);

            return response;
        }

        public Task<RpcResponse<object>> ApproveFromAsync(string fromAddress, string entityIdentifier, object approve)
        {
            return ApproveFromAsync(BlockchainOptions.ChainName, UUID.NoHyphens, fromAddress, entityIdentifier, approve);
        }


        public async Task<RpcResponse<object>> BackupWalletAsync(string blockchainName, string id, string destination)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.BackupWalletMethod, id, destination);

            return response;
        }

        public Task<RpcResponse<object>> BackupWalletAsync(string destination)
        {
            return BackupWalletAsync(BlockchainOptions.ChainName, UUID.NoHyphens, destination);
        }


        public async Task<RpcResponse<object>> CombineUnspentAsync(string blockchainName, string id, string addresses, int min_conf, int max_combines, int min_inputs, int max_inputs, int max_time)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.CombineUnspentMethod, id, addresses, min_conf, max_combines, min_inputs, max_inputs, max_time);

            return response;
        }

        public Task<RpcResponse<object>> CombineUnspentAsync(string addresses, int min_conf, int max_combines, int min_inputs, int max_inputs, int max_time)
        {
            return CombineUnspentAsync(BlockchainOptions.ChainName, UUID.NoHyphens, addresses, min_conf, max_combines, min_inputs, max_inputs, max_time);
        }


        public async Task<RpcResponse<object>> CompleteRawExchangeAsync(string blockchainName, string id, string hex, string txid, int vout, object ask_assets, object data)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.CompleteRawExchangeMethod, id, hex, txid, vout, ask_assets, data);

            return response;
        }

        public Task<RpcResponse<object>> CompleteRawExchangeAsync(string hex, string txid, int vout, object ask_assets, object data)
        {
            return CompleteRawExchangeAsync(BlockchainOptions.ChainName, UUID.NoHyphens, hex, txid, vout, ask_assets, data);
        }


        public async Task<RpcResponse<string>> CreateAsync(string blockchainName, string id, string entity_type, string entity_name, object restrictions_or_open, object custom_fields)
        {
            var response = await TransactAsync<RpcResponse<string>>(blockchainName, WalletAction.CreateMethod, id, entity_type, entity_name, restrictions_or_open, custom_fields);

            return response;
        }

        public Task<RpcResponse<string>> CreateAsync(string entity_type, string entity_name, object restrictions_or_open, object custom_fields)
        {
            return CreateAsync(BlockchainOptions.ChainName, UUID.NoHyphens, entity_type, entity_name, restrictions_or_open, custom_fields);
        }


        public async Task<RpcResponse<string>> CreateFromAsync(string blockchainName, string id, string from_address, string entity_type, string entity_name, object restrictions_or_open, object custom_fields)
        {
            var response = await TransactAsync<RpcResponse<string>>(blockchainName, WalletAction.CreateFromMethod, id, from_address, entity_type, entity_name, restrictions_or_open, custom_fields);

            return response;
        }

        public Task<RpcResponse<string>> CreateFromAsync(string from_address, string entity_type, string entity_name, object restrictions_or_open, object custom_fields)
        {
            return CreateFromAsync(BlockchainOptions.ChainName, UUID.NoHyphens, from_address, entity_type, entity_name, restrictions_or_open, custom_fields);
        }


        public async Task<RpcResponse<string>> CreateRawExchangeAsync(string blockchainName, string id, string txid, int vout, object ask_assets)
        {
            var response = await TransactAsync<RpcResponse<string>>(blockchainName, WalletAction.CreateRawExchangeMethod, id, txid, vout, ask_assets);

            return response;
        }

        public Task<RpcResponse<string>> CreateRawExchangeAsync(string txid, int vout, object ask_assets)
        {
            return CreateRawExchangeAsync(BlockchainOptions.ChainName, UUID.NoHyphens, txid, vout, ask_assets);
        }


        public async Task<RpcResponse<object>> CreateRawSendFromAsync(string blockchainName, string id, string from_address, object addresses, object[] data, string action)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.CreateRawSendFromMethod, id, from_address, addresses, data, action);

            return response;
        }

        public Task<RpcResponse<object>> CreateRawSendFromAsync(string from_address, object addresses, object[] data, string action)
        {
            return CreateRawSendFromAsync(BlockchainOptions.ChainName, UUID.NoHyphens, from_address, addresses, data, action);
        }


        public async Task<RpcResponse<DecodeRawExchangeResult>> DecodeRawExchangeAsync(string blockchainName, string id, string tx_hex, bool verbose)
        {
            var response = await TransactAsync<RpcResponse<DecodeRawExchangeResult>>(blockchainName, WalletAction.DecodeRawExchangeMethod, id, tx_hex, verbose);

            return response;
        }

        public Task<RpcResponse<DecodeRawExchangeResult>> DecodeRawExchangeAsync(string tx_hex, bool verbose)
        {
            return DecodeRawExchangeAsync(BlockchainOptions.ChainName, UUID.NoHyphens, tx_hex, verbose);
        }


        public async Task<RpcResponse<object>> DisableRawTransactionAsync(string blockchainName, string id, string tx_hex)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.DisableRawTransactionMethod, id, tx_hex);

            return response;
        }

        public Task<RpcResponse<object>> DisableRawTransactionAsync(string tx_hex)
        {
            return DisableRawTransactionAsync(BlockchainOptions.ChainName, UUID.NoHyphens, tx_hex);
        }


        public async Task<RpcResponse<object>> DumpPrivKeyAsync(string blockchainName, string id, string address)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.DumpPrivKeyMethod, id, address);

            return response;
        }

        public Task<RpcResponse<object>> DumpPrivKeyAsync(string address)
        {
            return DumpPrivKeyAsync(BlockchainOptions.ChainName, UUID.NoHyphens, address);
        }


        public async Task<RpcResponse<object>> DumpWalletAsync(string blockchainName, string id, string filename)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.DumpWalletMethod, id, filename);

            return response;
        }

        public Task<RpcResponse<object>> DumpWalletAsync(string filename)
        {
            return DumpWalletAsync(BlockchainOptions.ChainName, UUID.NoHyphens, filename);
        }


        public async Task<RpcResponse<object>> EncryptWalletAsync(string blockchainName, string id, string passphrase)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.EncryptWalletMethod, id, passphrase);

            return response;
        }

        public Task<RpcResponse<object>> EncryptWalletAsync(string passphrase)
        {
            return EncryptWalletAsync(BlockchainOptions.ChainName, UUID.NoHyphens, passphrase);
        }


        public async Task<RpcResponse<object>> GetAccountAsync(string blockchainName, string id, string address)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.GetAccountMethod, id, address);

            return response;
        }

        public Task<RpcResponse<object>> GetAccountAsync(string address)
        {
            return GetAccountAsync(BlockchainOptions.ChainName, UUID.NoHyphens, address);
        }


        public async Task<RpcResponse<object>> GetAccountAddressAsync(string blockchainName, string id, string account)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.GetAccountAddressMethod, id, account);

            return response;
        }

        public Task<RpcResponse<object>> GetAccountAddressAsync(string account)
        {
            return GetAccountAddressAsync(BlockchainOptions.ChainName, UUID.NoHyphens, account);
        }


        public async Task<RpcResponse<GetAddressBalancesResult[]>> GetAddressBalancesAsync(string blockchainName, string id, string address, int min_conf, bool include_locked)
        {
            var response = await TransactAsync<RpcResponse<GetAddressBalancesResult[]>>(blockchainName, WalletAction.GetAddressBalancesMethod, id, address, min_conf, include_locked);

            return response;
        }

        public Task<RpcResponse<GetAddressBalancesResult[]>> GetAddressBalancesAsync(string address, int min_conf, bool include_locked)
        {
            return GetAddressBalancesAsync(BlockchainOptions.ChainName, UUID.NoHyphens, address, min_conf, include_locked);
        }


        public async Task<RpcResponse<GetAddressesResult[]>> GetAddressesAsync(string blockchainName, string id, bool verbose)
        {
            var response = await TransactAsync<RpcResponse<GetAddressesResult[]>>(blockchainName, WalletAction.GetAddressesMethod, id, verbose);

            return response;
        }

        public Task<RpcResponse<GetAddressesResult[]>> GetAddressesAsync(bool verbose)
        {
            return GetAddressesAsync(BlockchainOptions.ChainName, UUID.NoHyphens, verbose);
        }


        public async Task<RpcResponse<object>> GetAddressesByAccountAsync(string blockchainName, string id, string account)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.GetAddressesByAccountMethod, id, account);

            return response;
        }

        public Task<RpcResponse<object>> GetAddressesByAccountAsync(string account)
        {
            return GetAddressesByAccountAsync(BlockchainOptions.ChainName, UUID.NoHyphens, account);
        }


        public async Task<RpcResponse<GetAddressTransactionResult>> GetAddressTransactionAsync(string blockchainName, string id, string address, string txid, bool verbose)
        {
            var response = await TransactAsync<RpcResponse<GetAddressTransactionResult>>(blockchainName, WalletAction.GetAddressTransactionMethod, id, address, txid, verbose);

            return response;
        }

        public Task<RpcResponse<GetAddressTransactionResult>> GetAddressTransactionAsync(string address, string txid, bool verbose)
        {
            return GetAddressTransactionAsync(BlockchainOptions.ChainName, UUID.NoHyphens, address, txid, verbose);
        }


        public async Task<RpcResponse<object>> GetAssetBalancesAsync(string blockchainName, string id, string account, int min_conf, bool include_watch_only, bool include_locked)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.GetAssetBalancesMethod, id, account, min_conf, include_watch_only, include_locked);

            return response;
        }

        public Task<RpcResponse<object>> GetAssetBalancesAsync(string account, int min_conf, bool include_watch_only, bool include_locked)
        {
            return GetAssetBalancesAsync(BlockchainOptions.ChainName, UUID.NoHyphens, account, min_conf, include_watch_only, include_locked);
        }


        public async Task<RpcResponse<GetAssetTransactionResult>> GetAssetTransactionAsync(string blockchainName, string id, string asset_identifier, string txid, bool verbose)
        {
            var response = await TransactAsync<RpcResponse<GetAssetTransactionResult>>(blockchainName, WalletAction.GetAssetTransactionMethod, id, asset_identifier, txid, verbose);

            return response;
        }

        public Task<RpcResponse<GetAssetTransactionResult>> GetAssetTransactionAsync(string asset_identifier, string txid, bool verbose)
        {
            return GetAssetTransactionAsync(BlockchainOptions.ChainName, UUID.NoHyphens, asset_identifier, txid, verbose);
        }


        public async Task<RpcResponse<object>> GetBalanceAsync(string blockchainName, string id, string account, int min_conf, bool include_watch_only)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.GetBalanceMethod, id, account, min_conf, include_watch_only);

            return response;
        }

        public Task<RpcResponse<object>> GetBalanceAsync(string account, int min_conf, bool include_watch_only)
        {
            return GetBalanceAsync(BlockchainOptions.ChainName, UUID.NoHyphens, account, min_conf, include_watch_only);
        }


        public async Task<RpcResponse<object>> GetMultiBalancesAsync(string blockchainName, string id, object addresses, object assets, int min_conf, bool include_locked, bool include_watch_only)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.GetMultiBalancesMethod, id, addresses, assets, min_conf, include_locked, include_watch_only);

            return response;
        }

        public Task<RpcResponse<object>> GetMultiBalancesAsync(object addresses, object assets, int min_conf, bool include_locked, bool include_watch_only)
        {
            return GetMultiBalancesAsync(BlockchainOptions.ChainName, UUID.NoHyphens, addresses, assets, min_conf, include_locked, include_watch_only);
        }


        public async Task<RpcResponse<string>> GetNewAddressAsync(string blockchainName, string id, string account)
        {
            RpcResponse<string> response;
            if (string.IsNullOrEmpty(account))
                response = await TransactAsync<RpcResponse<string>>(blockchainName, WalletAction.GetNewAddressMethod, id);
            else
                response = await TransactAsync<RpcResponse<string>>(blockchainName, WalletAction.GetNewAddressMethod, id, account);

            return response;
        }

        public Task<RpcResponse<string>> GetNewAddressAsync([Optional]string account)
        {
            return GetNewAddressAsync(BlockchainOptions.ChainName, UUID.NoHyphens, account);
        }


        public async Task<RpcResponse<object>> GetRawChangeAddressAsync(string blockchainName, string id)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.GetRawChangeAddressMethod, id);

            return response;
        }

        public Task<RpcResponse<object>> GetRawChangeAddressAsync()
        {
            return GetRawChangeAddressAsync(BlockchainOptions.ChainName, UUID.NoHyphens);
        }


        public async Task<RpcResponse<object>> GetReceivedByAccountAsync(string blockchainName, string id, string account, int min_conf)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.GetReceivedByAccountMethod, id, account, min_conf);

            return response;
        }

        public Task<RpcResponse<object>> GetReceivedByAccountAsync(string account, int min_conf)
        {
            return GetReceivedByAccountAsync(BlockchainOptions.ChainName, UUID.NoHyphens, account, min_conf);
        }


        public async Task<RpcResponse<object>> GetReceivedByAddressAsync(string blockchainName, string id, string address, int min_conf)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.GetReceivedByAddressMethod, id, address, min_conf);

            return response;
        }

        public Task<RpcResponse<object>> GetReceivedByAddressAsync(string address, int min_conf)
        {
            return GetReceivedByAddressAsync(BlockchainOptions.ChainName, UUID.NoHyphens, address, min_conf);
        }


        public async Task<RpcResponse<GetStreamItemResult>> GetStreamItemAsync(string blockchainName, string id, string stream_identifier, string txid, bool verbose)
        {
            var response = await TransactAsync<RpcResponse<GetStreamItemResult>>(blockchainName, WalletAction.GetStreamItemMethod, id, stream_identifier, txid, verbose);

            return response;
        }

        public Task<RpcResponse<GetStreamItemResult>> GetStreamItemAsync(string stream_identifier, string txid, bool verbose)
        {
            return GetStreamItemAsync(BlockchainOptions.ChainName, UUID.NoHyphens, stream_identifier, txid, verbose);
        }


        public async Task<RpcResponse<object>> GetStreamKeySummaryAsync(string blockchainName, string id, string stream_identifier, string key, string mode)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.GetStreamKeySummaryMethod, id, stream_identifier, key, mode);

            return response;
        }

        public Task<RpcResponse<object>> GetStreamKeySummaryAsync(string stream_identifier, string key, string mode)
        {
            return GetStreamKeySummaryAsync(BlockchainOptions.ChainName, UUID.NoHyphens, stream_identifier, key, mode);
        }


        public async Task<RpcResponse<object>> GetStreamPublisherSummaryAsync(string blockchainName, string id, string stream_identifier, string address, string mode)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.GetStreamPublisherSummaryMethod, id, stream_identifier, address, mode);

            return response;
        }

        public Task<RpcResponse<object>> GetStreamPublisherSummaryAsync(string stream_identifier, string address, string mode)
        {
            return GetStreamPublisherSummaryAsync(BlockchainOptions.ChainName, UUID.NoHyphens, stream_identifier, address, mode);
        }


        public async Task<RpcResponse<GetTotalBalancesResult[]>> GetTotalBalancesAsync(string blockchainName, string id, int min_conf, bool include_watch_only, bool include_locked)
        {
            var response = await TransactAsync<RpcResponse<GetTotalBalancesResult[]>>(blockchainName, WalletAction.GetTotalBalancesMethod, id, min_conf, include_watch_only, include_locked);

            return response;
        }

        public Task<RpcResponse<GetTotalBalancesResult[]>> GetTotalBalancesAsync(int min_conf, bool include_watch_only, bool include_locked)
        {
            return GetTotalBalancesAsync(BlockchainOptions.ChainName, UUID.NoHyphens, min_conf, include_watch_only, include_locked);
        }


        public async Task<RpcResponse<GetTransactionResult>> GetTransactionAsync(string blockchainName, string id, string txid, bool include_watch_only)
        {
            var response = await TransactAsync<RpcResponse<GetTransactionResult>>(blockchainName, WalletAction.GetTransactionMethod, id, txid, include_watch_only);

            return response;
        }

        public Task<RpcResponse<GetTransactionResult>> GetTransactionAsync(string txid, bool include_watch_only)
        {
            return GetTransactionAsync(BlockchainOptions.ChainName, UUID.NoHyphens, txid, include_watch_only);
        }


        public async Task<RpcResponse<object>> GetTxOutDataAsync(string blockchainName, string id, string txid, int vout, int count_bytes, int start_byte)
        {
            RpcResponse<object> response;
            if (count_bytes > 0)
                response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.GetTxOutDataMethod, id, txid, vout, count_bytes, start_byte);
            else
                response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.GetTxOutDataMethod, id, txid, vout);

            return response;
        }

        public Task<RpcResponse<object>> GetTxOutDataAsync(string txid, int vout, int count_bytes, int start_byte)
        {
            return GetTxOutDataAsync(BlockchainOptions.ChainName, UUID.NoHyphens, txid, vout, count_bytes, start_byte);
        }


        public async Task<RpcResponse<object>> GetUnconfirmedBalanceAsync(string blockchainName, string id)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.GetUnconfirmedBalanceMethod, id);

            return response;
        }

        public Task<RpcResponse<object>> GetUnconfirmedBalanceAsync()
        {
            return GetUnconfirmedBalanceAsync(BlockchainOptions.ChainName, UUID.NoHyphens);
        }


        public async Task<RpcResponse<GetWalletInfoResult>> GetWalletInfoAsync(string blockchainName, string id)
        {
            var response = await TransactAsync<RpcResponse<GetWalletInfoResult>>(blockchainName, WalletAction.GetwalletinfoMethod, id);

            return response;
        }

        public Task<RpcResponse<GetWalletInfoResult>> GetWalletInfoAsync()
        {
            return GetWalletInfoAsync(BlockchainOptions.ChainName, UUID.NoHyphens);
        }


        public async Task<RpcResponse<GetWalletTransactionResult>> GetWalletTransactionAsync(string blockchainName, string id, string txid, bool include_watch_only, bool verbose)
        {
            var response = await TransactAsync<RpcResponse<GetWalletTransactionResult>>(blockchainName, WalletAction.GetWalletTransactionMethod, id, txid, include_watch_only, verbose);

            return response;
        }

        public Task<RpcResponse<GetWalletTransactionResult>> GetWalletTransactionAsync(string txid, bool include_watch_only, bool verbose)
        {
            return GetWalletTransactionAsync(BlockchainOptions.ChainName, UUID.NoHyphens, txid, include_watch_only, verbose);
        }


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

        public Task<RpcResponse<object>> GrantAsync(string addresses, string permissions, decimal native_amount, int start_block, uint end_block, string comment, string comment_to)
        {
            return GrantAsync(BlockchainOptions.ChainName, UUID.NoHyphens, addresses, permissions, native_amount, start_block, end_block, comment, comment_to);
        }


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

        public Task<RpcResponse<object>> GrantFromAsync(string from_address, string addresses, string permissions, decimal native_amount, int start_block, uint end_block, string comment, string comment_to)
        {
            return GrantFromAsync(BlockchainOptions.ChainName, UUID.NoHyphens, from_address, addresses, permissions, native_amount, start_block, end_block, comment, comment_to);
        }


        public async Task<RpcResponse<object>> GrantWithDataAsync(string blockchainName, string id, string addresses, string permissions, object object_or_hex, decimal native_amount, int start_block, uint end_block)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.GrantWithDataMethod, id, addresses, permissions, object_or_hex, native_amount, start_block, end_block);

            return response;
        }

        public Task<RpcResponse<object>> GrantWithDataAsync(string addresses, string permissions, object object_or_hex, decimal native_amount, int start_block, uint end_block)
        {
            return GrantWithDataAsync(BlockchainOptions.ChainName, UUID.NoHyphens, addresses, permissions, object_or_hex, native_amount, start_block, end_block);
        }


        public async Task<RpcResponse<object>> GrantWithDataFromAsync(string blockchainName, string id, string from_address, string to_addresses, string permissions, object object_or_hex, decimal native_amount, int start_block, uint end_block)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.GrantWithDataFromMethod, id, from_address, to_addresses, permissions, object_or_hex, native_amount, start_block, end_block);

            return response;
        }

        public Task<RpcResponse<object>> GrantWithDataFromAsync(string from_address, string to_addresses, string permissions, object object_or_hex, decimal native_amount, int start_block, uint end_block)
        {
            return GrantWithDataFromAsync(BlockchainOptions.ChainName, UUID.NoHyphens, from_address, to_addresses, permissions, object_or_hex, native_amount, start_block, end_block);
        }


        public async Task<RpcResponse<object>> ImportAddressAsync(string blockchainName, string id, object addresses, string label, object rescan)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.ImportAddressMethod, id, addresses, label, rescan);

            return response;
        }

        public Task<RpcResponse<object>> ImportAddressAsync(object addresses, string label, object rescan)
        {
            return ImportAddressAsync(BlockchainOptions.ChainName, UUID.NoHyphens, addresses, label, rescan);
        }


        public async Task<RpcResponse<object>> ImportPrivKeyAsync(string blockchainName, string id, object priv_keys, string label, object rescan)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.ImportPrivKeyMethod, id, priv_keys, label, rescan);

            return response;
        }

        public Task<RpcResponse<object>> ImportPrivKeyAsync(object priv_keys, string label, object rescan)
        {
            return ImportPrivKeyAsync(BlockchainOptions.ChainName, UUID.NoHyphens, priv_keys, label, rescan);
        }


        public async Task<RpcResponse<object>> ImportWalletAsync(string blockchainName, string id, string filename, object rescan)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.ImportWalletMethod, id, filename, rescan);

            return response;
        }

        public Task<RpcResponse<object>> ImportWalletAsync(string filename, object rescan)
        {
            return ImportWalletAsync(BlockchainOptions.ChainName, UUID.NoHyphens, filename, rescan);
        }


        public async Task<RpcResponse<string>> IssueAsync(string blockchainName, string id, string to_address, object asset_params, int quantity, double units, decimal native_amount, object metadata)
        {
            var response = await TransactAsync<RpcResponse<string>>(blockchainName, WalletAction.IssueMethod, id, to_address, asset_params, quantity, units, native_amount, metadata);

            return response;
        }

        public Task<RpcResponse<string>> IssueAsync(string to_address, object asset_params, int quantity, double units, decimal native_amount, object metadata)
        {
            return IssueAsync(BlockchainOptions.ChainName, UUID.NoHyphens, to_address, asset_params, quantity, units, native_amount, metadata);
        }


        public async Task<RpcResponse<string>> IssueFromAsync(string blockchainName, string id, string from_address, string to_address, object asset_params, int quantity, double units, decimal native_amount, object metadata)
        {
            var response = await TransactAsync<RpcResponse<string>>(blockchainName, WalletAction.IssueFromMethod, id, from_address, to_address, asset_params, quantity, units, native_amount, metadata);

            return response;
        }

        public Task<RpcResponse<string>> IssueFromAsync(string from_address, string to_address, object asset_params, int quantity, double units, decimal native_amount, object metadata)
        {
            return IssueFromAsync(BlockchainOptions.ChainName, UUID.NoHyphens, from_address, to_address, asset_params, quantity, units, native_amount, metadata);
        }


        public async Task<RpcResponse<object>> IssueMoreAsync(string blockchainName, string id, string to_address, string asset_identifier, int quantity, decimal native_amount, object custom_fields)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.IssueMoreMethod, id, to_address, asset_identifier, quantity, native_amount, custom_fields);

            return response;
        }

        public Task<RpcResponse<object>> IssueMoreAsync(string to_address, string asset_identifier, int quantity, decimal native_amount, object custom_fields)
        {
            return IssueMoreAsync(BlockchainOptions.ChainName, UUID.NoHyphens, to_address, asset_identifier, quantity, native_amount, custom_fields);
        }


        public async Task<RpcResponse<object>> IssueMoreFromAsync(string blockchainName, string id, string from_address, string to_address, string asset_identifier, int quantity, decimal native_amount, object custom_fields)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.IssueMoreFromMethod, id, from_address, to_address, asset_identifier, quantity, native_amount, custom_fields);

            return response;
        }

        public Task<RpcResponse<object>> IssueMoreFromAsync(string from_address, string to_address, string asset_identifier, int quantity, decimal native_amount, object custom_fields)
        {
            return IssueMoreFromAsync(BlockchainOptions.ChainName, UUID.NoHyphens, from_address, to_address, asset_identifier, quantity, native_amount, custom_fields);
        }


        public async Task<RpcResponse<object>> KeyPoolRefillAsync(string blockchainName, string id, int new_size)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.KeyPoolRefillMethod, id, new_size);

            return response;
        }
        public Task<RpcResponse<object>> KeyPoolRefillAsync(int new_size)
        {
            return KeyPoolRefillAsync(BlockchainOptions.ChainName, UUID.NoHyphens, new_size);
        }


        public async Task<RpcResponse<object>> ListAccountsAsync(string blockchainName, string id, int min_conf, bool include_watch_only)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.ListAccountsMethod, id, min_conf, include_watch_only);

            return response;
        }

        public Task<RpcResponse<object>> ListAccountsAsync(int min_conf, bool include_watch_only)
        {
            return ListAccountsAsync(BlockchainOptions.ChainName, UUID.NoHyphens, min_conf, include_watch_only);
        }


        public async Task<RpcResponse<ListAddressesResult[]>> ListAddressesAsync(string blockchainName, string id, object addresses, bool verbose, int count, int start)
        {
            var response = await TransactAsync<RpcResponse<ListAddressesResult[]>>(blockchainName, WalletAction.ListAddressesMethod, id, addresses, verbose, count, start);

            return response;
        }

        public Task<RpcResponse<ListAddressesResult[]>> ListAddressesAsync(object addresses, bool verbose, int count, int start)
        {
            return ListAddressesAsync(BlockchainOptions.ChainName, UUID.NoHyphens, addresses, verbose, count, start);
        }


        public async Task<RpcResponse<object>> ListAddressGroupingsAsync(string blockchainName, string id)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.ListAddressGroupingsMethod, id);

            return response;
        }

        public Task<RpcResponse<object>> ListAddressGroupingsAsync()
        {
            return ListAddressGroupingsAsync(BlockchainOptions.ChainName, UUID.NoHyphens);
        }


        public async Task<RpcResponse<ListAddressTransactionsResult[]>> ListAddressTransactionsAsync(string blockchainName, string id, string address, int count, int skip, bool verbose)
        {
            var response = await TransactAsync<RpcResponse<ListAddressTransactionsResult[]>>(blockchainName, WalletAction.ListAddressTransactionsMethod, id, address, count, skip, verbose);

            return response;
        }

        public Task<RpcResponse<ListAddressTransactionsResult[]>> ListAddressTransactionsAsync(string address, int count, int skip, bool verbose)
        {
            return ListAddressTransactionsAsync(BlockchainOptions.ChainName, UUID.NoHyphens, address, count, skip, verbose);
        }



        public async Task<RpcResponse<ListAssetTransactionsResult[]>> ListAssetTransactionsAsync(string blockchainName, string id, string asset_identifier, bool verbose, int count, int start, bool local_ordering)
        {
            var response = await TransactAsync<RpcResponse<ListAssetTransactionsResult[]>>(blockchainName, WalletAction.ListAssetTransactionsMethod, id, asset_identifier, verbose, count, start, local_ordering);

            return response;
        }

        public Task<RpcResponse<ListAssetTransactionsResult[]>> ListAssetTransactionsAsync(string asset_identifier, bool verbose, int count, int start, bool local_ordering)
        {
            return ListAssetTransactionsAsync(BlockchainOptions.ChainName, UUID.NoHyphens, asset_identifier, verbose, count, start, local_ordering);
        }


        public async Task<RpcResponse<object>> ListLockUnspentAsync(string blockchainName, string id)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.ListLockUnspentMethod, id);

            return response;
        }

        public Task<RpcResponse<object>> ListLockUnspentAsync()
        {
            return ListLockUnspentAsync(BlockchainOptions.ChainName, UUID.NoHyphens);
        }


        public async Task<RpcResponse<object>> ListReceivedByAccountAsync(string blockchainName, string id, int min_conf, bool include_empty, bool include_watch_only)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.ListReceivedByAccountMethod, id, min_conf, include_empty, include_watch_only);

            return response;
        }

        public Task<RpcResponse<object>> ListReceivedByAccountAsync(int min_conf, bool include_empty, bool include_watch_only)
        {
            return ListReceivedByAccountAsync(BlockchainOptions.ChainName, UUID.NoHyphens, min_conf, include_empty, include_watch_only);
        }


        public async Task<RpcResponse<object>> ListReceivedByAddressAsync(string blockchainName, string id, int min_conf, bool include_empty, bool include_watch_only)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.ListReceivedByAddressMethod, id, min_conf, include_empty, include_watch_only);

            return response;
        }

        public Task<RpcResponse<object>> ListReceivedByAddressAsync(int min_conf, bool include_empty, bool include_watch_only)
        {
            return ListReceivedByAddressAsync(BlockchainOptions.ChainName, UUID.NoHyphens, min_conf, include_empty, include_watch_only);
        }


        public async Task<RpcResponse<object>> ListSinceBlockAsync(string blockchainName, string id, string block_hash, int target_confirmations, bool include_watch_only)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.ListSinceBlockMethod, id, block_hash, target_confirmations, include_watch_only);

            return response;
        }

        public Task<RpcResponse<object>> ListSinceBlockAsync(string block_hash, int target_confirmations, bool include_watch_only)
        {
            return ListSinceBlockAsync(BlockchainOptions.ChainName, UUID.NoHyphens, block_hash, target_confirmations, include_watch_only);
        }


        public async Task<RpcResponse<object>> ListStreamBlockItemsAsync(string blockchainName, string id, string stream_identifier, object block_set_identifier, bool verbose, int count, int start)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.ListStreamBlockItemsMethod, id, stream_identifier, block_set_identifier, verbose, count, start);

            return response;
        }

        public Task<RpcResponse<object>> ListStreamBlockItemsAsync(string stream_identifier, object block_set_identifier, bool verbose, int count, int start)
        {
            return ListStreamBlockItemsAsync(BlockchainOptions.ChainName, UUID.NoHyphens, stream_identifier, block_set_identifier, verbose, count, start);
        }


        public async Task<RpcResponse<ListStreamItemsResult[]>> ListStreamItemsAsync(string blockchainName, string id, string stream_identifier, bool verbose, int count, int start, bool local_ordering)
        {
            var response = await TransactAsync<RpcResponse<ListStreamItemsResult[]>>(blockchainName, WalletAction.ListStreamItemsMethod, id, stream_identifier, verbose, count, start, local_ordering);

            return response;
        }

        public Task<RpcResponse<ListStreamItemsResult[]>> ListStreamItemsAsync(string stream_identifier, bool verbose, int count, int start, bool local_ordering)
        {
            return ListStreamItemsAsync(BlockchainOptions.ChainName, UUID.NoHyphens, stream_identifier, verbose, count, start, local_ordering);
        }


        public async Task<RpcResponse<ListStreamKeyItemsResult[]>> ListStreamKeyItemsAsync(string blockchainName, string id, string stream_identifier, string key, bool verbose, int count, int start, bool local_ordering)
        {
            var response = await TransactAsync<RpcResponse<ListStreamKeyItemsResult[]>>(blockchainName, WalletAction.ListStreamKeyItemsMethod, id, stream_identifier, key, verbose, count, start, local_ordering);

            return response;
        }

        public Task<RpcResponse<ListStreamKeyItemsResult[]>> ListStreamKeyItemsAsync(string stream_identifier, string key, bool verbose, int count, int start, bool local_ordering)
        {
            return ListStreamKeyItemsAsync(BlockchainOptions.ChainName, UUID.NoHyphens, stream_identifier, key, verbose, count, start, local_ordering);
        }


        public async Task<RpcResponse<ListStreamKeysResult[]>> ListStreamKeysAsync(string blockchainName, string id, string stream_identifier, object keys, bool verbose, int count, int start, bool local_ordering)
        {
            var response = await TransactAsync<RpcResponse<ListStreamKeysResult[]>>(blockchainName, WalletAction.ListStreamKeysMethod, id, stream_identifier, keys, verbose, count, start, local_ordering);

            return response;
        }

        public Task<RpcResponse<ListStreamKeysResult[]>> ListStreamKeysAsync(string stream_identifier, object keys, bool verbose, int count, int start, bool local_ordering)
        {
            return ListStreamKeysAsync(BlockchainOptions.ChainName, UUID.NoHyphens, stream_identifier, keys, verbose, count, start, local_ordering);
        }


        public async Task<RpcResponse<ListStreamPublisherItemsResult[]>> ListStreamPublisherItemsAsync(string blockchainName, string id, string stream_identifiers, string address, bool verbose, int count, int start, bool local_ordering)
        {
            var response = await TransactAsync<RpcResponse<ListStreamPublisherItemsResult[]>>(blockchainName, WalletAction.ListStreamPublisherItemsMethod, id, stream_identifiers, address, verbose, count, start, local_ordering);

            return response;
        }

        public Task<RpcResponse<ListStreamPublisherItemsResult[]>> ListStreamPublisherItemsAsync(string stream_identifiers, string address, bool verbose, int count, int start, bool local_ordering)
        {
            return ListStreamPublisherItemsAsync(BlockchainOptions.ChainName, UUID.NoHyphens, stream_identifiers, address, verbose, count, start, local_ordering);
        }


        public async Task<RpcResponse<ListStreamPublishersResult[]>> ListStreamPublishersAsync(string blockchainName, string id, string stream_identifier, object addresses, bool verbose, int count, int start, bool local_ordering)
        {
            var response = await TransactAsync<RpcResponse<ListStreamPublishersResult[]>>(blockchainName, WalletAction.ListStreamPublishersMethod, id, stream_identifier, addresses, verbose, count, start, local_ordering);

            return response;
        }

        public Task<RpcResponse<ListStreamPublishersResult[]>> ListStreamPublishersAsync(string stream_identifier, object addresses, bool verbose, int count, int start, bool local_ordering)
        {
            return ListStreamPublishersAsync(BlockchainOptions.ChainName, UUID.NoHyphens, stream_identifier, addresses, verbose, count, start, local_ordering);
        }


        public async Task<RpcResponse<object>> ListStreamQueryItemsAsync(string blockchainName, string id, string stream_identifier, object query, bool verbose)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.ListStreamQueryItemsMethod, id, stream_identifier, query, verbose);

            return response;
        }

        public Task<RpcResponse<object>> ListStreamQueryItemsAsync(string stream_identifier, object query, bool verbose)
        {
            return ListStreamQueryItemsAsync(BlockchainOptions.ChainName, UUID.NoHyphens, stream_identifier, query, verbose);
        }


        public async Task<RpcResponse<object>> ListStreamTxItemsAsync(string blockchainName, string id, string stream_identifiers, object txids, bool verbose)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.ListStreamTxItemsMethod, id, stream_identifiers, txids, verbose);

            return response;
        }

        public Task<RpcResponse<object>> ListStreamTxItemsAsync(string stream_identifiers, object txids, bool verbose)
        {
            return ListStreamTxItemsAsync(BlockchainOptions.ChainName, UUID.NoHyphens, stream_identifiers, txids, verbose);
        }


        public async Task<RpcResponse<ListTransactionsResult[]>> ListTransactionsAsync(string blockchainName, string id, string account, int count, int from, bool include_watch_only)
        {
            var response = await TransactAsync<RpcResponse<ListTransactionsResult[]>>(blockchainName, WalletAction.ListTransactionsMethod, id, account, count, from, include_watch_only);

            return response;
        }

        public Task<RpcResponse<ListTransactionsResult[]>> ListTransactionsAsync(string account, int count, int from, bool include_watch_only)
        {
            return ListTransactionsAsync(BlockchainOptions.ChainName, UUID.NoHyphens, account, count, from, include_watch_only);
        }


        public async Task<RpcResponse<ListUnspentResult[]>> ListUnspentAsync(string blockchainName, string id, int min_conf, int max_conf, object addresses)
        {
            var response = await TransactAsync<RpcResponse<ListUnspentResult[]>>(blockchainName, WalletAction.ListUnspentMethod, id, min_conf, max_conf, addresses);

            return response;
        }

        public Task<RpcResponse<ListUnspentResult[]>> ListUnspentAsync(int min_conf, int max_conf, object addresses)
        {
            return ListUnspentAsync(BlockchainOptions.ChainName, UUID.NoHyphens, min_conf, max_conf, addresses);
        }


        public async Task<RpcResponse<ListWalletTransactionsResult[]>> ListWalletTransactionsAsync(string blockchainName, string id, int count, int skip, bool include_watch_only, bool verbose)
        {
            var response = await TransactAsync<RpcResponse<ListWalletTransactionsResult[]>>(blockchainName, WalletAction.ListWalletTransactionsMethod, id, count, skip, include_watch_only, verbose);

            return response;
        }

        public Task<RpcResponse<ListWalletTransactionsResult[]>> ListWalletTransactionsAsync(int count, int skip, bool include_watch_only, bool verbose)
        {
            return ListWalletTransactionsAsync(BlockchainOptions.ChainName, UUID.NoHyphens, count, skip, include_watch_only, verbose);
        }


        public async Task<RpcResponse<object>> LockUnspentAsync(string blockchainName, string id, bool unlock, object[] unspent)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.LockUnspentMethod, id, unlock, unspent);

            return response;
        }

        public Task<RpcResponse<object>> LockUnspentAsync(bool unlock, object[] unspent)
        {
            return LockUnspentAsync(BlockchainOptions.ChainName, UUID.NoHyphens, unlock, unspent);
        }


        public async Task<RpcResponse<object>> MoveAsync(string blockchainName, string id, string from_account, string to_account, object amount, int min_conf, string comment)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.MoveMethod, id, from_account, to_account, amount, min_conf, comment);

            return response;
        }

        public Task<RpcResponse<object>> MoveAsync(string from_account, string to_account, object amount, int min_conf, string comment)
        {
            return MoveAsync(BlockchainOptions.ChainName, UUID.NoHyphens, from_account, to_account, amount, min_conf, comment);
        }


        public async Task<RpcResponse<PrepareLockUnspentResult>> PrepareLockUnspentAsync(string blockchainName, string id, object asset_quantities, bool _lock)
        {
            var response = await TransactAsync<RpcResponse<PrepareLockUnspentResult>>(blockchainName, WalletAction.PrepareLockUnspentMethod, id, asset_quantities, _lock);

            return response;
        }

        public Task<RpcResponse<PrepareLockUnspentResult>> PrepareLockUnspentAsync(object asset_quantities, bool _lock)
        {
            return PrepareLockUnspentAsync(BlockchainOptions.ChainName, UUID.NoHyphens, asset_quantities, _lock);
        }


        public async Task<RpcResponse<PrepareLockUnspentFromResult>> PrepareLockUnspentFromAsync(string blockchainName, string id, string from_address, object asset_quantities, bool _lock)
        {
            var response = await TransactAsync<RpcResponse<PrepareLockUnspentFromResult>>(blockchainName, WalletAction.PrepareLockUnspentFromMethod, id, from_address, asset_quantities, _lock);

            return response;
        }

        public Task<RpcResponse<PrepareLockUnspentFromResult>> PrepareLockUnspentFromAsync(string from_address, object asset_quantities, bool _lock)
        {
            return PrepareLockUnspentFromAsync(BlockchainOptions.ChainName, UUID.NoHyphens, from_address, asset_quantities, _lock);
        }


        public async Task<RpcResponse<string>> PublishAsync(string blockchainName, string id, string stream_identifier, object keys, object data_hex_or_object, string options)
        {
            RpcResponse<string> response;
            if (string.IsNullOrEmpty(options))
                response = await TransactAsync<RpcResponse<string>>(blockchainName, WalletAction.PublishMethod, id, stream_identifier, keys, data_hex_or_object);
            else
                response = await TransactAsync<RpcResponse<string>>(blockchainName, WalletAction.PublishMethod, id, stream_identifier, keys, data_hex_or_object, options);

            return response;
        }

        public Task<RpcResponse<string>> PublishAsync(string stream_identifier, object keys, object data_hex_or_object, string options)
        {
            return PublishAsync(BlockchainOptions.ChainName, UUID.NoHyphens, stream_identifier, keys, data_hex_or_object, options);
        }


        public async Task<RpcResponse<string>> PublishFromAsync(string blockchainName, string id, string from_address, string stream_identifier, object keys, object data_hex_or_object, string options)
        {
            RpcResponse<string> response;
            if (string.IsNullOrEmpty(options))
                response = await TransactAsync<RpcResponse<string>>(blockchainName, WalletAction.PublishFromMethod, id, from_address, stream_identifier, keys, data_hex_or_object);
            else
                response = await TransactAsync<RpcResponse<string>>(blockchainName, WalletAction.PublishFromMethod, id, from_address, stream_identifier, keys, data_hex_or_object, options);

            return response;
        }

        public Task<RpcResponse<string>> PublishFromAsync(string from_address, string stream_identifier, object keys, object data_hex_or_object, string options)
        {
            return PublishFromAsync(BlockchainOptions.ChainName, UUID.NoHyphens, from_address, stream_identifier, keys, data_hex_or_object, options);
        }


        public async Task<RpcResponse<string>> PublishMultiAsync(string blockchainName, string id, string stream_identifier, object[] items, string options)
        {
            RpcResponse<string> response;
            if (string.IsNullOrEmpty(options))
                response = await TransactAsync<RpcResponse<string>>(blockchainName, WalletAction.PublishMultiMethod, id, stream_identifier, items);
            else
                response = await TransactAsync<RpcResponse<string>>(blockchainName, WalletAction.PublishMultiMethod, id, stream_identifier, items, options);

            return response;
        }

        public Task<RpcResponse<string>> PublishMultiAsync(string stream_identifier, object[] items, string options)
        {
            return PublishMultiAsync(BlockchainOptions.ChainName, UUID.NoHyphens, stream_identifier, items, options);
        }


        public async Task<RpcResponse<string>> PublishMultiFromAsync(string blockchainName, string id, string from_address, string stream_identifier, object[] items, string options)
        {
            RpcResponse<string> response;
            if (string.IsNullOrEmpty(options))
                response = await TransactAsync<RpcResponse<string>>(blockchainName, WalletAction.PublishMultiFromMethod, id, from_address, stream_identifier, items);
            else
                response = await TransactAsync<RpcResponse<string>>(blockchainName, WalletAction.PublishMultiFromMethod, id, from_address, stream_identifier, items, options);

            return response;
        }

        public Task<RpcResponse<string>> PublishMultiFromAsync(string from_address, string stream_identifier, object[] items, string options)
        {
            return PublishMultiFromAsync(BlockchainOptions.ChainName, UUID.NoHyphens, from_address, stream_identifier, items, options);
        }


        public async Task<RpcResponse<object>> ResendWalletTransactionsAsync(string blockchainName, string id)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.ResendWalletTransactionsMethod, id);

            return response;
        }

        public Task<RpcResponse<object>> ResendWalletTransactionsAsync()
        {
            return ResendWalletTransactionsAsync(BlockchainOptions.ChainName, UUID.NoHyphens);
        }


        public async Task<RpcResponse<object>> RevokeAsync(string blockchainName, string id, string addresses, string permissions, double native_amount, string comment, string comment_to)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.RevokeMethod, id, addresses, permissions, native_amount, comment, comment_to);

            return response;
        }

        public Task<RpcResponse<object>> RevokeAsync(string addresses, string permissions, double native_amount, string comment, string comment_to)
        {
            return RevokeAsync(BlockchainOptions.ChainName, UUID.NoHyphens, addresses, permissions, native_amount, comment, comment_to);
        }


        public async Task<RpcResponse<object>> RevokeFromAsync(string blockchainName, string id, string from_address, string to_addresses, string permissions, double native_amount, string comment, string comment_to)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.RevokeFromMethod, id, from_address, to_addresses, permissions, native_amount, comment, comment_to);

            return response;
        }

        public Task<RpcResponse<object>> RevokeFromAsync(string from_address, string to_addresses, string permissions, double native_amount, string comment, string comment_to)
        {
            return RevokeFromAsync(BlockchainOptions.ChainName, UUID.NoHyphens, from_address, to_addresses, permissions, native_amount, comment, comment_to);
        }


        public async Task<RpcResponse<string>> SendAsync(string blockchainName, string id, string to_address, object amount_or_asset_quantities, string comment, string comment_to)
        {
            var response = await TransactAsync<RpcResponse<string>>(blockchainName, WalletAction.SendMethod, id, to_address, amount_or_asset_quantities, comment, comment_to);

            return response;
        }

        public Task<RpcResponse<string>> SendAsync(string to_address, object amount_or_asset_quantities, string comment, string comment_to)
        {
            return SendAsync(BlockchainOptions.ChainName, UUID.NoHyphens, to_address, amount_or_asset_quantities, comment, comment_to);
        }


        public async Task<RpcResponse<object>> SendAssetAsync(string blockchainName, string id, string to_address, string asset_identifier, int asset_quantity, double native_amount, string comment, string comment_to)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.SendAssetMethod, id, to_address, asset_identifier, asset_quantity, native_amount, comment, comment_to);

            return response;
        }

        public Task<RpcResponse<object>> SendAssetAsync(string to_address, string asset_identifier, int asset_quantity, double native_amount, string comment, string comment_to)
        {
            return SendAssetAsync(BlockchainOptions.ChainName, UUID.NoHyphens, to_address, asset_identifier, asset_quantity, native_amount, comment, comment_to);
        }


        public async Task<RpcResponse<object>> SendAssetFromAsync(string blockchainName, string id, string from_address, string to_address, string asset_identifier, int asset_quantity, double native_amount, string comment, string comment_to)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.SendAssetFromMethod, id, from_address, to_address, asset_identifier, asset_quantity, native_amount, comment, comment_to);

            return response;
        }

        public Task<RpcResponse<object>> SendAssetFromAsync(string from_address, string to_address, string asset_identifier, int asset_quantity, double native_amount, string comment, string comment_to)
        {
            return SendAssetFromAsync(BlockchainOptions.ChainName, UUID.NoHyphens, from_address, to_address, asset_identifier, asset_quantity, native_amount, comment, comment_to);
        }


        public async Task<RpcResponse<object>> SendFromAsync(string blockchainName, string id, string from_address, string to_address, object amount_or_asset_quantities, string comment, string comment_to)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.SendFromMethod, id, from_address, to_address, amount_or_asset_quantities, comment, comment_to);

            return response;
        }

        public Task<RpcResponse<object>> SendFromAsync(string from_address, string to_address, object amount_or_asset_quantities, string comment, string comment_to)
        {
            return SendFromAsync(BlockchainOptions.ChainName, UUID.NoHyphens, from_address, to_address, amount_or_asset_quantities, comment, comment_to);
        }


        public async Task<RpcResponse<object>> SendFromAccountAsync(string blockchainName, string id, string from_account, string to_address, object amount, int min_conf, string comment, string comment_to)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.SendFromAccountMethod, id, from_account, to_address, amount, min_conf, comment, comment_to);

            return response;
        }

        public Task<RpcResponse<object>> SendFromAccountAsync(string from_account, string to_address, object amount, int min_conf, string comment, string comment_to)
        {
            return SendFromAccountAsync(BlockchainOptions.ChainName, UUID.NoHyphens, from_account, to_address, amount, min_conf, comment, comment_to);
        }


        public async Task<RpcResponse<object>> SendManyAsync(string blockchainName, string id, string from_account, object[] amounts, int min_conf, string comment)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.SendManyMethod, id, from_account, amounts, min_conf, comment);

            return response;
        }

        public Task<RpcResponse<object>> SendManyAsync(string from_account, object[] amounts, int min_conf, string comment)
        {
            return SendManyAsync(BlockchainOptions.ChainName, UUID.NoHyphens, from_account, amounts, min_conf, comment);
        }


        public async Task<RpcResponse<object>> SendWithDataAsync(string blockchainName, string id, string to_address, object amount_or_asset_quantities, object data_or_publish_new_stream_item)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.SendWithDataMethod, id, to_address, amount_or_asset_quantities, data_or_publish_new_stream_item);

            return response;
        }

        public Task<RpcResponse<object>> SendWithDataAsync(string to_address, object amount_or_asset_quantities, object data_or_publish_new_stream_item)
        {
            return SendWithDataAsync(BlockchainOptions.ChainName, UUID.NoHyphens, to_address, amount_or_asset_quantities, data_or_publish_new_stream_item);
        }

        public async Task<RpcResponse<object>> SendWithDataFromAsync(string blockchainName, string id, string from_address, string to_address, object amount_or_asset_quantities, object data_or_publish_new_stream_item)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.SendWithDataFromMethod, id, from_address, to_address, amount_or_asset_quantities, data_or_publish_new_stream_item);

            return response;
        }

        public Task<RpcResponse<object>> SendWithDataFromAsync(string from_address, string to_address, object amount_or_asset_quantities, object data_or_publish_new_stream_item)
        {
            return SendWithDataFromAsync(BlockchainOptions.ChainName, UUID.NoHyphens, from_address, to_address, amount_or_asset_quantities, data_or_publish_new_stream_item);
        }


        public async Task<RpcResponse<object>> SetAccountAsync(string blockchainName, string id, string address, string account)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.SetAccountMethod, id, address, account);

            return response;
        }

        public Task<RpcResponse<object>> SetAccountAsync(string address, string account)
        {
            return SetAccountAsync(BlockchainOptions.ChainName, UUID.NoHyphens, address, account);
        }


        public async Task<RpcResponse<object>> SetTxFeeAsync(string blockchainName, string id, double amount)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.SetTxFeeMethod, id, amount);

            return response;
        }

        public Task<RpcResponse<object>> SetTxFeeAsync(double amount)
        {
            return SetTxFeeAsync(BlockchainOptions.ChainName, UUID.NoHyphens, amount);
        }


        public async Task<RpcResponse<string>> SignMessageAsync(string blockchainName, string id, string address_or_privkey, string message)
        {
            var response = await TransactAsync<RpcResponse<string>>(blockchainName, WalletAction.SignMessageMethod, id, address_or_privkey, message);

            return response;
        }

        public Task<RpcResponse<string>> SignMessageAsync(string address_privkey, string message)
        {
            return SignMessageAsync(BlockchainOptions.ChainName, UUID.NoHyphens, address_privkey, message);
        }


        public async Task<RpcResponse<object>> SubscribeAsync(string blockchainName, string id, object entity_identifiers, bool rescan, string parameters)
        {
            RpcResponse<object> response;
            if (string.IsNullOrEmpty(parameters))
                response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.SubscribeMethod, id, entity_identifiers, rescan);
            else
                response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.SubscribeMethod, id, entity_identifiers, rescan, parameters);

            return response;
        }

        public Task<RpcResponse<object>> SubscribeAsync(object entity_identifiers, bool rescan, string parameters)
        {
            return SubscribeAsync(BlockchainOptions.ChainName, UUID.NoHyphens, entity_identifiers, rescan, parameters);
        }


        public async Task<RpcResponse<object>> TrimSubscribeAsync(string blockchainName, string id, object streams, string parameters)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.TrimSubscribeMethod, id, streams, parameters);

            return response;
        }

        public Task<RpcResponse<object>> TrimSubscribeAsync(object streams, string parameters)
        {
            return TrimSubscribeAsync(BlockchainOptions.ChainName, UUID.NoHyphens, streams, parameters);
        }


        public async Task<RpcResponse<double>> TxOutToBinaryCacheAsync(string blockchainName, string id, string identifier, string txid, int vout, int count_bytes, int start_byte)
        {
            var response = await TransactAsync<RpcResponse<double>>(blockchainName, WalletAction.TxOutToBinaryCacheMethod, id, identifier, txid, vout, count_bytes, start_byte);

            return response;
        }

        public Task<RpcResponse<double>> TxOutToBinaryCacheAsync(string identifier, string txid, int vout, int count_bytes, int start_byte)
        {
            return TxOutToBinaryCacheAsync(BlockchainOptions.ChainName, UUID.NoHyphens, identifier, txid, vout, count_bytes, start_byte);
        }


        public async Task<RpcResponse<object>> UnsubscribeAsync(string blockchainName, string id, object entity_identifiers, bool purge)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.UnsubscribeMethod, id, entity_identifiers, purge);

            return response;
        }

        public Task<RpcResponse<object>> UnsubscribeAsync(object entity_identifiers, bool purge)
        {
            return UnsubscribeAsync(BlockchainOptions.ChainName, UUID.NoHyphens, entity_identifiers, purge);
        }


        public async Task<RpcResponse<object>> WalletLockAsync(string blockchainName, string id)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.WalletLockMethod, id);

            return response;
        }

        public Task<RpcResponse<object>> WalletLockAsync()
        {
            return WalletLockAsync(BlockchainOptions.ChainName, UUID.NoHyphens);
        }


        public async Task<RpcResponse<object>> WalletPassphraseAsync(string blockchainName, string id, string passphrase, int time_out)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.WalletPassphraseMethod, id, passphrase, time_out);

            return response;
        }

        public Task<RpcResponse<object>> WalletPassphraseAsync(string passphrase, int time_out)
        {
            return WalletPassphraseAsync(BlockchainOptions.ChainName, UUID.NoHyphens, passphrase, time_out);
        }


        public async Task<RpcResponse<object>> WalletPassphraseChangeAsync(string blockchainName, string id, string old_passphrase, string new_passphrase)
        {
            var response = await TransactAsync<RpcResponse<object>>(blockchainName, WalletAction.WalletPassphraseChangeMethod, id, old_passphrase, new_passphrase);

            return response;
        }

        public Task<RpcResponse<object>> WalletPassphraseChangeAsync(string old_passphrase, string new_passphrase)
        {
            return WalletPassphraseChangeAsync(BlockchainOptions.ChainName, UUID.NoHyphens, old_passphrase, new_passphrase);
        }
    }
}
