using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dropbox.Api;
using Dropbox.Api.Files;

namespace ListLibrary.Database
{
    public static class DropboxSyncProcessor
    {
        private readonly static string accessToken = DropboxToken.GetToken();
        private static DropboxClient client;

        public static void UploadSyncFiles(string localFilePath, string dropboxFilePath)
        {
            client = new DropboxClient(accessToken);

            try
            {
                using (var fileStream = File.Open(localFilePath, FileMode.Open))
                {
                    var uploaded = client.Files.UploadAsync(dropboxFilePath, WriteMode.Add.Instance, body: fileStream).Result;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error uploading the database file from Dropbox: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            client.Dispose();

            if (File.Exists(localFilePath))
            {
                File.Delete(localFilePath);
            }
        }
    }
}
