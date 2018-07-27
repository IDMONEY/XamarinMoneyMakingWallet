using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace IDMONEY.IO.Helper
{
    public class ValidationHelper
    {
        public static bool IsValidEmail(string email)
        {
            bool valid = true;
            if (!string.IsNullOrEmpty(email))
            {
                Regex rx = new Regex(@"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                          @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));

                if (!rx.IsMatch(email))
                {
                    valid = false;
                }
            }
            return valid;
        }

        public static bool IsValidPassword(string password)
        {
            bool valid = true;
            if (!string.IsNullOrEmpty(password))
            {
                Regex rx = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));

                if (!rx.IsMatch(password))
                {
                    valid = false;
                }
            }
            return valid;
        }
    }
}
