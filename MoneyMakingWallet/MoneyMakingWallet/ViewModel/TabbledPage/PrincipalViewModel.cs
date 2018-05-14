using IDMONEY.IO.Model;
using IDMONEY.IO.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace IDMONEY.IO.ViewModel
{
    public class PrincipalViewModel : ViewModelBase
    {
        #region Singleton
        private static PrincipalViewModel instance = null;

        public static PrincipalViewModel GetInstance(CurrencyModel currencyModel = null)
        {
            if (instance == null || currencyModel != null)
            {
                instance = new PrincipalViewModel(currencyModel);
            }
            return instance;
        }

        public static void DeleteInstance()
        {
            if (instance != null)
            {
                instance = null;
            }
        }
        private PrincipalViewModel(CurrencyModel currencyModel)
        {
            initCommands();
            initClass(currencyModel);
        }
        #endregion

        #region Instances
        public BalanceModel Balance { get; set; }

        public string CodeQR
        {
            get { return string.Format("{0} - {1}", user.Address, Balance.CryptoAmount); }
        }

        public string MyAddress
        {
            get { return user.Address; }
        }

        private UserModel user;
        #endregion

        #region Commands
        public ICommand ChangeAmountCommand { get; private set; }
        #endregion

        #region Private Methods
        private void initCommands()
        {
            ChangeAmountCommand = new Command<string>(ChangeAmount);
        }

        private void ChangeAmount(string option)
        {

            OnPropertyChanged("CodeQR");
        }

        private void initClass(CurrencyModel currency)
        {
            user = UserRequest.GetUser();
            Balance = BalanceService.GetBalance(currency);
        }
        #endregion
    }
}
