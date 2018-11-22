using IDMONEY.IO.Helpers;
using IDMONEY.IO.Model;
using IDMONEY.IO.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

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
            InitClass();
            InitCommands();
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
                if (_user != value)
                {
                    _user = value;
                    OnPropertyChanged(nameof(User));
                }
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
                if (_lstTransfers != value)
                {
                    _lstTransfers = value;
                    OnPropertyChanged(nameof(lstTransfers));
                }
            }
        }

        #endregion

        #region Public Methods
        public async void FillDataAsync()
        {
            try
            {
                IsBusy = true;

                List<Error> errors = new List<Error>();
                await Task.WhenAll(
                    Task.Run(() =>
                    {
                        GetUserService req = GetUserService.GetUser();

                        if (!req.IsSuccessful)
                        {
                            lock (errors)
                            {
                                errors.AddRange(req.Errors);
                            }
                            return;
                        }
                        User = req.User;
                    }),
                    Task.Run(() =>
                    {
                        TransactionService req = TransactionService.SearchTransaction();
                        if (!req.IsSuccessful)
                        {
                            lock (errors)
                            {
                                errors.AddRange(req.Errors);
                            }
                            return;
                        }
                        lstTransfers = req.Transactions;
                    }));

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

        protected override void InitClass()
        {
            FillDataAsync();
        }

        protected override void InitCommands()
        {
        }
        #endregion
    }
}
