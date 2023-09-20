using GIModMan.Converters;
using Newtonsoft.Json;
using System;

namespace GIModMan.MVVM.Models
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class ModFile
    {
        [JsonProperty("_idRow")]
        public int Id { get; set; }

        [JsonProperty("_sFile")]
        public string FileName { get; set; }

        [JsonProperty("_nFilesize")]
        public int Filesize { get; set; }

        [JsonProperty("_sDescription")]
        public string Description { get; set; }

        [JsonProperty("_tsDateAdded")]
        [JsonConverter(typeof(UnixTimeToDateTimeConverter))]
        public DateTime DateAdded { get; set; }

        [JsonProperty("_nDownloadCount")]
        public long DownloadCount { get; set; }

        [JsonProperty("_sAnalysisState")]
        public string AnalysisState { get; set; }

        [JsonProperty("_sDownloadUrl")]
        public Uri DownloadUrl { get; set; }

        [JsonProperty("_sMd5Checksum")]
        public string Md5Checksum { get; set; }

        [JsonProperty("_sClamAvResult")]
        public string ClamAvResult { get; set; }

        [JsonProperty("_sAnalysisResult")]
        public string AnalysisResult { get; set; }

        [JsonProperty("_bContainsExe")]
        public bool ContainsExe { get; set; }

    }
}
