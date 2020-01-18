using System;

namespace MCWrapper.RPC.Connection
{
    /// <summary>
    /// Service response object
    /// </summary>
    /// <typeparam name="TObject"></typeparam>
    public class RpcResponse<TObject>
    {
        public RpcResponse() { }

        /// <summary>
        /// Request id
        /// </summary>
        public string Id { get; set; }
            = string.Empty;

        /// <summary>
        /// Error object
        /// </summary>
        public ServiceError Error { get; set; }
            = new ServiceError();

        /// <summary>
        /// Generic Result may be string, object, or int, or bool, or Array, etc...
        /// </summary>
        public TObject Result { get; set; }

        public bool IsSuccess()
        {
            if (Error == null)
                return true;

            return Error.Code.Length == 0 && Error.Message.Length == 0;
        }
    }

    /// <summary>
    /// Service response object
    /// </summary>
    public class RpcResponse
    {
        public RpcResponse() { }

        /// <summary>
        /// Request id
        /// </summary>
        public string Id { get; set; }
            = string.Empty;

        /// <summary>
        /// Error object
        /// </summary>
        public ServiceError Error { get; set; }
            = new ServiceError();

        /// <summary>
        /// Generic Result may be string, object, or int, or bool, or Array, etc...
        /// </summary>
        public object Result { get; set; }
            = new { };

        public bool IsSuccess()
        {
            if (Error == null)
                return true;

            return Error.Code.Length == 0 && Error.Message.Length == 0;
        }
    }

    /// <summary>
    /// ServiceError object
    /// </summary>
    public class ServiceError
    {
        public ServiceError() { }

        /// <summary>
        /// Error code
        /// </summary>
        public string Code { get; set; }
            = string.Empty;

        /// <summary>
        /// Error message
        /// </summary>
        public string Message { get; set; }
            = string.Empty;
    }
}