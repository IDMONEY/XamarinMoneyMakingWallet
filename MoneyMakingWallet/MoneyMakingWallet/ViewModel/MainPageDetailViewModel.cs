using IDMONEY.IO.Helper;
using IDMONEY.IO.Model;
using IDMONEY.IO.Service;
using IDMONEY.IO.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
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
            ToolbarTappedCommand = new Command<string>(ToolbarTapped);
        }

        private void ToolbarTapped(string option)
        {
            try
            {
                switch (option)
                {
                    case "Logout":
                        UserRequest.DeleteUser();
                        App.Current.MainPage = new LoginView();
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
