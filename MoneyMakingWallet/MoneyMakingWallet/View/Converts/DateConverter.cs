using System;
using System.Globalization;
using Xamarin.Forms;

namespace IDMONEY.IO.View
{
    public class DateConverter : IValueConverter
    {
        private object obj;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            obj = value;

            DateFormatString dateFormat = (DateFormatString)Enum.Parse(typeof(DateFormatString), (string)parameter);

            if (dateFormat == DateFormatString.MonthAndDay)
            {
                DateTime date = (DateTime)value;
                return $"{CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(date.Month)} {date.Day}";
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return obj;
        }
    }

    public enum DateFormatString
    {
        MonthAndDay
    }
}
