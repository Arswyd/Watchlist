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
        public List<ListHeaderModel> newlistsettings = SqliteDataAccess.LoadListHeaders();
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
                flowLayoutPanel1.Focus();
                searchBar.Text = "";
            }
            if (activeListType == "Series")
            {
                flowLayoutPanel1.Focus();
                searchBar.Text = "";
            }
            if (activeListType == "Game")
            {
                flowLayoutPanel1.Focus();
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
                        break;
                    case "Series":
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
                        break;
                    case "Series":
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
            else
            {
                return "";
            }
        }

        public void CreateMenuItems()
        {

            listMenuPanel.Controls.Clear();

            ListMenuItem allMenuItem = new ListMenuItem(activeGroup, this);
            allMenuItem.MenuItemName("All");
            allMenuItem.MenuItemCount(newlistsettings.Where(n => n.ListType == "Anime").Sum(n => n.Count).ToString());
            if (activeGroup == "All")
            {
                allMenuItem.ActiveColor();
            }
            listMenuPanel.Controls.Add(allMenuItem);

            foreach (ListHeaderModel listsetting in newlistsettings.Where(n => n.ListType == "Anime").OrderBy(n => n.SortOrder))
            {
                ListMenuItem menuitem = new ListMenuItem(activeGroup, this);
                menuitem.MenuItemName(listsetting.ListGroup);
                menuitem.MenuItemCount(listsetting.Count.ToString());
                if (listsetting.ListGroup == activeGroup)
                {
                    menuitem.ActiveColor();
                }
                listMenuPanel.Controls.Add(menuitem);
            }
        }

        public void InitializeListLoading()
        {
            int yscroll = flowLayoutPanel1.AutoScrollPosition.Y;

            // TODO : Dispose
            flowLayoutPanel1.Controls.Clear();

            if (activeGroup == "All")
            {
                foreach (ListHeaderModel listsetting in newlistsettings.Where(n => n.ListType == "Anime"))
                {
                    LoadListItems(listsetting.ListGroup);
                }
            }
            else
            {
                LoadListItems(activeGroup);
            }

            flowLayoutPanel1.VerticalScroll.Value = (-1) * yscroll;
            //flowLayoutPanel1.Visible = true;
        }

        private void LoadListItems(string headerText)
        {
            ListHeader listHeader = new ListHeader();
            listHeader.HeaderName(headerText);
            flowLayoutPanel1.Controls.Add(listHeader);

            foreach (ItemModel item in itemlist.Where(n => n.ListGroup == headerText))
            {
                ListItem listItem = new ListItem(this);
                listItem.AddItem(item);
                flowLayoutPanel1.Controls.Add(listItem);
            }

            flowLayoutPanel1.Update();
        }

        public void ModifyItem(ItemModel item, ListItem listItem)
        {
            OverlayForm overlay = new OverlayForm();
            overlay.Show(this);
            overlay.Location = new Point(this.Location.X + 8, this.Location.Y + 30);
            ItemDetailForm frm = new ItemDetailForm(activeListType, item, this);
            frm.ShowDialog();
            flowLayoutPanel1.Focus();
            overlay.Close();
        }

        public void WireUpRequest(string listGroup)
        {
            flowLayoutPanel1.VerticalScroll.Value = 0;
            activeGroup = listGroup;
            WireUpLibraryForm();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            OverlayForm overlay = new OverlayForm();
            overlay.Show(this);
            overlay.Location = new Point(this.Location.X + 8, this.Location.Y + 30);
            ItemDetailForm frm = new ItemDetailForm(activeListType, this);
            frm.ShowDialog();
            flowLayoutPanel1.Focus();
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
            flowLayoutPanel1.VerticalScroll.Value = 0;
            activeListType = "Anime";
            activeGroup = "Watching";
            WireUpLibraryForm();
        }

        private void seriesButton_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.VerticalScroll.Value = 0;
            activeListType = "Series";
            activeGroup = "Watching";
            WireUpLibraryForm();
        }

        private void gameButton_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.VerticalScroll.Value = 0;
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
            flowLayoutPanel1.Focus();
        }
    }
}
