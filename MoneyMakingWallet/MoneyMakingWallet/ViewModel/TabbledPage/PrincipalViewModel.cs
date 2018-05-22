using IDMONEY.IO.Helper;
using IDMONEY.IO.Model;
using IDMONEY.IO.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

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
        public BalanceModel PrincipalBalance { get; set; }

        public BalanceModel SendBalance { get; set; }

        public BalanceModel ReceiveBalance { get; set; }

        public string CodeQR
        {
            get
            {
                return JsonConvert.SerializeObject(new
                {
                    Ethereum = user.Address,
                    Amount = ReceiveBalance.CryptoAmount
                }).ToString();
            }
        }

        private string _addressToSend;
        public string AddressToSend
        {
            get
            {
                return _addressToSend;
            }
            set
            {
                _addressToSend = value;
                OnPropertyChanged("AddressToSend");
            }
        }
        
        public string MyAddress
        {
            get { return user.Address; }
        }

        private UserModel user;
        #endregion

        #region Commands
        public ICommand ReceiveChangeAmountCommand { get; private set; }

        public ICommand SendChangeAmountCommand { get; private set; }

        public ICommand ScanCodeQRCommand { get; private set; }
        #endregion

        #region Private Methods
        private void initCommands()
        {
            ReceiveChangeAmountCommand = new Command<string>(ReceiveChangeAmount);
            SendChangeAmountCommand = new Command<string>(SendChangeAmount);
            ScanCodeQRCommand = new Command(ScanCodeQRAsync);
        }

        private async void ScanCodeQRAsync()
        {
            try
            {
                var scanPage = new ZXingScannerPage();

                scanPage.OnScanResult += (result) =>
                {
                    // Stop scanning
                    scanPage.IsScanning = false;

                    // Pop the page and show the result
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        await ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PopAsync();
                        dynamic dynamic = JsonConvert.DeserializeObject<dynamic>(result.Text);
                        AddressToSend = dynamic.Ethereum;
                        SendBalance.CryptoAmount = dynamic.Amount;

                        SendChangeAmount("CryptoCurrency");
                    });
                };

                // Navigate to our scanner page
                await ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PushAsync(scanPage);
            }
            catch (Exception ex)
            {
                ErrorHelper.ControlError(ex);
            }
        }

        private void ReceiveChangeAmount(string option)
        {
            if (option == "CryptoCurrency")
            {
                ReceiveBalance.Amount = ReceiveBalance.CryptoAmount * ReceiveBalance.ExchangeRate;
            }
            else
            {
                ReceiveBalance.CryptoAmount = ReceiveBalance.Amount / ReceiveBalance.ExchangeRate;
            }
            OnPropertyChanged("CodeQR");
        }

        private void SendChangeAmount(string option)
        {
            if (option == "CryptoCurrency")
            {
                SendBalance.Amount = SendBalance.CryptoAmount * SendBalance.ExchangeRate;
            }
            else
            {
                SendBalance.CryptoAmount = SendBalance.Amount / SendBalance.ExchangeRate;
            }
            OnPropertyChanged("CodeQR");
        }

        private void initClass(CurrencyModel currency)
        {
            user = UserService.GetUser();
            PrincipalBalance = BalanceService.GetBalance(currency);

            ReceiveBalance = new BalanceModel()
            {
                CryptoCurrency = PrincipalBalance.CryptoCurrency,
                Currency = PrincipalBalance.Currency,
                ExchangeRate = PrincipalBalance.ExchangeRate
            };

            SendBalance = new BalanceModel()
            {
                CryptoCurrency = PrincipalBalance.CryptoCurrency,
                Currency = PrincipalBalance.Currency,
                ExchangeRate = PrincipalBalance.ExchangeRate
            };
        }
        #endregion
    }
}
