using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace IDMONEY.IO.Model
{
    public class TransactionModel : Transaction, INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) // if there is any subscribers 
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
  
    }

    public class Transaction
    {
        public long? Id { get; set; }

        public int? BusinessId { get; set; }

        public string BusinessName { get; set; }

        public int? UserId { get; set; }

        public decimal? Amount { get; set; }

        public DateTime? RegistrationDate { get; set; }

        public DateTime? ProcessingDate { get; set; }

        public string Description { get; set; }

        public int Status { get; set; }

        public string StatusName { get; set; }
    }
}
