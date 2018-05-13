using System;
using System.Collections.Generic;
using System.Text;

namespace IDMONEY.IO.Model
{
    public class APIDictionary
    {
        private const string Base = "http://jeancarlos.eastus2.cloudapp.azure.com/WebApiMoneyMakingWallet2/";

        #region Users
        public const string API_CreateUser = Base + "api/User/Create";
        public const string API_LoginUser = Base + "api/User/Login";
        #endregion
    }
}
