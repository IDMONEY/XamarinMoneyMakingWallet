using IDMONEY.IO.Service;
using IDMONEY.IO.View;

using Xamarin.Forms;

namespace IDMONEY.IO
{
    public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            if (UserService.GetUser().IsNotNull())
            {
                MainPage = new MainPage(); 
            }
            else
            {
                MainPage = new LoginView();
            }
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
