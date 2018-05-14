using Newtonsoft.Json;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace IDMONEY.IO.Model
{
    public class UserModel : RealmObject
    {
        [PrimaryKey]
        public long Id { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string Password { get; set; }

        public string Privatekey { get; set; }

        public string Token { get; set; }
    }

    public class UserRequest
    {
        public static UserModel GetUser()
        {
            var realm = Realm.GetInstance();

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
            var realm = Realm.GetInstance();

            var lstUserModel = realm.All<UserModel>().ToList();

            if (lstUserModel.Count() == 0)
            {
                //Insert
                realm.Write(() =>
                {
                    realm.Add(new UserModel { Token = token, Address = user.Address, Email = user.Email, Id = user.Id,
                                            Password = user.Password, Privatekey = user.Privatekey });
                });
            }
            else
            {
                using (var trans = realm.BeginWrite())
                {
                    realm.RemoveAll();

                    var userModel = new UserModel { Token = token, Address = user.Address, Email = user.Email,
                                    Id = user.Id, Password = user.Password, Privatekey = user.Privatekey
                    };

                    realm.Add(userModel);

                    trans.Commit();
                }
            }
        }

        public static void DeleteUser()
        {
            var realm = Realm.GetInstance();

            using (var transaction = realm.BeginWrite())
            {
                realm.RemoveAll();
                transaction.Commit();
            }
        }
    }

    public class CreateUserRequest : BaseRequest
    {
        public UserModel User { get; set; }

        public string Token { get; set; }

        public static async Task<CreateUserRequest> CreateUser(string email, string password)
        {
            CreateUserRequest req = new CreateUserRequest();

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

                req = JsonConvert.DeserializeObject<CreateUserRequest>(ans);
            }

            return req;
        }
    }

    public class LoginRequest : BaseRequest
    {
        public UserModel User { get; set; }

        public string Token { get; set; }

        public static async Task<LoginRequest> LoginUser(string email, string password)
        {
            LoginRequest req = new LoginRequest();

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

                req = JsonConvert.DeserializeObject<LoginRequest>(ans);
            }

            return req;
        }
    }
}
