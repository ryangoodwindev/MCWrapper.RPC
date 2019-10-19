using System;

namespace MCWrapper.RPC.ErrorHandling
{
    /// <summary>
    /// ClientException extends Exception class
    /// </summary>
    public class ClientException : Exception
    {
        /// <summary>
        /// Create a new ClientException
        /// </summary>
        /// <param name="message">Error message</param>
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