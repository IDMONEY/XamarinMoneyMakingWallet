using IDMONEY.IO.Helpers;
using IDMONEY.IO.Model;
using IDMONEY.IO.Service;
using System;
using System.Collections.Generic;
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
                OnPropertyChanged("User");
            }
        }
        #endregion

        #region private methods
        private async void initClassAsync()
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

                IsBusy = false;
            }
            catch (Exception ex)
            {
                IsBusy = false;
                ErrorHelper.ControlError(ex, false);
            }
        }

        private void initCommands()
        {

        }
        #endregion
    }
}
