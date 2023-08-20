using ListLibrary.Database;
using ListLibrary.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace ListUI.Forms
{
    public partial class SettingsForm : Form
    {
        List<HeaderModel> headers;
        HeaderModel selectedHeader;
        LibraryUI libraryUI;
        bool isPrimaryClient;
        bool isShowingDeleted;

        public SettingsForm(LibraryUI _libraryUI, string listType)
        {
            InitializeComponent();

            libraryUI = _libraryUI;

            isPrimaryClient = libraryUI.GetIsPrimaryClient();
            chIsPrimaryClient.Checked = isPrimaryClient;

            isShowingDeleted = libraryUI.GetIsShowingDeleted();
            chShowDeleted.Checked = isShowingDeleted;

            WireUpDropDown();

            if(listType == "Anime")
                cbListType.SelectedIndex = 0;
            else if(listType == "Series")
                cbListType.SelectedIndex = 1;
            else if (listType == "Game")
                cbListType.SelectedIndex = 2;

            lvHeaders.Select();
        }

        private void WireUpDropDown()
        {
            cbListType.Items.Add("Anime");
            cbListType.Items.Add("Series");
            cbListType.Items.Add("Game");
        }

        private void cbListType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadHeaderListView();
        }

        private void LoadHeaderListView()
        {
            if (cbListType.SelectedItem.ToString() == "Anime")
                headers = SqliteDataAccess.LoadAnimeListHeaders(false);
            else if (cbListType.SelectedItem.ToString() == "Series")
                headers = SqliteDataAccess.LoadSeriesListHeaders(false);
            else if (cbListType.SelectedItem.ToString() == "Game")
                headers = SqliteDataAccess.LoadGameListHeaders(false);

            lvHeaders.Items.Clear();

            foreach (var header in headers)
            {
                var lvitem = new ListViewItem(header.SortOrder.ToString());
                lvitem.SubItems.Add(header.ListGroup);
                lvHeaders.Items.Add(lvitem);
            }
        }

        private bool LoadList()
        {
            List<ItemModel> itemlist = new List<ItemModel>();

            switch (cbListType.Text)
            {
                case "Anime":
                    itemlist.AddRange(SqliteDataAccess.LoadAnimeGroup("SELECT 1 FROM Anime WHERE ListGroup='" + selectedHeader.ListGroup + "' LIMIT 1"));
                    break;
                case "Game":
                    itemlist.AddRange(SqliteDataAccess.LoadGameGroup("SELECT 1 FROM Games WHERE ListGroup='" + selectedHeader.ListGroup + "' LIMIT 1"));
                    break;
                case "Series":
                    itemlist.AddRange(SqliteDataAccess.LoadSeriesGroup("SELECT 1 FROM Series WHERE ListGroup='" + selectedHeader.ListGroup + "' LIMIT 1"));
                    break;
            }

            return (itemlist.Count != 0) ? true : false;
          }

        private void lvHeaders_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvHeaders.SelectedItems.Count != 0)
            {
                selectedHeader = headers.Where(c => c.ListGroup == lvHeaders.SelectedItems[0].SubItems[1].Text).First();
                txbHeaderEdit.Text = selectedHeader.ListGroup;
            }
            else
            {
                selectedHeader = null;
                txbHeaderEdit.Text = "";
            }
        }

        private void bImportA_Click(object sender, EventArgs e)
        {
            var path = GetFilePath(false);
            if (!String.IsNullOrWhiteSpace(path))
            {
                ImportItemsToDatabase(DataImportExportProcessor.LoadFile(path).ConvertToAnimeModel());
            }
        }

        private void bImportS_Click(object sender, EventArgs e)
        {
            var path = GetFilePath(false);
            if (!String.IsNullOrWhiteSpace(path))
            {
                ImportItemsToDatabase(DataImportExportProcessor.LoadFile(path).ConvertToSeriesModel());
            }
        }

        private void bImportG_Click(object sender, EventArgs e)
        {
            var path = GetFilePath(false);
            if (!String.IsNullOrWhiteSpace(path))
            {
                ImportItemsToDatabase(DataImportExportProcessor.LoadFile(path).ConvertToGameModel());
            }
        }

        private static string GetFilePath(bool isSyncing)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = isSyncing ? @"..\..\..\ListLibrary\ListBackup\SyncFiles\" : @"..\..\..\ListLibrary\ListBackup\"; // "d:\\";
                openFileDialog.Title = "Select file to import";
                openFileDialog.Filter = "CSV Files (*.csv)|*.csv";
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    return openFileDialog.FileName;
                }
                else
                {
                    return "";
                }
            }
        }

        private void ImportItemsToDatabase(List<ItemModel> items)
        {
            progressBar1.Value = 0;
            progressBar1.Maximum = items.Count;

            List<string> lines = new List<string>();

            foreach (ItemModel item in items.OrderBy(x => x.Title))
            {
                if (item is AnimeModel animeModel)
                {
                    SqliteDataAccess.SyncAnime(animeModel);
                }
                else if (item is SeriesModel seriesModel)
                {
                    SqliteDataAccess.SyncSeries(seriesModel);
                }
                else if (item is GameModel gameModel)
                {
                    SqliteDataAccess.SyncGame(gameModel);
                }

                lines.Add($"{item.ID};{item.Title};{item.ListGroup};{item.ModDate}");

                progressBar1.Increment(1);
            }

            string localFilePath = @"..\..\..\ListLibrary\ListBackup\LogFiles\" + DateTime.Now.ToString("yyyy_MM_dd") + "_Log.csv";
            File.AppendAllLines(localFilePath, lines);

            MessageBox.Show("Import completed!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void bExportA_Click(object sender, EventArgs e)
        {
            DataImportExportProcessor.ExportAnime(false);
            MessageBox.Show("Export completed!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void bExportS_Click(object sender, EventArgs e)
        {
            DataImportExportProcessor.ExportSeries(false);
            MessageBox.Show("Export completed!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void bExportG_Click(object sender, EventArgs e)
        {
            DataImportExportProcessor.ExportGame(false);
            MessageBox.Show("Export completed!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void bDeleteAnime_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to DELETE ALL Anime?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                SqliteDataAccess.DeleteAllAnime();

                var dir = new DirectoryInfo(@"..\..\..\ListLibrary\Pictures\Anime\");
                foreach (FileInfo file in dir.GetFiles())
                {
                    file.Delete();
                }

                MessageBox.Show("All Anime Deleted!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void bDeleteSeries_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to DELETE ALL Series?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                SqliteDataAccess.DeleteAllSeries();

                var dir = new DirectoryInfo(@"..\..\..\ListLibrary\Pictures\Series\");
                foreach (FileInfo file in dir.GetFiles())
                {
                    file.Delete();
                }

                MessageBox.Show("All Series Deleted!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void bDeleteGame_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to DELETE ALL Games?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                SqliteDataAccess.DeleteAllGame();

                var dir = new DirectoryInfo(@"..\..\..\ListLibrary\Pictures\Game\");
                foreach (FileInfo file in dir.GetFiles())
                {
                    file.Delete();
                }

                MessageBox.Show("All Game Deleted!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void pbMoveUp_Click(object sender, EventArgs e)
        {
            if (lvHeaders.SelectedItems.Count == 0)
            {
                MessageBox.Show("There is no selected item!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (headers.Where(c => c.SortOrder == selectedHeader.SortOrder - 1).Count() == 0)
            {
                return;
            }

            var header = headers.Where(c => c.SortOrder == selectedHeader.SortOrder - 1).First();
            header.SortOrder++;
            SqliteDataAccess.UpdateHeader(header);
            selectedHeader.SortOrder--;
            SqliteDataAccess.UpdateHeader(selectedHeader);
            txbHeaderEdit.Text = selectedHeader.ListGroup;
            LoadHeaderListView();
            lvHeaders.Items[selectedHeader.SortOrder].Selected = true;
        }

        private void pbMoveDown_Click(object sender, EventArgs e)
        {
            if (lvHeaders.SelectedItems.Count == 0)
            {
                MessageBox.Show("There is no selected item!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (headers.Where(c => c.SortOrder == selectedHeader.SortOrder + 1).Count() == 0)
            {
                return;
            }

            var header = headers.Where(c => c.SortOrder == selectedHeader.SortOrder + 1).First();
            header.SortOrder--;
            SqliteDataAccess.UpdateHeader(header);
            selectedHeader.SortOrder++;
            SqliteDataAccess.UpdateHeader(selectedHeader);
            LoadHeaderListView();
            lvHeaders.Items[selectedHeader.SortOrder].Selected = true;
        }

        private void pbAddRow_Click(object sender, EventArgs e)
        {
            int neworder = 0;
            int newID = 0;
            int newListType = 0;
            if (headers != null)
            {
                neworder = headers.Max(c => c.SortOrder) + 1;
                newID = headers.Max(c => c.ID) + 1;
                newListType = headers.Min(c => c.ListType);
            }

            if (headers != null && headers.Count < 18)
            {
                selectedHeader = new HeaderModel() { ID = newID, ListType = newListType, ListGroup = "New Group", SortOrder = neworder };
                SqliteDataAccess.SaveHeader(selectedHeader);
                LoadHeaderListView();
                lvHeaders.Focus();
                lvHeaders.Items[lvHeaders.Items.Count-1].Selected = true;
            }
            else
            {
                MessageBox.Show("No more headers can be added!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void pbDeleteRow_Click(object sender, EventArgs e)
        {
            if (lvHeaders.SelectedItems.Count == 0)
            {
                MessageBox.Show("There is no selected item!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (LoadList())
            {
                MessageBox.Show("There are items in this list group!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                SqliteDataAccess.DeleteHeader(selectedHeader);
                foreach (var header in headers.Where(c => c.SortOrder > selectedHeader.SortOrder))
                {
                    header.SortOrder--;
                    SqliteDataAccess.UpdateHeader(header);
                }
                txbHeaderEdit.Text = "";
                LoadHeaderListView();
            }
        }

        private void pbSave_Click(object sender, EventArgs e)
        {
            if (lvHeaders.SelectedItems.Count == 0)
            {
                MessageBox.Show("There is no selected item!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if(MessageBox.Show("Do you want to edit list group?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                switch (cbListType.Text)
                {
                    case "Anime":
                        SqliteDataAccess.UpdateAnimeListGroup(txbHeaderEdit.Text, selectedHeader.ListGroup);
                        break;
                    case "Game":
                        SqliteDataAccess.UpdateGameListGroup(txbHeaderEdit.Text, selectedHeader.ListGroup);
                        break;
                    case "Series":
                        SqliteDataAccess.UpdateSeriesListGroup(txbHeaderEdit.Text, selectedHeader.ListGroup);
                        break;
                }
                selectedHeader.ListGroup = txbHeaderEdit.Text;
                SqliteDataAccess.UpdateHeader(selectedHeader);
                txbHeaderEdit.Text = "";
                LoadHeaderListView();
            }
        }

        private void pbMoveUp_MouseEnter(object sender, EventArgs e)
        {
            IncreasePic(pbMoveUp);
        }

        private void pbMoveUp_MouseLeave(object sender, EventArgs e)
        {
             DecreasePic(pbMoveUp);
        }

        private void pbAddRow_MouseEnter(object sender, EventArgs e)
        {
            IncreasePic(pbAddRow);
        }

        private void pbAddRow_MouseLeave(object sender, EventArgs e)
        {
            DecreasePic(pbAddRow);
        }

        private void pbDeleteRow_MouseEnter(object sender, EventArgs e)
        {
            IncreasePic(pbDeleteRow);
        }

        private void pbDeleteRow_MouseLeave(object sender, EventArgs e)
        {
            DecreasePic(pbDeleteRow);
        }

        private void pbMoveDown_MouseEnter(object sender, EventArgs e)
        {
            IncreasePic(pbMoveDown);
        }

        private void pbMoveDown_MouseLeave(object sender, EventArgs e)
        { 
            DecreasePic(pbMoveDown);
        }

        private void pbSave_MouseEnter(object sender, EventArgs e)
        {
            IncreasePic(pbSave);
        }

        private void pbSave_MouseLeave(object sender, EventArgs e)
        {
            DecreasePic(pbSave);
        }

        private void DecreasePic(PictureBox pb)
        {
            pb.Size = new Size(pb.Width - 2, pb.Height - 2);
            pb.Location = new Point(pb.Location.X + 1, pb.Location.Y + 1);
        }

        private void IncreasePic(PictureBox pb)
        {
            pb.Size = new Size(pb.Width + 2, pb.Height + 2);
            pb.Location = new Point(pb.Location.X - 1, pb.Location.Y - 1);
        }

        private void chIsPrimaryClient_CheckStateChanged(object sender, EventArgs e)
        {
            SqliteDataAccess.ChangeClientType(chIsPrimaryClient.Checked);
            libraryUI.SetIsPrimaryClient(chIsPrimaryClient.Checked);
            isPrimaryClient = chIsPrimaryClient.Checked;
        }

        private void checkBox2_CheckStateChanged(object sender, EventArgs e)
        {
            SqliteDataAccess.ChangeShowingDeleted(chShowDeleted.Checked);
            libraryUI.SetIsShowingDeleted(chShowDeleted.Checked);
            isShowingDeleted = chShowDeleted.Checked;
        }

        private void bDownloadPicA_Click(object sender, EventArgs e)
        {
            if (isPrimaryClient)
            {
                DataImportExportProcessor.ExportAnime(true);
                MessageBox.Show("Export completed!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                var path = GetFilePath(true);
                if (!String.IsNullOrWhiteSpace(path))
                {
                    ImportItemsToDatabase(DataImportExportProcessor.LoadFile(path).ConvertToAnimeModel());
                }
            }

            SqliteDataAccess.SetAnimeSyncDate();
        }

        private void bDownloadPicS_Click(object sender, EventArgs e)
        {
            if (isPrimaryClient)
            {
                DataImportExportProcessor.ExportSeries(true);
                MessageBox.Show("Export completed!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                var path = GetFilePath(true);
                if (!String.IsNullOrWhiteSpace(path))
                {
                    ImportItemsToDatabase(DataImportExportProcessor.LoadFile(path).ConvertToSeriesModel());
                }
            }

            SqliteDataAccess.SetSeriesSyncDate();
        }

        private void bDownloadPicG_Click(object sender, EventArgs e)
        {
            if (isPrimaryClient)
            {
                DataImportExportProcessor.ExportGame(true);
                MessageBox.Show("Export completed!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                var path = GetFilePath(false);
                if (!String.IsNullOrWhiteSpace(path))
                {
                    ImportItemsToDatabase(DataImportExportProcessor.LoadFile(path).ConvertToGameModel());
                }
            }

            SqliteDataAccess.SetGameSyncDate();
        }
    }
}
