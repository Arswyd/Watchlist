using ListLibrary.Database;
using ListLibrary.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
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
        enum ChangeType { nochange, update, delete}
        ChangeType pictureChange = ChangeType.nochange;

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

            pbDelete.Enabled = true;
            pbDelete.Visible = true;

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
                chDubbed.Enabled = true;
                chDubbed.Visible = true;
                lbSeason_Platform.Text = "Season";
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
                txbCurrentSe.Enabled = true;
                txbCurrentSe.Visible = true;
                chFinished.Enabled = true;
                chFinished.Visible = true;
                lbSeason_Platform.Text = "Platform";
            }
            else if (listType == "Game")
            {
                chOwned.Enabled = true;
                chOwned.Visible = true;
                lbSeason_Platform.Text = "Platform";
                lbLenght.Enabled = true;
                lbLenght.Visible = true;
                txbLenght.Enabled = true;
                txbLenght.Visible = true;
            }

            foreach (HeaderModel listsetting in listHeaders)
            {
                cbListGroup.Items.Add(listsetting.ListGroup);
            }

            if (listType == "Anime")
            {
                cbSeason_Platform.Items.Add("Spring");
                cbSeason_Platform.Items.Add("Summer");
                cbSeason_Platform.Items.Add("Fall");
                cbSeason_Platform.Items.Add("Winter");
                cbSeason_Platform.Items.Add("");
            }
            else if (listType == "Series")
            {
                cbSeason_Platform.Items.Add("Netflix");
                cbSeason_Platform.Items.Add("HBO");
                cbSeason_Platform.Items.Add("");
            }
            else if (listType == "Game")
            {
                cbSeason_Platform.Items.Add("Steam");
                cbSeason_Platform.Items.Add("Epic");
                cbSeason_Platform.Items.Add("GoG");
                cbSeason_Platform.Items.Add("Ubisoft");
                cbSeason_Platform.Items.Add("");
            }
        }

        private void LoadForm(ItemModel item)
        {
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
            pbFavourite.Image = (item.Favourite) ? Properties.Resources.heart : Properties.Resources.empty;
            cbListGroup.Text = item.ListGroup;
            txbNotes.Text = item.Notes;
            txbYear.Text = item.Year.ToString();
            if (item is AnimeModel animeModel)
            {
                cbSeason_Platform.Text = animeModel.Season;
                txbTotalEp.Text = animeModel.TotalEp.ToString();
                txbWatchedEp.Text = animeModel.WatchedEp.ToString();
                chDubbed.Checked = animeModel.Dubbed;
            }
            if (item is SeriesModel seriesModel)
            {
                txbCurrentSe.Text = seriesModel.CurrentSe.ToString();
                txbTotalEp.Text = seriesModel.TotalEp.ToString();
                txbWatchedEp.Text = seriesModel.WatchedEp.ToString();
                chFinished.Checked = seriesModel.FinishedRunning;
                cbSeason_Platform.Text = seriesModel.Platform;
            }
            if (item is GameModel gameModel)
            {
                chOwned.Checked = gameModel.Owned;
                txbLenght.Text = gameModel.Lenght.ToString();
                cbSeason_Platform.Text = gameModel.Platform;
            }
        }

        private void favouritePicture_Click(object sender, EventArgs e)
        {
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

                if (newitem == true)
                {
                    if (currentItem is AnimeModel animeModel)
                    {
                        if (SqliteDataAccess.LoadAnimeGroup("SELECT 1 FROM Anime WHERE Title='" + animeModel.Title.Replace("'","'+CHAR(39)+'") + "' LIMIT 1").Count == 1)
                        {
                            txbTitle.BackColor = Color.LightCoral;
                            MessageBox.Show("Title already Exists", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                        else
                        {
                            SqliteDataAccess.SaveAnime(animeModel, 1);
                            animeModel.ID = SqliteDataAccess.GetLastAnimeID();
                        }
                    }
                    else if (currentItem is SeriesModel seriesModel)
                    {
                        if (SqliteDataAccess.LoadSeriesGroup("SELECT 1 FROM Series WHERE Title='" + txbTitle.Text.Replace("'", "'+CHAR(39)+'") + "' LIMIT 1").Count == 1)
                        {
                            txbTitle.BackColor = Color.LightCoral;
                            MessageBox.Show("Title already Exists", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                        else
                        {
                            SqliteDataAccess.SaveSeries(seriesModel, 1);
                            seriesModel.ID = SqliteDataAccess.GetLastSeriesID();
                        }
                    }
                    else if (currentItem is GameModel gameModel)
                    {
                        if (SqliteDataAccess.LoadGameGroup("SELECT 1 FROM Games WHERE Title='" + txbTitle.Text.Replace("'", "'+CHAR(39)+'") + "' LIMIT 1").Count == 1)
                        {
                            txbTitle.BackColor = Color.LightCoral;
                            MessageBox.Show("Title already Exists", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                        else
                        {
                            SqliteDataAccess.SaveGame(gameModel, 1);
                            gameModel.ID = SqliteDataAccess.GetLastGameID();
                        }
                    }
                }
                else
                {
                    if (currentItem is AnimeModel animeModel)
                    {
                        SqliteDataAccess.UpdateAnime(animeModel);
                    }
                    else if (currentItem is SeriesModel seriesModel)
                    {
                        SqliteDataAccess.UpdateSeries(seriesModel);
                    }
                    else if (currentItem is GameModel gameModel)
                    {
                        SqliteDataAccess.UpdateGame(gameModel);
                    }
                }

                if (pictureChange == ChangeType.update)
                {
                    SaveItemPicture();
                }
                else if (pictureChange == ChangeType.delete)
                {
                    DeleteItemPicture();
                }
            }
            else
            {
                MessageBox.Show("Inputs are invalid!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            else
            {
                txbTitle.Text = txbTitle.Text.Trim();
            }

            //Url

            if (txbUrl.Text.Length == 0 || !(txbUrl.Text.Contains("https") || txbUrl.Text.Contains("http") || txbUrl.Text.Contains("www") || txbUrl.Text.Contains(".com")))
            {
                txbUrl.BackColor = Color.LightCoral;
                output = false;
            }
            else if (txbUrl.Text.Contains("?q="))
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

            decimal score;
            bool scoreValid = decimal.TryParse(txbScore.Text, out score);

            if (!scoreValid)
            {
                txbScore.BackColor = Color.LightCoral;
                return false;
            }
            else if (score > 10 || score < 0)
            {
                txbScore.BackColor = Color.LightCoral;
                output = false;
            }

            //Year

            int year;
            bool yearValid = int.TryParse(txbYear.Text, out year);

            if (!yearValid)
            {
                txbYear.BackColor = Color.LightCoral;
                return false;
            }
            else if (!(txbYear.Text.Length == 4 || Convert.ToInt32(txbYear.Text) == 0))
            {
                txbYear.BackColor = Color.LightCoral;
                output = false;
            }

            if (listType == "Anime")
            {
                //Anime TotalEp

                int totalEp;
                bool totalEpValid = int.TryParse(txbTotalEp.Text, out totalEp);

                if (!totalEpValid)
                {
                    txbTotalEp.BackColor = Color.LightCoral;
                    return false;
                }
                else if (totalEp < 0)
                {
                    txbTotalEp.BackColor = Color.LightCoral;
                    output = false;
                }

                //Anime WatchedEp

                int watchedEp;
                bool watchedEpValid = int.TryParse(txbWatchedEp.Text, out watchedEp);

                if (!watchedEpValid)
                {
                    txbWatchedEp.BackColor = Color.LightCoral;
                    return false;
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
                //Series CurrentSe

                int currentSe;
                bool currentSeValid = int.TryParse(txbCurrentSe.Text, out currentSe);

                if (!currentSeValid)
                {
                    txbCurrentSe.BackColor = Color.LightCoral;
                    return false;
                }
                else if (currentSe < 0)
                {
                    txbCurrentSe.BackColor = Color.LightCoral;
                    output = false;
                }

                //Series TotalEp

                int totalEp;
                bool totalEpValid = int.TryParse(txbTotalEp.Text, out totalEp);

                if (!totalEpValid)
                {
                    txbTotalEp.BackColor = Color.LightCoral;
                    output = false;
                }
                else if (totalEp < 0)
                {
                    txbTotalEp.BackColor = Color.LightCoral;
                    output = false;
                }

                //Series WatchedEp

                int watchedEp;
                bool watchedEpValid = int.TryParse(txbWatchedEp.Text, out watchedEp);

                if (!watchedEpValid)
                {
                    txbWatchedEp.BackColor = Color.LightCoral;
                    return false;
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
            else
            {
                //Lenght

                decimal lenght;
                bool lenghtValid = decimal.TryParse(txbLenght.Text, out lenght);

                if (!lenghtValid)
                {
                    txbLenght.BackColor = Color.LightCoral;
                    return false;
                }
                else if (lenght > 1000 || lenght < 0)
                {
                    txbLenght.BackColor = Color.LightCoral;
                    output = false;
                }
            }

            return output;
        }

        private void UpdateCurrentItem()
        {
            currentItem.Title = txbTitle.Text;
            currentItem.Url = txbUrl.Text;
            currentItem.PictureUrl = txbPictureUrl.Text;
            currentItem.PicFormat = (pictureChange == ChangeType.update && pbPicture.SizeMode == PictureBoxSizeMode.Zoom) ? 1 : 0;
            currentItem.ListGroup = cbListGroup.Text;
            currentItem.Score = decimal.Round(Convert.ToDecimal(txbScore.Text), 1);
            currentItem.Notes = txbNotes.Text;
            currentItem.Year = Convert.ToInt32(txbYear.Text);
            if (currentItem is AnimeModel animeModel)
            {
                animeModel.Season = cbSeason_Platform.Text;
                animeModel.TotalEp = Convert.ToInt32(txbTotalEp.Text);
                animeModel.WatchedEp = Convert.ToInt32(txbWatchedEp.Text);
                animeModel.Dubbed = chDubbed.Checked;
            }
            else if (currentItem is SeriesModel seriesModel)
            {
                seriesModel.Platform = cbSeason_Platform.Text;
                seriesModel.CurrentSe = Convert.ToInt32(txbCurrentSe.Text);
                seriesModel.TotalEp = Convert.ToInt32(txbTotalEp.Text);
                seriesModel.WatchedEp = Convert.ToInt32(txbWatchedEp.Text);
                seriesModel.FinishedRunning = chFinished.Checked;
            }
            else if (currentItem is GameModel gameModel)
            {
                gameModel.Platform = cbSeason_Platform.Text;
                gameModel.Owned = chOwned.Checked;
                gameModel.Lenght = decimal.Round(Convert.ToDecimal(txbLenght.Text), 1);
            }
        }

        private void SaveItemPicture()
        {
            try
            {
                if (currentItem.PicFormat == 0)
                {
                    using (WebClient client = new WebClient())
                    {
                        client.DownloadFile(currentItem.PictureUrl, currentItem.PictureDir);
                    }

                    currentItem.PicFormat = 1;
                    DeleteItemPicture();
                }
                else
                {
                    using (Bitmap bitmap = new Bitmap(pbPicture.Width, pbPicture.Height, PixelFormat.Format32bppRgb))
                    {
                        pbPicture.DrawToBitmap(bitmap, new Rectangle(0, 0, 160, 220));
                        bitmap.Save(currentItem.PictureDir, ImageFormat.Png);
                    }

                    currentItem.PicFormat = 0;
                    DeleteItemPicture();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Picture Url does not exist!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void DeleteItemPicture()
        {
            if (File.Exists(currentItem.PictureDir))
            {
                File.Delete(currentItem.PictureDir);
            }
        }

        private void deletePicture_Click(object sender, EventArgs e)
        {
            userclosing = false;

            if(MessageBox.Show("Do you want to delete this?","Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (currentItem is AnimeModel animeModel)
                {
                    SqliteDataAccess.DeleteAnime(animeModel);
                }
                else if (currentItem is SeriesModel seriesModel)
                {
                    SqliteDataAccess.DeleteSeries(seriesModel);
                }
                else if (currentItem is GameModel gameModel)
                {
                    SqliteDataAccess.DeleteGame(gameModel);
                }

                DeleteItemPicture();

                this.Close();
            }
        }


        private void ItemDetailForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (newitem == false && userclosing == true)
            {
                if (CheckIfChanged())
                {
                    if (MessageBox.Show("There are unsaved records! Do you want to Quit?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        e.Cancel = true;
                    }
                }
            }
            else if (userclosing == false)
            {
                callingForm.WireUpLibraryForm(true, false);
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
            else if (pictureChange != ChangeType.nochange)
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
            else if (currentItem is AnimeModel animeModel)
            {
                if (animeModel.TotalEp.ToString() != txbTotalEp.Text)
                {
                    output = true;
                }
                else if (animeModel.WatchedEp.ToString() != txbWatchedEp.Text)
                {
                    output = true;
                }
                else if (animeModel.Dubbed != chDubbed.Checked)
                {
                    output = true;
                }
                else if (animeModel.Season != cbSeason_Platform.Text)
                {
                    output = true;
                }
            }
            else if (currentItem is SeriesModel seriesModel)
            {
                if (seriesModel.TotalEp.ToString() != txbTotalEp.Text)
                {
                    output = true;
                }
                else if (seriesModel.CurrentSe.ToString() != txbCurrentSe.Text)
                {
                    output = true;
                }
                else if (seriesModel.WatchedEp.ToString() != txbWatchedEp.Text)
                {
                    output = true;
                }
                else if (seriesModel.FinishedRunning != chFinished.Checked)
                {
                    output = true;
                }
                else if (seriesModel.Platform != cbSeason_Platform.Text)
                {
                    output = true;
                }
            }
            else if (currentItem is GameModel gameModel)
            {
                if (gameModel.Owned != chOwned.Checked)
                {
                    output = true;
                }
                else if (gameModel.Lenght.ToString() != txbLenght.Text)
                {
                    output = true;
                }
                else if (gameModel.Platform != cbSeason_Platform.Text)
                {
                    output = true;
                }
            }

            return output;
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

        private void txbTitle_DoubleClick(object sender, EventArgs e)
        {
            txbTitle.SelectAll();
        }

        private void txbUrl_DoubleClick(object sender, EventArgs e)
        {
            txbUrl.SelectAll();
        }

        private void txbPictureUrl_DoubleClick(object sender, EventArgs e)
        {
            txbPictureUrl.SelectAll();
        }

        private void pbReloadPic_Click(object sender, EventArgs e)
        {
            try
            {
                pbPicture.Load(txbPictureUrl.Text);
                pictureChange = ChangeType.update;
            }
            catch (Exception)
            {
                MessageBox.Show("Picture Url does not exist!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void pbPicture_Click(object sender, EventArgs e)
        {
            if (pictureChange == ChangeType.update)
            {
                switch (pbPicture.SizeMode)
                {
                    case PictureBoxSizeMode.StretchImage:
                        pbPicture.SizeMode = PictureBoxSizeMode.Zoom;
                        break;
                    case PictureBoxSizeMode.Zoom:
                        pbPicture.SizeMode = PictureBoxSizeMode.StretchImage;
                        break;
                }
            }
        }

        private void pbDeletePic_Click(object sender, EventArgs e)
        {
            pbPicture.Image = Properties.Resources.nocover;
            txbPictureUrl.Text = "";
            pictureChange = ChangeType.delete;
        }
    }
}
