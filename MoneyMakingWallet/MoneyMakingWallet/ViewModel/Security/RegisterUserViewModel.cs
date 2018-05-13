using IDMONEY.IO.Helper;
using IDMONEY.IO.Model;
using IDMONEY.IO.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace IDMONEY.IO.ViewModel
{
    public class RegisterUserViewModel : ViewModelBase
    {
        #region Instances
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

        private string _confirmPassword { get; set; }
        public string ConfirmPassword
        {
            get { return _confirmPassword; }
            set
            {
                _confirmPassword = value;
                OnPropertyChanged("ConfirmPassword");
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

        public ICommand RegisterUserCommand { get; private set; }
        #endregion

        #region Public Methods
        public RegisterUserViewModel()
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
            RegisterUserCommand = new Command(RegisterUserAsync);
            ValidateUserCommand = new Command(ValidateUser);
        }

        private async void RegisterUserAsync()
        {
            try
            {
                IsBusy = true;

                CreateUserRequest req = await CreateUserRequest.CreateUser(Email, Password);

                if (!req.IsSuccessful)
                {
                    IsBusy = false;
                    ErrorHelper.ControlError(req.Errors, false);
                    return;
                }
                else
                {
                    UserRequest.SaveUser(req.User, req.Token);
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

        private void ValidateUser()
        {
            IsValidUser = !string.IsNullOrEmpty(Email) && ValidationHelper.IsValidEmail(Email) &&
                                  !string.IsNullOrEmpty(Password) && ValidationHelper.IsValidPassword(Password) &&
                                  !string.IsNullOrEmpty(ConfirmPassword) && Password == ConfirmPassword;
        }
        #endregion
    }
}
