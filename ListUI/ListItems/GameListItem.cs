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
    public partial class GameListItem : UserControl
    {
        IModifyRequester callingForm;
        public GameListItem(IModifyRequester caller)
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

        public void AddGame(GameModel game)
        {
            if (String.IsNullOrWhiteSpace(game.PictureDir))
            {
                listItemPicture.ImageLocation = @"..\..\..\ListLibrary\Pictures\nocover.jpg";
            }
            else
            {
                listItemPicture.ImageLocation = game.PictureDir;
            }
            listItemName.Text = game.Name.ToString();
            listItemScore.Text = game.Score.ToString();
            if (game.Score > 0)
            {
                listItemScore.Text = game.Score.ToString();
            }
            if (game.Score == 0)
            {
                listItemScore.Text = "N/A";
            }
            if (game.Favourite == true)
            {
                panel2.BackColor = Color.Maroon;
            }
            if (game.Notes != "")
            {
                noteIcon.Show();
            }
            toolTip1.SetToolTip(noteIcon, game.Notes);
        }

        private void listItemName_Click(object sender, EventArgs e)
        {
            List<GameModel> gamelist = GlobalConfig.Connection.GetGame_All();

            GameModel model = new GameModel();

            if (listItemScore.Text == "N/A")
            {
                listItemScore.Text = "0";
            }

            model = gamelist.Find(n => n.Name == listItemName.Text && n.Score.ToString() == listItemScore.Text);

            if (model.GameUrl.StartsWith("https://"))
            {
                System.Diagnostics.Process.Start(model.GameUrl);
            }

            if (listItemScore.Text == "0")
            {
                listItemScore.Text = "N/A";
            }
        }

        private void listItemScore_MouseEnter(object sender, EventArgs e)
        {
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
            listItemName.ForeColor = Color.LightSteelBlue;
        }

        private void listItemName_MouseLeave(object sender, EventArgs e)
        {
            listItemName.ForeColor = Color.White;
        }

        private void menuPicture_Click(object sender, EventArgs e)
        {
            List<GameModel> gamelist = GlobalConfig.Connection.GetGame_All();

            GameModel model = new GameModel();

            if (listItemScore.Text == "N/A")
            {
                listItemScore.Text = "0";
            }

            model = gamelist.Find(n => n.Name == listItemName.Text && n.Score.ToString() == listItemScore.Text);

            callingForm.ModifyGameRequest(model);

            if (listItemScore.Text == "0")
            {
                listItemScore.Text = "N/A";
            }
        }
    }
}
