using IDMONEY.IO.Helper;
using IDMONEY.IO.Model;
using IDMONEY.IO.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace IDMONEY.IO.ViewModel
{
    public class EntryDataViewModel : ViewModelBase
    {
        #region Commands
        public ICommand SaveEntryDataCommand { get; private set; }
        #endregion

        #region Instances
        private ObservableCollection<DataEntryModel> _lstDataEntries;

        public ObservableCollection<DataEntryModel> lstDataEntries
        {
            get
            {
                return _lstDataEntries;
            }
            set
            {
                _lstDataEntries = value;
                OnPropertyChanged("lstDataEntries");
            }
        }

        public object SaveEntryData { get; private set; }
        #endregion

        #region Public Methods
        public EntryDataViewModel()
        {
            initClassAsync();
            initCommands();
        }
        #endregion

        #region private Methods
        private void initCommands()
        {
            SaveEntryDataCommand = new Command(SaveEntryDataAsync);
        }

        private async void SaveEntryDataAsync()
        {
            try
            {
                IsBusy = true;

                EntryDataService req = await EntryDataService.SaveEntryDataAsync(lstDataEntries);

                if (!req.IsSuccessful)
                {
                    IsBusy = false;
                    ErrorHelper.ControlError(req.Errors, false);
                    return;
                }
                IsBusy = false;

                await ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PopToRootAsync();              
            }
            catch (Exception ex)
            {
                IsBusy = false;
                ErrorHelper.ControlError(ex, false);
            }
        }

        private async void initClassAsync()
        {
            try
            {
                IsBusy = true;

                EntryDataService req = await EntryDataService.SearchEntryDataAsync();

                if (!req.IsSuccessful)
                {
                    IsBusy = false;
                    ErrorHelper.ControlError(req.Errors, false);
                    return;
                }
                lstDataEntries = req.DataEntries;

                IsBusy = false;
            }
            catch (Exception ex)
            {
                IsBusy = false;
                ErrorHelper.ControlError(ex, false);
            }
        }
        #endregion
    }
}
