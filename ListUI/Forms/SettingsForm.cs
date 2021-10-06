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
        List<LogModel> logs;
        HeaderModel selectedHeader;

        public SettingsForm()
        {
            InitializeComponent();

            WireUpDropDown();
            LoadLogs();
        }

        private void LoadLogs()
        {
            lvLogs.Items.Clear();
            logs = SqliteDataAccess.LoadLogs();

            foreach (var log in logs)
            {
                var lvitem = new ListViewItem(log.Date.ToString("yyyy.MM.dd. HH:mm"));
                lvitem.SubItems.Add(log.LogText);
                lvLogs.Items.Add(lvitem);
            }
        }

        private void WireUpDropDown()
        {
            cbListType.Items.Add("Anime");
            cbListType.Items.Add("Series");
            cbListType.Items.Add("Game");
        }

        private void cbListType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadHeaderListView();
        }

        private void LoadHeaderListView()
        {
            if (cbListType.SelectedItem.ToString() == "Anime")
                headers = SqliteDataAccess.LoadAnimeListHeaders();
            else if (cbListType.SelectedItem.ToString() == "Series")
                headers = SqliteDataAccess.LoadSeriesListHeaders();
            else if (cbListType.SelectedItem.ToString() == "Game")
                headers = SqliteDataAccess.LoadGameListHeaders();

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
                    itemlist.AddRange(SqliteDataAccess.LoadGameGroup("SELECT 1 FROM Game WHERE ListGroup='" + selectedHeader.ListGroup + "' LIMIT 1"));
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

        private void bTruncateLog_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete all logs?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                SqliteDataAccess.DeleteLogs();
                LoadLogs();
            }
        }

        private void bImportA_Click(object sender, EventArgs e)
        {
            var path = GetFilePath();
            if (!String.IsNullOrWhiteSpace(path))
            {
                ImportItemsToDatabase(DataImportExportProcessor.LoadFile(path).ConvertToAnimeModel(), SqliteDataAccess.CheckIfEmptyAnime());
            }
        }

        private void bImportS_Click(object sender, EventArgs e)
        {
            var path = GetFilePath();
            if (!String.IsNullOrWhiteSpace(path))
            {
                ImportItemsToDatabase(DataImportExportProcessor.LoadFile(path).ConvertToSeriesModel(), SqliteDataAccess.CheckIfEmptySeries());
            }
        }

        private void bImportG_Click(object sender, EventArgs e)
        {
            var path = GetFilePath();
            if (!String.IsNullOrWhiteSpace(path))
            {
                ImportItemsToDatabase(DataImportExportProcessor.LoadFile(path).ConvertToGameModel(), SqliteDataAccess.CheckIfEmptyGame());
            }
        }

        private static string GetFilePath()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "d:\\";
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

        private void ImportItemsToDatabase(List<ItemModel> items, int id)
        {
            progressBar1.Value = 0;
            progressBar1.Maximum = items.Count;

            if (id == 0)
            {
                foreach (ItemModel item in items)
                {
                    if (item is AnimeModel)
                    {
                        SqliteDataAccess.SaveAnime((AnimeModel)item, 0);
                    }
                    else if (item is SeriesModel)
                    {
                        SqliteDataAccess.SaveSeries((SeriesModel)item, 0);
                    }
                    else if (item is GameModel)
                    {
                        SqliteDataAccess.SaveGame((GameModel)item, 0);
                    }

                    progressBar1.Increment(1);
                }
            }
            else
            {
                foreach (ItemModel item in items)
                {
                    if (item is AnimeModel)
                    {
                        SqliteDataAccess.ImportAnime((AnimeModel)item);
                    }
                    else if (item is SeriesModel)
                    {
                        SqliteDataAccess.ImportSeries((SeriesModel)item);
                    }
                    else if (item is GameModel)
                    {
                        SqliteDataAccess.ImportGame((GameModel)item);
                    }

                    progressBar1.Increment(1);
                }
            }

            MessageBox.Show("Import completed!");
        }

        private void bExportA_Click(object sender, EventArgs e)
        {
            DataImportExportProcessor.ExportAnime();
            MessageBox.Show("Export completed!");
        }

        private void bExportS_Click(object sender, EventArgs e)
        {
            DataImportExportProcessor.ExportSeries();
            MessageBox.Show("Export completed!");
        }

        private void bExportG_Click(object sender, EventArgs e)
        {
            DataImportExportProcessor.ExportGame();
            MessageBox.Show("Exported completed!");
        }

        private void bDeleteAnime_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to DELETE all Anime?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                SqliteDataAccess.DeleteAllAnime();

                var dir = new DirectoryInfo(@"..\..\..\ListLibrary\Pictures\Anime\");
                foreach (FileInfo file in dir.GetFiles())
                {
                    file.Delete();
                }

                MessageBox.Show("All Anime Deleted!");
            }
        }

        private void bDeleteSeries_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to DELETE all Series?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                SqliteDataAccess.DeleteAllSeries();

                var dir = new DirectoryInfo(@"..\..\..\ListLibrary\Pictures\Series\");
                foreach (FileInfo file in dir.GetFiles())
                {
                    file.Delete();
                }

                MessageBox.Show("All Series Deleted!");
            }
        }

        private void bDeleteGame_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to DELETE all Games?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                SqliteDataAccess.DeleteAllGame();

                var dir = new DirectoryInfo(@"..\..\..\ListLibrary\Pictures\Game\");
                foreach (FileInfo file in dir.GetFiles())
                {
                    file.Delete();
                }

                MessageBox.Show("All Game Deleted!");
            }
        }

        private void bDownloadPicS_Click(object sender, EventArgs e)
        {
            List<ItemModel> items = new List<ItemModel>();

            items.AddRange(SqliteDataAccess.LoadSeriesGroup("SELECT S.ID, S.Title, S.Url, S.PictureUrl, S.Score, S.Year, S.Favourite, S.Notes, " +
                    "S.ListGroup, S.TotalSe, S.CurrentSe, S.TotalEp, S.WatchedEp, S.FinishedRunning FROM Series AS S"));

            DownloadPics(items);

            MessageBox.Show("Download completed!");
        }

        private void bDownloadPicA_Click(object sender, EventArgs e)
        {
            List<ItemModel> items = new List<ItemModel>();

            items.AddRange(SqliteDataAccess.LoadAnimeGroup("SELECT A.ID, A.Title, A.Url, A.PictureUrl, A.Score, A.Year, A.Favourite, A.Notes, " +
                "A.ListGroup, A.Season, A.TotalEp, A.WatchedEp, A.Dubbed FROM Anime AS A"));

            DownloadPics(items);

            MessageBox.Show("Download completed!");
        }

        private void bDownloadPicG_Click(object sender, EventArgs e)
        {
            List<ItemModel> items = new List<ItemModel>();

            items.AddRange(SqliteDataAccess.LoadGameGroup("SELECT G.ID, G.Title, G.Url, G.PictureUrl, G.Score, G.Year, G.Favourite, G.Notes, " +
                "G.ListGroup FROM Games AS G"));

            DownloadPics(items);

            MessageBox.Show("Download completed!");
        }

        private void DownloadPics(List<ItemModel> items)
        {
            progressBar1.Value = 0;
            progressBar1.Maximum = items.Count;

            foreach (ItemModel p in items)
            {
                if (!File.Exists(p.PictureDir))
                {
                    try
                    {
                        using (WebClient client = new WebClient())
                        {
                            client.DownloadFile(p.PictureUrl, p.PictureDir);
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error: " + p.Title);
                    }
                }

                progressBar1.Increment(1);
            }
        }

        private void pbMoveUp_Click(object sender, EventArgs e)
        {
            var header = headers.Where(c => c.SortOrder == selectedHeader.SortOrder - 1).First();
            header.SortOrder++;
            SqliteDataAccess.UpdateHeader(header);
            selectedHeader.SortOrder--;
            SqliteDataAccess.UpdateHeader(selectedHeader);
            //txbHeaderEdit.Text = "";
            LoadHeaderListView();
            LoadLogs();
        }

        private void pbMoveDown_Click(object sender, EventArgs e)
        {
            var header = headers.Where(c => c.SortOrder == selectedHeader.SortOrder + 1).First();
            header.SortOrder--;
            SqliteDataAccess.UpdateHeader(header);
            selectedHeader.SortOrder++;
            SqliteDataAccess.UpdateHeader(selectedHeader);
            //txbHeaderEdit.Text = "";
            LoadHeaderListView();
            LoadLogs();
        }

        private void pbAddRow_Click(object sender, EventArgs e)
        {
            int neworder = 0;
            if (headers != null)
                neworder = headers.Max(c => c.SortOrder) + 1;

            if (headers != null && headers.Count < 15)
            {
                selectedHeader = new HeaderModel() { ListType = cbListType.Text, ListGroup = "New Group", SortOrder = neworder };
                SqliteDataAccess.SaveHeader(selectedHeader);
                LoadHeaderListView();
            }
            else
            {
                MessageBox.Show("No more headers can be added!");
            }

            LoadLogs();
        }

        private void pbDeleteRow_Click(object sender, EventArgs e)
        {
            if (lvHeaders.SelectedItems.Count != 0)
            {
                if (LoadList())
                {
                    MessageBox.Show("There are items in this list group!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            else
            {
                MessageBox.Show("There is no selected item", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            LoadLogs();
        }

        private void pbSave_Click(object sender, EventArgs e)
        {
            if (lvHeaders.SelectedItems.Count != 0)
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to edit list group?", "Attention!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dialogResult == DialogResult.Yes)
                {
                    SqliteDataAccess.UpdateAnimeListGroup(txbHeaderEdit.Text, selectedHeader.ListGroup);
                    selectedHeader.ListGroup = txbHeaderEdit.Text;
                    SqliteDataAccess.UpdateHeader(selectedHeader);
                    txbHeaderEdit.Text = "";
                    LoadHeaderListView();
                }
            }
            else
            {
                MessageBox.Show("There is no selected item", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            LoadLogs();
        }

        private void bExportLogs_Click(object sender, EventArgs e)
        {
            DataImportExportProcessor.ExportLogs();
            MessageBox.Show("Exported completed!");
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
    }
}
