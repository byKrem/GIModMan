using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using GIModMan.Extensions;

namespace GIModMan.Core
{
    public class GameBananaAPIWork
    {
        private const int GAME_ID = 8552;
        /// <summary>
        /// {0} - PageNumber,
        /// {1} - ItemsPerPage,
        /// {2} - SortType (Enum: "default", "new", "updated")
        /// </summary>
        private const string LIST_DATA_PATH = "/Game/8552/Subfeed?_nPage={0}&_nPerpage={1}&" +
            "_sSort={2}&_csvModelInclushions=Mod"; // Maybe include Tool model?
        /// <summary>
        /// {0} - ItemType, {1} - ItemID, {2} - Properties
        /// </summary>
        private const string ITEM_DATA_PATH = "/{0}/{1}?_csvProperties={2}";
        private const string BASE_PATH = "https://gamebanana.com/apiv11";

        private static HttpClient client;
        static GameBananaAPIWork()
        {
            client = new HttpClient()
            {
                BaseAddress = new Uri(BASE_PATH)
            };
        }

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

            string request = string.Format(ITEM_DATA_PATH, nameof(T), itemid, PreparePropertiesString(fields));

            var response = client.GetStringAsync(request);

            return JsonConvert.DeserializeObject<T>(await @response);
        }

        public async Task<List<T>> GetListAsync<T>(int page, int itemsPerPage, params string[] fields)
        {
            string request = string.Format(LIST_DATA_PATH, page, itemsPerPage, "default");

            var response = client.GetStringAsync(request);

            // TODO: Change to new version of API
            List<List<object>> items = JsonConvert.DeserializeObject<List<List<object>>>(await @response);
            // (long) x[1] - Item ID
            IEnumerable<Task<T>> tasks = items.Select(x => GetItemAsync<T>((long)x[1], fields));
            return (await Task.WhenAll(tasks)).ToList();
        }
    }
}
