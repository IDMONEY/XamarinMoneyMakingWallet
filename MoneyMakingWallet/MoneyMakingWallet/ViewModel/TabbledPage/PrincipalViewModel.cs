using IDMONEY.IO.Model;
using IDMONEY.IO.Service;
using System;
using System.Collections.Generic;
using System.Text;

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
            get { return "0x46 ed94 c49a b4ab 05743 dea4 655b e90d d23a 4000e"; }
        }
        #endregion

        #region Commands

        #endregion

        #region Private Methods
        private void initCommands()
        {

        }

        private void initClass(CurrencyModel currency)
        {
            Balance = BalanceService.GetBalance(currency); 
        }
        #endregion
    }
}
