namespace MCWrapper.RPC.Constants
{
    /// <summary>
    /// Constant Peer connection command values
    /// </summary>
    public struct PeerConnection
    {
        /// <summary>
        /// Used to indicate adding a node
        /// </summary>
        public const string Add = "add";

        /// <summary>
        /// Used to indicate removing a previously added node
        /// </summary>
        public const string Remove = "remove";

        /// <summary>
        /// Try to connect new node once
        /// </summary>
        public const string OneTry = "onetry";
    }
}