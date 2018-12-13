using IDMONEY.IO.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IDMONEY.IO.ViewModel
{
    public class ServerManagement
    {
        #region Singleton
        private static ServerManagement serverManagement;

        public static ServerManagement GetInstance(bool refresh = false)
        {
            if (refresh || serverManagement.IsNull())
            {
                serverManagement = new ServerManagement();
            }
            return serverManagement;
        }

        private ServerManagement()
        {
        }

        public UserModel User { get; set; }
        #endregion
    }
}
