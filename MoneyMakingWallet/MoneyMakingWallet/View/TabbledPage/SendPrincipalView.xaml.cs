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
    public partial class SendPrincipalView : ContentPage
    {
        public SendPrincipalView()
        {
            InitializeComponent();

            BindingContext = PrincipalViewModel.GetInstance();
        }


        private void AdvanceSettings_Clicked(object sender, ClickedEventArgs e)
        {
            pnlAdvanceSettings.IsVisible = !pnlAdvanceSettings.IsVisible;
        }
    }
}