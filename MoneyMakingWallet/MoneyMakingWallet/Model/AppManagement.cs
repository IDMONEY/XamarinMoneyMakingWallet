using Realms;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace IDMONEY.IO.Model
{
    public static class AppManagement
    {
        #region App Colors

        //General Colors
        public static Xamarin.Forms.Color General_ColorError = (Xamarin.Forms.Color)Application.Current.Resources["General_ColorError"];
        public static Xamarin.Forms.Color General_DefaultColor = (Xamarin.Forms.Color)Application.Current.Resources["General_DefaultColor"];

        #endregion

        #region Realm
        public static RealmConfiguration RealmConfigurationUser = new RealmConfiguration()
        {
            SchemaVersion = 1,
            MigrationCallback = (migration, oldSchemaVersion) =>
            {
            }
        };
        #endregion
    }
}
