using Newtonsoft.Json;
using System.Collections.Generic;

namespace MCWrapper.RPC.Connection.Request
{
    /// <summary>
    /// Service request object contains required information and format to transact with a blockchain network
    /// </summary>
    public class RpcRequest

    {
        /// <summary>
        /// Get name values
        /// </summary>
        public Dictionary<string, object> GetNamedValues { get; set; } = new Dictionary<string, object>();

        /// <summary>
        /// Create a new Service Request
        /// </summary>
        public RpcRequest() { }

        /// <summary>
        /// Create a new Service Request
        /// </summary>
        public RpcRequest(string id, string method, object[] args, string multiChainName)
        {
            Id = id;
            Method = method;
            Params = args;
            ChainName = multiChainName;
        }

        /// <summary>
        /// Method property
        /// </summary>
        [JsonProperty("method")]
        public string Method
        {
            get => GetNamedValue<string>("method");
            set => SetNamedValue("method", value);
        }

        /// <summary>
        /// Params property
        /// </summary>
        [JsonProperty("params")]
        public object[] Params
        {
            get => GetNamedValue<object[]>("params");
            set => SetNamedValue("params", value);
        }

        /// <summary>
        /// Id property
        /// </summary>
        [JsonProperty("id")]
        public string Id
        {
            get => GetNamedValue<string>("id");
            set => SetNamedValue("id", value);
        }

        /// <summary>
        /// ChainName property
        /// </summary>
        [JsonProperty("chain_name")]
        public string ChainName
        {
            get => GetNamedValue<string>("chain_name");
            set => SetNamedValue("chain_name", value);
        }

        /// <summary>
        /// Set named value
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        private void SetNamedValue(string name, object value) => GetNamedValues[name] = value;

        /// <summary>
        /// Get name value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        public T GetNamedValue<T>(string name)
        {
            if (GetNamedValues.ContainsKey(name))
                return (T)GetNamedValues[name];
            else
            {
                object None = new { };
                return (T)None;
            }
        }
    }
}
