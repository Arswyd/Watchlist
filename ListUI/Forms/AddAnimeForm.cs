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
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListUI.Forms
{
    public partial class AddAnimeForm : Form
    {
        public List<ListHeaderModel> newlistsettings = GlobalConfig.SettingsConnection.GetSettings();
        private bool newanime = true;
        private bool userclosing = true;
        private bool favourite = false;
        private string pictureDir;
        private AnimeModel deleteanime = new AnimeModel();
        
        IItemRequester callingForm;
        public AddAnimeForm(IItemRequester caller)
        {
            InitializeComponent();
            ShowInTaskbar = false;
            WireUpDropDown();
            listGroupValue.Text = "Not Aired Yet";

            callingForm = caller;
        }

        public AddAnimeForm(AnimeModel model, IItemRequester caller)
        {
            newanime = false;

            InitializeComponent();
            ShowInTaskbar = false;
            WireUpDropDown();

            callingForm = caller;

            LoadForm(model);
        }

        private void LoadForm(AnimeModel model)
        {

            deletePicture.Enabled = true;
            deletePicture.Visible = true;

            nameValue.Text = model.Name;
            animeUrlValue.Text = model.AnimeUrl;
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
            totalEpValue.Text = model.TotalEp.ToString();
            watchedEpValue.Text = model.WatchedEp.ToString();
            dubValue.Checked = model.Dubbed;
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
            deleteanime = model;
            pictureDir = model.PictureDir;
        }

        private void WireUpDropDown()
        {
            foreach (ListHeaderModel listsetting in newlistsettings.Where(n => n.ListType == "Anime"))
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

            if (animeUrlValue.Text.Length == 0)
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

            if (newanime == true) 
            {
                if (ValidateForm())
                {
                    AnimeModel model = new AnimeModel(
                        nameValue.Text,
                        animeUrlValue.Text,
                        pictureUrlValue.Text,
                        scoreValue.Text,
                        totalEpValue.Text,
                        watchedEpValue.Text,
                        dubValue.Checked,
                        favourite,
                        notesValue.Text,
                        listGroupValue.Text,
                        pictureDir);

                    GlobalConfig.Connection.AddAnime(model);

                    callingForm.AnimeItemComplete(model);

                    this.Close();

                }
            }
            else
            {
                if (ValidateForm())
                {
                    GlobalConfig.Connection.RemoveAnime(deleteanime);

                    List<AnimeModel> modifylist = GlobalConfig.Connection.GetAnime_All();

                    modifylist.Remove(deleteanime);

                    AnimeModel model = new AnimeModel(
                        nameValue.Text,
                        animeUrlValue.Text,
                        pictureUrlValue.Text,
                        scoreValue.Text,
                        totalEpValue.Text,
                        watchedEpValue.Text,
                        dubValue.Checked,
                        favourite,
                        notesValue.Text,
                        listGroupValue.Text,
                        pictureDir);

                    GlobalConfig.Connection.AddAnime(model);

                    modifylist.Add(model);

                    callingForm.AnimeDeleteComplete(modifylist);

                    this.Close();
                }
            }
        }

        private void deletePicture_Click(object sender, EventArgs e)
        {
            userclosing = false;

            if(MessageBox.Show("Do you want to delete this?","Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                GlobalConfig.Connection.RemoveAnime(deleteanime);

                List<AnimeModel> modifylist = GlobalConfig.Connection.GetAnime_All();

                modifylist.Remove(deleteanime);

                callingForm.AnimeDeleteComplete(modifylist);

                if (!String.IsNullOrWhiteSpace(pictureDir))
                {

                    File.Delete(deleteanime.PictureDir);

                }

                this.Close();
            }
            else
            {

            }
        }

        private void AddAnimeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (newanime == false && userclosing == true)
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

            if (deleteanime.Name != nameValue.Text)
            {
                output = true;
            }
            if (deleteanime.AnimeUrl != animeUrlValue.Text)
            {
                output = true;
            }
            if (deleteanime.PictureUrl != pictureUrlValue.Text)
            {
                output = true;
            }
            if (deleteanime.Score.ToString() != scoreValue.Text)
            {
                output = true;
            }
            if (deleteanime.TotalEp.ToString() != totalEpValue.Text)
            {
                output = true;
            }
            if (deleteanime.WatchedEp.ToString() != watchedEpValue.Text)
            {
                output = true;
            }
            if (deleteanime.Dubbed != dubValue.Checked)
            {
                output = true;
            }
            if (deleteanime.Favourite != favourite)
            {
                output = true;
            }
            if (deleteanime.Notes != notesValue.Text)
            {
                output = true;
            }
            if (deleteanime.ListGroup != listGroupValue.Text)
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
    }
}
