using Newtonsoft.Json;

namespace MCWrapper.RPC.Ledger.Models.Wallet
{
    /// <summary>
    /// 
    /// </summary>
    public class DecodeRawExchangeResult
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("offer")]
        public DecodeRawExchangeOffer Offer { get; set; } = new DecodeRawExchangeOffer();

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("ask")]
        public DecodeRawExchangeAsk Ask { get; set; } = new DecodeRawExchangeAsk();

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("requiredfee")]
        public int RequiredFee { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("candisable")]
        public bool Candisable { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("cancomplete")]
        public bool CanComplete { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("complete")]
        public bool Complete { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("exchanges")]
        public DecodeRawExchangeExchange[] Exchanges { get; set; } = new DecodeRawExchangeExchange[] { };
    }

    /// <summary>
    /// 
    /// </summary>
    public class DecodeRawExchangeOffer
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("amount")]
        public int Amount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("assets")]
        public DecodeRawExchangeAsset[] Assets { get; set; } = new DecodeRawExchangeAsset[] { };
    }

    /// <summary>
    /// 
    /// </summary>
    public class DecodeRawExchangeAsset
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
        public object AssetRef { get; set; } = new { };

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("qty")]
        public int Qty { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class DecodeRawExchangeAsk
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("amount")]
        public int Amount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("assets")]
        public object[] Assets { get; set; } = new object[] { };
    }

    /// <summary>
    /// 
    /// </summary>
    public class DecodeRawExchangeExchange
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("offer")]
        public DecodeRawExchangeOffer1 Offer { get; set; } = new DecodeRawExchangeOffer1();

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("ask")]
        public DecodeRawExchangeAsk1 Ask { get; set; } = new DecodeRawExchangeAsk1();
    }

    /// <summary>
    /// 
    /// </summary>
    public class DecodeRawExchangeOffer1
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("amount")]
        public int Amount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("assets")]
        public DecodeRawExchangeAsset1[] Assets { get; set; } = new DecodeRawExchangeAsset1[] { };

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("address")]
        public string Address { get; set; } = string.Empty;

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
    }

    /// <summary>
    /// 
    /// </summary>
    public class DecodeRawExchangeAsset1
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
        public object AssetRef { get; set; } = new { };

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("qty")]
        public int Qty { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class DecodeRawExchangeAsk1
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("amount")]
        public int Amount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("assets")]
        public object[] Assets { get; set; } = new object[] { };

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("address")]
        public string Address { get; set; } = string.Empty;
    }
}