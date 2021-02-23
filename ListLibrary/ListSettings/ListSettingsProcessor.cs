using ListLibrary.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListLibrary.ListSettings
{
    public static class ListSettingsProcessor
    {
        public static string SettingsFilePath(this string fileName)
        {
            return $"{ConfigurationManager.AppSettings["settingsPath"]}//{fileName}";
        }
        public static List<string> LoadSettingsFile(this string file)
        {
            //if (!File.Exists(file))
            //{
            //    return new List<string>();
            //}

            return File.ReadAllLines(file).ToList();
        }
        public static List<ListSettingsModel> ConvertToSettingsModel(this List<string> lines)
        {
            List<ListSettingsModel> output = new List<ListSettingsModel>();

            foreach (string line in lines)
            {
                string[] cols = line.Split(';');

                ListSettingsModel p = new ListSettingsModel();
                p.ListType = cols[0];
                p.ListHeaderName = cols[1];

                output.Add(p);
            }

            return output;
        }
    }
}
