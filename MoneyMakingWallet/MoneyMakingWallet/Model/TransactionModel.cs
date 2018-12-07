using System.ComponentModel;

namespace IDMONEY.IO.Service
{
    public class TransactionModel : Transaction, INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged.IsNotNull()) // if there is any subscribers 
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
  
    }

    public class Transaction
    {
        public decimal? Amount { get; set; }

        public string Description { get; set; }

        public long FromAccountId { get; set; }

        public long ToAccountId { get; set; }

    }
}
