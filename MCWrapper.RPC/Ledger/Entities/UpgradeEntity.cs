using MCWrapper.RPC.Constants;
using MCWrapper.RPC.Ledger.Entities.BaseEntity;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace MCWrapper.RPC.Ledger.Entities
{
    /// <summary>
    /// UpgradeEntity is POCO representation of an Upgrade for MultiChain Core
    /// </summary>
    public class UpgradeEntity : ChainEntity
    {
        /// <summary>
        /// Upgrade customer fields property
        /// </summary>
        public UpgradeCustomFields CustomFields { get => _customFields; }
        private readonly UpgradeCustomFields _customFields;

        /// <summary>
        /// Readonly and initialized with False value;
        /// <para>
        ///     Should always be false for UpgradeEntity types
        /// </para>
        /// </summary>
        public bool Open => _open;
        private readonly bool _open = false;

        /// <summary>
        /// Create a new UpgradeEntity instance
        /// </summary>
        /// <param name="name"></param>
        /// <param name="customFields"></param>
        public UpgradeEntity(string name, UpgradeCustomFields customFields)
            : base(name, Entity.Upgrade) => _customFields = customFields;
    }

    /// <summary>
    /// Custom fields object used to build a proper MultiChain upgrade request
    /// </summary>
    public class UpgradeCustomFields
    {
        /// <summary>
        /// UpgradeCustomFields parameter key valu pairs
        /// </summary>
        public ConcurrentDictionary<string, int> Parameters
        {
            get => _parameters;
        }
        private readonly ConcurrentDictionary<string, int> _parameters;

        /// <summary>
        /// Whitelist of valid MultiChain Core upgrade parameters
        /// </summary>
        private readonly List<string> paramKeyWhitelist = new List<string>
        {
            UpgradeParameterKeys.StartBlock,
            UpgradeParameterKeys.ProtocolVersion,
            UpgradeParameterKeys.TargetBlockTimeKey,
            UpgradeParameterKeys.MaximumBlockSizeKey,
            UpgradeParameterKeys.MaxStdTxSizeKey,
            UpgradeParameterKeys.MaxStdOpReturnsCountKey,
            UpgradeParameterKeys.MaxStdOpReturnSizeKey,
            UpgradeParameterKeys.MaxStdOpDropsCountKey,
            UpgradeParameterKeys.MaxStdElementSizeKey,
            UpgradeParameterKeys.AnyoneCanConnectKey,
            UpgradeParameterKeys.AnyoneCanSend,
            UpgradeParameterKeys.AnyoneCanReceive,
            UpgradeParameterKeys.AnyoneCanReceiveEmpty,
            UpgradeParameterKeys.AnyoneCanIssue,
            UpgradeParameterKeys.AnyoneCanCreate,
            UpgradeParameterKeys.AnyoneCanActivate,
        };

        /// <summary>
        /// Create a new UpgradeCustomFields instance
        /// </summary>
        /// <param name="protocolVersion"></param>
        /// <param name="paramKey"></param>
        /// <param name="paramValue"></param>
        /// <param name="startBlock"></param>
        /// <param name="additionalParameters"></param>
        public UpgradeCustomFields(
            int protocolVersion, string paramKey, int paramValue,
            Dictionary<string, int> additionalParameters, int? startBlock = null)
        {
            // validate paramKey against hard-coded whitelist
            if (!paramKeyWhitelist.Contains(paramKey))
                throw new ArgumentException($"{paramKey} is not a valid MultiChain Core Upgrade parameter key value");

            // if we get here we know the paramKey is valid and we instantiate the Concurrent Dictionary
            _parameters = new ConcurrentDictionary<string, int>();

            // add protocol version key value pair
            _parameters.TryAdd(UpgradeParameterKeys.ProtocolVersion, protocolVersion);

            // add param key value pair
            _parameters.TryAdd(paramKey, paramValue);

            // add start block key value pair
            _parameters.TryAdd(UpgradeParameterKeys.StartBlock, startBlock ?? 0);

            // append remaining parameters to Concurrent Dictionary
            foreach (var keyPair in additionalParameters)
                _parameters.TryAdd(keyPair.Key, keyPair.Value);
        }

        /// <summary>
        /// Add or update internal ConcurrentDictionary key value
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public int AddOrUpdateParameter(string key, int value)
        {
            var addOrUpdate = _parameters.AddOrUpdate(key, value,
                (key, existingValue) =>
                {
                    existingValue = value;
                    return existingValue;
                });

            return addOrUpdate;
        }

        /// <summary>
        /// If key exists within the internal ConcurrentDictionary then we remove the key value pair;
        /// Otherwise no action is taken since we do verify if the parameter actually exists before attempting
        /// to remove from the ConcurrentDictionary collection.
        /// </summary>
        /// <param name="key"></param>
        public void RemoveParameter(string key)
        {
            if (_parameters.ContainsKey(key))
                _ = _parameters.Remove(key, out int _);
        }
    }

    /// <summary>
    /// Struct defines all available MultiChain upgrade parameter keys
    /// </summary>
    public struct UpgradeParameterKeys
    {
        /// <summary>
        /// (optional, default 0) Block to apply from
        /// </summary>
        public const string StartBlock = "startblock";

        /// <summary>
        /// (optional) Protocol version to upgrade to
        /// <para>Upgrade parameter represented as a plain string "protocol-version"</para>
        /// </summary>
        public const string ProtocolVersion = "protocol-version";

        /// <summary>
        /// Upgrade parameter represented as a plain string "max-std-tx-size"
        /// </summary>
        public const string MaxStdTxSizeKey = "max-std-tx-size";

        /// <summary>
        /// Upgrade parameter represented as a plain string "maximum-block-size"
        /// </summary>
        public const string MaximumBlockSizeKey = "maximum-block-size";

        /// <summary>
        /// Upgrade parameter represented as a plain string "target-block-time"
        /// </summary>
        public const string TargetBlockTimeKey = "target-block-time";

        /// <summary>
        /// Upgrade parameter represented as a plain string "max-std-op-returns-count"
        /// </summary>
        public const string MaxStdOpReturnsCountKey = "max-std-op-returns-count";

        /// <summary>
        /// Upgrade parameter represented as a plain string "max-std-op-return-size"
        /// </summary>
        public const string MaxStdOpReturnSizeKey = "max-std-op-return-size";

        /// <summary>
        /// Upgrade parameter represented as a plain string "max-std-op-drops-count"
        /// </summary>
        public const string MaxStdOpDropsCountKey = "max-std-op-drops-count";

        /// <summary>
        /// Upgrade parameter represented as a plain string "max-std-element-size"
        /// </summary>
        public const string MaxStdElementSizeKey = "max-std-element-size";

        /// <summary>
        /// Upgrade parameter represented as a plain string "anyone-can-connect"
        /// </summary>
        public const string AnyoneCanConnectKey = "anyone-can-connect";

        /// <summary>
        /// Upgrade parameter represented as a plain string "anyone-can-send"
        /// </summary>
        public const string AnyoneCanSend = "anyone-can-send";

        /// <summary>
        /// Upgrade parameter represented as a plain string "anyone-can-receive"
        /// </summary>
        public const string AnyoneCanReceive = "anyone-can-receive";

        /// <summary>
        /// Upgrade parameter represented as a plain string "anyone-can-receiveempty"
        /// </summary>
        public const string AnyoneCanReceiveEmpty = "anyone-can-receiveempty";

        /// <summary>
        /// Upgrade parameter represented as a plain string "anyone-can-issue"
        /// </summary>
        public const string AnyoneCanIssue = "anyone-can-issue";

        /// <summary>
        /// Upgrade parameter represented as a plain string "anyone-can-create"
        /// </summary>
        public const string AnyoneCanCreate = "anyone-can-create";

        /// <summary>
        /// Upgrade parameter represented as a plain string "anyone-can-activate"
        /// </summary>
        public const string AnyoneCanActivate = "anyone-can-activate";
    }
}