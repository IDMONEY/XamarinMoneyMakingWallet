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
    public class BusinessService : BaseService
    {
        public ObservableCollection<BusinessModel> Businesses { get; set; }

        public static async Task<BusinessService> SearchBusinessAsync(string name)
        {
            var uri = new Uri(APIDictionary.API_BusinessList);

            Dictionary<string, string> parameters = null;

            parameters = new Dictionary<string, string>()
                {
                    { "Name", name }
                };

            return await GetAsync<BusinessService>(uri, UserService.GetUser().Token, parameters);
        }

        public static async Task<BusinessService> BusinessListAsync()
        {
            var uri = new Uri(APIDictionary.API_BusinessList);
            return await GetAsync<BusinessService>(uri, UserService.GetUser().Token);
        }
    }
}
