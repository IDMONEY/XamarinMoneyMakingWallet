using IDMONEY.IO.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace IDMONEY.IO.Service
{
    public class EntryDataService : BaseRequest
    {
        public ObservableCollection<DataEntryModel> DataEntries { get; set; }

        public static async Task<EntryDataService> SearchEntryDataAsync()
        {
            EntryDataService req = new EntryDataService();

            using (HttpClient client = new HttpClient())
            {
                var uri = new Uri(APIDictionary.API_SearchEntryData);

                var json = JsonConvert.SerializeObject(new
                {
                });

                var content = new StringContent(json, Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", UserService.GetUser().Token);
                HttpResponseMessage response = await client.PostAsync(uri, content).ConfigureAwait(false);
                string ans = await response.Content.ReadAsStringAsync();

                req = JsonConvert.DeserializeObject<EntryDataService>(ans);
            }

            return req;
        }

        public static async Task<EntryDataService> SaveEntryDataAsync(ObservableCollection<DataEntryModel> lstDataEntries)
        {
            EntryDataService req = new EntryDataService();

            using (HttpClient client = new HttpClient())
            {
                var uri = new Uri(APIDictionary.API_SaveEntryData);

                var json = JsonConvert.SerializeObject(new
                {
                    DataEntries = lstDataEntries
                });

                var content = new StringContent(json, Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", UserService.GetUser().Token);
                HttpResponseMessage response = await client.PostAsync(uri, content).ConfigureAwait(false);
                string ans = await response.Content.ReadAsStringAsync();

                req = JsonConvert.DeserializeObject<EntryDataService>(ans);
            }

            return req;
        }
    }
}
