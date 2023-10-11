using Newtonsoft.Json;

namespace GIModMan.MVVM.Models
{
    public class Submitter
    {
        [JsonProperty("_idRow")]
        public int ID { get; set; }


        [JsonProperty("_sName")]
        public string Name { get; set; }
    }
}
