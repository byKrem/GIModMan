using GIModMan.Converters;
using GIModMan.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace GIModMan.MVVM.Models
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class Mod : ObservableObject
    {
#region Properties

        private int _id;
        private string _name;
        private JArray _submitter;
        private ModCategory _category;
        private bool _isNSFW;
        private DateTime _creationDate;
        private DateTime _modificationDate;
        private string _description;
        private long _downloads;
        private List<ModFile> _files = new List<ModFile>();

        [JsonProperty("_idRow")]
        public int Id
        {
            get => _id;
            set => Set(ref _id, value);
        }

        [JsonProperty("_sName")]
        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }

        /// <summary>
        /// _idRow, _sName, _sAvatarUrl
        /// </summary>
        [JsonProperty("_aSubmitter")]
        public JArray Submitter // TODO: Create model User?
        {
            get => _submitter;
            set => Set(ref _submitter, value);
        }

        /// <summary>
        /// _sName, _sIconUrl
        /// </summary>
        [JsonProperty("_aRootCategory")]
        public ModCategory Category
        {
            get => _category;
            set => Set(ref _category, value);
        }
        /*
         * Genshin Mod Categories:
            {
            Entity
            Gadget
            MelonLoader (Exclude 'cause not GIMI)
            Objects {TCG Cards}
            Other/Misc
            Skins
             {
              Weapons
              Character {...}
             }
            UI {Loading Screen, MouseCursor, Characters Icons, Splash Screen}
            Waverider
            }
         */

        /// <summary>
        /// Enum (show,warn,hide)
        /// </summary>
        [JsonProperty("_sInitialVisibility")]
        public bool IsNSFW
        {
            get => _isNSFW;
            set => Set(ref _isNSFW, value);
        }

        [JsonProperty("_tsDateAdded")]
        [JsonConverter(typeof(UnixTimeToDateTimeConverter))]
        public DateTime CreationDate
        {
            get => _creationDate;
            set => Set(ref _creationDate, value);
        }

        [JsonProperty("_tsDateModified")]
        [JsonConverter(typeof(UnixTimeToDateTimeConverter))]
        public DateTime ModificationDate
        {
            get => _modificationDate;
            set => Set(ref _modificationDate, value);
        }

        [JsonProperty("_aFiles")]
        public List<ModFile> Files
        {
            get => _files;
            set => Set(ref _files, value);
        }

#endregion
        public Mod()
        {

        }
		
		public Mod(int itemid)
		{
			_id = itemid;
		}
    }
}
