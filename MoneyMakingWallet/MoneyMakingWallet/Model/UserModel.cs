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

        [Ignored]
        public AccountModel Account { get; set; }

        [Ignored]
        public string Password { get; set; }

        public string Token { get; set; }
    }
}