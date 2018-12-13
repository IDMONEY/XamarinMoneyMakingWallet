using System;
using System.Globalization;
using Xamarin.Forms;

namespace IDMONEY.IO.View
{
    public class IsSmallerThanConverter : IValueConverter
    {
        private object obj;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            obj = value;

            if (value.IsNotNull() && parameter.IsNotNull())
            {
                return System.Convert.ToDecimal(value) < System.Convert.ToDecimal(parameter);
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return obj;
        }
    }
}
