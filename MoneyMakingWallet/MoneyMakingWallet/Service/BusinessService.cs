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
    public class BusinessService : BaseRequest
    {
        public ObservableCollection<BusinessModel> Businesses { get; set; }

        public static async Task<BusinessService> SearchBusinessAsync(string name = null)
        {
            BusinessService req = new BusinessService();

            using (HttpClient client = new HttpClient())
            {
                var uri = new Uri(APIDictionary.API_SearchBusiness);

                var json = JsonConvert.SerializeObject(new
                {
                    Name = name
                });

                var content = new StringContent(json, Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", UserService.GetUser().Token);
                HttpResponseMessage response = await client.PostAsync(uri, content).ConfigureAwait(false);
                string ans = await response.Content.ReadAsStringAsync();

                req = JsonConvert.DeserializeObject<BusinessService>(ans);
            }

            return req;
        }
    }
}
