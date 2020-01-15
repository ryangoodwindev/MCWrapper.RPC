using Newtonsoft.Json;

namespace MCWrapper.RPC.Connection
{
    /// <summary>
    /// Service response object
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RpcResponse<T>
    {
        /// <summary>
        /// Create a new Service Response
        /// </summary>
        public RpcResponse()
        {

        }

        /// <summary>
        /// Request id
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Error object
        /// </summary>
        [JsonProperty("error")]
        public ServiceError Error { get; set; }

        /// <summary>
        /// Generic Result may be string, object, or int, or bool, or Array, etc...
        /// </summary>
        [JsonProperty("result")]
        public T Result { get; set; }
    }

    /// <summary>
    /// Service response object
    /// </summary>
    public class RpcResponse
    {
        /// <summary>
        /// Create a new Service Response
        /// </summary>
        public RpcResponse() { }

        /// <summary>
        /// Request id
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Error object
        /// </summary>
        [JsonProperty("error")]
        public ServiceError Error { get; set; }

        /// <summary>
        /// Generic Result may be string, object, or int, or bool, or Array, etc...
        /// </summary>
        [JsonProperty("result")]
        public object Result { get; set; }
    }

    /// <summary>
    /// ServiceError object
    /// </summary>
    public class ServiceError
    {
        /// <summary>
        /// Error code
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; } = string.Empty;

        /// <summary>
        /// Error message
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; } = string.Empty;
    }
}