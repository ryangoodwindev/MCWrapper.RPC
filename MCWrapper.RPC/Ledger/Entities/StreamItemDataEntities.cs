using Newtonsoft.Json;

namespace MCWrapper.RPC.Ledger.Entities
{
    /// <summary>
    /// JSON data object
    /// </summary>
    public class DataJson
    {
        /// <summary>
        /// Needs to be a valid JSON object
        /// </summary>
        [JsonProperty(PropertyName = "json")]
        public object Json
        {
            get => _json;
            set => _json = value;
        }
        private object _json = new object();

        /// <summary>
        /// Create a new DataJson instance
        /// </summary>
        public DataJson() { }

        /// <summary>
        /// Create a new DataJson instance with parameter
        /// </summary>
        /// <param name="json"></param>
        public DataJson(object json) => _json = json;
    }

    /// <summary>
    ///  Text data object
    /// </summary>
    public class DataText
    {
        /// <summary>
        ///  Data string (plain text)
        /// </summary>
        [JsonProperty(PropertyName = "text")]
        public string Text
        {
            get => _text;
            set => _text = value;
        }
        private string _text = string.Empty;

        /// <summary>
        /// Create a new DataText instance
        /// </summary>
        public DataText() { }

        /// <summary>
        /// Create a new DataText instance with parameter
        /// </summary>
        /// <param name="text"></param>
        public DataText(string text) => _text = text;
    }

    /// <summary>
    /// Binary raw data created with appendbinarycache
    /// </summary>
    public class DataCached
    {
        /// <summary>
        /// Binary cache identifier
        /// </summary>
        [JsonProperty(PropertyName = "cache")]
        public string Cache
        {
            get => _cache;
            set => _cache = value;
        }
        private string _cache = string.Empty;

        /// <summary>
        /// Create a new DataCached instance
        /// </summary>
        public DataCached() { }

        /// <summary>
        /// reate a new DataCached instance with parameter
        /// </summary>
        /// <param name="cache"></param>
        public DataCached(string cache) => _cache = cache;
    }
}
