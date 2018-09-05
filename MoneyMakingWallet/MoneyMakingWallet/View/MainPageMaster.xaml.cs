using IDMONEY.IO.Helpers;
using IDMONEY.IO.Service;
using IDMONEY.IO.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IDMONEY.IO.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPageMaster : ContentPage
    {
        public MainPageMaster()
        {
            InitializeComponent();

            BindingContext = new MainPageMasterViewModel();
        }

        private void btnOverview_Tapped(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                ErrorHelper.ControlError(ex, false);
            }
        }

        private void addPage(Page page)
        {
            MasterDetailPage masterDetailPage = (MasterDetailPage)App.Current.MainPage;
            if (masterDetailPage.Detail.Navigation.NavigationStack.Count > 1)
            {
                int pops = 0;
                int count = masterDetailPage.Detail.Navigation.NavigationStack.Count - 1;

                while (count > pops)
                {
                    masterDetailPage.Detail.Navigation.RemovePage(
                        masterDetailPage.Detail.Navigation.NavigationStack[masterDetailPage.Detail.Navigation.NavigationStack.Count - 1]);
                    count--;
                }
            }

            masterDetailPage.IsPresented = false;

            masterDetailPage.Detail.Navigation.PushAsync(page);
        }

        private void Logout_Clicked(object sender, EventArgs e)
        {
            try
            {
                UserService.DeleteUser();
                App.Current.MainPage = new LoginView();
            }
            catch (Exception ex)
            {
                ErrorHelper.ControlError(ex, false);
            }
        }
    }
}