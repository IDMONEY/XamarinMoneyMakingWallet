#region Libraries
using IDMONEY.IO.Helpers;
using System;
using System.Globalization;
using Xamarin.Forms; 
#endregion

namespace IDMONEY.IO.View
{
    public class NumberConverter : IValueConverter
    {
        #region Constants
        private const int DEFAULT_VALUE = 0;
        #endregion

        private object obj;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            obj = value;
            EnumNumberType numberFormat = (EnumNumberType)Enum.Parse(typeof(EnumNumberType), (string)parameter);

            if (numberFormat == EnumNumberType.Percent)
            {
                return value.IsNull() ? FormatPercentage(DEFAULT_VALUE) : FormatPercentage(value);

            }
            else
            {
                return value.IsNull() ? FormatAmount(DEFAULT_VALUE) : FormatAmount(value);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return obj;
        }

        #region Private Methods
        private string FormatAmount(object value) => FormatterHelper.Format(System.Convert.ToDecimal(value));
        private string FormatPercentage(object value) => FormatterHelper.FormatPercentage(System.Convert.ToDecimal(value)); 
        #endregion
    }
}
