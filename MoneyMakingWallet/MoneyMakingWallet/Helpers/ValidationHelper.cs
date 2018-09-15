#region Libraries
using System;
using System.Text.RegularExpressions; 
#endregion

namespace IDMONEY.IO.Helpers
{
    public static class ValidationHelper
    {
        #region Constants
        private const int MAX_TIMEOUT_REGEX = 250;
        #endregion

        public static bool IsValidEmail(string email)
        {
            bool valid = true;
            if (email.IsNotNullOrEmpty())
            {
                Regex rx = new Regex(@"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                          @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(MAX_TIMEOUT_REGEX));

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
            if (password.IsNotNullOrEmpty())
            {
                Regex rx = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(MAX_TIMEOUT_REGEX));

                if (!rx.IsMatch(password))
                {
                    valid = false;
                }
            }
            return valid;
        }
    }
}
