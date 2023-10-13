using Newtonsoft.Json;
using System;

namespace GIModMan.MVVM.Models
{
    public class ModImage
    {
        [JsonProperty("_sBaseUrl")]
        public Uri BaseUrl { get; set; }

        [JsonProperty("_sFile")]
        public string File { get; set; }

        [JsonProperty("_sFile220")]
        public string File220 { get; set; }

        [JsonProperty("_sFile100")]
        public string File100 { get; set; }

    }
}
