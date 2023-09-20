using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace GIModMan.MVVM.Models
{
    public class ModCategory
    {
        [JsonProperty("_idRow")]
        public int ID { get; set; } // 17510

        [JsonProperty("_sName")]
        public string Name { get; set; }

        [JsonProperty("_nItemCount")]
        public int ItemsCount { get; set; }

        [JsonProperty("_sIconUrl")]
        public Uri IconUrl { get; set; }

        [JsonProperty("_nCategoryCount")]
        public int SubCategoryCount { get; set; }

        public List<ModCategory> SubCategories { get; set; } // ModCategory/:rootCategoryId/SubCategories
    }
}
