using IDMONEY.IO.View;
using MoneyMakingWallet;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace IDMONEY.IO.Helper
{
    public class ErrorHelper
    {
        public static void ControlError(Exception ex)
        {
            MessengerHelper.Alert(App.Current.Resources["GeneralError"].ToString());
            if (App.Current.MainPage.GetType() == typeof(MasterDetailPage))
            {
                ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PopToRootAsync();
            }
            else
            {
                ((NavigationPage)App.Current.MainPage).Navigation.PopToRootAsync();
            }
        }
    }
}