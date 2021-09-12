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
    public partial class AnimeListItem : UserControl
    {
        IModifyRequester callingForm;
        public AnimeListItem(IModifyRequester caller)
        {
            InitializeComponent();

            Color myColor = Color.FromArgb(180, 0,0,0);
            dubbedIcon.Parent = listItemPicture;
            noteIcon.Parent = listItemPicture;
            listItemName.Parent = listItemPicture;
            listItemName.BackColor = myColor;
            listItemScore.Parent = listItemPicture;
            listItemScore.BackColor = myColor;

            callingForm = caller;
        }

        public void AddAnime(AnimeModel anime)
        {

            if (String.IsNullOrWhiteSpace(anime.PictureDir))
            {
                listItemPicture.ImageLocation = @"..\..\..\ListLibrary\Pictures\nocover.jpg";
            }
            else
            {
                listItemPicture.ImageLocation = anime.PictureDir;
            }
            listItemName.Text = anime.Name.ToString();
            if (anime.Score > 0)
            {
                listItemScore.Text = anime.Score.ToString();
            }
            if (anime.Score == 0)
            {
                listItemScore.Text = "N/A";
            }
            listItemTotalEp.Text = anime.TotalEp.ToString();
            listItemWatchedEp.Text = anime.WatchedEp.ToString();
            if(anime.Dubbed == true)
            {
                dubbedIcon.Show();
            }
            if (anime.Favourite == true)
            {
                panel2.BackColor = Color.Maroon;
            }
            if (anime.Dubbed == false)
            {
                if (anime.Notes != "")
                {
                    noteIcon.Show();
                    noteIcon.Location = new Point(2, 2);
                }
            }
            if (anime.Dubbed == true)
            {
                if (anime.Notes != "")
                {
                    noteIcon.Show();
                }
            }
            toolTip1.SetToolTip(noteIcon, anime.Notes);
            if (anime.ListGroup != "Watching")
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

        private void AnimeListItem_MouseLeave(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void listItemName_Click(object sender, EventArgs e)
        {
            List<AnimeModel> animelist = GlobalConfig.Connection.GetAnime_All();

            AnimeModel model = new AnimeModel();

            if (listItemScore.Text == "N/A")
            {
                listItemScore.Text = "0";
            }

            model = animelist.Find(n => n.Name == listItemName.Text && n.Score.ToString() == listItemScore.Text);

            if (model.AnimeUrl.StartsWith("https://"))
            {
                System.Diagnostics.Process.Start(model.AnimeUrl);
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
            List<AnimeModel> animelist = GlobalConfig.Connection.GetAnime_All();

            AnimeModel model = new AnimeModel();

            if (listItemScore.Text == "N/A")
            {
                listItemScore.Text = "0";
            }

            model = animelist.Find(n => n.Name == listItemName.Text && n.Score.ToString() == listItemScore.Text);

            if (model.WatchedEp < (model.TotalEp-1) )
            {
                GlobalConfig.Connection.RemoveAnime(model);

                model.WatchedEp += 1;

                listItemWatchedEp.Text = model.WatchedEp.ToString();

                GlobalConfig.Connection.AddAnime(model);
            }
            else
            {
                if (model.WatchedEp == (model.TotalEp - 1))
                {
                    MessageBox.Show("Anime Completed!");

                    GlobalConfig.Connection.RemoveAnime(model);

                    animelist.Remove(model);

                    model.WatchedEp += 1;

                    listItemWatchedEp.Text = model.WatchedEp.ToString();

                    model.ListGroup = "Completed";

                    GlobalConfig.Connection.AddAnime(model);

                    animelist.Add(model);

                    callingForm.AddAnimeWatchedEpisode(animelist);
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
            List<AnimeModel> animelist = GlobalConfig.Connection.GetAnime_All();

            AnimeModel model = new AnimeModel();

            if (listItemScore.Text == "N/A")
            {
                listItemScore.Text = "0";
            }

            model = animelist.Find(n => n.Name == listItemName.Text && n.Score.ToString() == listItemScore.Text);

            callingForm.ModifyAnimeRequest(model);

            if (listItemScore.Text == "0")
            {
                listItemScore.Text = "N/A";
            }
        }
    }
}
