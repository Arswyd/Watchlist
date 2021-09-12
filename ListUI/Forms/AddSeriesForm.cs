using ListLibrary;
using ListLibrary.DataAccess;
using ListLibrary.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListUI.Forms
{
    public partial class AddSeriesForm : Form
    {
        public List<ListHeaderModel> newlistsettings = GlobalConfig.SettingsConnection.GetSettings();
        private bool newseries = true;
        private bool userclosing = true;
        private bool favourite = false;
        private string pictureDir;
        private SeriesModel deleteseries = new SeriesModel();
        
        IItemRequester callingForm;
        public AddSeriesForm(IItemRequester caller)
        {
            InitializeComponent();
            ShowInTaskbar = false;
            WireUpDropDown();
            listGroupValue.Text = "Not Aired Yet";

            callingForm = caller;
        }

        public AddSeriesForm(SeriesModel model, IItemRequester caller)
        {
            newseries = false;

            InitializeComponent();
            ShowInTaskbar = false;
            WireUpDropDown();

            callingForm = caller;

            LoadForm(model);
        }

        private void LoadForm(SeriesModel model)
        {

            deletePicture.Enabled = true;
            deletePicture.Visible = true;

            nameValue.Text = model.Name;
            seriesUrlValue.Text = model.SeriesUrl;
            pictureUrlValue.Text = model.PictureUrl;
            if (String.IsNullOrWhiteSpace(model.PictureDir))
            {
                addItemPicture.ImageLocation = @"..\..\..\ListLibrary\Pictures\nocover.jpg";
            }
            else
            {
                addItemPicture.ImageLocation = model.PictureDir;
            }
            scoreValue.Text = model.Score.ToString();
            seasonValue.Text = model.Season.ToString();
            totalEpValue.Text = model.TotalEp.ToString();
            watchedEpValue.Text = model.WatchedEp.ToString();
            favourite = model.Favourite;
            if (favourite == false)
            {
                favouritePicture.Image = Properties.Resources.empty;
            }
            else
            {
                favouritePicture.Image = Properties.Resources.heart;
            }
            notesValue.Text = model.Notes;
            listGroupValue.Text = model.ListGroup;
            deleteseries = model;
            pictureDir = model.PictureDir;
        }

        private void WireUpDropDown()
        {
            foreach (ListHeaderModel listsetting in newlistsettings.Where(n => n.ListType == "Series"))
            {
                listGroupValue.Items.Add(listsetting.ListHeaderName);
            }
        }

        private bool ValidateForm()
        {
            bool output = true;

            //Name

            if (nameValue.Text.Length == 0)
            {
                nameValue.BackColor = Color.LightCoral;
                output = false;
            }

            //AnimeUrl

            if (seriesUrlValue.Text.Length == 0)
            {
                addItemPicture.BackColor = Color.LightCoral;
                output = false;
            }

            //Score

            decimal score = 0;
            bool scoreValid = decimal.TryParse(scoreValue.Text, out score);

            if (scoreValid == false)
            {
                scoreValue.BackColor = Color.LightCoral;
                output = false;
            }

            if (score > 10 || score < 0)
            {
                scoreValue.BackColor = Color.LightCoral;
                output = false;
            }

            //Season

            int season = 0;
            bool seasonValid = int.TryParse(seasonValue.Text, out season);

            if (seasonValid == false)
            {
                seasonValue.BackColor = Color.LightCoral;
                output = false;
            }

            if (season < 0)
            {
                seasonValue.BackColor = Color.LightCoral;
                output = false;
            }

            //TotalEp

            int totalEp = 0;
            bool totalEpValid = int.TryParse(totalEpValue.Text, out totalEp);

            if (totalEpValid == false)
            {
                totalEpValue.BackColor = Color.LightCoral;
                output = false;
            }

            if (totalEp < 0)
            {
                totalEpValue.BackColor = Color.LightCoral;
                output = false;
            }

            //WatchedEp

            int watchedEp = 0;
            bool watchedEpValid = int.TryParse(watchedEpValue.Text, out watchedEp);

            if (watchedEpValid == false)
            {
                watchedEpValue.BackColor = Color.LightCoral;
                output = false;
            }

            if (watchedEp < 0)
            {
                watchedEpValue.BackColor = Color.LightCoral;
                output = false;
            }

            if (watchedEp > totalEp)
            {
                watchedEpValue = totalEpValue;
                watchedEpValue.Text = totalEpValue.Text;
                output = false;
            }

            return output;
        }

        private void addItemPicture_Click(object sender, EventArgs e)
        {
            urlPanel.Enabled = true;
            urlPanel.Show();
            panel1.Enabled = false;
        }

        private void urlButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(pictureUrlValue.Text))
            {
                addItemPicture.ImageLocation = @"..\..\..\ListLibrary\Pictures\nocover.jpg";
            }
            else
            {
                addItemPicture.ImageLocation = pictureUrlValue.Text;
            }
            urlPanel.Enabled = false;
            urlPanel.Hide();
            panel1.Enabled = true;
        }

        private void favouritePicture_Click(object sender, EventArgs e)
        {
            if (favourite == false)
            {
                favourite = true;
                favouritePicture.Image = Properties.Resources.heart;
            }
            else
            {
                favourite = false;
                favouritePicture.Image = Properties.Resources.empty;
            }
        }

        private void savePicture_Click_1(object sender, EventArgs e)
        {
            userclosing = false;

            if (newseries == true) 
            {
                if (ValidateForm())
                {
                    SeriesModel model = new SeriesModel(
                        nameValue.Text,
                        seriesUrlValue.Text,
                        pictureUrlValue.Text,
                        scoreValue.Text,
                        seasonValue.Text,
                        totalEpValue.Text,
                        watchedEpValue.Text,
                        favourite,
                        notesValue.Text,
                        listGroupValue.Text,
                        pictureDir);

                    GlobalConfig.Connection.AddSeries(model);

                    callingForm.SeriesItemComplete(model);

                    this.Close();

                }
            }
            else
            {
                if (ValidateForm())
                {
                    GlobalConfig.Connection.RemoveSeries(deleteseries);

                    List<SeriesModel> modifylist = GlobalConfig.Connection.GetSeries_All();

                    modifylist.Remove(deleteseries);

                    SeriesModel model = new SeriesModel(
                        nameValue.Text,
                        seriesUrlValue.Text,
                        pictureUrlValue.Text,
                        scoreValue.Text,
                        seasonValue.Text,
                        totalEpValue.Text,
                        watchedEpValue.Text,
                        favourite,
                        notesValue.Text,
                        listGroupValue.Text,
                        pictureDir);

                    GlobalConfig.Connection.AddSeries(model);

                    modifylist.Add(model);

                    callingForm.SeriesDeleteComplete(modifylist);

                    this.Close();
                }
            }
        }

        private void deletePicture_Click(object sender, EventArgs e)
        {
            userclosing = false;

            if (MessageBox.Show("Do you want to delete this?","Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                GlobalConfig.Connection.RemoveSeries(deleteseries);

                List<SeriesModel> modifylist = GlobalConfig.Connection.GetSeries_All();

                modifylist.Remove(deleteseries);

                callingForm.SeriesDeleteComplete(modifylist);

                if (!String.IsNullOrWhiteSpace(pictureDir))
                {

                    File.Delete(deleteseries.PictureDir);

                }

                this.Close();
            }
            else
            {

            }
        }

        private void AddSeriesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (newseries == false && userclosing == true)
            {
                bool changed = CheckIfChanged();

                if (changed == true)
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

            if (deleteseries.Name != nameValue.Text)
            {
                output = true;
            }
            if (deleteseries.SeriesUrl != seriesUrlValue.Text)
            {
                output = true;
            }
            if (deleteseries.PictureUrl != pictureUrlValue.Text)
            {
                output = true;
            }
            if (deleteseries.Score.ToString() != scoreValue.Text)
            {
                output = true;
            }
            if (deleteseries.Season.ToString() != seasonValue.Text)
            {
                output = true;
            }
            if (deleteseries.TotalEp.ToString() != totalEpValue.Text)
            {
                output = true;
            }
            if (deleteseries.WatchedEp.ToString() != watchedEpValue.Text)
            {
                output = true;
            }
            if (deleteseries.Favourite != favourite)
            {
                output = true;
            }
            if (deleteseries.Notes != notesValue.Text)
            {
                output = true;
            }
            if (deleteseries.ListGroup != listGroupValue.Text)
            {
                output = true;
            }

            return output;
        }

        private void scoreValue_Click(object sender, EventArgs e)
        {
            scoreValue.Text = "";
        }

        private void totalEpValue_Click(object sender, EventArgs e)
        {
            totalEpValue.Text = "";
        }

        private void watchedEpValue_Click(object sender, EventArgs e)
        {
            watchedEpValue.Text = "";
        }

        private void seasonValue_Click(object sender, EventArgs e)
        {
            seasonValue.Text = "";
        }
    }
}
