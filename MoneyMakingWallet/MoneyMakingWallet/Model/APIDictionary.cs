using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace IDMONEY.IO.Model
{
    public class APIDictionary
    {
        private const string Base = "http://jeancarlos.eastus2.cloudapp.azure.com/WebApiMoneyMakingWallet2/";
        //private const string Base = "http://54.70.160.109/webapimoneymakingwallet/";

        #region Users
        public const string API_CreateUser = Base + "api/User/Create";
        public const string API_LoginUser = Base + "api/User/Login";
        public const string API_GetUser = Base + "api/User/Get";
        #endregion

        #region Business
        public const string API_SearchBusiness = Base + "api/Business/Search";
        #endregion
        #region Transaction
        public const string API_InsertTrasaction = Base + "api/Transaction/Insert";
        #endregion
    }
}
