using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace IDMONEY.IO.Model
{
    public class DataEntryModel : DataEntry, INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) // if there is any subscribers 
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        public new string Value
        {
            get
            { return base.Value; }
            set
            {
                base.Value = value;
                OnPropertyChanged("Value");
            }
        }
    }

    public class DataEntry
    {
        public int SettingId { get; set; }

        public string Code { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }

        public string Value { get; set; }
    }
}
