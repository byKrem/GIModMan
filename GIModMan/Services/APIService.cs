using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using GIModMan.Extensions;
using GIModMan.MVVM.Models.API;

namespace GIModMan.Services
{
    public class APIService
    {
        private const int GAME_ID = 8552;
        /// <summary>
        /// {0} - PageNumber,
        /// {1} - ItemsPerPage,
        /// {2} - SortType (Enum: "default", "new", "updated"),
        /// </summary>
        private const string LIST_DATA_PATH = "https://gamebanana.com/apiv11/Game/8552/Subfeed?_nPage={0}&_nPerpage={1}&" +
            "_sSort={2}&_csvModelExclusions=App,Article,Bug,Blog,Club,Contest,Concept,Event,Game,Idea" +
            ",Jam,Model,News,Poll,Project,Question,Review,Request,Script," +
            "Sound,Spray,Studio,Thread,Tool,Tutorial,Wiki,Wip"; // Maybe include Tool model?
        /// <summary>
        /// {0} - ItemType, {1} - ItemID, {2} - Properties
        /// </summary>
        private const string ITEM_DATA_PATH = "https://gamebanana.com/apiv11/{0}/{1}?_csvProperties={2}";

        private string PreparePropertiesString(string[] fields)
        {
            StringBuilder propertiesBuilder = new StringBuilder();

            for (int i = 0; i < fields.Length; i++)
            {
                propertiesBuilder.Append(fields[i]);
                if (i == fields.Length - 1)
                    continue;
                propertiesBuilder.Append(',');
            }

            return propertiesBuilder.ToString();
        }

        public async Task<T> GetItemAsync<T>(long itemid, params string[] fields)
        {
            if (fields.Length == 0)
            {
                fields = typeof(T).GetCustomAttributesNames().ToArray();
            }
            HttpClient client = new HttpClient();

            string request = string.Format(ITEM_DATA_PATH, nameof(T), itemid, PreparePropertiesString(fields));

            var response = client.GetStringAsync(request);

            return JsonConvert.DeserializeObject<T>(await @response);
        }

        public async Task<List<T>> GetListAsync<T>(int page)
        {
            int itemsPerPage = 15;
            string request = string.Format(LIST_DATA_PATH, page, itemsPerPage, "default");

            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync(request);

            RecordsList<T> records = JsonConvert.DeserializeObject<RecordsList<T>>(@response);

            return records.Records;
        }
    }
}
