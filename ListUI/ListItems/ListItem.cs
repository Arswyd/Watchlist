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

            if (item is AnimeModel)
            {
                lbItemEpisodes.Text = ((AnimeModel)item).TotalEp.ToString() + " / " + ((AnimeModel)item).WatchedEp.ToString();

                SetCheckAndNoteIcon(((AnimeModel)item).Dubbed, !String.IsNullOrWhiteSpace(item.Notes));
            }
            else if (item is SeriesModel)
            {
                lbItemEpisodes.Text = "S" + ((SeriesModel)item).CurrentSe.ToString() + " E" + ((SeriesModel)item).WatchedEp.ToString();

                SetCheckAndNoteIcon(((SeriesModel)item).FinishedRunning, !String.IsNullOrWhiteSpace(item.Notes));
            }
            else
            {
                lbItemEpisodes.Text = ((GameModel)item).Lenght.ToString() + " h";

                SetCheckAndNoteIcon(((GameModel)item).Owned, !String.IsNullOrWhiteSpace(item.Notes));
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

            if (currentItem is AnimeModel)
            {
                if (((AnimeModel)currentItem).TotalEp == 0)
                {
                    MessageBox.Show("Total Episodes were not set!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (((AnimeModel)currentItem).WatchedEp < (((AnimeModel)currentItem).TotalEp - 1))
                {
                    ((AnimeModel)currentItem).WatchedEp += 1;

                    lbItemEpisodes.Text = ((AnimeModel)currentItem).TotalEp.ToString() + " / " + ((AnimeModel)currentItem).WatchedEp.ToString();

                    SqliteDataAccess.UpdateAnime((AnimeModel)currentItem);
                }
                else if (((AnimeModel)currentItem).WatchedEp == (((AnimeModel)currentItem).TotalEp - 1))
                {
                    ((AnimeModel)currentItem).WatchedEp += 1;

                    lbItemEpisodes.Text = ((AnimeModel)currentItem).TotalEp.ToString() + " / " + ((AnimeModel)currentItem).WatchedEp.ToString();

                    currentItem.ListGroup = "Completed";

                    SqliteDataAccess.UpdateAnime((AnimeModel)currentItem);

                    MessageBox.Show("Anime Completed!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    callerForm.WireUpRequest(listGroup);
                }
                else
                {
                    //MessageBox.Show("NOT");
                }
            }
            else if (currentItem is SeriesModel)
            {
                if (String.IsNullOrWhiteSpace(((SeriesModel)currentItem).TotalEp))
                {
                    MessageBox.Show("Total Episodes were not set!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                if (((SeriesModel)currentItem).FinishedRunning && ((SeriesModel)currentItem).CurrentSe == ((SeriesModel)currentItem).TotalSe && ((SeriesModel)currentItem).WatchedEp == (((SeriesModel)currentItem).CurrentSeasonTotalEp - 1))
                {
                    ((SeriesModel)currentItem).WatchedEp += 1;

                    lbItemEpisodes.Text = "S" + ((SeriesModel)currentItem).CurrentSe.ToString() + " E" + ((SeriesModel)currentItem).WatchedEp.ToString();

                    currentItem.ListGroup = "Completed";

                    SqliteDataAccess.UpdateSeries((SeriesModel)currentItem);

                    MessageBox.Show("Series Completed!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    callerForm.WireUpRequest(listGroup);
                }
                else if (!((SeriesModel)currentItem).FinishedRunning && ((SeriesModel)currentItem).CurrentSe == ((SeriesModel)currentItem).TotalSe && ((SeriesModel)currentItem).WatchedEp == (((SeriesModel)currentItem).CurrentSeasonTotalEp - 1))
                {
                    ((SeriesModel)currentItem).WatchedEp += 1;

                    lbItemEpisodes.Text = "S" + ((SeriesModel)currentItem).CurrentSe.ToString() + " E" + ((SeriesModel)currentItem).WatchedEp.ToString();

                    currentItem.ListGroup = "Season Completed";

                    SqliteDataAccess.UpdateSeries((SeriesModel)currentItem);

                    MessageBox.Show("Season Completed!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    callerForm.WireUpRequest(listGroup);
                }
                else
                {
                    if (((SeriesModel)currentItem).WatchedEp < (((SeriesModel)currentItem).CurrentSeasonTotalEp - 1))
                    {
                        ((SeriesModel)currentItem).WatchedEp += 1;

                        lbItemEpisodes.Text = "S" + ((SeriesModel)currentItem).CurrentSe.ToString() + " E" + ((SeriesModel)currentItem).WatchedEp.ToString();

                        SqliteDataAccess.UpdateSeries((SeriesModel)currentItem);
                    }
                    else if (((SeriesModel)currentItem).WatchedEp == (((SeriesModel)currentItem).CurrentSeasonTotalEp - 1))
                    {
                        ((SeriesModel)currentItem).CurrentSe += 1;

                        ((SeriesModel)currentItem).WatchedEp = 0;

                        lbItemEpisodes.Text = "S" + ((SeriesModel)currentItem).CurrentSe.ToString() + " E" + ((SeriesModel)currentItem).WatchedEp.ToString();

                        SqliteDataAccess.UpdateSeries((SeriesModel)currentItem);
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
