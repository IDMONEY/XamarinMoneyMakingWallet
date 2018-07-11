using IDMONEY.IO.Helper;
using IDMONEY.IO.Model;
using IDMONEY.IO.Service;
using IDMONEY.IO.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace IDMONEY.IO.ViewModel
{
    public class MainPageDetailViewModel : ViewModelBase
    {
        #region Instances
        public CurrencyModel Currency { get; set; }

        public decimal Amount { get; set; }
        public ObservableCollection<BalanceModel> lstBalances { get; set; }
        #endregion

        #region Commands
        public ICommand ToolbarTappedCommand { get; private set; }
        #endregion

        #region Public Methods
        public MainPageDetailViewModel()
        {
            initCommands();
            initClass();
        }
        #endregion

        #region Private Methods
        private void initCommands()
        {
            ToolbarTappedCommand = new Command<string>(ToolbarTappedAsync);
        }

        private async void ToolbarTappedAsync(string option)
        {
            try
            {
                switch (option)
                {
                    case "Logout":
                        UserService.DeleteUser();
                        App.Current.MainPage = new LoginView();
                        break;
                    case "DataEntry":
                        IsBusy = true;

                        Page page = null;

                        await Task.Run(() =>
                        {
                            page = new EntryDataView();
                        });

                        await ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PushAsync(page);

                        IsBusy = false;
                        break;
                }
            }
            catch (Exception ex)
            {

                ErrorHelper.ControlError(ex, false);
            }
        }

        private void initClass()
        {
            Currency = CurrencyService.GetConfigCurrency();
            lstBalances = BalanceService.SearchBalanceByUser();
        }
        #endregion
    }
}
