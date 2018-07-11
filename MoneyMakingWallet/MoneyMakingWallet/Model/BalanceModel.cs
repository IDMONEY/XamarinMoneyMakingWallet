using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace IDMONEY.IO.Model
{
    public class BalanceModel : Balance, INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) // if there is any subscribers 
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        public new decimal? Amount
        {
            get
            {
                return base.Amount;
            }
            set
            {
                base.Amount = value;
                OnPropertyChanged("Amount");
            }
        }

        public new decimal? CryptoAmount
        {
            get
            {
                return base.CryptoAmount;
            }
            set
            {
                base.CryptoAmount = value;
                OnPropertyChanged("CryptoAmount");
            }
        }
    }

    public class Balance
    {
        public CurrencyModel Currency { get; set; }

        public decimal? Amount { get; set; }

        public decimal? ExchangeRate { get; set; }

        public CurrencyModel CryptoCurrency { get; set; }

        public decimal? CryptoAmount { get; set; }
    }
}
