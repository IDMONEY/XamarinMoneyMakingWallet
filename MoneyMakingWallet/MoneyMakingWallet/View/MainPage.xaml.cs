using IDMONEY.IO.Model;
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
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;

            TapGestureRecognizer tap = new TapGestureRecognizer();
            tap.Tapped += Overview_Tapped;
            MasterPage.Overview.GestureRecognizers.Add(tap);
        }

        private void Overview_Tapped(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new MainPageDetail());
            IsPresented = false;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as CurrencyModel;
            if (item == null)
                return;

            var page = new TabbledPrincipalView(item);
            page.Title = item.Name;

            Detail = new NavigationPage(page);
            IsPresented = false;

            MasterPage.ListView.SelectedItem = null;
        }
    }
}