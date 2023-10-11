using GIModMan.Converters;
using GIModMan.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace GIModMan.MVVM.Models
{
	public enum ModVisibility
	{
		hide = 0,
		warn,
		show
	}
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class Mod : ObservableObject
    {
#region Properties

        private int _id;
        private string _name;
        private Submitter _submitter;
        private ModCategory _category;
        private ModCategory _superCategory;
        private ModVisibility _initialVisibility;
        private DateTime _creationDate;
        private DateTime _modificationDate;
        private long _downloads;
        private long _likes;
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

        [JsonProperty("_aSubmitter")]
        public Submitter Submitter // TODO: Create model User?
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
        
        [JsonProperty("_aSuperCategory")]
        public ModCategory SuperCategory
        {
            get => _superCategory;
            set => Set(ref _superCategory, value);
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
        /// Enum (show,warn,hide) ModVisibility
        /// </summary>
        [JsonProperty("_sInitialVisibility")]
        public ModVisibility InitialVisibility
        {
            get => _initialVisibility;
            set => Set(ref _initialVisibility, value);
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

        [JsonProperty("_nLikeCount")]
        public long LikeCount
        {
            get => _likes;
            set => Set(ref _likes, value);

        }

        [JsonProperty("_nDownloadCount")]
        public long Donwloads
        {
            get => _downloads;
            set => Set(ref _downloads, value);
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
