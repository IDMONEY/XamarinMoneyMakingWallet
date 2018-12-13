

using IDMONEY.IO.Helpers;
using IDMONEY.IO.Model;
using IDMONEY.IO.Service;
using IDMONEY.IO.View;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace IDMONEY.IO.ViewModel
{
    public class PayBusinessViewModel : ViewModelBase
    {
        #region Instances

        private ObservableCollection<BusinessModel> _lstBusiness = new ObservableCollection<BusinessModel>();

        public ObservableCollection<BusinessModel> lstBusiness
        {
            get
            {
                return _lstBusiness;
            }
            set
            {
                if (_lstBusiness != value)
                {
                    _lstBusiness = value;
                    OnPropertyChanged(nameof(lstBusiness));
                }
            }
        }

        private BusinessModel _business;

        public BusinessModel Business
        {
            get
            {
                return _business;
            }
            set
            {
                if (_business != value)
                {
                    _business = value;
                    OnPropertyChanged(nameof(Business));
                }
            }
        }
        private TransactionModel _Transaction;

        public TransactionModel Transaction
        {
            get
            {
                return _Transaction;
            }
            set
            {
                if (_Transaction != value)
                {
                    _Transaction = value;
                    OnPropertyChanged(nameof(Transaction));
                }
            }
        }

        private bool _IsTransferValid;

        public bool IsTransferValid
        {
            get
            {
                return _IsTransferValid;
            }
            set
            {
                if (_IsTransferValid != value)
                {
                    _IsTransferValid = value;
                    OnPropertyChanged(nameof(IsTransferValid));
                }
            }
        }
        
        #endregion

        #region Commands
        public ICommand ChooseBusinessCommand { get; private set; }

        public ICommand SendTransferCommand { get; private set; }

        public ICommand ValidateTransferCommand { get; private set; }
        #endregion

        #region Singleton
        private static PayBusinessViewModel businessViewModel;

        public static PayBusinessViewModel GetInstance(bool refresh = false)
        {
            if (refresh || businessViewModel.IsNull())
            {
                businessViewModel = new PayBusinessViewModel();
            }
            return businessViewModel;
        }

        private PayBusinessViewModel()
        {
            InitClass();
            InitCommands();
        }
        #endregion

        #region Private Methods
        protected override async void InitClass()
        {
            try
            {
                IsBusy = true;

                BusinessService req = await BusinessService.BusinessListAsync();

                if (!req.IsSuccessful)
                {
                    IsBusy = false;
                    ErrorHelper.ControlError(req.Errors, false);
                    return;
                }
                lstBusiness = req.Businesses;

                IsBusy = false;
            }
            catch (Exception ex)
            {
                IsBusy = false;
                ErrorHelper.ControlError(ex, false);
            }
        }

        protected override void InitCommands()
        {
            ChooseBusinessCommand = new Command<BusinessModel>(ChooseBusiness);
            SendTransferCommand = new Command(SendTransferAsync);
            ValidateTransferCommand = new Command(ValidateTransfer);
        }

        private void ValidateTransfer()
        {
            IsTransferValid = Transaction.Amount > 0;
        }

        private async void SendTransferAsync()
        {
            try
            {
                IsBusy = true;

                TransactionService req = await TransactionService.InsertTrasactionAsync(Transaction);

                if (!req.IsSuccessful)
                {
                    IsBusy = false;
                    ErrorHelper.ControlError(req.Errors, false);
                    return;
                }
                else
                {
                    HomeViewModel.GetInstance().FillDataAsync();
                    base.PopToRoot();
                }
                IsBusy = false;
            }
            catch (Exception ex)
            {
                IsBusy = false;
                ErrorHelper.ControlError(ex);
            }
        }

        private void ChooseBusiness(BusinessModel business)
        {
            try
            {
                Transaction = new TransactionModel()
                {
                    ToAccountId = business.Account.Id,
                    FromAccountId = ServerManagement.GetInstance().User.Account.Id
                };
                Business = business;
                ValidateTransfer();
                AddPage(new SendTransferView());
            }
            catch (Exception ex)
            {
                ErrorHelper.ControlError(ex);
            }
        }

        #endregion
    }
}
