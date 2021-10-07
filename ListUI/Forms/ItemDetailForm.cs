using ListLibrary.Database;
using ListLibrary.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace ListUI.Forms
{
    public partial class ItemDetailForm : Form
    {
        List<HeaderModel> listHeaders;
        bool newitem = true;
        bool userclosing = true;
        bool favouriteChanged = false;
        string listType;
        int itemIndex;

        ItemModel currentItem;
        LibraryUI callingForm;

        public ItemDetailForm(string activeListType, LibraryUI libraryUI)
        {
            InitializeComponent();

            listType = activeListType;
            callingForm = libraryUI;

            if (listType == "Anime")
            {
                currentItem = new AnimeModel();
                listHeaders = SqliteDataAccess.LoadAnimeListHeaders();
            }
            else if (listType == "Game")
            {
                currentItem = new GameModel();
                listHeaders = SqliteDataAccess.LoadGameListHeaders();
            }
            else if (listType == "Series")
            {
                currentItem = new SeriesModel();
                listHeaders = SqliteDataAccess.LoadSeriesListHeaders();
            }

            WireUpFrom();
            LoadForm(currentItem);
        }

        public ItemDetailForm(string activeListType, ItemModel item, int index, LibraryUI libraryUI)
        {
            InitializeComponent();

            newitem = false;
            itemIndex = index;
            listType = activeListType;
            callingForm = libraryUI;
            currentItem = item;

            if (listType == "Anime")
                listHeaders = SqliteDataAccess.LoadAnimeListHeaders();
            else if (listType == "Game")
                listHeaders = SqliteDataAccess.LoadGameListHeaders();
            else if (listType == "Series")
                listHeaders = SqliteDataAccess.LoadSeriesListHeaders();

            WireUpFrom();
            LoadForm(currentItem);
        }

        private void WireUpFrom()
        {
            if (listType == "Anime")
            {
                lbTotalEp.Enabled = true;
                lbTotalEp.Visible = true;
                txbTotalEp.Enabled = true;
                txbTotalEp.Visible = true;
                lbWatchedEp.Enabled = true;
                lbWatchedEp.Visible = true;
                txbWatchedEp.Enabled = true;
                txbWatchedEp.Visible = true;
                lbSeason.Enabled = true;
                lbSeason.Visible = true;
                cbSeason.Enabled = true;
                cbSeason.Visible = true;
                chDubbed.Enabled = true;
                chDubbed.Visible = true;
            }
            else if (listType == "Series")
            {
                lbTotalEp.Enabled = true;
                lbTotalEp.Visible = true;
                txbTotalEp.Enabled = true;
                txbTotalEp.Visible = true;
                txbTotalEp.MaxLength = 100;
                lbWatchedEp.Enabled = true;
                lbWatchedEp.Visible = true;
                txbWatchedEp.Enabled = true;
                txbWatchedEp.Visible = true;
                lbTotalSe.Enabled = true;
                lbTotalSe.Visible = true;
                txbTotalSe.Enabled = true;
                txbTotalSe.Visible = true;
                lbCurrentSe.Enabled = true;
                lbCurrentSe.Visible = true;
                txbCurrentSe.Enabled = true;
                txbCurrentSe.Visible = true;
                chFinished.Enabled = true;
                chFinished.Visible = true;
            }
            else if (listType == "Game")
            {
                chOwned.Enabled = true;
                chOwned.Visible = true;
            }

            foreach (HeaderModel listsetting in listHeaders)
            {
                cbListGroup.Items.Add(listsetting.ListGroup);
            }

            if (listType == "Anime")
            {
                cbSeason.Items.Add("Spring");
                cbSeason.Items.Add("Summer");
                cbSeason.Items.Add("Fall");
                cbSeason.Items.Add("Winter");
            }
        }

        private void LoadForm(ItemModel item)
        {
            pbDelete.Enabled = true;
            pbDelete.Visible = true;

            txbTitle.Text = item.Title;
            txbUrl.Text = item.Url;
            txbPictureUrl.Text = item.PictureUrl;
            if (!File.Exists(item.PictureDir))
            {
                pbPicture.Image = Properties.Resources.nocover;
            }
            else
            {
                using (FileStream stream = new FileStream(item.PictureDir, FileMode.Open, FileAccess.Read))
                {
                    pbPicture.Image = Image.FromStream(stream);
                }
            }
            txbScore.Text = item.Score.ToString();
            if (item.Favourite == false)
            {
                pbFavourite.Image = Properties.Resources.empty;
            }
            else
            {
                pbFavourite.Image = Properties.Resources.heart;
            }
            cbListGroup.Text = item.ListGroup;
            txbNotes.Text = item.Notes;
            txbYear.Text = item.Year.ToString();
            if (item is AnimeModel)
            {
                cbSeason.Text = ((AnimeModel)item).Season;
                txbTotalEp.Text = ((AnimeModel)item).TotalEp.ToString();
                txbWatchedEp.Text = ((AnimeModel)item).WatchedEp.ToString();
                chDubbed.Checked = ((AnimeModel)item).Dubbed;
            }
            if (item is SeriesModel)
            {
                txbTotalSe.Text = ((SeriesModel)item).TotalSe.ToString();
                txbCurrentSe.Text = ((SeriesModel)item).CurrentSe.ToString();
                txbTotalEp.Text = ((SeriesModel)item).TotalEp;
                txbWatchedEp.Text = ((SeriesModel)item).WatchedEp.ToString();
                chFinished.Checked = ((SeriesModel)item).FinishedRunning;
            }
            if (item is GameModel)
            {
                chOwned.Checked = ((GameModel)item).Owned;
            }
        }

        private void favouritePicture_Click(object sender, EventArgs e)
        {
            callingForm.Controls.Find("fpListItemPanel", true).First().Controls[itemIndex].Controls.OfType<Panel>().First().Controls.OfType<PictureBox>().First().Image.Dispose();

            if (currentItem.Favourite == false)
            {
                currentItem.Favourite = true;
                pbFavourite.Image = Properties.Resources.heart;
                favouriteChanged = true;
            }
            else
            {
                currentItem.Favourite = false;
                pbFavourite.Image = Properties.Resources.empty;
                favouriteChanged = true;
            }
        }

        private void savePicture_Click_1(object sender, EventArgs e)
        {
            userclosing = false;

            if (ValidateForm())
            {
                UpdateCurrentItem();
                bool pictureUrlChanged = UpdateCurrentItemPicture();

                if (newitem == true)
                {
                    if (currentItem is AnimeModel)
                    {
                        if (SqliteDataAccess.LoadAnimeGroup("SELECT 1 FROM Anime WHERE Title='" + currentItem.Title + "' LIMIT 1").Count == 1)
                        {
                            txbTitle.BackColor = Color.LightCoral;
                            MessageBox.Show("Title already Exists!");
                            return;
                        }
                        else
                        {
                            SqliteDataAccess.SaveAnime((AnimeModel)currentItem, 1);
                            currentItem.ID = SqliteDataAccess.GetLastAnimeID();
                        }
                    }
                    else if (currentItem is SeriesModel)
                    {
                        if (SqliteDataAccess.LoadSeriesGroup("SELECT 1 FROM Series WHERE Title='" + txbTitle.Text + "' LIMIT 1").Count == 1)
                        {
                            txbTitle.BackColor = Color.LightCoral;
                            MessageBox.Show("Title already Exists!");
                            return;
                        }
                        else
                        {
                            SqliteDataAccess.SaveSeries((SeriesModel)currentItem, 1);
                            currentItem.ID = SqliteDataAccess.GetLastSeriesID();
                        }
                    }
                    else if (currentItem is GameModel)
                    {
                        if (SqliteDataAccess.LoadGameGroup("SELECT 1 FROM Games WHERE Title='" + txbTitle.Text + "' LIMIT 1").Count == 1)
                        {
                            txbTitle.BackColor = Color.LightCoral;
                            MessageBox.Show("Title already Exists!");
                            return;
                        }
                        else
                        {
                            SqliteDataAccess.SaveGame((GameModel)currentItem, 1);
                            currentItem.ID = SqliteDataAccess.GetLastGameID();
                        }
                    }
                }
                else
                {
                    if (currentItem is AnimeModel)
                    {
                        SqliteDataAccess.UpdateAnime((AnimeModel)currentItem);
                    }
                    else if (currentItem is SeriesModel)
                    {
                        SqliteDataAccess.UpdateSeries((SeriesModel)currentItem);
                    }
                    else if (currentItem is GameModel)
                    {
                        SqliteDataAccess.UpdateGame((GameModel)currentItem);
                    }
                }

                if (pictureUrlChanged)
                {
                    SaveItemPicture();
                }
            }
            else
            {
                MessageBox.Show("Invalid inputs!");
                return;
            }

            //TODO: modify according to listitem index

            this.Close();
        }

        private bool ValidateForm()
        {
            bool output = true;

            //Title

            if (txbTitle.Text.Length == 0)
            {
                txbTitle.BackColor = Color.LightCoral;
                output = false;
            }

            //Url

            if (txbUrl.Text.Length == 0 || !txbUrl.Text.Contains("https"))
            {
                txbUrl.BackColor = Color.LightCoral;
                output = false;
            }

            //Picture Url

            if (txbPictureUrl.Text.Length != 0 && !txbPictureUrl.Text.Contains("https"))
            {
                txbPictureUrl.BackColor = Color.LightCoral;
                output = false;
            }

            //Score

            decimal score = 0;
            bool scoreValid = decimal.TryParse(txbScore.Text, out score);

            if (scoreValid == false)
            {
                txbScore.BackColor = Color.LightCoral;
                output = false;
            }
            else if (score > 10 || score < 0)
            {
                txbScore.BackColor = Color.LightCoral;
                output = false;
            }

            //Year

            int year = 0;
            bool yearValid = int.TryParse(txbYear.Text, out year);

            if (yearValid == false)
            {
                txbYear.BackColor = Color.LightCoral;
                output = false;
            }
            else if (txbYear.Text.Length != 4)
            {
                txbYear.BackColor = Color.LightCoral;
                output = false;
            }

            if (listType == "Anime")
            {
                //Anime TotalEp

                int totalEp = 0;
                bool totalEpValid = int.TryParse(txbTotalEp.Text, out totalEp);

                if (totalEpValid == false)
                {
                    txbTotalEp.BackColor = Color.LightCoral;
                    output = false;
                }
                else if (totalEp < 0)
                {
                    txbTotalEp.BackColor = Color.LightCoral;
                    output = false;
                }

                //Anime WatchedEp

                int watchedEp = 0;
                bool watchedEpValid = int.TryParse(txbWatchedEp.Text, out watchedEp);

                if (watchedEpValid == false)
                {
                    txbWatchedEp.BackColor = Color.LightCoral;
                    output = false;
                }
                else if (watchedEp < 0)
                {
                    txbWatchedEp.BackColor = Color.LightCoral;
                    output = false;
                }
                else if (watchedEp > totalEp)
                {
                    txbWatchedEp.BackColor = Color.LightCoral;
                    output = false;
                }
            }
            else if (listType == "Series")
            {
                //Series TotalEp

                if (txbTotalEp.Text.Length != 0 && !txbTotalEp.Text.All(c => ((c >= '0' && c <= '9') || c.ToString() == "/")))
                {
                    txbTotalEp.BackColor = Color.LightCoral;
                    output = false;
                }

                //Series WatchedEp

                int watchedEp = 0;
                bool watchedEpValid = int.TryParse(txbWatchedEp.Text, out watchedEp);

                if (watchedEpValid == false)
                {
                    txbWatchedEp.BackColor = Color.LightCoral;
                    output = false;
                }
                else if (watchedEp < 0)
                {
                    txbWatchedEp.BackColor = Color.LightCoral;
                    output = false;
                }
                else if (watchedEp > ((SeriesModel)currentItem).CurrentSeasonTotalEp)
                {
                    txbWatchedEp.BackColor = Color.LightCoral;
                    output = false;
                }

                //Series TotalSe

                int totalSe = 0;
                bool totalSeValid = int.TryParse(txbTotalSe.Text, out totalSe);

                if (totalSeValid == false)
                {
                    txbTotalSe.BackColor = Color.LightCoral;
                    output = false;
                }
                else if (totalSe < 0)
                {
                    txbTotalSe.BackColor = Color.LightCoral;
                    output = false;
                }

                //Series CurrentSe

                int currentSe = 0;
                bool currentSeValid = int.TryParse(txbCurrentSe.Text, out currentSe);

                if (currentSeValid == false)
                {
                    txbCurrentSe.BackColor = Color.LightCoral;
                    output = false;
                }
                else if (currentSe < 0)
                {
                    txbCurrentSe.BackColor = Color.LightCoral;
                    output = false;
                }
                else if (currentSe > totalSe)
                {
                    txbCurrentSe.BackColor = Color.LightCoral;
                    output = false;
                }
            }

            return output;
        }

        private void UpdateCurrentItem()
        {
            currentItem.Title = txbTitle.Text;
            currentItem.Url = txbUrl.Text;
            currentItem.ListGroup = cbListGroup.Text;
            currentItem.Score = decimal.Round(Convert.ToDecimal(txbScore.Text), 1);
            currentItem.Notes = txbNotes.Text;
            currentItem.Year = Convert.ToInt32(txbYear.Text);
            if (currentItem is AnimeModel)
            {
                ((AnimeModel)currentItem).Season = cbSeason.Text;
                ((AnimeModel)currentItem).TotalEp = Convert.ToInt32(txbTotalEp.Text);
                ((AnimeModel)currentItem).WatchedEp = Convert.ToInt32(txbWatchedEp.Text);
                ((AnimeModel)currentItem).Dubbed = chDubbed.Checked;
            }
            else if (currentItem is SeriesModel)
            {
                ((SeriesModel)currentItem).TotalSe = Convert.ToInt32(txbTotalSe.Text);
                ((SeriesModel)currentItem).CurrentSe = Convert.ToInt32(txbCurrentSe.Text);
                ((SeriesModel)currentItem).TotalEp = txbTotalEp.Text;
                ((SeriesModel)currentItem).WatchedEp = Convert.ToInt32(txbWatchedEp.Text);
                ((SeriesModel)currentItem).FinishedRunning = chFinished.Checked;
            }
            else if (currentItem is GameModel)
            {
                ((GameModel)currentItem).Owned = chOwned.Checked;
            }
        }

        private bool UpdateCurrentItemPicture()
        {
            if (currentItem.PictureUrl != txbPictureUrl.Text)
            {
                currentItem.PictureUrl = txbPictureUrl.Text;
                return true;
            }
            else
            {
                return false;
            }
        }

        private void SaveItemPicture()
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(currentItem.PictureUrl, currentItem.PictureDir);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Not proper picture format!");
            }
        }

        private void deletePicture_Click(object sender, EventArgs e)
        {
            userclosing = false;

            if(MessageBox.Show("Do you want to delete this?","Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (currentItem is AnimeModel)
                {
                    SqliteDataAccess.DeleteAnime((AnimeModel)currentItem);
                }
                else if (currentItem is SeriesModel)
                {
                    SqliteDataAccess.DeleteSeries((SeriesModel)currentItem);
                }
                else if (currentItem is GameModel)
                {
                    SqliteDataAccess.DeleteGame((GameModel)currentItem);
                }

                if (File.Exists(currentItem.PictureDir))
                {
                    File.Delete(currentItem.PictureDir);
                }

                this.Close();
            }
        }

        private void ItemDetailForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (newitem == false && userclosing == true)
            {
                if (CheckIfChanged())
                {
                    if (MessageBox.Show("There are unsaved records! Do you want to Quit?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    {
                        e.Cancel = true;
                    }
                }
            }
        }

        private bool CheckIfChanged()
        {
            bool output = false;

            if (currentItem.Title != txbTitle.Text)
            {
                output = true;
            }
            else if (currentItem.Url != txbUrl.Text)
            {
                output = true;
            }
            else if (currentItem.PictureUrl != txbPictureUrl.Text)
            {
                output = true;
            }
            else if (currentItem.Score.ToString() != txbScore.Text)
            {
                output = true;
            }
            else if (favouriteChanged)
            {
                output = true;
            }
            else if (currentItem.Notes != txbNotes.Text)
            {
                output = true;
            }
            else if (currentItem.ListGroup != cbListGroup.Text)
            {
                output = true;
            }
            else if (currentItem.Year.ToString() != txbYear.Text)
            {
                output = true;
            }
            else if (currentItem is AnimeModel)
            {
                if (((AnimeModel)currentItem).TotalEp.ToString() != txbTotalEp.Text)
                {
                    output = true;
                }
                else if (((AnimeModel)currentItem).WatchedEp.ToString() != txbWatchedEp.Text)
                {
                    output = true;
                }
                else if (((AnimeModel)currentItem).Dubbed != chDubbed.Checked)
                {
                    output = true;
                }
                else if (((AnimeModel)currentItem).Season != cbSeason.Text)
                {
                    output = true;
                }
            }
            else if (currentItem is SeriesModel)
            {
                if (((SeriesModel)currentItem).TotalSe.ToString() != txbTotalSe.Text)
                {
                    output = true;
                }
                else if (((SeriesModel)currentItem).TotalEp != txbTotalEp.Text)
                {
                    output = true;
                }
                else if (((SeriesModel)currentItem).CurrentSe.ToString() != txbCurrentSe.Text)
                {
                    output = true;
                }
                else if (((SeriesModel)currentItem).WatchedEp.ToString() != txbWatchedEp.Text)
                {
                    output = true;
                }
                else if (((SeriesModel)currentItem).FinishedRunning != chFinished.Checked)
                {
                    output = true;
                }
            }
            else if (currentItem is SeriesModel)
            {
                if (((GameModel)currentItem).Owned != chOwned.Checked)
                {
                    output = true;
                }
            }

            return output;
        }

        private void txbPictureUrl_Leave(object sender, EventArgs e)
        {
            try
            {
                pbPicture.Load(txbPictureUrl.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Picture Url not valid!");
            }
        }

        private void pbFavourite_MouseEnter(object sender, EventArgs e)
        {
            IncreasePic(pbFavourite);
        }

        private void pbFavourite_MouseLeave(object sender, EventArgs e)
        {
            DecreasePic(pbFavourite);
        }

        private void pbSave_MouseEnter(object sender, EventArgs e)
        {
            IncreasePic(pbSave);
        }

        private void pbSave_MouseLeave(object sender, EventArgs e)
        {
            DecreasePic(pbSave);
        }

        private void pbDelete_MouseEnter(object sender, EventArgs e)
        {
            IncreasePic(pbDelete);
        }

        private void pbDelete_MouseLeave(object sender, EventArgs e)
        {
            DecreasePic(pbDelete);
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
