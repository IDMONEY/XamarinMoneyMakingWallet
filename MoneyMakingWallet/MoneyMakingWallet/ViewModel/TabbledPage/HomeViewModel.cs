using IDMONEY.IO.Helper;
using IDMONEY.IO.Model;
using IDMONEY.IO.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace IDMONEY.IO.ViewModel
{
    public class HomeViewModel : ViewModelBase
    {
        #region Singleton
        private static HomeViewModel homeViewModel;

        public static HomeViewModel GetInstance(bool refresh = false)
        {
            if (refresh || homeViewModel == null)
            {
                homeViewModel = new HomeViewModel();
            }
            return homeViewModel;
        }

        private HomeViewModel()
        {
            initClass();
            initCommands();
        }
        #endregion

        #region Commands

        #endregion

        #region Instances
        private UserModel _user;

        public UserModel User
        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;
                OnPropertyChanged("User");
            }
        }

        private ObservableCollection<TransactionModel> _lstTransfers;

        public ObservableCollection<TransactionModel> lstTransfers
        {
            get
            {
                return _lstTransfers;
            }
            set
            {
                _lstTransfers = value;
                OnPropertyChanged("lstTransfers");
            }
        }

        #endregion

        #region Public Methods
        public async void FillData()
        {
            try
            {
                IsBusy = true;

                GetUserService req = await GetUserService.GetUser();

                if (!req.IsSuccessful)
                {
                    IsBusy = false;
                    ErrorHelper.ControlError(req.Errors, false);
                    return;
                }
                User = req.User;

                TransactionService transactionService = await TransactionService.SearchTransaction();
                if (!transactionService.IsSuccessful)
                {
                    IsBusy = false;
                    ErrorHelper.ControlError(req.Errors, false);
                    return;
                }
                lstTransfers = transactionService.Transactions;

                IsBusy = false;
            }
            catch (Exception ex)
            {
                IsBusy = false;
                ErrorHelper.ControlError(ex, false);
            }
        }
        #endregion

        #region private methods
        private void initClass()
        {
            FillData();
        }

        private void initCommands()
        {

        }
        #endregion
    }
}
