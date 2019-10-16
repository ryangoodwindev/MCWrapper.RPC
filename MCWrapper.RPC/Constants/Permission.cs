namespace MCWrapper.RPC.Constants
{
    /// <summary>
    /// MultiChain Core blockchain permissions types
    /// </summary>
    public struct Permission
    {
        /// <summary>
        /// To connect to other nodes and see the blockchain’s contents
        /// </summary>
        public const string Connect = "connect";

        /// <summary>
        /// To send funds, e.g. sign inputs of transactions
        /// </summary>
        public const string Send = "send";

        /// <summary>
        /// To receive funds, e.g. appear in the outputs of transactions
        /// </summary>
        public const string Receive = "receive";

        /// <summary>
        /// To issue assets, e.g. sign inputs of transactions which create new native assets;
        /// Implied permissions: issue → send
        /// </summary>
        public const string Issue = "issue";

        /// <summary>
        /// To create streams, e.g. sign inputs of transactions which create new streams
        /// Implied permissions: create → send
        /// </summary>
        public const string Create = "create";

        /// <summary>
        /// To create blocks, e.g. to sign the metadata of coinbase transactions;
        /// Implied permissions: mine → connect, receive (in coinbase transaction only)
        /// </summary>
        public const string Mine = "mine";

        /// <summary>
        /// To change connect, send and receive permissions for other users, e.g. sign transactions which change those permissions;
        /// Implied permissions: activate → send, receive, connect
        /// </summary>
        public const string Activate = "activate";

        /// <summary>
        /// To change all permissions for other users, including issue, mine, activate and admin;
        /// Implied permissions: admin → activate, send, receive, connect
        /// </summary>
        public const string Admin = "admin";

        /// <summary>
        /// A permission is granted permanently by setting the start block to 0 and the end block to 4294967295, the maximum 32-bit unsigned integer.
        /// A permission is revoked by setting both the start block and end block to 0.
        /// </summary>
        public const uint MaxEndblock = 4294967295;
    }
}
