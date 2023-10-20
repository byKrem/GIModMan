using Newtonsoft.Json;
using System.Collections.Generic;

namespace GIModMan.MVVM.Models.API
{
    public class RecordsList<T>
    {

        [JsonProperty("_aMetadata")]
        public RecordMetadata Metadata { get; set; }

        [JsonProperty("_aRecords")]
        public List<T> Records { get; set; }
    }
}
