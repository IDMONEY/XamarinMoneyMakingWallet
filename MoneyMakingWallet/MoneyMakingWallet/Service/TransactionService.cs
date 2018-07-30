using IDMONEY.IO.Model;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace IDMONEY.IO.Service
{
    public class TransactionService : BaseRequest
    {
        public TransactionModel Transaction { get; set; }

        public static async Task<TransactionService> InsertTrasactionAsync(TransactionModel transaction)
        {
            TransactionService req = new TransactionService();

            using (HttpClient client = new HttpClient())
            {
                var uri = new Uri(APIDictionary.API_InsertTrasaction);

                var json = JsonConvert.SerializeObject(new
                {
                    Transaction = transaction
                });

                var content = new StringContent(json, Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", UserService.GetUser().Token);
                HttpResponseMessage response = await client.PostAsync(uri, content).ConfigureAwait(false);
                string ans = await response.Content.ReadAsStringAsync();

                req = JsonConvert.DeserializeObject<TransactionService>(ans);
            }

            return req;
        }
    }
}
