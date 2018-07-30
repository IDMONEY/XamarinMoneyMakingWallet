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
	public partial class PayPrincipalView : ContentPage
	{
		public PayPrincipalView ()
		{
			InitializeComponent ();

            BindingContext = PayBusinessViewModel.GetInstance(true);

        }

        private void Cell_OnTapped(object sender, EventArgs e)
        {
            var viewCell = (ViewCell)sender;
            if (viewCell.View != null)
            {
                viewCell.View.BackgroundColor = Color.White;
            }
        }
    }
}