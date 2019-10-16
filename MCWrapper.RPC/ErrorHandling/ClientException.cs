using System;

namespace MCWrapper.RPC.ErrorHandling
{
    /// <summary>
    /// Custom API Exception object
    /// </summary>
    public class ClientException : Exception
    {
        public ClientException(string message) : base(message) { }

        /// <summary>
        /// HTTP response status code
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// HTTP response body content
        /// </summary>
        public string Content { get; set; } = string.Empty;
    }
}
