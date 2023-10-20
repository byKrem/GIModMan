using Newtonsoft.Json;

namespace GIModMan.MVVM.Models.API
{
    public class RecordMetadata
    {
        [JsonProperty("_nRecordCount")]
        public int RecordsCount { get; set; }

        [JsonProperty("_nPerpage")]
        public int PerPage { get; set; }

        [JsonProperty("_bIsComplete")]
        public bool IsComplete { get; set; }
        public int TotalPages => (int)System.Math.Ceiling((double)RecordsCount / PerPage);
    }
}
