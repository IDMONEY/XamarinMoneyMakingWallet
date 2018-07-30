using IDMONEY.IO.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IDMONEY.IO.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePrincipalView : ContentPage
	{
		public HomePrincipalView ()
		{
			InitializeComponent ();

            BindingContext = HomeViewModel.GetInstance();

        }
	}
}