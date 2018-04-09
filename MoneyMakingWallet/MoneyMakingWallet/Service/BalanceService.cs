using IDMONEY.IO.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace IDMONEY.IO.Service
{
    public class BalanceService
    {
        public static ObservableCollection<BalanceModel> SearchBalanceByUser()
        {
            ObservableCollection<BalanceModel> balances = new ObservableCollection<BalanceModel>();

            ObservableCollection<CurrencyModel> currencies = CurrencyService.SearchCrytoCurrenciesByUser();

            foreach (CurrencyModel currency in currencies)
            {
                balances.Add(GetBalance(currency));
            }

            return balances;
        }

        public static BalanceModel GetBalance(CurrencyModel cryptoCurrency)
        {
            if (cryptoCurrency.Code == "BTC")
            {
                return  new BalanceModel() { Amount = 0, CryptoAmount = 0, CryptoCurrency = cryptoCurrency, Currency = CurrencyService.GetConfigCurrency(), ExchangeRate = 7038.75m };
            }
            else if (cryptoCurrency.Code == "ETH")
            {
                return new BalanceModel() { Amount = 0, CryptoAmount = 0, CryptoCurrency = cryptoCurrency, Currency = CurrencyService.GetConfigCurrency(), ExchangeRate = 391.26m };
            }
            else
            {
                return new BalanceModel() { Amount = 0, CryptoAmount = 0, CryptoCurrency = cryptoCurrency, Currency = CurrencyService.GetConfigCurrency(), ExchangeRate = 0.2945m };
            }
        }
    }
}
