using IDMONEY.IO.Model;
using IDMONEY.IO.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

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

        }

        private void initClass()
        {
            Currency = CurrencyService.GetConfigCurrency();
            lstBalances = BalanceService.SearchBalanceByUser();
        }
        #endregion
    }
}
