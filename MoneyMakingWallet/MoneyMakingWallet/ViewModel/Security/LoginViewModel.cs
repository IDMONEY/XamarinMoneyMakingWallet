using IDMONEY.IO.Helper;
using IDMONEY.IO.Model;
using IDMONEY.IO.Service;
using IDMONEY.IO.View;
using IDMONEY.IO.View.Security;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace IDMONEY.IO.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        #region Intances
        private string _email { get; set; }
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged("Email");
            }
        }

        private string _password { get; set; }
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }

        private bool _isValidUser;
        public bool IsValidUser
        {
            get { return _isValidUser; }
            set
            {
                _isValidUser = value;
                OnPropertyChanged("IsValidUser");
            }
        }
        #endregion

        #region Commands

        public ICommand ValidateUserCommand { get; private set; }

        public ICommand GoToForgotPasswordCommand { get; private set; }

        public ICommand GoToRegisterUserCommand { get; private set; }

        public ICommand AuthenticateCommand { get; private set; }

        #endregion

        #region Public Methods
        public LoginViewModel()
        {
            initClass();
            initCommands();
        }
        #endregion
        #region Private Methods
        private void initClass()
        {

        }

        private void initCommands()
        {
            ValidateUserCommand = new Command(ValidateUser);
            GoToForgotPasswordCommand = new Command(GoToForgotPassword);
            GoToRegisterUserCommand = new Command(GoToRegisterUser);
            AuthenticateCommand = new Command(AuthenticateAsync);
        }

        private async void AuthenticateAsync()
        {
            try
            {
                IsBusy = true;

                LoginService req = await LoginService.LoginUser(Email, Password);

                if (!req.IsSuccessful)
                {
                    IsBusy = false;
                    ErrorHelper.ControlError(req.Errors, false);
                    return;
                }
                else
                {
                    UserService.SaveUser(req.User, req.Token);
                    App.Current.MainPage = new MainPage();
                    IsBusy = false;
                }
            }
            catch (Exception ex)
            {
                IsBusy = false;
                ErrorHelper.ControlError(ex, false);
            }
        }

        private void GoToRegisterUser()
        {
            App.Current.MainPage = new RegisterUserView();
        }

        private void GoToForgotPassword()
        {
            App.Current.MainPage = new ForgotPasswordView();
        }

        private void ValidateUser()
        {
            IsValidUser = !string.IsNullOrEmpty(Email) && ValidationHelper.IsValidEmail(Email) &&
                                   !string.IsNullOrEmpty(Password);// && ValidationHelper.IsValidPassword(Password);
        }
        #endregion
    }
}
