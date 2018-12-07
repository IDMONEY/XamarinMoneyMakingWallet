using System;
using System.Globalization;
using System.IO;
using Xamarin.Forms;

namespace IDMONEY.IO.View
{
    public class Base64Converter : IValueConverter
    {
        private object obj;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            obj = value;

            if (value.IsNotNull())
            {
                try
                {
                    byte[] Base64Stream = System.Convert.FromBase64String(value.ToString());
                    return ImageSource.FromStream(() => new MemoryStream(Base64Stream));
                }
                catch (Exception) { }
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return obj;
        }
    }
}
