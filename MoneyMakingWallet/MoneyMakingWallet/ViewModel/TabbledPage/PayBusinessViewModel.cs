using IDMONEY.IO.Helper;
using IDMONEY.IO.Model;
using IDMONEY.IO.Service;
using System;
using System.Collections.ObjectModel;

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
        #endregion

        #region Commands

        #endregion

        #region Public Methods
        public PayBusinessViewModel()
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

        }
        #endregion
    }
}
