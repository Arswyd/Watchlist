using ListLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListLibrary.ListSettings
{
    public interface ISettingsConnection
    {
        List<ListSettingsModel> GetSettings();
    }
}
