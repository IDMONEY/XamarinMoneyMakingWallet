using Newtonsoft.Json;
using Realms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace IDMONEY.IO.Model
{
    public class UserModel : RealmObject, INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) // if there is any subscribers 
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
                OnPropertyChanged("AvailableBalance");
            }
        }

        [Ignored]
        public decimal BlockedBalance { get; set; }
    }
}
