using ListLibrary;
using ListLibrary.Model;
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
        public List<ListHeaderModel> headerList; // = SqliteDataAccess.LoadListHeaders();
        public List<ItemModel> itemlist = new List<ItemModel>();
        private string activeGroup;
        private string activeListType;

        public LibraryUI(string startuplist)
        {
            InitializeComponent();

            activeListType = startuplist;

            if (activeListType == "Game")
            {
                activeGroup = "Playing";
            }
            else
            {
                activeGroup = "Watching";
            }

            WireUpLibraryForm();
        }

        public void WireUpLibraryForm()
        {
            Application.UseWaitCursor = true;

            LoadList();
            CheckButtons();

            if (activeListType == "Anime")
            {
                CreateMenuItems();
                InitializeListLoading();
                pListItemPanel.Focus();
                searchBar.Text = "";
            }
            if (activeListType == "Series")
            {
                CreateMenuItems();
                InitializeListLoading();
                pListItemPanel.Focus();
                searchBar.Text = "";
            }
            if (activeListType == "Game")
            {
                CreateMenuItems();
                InitializeListLoading();
                pListItemPanel.Focus();
                searchBar.Text = "";
            }

            Application.UseWaitCursor = false;
        }

        public void LoadList()
        {
            itemlist.Clear();

            if (activeGroup == "All")
            {
                switch (activeListType)
                {
                    case "Anime":
                        itemlist.AddRange(SqliteDataAccess.LoadAllAnime());
                        break;
                    case "Game":
                        itemlist.AddRange(SqliteDataAccess.LoadAllGame());
                        break;
                    case "Series":
                        itemlist.AddRange(SqliteDataAccess.LoadAllSeries());
                        break;
                }
            }
            else
            { 
                switch (activeListType)
                {
                    case "Anime":
                        itemlist.AddRange(SqliteDataAccess.LoadAnimeGroup(CreateFilteredSqlString(activeGroup)));
                        break;
                    case "Game":
                        itemlist.AddRange(SqliteDataAccess.LoadGameGroup(CreateFilteredSqlString(activeGroup)));
                        break;
                    case "Series":
                        itemlist.AddRange(SqliteDataAccess.LoadSeriesGroup(CreateFilteredSqlString(activeGroup)));
                        break;
                }
            }
        }

        private string CreateFilteredSqlString(string activeGroup)
        {
            if (activeListType == "Anime")
            {
                return "SELECT A.ID, A.Title, A.Url, A.PictureUrl, A.Score, A.Year, A.Favourite, A.Notes, A.ListGroup, A.Season, A.TotalEp, A.WatchedEp, A.Dubbed " +
                       "FROM Anime AS A WHERE ListGroup=\"" + activeGroup + "\"";
            }
            if (activeListType == "Game")
            {
                return "SELECT G.ID, G.Title, G.Url, G.PictureUrl, G.Score, G.Year, G.Favourite, G.Notes, G.ListGroup " +
                       "FROM Games AS G WHERE ListGroup=\"" + activeGroup + "\"";
            }
            if (activeListType == "Series")
            {
                return "SELECT S.ID, S.Title, S.Url, S.PictureUrl, S.Score, S.Year, S.Favourite, S.Notes, S.ListGroup, S.TotalSe, S.CurrentSe, S.TotalEp, S.WatchedEp, S.FinishedRunning " +
                       "FROM Series AS S WHERE ListGroup=\"" + activeGroup + "\"";
            }
            else
            {
                return "";
            }
        }

        public void CreateMenuItems()
        {
            pListHeaderPanel.Controls.Clear();

            pListHeaderPanel.SuspendLayout();

            if (activeListType == "Anime")
                headerList = SqliteDataAccess.LoadAnimeListHeaders();
            else if (activeListType == "Game")
                headerList = SqliteDataAccess.LoadGameListHeaders();
            else if (activeListType == "Series")
                headerList = SqliteDataAccess.LoadSeriesListHeaders();

            ListMenuItem allMenuItem = new ListMenuItem(activeGroup, this);
            allMenuItem.MenuItemName("All");
            allMenuItem.MenuItemCount(headerList.Sum(n => n.Count).ToString());
            if (activeGroup == "All")
            {
                allMenuItem.ActiveColor();
            }
            pListHeaderPanel.Controls.Add(allMenuItem);

            foreach (ListHeaderModel listsetting in headerList.OrderBy(n => n.SortOrder))
            {
                ListMenuItem menuItem = new ListMenuItem(activeGroup, this);
                menuItem.MenuItemName(listsetting.ListGroup);
                menuItem.MenuItemCount(listsetting.Count.ToString());
                if (listsetting.ListGroup == activeGroup)
                {
                    menuItem.ActiveColor();
                }
                pListHeaderPanel.Controls.Add(menuItem);
            }

            pListHeaderPanel.ResumeLayout();
        }

        public void InitializeListLoading()
        {
            int yscroll = pListItemPanel.AutoScrollPosition.Y;

            // TODO : Dispose
            pListItemPanel.Controls.Clear();

            pListItemPanel.SuspendLayout();

            if (activeGroup == "All")
            {
                foreach (ListHeaderModel listsetting in headerList.Where(n => n.ListType == activeListType))
                {
                    LoadListItems(listsetting.ListGroup);
                }
            }
            else
            {
                LoadListItems(activeGroup);
            }

            pListItemPanel.VerticalScroll.Value = (-1) * yscroll;

            pListItemPanel.ResumeLayout();
        }

        private void LoadListItems(string headerText)
        {
            ListHeader listHeader = new ListHeader();
            listHeader.HeaderName(headerText);
            pListItemPanel.Controls.Add(listHeader);

            foreach (ItemModel item in itemlist.Where(n => n.ListGroup == headerText))
            {
                ListItem listItem = new ListItem(this);
                listItem.AddItem(item);
                pListItemPanel.Controls.Add(listItem);
            }

            pListItemPanel.Update();
        }

        public void ModifyItem(ItemModel item, int index)
        {
            OverlayForm overlay = new OverlayForm();
            overlay.Show(this);
            overlay.Location = new Point(this.Location.X + 8, this.Location.Y + 30);
            ItemDetailForm frm = new ItemDetailForm(activeListType, item, index, this);
            frm.ShowDialog();
            pListItemPanel.Focus();
            overlay.Close();

            WireUpLibraryForm();
        }

        public void WireUpRequest(string listGroup)
        {
            pListItemPanel.VerticalScroll.Value = 0;
            activeGroup = listGroup;

            //TODO: Elimination of reloading flowlayout panel
            WireUpLibraryForm();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            OverlayForm overlay = new OverlayForm();
            overlay.Show(this);
            overlay.Location = new Point(this.Location.X + 8, this.Location.Y + 30);
            ItemDetailForm frm = new ItemDetailForm(activeListType, this);
            frm.ShowDialog();
            pListItemPanel.Focus();
            overlay.Close();
        }

        private void CheckButtons()
        {
            if (activeListType == "Anime")
            {
                animeButton.Enabled = false;
                seriesButton.Enabled = true;
                gameButton.Enabled = true;
            }
            if (activeListType == "Series")
            {
                animeButton.Enabled = true;
                seriesButton.Enabled = false;
                gameButton.Enabled = true;
            }
            if (activeListType == "Game")
            {
                animeButton.Enabled = true;
                seriesButton.Enabled = true;
                gameButton.Enabled = false;
            }
        }

        private void animeButton_Click(object sender, EventArgs e)
        {
            pListItemPanel.VerticalScroll.Value = 0;
            activeListType = "Anime";
            activeGroup = "Watching";
            WireUpLibraryForm();
        }

        private void seriesButton_Click(object sender, EventArgs e)
        {
            pListItemPanel.VerticalScroll.Value = 0;
            activeListType = "Series";
            activeGroup = "Watching";
            WireUpLibraryForm();
        }

        private void gameButton_Click(object sender, EventArgs e)
        {
            pListItemPanel.VerticalScroll.Value = 0;
            activeListType = "Game";
            activeGroup = "Playing";
            WireUpLibraryForm();
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

        private void flowLayoutPanel1_Click(object sender, EventArgs e)
        {
            pListItemPanel.Focus();
        }
    }
}
