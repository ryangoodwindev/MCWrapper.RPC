using Newtonsoft.Json;
using System;

namespace MCWrapper.RPC.Ledger.Models.Wallet
{
    /// <summary>
    /// 
    /// </summary>
    public class GetWalletTransactionResult
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("balance")]
        public GetWalletTransactionBalance Balance { get; set; } = new GetWalletTransactionBalance();

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("myaddresses")]
        public string[] MyAddresses { get; set; } = new string[] { };

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("addresses")]
        public object[] Addresses { get; set; } = new object[] { };

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("permissions")]
        public object[] Permissions { get; set; } = new object[] { };

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("items")]
        public object[] Items { get; set; } = new object[] { };

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("data")]
        public object[] Data { get; set; } = new object[] { };

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("confirmations")]
        public int Confirmations { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("blockhash")]
        public string BlockHash { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("blockindex")]
        public int BlockIndex { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("blocktime")]
        public int BlockTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("txid")]
        public string Txid { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("valid")]
        public bool Valid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("time")]
        public int Time { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("timereceived")]
        public Int64 TimeReceived { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("vin")]
        public GetWalletTransactionVin[] Vin { get; set; } = new GetWalletTransactionVin[] { };

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("vout")]
        public GetWalletTransactionVout[] Vout { get; set; } = new GetWalletTransactionVout[] { };

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("hex")]
        public string Hex { get; set; } = string.Empty;
    }

    /// <summary>
    /// 
    /// </summary>
    public class GetWalletTransactionBalance
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("assets")]
        public object[] Assets { get; set; } = new object[] { };
    }

    /// <summary>
    /// 
    /// </summary>
    public class GetWalletTransactionVin
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("txid")]
        public string Txid { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("vout")]
        public int Vout { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("addresses")]
        public string[] Addresses { get; set; } = new string[] { };

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("ismine")]
        public bool IsMine { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("iswatchonly")]
        public bool IsWatchOnly { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("assets")]
        public GetWalletTransactionAsset[] Assets { get; set; } = new GetWalletTransactionAsset[] { };
    }

    /// <summary>
    /// 
    /// </summary>
    public class GetWalletTransactionAsset
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("assetref")]
        public string AssetRef { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("qty")]
        public int Qty { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class GetWalletTransactionVout
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("n")]
        public int N { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("addresses")]
        public string[] Addresses { get; set; } = new string[] { };

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("ismine")]
        public bool IsMine { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("iswatchonly")]
        public bool IsWatchOnly { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("assets")]
        public GetWalletTransactionAsset1[] Assets { get; set; } = new GetWalletTransactionAsset1[] { };
    }

    /// <summary>
    /// 
    /// </summary>
    public class GetWalletTransactionAsset1
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("assetref")]
        public string AssetRef { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("qty")]
        public int Qty { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; } = string.Empty;
    }
}