﻿using IDMONEY.IO.Helpers;
using IDMONEY.IO.Service;
using IDMONEY.IO.View;
using System;
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
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
        }

        private string _password { get; set; }
        public string Password
        {
            get { return _password; }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged(nameof(Password));
                }
            }
        }

        private string _confirmPassword { get; set; }
        public string ConfirmPassword
        {
            get { return _confirmPassword; }
            set
            {
                if (_confirmPassword != value)
                {
                    _confirmPassword = value;
                    OnPropertyChanged(nameof(ConfirmPassword));
                }
            }
        }

        private bool _isValidUser;
        public bool IsValidUser
        {
            get { return _isValidUser; }
            set
            {
                if (_isValidUser != value)
                {
                    _isValidUser = value;
                    OnPropertyChanged(nameof(IsValidUser));
                }
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
            InitClass();
            InitCommands();
        }
        #endregion

        #region Private Methods
        protected override void InitClass()
        {

        }

        protected override void InitCommands()
        {
            RegisterUserCommand = new Command(RegisterUserAsync);
            ValidateUserCommand = new Command(ValidateUser);
        }

        private async void RegisterUserAsync()
        {
            try
            {
                IsBusy = true;

                CreateUserService req = await CreateUserService.CreateUserAsync(Email, Password);

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

        private void ValidateUser()
        {
            IsValidUser = !string.IsNullOrEmpty(Email) && ValidationHelper.IsValidEmail(Email) &&
                                  !string.IsNullOrEmpty(Password) && ValidationHelper.IsValidPassword(Password) &&
                                  !string.IsNullOrEmpty(ConfirmPassword) && Password == ConfirmPassword;
        }
        #endregion
    }
}
