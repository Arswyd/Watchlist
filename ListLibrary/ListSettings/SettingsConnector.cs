using ListLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListLibrary.ListSettings
{
    public class SettingsConnector: ISettingsConnection
    {
        private const string SettingsFile = "ListSettings.csv";

        public List<ListSettingsModel> GetSettings()
        {
            return SettingsFile.SettingsFilePath().LoadSettingsFile().ConvertToSettingsModel();
        }
    }
}
