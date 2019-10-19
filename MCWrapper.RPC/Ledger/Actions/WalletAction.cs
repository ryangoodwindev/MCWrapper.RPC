namespace MCWrapper.RPC.Ledger.Actions
{
    /// <summary>
    /// Defines all available blockchain wallet service method names
    /// </summary>
    public struct WalletAction
    {
        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "addmultisigaddress"
        /// </summary>
        public const string AddMultiSigAddressMethod = "addmultisigaddress";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "appendrawexchange"
        /// </summary>
        public const string AppendRawExchangeMethod = "appendrawexchange";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "approvefrom"
        /// </summary>
        public const string ApproveFromMethod = "approvefrom";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "backupwallet"
        /// </summary>
        public const string BackupWalletMethod = "backupwallet";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "combineunspent"
        /// </summary>
        public const string CombineUnspentMethod = "combineunspent";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "completerawexchange"
        /// </summary>
        public const string CompleteRawExchangeMethod = "completerawexchange";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "create"
        /// </summary>
        public const string CreateMethod = "create";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "createfrom"
        /// </summary>
        public const string CreateFromMethod = "createfrom";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "createrawexchange"
        /// </summary>
        public const string CreateRawExchangeMethod = "createrawexchange";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "createrawsendfrom"
        /// </summary>
        public const string CreateRawSendFromMethod = "createrawsendfrom";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "decoderawexchange"
        /// </summary>
        public const string DecodeRawExchangeMethod = "decoderawexchange";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "disablerawtransaction"
        /// </summary>
        public const string DisableRawTransactionMethod = "disablerawtransaction";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "dumpprivkey"
        /// </summary>
        public const string DumpPrivKeyMethod = "dumpprivkey";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "dumpwallet"
        /// </summary>
        public const string DumpWalletMethod = "dumpwallet";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "encryptwallet"
        /// </summary>
        public const string EncryptWalletMethod = "encryptwallet";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "getaccount"
        /// </summary>
        public const string GetAccountMethod = "getaccount";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "getaccountaddress"
        /// </summary>
        public const string GetAccountAddressMethod = "getaccountaddress";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "getaddressbalances"
        /// </summary>
        public const string GetAddressBalancesMethod = "getaddressbalances";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "getaddresses"
        /// </summary>
        public const string GetAddressesMethod = "getaddresses";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "getaddressesbyaccount"
        /// </summary>
        public const string GetAddressesByAccountMethod = "getaddressesbyaccount";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "getaddresstransaction"
        /// </summary>
        public const string GetAddressTransactionMethod = "getaddresstransaction";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "getassetbalances"
        /// </summary>
        public const string GetAssetBalancesMethod = "getassetbalances";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "getassettransaction"
        /// </summary>
        public const string GetAssetTransactionMethod = "getassettransaction";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "getbalance"
        /// </summary>
        public const string GetBalanceMethod = "getbalance";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "getmultibalances"
        /// </summary>
        public const string GetMultiBalancesMethod = "getmultibalances";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "getnewaddress"
        /// </summary>
        public const string GetNewAddressMethod = "getnewaddress";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "getrawchangeaddress"
        /// </summary>
        public const string GetRawChangeAddressMethod = "getrawchangeaddress";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "getreceivedbyaccount"
        /// </summary>
        public const string GetReceivedByAccountMethod = "getreceivedbyaccount";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "getreceivedbyaddress"
        /// </summary>
        public const string GetReceivedByAddressMethod = "getreceivedbyaddress";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "getstreamitem"
        /// </summary>
        public const string GetStreamItemMethod = "getstreamitem";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "getstreamkeysummary"
        /// </summary>
        public const string GetStreamKeySummaryMethod = "getstreamkeysummary";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "getstreampublishersummary"
        /// </summary>
        public const string GetStreamPublisherSummaryMethod = "getstreampublishersummary";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "gettotalbalances"
        /// </summary>
        public const string GetTotalBalancesMethod = "gettotalbalances";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "gettransaction"
        /// </summary>
        public const string GetTransactionMethod = "gettransaction";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "gettxoutdata"
        /// </summary>
        public const string GetTxOutDataMethod = "gettxoutdata";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "getunconfirmedbalance"
        /// </summary>
        public const string GetUnconfirmedBalanceMethod = "getunconfirmedbalance";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "getwalletinfo"
        /// </summary>
        public const string GetwalletinfoMethod = "getwalletinfo";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "getwallettransaction"
        /// </summary>
        public const string GetWalletTransactionMethod = "getwallettransaction";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "grant"
        /// </summary>
        public const string GrantMethod = "grant";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "grantfrom"
        /// </summary>
        public const string GrantFromMethod = "grantfrom";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "grantwithdata"
        /// </summary>
        public const string GrantWithDataMethod = "grantwithdata";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "grantwithdatafrom"
        /// </summary>
        public const string GrantWithDataFromMethod = "grantwithdatafrom";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "importaddress"
        /// </summary>
        public const string ImportAddressMethod = "importaddress";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "importprivkey"
        /// </summary>
        public const string ImportPrivKeyMethod = "importprivkey";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "importwallet"
        /// </summary>
        public const string ImportWalletMethod = "importwallet";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "issue"
        /// </summary>
        public const string IssueMethod = "issue";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "issuefrom"
        /// </summary>
        public const string IssueFromMethod = "issuefrom";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "issuemore"
        /// </summary>
        public const string IssueMoreMethod = "issuemore";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "issuemorefrom"
        /// </summary>
        public const string IssueMoreFromMethod = "issuemorefrom";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "keypoolrefill"
        /// </summary>
        public const string KeyPoolRefillMethod = "keypoolrefill";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "listaccounts"
        /// </summary>
        public const string ListAccountsMethod = "listaccounts";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "listaddresses"
        /// </summary>
        public const string ListAddressesMethod = "listaddresses";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "listaddressgroupings"
        /// </summary>
        public const string ListAddressGroupingsMethod = "listaddressgroupings";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "listaddresstransactions"
        /// </summary>
        public const string ListAddressTransactionsMethod = "listaddresstransactions";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "listassettransactions"
        /// </summary>
        public const string ListAssetTransactionsMethod = "listassettransactions";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "listlockunspent"
        /// </summary>
        public const string ListLockUnspentMethod = "listlockunspent";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "listreceivedbyaccount"
        /// </summary>
        public const string ListReceivedByAccountMethod = "listreceivedbyaccount";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "listreceivedbyaddress"
        /// </summary>
        public const string ListReceivedByAddressMethod = "listreceivedbyaddress";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "listsinceblock"
        /// </summary>
        public const string ListSinceBlockMethod = "listsinceblock";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "liststreamblockitems"
        /// </summary>
        public const string ListStreamBlockItemsMethod = "liststreamblockitems";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "liststreamitems"
        /// </summary>
        public const string ListStreamItemsMethod = "liststreamitems";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "liststreamkeyitems"
        /// </summary>
        public const string ListStreamKeyItemsMethod = "liststreamkeyitems";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "liststreamkeys"
        /// </summary>
        public const string ListStreamKeysMethod = "liststreamkeys";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "liststreampublisheritems"
        /// </summary>
        public const string ListStreamPublisherItemsMethod = "liststreampublisheritems";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "liststreampublishers"
        /// </summary>
        public const string ListStreamPublishersMethod = "liststreampublishers";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "liststreamqueryitems"
        /// </summary>
        public const string ListStreamQueryItemsMethod = "liststreamqueryitems";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "liststreamtxitems"
        /// </summary>
        public const string ListStreamTxItemsMethod = "liststreamtxitems";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "listtransactions"
        /// </summary>
        public const string ListTransactionsMethod = "listtransactions";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "listunspent"
        /// </summary>
        public const string ListUnspentMethod = "listunspent";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "listwallettransactions"
        /// </summary>
        public const string ListWalletTransactionsMethod = "listwallettransactions";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "lockunspent"
        /// </summary>
        public const string LockUnspentMethod = "lockunspent";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "move"
        /// </summary>
        public const string MoveMethod = "move";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "preparelockunspent"
        /// </summary>
        public const string PrepareLockUnspentMethod = "preparelockunspent";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "preparelockunspentfrom"
        /// </summary>
        public const string PrepareLockUnspentFromMethod = "preparelockunspentfrom";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "publish"
        /// </summary>
        public const string PublishMethod = "publish";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "publishmulti"
        /// </summary>
        public const string PublishMultiMethod = "publishmulti";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "publishmultifrom"
        /// </summary>
        public const string PublishMultiFromMethod = "publishmultifrom";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "publishfrom"
        /// </summary>
        public const string PublishFromMethod = "publishfrom";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "resendwallettransactions"
        /// </summary>
        public const string ResendWalletTransactionsMethod = "resendwallettransactions";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "revoke"
        /// </summary>
        public const string RevokeMethod = "revoke";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "revokefrom"
        /// </summary>
        public const string RevokeFromMethod = "revokefrom";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "send"
        /// </summary>
        public const string SendMethod = "send";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "sendasset"
        /// </summary>
        public const string SendAssetMethod = "sendasset";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "sendassetfrom"
        /// </summary>
        public const string SendAssetFromMethod = "sendassetfrom";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "sendfrom"
        /// </summary>
        public const string SendFromMethod = "sendfrom";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "sendfromaccount"
        /// </summary>
        public const string SendFromAccountMethod = "sendfromaccount";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "sendmany"
        /// </summary>
        public const string SendManyMethod = "sendmany";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "sendwithdata"
        /// </summary>
        public const string SendWithDataMethod = "sendwithdata";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "sendwithdatafrom"
        /// </summary>
        public const string SendWithDataFromMethod = "sendwithdatafrom";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "setaccount"
        /// </summary>
        public const string SetAccountMethod = "setaccount";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "settxfee"
        /// </summary>
        public const string SetTxFeeMethod = "settxfee";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "signmessage"
        /// </summary>
        public const string SignMessageMethod = "signmessage";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "subscribe"
        /// </summary>
        public const string SubscribeMethod = "subscribe";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "trimsubscribe"
        /// Only available for MultiChain Enterprise users
        /// </summary>
        public const string TrimSubscribeMethod = "trimsubscribe";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "txouttobinarycache"
        /// </summary>
        public const string TxOutToBinaryCacheMethod = "txouttobinarycache";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "unsubscribe"
        /// </summary>
        public const string UnsubscribeMethod = "unsubscribe";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "walletlock"
        /// </summary>
        public const string WalletLockMethod = "walletlock";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "walletpassphrase"
        /// </summary>
        public const string WalletPassphraseMethod = "walletpassphrase";

        /// <summary>
        /// Defines MultiChain Core wallet service method as plain string "walletpassphrasechange"
        /// </summary>
        public const string WalletPassphraseChangeMethod = "walletpassphrasechange";
    }
}