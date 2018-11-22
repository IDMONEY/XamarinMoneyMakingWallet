using System.ComponentModel;
using Xamarin.Forms;

namespace IDMONEY.IO.ViewModel
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged.IsNotNull()) // if there is any subscribers 
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Instances
        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                if(_isBusy != value)
                {
                    _isBusy = value;
                    OnPropertyChanged(nameof(IsBusy));
                }
            }
        }
        #endregion

        protected abstract void InitClass();

        protected abstract void InitCommands();

        #region Public Methods
        protected void AddPage(Page page, bool clearStack = false)
        {
            INavigation navigation = ((MasterDetailPage)App.Current.MainPage).Detail.Navigation;

            if (navigation.NavigationStack.Count > 1 && clearStack)
            {
                int pops = 0;
                int count = navigation.NavigationStack.Count - 1;

                while (count > pops)
                {
                    navigation.RemovePage(
                        navigation.NavigationStack[navigation.NavigationStack.Count - 1]);
                    count--;
                }
            }

            navigation.PushAsync(page);
        }

        internal void PopToRoot()
        {
            INavigation navigation = ((MasterDetailPage)App.Current.MainPage).Detail.Navigation;
            navigation.PopToRootAsync();
        }
        #endregion
    }
}