#region Libraries
using System;
#endregion

namespace IDMONEY.IO
{
    public static class ObjectExtensions
    {
        public static bool IsNotNull(this object @object)
        {
            return IsNotNull<object>(@object);
        }

        public static bool IsNotNull<TObject>(this object @object)
        {
            return !Object.ReferenceEquals(@object, null);
        }

        public static bool IsNull(this object @object)
        {
            return IsNull<object>(@object);
        }

        public static bool IsNull<TObject>(this object @object)
        {
            return Object.ReferenceEquals(@object, null);
        }


    }
}