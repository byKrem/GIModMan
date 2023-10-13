using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace GIModMan.MVVM.Models
{
    public class PreviewMedia
    {
        [JsonProperty("_aImages")]
        public List<ModImage> Images { get; set; }

        public Uri FirstImagePath => new Uri($"{Images[0].BaseUrl}/{Images[0].File}");
    }
}
