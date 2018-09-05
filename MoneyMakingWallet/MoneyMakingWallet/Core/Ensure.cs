#region Libraries
using System;
using System.Diagnostics;
#endregion

namespace IDMONEY.IO
{
    public static class Ensure
    {
        [DebuggerStepThrough]
        public static void IsNotNullOrEmpty(string parameter)
        {
            if (String.IsNullOrWhiteSpace(parameter))
            {
                throw new ArgumentException(String.Format("{0} cannot be null or empty", nameof(parameter)));
            }
        }

        [DebuggerStepThrough]
        public static void IsNotNegativeOrZero(long parameter)
        {
            if (parameter <= 0)
            {
                throw new ArgumentException(String.Format("{0} cannot be negative or equals to zero", nameof(parameter)));
            }
        }

        [DebuggerStepThrough]
        public static void IsNotNegative(long parameter)
        {
            if (parameter < 0)
            {
                throw new ArgumentException(String.Format("{0} cannot be negative", nameof(parameter)));
            }
        }

    }
}