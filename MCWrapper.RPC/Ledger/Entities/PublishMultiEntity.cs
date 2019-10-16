using Newtonsoft.Json;

namespace MCWrapper.RPC.Ledger.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class PublishMultiEntity
    {
        /// <summary>
        /// Stream identifier - one of: create txid, stream reference, stream name. Default for items if "for" field is omitted
        /// </summary>
        public string StreamIdentifier { get; set; } = string.Empty;

        /// <summary>
        /// Array of PublishMultiItemEntity objects
        /// </summary>
        public object[] Items { get; set; } = new object[] { };

        /// <summary>
        /// Should be "offchain" or omitted. Default for items if "options" field is omitted
        /// </summary>
        public string Options { get; set; } = string.Empty;
    }

    /// <summary>
    /// 
    /// </summary>
    public class PublishMultiItemKeyEntity
    {
        /// <summary>
        /// Stream identifier, uses default if omitted
        /// </summary>
        [JsonProperty(PropertyName = "for")]
        public string? For
        {
            get => _for;
            set => _for = value;
        }
        private string? _for = null;


        /// <summary>
        /// Should be "offchain" or omitted
        /// </summary>
        [JsonProperty(PropertyName = "options")]
        public string? Options
        {
            get => _options;
            set => _options = value;
        }
        private string? _options = null;

        /// <summary>
        /// 
        /// </summary>

        [JsonProperty(PropertyName = "key")]
        public string Key
        {
            get => _key;
            set => _key = value;
        }
        private string _key = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "data")]
        public string? DataHex
        {
            get => _dataHex;
            set => _dataHex = value;
        }
        private string? _dataHex = null;
    }

    /// <summary>
    /// 
    /// </summary>
    public class PublishMultiItemKeysEntity
    {
        /// <summary>
        /// Stream identifier, uses default if omitted
        /// </summary>
        [JsonProperty(PropertyName = "for")]
        public string? For
        {
            get => _for;
            set => _for = value;
        }
        private string? _for = null;


        /// <summary>
        /// Should be "offchain" or omitted
        /// </summary>
        [JsonProperty(PropertyName = "options")]
        public string? Options
        {
            get => _options;
            set => _options = value;
        }
        private string? _options = null;

        /// <summary>
        /// 
        /// </summary>

        [JsonProperty(PropertyName = "keys")]
        public string[] Keys
        {
            get => _keys;
            set => _keys = value;
        }
        private string[] _keys = new string[] { };

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "data")]
        public string? DataHex
        {
            get => _dataHex;
            set => _dataHex = value;
        }
        private string? _dataHex = null;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="DataItemType">Should be string, DataText, DataCached, or DataJson types</typeparam>
    public class PublishMultiItemKeyEntity<DataItemType> where DataItemType : new()
    {
        /// <summary>
        /// Stream identifier, uses default if omitted
        /// </summary>
        [JsonProperty(PropertyName = "for")]
        public string? For
        {
            get => _for;
            set => _for = value;
        }
        private string? _for = null;


        /// <summary>
        /// Should be "offchain" or omitted
        /// </summary>
        [JsonProperty(PropertyName = "options")]
        public string? Options
        {
            get => _options;
            set => _options = value;
        }
        private string? _options = null;

        /// <summary>
        /// 
        /// </summary>

        [JsonProperty(PropertyName = "key")]
        public string Key
        {
            get => _key;
            set => _key = value;
        }
        private string _key = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "data")]
        public DataItemType Data
        {
            get => _data;
            set => _data = value;
        }
        private DataItemType _data = new DataItemType();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="DataItemType">Should be string, DataText, DataCached, or DataJson types</typeparam>
    public class PublishMultiItemKeysEntity<DataItemType> where DataItemType : new()
    {
        /// <summary>
        /// Stream identifier, uses default if omitted
        /// </summary>
        [JsonProperty(PropertyName = "for")]
        public string? For
        {
            get => _for;
            set => _for = value;
        }
        private string? _for = null;


        /// <summary>
        /// Should be "offchain" or omitted
        /// </summary>
        [JsonProperty(PropertyName = "options")]
        public string? Options
        {
            get => _options;
            set => _options = value;
        }
        private string? _options = null;

        /// <summary>
        /// 
        /// </summary>

        [JsonProperty(PropertyName = "keys")]
        public string[] Keys
        {
            get => _keys;
            set => _keys = value;
        }
        private string[] _keys = new string[] { };

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "data")]
        public DataItemType Data
        {
            get => _data;
            set => _data = value;
        }
        private DataItemType _data = new DataItemType();
    }
}
