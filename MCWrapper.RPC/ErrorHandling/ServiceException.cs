using System;

namespace MCWrapper.RPC.ErrorHandling
{
    /// <summary>
    /// ServiceException extends Exception class
    /// </summary>
    public class ServiceException : Exception
    {
        /// <summary>
        /// Create a new ServiceException
        /// </summary>
        /// <param name="message">Error message</param>
        public ServiceException(string message) : base(message) { }
    }
}