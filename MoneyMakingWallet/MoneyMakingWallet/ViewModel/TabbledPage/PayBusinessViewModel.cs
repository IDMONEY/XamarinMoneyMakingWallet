

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
                _lstBusiness = value;
                OnPropertyChanged("lstBusiness");
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
                _business = value;
                OnPropertyChanged("Business");
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
                _Transaction = value;
                OnPropertyChanged("Transaction");
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
                _IsTransferValid = value;
                OnPropertyChanged("IsTransferValid");
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
            if (refresh || businessViewModel == null)
            {
                businessViewModel = new PayBusinessViewModel();
            }
            return businessViewModel;
        }

        private PayBusinessViewModel()
        {
            initClass();
            initCommands();
        }
        #endregion

        #region Private Methods
        private async void initClass()
        {
            try
            {
                IsBusy = true;

                BusinessService req = await BusinessService.SearchBusinessAsync();

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

        private void initCommands()
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
                    BusinessId = business.Id,
                    BusinessName = business.Name
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
