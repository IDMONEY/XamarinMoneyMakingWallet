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
    }
}