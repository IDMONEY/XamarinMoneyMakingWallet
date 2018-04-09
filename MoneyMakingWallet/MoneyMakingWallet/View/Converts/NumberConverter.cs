using IDMONEY.IO.Helper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace IDMONEY.IO.View
{
    public class NumberConverter : IValueConverter
    {
        private object obj;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            obj = value;
            EnumNumberType numberFormat = (EnumNumberType)Enum.Parse(typeof(EnumNumberType), (string)parameter);

            string numberFommatter = string.Empty;
            if (numberFormat == EnumNumberType.Amount)
            {
                if (value == null)
                {
                    numberFommatter = FormatterHelper.Format(0);
                }
                else
                {
                    numberFommatter = FormatterHelper.Format((decimal)value);
                }
            }
            else if(numberFormat == EnumNumberType.Percent)
            {
                if (value == null)
                {
                    numberFommatter = FormatterHelper.FormatPorcent(0);
                }
                else
                {
                    numberFommatter = FormatterHelper.FormatPorcent((decimal)value);
                }
            }
            else
            {
                if (value == null)
                {
                    numberFommatter = FormatterHelper.Format(0);
                }
                else
                {
                    numberFommatter = FormatterHelper.Format((decimal)value);
                }
            }

            return numberFommatter;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return obj;
        }
    }
}
