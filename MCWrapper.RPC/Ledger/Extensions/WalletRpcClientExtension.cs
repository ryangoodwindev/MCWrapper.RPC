using MCWrapper.Ledger.Entities;
using MCWrapper.RPC.Connection;
using System.Threading.Tasks;

namespace MCWrapper.RPC.Ledger.Clients
{
    /// <summary>
    /// Extension methods derived from the WalletRpcClient contract and WalletRPCClient implementation
    /// </summary>
    public static class WalletRpcClientExtension

    {
        // *** Create Stream extension methods

        /// <summary>
        /// Create stream; Blockchain name is inferred
        /// </summary>
        /// <param name="client"></param>
        /// <param name="streamEntity"></param>
        /// <returns></returns>
        public static Task<RpcResponse<string>> CreateStream(this WalletRpcClient client, StreamEntity streamEntity) =>
            client.CreateAsync(streamEntity.EntityType, streamEntity.Name, streamEntity.Restrictions, streamEntity.CustomFields);

        /// <summary>
        /// Create stream; Blockchain name is explicit
        /// </summary>
        /// <param name="client"></param>
        /// <param name="blockchainName"></param>
        /// <param name="id"></param>
        /// <param name="streamEntity"></param>
        /// <returns></returns>
        public static Task<RpcResponse<string>> CreateStream(this WalletRpcClient client, string blockchainName, string id, StreamEntity streamEntity) =>
            client.CreateAsync(blockchainName, id, streamEntity.EntityType, streamEntity.Name, streamEntity.Restrictions, streamEntity.CustomFields);

        /// <summary>
        /// Create stream from an address; Blockchain name is inferred
        /// </summary>
        /// <param name="client"></param>
        /// <param name="fromAddress"></param>
        /// <param name="streamEntity"></param>
        /// <returns></returns>
        public static Task<RpcResponse<string>> CreateStreamFrom(this WalletRpcClient client, string fromAddress, StreamEntity streamEntity) =>
            client.CreateFromAsync(fromAddress, streamEntity.EntityType, streamEntity.Name, streamEntity.Restrictions, streamEntity.CustomFields);

        /// <summary>
        /// Create stream from an address; Blockchain name is explicit
        /// </summary>
        /// <param name="client"></param>
        /// <param name="blockchainName"></param>
        /// <param name="id"></param>
        /// <param name="fromAddress"></param>
        /// <param name="streamEntity"></param>
        /// <returns></returns>
        public static Task<RpcResponse<string>> CreateStreamFrom(this WalletRpcClient client, string blockchainName, string id, string fromAddress, StreamEntity streamEntity) =>
            client.CreateFromAsync(blockchainName, id, fromAddress, streamEntity.EntityType, streamEntity.Name, streamEntity.Restrictions, streamEntity.CustomFields);


        // *** Create Upgrade extension methods

        /// <summary>
        /// Create upgrade; Blockchain name is inferred
        /// </summary>
        /// <param name="client"></param>
        /// <param name="upgradeEntity"></param>
        /// <returns></returns>
        public static Task<RpcResponse<string>> CreateUpgrade(this WalletRpcClient client, UpgradeEntity upgradeEntity) =>
            client.CreateAsync(upgradeEntity.EntityType, upgradeEntity.Name, upgradeEntity.Open, upgradeEntity.CustomFields);

        /// <summary>
        /// Create upgrade; Blockchain name is explicit
        /// </summary>
        /// <param name="client"></param>
        /// <param name="blockchainName"></param>
        /// <param name="id"></param>
        /// <param name="upgradeEntity"></param>
        /// <returns></returns>
        public static Task<RpcResponse<string>> CreateUpgrade(this WalletRpcClient client, string blockchainName, string id, UpgradeEntity upgradeEntity) =>
            client.CreateAsync(blockchainName, id, upgradeEntity.EntityType, upgradeEntity.Name, upgradeEntity.Open, upgradeEntity.CustomFields);

        /// <summary>
        /// Create upgrade from an address; Blockchain name is inferred
        /// </summary>
        /// <param name="client"></param>
        /// <param name="fromAddress"></param>
        /// <param name="upgradeEntity"></param>
        /// <returns></returns>
        public static Task<RpcResponse<string>> CreateUpgradeFrom(this WalletRpcClient client, string fromAddress, UpgradeEntity upgradeEntity) =>
            client.CreateFromAsync(fromAddress, upgradeEntity.EntityType, upgradeEntity.Name, upgradeEntity.Open, upgradeEntity.CustomFields);

        /// <summary>
        /// Create upgrade from an address; Blockchain name is explicit
        /// </summary>
        /// <param name="client"></param>
        /// <param name="blockchainName"></param>
        /// <param name="id"></param>
        /// <param name="fromAddress"></param>
        /// <param name="upgradeEntity"></param>
        /// <returns></returns>
        public static Task<RpcResponse<string>> CreateUpgradeFrom(this WalletRpcClient client, string blockchainName, string id, string fromAddress, UpgradeEntity upgradeEntity) =>
            client.CreateFromAsync(blockchainName, id, fromAddress, upgradeEntity.EntityType, upgradeEntity.Name, upgradeEntity.Open, upgradeEntity.CustomFields);


        // *** Create Stream Filter extension methods

        /// <summary>
        /// Create stream filter; Blockchain name is inferred
        /// </summary>
        /// <param name="client"></param>
        /// <param name="streamFilterEntity"></param>
        /// <returns></returns>
        public static Task<RpcResponse<string>> CreateStreamFilter(this WalletRpcClient client, StreamFilterEntity streamFilterEntity) =>
            client.CreateAsync(streamFilterEntity.EntityType, streamFilterEntity.Name, streamFilterEntity.Restrictions, streamFilterEntity.JavaScriptCode);

        /// <summary>
        /// Create stream filter; Blockchain name is explicit
        /// </summary>
        /// <param name="client"></param>
        /// <param name="blockchainName"></param>
        /// <param name="id"></param>
        /// <param name="streamFilterEntity"></param>
        /// <returns></returns>
        public static Task<RpcResponse<string>> CreateStreamFilter(this WalletRpcClient client, string blockchainName, string id, StreamFilterEntity streamFilterEntity) =>
            client.CreateAsync(blockchainName, id, streamFilterEntity.EntityType, streamFilterEntity.Name, streamFilterEntity.Restrictions, streamFilterEntity.JavaScriptCode);

        /// <summary>
        /// Create stream filter from an address; Blockchain name is inferred
        /// </summary>
        /// <param name="client"></param>
        /// <param name="fromAddress"></param>
        /// <param name="streamFilterEntity"></param>
        /// <returns></returns>
        public static Task<RpcResponse<string>> CreateStreamFilterFrom(this WalletRpcClient client, string fromAddress, StreamFilterEntity streamFilterEntity) =>
            client.CreateFromAsync(fromAddress, streamFilterEntity.EntityType, streamFilterEntity.Name, streamFilterEntity.Restrictions, streamFilterEntity.JavaScriptCode);

        /// <summary>
        /// Create stream filter from an address; Blockchain name is explicit
        /// </summary>
        /// <param name="client"></param>
        /// <param name="blockchainName"></param>
        /// <param name="id"></param>
        /// <param name="fromAddress"></param>
        /// <param name="streamFilterEntity"></param>
        /// <returns></returns>
        public static Task<RpcResponse<string>> CreateStreamFilterFrom(this WalletRpcClient client, string blockchainName, string id, string fromAddress, StreamFilterEntity streamFilterEntity) =>
            client.CreateFromAsync(blockchainName, id, fromAddress, streamFilterEntity.EntityType, streamFilterEntity.Name, streamFilterEntity.Restrictions, streamFilterEntity.JavaScriptCode);


        // *** Create Tx Filter extension methods

        /// <summary>
        /// Create transaction filter; Blockchain name is inferred
        /// </summary>
        /// <param name="client"></param>
        /// <param name="txFilterEntity"></param>
        /// <returns></returns>
        public static Task<RpcResponse<string>> CreateTxFilter(this WalletRpcClient client, TxFilterEntity txFilterEntity) =>
            client.CreateAsync(txFilterEntity.EntityType, txFilterEntity.Name, txFilterEntity.Restrictions, txFilterEntity.JavaScriptCode);

        /// <summary>
        /// Create transaction filter; Blockchain name is explicit
        /// </summary>
        /// <param name="client"></param>
        /// <param name="blockchainName"></param>
        /// <param name="id"></param>
        /// <param name="txFilterEntity"></param>
        /// <returns></returns>
        public static Task<RpcResponse<string>> CreateTxFilter(this WalletRpcClient client, string blockchainName, string id, TxFilterEntity txFilterEntity) =>
            client.CreateAsync(blockchainName, id, txFilterEntity.EntityType, txFilterEntity.Name, txFilterEntity.Restrictions, txFilterEntity.JavaScriptCode);

        /// <summary>
        /// Create transaction filter from an address; Blockchain name is inferred
        /// </summary>
        /// <param name="client"></param>
        /// <param name="fromAddress"></param>
        /// <param name="txFilterEntity"></param>
        /// <returns></returns>
        public static Task<RpcResponse<string>> CreateTxFilterFrom(this WalletRpcClient client, string fromAddress, TxFilterEntity txFilterEntity) =>
            client.CreateFromAsync(fromAddress, txFilterEntity.EntityType, txFilterEntity.Name, txFilterEntity.Restrictions, txFilterEntity.JavaScriptCode);

        /// <summary>
        /// Create transaction filter from an address; Blockchain name is explicit
        /// </summary>
        /// <param name="client"></param>
        /// <param name="blockchainName"></param>
        /// <param name="id"></param>
        /// <param name="fromAddress"></param>
        /// <param name="txFilterEntity"></param>
        /// <returns></returns>
        public static Task<RpcResponse<string>> CreateTxFilterFrom(this WalletRpcClient client, string blockchainName, string id, string fromAddress, TxFilterEntity txFilterEntity) =>
            client.CreateFromAsync(blockchainName, id, fromAddress, txFilterEntity.EntityType, txFilterEntity.Name, txFilterEntity.Restrictions, txFilterEntity.JavaScriptCode);


        // *** PublishStreamItem using an inferred blockchain name

        /// <summary>
        /// Create stream item; Blockchain name is inferred
        /// </summary>
        /// <param name="client"></param>
        /// <param name="streamItemEntity"></param>
        /// <returns></returns>
        public static Task<RpcResponse<string>> PublishStreamItemKey(this WalletRpcClient client, PublishEntity streamItemEntity) =>
            client.PublishAsync(streamItemEntity.StreamIdentifer, streamItemEntity.Key, streamItemEntity.Data, streamItemEntity.Options);

        /// <summary>
        /// Create stream item; Blockchain name is inferred
        /// </summary>
        /// <param name="client"></param>
        /// <param name="streamItemEntity"></param>
        /// <returns></returns>
        public static Task<RpcResponse<string>> PublishStreamItemKey(this WalletRpcClient client, PublishEntity<DataCached> streamItemEntity) =>
            client.PublishAsync(streamItemEntity.StreamIdentifer, streamItemEntity.Key, streamItemEntity.Data, streamItemEntity.Options);

        /// <summary>
        /// Create stream item; Blockchain name is inferred
        /// </summary>
        /// <param name="client"></param>
        /// <param name="streamItemEntity"></param>
        /// <returns></returns>
        public static Task<RpcResponse<string>> PublishStreamItemKey(this WalletRpcClient client, PublishEntity<DataJson> streamItemEntity) =>
            client.PublishAsync(streamItemEntity.StreamIdentifer, streamItemEntity.Key, streamItemEntity.Data, streamItemEntity.Options);

        /// <summary>
        /// Create stream item; Blockchain name is inferred
        /// </summary>
        /// <param name="client"></param>
        /// <param name="streamItemEntity"></param>
        /// <returns></returns>
        public static Task<RpcResponse<string>> PublishStreamItemKey(this WalletRpcClient client, PublishEntity<DataText> streamItemEntity) =>
            client.PublishAsync(streamItemEntity.StreamIdentifer, streamItemEntity.Key, streamItemEntity.Data, streamItemEntity.Options);


        // *** PublishStreamItems using an inferred blockchain name

        /// <summary>
        /// Create stream item; Blockchain name is inferred
        /// </summary>
        /// <param name="client"></param>
        /// <param name="streamItemEntity"></param>
        /// <returns></returns>
        public static Task<RpcResponse<string>> PublishStreamItemKeys(this WalletRpcClient client, PublishEntity streamItemEntity) =>
            client.PublishAsync(streamItemEntity.StreamIdentifer, streamItemEntity.Keys, streamItemEntity.Data, streamItemEntity.Options);

        /// <summary>
        /// Create stream item; Blockchain name is inferred
        /// </summary>
        /// <param name="client"></param>
        /// <param name="streamItemEntity"></param>
        /// <returns></returns>
        public static Task<RpcResponse<string>> PublishStreamItemKeys(this WalletRpcClient client, PublishEntity<DataCached> streamItemEntity) =>
            client.PublishAsync(streamItemEntity.StreamIdentifer, streamItemEntity.Keys, streamItemEntity.Data, streamItemEntity.Options);

        /// <summary>
        /// Create stream item; Blockchain name is inferred
        /// </summary>
        /// <param name="client"></param>
        /// <param name="streamItemEntity"></param>
        /// <returns></returns>
        public static Task<RpcResponse<string>> PublishStreamItemKeys(this WalletRpcClient client, PublishEntity<DataJson> streamItemEntity) =>
            client.PublishAsync(streamItemEntity.StreamIdentifer, streamItemEntity.Keys, streamItemEntity.Data, streamItemEntity.Options);

        /// <summary>
        /// Create stream item; Blockchain name is inferred
        /// </summary>
        /// <param name="client"></param>
        /// <param name="streamItemEntity"></param>
        /// <returns></returns>
        public static Task<RpcResponse<string>> PublishStreamItemKeys(this WalletRpcClient client, PublishEntity<DataText> streamItemEntity) =>
            client.PublishAsync(streamItemEntity.StreamIdentifer, streamItemEntity.Keys, streamItemEntity.Data, streamItemEntity.Options);


        // *** PublishStreamItem using an explicit blockchain name

        /// <summary>
        /// Create stream item; Blockchain name is explicit
        /// </summary>
        /// <param name="client"></param>
        /// <param name="blockchainName"></param>
        /// <param name="id"></param>
        /// <param name="streamItemEntity"></param>
        /// <returns></returns>
        public static Task<RpcResponse<string>> PublishStreamItemKey(this WalletRpcClient client, string blockchainName, string id, PublishEntity streamItemEntity) =>
            client.PublishAsync(blockchainName, id, streamItemEntity.StreamIdentifer, streamItemEntity.Key, streamItemEntity.Data, streamItemEntity.Options);

        /// <summary>
        /// Create stream item; Blockchain name is explicit
        /// </summary>
        /// <param name="client"></param>
        /// <param name="blockchainName"></param>
        /// <param name="id"></param>
        /// <param name="streamItemEntity"></param>
        /// <returns></returns>
        public static Task<RpcResponse<string>> PublishStreamItemKey(this WalletRpcClient client, string blockchainName, string id, PublishEntity<DataCached> streamItemEntity) =>
            client.PublishAsync(blockchainName, id, streamItemEntity.StreamIdentifer, streamItemEntity.Key, streamItemEntity.Data, streamItemEntity.Options);

        /// <summary>
        /// Create stream item; Blockchain name is explicit
        /// </summary>
        /// <param name="client"></param>
        /// <param name="blockchainName"></param>
        /// <param name="id"></param>
        /// <param name="streamItemEntity"></param>
        /// <returns></returns>
        public static Task<RpcResponse<string>> PublishStreamItemKey(this WalletRpcClient client, string blockchainName, string id, PublishEntity<DataJson> streamItemEntity) =>
            client.PublishAsync(blockchainName, id, streamItemEntity.StreamIdentifer, streamItemEntity.Key, streamItemEntity.Data, streamItemEntity.Options);

        /// <summary>
        /// Create stream item; Blockchain name is explicit
        /// </summary>
        /// <param name="client"></param>
        /// <param name="blockchainName"></param>
        /// <param name="id"></param>
        /// <param name="streamItemEntity"></param>
        /// <returns></returns>
        public static Task<RpcResponse<string>> PublishStreamItemKey(this WalletRpcClient client, string blockchainName, string id, PublishEntity<DataText> streamItemEntity) =>
            client.PublishAsync(blockchainName, id, streamItemEntity.StreamIdentifer, streamItemEntity.Key, streamItemEntity.Data, streamItemEntity.Options);


        // *** PublishStreamItems using an explicit blockchain name

        /// <summary>
        /// Create stream item; Blockchain name is explicit
        /// </summary>
        /// <param name="client"></param>
        /// <param name="blockchainName"></param>
        /// <param name="id"></param>
        /// <param name="streamItemEntity"></param>
        /// <returns></returns>
        public static Task<RpcResponse<string>> PublishStreamItemKeys(this WalletRpcClient client, string blockchainName, string id, PublishEntity streamItemEntity) =>
            client.PublishAsync(blockchainName, id, streamItemEntity.StreamIdentifer, streamItemEntity.Keys, streamItemEntity.Data, streamItemEntity.Options);

        /// <summary>
        /// Create stream item; Blockchain name is explicit
        /// </summary>
        /// <param name="client"></param>
        /// <param name="blockchainName"></param>
        /// <param name="id"></param>
        /// <param name="streamItemEntity"></param>
        /// <returns></returns>
        public static Task<RpcResponse<string>> PublishStreamItemKeys(this WalletRpcClient client, string blockchainName, string id, PublishEntity<DataCached> streamItemEntity) =>
            client.PublishAsync(blockchainName, id, streamItemEntity.StreamIdentifer, streamItemEntity.Keys, streamItemEntity.Data, streamItemEntity.Options);

        /// <summary>
        /// Create stream item; Blockchain name is explicit
        /// </summary>
        /// <param name="client"></param>
        /// <param name="blockchainName"></param>
        /// <param name="id"></param>
        /// <param name="streamItemEntity"></param>
        /// <returns></returns>
        public static Task<RpcResponse<string>> PublishStreamItemKeys(this WalletRpcClient client, string blockchainName, string id, PublishEntity<DataJson> streamItemEntity) =>
            client.PublishAsync(blockchainName, id, streamItemEntity.StreamIdentifer, streamItemEntity.Keys, streamItemEntity.Data, streamItemEntity.Options);

        /// <summary>
        /// Create stream item; Blockchain name is explicit
        /// </summary>
        /// <param name="client"></param>
        /// <param name="blockchainName"></param>
        /// <param name="id"></param>
        /// <param name="streamItemEntity"></param>
        /// <returns></returns>
        public static Task<RpcResponse<string>> PublishStreamItemKeys(this WalletRpcClient client, string blockchainName, string id, PublishEntity<DataText> streamItemEntity) =>
            client.PublishAsync(blockchainName, id, streamItemEntity.StreamIdentifer, streamItemEntity.Keys, streamItemEntity.Data, streamItemEntity.Options);


        // *** PublishStreamItemFrom using an inferred blockchain name

        /// <summary>
        /// Create stream item from an address; Blockchain name is inferred
        /// </summary>
        /// <param name="client"></param>
        /// <param name="fromAddress"></param>
        /// <param name="streamItemEntity"></param>
        /// <returns></returns>
        public static Task<RpcResponse<string>> PublishStreamItemKeyFrom(this WalletRpcClient client, string fromAddress, PublishEntity streamItemEntity) =>
            client.PublishFromAsync(fromAddress, streamItemEntity.StreamIdentifer, streamItemEntity.Key, streamItemEntity.Data, streamItemEntity.Options);

        /// <summary>
        /// Create stream item from an address; Blockchain name is inferred
        /// </summary>
        /// <param name="client"></param>
        /// <param name="fromAddress"></param>
        /// <param name="streamItemEntity"></param>
        /// <returns></returns>
        public static Task<RpcResponse<string>> PublishStreamItemKeyFrom(this WalletRpcClient client, string fromAddress, PublishEntity<DataCached> streamItemEntity) =>
            client.PublishFromAsync(fromAddress, streamItemEntity.StreamIdentifer, streamItemEntity.Key, streamItemEntity.Data, streamItemEntity.Options);

        /// <summary>
        /// Create stream item from an address; Blockchain name is inferred
        /// </summary>
        /// <param name="client"></param>
        /// <param name="fromAddress"></param>
        /// <param name="streamItemEntity"></param>
        /// <returns></returns>
        public static Task<RpcResponse<string>> PublishStreamItemKeyFrom(this WalletRpcClient client, string fromAddress, PublishEntity<DataJson> streamItemEntity) =>
            client.PublishFromAsync(fromAddress, streamItemEntity.StreamIdentifer, streamItemEntity.Key, streamItemEntity.Data, streamItemEntity.Options);

        /// <summary>
        /// Create stream item from an address; Blockchain name is inferred
        /// </summary>
        /// <param name="client"></param>
        /// <param name="fromAddress"></param>
        /// <param name="streamItemEntity"></param>
        /// <returns></returns>
        public static Task<RpcResponse<string>> PublishStreamItemKeyFrom(this WalletRpcClient client, string fromAddress, PublishEntity<DataText> streamItemEntity) =>
            client.PublishFromAsync(fromAddress, streamItemEntity.StreamIdentifer, streamItemEntity.Key, streamItemEntity.Data, streamItemEntity.Options);


        // *** PublishStreamItemsFrom using an inferred blockchain name

        /// <summary>
        /// Create stream item from an address; Blockchain name is inferred
        /// </summary>
        /// <param name="client"></param>
        /// <param name="fromAddress"></param>
        /// <param name="streamItemEntity"></param>
        /// <returns></returns>
        public static Task<RpcResponse<string>> PublishStreamItemKeysFrom(this WalletRpcClient client, string fromAddress, PublishEntity streamItemEntity) =>
            client.PublishFromAsync(fromAddress, streamItemEntity.StreamIdentifer, streamItemEntity.Keys, streamItemEntity.Data, streamItemEntity.Options);

        /// <summary>
        /// Create stream item from an address; Blockchain name is inferred
        /// </summary>
        /// <param name="client"></param>
        /// <param name="fromAddress"></param>
        /// <param name="streamItemEntity"></param>
        /// <returns></returns>
        public static Task<RpcResponse<string>> PublishStreamItemKeysFrom(this WalletRpcClient client, string fromAddress, PublishEntity<DataCached> streamItemEntity) =>
            client.PublishFromAsync(fromAddress, streamItemEntity.StreamIdentifer, streamItemEntity.Keys, streamItemEntity.Data, streamItemEntity.Options);

        /// <summary>
        /// Create stream item from an address; Blockchain name is inferred
        /// </summary>
        /// <param name="client"></param>
        /// <param name="fromAddress"></param>
        /// <param name="streamItemEntity"></param>
        /// <returns></returns>
        public static Task<RpcResponse<string>> PublishStreamItemKeysFrom(this WalletRpcClient client, string fromAddress, PublishEntity<DataJson> streamItemEntity) =>
            client.PublishFromAsync(fromAddress, streamItemEntity.StreamIdentifer, streamItemEntity.Keys, streamItemEntity.Data, streamItemEntity.Options);

        /// <summary>
        /// Create stream item from an address; Blockchain name is inferred
        /// </summary>
        /// <param name="client"></param>
        /// <param name="fromAddress"></param>
        /// <param name="streamItemEntity"></param>
        /// <returns></returns>
        public static Task<RpcResponse<string>> PublishStreamItemKeysFrom(this WalletRpcClient client, string fromAddress, PublishEntity<DataText> streamItemEntity) =>
            client.PublishFromAsync(fromAddress, streamItemEntity.StreamIdentifer, streamItemEntity.Keys, streamItemEntity.Data, streamItemEntity.Options);


        // *** PublishStreamItemFrom using an explicit blockchain name

        /// <summary>
        /// Create stream item from an address; Blockchain name is explicit
        /// </summary>
        /// <param name="client"></param>
        /// <param name="blockchainName"></param>
        /// <param name="id"></param>
        /// <param name="fromAddress"></param>
        /// <param name="streamItemEntity"></param>
        /// <returns></returns>
        public static Task<RpcResponse<string>> PublishStreamItemKeyFrom(this WalletRpcClient client, string blockchainName, string id, string fromAddress, PublishEntity streamItemEntity) =>
            client.PublishFromAsync(blockchainName, id, fromAddress, streamItemEntity.StreamIdentifer, streamItemEntity.Key, streamItemEntity.Data, streamItemEntity.Options);

        /// <summary>
        /// Create stream item from an address; Blockchain name is explicit
        /// </summary>
        /// <param name="client"></param>
        /// <param name="blockchainName"></param>
        /// <param name="id"></param>
        /// <param name="fromAddress"></param>
        /// <param name="streamItemEntity"></param>
        /// <returns></returns>
        public static Task<RpcResponse<string>> PublishStreamItemKeyFrom(this WalletRpcClient client, string blockchainName, string id, string fromAddress, PublishEntity<DataCached> streamItemEntity) =>
            client.PublishFromAsync(blockchainName, id, fromAddress, streamItemEntity.StreamIdentifer, streamItemEntity.Key, streamItemEntity.Data, streamItemEntity.Options);

        /// <summary>
        /// Create stream item from an address; Blockchain name is explicit
        /// </summary>
        /// <param name="client"></param>
        /// <param name="blockchainName"></param>
        /// <param name="id"></param>
        /// <param name="fromAddress"></param>
        /// <param name="streamItemEntity"></param>
        /// <returns></returns>
        public static Task<RpcResponse<string>> PublishStreamItemKeyFrom(this WalletRpcClient client, string blockchainName, string id, string fromAddress, PublishEntity<DataJson> streamItemEntity) =>
            client.PublishFromAsync(blockchainName, id, fromAddress, streamItemEntity.StreamIdentifer, streamItemEntity.Key, streamItemEntity.Data, streamItemEntity.Options);

        /// <summary>
        /// Create stream item from an address; Blockchain name is explicit
        /// </summary>
        /// <param name="client"></param>
        /// <param name="blockchainName"></param>
        /// <param name="id"></param>
        /// <param name="fromAddress"></param>
        /// <param name="streamItemEntity"></param>
        /// <returns></returns>
        public static Task<RpcResponse<string>> PublishStreamItemKeyFrom(this WalletRpcClient client, string blockchainName, string id, string fromAddress, PublishEntity<DataText> streamItemEntity) =>
            client.PublishFromAsync(blockchainName, id, fromAddress, streamItemEntity.StreamIdentifer, streamItemEntity.Key, streamItemEntity.Data, streamItemEntity.Options);


        // *** PublishStreamItemsFrom using an explicit blockchain name

        /// <summary>
        /// Create stream item from an address; Blockchain name is explicit
        /// </summary>
        /// <param name="client"></param>
        /// <param name="blockchainName"></param>
        /// <param name="id"></param>
        /// <param name="fromAddress"></param>
        /// <param name="streamItemEntity"></param>
        /// <returns></returns>
        public static Task<RpcResponse<string>> PublishStreamItemKeysFrom(this WalletRpcClient client, string blockchainName, string id, string fromAddress, PublishEntity streamItemEntity) =>
            client.PublishFromAsync(blockchainName, id, fromAddress, streamItemEntity.StreamIdentifer, streamItemEntity.Keys, streamItemEntity.Data, streamItemEntity.Options);

        /// <summary>
        /// Create stream item from an address; Blockchain name is explicit
        /// </summary>
        /// <param name="client"></param>
        /// <param name="blockchainName"></param>
        /// <param name="id"></param>
        /// <param name="fromAddress"></param>
        /// <param name="streamItemEntity"></param>
        /// <returns></returns>
        public static Task<RpcResponse<string>> PublishStreamItemKeysFrom(this WalletRpcClient client, string blockchainName, string id, string fromAddress, PublishEntity<DataCached> streamItemEntity) =>
            client.PublishFromAsync(blockchainName, id, fromAddress, streamItemEntity.StreamIdentifer, streamItemEntity.Keys, streamItemEntity.Data, streamItemEntity.Options);

        /// <summary>
        /// Create stream item from an address; Blockchain name is explicit
        /// </summary>
        /// <param name="client"></param>
        /// <param name="blockchainName"></param>
        /// <param name="id"></param>
        /// <param name="fromAddress"></param>
        /// <param name="streamItemEntity"></param>
        /// <returns></returns>
        public static Task<RpcResponse<string>> PublishStreamItemKeysFrom(this WalletRpcClient client, string blockchainName, string id, string fromAddress, PublishEntity<DataJson> streamItemEntity) =>
            client.PublishFromAsync(blockchainName, id, fromAddress, streamItemEntity.StreamIdentifer, streamItemEntity.Keys, streamItemEntity.Data, streamItemEntity.Options);

        /// <summary>
        /// Create stream item from an address; Blockchain name is explicit
        /// </summary>
        /// <param name="client"></param>
        /// <param name="blockchainName"></param>
        /// <param name="id"></param>
        /// <param name="fromAddress"></param>
        /// <param name="streamItemEntity"></param>
        /// <returns></returns>
        public static Task<RpcResponse<string>> PublishStreamItemKeysFrom(this WalletRpcClient client, string blockchainName, string id, string fromAddress, PublishEntity<DataText> streamItemEntity) =>
            client.PublishFromAsync(blockchainName, id, fromAddress, streamItemEntity.StreamIdentifer, streamItemEntity.Keys, streamItemEntity.Data, streamItemEntity.Options);


        // *** PublishMultiStreamItems using an inferred blockchain name

        /// <summary>
        /// Publish multiple stream items; Blockchain name is inferred
        /// </summary>
        /// <param name="client"></param>
        /// <param name="publishMultiEntity"></param>
        /// <returns></returns>
        public static Task<RpcResponse<string>> PublishMultiStreamItems(this WalletRpcClient client, PublishMultiEntity publishMultiEntity) =>
            client.PublishMultiAsync(publishMultiEntity.StreamIdentifier, publishMultiEntity.Items, publishMultiEntity.Options);

        // *** PublishMultiStreamItems using an explicit blockchain name

        /// <summary>
        /// Publish multiple stream items; Blockchain name is explicit
        /// </summary>
        /// <param name="client"></param>
        /// <param name="blockchainName"></param>
        /// <param name="id"></param>
        /// <param name="publishMultiEntity"></param>
        /// <returns></returns>
        public static Task<RpcResponse<string>> PublishMultiStreamItems(this WalletRpcClient client, string blockchainName, string id, PublishMultiEntity publishMultiEntity) =>
            client.PublishMultiAsync(blockchainName, id, publishMultiEntity.StreamIdentifier, publishMultiEntity.Items, publishMultiEntity.Options);

        // *** PublishMultiStreamItemsFrom using an inferred blockchain name

        /// <summary>
        /// Publish multiple stream items from an address; Blockchain name is inferred
        /// </summary>
        /// <param name="client"></param>
        /// <param name="fromAddress"></param>
        /// <param name="publishMultiEntity"></param>
        /// <returns></returns>
        public static Task<RpcResponse<string>> PublishMultiStreamItemsFrom(this WalletRpcClient client, string fromAddress, PublishMultiEntity publishMultiEntity) =>
            client.PublishMultiFromAsync(fromAddress, publishMultiEntity.StreamIdentifier, publishMultiEntity.Items, publishMultiEntity.Options);

        // *** PublishMultiStreamItemsFrom using an explicit blockchain name

        /// <summary>
        /// Publish multiple stream items from an address; Blockchain name is explicit
        /// </summary>
        /// <param name="client"></param>
        /// <param name="blockchainName"></param>
        /// <param name="id"></param>
        /// <param name="fromAddress"></param>
        /// <param name="publishMultiEntity"></param>
        /// <returns></returns>
        public static Task<RpcResponse<string>> PublishMultiStreamItemsFrom(this WalletRpcClient client, string blockchainName, string id, string fromAddress, PublishMultiEntity publishMultiEntity) =>
            client.PublishMultiFromAsync(blockchainName, id, fromAddress, publishMultiEntity.StreamIdentifier, publishMultiEntity.Items, publishMultiEntity.Options);
    }
}
