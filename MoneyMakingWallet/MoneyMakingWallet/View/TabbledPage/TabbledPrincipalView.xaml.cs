using IDMONEY.IO.Model;
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
	public partial class TabbledPrincipalView : TabbedPage
	{
		public TabbledPrincipalView (CurrencyModel currencyModel)
		{
            BindingContext = PrincipalViewModel.GetInstance(currencyModel);

            InitializeComponent ();     
        }
	}
}