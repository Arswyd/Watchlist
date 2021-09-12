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
    public partial class AddGameForm : Form
    {
        public List<ListHeaderModel> newlistsettings = GlobalConfig.SettingsConnection.GetSettings();
        private bool newgame = true;
        private bool userclosing = true;
        private bool favourite = false;
        private string pictureDir;
        private GameModel deletegame = new GameModel();
        
        IItemRequester callingForm;
        public AddGameForm(IItemRequester caller)
        {
            InitializeComponent();
            ShowInTaskbar = false;
            WireUpDropDown();
            listGroupValue.Text = "Not Released Yet";

            callingForm = caller;
        }

        public AddGameForm(GameModel model, IItemRequester caller)
        {
            newgame = false;

            InitializeComponent();
            ShowInTaskbar = false;
            WireUpDropDown();

            callingForm = caller;

            LoadForm(model);
        }

        private void LoadForm(GameModel model)
        {

            deletePicture.Enabled = true;
            deletePicture.Visible = true;

            nameValue.Text = model.Name;
            gameUrlValue.Text = model.GameUrl;
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
            deletegame = model;
            pictureDir = model.PictureDir;
        }

        private void WireUpDropDown()
        {
            foreach (ListHeaderModel listsetting in newlistsettings.Where(n => n.ListType == "Game"))
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

            //GameUrl

            if (gameUrlValue.Text.Length == 0)
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

            if (newgame == true) 
            {
                if (ValidateForm())
                {
                    GameModel model = new GameModel(
                        nameValue.Text,
                        gameUrlValue.Text,
                        pictureUrlValue.Text,
                        scoreValue.Text,
                        favourite,
                        notesValue.Text,
                        listGroupValue.Text,
                        pictureDir);

                    GlobalConfig.Connection.AddGame(model);

                    callingForm.GameItemComplete(model);

                    this.Close();

                }
            }
            else
            {
                if (ValidateForm())
                {
                    GlobalConfig.Connection.RemoveGame(deletegame);

                    List<GameModel> modifylist = GlobalConfig.Connection.GetGame_All();

                    modifylist.Remove(deletegame);

                    GameModel model = new GameModel(
                        nameValue.Text,
                        gameUrlValue.Text,
                        pictureUrlValue.Text,
                        scoreValue.Text,
                        favourite,
                        notesValue.Text,
                        listGroupValue.Text,
                        pictureDir);

                    GlobalConfig.Connection.AddGame(model);

                    modifylist.Add(model);

                    callingForm.GameDeleteComplete(modifylist);

                    this.Close();
                }
            }
        }

        private void deletePicture_Click(object sender, EventArgs e)
        {
            userclosing = false;

            if (MessageBox.Show("Do you want to delete this?","Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                GlobalConfig.Connection.RemoveGame(deletegame);

                List<GameModel> modifylist = GlobalConfig.Connection.GetGame_All();

                modifylist.Remove(deletegame);

                callingForm.GameDeleteComplete(modifylist);

                if (!String.IsNullOrWhiteSpace(pictureDir))
                {
                    File.Delete(deletegame.PictureDir);
                }

                this.Close();
            }
            else
            {

            }
        }

        private void AddGameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (newgame == false && userclosing == true)
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

            if (deletegame.Name != nameValue.Text)
            {
                output = true;
            }
            if (deletegame.GameUrl != gameUrlValue.Text)
            {
                output = true;
            }
            if (deletegame.PictureUrl != pictureUrlValue.Text)
            {
                output = true;
            }
            if (deletegame.Score.ToString() != scoreValue.Text)
            {
                output = true;
            }
            if (deletegame.Favourite != favourite)
            {
                output = true;
            }
            if (deletegame.Notes != notesValue.Text)
            {
                output = true;
            }
            if (deletegame.ListGroup != listGroupValue.Text)
            {
                output = true;
            }

            return output;
        }

        private void scoreValue_Click(object sender, EventArgs e)
        {
            scoreValue.Text = "";
        }
    }
}
