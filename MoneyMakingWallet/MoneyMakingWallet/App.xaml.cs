using IDMONEY.IO.Model;
using IDMONEY.IO.Service;
using IDMONEY.IO.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace IDMONEY.IO
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            if (UserService.GetUser() == null)
            {
                MainPage = new LoginView();
            }
            else
            {
                MainPage = new MainPage();
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
