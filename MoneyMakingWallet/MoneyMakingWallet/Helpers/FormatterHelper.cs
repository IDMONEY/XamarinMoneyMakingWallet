#region Libraries
using System;
using System.Collections.Generic;
using System.Text; 
#endregion

namespace IDMONEY.IO.Helpers
{
    public static class FormatterHelper
    {
        public static string Format(decimal value)
        {
            return value.ToString("N2");
        }

        public static string FormatPorcent(decimal value)
        {
            value = value / 100;
            return value.ToString("0.00%");
        }
    }
}
