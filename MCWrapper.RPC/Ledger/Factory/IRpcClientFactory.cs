namespace MCWrapper.RPC.Ledger.Clients
{
    public interface IRpcClientFactory
    {
        T GetRpcClient<T>();
    }
}