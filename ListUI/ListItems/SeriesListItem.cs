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
using ListLibrary.DataAccess;
using ListLibrary;

namespace ListUI.ListItems
{
    public partial class SeriesListItem : UserControl
    {
        IModifyRequester callingForm;
        public SeriesListItem(IModifyRequester caller)
        {
            InitializeComponent();

            Color myColor = Color.FromArgb(180, 0,0,0);
            noteIcon.Parent = listItemPicture;
            listItemName.Parent = listItemPicture;
            listItemName.BackColor = myColor;
            listItemScore.Parent = listItemPicture;
            listItemScore.BackColor = myColor;

            callingForm = caller;
        }

        public void AddSeries(SeriesModel series)
        {
            if (String.IsNullOrWhiteSpace(series.PictureDir))
            {
                listItemPicture.ImageLocation = @"..\..\..\ListLibrary\Pictures\nocover.jpg";
            }
            else
            {
                listItemPicture.ImageLocation = series.PictureDir;
            }
            listItemName.Text = series.Name.ToString();
            if (series.Score > 0)
            {
                listItemScore.Text = series.Score.ToString();
            }
            if (series.Score == 0)
            {
                listItemScore.Text = "N/A";
            }
            listItemSeason.Text = series.Season.ToString();
            listItemWatchedEp.Text = series.WatchedEp.ToString();
            if (series.Favourite == true)
            {
                panel2.BackColor = Color.Maroon;
            }
            if (series.Notes != "")
            {
                noteIcon.Show();
            }
            toolTip1.SetToolTip(noteIcon, series.Notes);
            if (series.ListGroup != "Watching")
            {
                panel1.Enabled = false;
                plusWatched.Enabled = false;
                plusWatched.Visible = false;
            }
        }

        private void listItemPicture_MouseEnter(object sender, EventArgs e)
        {
                Color myColor = Color.FromArgb(180, 0, 0, 0);
                panel1.Parent = listItemPicture;
                panel1.BackColor = myColor;
                panel1.Visible = true;
        }

        private void SeriesListItem_MouseLeave(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void listItemName_Click(object sender, EventArgs e)
        {
            List<SeriesModel> serieslist = GlobalConfig.Connection.GetSeries_All();

            SeriesModel model = new SeriesModel();

            if (listItemScore.Text == "N/A")
            {
                listItemScore.Text = "0";
            }

            model = serieslist.Find(n => n.Name == listItemName.Text && n.Score.ToString() == listItemScore.Text);

            if (model.SeriesUrl.StartsWith("https://"))
            {
                System.Diagnostics.Process.Start(model.SeriesUrl);
            }

            if (listItemScore.Text == "0")
            {
                listItemScore.Text = "N/A";
            }
        }

        private void panel2_MouseLeave(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void plusWatched_Click(object sender, EventArgs e)
        {
            List<SeriesModel> serieslist = GlobalConfig.Connection.GetSeries_All();

            SeriesModel model = new SeriesModel();

            if (listItemScore.Text == "N/A")
            {
                listItemScore.Text = "0";
            }

            model = serieslist.Find(n => n.Name == listItemName.Text && n.Score.ToString() == listItemScore.Text);

            if (model.WatchedEp < (model.TotalEp-1) )
            {
                GlobalConfig.Connection.RemoveSeries(model);

                model.WatchedEp += 1;

                listItemWatchedEp.Text = model.WatchedEp.ToString();

                GlobalConfig.Connection.AddSeries(model);

            }
            else
            {
                if (model.WatchedEp == (model.TotalEp - 1))
                {
                    MessageBox.Show("Season Completed!");

                    GlobalConfig.Connection.RemoveSeries(model);

                    serieslist.Remove(model);

                    model.WatchedEp += 1;

                    model.ListGroup = "Season Completed";

                    GlobalConfig.Connection.AddSeries(model);

                    serieslist.Add(model);

                    callingForm.AddSeriesWatchedEpisode(serieslist);
                }
                else
                {
                    MessageBox.Show("NOT");
                }
            }
        }

        private void listItemScore_MouseEnter(object sender, EventArgs e)
        {
            panel1.Visible = false;
            listItemScore.Visible = false;
            Color myColor = Color.FromArgb(180, 0, 0, 0);
            menuPicture.Parent = listItemPicture;
            menuPicture.Location = new Point(110, 0);
            menuPicture.BackColor = myColor;
            menuPicture.Visible = true;
        }

        private void menuPicture_MouseLeave(object sender, EventArgs e)
        {
            listItemScore.Visible = true;
            menuPicture.Visible = false;
        }

        private void listItemName_MouseEnter(object sender, EventArgs e)
        {
            panel1.Visible = false;
            listItemName.ForeColor = Color.LightSteelBlue;
        }

        private void listItemName_MouseLeave(object sender, EventArgs e)
        {
            listItemName.ForeColor = Color.White;
        }

        private void plusWatched_MouseEnter(object sender, EventArgs e)
        {
            plusWatched.ForeColor = Color.LightSteelBlue;
        }

        private void plusWatched_MouseLeave(object sender, EventArgs e)
        {
            plusWatched.ForeColor = Color.White;
        }

        private void menuPicture_Click(object sender, EventArgs e)
        {
            List<SeriesModel> serieslist = GlobalConfig.Connection.GetSeries_All();

            SeriesModel model = new SeriesModel();

            if (listItemScore.Text == "N/A")
            {
                listItemScore.Text = "0";
            }

            model = serieslist.Find(n => n.Name == listItemName.Text && n.Score.ToString() == listItemScore.Text);

            callingForm.ModifySeriesRequest(model);

            if (listItemScore.Text == "0")
            {
                listItemScore.Text = "N/A";
            }
        }
    }
}
