using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ListLibrary.Model;
using ListUI.Forms;
using ListLibrary;
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
            pbDubbed.Parent = pbListItem;
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
                pbListItem.LoadAsync(item.PictureDir);
            }
            lbItemTitle.Text = item.Title; 
            if (item.Score == 0)
            {
                lbItemScore.Text = "N/A";
            }
            else
            {
                lbItemScore.Text = item.Score.ToString();
            }

            if (item is AnimeModel)
            {
                lbItemEpisodes.Text = ((AnimeModel)item).TotalEp.ToString() + "/" + ((AnimeModel)item).WatchedEp.ToString();

                if (((AnimeModel)item).Dubbed == true && String.IsNullOrWhiteSpace(item.Notes))
                {
                    pbDubbed.Show();
                }
                else if (!String.IsNullOrWhiteSpace(item.Notes) && ((AnimeModel)item).Dubbed == false)
                {
                    pbNotes.Show();
                    toolTip1.SetToolTip(pbNotes, item.Notes);
                    pbNotes.Location = new Point(2, 2);
                }
                else if (!String.IsNullOrWhiteSpace(item.Notes) && ((AnimeModel)item).Dubbed == true)
                {
                    pbNotes.Show();
                    toolTip1.SetToolTip(pbNotes, item.Notes);
                }
            }
            else if (item is SeriesModel)
            {
                lbItemEpisodes.Text = "S" + ((SeriesModel)item).CurrentSe.ToString() + " E" + ((SeriesModel)item).WatchedEp.ToString();

                if (((SeriesModel)item).FinishedRunning == true && String.IsNullOrWhiteSpace(item.Notes))
                {
                    pbDubbed.Show();
                }
                else if (!String.IsNullOrWhiteSpace(item.Notes) && ((SeriesModel)item).FinishedRunning == false)
                {
                    pbNotes.Show();
                    toolTip1.SetToolTip(pbNotes, item.Notes);
                    pbNotes.Location = new Point(2, 2);
                }
                else if (!String.IsNullOrWhiteSpace(item.Notes) && ((SeriesModel)item).FinishedRunning == true)
                {
                    pbNotes.Show();
                    toolTip1.SetToolTip(pbNotes, item.Notes);
                }
            }
            else
            {
                if (item.Notes != "")
                {
                    pbNotes.Show();
                    toolTip1.SetToolTip(pbNotes, item.Notes);
                    pbNotes.Location = new Point(2, 2);
                }
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

        private void listItemName_Click(object sender, EventArgs e)
        {
            //TODO: Kell ez?

            if (lbItemScore.Text == "N/A")
            {
                lbItemScore.Text = "0";
            }

            if (currentItem.Url.StartsWith("https://"))
            {
                System.Diagnostics.Process.Start(currentItem.Url);
            }

            if (lbItemScore.Text == "0")
            {
                lbItemScore.Text = "N/A";
            }
        }

        private void plusWatched_Click(object sender, EventArgs e)
        {
            lbPlusEp.Enabled = false;
            Application.UseWaitCursor = true;

            //if (lbItemScore.Text == "N/A")
            //{
            //    lbItemScore.Text = "0";
            //}

            if (currentItem is AnimeModel)
            {
                if (((AnimeModel)currentItem).TotalEp == 0)
                {
                    MessageBox.Show("Total Episodes were not set!");
                }
                else if (((AnimeModel)currentItem).WatchedEp < (((AnimeModel)currentItem).TotalEp - 1))
                {
                    ((AnimeModel)currentItem).WatchedEp += 1;

                    lbItemEpisodes.Text = ((AnimeModel)currentItem).TotalEp.ToString() + "/" + ((AnimeModel)currentItem).WatchedEp.ToString();

                    SqliteDataAccess.UpdateAnime((AnimeModel)currentItem);
                }
                else if (((AnimeModel)currentItem).WatchedEp == (((AnimeModel)currentItem).TotalEp - 1))
                {
                    ((AnimeModel)currentItem).WatchedEp += 1;

                    lbItemEpisodes.Text = ((AnimeModel)currentItem).TotalEp.ToString() + "/" + ((AnimeModel)currentItem).WatchedEp.ToString();

                    currentItem.ListGroup = "Completed";

                    SqliteDataAccess.UpdateAnime((AnimeModel)currentItem);

                    MessageBox.Show("Anime Completed!");

                    callerForm.WireUpRequest(listGroup);

                    //this.Dispose();
                }
                else
                {
                    MessageBox.Show("NOT");
                }
            }
            else if (currentItem is SeriesModel)
            {
                if (String.IsNullOrWhiteSpace(((SeriesModel)currentItem).TotalEp))
                {
                    MessageBox.Show("Total Episodes were not set!");
                }
                if (((SeriesModel)currentItem).FinishedRunning && ((SeriesModel)currentItem).CurrentSe == ((SeriesModel)currentItem).TotalSe && ((SeriesModel)currentItem).WatchedEp == (((SeriesModel)currentItem).CurrentSeasonTotalEp - 1))
                {
                    ((SeriesModel)currentItem).WatchedEp += 1;

                    lbItemEpisodes.Text = "S" + ((SeriesModel)currentItem).CurrentSe.ToString() + " E" + ((SeriesModel)currentItem).WatchedEp.ToString();

                    currentItem.ListGroup = "Completed";

                    SqliteDataAccess.UpdateSeries((SeriesModel)currentItem);

                    MessageBox.Show("Series Completed!");

                    callerForm.WireUpRequest(listGroup);

                    //this.Dispose();
                }
                else if (!((SeriesModel)currentItem).FinishedRunning && ((SeriesModel)currentItem).CurrentSe == ((SeriesModel)currentItem).TotalSe && ((SeriesModel)currentItem).WatchedEp == (((SeriesModel)currentItem).CurrentSeasonTotalEp - 1))
                {
                    ((SeriesModel)currentItem).WatchedEp += 1;

                    lbItemEpisodes.Text = "S" + ((SeriesModel)currentItem).CurrentSe.ToString() + " E" + ((SeriesModel)currentItem).WatchedEp.ToString();

                    currentItem.ListGroup = "Season Completed";

                    SqliteDataAccess.UpdateSeries((SeriesModel)currentItem);

                    MessageBox.Show("Season Completed!");

                    callerForm.WireUpRequest(listGroup);

                    //this.Dispose();
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

                        //TODO: Reload list
                    }
                    else
                    {
                        MessageBox.Show("NOT");
                    }
                }
            }

            lbPlusEp.Enabled = true;
            Application.UseWaitCursor = false;
        }

        private void pbListItem_MouseEnter(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void pbListItem_MouseLeave(object sender, EventArgs e)
        {
            panel1.Visible = false;
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
            if (!(currentItem is GameModel))
            {
                panel1.Visible = false;
            }

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
            //TODO: Kell ez?

            if (lbItemScore.Text == "N/A")
            {
                lbItemScore.Text = "0";
            }

            callerForm.ModifyItem(currentItem, this.Parent.Controls.GetChildIndex(this));

            //AddItem(currentItem);

            if (lbItemScore.Text == "0")
            {
                lbItemScore.Text = "N/A";
            }
        }
    }
}
