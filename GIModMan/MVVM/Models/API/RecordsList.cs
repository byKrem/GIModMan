using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace GIModMan.MVVM.Models.API
{
    internal class RecordsList<T>
    {
        [JsonProperty("_aMetadata")]
        public JObject Metadata { get; set; }

        [JsonProperty("_aRecords")]
        public List<T> Records { get; set; }
    }
}
