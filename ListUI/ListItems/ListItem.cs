using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ListLibrary.Model;
using ListLibrary.Database;
using System.IO;

namespace ListUI.ListItems
{
    public partial class ListItem : UserControl
    {
        string listGroup;
        ItemModel currentItem;
        LibraryUI callerForm;

        public ListItem(LibraryUI libraryUI)
        {
            InitializeComponent();

            Color myColor = Color.FromArgb(180, 0,0,0);
            pbCheck.Parent = pbListItem;
            pbNotes.Parent = pbListItem;
            lbItemTitle.Parent = pbListItem;
            lbItemTitle.BackColor = myColor;
            lbItemScore.Parent = pbListItem;
            lbItemScore.BackColor = myColor;
            panel1.Parent = pbListItem;
            panel1.BackColor = myColor;
            pbDetails.Parent = pbListItem;
            pbDetails.Location = new Point(110, 0);
            pbDetails.BackColor = myColor;

            callerForm = libraryUI;
        }

        public void AddItem(ItemModel item)
        {
            currentItem = item;
            listGroup = item.ListGroup;

            if (!File.Exists(item.PictureDir))
            {
                pbListItem.Image = Properties.Resources.nocover;
            }
            else
            {
                using (FileStream stream = new FileStream(item.PictureDir, FileMode.Open, FileAccess.Read))
                {
                    pbListItem.Image = Image.FromStream(stream);
                }
            }
            lbItemTitle.Text = item.Title; 
            if (item.Score == 0)
            {
                lbItemScore.Text = "N/A";
            }
            else if(item.Score % 1 == 0)
            {
                lbItemScore.Text = item.Score.ToString() + ",0";
            }
            else
            {
                lbItemScore.Text = item.Score.ToString();
            }

            if (item is AnimeModel animeModel)
            {
                lbItemEpisodes.Text = animeModel.TotalEp.ToString() + " / " + animeModel.WatchedEp.ToString();

                SetCheckAndNoteIcon(animeModel.Dubbed, !String.IsNullOrWhiteSpace(item.Notes));
            }
            else if (item is SeriesModel seriesModel)
            {
                lbItemEpisodes.Text = "S" + seriesModel.CurrentSe.ToString() + " E" + seriesModel.WatchedEp.ToString();

                SetCheckAndNoteIcon(seriesModel.FinishedRunning, !String.IsNullOrWhiteSpace(item.Notes));
            }
            else if (item is GameModel gameModel)
            {
                lbItemEpisodes.Text = gameModel.Lenght.ToString() + " h";

                SetCheckAndNoteIcon(gameModel.Owned, !String.IsNullOrWhiteSpace(item.Notes));
            }
            if (!String.IsNullOrWhiteSpace(item.Notes))
            {
                toolTip1.SetToolTip(pbNotes, item.Notes);
            }
            if (item.Favourite == true)
            {
                panel2.BackColor = Color.Maroon;
            }
            if (item.ListGroup != "Watching")
            {
                panel1.Enabled = false;
                lbPlusEp.Enabled = false;
                lbPlusEp.Visible = false;
            }
        }

        private void SetCheckAndNoteIcon(bool isChecked, bool hasNotes)
        {
            if (isChecked && !hasNotes)
            {
                pbCheck.Show();
            }
            else if (hasNotes && !isChecked)
            {
                pbNotes.Show();
                pbNotes.Location = new Point(2, 2);
            }
            else if (hasNotes && isChecked)
            {
                pbCheck.Show();
                pbNotes.Show();
            }
        }

        private void listItemName_Click(object sender, EventArgs e)
        {
            if (currentItem.Url.StartsWith("https://"))
            {
                System.Diagnostics.Process.Start(currentItem.Url);
            }
        }

        private void plusWatched_Click(object sender, EventArgs e)
        {
            lbPlusEp.Enabled = false;
            Application.UseWaitCursor = true;

            if (currentItem is AnimeModel animeModel)
            {
                if (animeModel.TotalEp == 0)
                {
                    MessageBox.Show("Total Episodes were not set!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (animeModel.WatchedEp < (animeModel.TotalEp - 1))
                {
                    animeModel.WatchedEp += 1;

                    lbItemEpisodes.Text = animeModel.TotalEp.ToString() + " / " + animeModel.WatchedEp.ToString();

                    SqliteDataAccess.UpdateAnime(animeModel);
                }
                else if (animeModel.WatchedEp == (animeModel.TotalEp - 1))
                {
                    animeModel.WatchedEp += 1;

                    lbItemEpisodes.Text = animeModel.TotalEp.ToString() + " / " + animeModel.WatchedEp.ToString();

                    currentItem.ListGroup = "Completed";

                    SqliteDataAccess.UpdateAnime(animeModel);

                    MessageBox.Show("Anime Completed!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    callerForm.WireUpRequest(listGroup);
                }
                else
                {
                    //MessageBox.Show("NOT");
                }
            }
            else if (currentItem is SeriesModel seriesModel)
            {
                if (String.IsNullOrWhiteSpace(seriesModel.TotalEp))
                {
                    MessageBox.Show("Total Episodes were not set!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                if (seriesModel.FinishedRunning && seriesModel.CurrentSe == seriesModel.TotalSe && seriesModel.WatchedEp == (seriesModel.CurrentSeasonTotalEp - 1))
                {
                    seriesModel.WatchedEp += 1;

                    lbItemEpisodes.Text = "S" + seriesModel.CurrentSe.ToString() + " E" + seriesModel.WatchedEp.ToString();

                    currentItem.ListGroup = "Completed";

                    SqliteDataAccess.UpdateSeries(seriesModel);

                    MessageBox.Show("Series Completed!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    callerForm.WireUpRequest(listGroup);
                }
                else if (!(seriesModel.FinishedRunning && seriesModel.CurrentSe == seriesModel.TotalSe && seriesModel.WatchedEp == (seriesModel.CurrentSeasonTotalEp - 1)))
                {
                    seriesModel.WatchedEp += 1;

                    lbItemEpisodes.Text = "S" + seriesModel.CurrentSe.ToString() + " E" + seriesModel.WatchedEp.ToString();

                    currentItem.ListGroup = "Season Completed";

                    SqliteDataAccess.UpdateSeries(seriesModel);

                    MessageBox.Show("Season Completed!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    callerForm.WireUpRequest(listGroup);
                }
                else
                {
                    if (seriesModel.WatchedEp < (seriesModel.CurrentSeasonTotalEp - 1))
                    {
                        seriesModel.WatchedEp += 1;

                        lbItemEpisodes.Text = "S" + seriesModel.CurrentSe.ToString() + " E" + seriesModel.WatchedEp.ToString();

                        SqliteDataAccess.UpdateSeries(seriesModel);
                    }
                    else if (seriesModel.WatchedEp == (seriesModel.CurrentSeasonTotalEp - 1))
                    {
                        seriesModel.CurrentSe += 1;

                        seriesModel.WatchedEp = 0;

                        lbItemEpisodes.Text = "S" + seriesModel.CurrentSe.ToString() + " E" + seriesModel.WatchedEp.ToString();

                        SqliteDataAccess.UpdateSeries(seriesModel);
                    }
                    else
                    {
                        //MessageBox.Show("NOT");
                    }
                }
            }

            lbPlusEp.Enabled = true;
            Application.UseWaitCursor = false;
        }

        private void pbListItem_MouseEnter(object sender, EventArgs e)
        {
            foreach (var c in Parent.Controls.OfType<ListItem>())
            {
                c.HidePanel();
            }

            panel1.Visible = true;
        }

        private void listItemScore_MouseEnter(object sender, EventArgs e)
        {
            lbItemScore.Visible = false;
            pbDetails.Visible = true;
            panel1.Visible = false;
        }

        private void menuPicture_MouseLeave(object sender, EventArgs e)
        {
            lbItemScore.Visible = true;
            pbDetails.Visible = false;
        }

        private void listItemName_MouseEnter(object sender, EventArgs e)
        {
            panel1.Visible = false;
            lbItemTitle.ForeColor = Color.LightSteelBlue;
        }

        private void listItemName_MouseLeave(object sender, EventArgs e)
        {
            lbItemTitle.ForeColor = Color.White;
        }

        private void plusWatched_MouseEnter(object sender, EventArgs e)
        {
            lbPlusEp.ForeColor = Color.LightSteelBlue;
        }

        private void plusWatched_MouseLeave(object sender, EventArgs e)
        {
            lbPlusEp.ForeColor = Color.White;
        }

        private void menuPicture_Click(object sender, EventArgs e)
        {
            callerForm.ModifyItem(currentItem, this.Parent.Controls.GetChildIndex(this));
        }

        public void HidePanel()
        {
            panel1.Visible = false;
        }

        private void ListItem_MouseLeave(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }
    }
}
