using Newtonsoft.Json;
using System;

namespace MCWrapper.RPC.Ledger.Entities
{
    /// <summary>
    /// Asset data model used for creating and transmitting entities to the blockchain network
    /// </summary>
    public class AssetEntity
    {
        /// <summary>
        /// Name of the new blockchain Asset
        /// </summary>
        [JsonProperty("name")]
        public string Name
        {
            get => _name;
            set => _name = value;
        }
        private string _name = string.Empty;

        /// <summary>
        /// Is the Asset open to reeive more units?
        /// Default value: True;
        /// True if follow-on issues are allowed
        /// </summary>
        [JsonProperty("open")]
        public bool IsOpen
        {
            get => _isOpen;
            set => _isOpen = value;
        }
        private bool _isOpen = true;

        /// <summary>
        /// Restrictions to place on this blockchain Asset;
        /// Possible valus: send,receive
        /// Comma delimited list of restrictions e.g. "send,receive"
        /// </summary>
        [JsonProperty("restrict")]
        public string? Restrictions
        {
            get => _restrictions;
            set => _restrictions = value;
        }
        private string? _restrictions = null;

        /// <summary>
        /// 
        /// </summary>
        public AssetEntity()
        {
            SetEntityNameAsUUID();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public AssetEntity(string name)
        {
            _name = name;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="isOpen"></param>
        public AssetEntity(string name, bool isOpen)
        {
            _name = name;
            _isOpen = isOpen;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="isOpen"></param>
        /// <param name="restrictions"></param>
        public AssetEntity(string name, bool isOpen, string restrictions)
        {
            _name = name;
            _isOpen = isOpen;
            _restrictions = restrictions;
        }


        /// <summary>
        /// Generate a 22-character UUID;
        /// Want to use your own UUID? Go ahead;
        /// This method can be called to assign a UUID to the Name property 
        /// and will return that same UUID string to the subscriber when called
        /// </summary>
        public static string GetUUID()
        {
            // generate a new Guid (36 characters)
            var newGuid = Guid.NewGuid();

            // convert and truncate Guid to 24 character UUID
            var newUuid = Convert.ToBase64String(newGuid.ToByteArray());

            // truncate the '==' trailing characters which results in a 22 character UUID
            var truncUuid = newUuid.Remove(newUuid.Length - 2);

            return truncUuid;
        }

        /// <summary>
        /// Generate a 22-character UUID;
        /// Want to use your own UUID? Go ahead;
        /// This method can be called to assign a UUID to the Name property 
        /// and will return that same UUID string to the subscriber when called
        /// </summary>
        public void SetEntityNameAsUUID()
        {
            // generate a new Guid (36 characters)
            var newGuid = Guid.NewGuid();

            // convert and truncate Guid to 24 character UUID
            var newUuid = Convert.ToBase64String(newGuid.ToByteArray());

            // truncate the '==' trailing characters which results in a 22 character UUID
            var truncUuid = newUuid.Remove(newUuid.Length - 2);

            _name = truncUuid;
        }
    }
}