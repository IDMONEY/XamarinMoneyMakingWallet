using System;
using System.Collections.Generic;
using System.Text;

namespace IDMONEY.IO.Model
{
    public class BalanceModel
    {
        public CurrencyModel Currency { get; set; }

        public decimal? Amount { get; set; }

        public decimal? ExchangeRate { get; set; }

        public CurrencyModel CryptoCurrency { get; set; }

        public decimal? CryptoAmount { get; set; }
    }
}
