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
    public static class UserService
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

            if (lstUserModel.Count == 0)
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

    public class CreateUserService : BaseService
    {
        public UserModel User { get; set; }

        public string Token { get; set; }

        public static async Task<CreateUserService> CreateUser(string email, string password)
        {
            var uri = new Uri(APIDictionary.API_InsertUser);

            var json = JsonConvert.SerializeObject(new
            {
                Email = email,
                Password = password.GenerateSHA512()
            });

            return await PostAsync<CreateUserService>(json, uri);
        }
    }

    public class LoginService : BaseService
    {
        public UserModel User { get; set; }

        public string Token { get; set; }

        public static async Task<LoginService> LoginUser(string email, string password)
        {
            var uri = new Uri(APIDictionary.API_LoginMembership);

            var json = JsonConvert.SerializeObject(new
            {
                Email = email,
                Password = password.GenerateSHA512()
            });

            return await PutAsync<LoginService>(json, uri);
        }
    }

    public class GetUserService : BaseService
    {
        public UserModel User { get; set; }

        public static async Task<GetUserService> GetUser()
        {
            var uri = new Uri(APIDictionary.API_GetUser);

            return await GetAsync<GetUserService>(uri, UserService.GetUser().Token);
        }
    }
}