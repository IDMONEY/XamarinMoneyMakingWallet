#region Libraries
using Acr.UserDialogs;
using IDMONEY.IO.Model; 
#endregion

namespace IDMONEY.IO.Helpers
{
    public static class MessengerHelper
    {
        public static void Alert(string msg)
        {
            UserDialogs.Instance.Alert(msg, App.Current.Resources["AlertTitle"].ToString(), App.Current.Resources["AlertOk"].ToString());
        }

        public static void Toast(string msg)
        {
            UserDialogs.Instance.Toast(msg);
        }

        public static void ShowError(Error error, bool isAlert)
        {
            if (isAlert)
            {
                Alert(error.Message);
            }
            else
            {
                Toast(error.Message);
            }
        }
    }
}