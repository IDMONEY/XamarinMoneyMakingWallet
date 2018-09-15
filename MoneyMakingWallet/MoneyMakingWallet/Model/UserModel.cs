using Realms;
using System.ComponentModel;

namespace IDMONEY.IO.Model
{
    public class UserModel : RealmObject, INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Implementation
        new public event PropertyChangedEventHandler PropertyChanged;
        protected override void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged.IsNotNull()) // if there is any subscribers 
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        [PrimaryKey]
        public long Id { get; set; }

        public string Email { get; set; }

        public string Token { get; set; }

        [Ignored]
        public string Address { get; set; }

        [Ignored]
        public string Privatekey { get; set; }

        [Ignored]
        private decimal _availableBalance { get; set; }

        [Ignored]
        public decimal AvailableBalance
        {
            get { return _availableBalance; }
            set
            {
                _availableBalance = value;
                OnPropertyChanged(nameof(AvailableBalance));
            }
        }

        [Ignored]
        public decimal BlockedBalance { get; set; }
    }
}