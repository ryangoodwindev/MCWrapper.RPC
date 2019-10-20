using Newtonsoft.Json;

namespace MCWrapper.RPC.Ledger.Models.Wallet.CustomModels
{
    public class Transaction
    {
        [JsonProperty("vout")]
        public int Vout { get; set; }

        [JsonProperty("txid")]
        public string Txid { get; set; } = string.Empty;
    }
}
