using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace IDMONEY.IO.Model
{
    public class APIDictionary
    {
        private const string Base = "http://jeancarlos.eastus2.cloudapp.azure.com/WebApiMoneyMakingWallet2/";

        #region Users
        public const string API_CreateUser = Base + "api/User/Create";
        public const string API_LoginUser = Base + "api/User/Login";

        public const string API_SearchEntryData = Base + "api/EntryData/SearchEntryData";
        public const string API_SaveEntryData = Base + "api/EntryData/SaveEntryData";
        #endregion
    }
}
