using Acr.UserDialogs;
using MoneyMakingWallet;
using System;
using System.Collections.Generic;
using System.Text;

namespace IDMONEY.IO.Helper
{
    public class MessengerHelper
    {
        public static void Alert(string msg)
        {
            UserDialogs.Instance.Alert(msg, App.Current.Resources["AlertTitle"].ToString(), App.Current.Resources["AlertOk"].ToString());
        }

        public static void Toast(string msg)
        {
            UserDialogs.Instance.Toast(msg);
        }
    }
}
