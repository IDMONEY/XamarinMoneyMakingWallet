#region Libraries
using IDMONEY.IO.Model;
using IDMONEY.IO.View;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms; 
#endregion

namespace IDMONEY.IO.Helpers
{
    public static class ErrorHelper
    {
        public static void ControlError(Exception ex, bool applyPopToRoot = true)
        {
            MessengerHelper.Alert(App.Current.Resources["GeneralError"].ToString());
            if (applyPopToRoot)
            {
                if (App.Current.MainPage.GetType() == typeof(MainPage))
                {
                    ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PopToRootAsync();
                }
                else
                {
                    ((NavigationPage)App.Current.MainPage).Navigation.PopToRootAsync();
                }
            }
        }

        public static void ControlError(List<Error> errors, bool isAlert = false)
        {
            if (errors?.Count > 0)
            {
                switch (errors[0].Code)
                {
                    default:
                        MessengerHelper.ShowError(errors[0], isAlert);
                        break;
                }
            }
        }
    }
}