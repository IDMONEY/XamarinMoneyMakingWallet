using IDMONEY.IO.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IDMONEY.IO.View.Security
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegisterUserView : ContentPage
	{
		public RegisterUserView ()
		{
			InitializeComponent ();

            BindingContext = new RegisterUserViewModel();
        }

        protected override bool OnBackButtonPressed()
        {
            App.Current.MainPage = new LoginView();
            return true;
        }
    }
}