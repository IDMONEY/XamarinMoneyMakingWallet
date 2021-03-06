﻿namespace IDMONEY.IO.Model
{
    //TODO: Store this information on configuration file
    public static class APIDictionary
    {
        private const string Base = "http://ec2-54-70-160-109.us-west-2.compute.amazonaws.com/WebApiMoneyMakingWallet/";
        #region Users
        public const string API_InsertUser = Base + "api/users";
        public const string API_LoginMembership = Base + "api/membership/login";
        public const string API_GetUser = Base + "api/users";
        #endregion

        #region Business
        public const string API_BusinessList = Base + "api/businesses";
        #endregion

        #region Transaction
        public const string API_InsertTrasaction = Base + "api/transactions";
        public const string API_TransactionsList = Base + "api/transactions";
        public const string API_TransactionPersonal = Base + "api/transactions/personal";

        
        #endregion
    }
}