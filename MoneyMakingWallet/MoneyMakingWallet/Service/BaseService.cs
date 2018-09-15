using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace IDMONEY.IO.Model
{
    public abstract class BaseService
    {
        public bool IsSuccessful { get; set; }

        public List<Error> Errors { get; set; }

        public BaseService()
        {
            Errors = new List<Error>();
        }

        public async static Task<Request> PostAsync<Request>(string json, Uri uri, string token = null) where Request : BaseService
        {
            using (HttpClient client = new HttpClient())
            {
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                if (!string.IsNullOrEmpty(token))
                {
                    client.DefaultRequestHeaders.Add("Authorization", token);
                }
                HttpResponseMessage response = await client.PostAsync(uri, content).ConfigureAwait(false);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    throw new Exception("Exception from api");
                }

                string ans = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<Request>(ans);
            }
        }

        public async static Task<Request> GetAsync<Request>(Uri uri, string token = null, Dictionary<string, string> parameters = null) where Request : BaseService
        {
            StringBuilder paramsBuilder = new StringBuilder();
            if (parameters.IsNotNull())
            {
                foreach(KeyValuePair<string, string> param in parameters)
                {
                    if (paramsBuilder.Length > 0)
                    {
                        paramsBuilder.Append("&");
                    }
                    paramsBuilder.Append($"{param.Key}={param.Value}");
                }
            }

            UriBuilder builder = new UriBuilder(uri);
            builder.Query = paramsBuilder.ToString();

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                if (!string.IsNullOrEmpty(token))
                {
                    client.DefaultRequestHeaders.Add("Authorization", token);
                }

                HttpResponseMessage response = await client.GetAsync(builder.Uri).ConfigureAwait(false);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    throw new Exception("Exception from api");
                }

                string ans = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Request>(ans);
            }
        }

        public async static Task<Request> PutAsync<Request>(string json, Uri uri, string token = null) where Request : BaseService
        {
            using (HttpClient client = new HttpClient())
            {
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                if (!string.IsNullOrEmpty(token))
                {
                    client.DefaultRequestHeaders.Add("Authorization", token);
                }

                HttpResponseMessage response = await client.PutAsync(uri, content).ConfigureAwait(false);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    throw new Exception("Exception from api");
                }

                string ans = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<Request>(ans);
            }
        }
    }

    public class Error
    {
        public Error()
        {

        }

        public string Message { set; get; }
        public string Code { set; get; }
    }
}
