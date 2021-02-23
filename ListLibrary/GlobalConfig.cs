using ListLibrary.DataAccess;
using ListLibrary.ListSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListLibrary
{
    public static class GlobalConfig
    {
        public static IDataConnection Connection { get; private set; }

        public static void InitializeConnections(bool textfile)
        {
            if (textfile == true)
            {
                TextConnector text = new TextConnector();
                Connection = text;
            }
        }

        public static ISettingsConnection SettingsConnection { get; private set; }
        public static void InitializeSettings()
        {
                SettingsConnection = new SettingsConnector();
        }
    }
}
