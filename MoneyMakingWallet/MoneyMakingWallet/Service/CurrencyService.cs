using IDMONEY.IO.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace IDMONEY.IO.Service
{
    public static class CurrencyService
    {
        public static ObservableCollection<CurrencyModel> SearchCrytoCurrenciesByUser()
        {
            return new ObservableCollection<CurrencyModel>(new[]
            {
                    new CurrencyModel { Name = "IdMoney", Code="iDM", Symbol="iDM",Image="icon.png" },
                    new CurrencyModel { Name = "Ethereum", Code="ETH", Symbol="ETH",Image="ethereum.png" }
                });
        }

        public static CurrencyModel GetConfigCurrency()
        {
            return new CurrencyModel() { Code = "USD", Name = "Dollar",Symbol="$"};
        }
    }
}
