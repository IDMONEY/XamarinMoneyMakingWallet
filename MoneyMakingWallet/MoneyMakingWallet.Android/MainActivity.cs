
using Acr.UserDialogs;
using Android.App;
using Android.Content.PM;
using Android.OS;
using IDMONEY.IO;

namespace MoneyMakingWallet.Droid
{
    [Activity(Label = "MIAMI WALLET", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            // Added to Acr UserDialogs to work
            UserDialogs.Init(this);

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);  

            global::Xamarin.Forms.Forms.Init(this, bundle);

            LoadApplication(new App());
        }
    }
}

