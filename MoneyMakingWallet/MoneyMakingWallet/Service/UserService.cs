using IDMONEY.IO.Model;
using Newtonsoft.Json;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace IDMONEY.IO.Service
{
    public class UserService
    {
        public static UserModel GetUser()
        {
            var realm = Realm.GetInstance(AppManagement.RealmConfigurationUser);

            var lstUserModel = realm.All<UserModel>();

            if (lstUserModel.Count() > 0)
            {
                return lstUserModel.FirstOrDefault();
            }
            else
            {
                return null;
            }
        }

        public static void SaveUser(UserModel user, string token)
        {
            var realm = Realm.GetInstance(AppManagement.RealmConfigurationUser);

            var lstUserModel = realm.All<UserModel>().ToList();

            if (lstUserModel.Count() == 0)
            {
                //Insert
                realm.Write(() =>
                {
                    realm.Add(new UserModel
                    {
                        Token = token,
                        Email = user.Email,
                        Id = user.Id
                    });
                });
            }
            else
            {
                using (var trans = realm.BeginWrite())
                {
                    realm.RemoveAll();

                    var userModel = new UserModel
                    {
                        Token = token,
                        Email = user.Email,
                        Id = user.Id,
                    };

                    realm.Add(userModel);

                    trans.Commit();
                }
            }
        }

        public static void DeleteUser()
        {
            var realm = Realm.GetInstance(AppManagement.RealmConfigurationUser);

            using (var transaction = realm.BeginWrite())
            {
                realm.RemoveAll();
                transaction.Commit();
            }
        }
    }

    public class CreateUserService : BaseRequest
    {
        public UserModel User { get; set; }

        public string Token { get; set; }

        public static async Task<CreateUserService> CreateUser(string email, string password)
        {
            CreateUserService req = new CreateUserService();

            using (HttpClient client = new HttpClient())
            {
                var uri = new Uri(APIDictionary.API_CreateUser);

                var json = JsonConvert.SerializeObject(new
                {
                    Email = email,
                    Password = password
                });

                var content = new StringContent(json, Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.PostAsync(uri, content).ConfigureAwait(false);
                string ans = await response.Content.ReadAsStringAsync();

                req = JsonConvert.DeserializeObject<CreateUserService>(ans);
            }

            return req;
        }
    }

    public class LoginService : BaseRequest
    {
        public UserModel User { get; set; }

        public string Token { get; set; }

        public static async Task<LoginService> LoginUser(string email, string password)
        {
            LoginService req = new LoginService();

            using (HttpClient client = new HttpClient())
            {
                var uri = new Uri(APIDictionary.API_LoginUser);

                var json = JsonConvert.SerializeObject(new
                {
                    Email = email,
                    Password = password
                });

                var content = new StringContent(json, Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.PostAsync(uri, content);
                string ans = await response.Content.ReadAsStringAsync();

                req = JsonConvert.DeserializeObject<LoginService>(ans);
            }

            return req;
        }
    }
}
