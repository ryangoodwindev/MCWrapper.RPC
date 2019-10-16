using Newtonsoft.Json;

namespace MCWrapper.RPC.Ledger.Models.Blockchain
{
    // Version Verbose

    /// <summary>
    /// 
    /// </summary>
    public class GetBlockVerboseResult
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("hash")]
        public string Hash { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("miner")]
        public string Miner { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("confirmations")]
        public int Confirmations { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("size")]
        public int Size { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("height")]
        public int Height { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("version")]
        public int Version { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("merkleroot")]
        public string Merkleroot { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("tx")]
        public string[] Tx { get; set; } = new string[] { };

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("time")]
        public int Time { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("nonce")]
        public int Nonce { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("bits")]
        public string Bits { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("difficulty")]
        public float Difficulty { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("chainwork")]
        public string Chainwork { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("previousblockhash")]
        public string PreviousBlockHash { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("nextblockhash")]
        public string NextBlockHash { get; set; } = string.Empty;
    }


    // Version Concise

    /// <summary>
    /// 
    /// </summary>
    public class GetBlockResultV1
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("hash")]
        public string Hash { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("miner")]
        public string Miner { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("confirmations")]
        public int Confirmations { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("size")]
        public int Size { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("height")]
        public int Height { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("version")]
        public int Version { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("merkleroot")]
        public string Merkleroot { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("tx")]
        public string[] Tx { get; set; } = new string[] { };

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("time")]
        public int Time { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("nonce")]
        public int Nonce { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("bits")]
        public string Bits { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("difficulty")]
        public float Difficulty { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("chainwork")]
        public string Chainwork { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("previousblockhash")]
        public string PreviousBlockHash { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("nextblockhash")]
        public string NextBlockHash { get; set; } = string.Empty;
    }


    // Version 2

    /// <summary>
    /// 
    /// </summary>
    public class GetBlockResultV2
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("hash")]
        public string Hash { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("miner")]
        public string Miner { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("confirmations")]
        public int Confirmations { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("size")]
        public int Size { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("height")]
        public int Height { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("version")]
        public int Version { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("merkleroot")]
        public string Merkleroot { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("tx")]
        public GetBlockTxV2[] Tx { get; set; } = new GetBlockTxV2[] { };

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("time")]
        public int Time { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("nonce")]
        public int Nonce { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("bits")]
        public string Bits { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("difficulty")]
        public float Difficulty { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("chainwork")]
        public string Chainwork { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("previousblockhash")]
        public string PreviousBlockHash { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("nextblockhash")]
        public string NextBlockHash { get; set; } = string.Empty;
    }

    /// <summary>
    /// 
    /// </summary>
    public class GetBlockTxV2
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("txid")]
        public string Txid { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("hex")]
        public string Hex { get; set; } = string.Empty;
    }


    // Version 3

    /// <summary>
    /// 
    /// </summary>
    public class GetBlockResultV3
    {
         /// <summary>
        /// 
        /// </summary>
        [JsonProperty("hash")]
        public string Hash { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("miner")]
        public string Miner { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("confirmations")]
        public int Confirmations { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("size")]
        public int Size { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("height")]
        public int Height { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("version")]
        public int Version { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("merkleroot")]
        public string Merkleroot { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("tx")]
        public GetBlockTxV3[] Tx { get; set; } = new GetBlockTxV3[] { };

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("time")]
        public int Time { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("nonce")]
        public int Nonce { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("bits")]
        public string Bits { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("difficulty")]
        public float Difficulty { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("chainwork")]
        public string Chainwork { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("previousblockhash")]
        public string PreviousBlockHash { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("nextblockhash")]
        public string NextBlockHash { get; set; } = string.Empty;
    }

    /// <summary>
    /// 
    /// </summary>
    public class GetBlockTxV3
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("txid")]
        public string Txid { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("version")]
        public int Version { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("locktime")]
        public int Locktime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("hex")]
        public string Hex { get; set; } = string.Empty;
    }


    // Version 4

    /// <summary>
    /// 
    /// </summary>
    public class GetBlockResultV4
    {
        /// <summary>
        /// 
        /// </summary>
        public GetBlockResultV4() { }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("hash")]
        public string Hash { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("miner")]
        public string Miner { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("confirmations")]
        public int Confirmations { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("size")]
        public int Size { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("height")]
        public int Height { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("version")]
        public int Version { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("merkleroot")]
        public string Merkleroot { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("tx")]
        public GetBlockTxV4[] Tx { get; set; } = new GetBlockTxV4[] { };

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("time")]
        public int Time { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("nonce")]
        public int Nonce { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("bits")]
        public string Bits { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("difficulty")]
        public float Difficulty { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("chainwork")]
        public string Chainwork { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("previousblockhash")]
        public string PreviousBlockhash { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("nextblockhash")]
        public string NextBlockhash { get; set; } = string.Empty;
    }

    /// <summary>
    /// 
    /// </summary>
    public class GetBlockTxV4
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("txid")]
        public string Txid { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("version")]
        public int Version { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("locktime")]
        public int LockTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("vin")]
        public GetBlockVinV4[] Vin { get; set; } = new GetBlockVinV4[] { };

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("vout")]
        public GetBlockVoutV4[] Vout { get; set; } = new GetBlockVoutV4[] { };

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("hex")]
        public string Hex { get; set; } = string.Empty;
    }

    /// <summary>
    /// 
    /// </summary>
    public class GetBlockVinV4
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("coinbase")]
        public string CoinBase { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("sequence")]
        public long Sequence { get; set; }

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
        [JsonProperty("scriptSig")]
        public GetBlockScriptsigV4 ScriptSig { get; set; } = new GetBlockScriptsigV4();
    }

    /// <summary>
    /// 
    /// </summary>
    public class GetBlockScriptsigV4
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("asm")]
        public string Asm { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("hex")]
        public string Hex { get; set; } = string.Empty;
    }

    /// <summary>
    /// 
    /// </summary>
    public class GetBlockVoutV4
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("value")]
        public float Value { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("n")]
        public int N { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("scriptPubKey")]
        public GetBlockScriptpubkeyV4 ScriptPubKey { get; set; } = new GetBlockScriptpubkeyV4();

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("data")]
        public string[] Data { get; set; } = new string[] { };
    }

    /// <summary>
    /// 
    /// </summary>
    public class GetBlockScriptpubkeyV4
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("asm")]
        public string Asm { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("hex")]
        public string Hex { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("reqSigs")]
        public int ReqSigs { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("addresses")]
        public string[] Addresses { get; set; } = new string[] { };
    }

}