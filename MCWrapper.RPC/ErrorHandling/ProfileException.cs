using System;

namespace MCWrapper.RPC.ErrorHandling
{
    /// <summary>
    /// ProfileException extends Exception class
    /// </summary>
    public class ProfileException : Exception
    {
        /// <summary>
        /// Create a new ProfileException
        /// </summary>
        /// <param name="message">Error message</param>
        public ProfileException(string message) : base(message) { }
    }
}