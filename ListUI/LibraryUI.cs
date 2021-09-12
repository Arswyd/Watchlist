using ListLibrary;
using ListLibrary.Model;
using ListLibrary.ListSettings;
using ListLibrary.DataAccess;
using ListUI.Forms;
using ListUI.ListItems;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using ListLibrary.Database;

namespace ListUI
{
    public partial class LibraryUI : Form
    {
        public List<ListHeaderModel> newlistsettings = SqliteDataAccess.LoadListHeaders();
        public List<ListItemModel> itemlist = new List<ListItemModel>();
        private string activeGroup;
        private string loadthislist;

        public LibraryUI(string startuplist)
        {
            InitializeComponent();

            loadthislist = startuplist;

            if (loadthislist == "Game")
            {
                activeGroup = "Playing";
            }
            else
            {
                activeGroup = "Watching";
            }

            LoadList();
            CheckButton();
            WireUpAll();

        }

        public void LoadList()
        {
            switch(loadthislist)
            {
                case "Anime":
                    (List<AnimeModel>)itemlist = SqliteDataAccess.LoadAnimeGroup(activeGroup);
                    break;
            }
        }

        public void WireUpAll()
        {
            if (loadthislist == "Anime")
            {
                WireUpAnimeList();
                WireUpAnimeMenu(activeGroup);
                flowLayoutPanel1.Focus();
                searchBar.Text = "";
            }
            if (loadthislist == "Series")
            {
                WireUpSeriesList();
                WireUpSeriesMenu(activeGroup);
                flowLayoutPanel1.Focus();
                searchBar.Text = "";
            }
            if (loadthislist == "Game")
            {
                WireUpGameList();
                WireUpGameMenu(activeGroup);
                flowLayoutPanel1.Focus();
                searchBar.Text = "";
            }
        }

        public void WireUpAnimeList()
        {
            if (activeGroup == "All")
            {
                int yscroll = flowLayoutPanel1.AutoScrollPosition.Y;
                //flowLayoutPanel1.Visible = false;
                flowLayoutPanel1.Controls.Clear();

                foreach (ListHeaderModel listsetting in newlistsettings.Where(n => n.ListType == "Anime"))
                {
                    AddAnimeListGroup(listsetting.ListHeaderName);
                }

                flowLayoutPanel1.VerticalScroll.Value = (-1) * yscroll;
                //flowLayoutPanel1.Visible = true;
            }
            else
            {
                int yscroll = flowLayoutPanel1.AutoScrollPosition.Y;
                //flowLayoutPanel1.Visible = false;
                flowLayoutPanel1.Controls.Clear();

                AddAnimeListGroup(activeGroup);

                flowLayoutPanel1.VerticalScroll.Value = (-1) * yscroll;
                //flowLayoutPanel1.Visible = true;
            }
        }
        public void WireUpAnimeMenu(string activeGroup)
        {

            listMenuPanel.Controls.Clear();

            ListMenuItem t = new ListMenuItem(activeGroup, this);
            t.MenuItemName("All");
            t.MenuItemCount(animelist.Count.ToString());
            if (activeGroup == "All")
            {
                t.ActiveColor();
            }
            listMenuPanel.Controls.Add(t);

            foreach (ListHeaderModel listsetting in newlistsettings.Where(n => n.ListType == "Anime"))
            {
                ListMenuItem p = new ListMenuItem(activeGroup, this);
                p.MenuItemName(listsetting.ListHeaderName);
                p.MenuItemCount(animelist.Count(s => s.ListGroup == listsetting.ListHeaderName).ToString());
                if (listsetting.ListHeaderName == activeGroup)
                {
                    p.ActiveColor();
                }
                listMenuPanel.Controls.Add(p);
            }
        }
        private void AddAnimeListGroup(string z)
        {
            ListHeader p = new ListHeader();
            flowLayoutPanel1.Controls.Add(p);
            p.HeaderName(z);

            foreach (AnimeModel model in animelist.Where(y => y.ListGroup == z).OrderByDescending(x => x.Score).ThenBy(x => x.Name))
            {
                AnimeListItem u = new AnimeListItem(this);
                u.AddAnime(model);
                flowLayoutPanel1.Controls.Add(u);
            }

            flowLayoutPanel1.Update();
        }

        public void WireUpSeriesList()
        {
            if (activeGroup == "All")
            {
                int yscroll = flowLayoutPanel1.AutoScrollPosition.Y;
                flowLayoutPanel1.Visible = false;
                flowLayoutPanel1.Controls.Clear();

                foreach (ListHeaderModel listsetting in newlistsettings.Where(n => n.ListType == "Series"))
                {
                    AddSeriesListGroup(listsetting.ListHeaderName);
                }

                flowLayoutPanel1.VerticalScroll.Value = (-1) * yscroll;
                flowLayoutPanel1.Visible = true;
            }
            else
            {
                int yscroll = flowLayoutPanel1.AutoScrollPosition.Y;
                flowLayoutPanel1.Visible = false;
                flowLayoutPanel1.Controls.Clear();

                AddSeriesListGroup(activeGroup);

                flowLayoutPanel1.VerticalScroll.Value = (-1) * yscroll;
                flowLayoutPanel1.Visible = true;
            }
        }
        public void WireUpSeriesMenu(string activeGroup)
        {

            listMenuPanel.Controls.Clear();

            ListMenuItem t = new ListMenuItem(activeGroup, this);
            t.MenuItemName("All");
            t.MenuItemCount(serieslist.Count.ToString());
            if (activeGroup == "All")
            {
                t.ActiveColor();
            }
            listMenuPanel.Controls.Add(t);

            foreach (ListHeaderModel listsetting in newlistsettings.Where(n => n.ListType == "Series"))
            {
                ListMenuItem p = new ListMenuItem(activeGroup, this);
                p.MenuItemName(listsetting.ListHeaderName);
                p.MenuItemCount(serieslist.Count(s => s.ListGroup == listsetting.ListHeaderName).ToString());
                if (listsetting.ListHeaderName == activeGroup)
                {
                    p.ActiveColor();
                }
                listMenuPanel.Controls.Add(p);
            }
        }
        private void AddSeriesListGroup(string z)
        {
            ListHeader p = new ListHeader();
            flowLayoutPanel1.Controls.Add(p);
            p.HeaderName(z);

            foreach (SeriesModel model in serieslist.Where(y => y.ListGroup == z).OrderByDescending(x => x.Score).ThenBy(x => x.Name))
            {
                SeriesListItem u = new SeriesListItem(this);
                u.AddSeries(model);
                flowLayoutPanel1.Controls.Add(u);
            }
        }

        public void WireUpGameList()
        {
            if (activeGroup == "All")
            {
                int yscroll = flowLayoutPanel1.AutoScrollPosition.Y;
                flowLayoutPanel1.Visible = false;
                flowLayoutPanel1.Controls.Clear();

                foreach (ListHeaderModel listsetting in newlistsettings.Where(n => n.ListType == "Game"))
                {
                    AddGameListGroup(listsetting.ListHeaderName);
                }

                flowLayoutPanel1.VerticalScroll.Value = (-1) * yscroll;
                flowLayoutPanel1.Visible = true;
            }
            else
            {
                int yscroll = flowLayoutPanel1.AutoScrollPosition.Y;
                flowLayoutPanel1.Visible = false;
                flowLayoutPanel1.Controls.Clear();

                AddGameListGroup(activeGroup);

                flowLayoutPanel1.VerticalScroll.Value = (-1) * yscroll;
                flowLayoutPanel1.Visible = true;
            }
        }
        public void WireUpGameMenu(string activeGroup)
        {
            listMenuPanel.Controls.Clear();

            ListMenuItem t = new ListMenuItem(activeGroup, this);
            t.MenuItemName("All");
            t.MenuItemCount(gamelist.Count.ToString());
            if (activeGroup == "All")
            {
                t.ActiveColor();
            }
            listMenuPanel.Controls.Add(t);

            foreach (ListHeaderModel listsetting in newlistsettings.Where(n => n.ListType == "Game"))
            {
                ListMenuItem p = new ListMenuItem(activeGroup, this);
                p.MenuItemName(listsetting.ListHeaderName);
                p.MenuItemCount(gamelist.Count(s => s.ListGroup == listsetting.ListHeaderName).ToString());
                if (listsetting.ListHeaderName == activeGroup)
                {
                    p.ActiveColor();
                }
                listMenuPanel.Controls.Add(p);
            }
        }
        private void AddGameListGroup(string z)
        {
            ListHeader p = new ListHeader();
            flowLayoutPanel1.Controls.Add(p);
            p.HeaderName(z);

            foreach (GameModel model in gamelist.Where(y => y.ListGroup == z).OrderByDescending(x => x.Score).ThenBy(x => x.Name))
            {
                GameListItem u = new GameListItem(this);
                u.AddGame(model);
                flowLayoutPanel1.Controls.Add(u);
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            OverlayForm qwe = new OverlayForm();
            qwe.Show(this);
            qwe.Location = new Point(this.Location.X + 8, this.Location.Y + 30);

            if (loadthislist == "Anime")
            {
                AddAnimeForm frm = new AddAnimeForm(this);
                frm.ShowDialog();
            }
            if (loadthislist == "Series")
            {
                AddSeriesForm frm = new AddSeriesForm(this);
                frm.ShowDialog();
            }
            if (loadthislist == "Game")
            {
                AddGameForm frm = new AddGameForm(this);
                frm.ShowDialog();
            }
            flowLayoutPanel1.Focus();
            qwe.Close();
        }

        public void ModifyAnimeRequest(AnimeModel model)
        {
            OverlayForm qwe = new OverlayForm();
            qwe.Show(this);
            qwe.Location = new Point(this.Location.X + 8, this.Location.Y + 30);
            AddAnimeForm frm = new AddAnimeForm(model, this);
            frm.ShowDialog();
            flowLayoutPanel1.Focus();
            qwe.Close();
        }
        public void ModifyGameRequest(GameModel model)
        {
            OverlayForm qwe = new OverlayForm();
            qwe.Show(this);
            qwe.Location = new Point(this.Location.X + 8, this.Location.Y + 30);
            AddGameForm frm = new AddGameForm(model, this);
            frm.ShowDialog();
            flowLayoutPanel1.Focus();
            qwe.Close();
        }
        public void ModifySeriesRequest(SeriesModel model)
        {
            OverlayForm qwe = new OverlayForm();
            qwe.Show(this);
            qwe.Location = new Point(this.Location.X + 8, this.Location.Y + 30);
            AddSeriesForm frm = new AddSeriesForm(model, this);
            frm.ShowDialog();
            flowLayoutPanel1.Focus();
            qwe.Close();
        }

        public void AnimeItemComplete(AnimeModel model)
        {
            animelist.Add(model);
            WireUpAll();
        }

        public void SeriesItemComplete(SeriesModel model)
        {
            serieslist.Add(model);
            WireUpAll();
        }
        public void GameItemComplete(GameModel model)
        {
            gamelist.Add(model);
            WireUpAll();
        }

        public void AddAnimeWatchedEpisode(List<AnimeModel> modifylist)
        {
            animelist = modifylist;
            WireUpAll();
        }
        public void AddSeriesWatchedEpisode(List<SeriesModel> modifylist)
        {
            serieslist = modifylist;
            WireUpAll();
        }

        public void AnimeDeleteComplete(List<AnimeModel> modifylist)
        {
            animelist = modifylist;
            WireUpAll();
        }

        public void SeriesDeleteComplete(List<SeriesModel> modifylist)
        {
            serieslist = modifylist;
            WireUpAll();
        }
        public void GameDeleteComplete(List<GameModel> modifylist)
        {
            gamelist = modifylist;
            WireUpAll();
        }

        public void WireUpRequest(string groupName)
        {
            flowLayoutPanel1.VerticalScroll.Value = 0;
            activeGroup = groupName;
            WireUpAll();
            //WireUpMenu(activeGroup);
        }

        private void CheckButton()
        {
            if (loadthislist == "Anime")
            {
                animeButton.Enabled = false;
                seriesButton.Enabled = true;
                gameButton.Enabled = true;
            }
            if (loadthislist == "Series")
            {
                animeButton.Enabled = true;
                seriesButton.Enabled = false;
                gameButton.Enabled = true;
            }
            if (loadthislist == "Game")
            {
                animeButton.Enabled = true;
                seriesButton.Enabled = true;
                gameButton.Enabled = false;
            }
        }

        private void animeButton_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.VerticalScroll.Value = 0;
            loadthislist = "Anime";
            activeGroup = "Watching";
            CheckButton();
            WireUpAll();
        }

        private void seriesButton_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.VerticalScroll.Value = 0;
            loadthislist = "Series";
            activeGroup = "Watching";
            CheckButton();
            WireUpAll();
        }

        private void gameButton_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.VerticalScroll.Value = 0;
            loadthislist = "Game";
            activeGroup = "Playing";
            CheckButton();
            WireUpAll();
        }

        private void animeButton_MouseEnter(object sender, EventArgs e)
        {
            animeButton.Size = new Size(52, 52);
            animeButton.Location = new Point(9,9);
        }

        private void animeButton_MouseLeave(object sender, EventArgs e)
        {
            animeButton.Size = new Size(50, 50);
            animeButton.Location = new Point(10, 10);
        }

        private void seriesButton_MouseEnter(object sender, EventArgs e)
        {
            seriesButton.Size = new Size(52, 52);
            seriesButton.Location = new Point(74, 9);
        }

        private void seriesButton_MouseLeave(object sender, EventArgs e)
        {
            seriesButton.Size = new Size(50, 50);
            seriesButton.Location = new Point(75, 10);
        }

        private void gameButton_MouseEnter(object sender, EventArgs e)
        {
            gameButton.Size = new Size(52, 52);
            gameButton.Location = new Point(139, 9);
        }

        private void gameButton_MouseLeave(object sender, EventArgs e)
        {
            gameButton.Size = new Size(50, 50);
            gameButton.Location = new Point(140, 10);
        }

        private void searchBar_TextChanged(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();

            if (loadthislist == "Anime")
            {
                if (searchBar.Text != "")
                {
                    if (activeGroup=="All")
                    {
                        foreach (AnimeModel model in animelist.Where(y => y.Name.ToLower().Contains(searchBar.Text) || y.Name.Contains(searchBar.Text)).OrderByDescending(x => x.Score).ThenBy(x => x.Name))
                        {
                            AnimeListItem u = new AnimeListItem(this);
                            u.AddAnime(model);
                            flowLayoutPanel1.Controls.Add(u);
                        }
                    }
                    else
                    {
                        foreach (AnimeModel model in animelist.Where(y => (y.Name.ToLower().Contains(searchBar.Text) || y.Name.Contains(searchBar.Text)) && y.ListGroup == activeGroup).OrderByDescending(x => x.Score).ThenBy(x => x.Name))
                        {
                            AnimeListItem u = new AnimeListItem(this);
                            u.AddAnime(model);
                            flowLayoutPanel1.Controls.Add(u);
                        }
                    }

                }
                else
                {
                    WireUpAll();
                }
            }

            if (loadthislist == "Series")
            {
                if (searchBar.Text != "")
                {
                    if (activeGroup == "All")
                    {
                        foreach (SeriesModel model in serieslist.Where(y => y.Name.ToLower().Contains(searchBar.Text) || y.Name.Contains(searchBar.Text)).OrderByDescending(x => x.Score).ThenBy(x => x.Name))
                        {
                            SeriesListItem u = new SeriesListItem(this);
                            u.AddSeries(model);
                            flowLayoutPanel1.Controls.Add(u);
                        }
                    }
                    else
                    {
                        foreach (SeriesModel model in serieslist.Where(y => (y.Name.ToLower().Contains(searchBar.Text) || y.Name.Contains(searchBar.Text)) && y.ListGroup == activeGroup).OrderByDescending(x => x.Score).ThenBy(x => x.Name))
                        {
                            SeriesListItem u = new SeriesListItem(this);
                            u.AddSeries(model);
                            flowLayoutPanel1.Controls.Add(u);
                        }
                    }
                }
                else
                {
                    WireUpAll();
                }
            }

            if (loadthislist == "Game")
            {
                if (searchBar.Text != "")
                {
                    if (activeGroup == "All")
                    {
                        foreach (GameModel model in gamelist.Where(y => y.Name.ToLower().Contains(searchBar.Text) || y.Name.Contains(searchBar.Text)).OrderByDescending(x => x.Score).ThenBy(x => x.Name))
                        {
                            GameListItem u = new GameListItem(this);
                            u.AddGame(model);
                            flowLayoutPanel1.Controls.Add(u);
                        }
                    }
                    else
                    {
                        foreach (GameModel model in gamelist.Where(y => (y.Name.ToLower().Contains(searchBar.Text) || y.Name.Contains(searchBar.Text)) && y.ListGroup == activeGroup).OrderByDescending(x => x.Score).ThenBy(x => x.Name))
                        {
                            GameListItem u = new GameListItem(this);
                            u.AddGame(model);
                            flowLayoutPanel1.Controls.Add(u);
                        }
                    }
                }
                else
                {
                    WireUpAll();
                }
            }

        }

        private void flowLayoutPanel1_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Focus();
        }

        private void LibraryUI_Load(object sender, EventArgs e)
        {

        }
    }
}
