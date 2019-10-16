using MCWrapper.RPC.Constants;
using MCWrapper.RPC.Ledger.Entities.BaseEntity;

namespace MCWrapper.RPC.Ledger.Entities
{
    /// <summary>
    /// Typed object model representing a new blockchain stream item 
    /// </summary>
    public class PublishEntity : PublishEntity<string>
    {
        /// <summary>
        /// Create a new PublishEntity instance with string type as Data object and accepts a single stream item key
        /// </summary>
        /// <param name="streamIdentifier"></param>
        /// <param name="key"></param>
        /// <param name="data"></param>
        /// <param name="options"></param>
        public PublishEntity(string streamIdentifier, string key, string data, string options)
            : base(streamIdentifier, key, data, options) { }

        /// <summary>
        /// Create a new PublishEntity instance with string type as Data objec and accepts a multiple stream item keys
        /// </summary>
        /// <param name="streamIdentifier"></param>
        /// <param name="keys"></param>
        /// <param name="data"></param>
        /// <param name="options"></param>
        public PublishEntity(string streamIdentifier, string[] keys, string data, string options)
            : base(streamIdentifier, keys, data, options) { }
    }

    /// <summary>
    /// Typed object model representing a new blockchain stream item 
    /// </summary>
    public class PublishEntity<T> : ChainEntity
    {
        /// <summary>
        /// MultiChain Core Stream identifier - one of the following: stream txid, stream reference, stream name
        /// </summary>
        public string StreamIdentifer
        {
            get => _streamIdentifier;
            set => _streamIdentifier = value;
        }
        private string _streamIdentifier = string.Empty;

        /// <summary>
        /// Item key
        /// </summary>
        public string Key
        {
            get => _key;
            set => _key = value;
        }
        private string _key = string.Empty;

        /// <summary>
        ///  Array of item keys
        /// </summary>
        public string[] Keys
        {
            get => _keys;
            set => _keys = value;
        }
        private string[] _keys = new string[] { };

        /// <summary>
        /// Data hex string
        /// </summary>
        public T Data
        {
            get => _data;
            set => _data = value;
        }
        private T _data;

        /// <summary>
        /// Should be "offchain" or omitted
        /// </summary>
        public string Options
        {
            get => _options;
            set => _options = value;
        }
        private string _options = string.Empty;

        /// <summary>
        ///  Create a new StreamItemEntity instance with the parameters
        /// </summary>
        /// <param name="streamIdentifier">Stream identifier - one of the following: stream txid, stream reference, stream name.</param>
        /// <param name="key">Item key</param>
        /// <param name="data">Data hex string</param>
        /// <param name="options">Should be "offchain" or omitte</param>
        public PublishEntity(string streamIdentifier, string key, T data, string options)
            : base(streamIdentifier, Entity.StreamItem)
        {
            _streamIdentifier = streamIdentifier;
            _key = key;
            _data = data;
            _options = options;
        }

        /// <summary>
        ///  Create a new StreamItemEntity instance with the parameters
        /// </summary>
        /// <param name="streamIdentifier">Stream identifier - one of the following: stream txid, stream reference, stream name.</param>
        /// <param name="keys">Array of item keys</param>
        /// <param name="data">Data hex string</param>
        /// <param name="options">Should be "offchain" or omitte</param>
        public PublishEntity(string streamIdentifier, string[] keys, T data, string options)
            : base(streamIdentifier, Entity.StreamItem)
        {
            _streamIdentifier = streamIdentifier;
            _keys = keys;
            _data = data;
            _options = options;
        }
    }
}
