using IDMONEY.IO.Helpers;
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
            if (refresh || homeViewModel.IsNull())
            {
                homeViewModel = new HomeViewModel();
            }
            return homeViewModel;
        }

        private HomeViewModel()
        {
            initClassAsync();
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
                OnPropertyChanged(nameof(User));
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
                OnPropertyChanged(nameof(lstTransfers));
            }
        }

        #endregion

        #region Public Methods
        public async void FillDataAsync()
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
        private void initClassAsync()
        {
            FillDataAsync();
        }

        private void initCommands()
        {

        }
        #endregion
    }
}
