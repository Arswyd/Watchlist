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
using ListUI.Properties;

namespace ListUI
{
    public partial class LibraryUI : Form
    {
        public List<HeaderModel> headerList; // = SqliteDataAccess.LoadListHeaders();
        public List<ItemModel> itemlist = new List<ItemModel>();
        private string activeGroup;
        private string activeListType;
        bool isFiltered = false;
        bool isAscending = false;

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

            cbOrderBy.Items.Add("Score");
            cbOrderBy.Items.Add("Title");
            cbOrderBy.Text = "Score";

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
            }
            if (activeListType == "Series")
            {
                CreateMenuItems();
                InitializeListLoading();
                pListItemPanel.Focus();
            }
            if (activeListType == "Game")
            {
                CreateMenuItems();
                InitializeListLoading();
                pListItemPanel.Focus();
            }

            Application.UseWaitCursor = false;
        }

        public void LoadList()
        {
            itemlist.Clear();

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

        private string CreateFilteredSqlString(string activeGroup)
        {
            if (activeListType == "Anime")
            {
                return "SELECT A.ID, A.Title, A.Url, A.PictureUrl, A.Score, A.Year, A.Favourite, A.Notes, A.ListGroup, A.Season, A.TotalEp, A.WatchedEp, A.Dubbed " +
                       "FROM Anime AS A" + CreateWhereString();
            }
            if (activeListType == "Game")
            {
                return "SELECT G.ID, G.Title, G.Url, G.PictureUrl, G.Score, G.Year, G.Favourite, G.Notes, G.ListGroup " +
                       "FROM Games AS G" + CreateWhereString();
            }
            if (activeListType == "Series")
            {
                return "SELECT S.ID, S.Title, S.Url, S.PictureUrl, S.Score, S.Year, S.Favourite, S.Notes, S.ListGroup, S.TotalSe, S.CurrentSe, S.TotalEp, S.WatchedEp, S.FinishedRunning " +
                       "FROM Series AS S" + CreateWhereString();
            }
            else
            {
                return "";
            }
        }

        private string CreateWhereString()
        {
            string c = "";
            string sWhere = " WHERE (1=1)";

            if (activeListType == "Anime")
                c = "A";            
            else if (activeListType == "Game")
                c = "G";
            else if (activeListType == "Series")
                c = "S";

            if(activeGroup !="All")
            {
                sWhere = sWhere + " AND ListGroup = '" + activeGroup + "'";
            }
            if (isFiltered)
            {
                if (txbTitleSearch.Text != "")
                    sWhere = sWhere + " AND " + c +".Title LIKE '%" + txbTitleSearch.Text + "%'";
                if (txbYearSearch.Text != "")
                    sWhere = sWhere + " AND " + c + ".Year =" + Convert.ToInt32(txbTitleSearch.Text);
                if (chFavouriteSearch.CheckState == CheckState.Checked)
                    sWhere = sWhere + " AND " + c + ".Favourite = 1";
                if (activeListType == "Anime")
                {
                    if (chDubbedSearch.CheckState == CheckState.Checked)
                        sWhere = sWhere + " AND " + c + ".Dubbed = 1";
                    else if (chDubbedSearch.CheckState == CheckState.Unchecked)
                        sWhere = sWhere + " AND " + c + ".Dubbed = 0";
                }
                if (activeListType == "Series")
                {
                    if (chFinishedSearch.CheckState == CheckState.Checked)
                        sWhere = sWhere + " AND " + c + ".FinishedRunning = 1";
                    else if (chFinishedSearch.CheckState == CheckState.Unchecked)
                        sWhere = sWhere + " AND " + c + ".FinishedRunning = 0";
                }
            }

            if (cbOrderBy.SelectedItem.ToString() == "Score")
            {
                if (isAscending)
                    sWhere = sWhere + " ORDER BY " + c + ".Score ASC, " + c + ".Title ASC";
                else
                    sWhere = sWhere + " ORDER BY " + c + ".Score DESC, " + c + ".Title ASC";
            }
            else if (cbOrderBy.SelectedItem.ToString() == "Title")
            {
                if (isAscending)
                    sWhere = sWhere + " ORDER BY " + c + ".Title ASC";
                else
                    sWhere = sWhere + " ORDER BY " + c + ".Title DESC";
            }

            return sWhere;
        }

        public void CreateMenuItems()
        {
            pListHeaderPanel.Controls.Clear();

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

            foreach (HeaderModel listsetting in headerList.OrderBy(n => n.SortOrder))
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
        }

        public void InitializeListLoading()
        {
            int yscroll = pListItemPanel.AutoScrollPosition.Y;

            pListItemPanel.Controls.Clear();

            pListItemPanel.SuspendLayout();

            if (activeGroup == "All")
            {
                foreach (HeaderModel listsetting in headerList.Where(n => n.ListType == activeListType))
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

        private void cbOrderBy_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(cbOrderBy.SelectedItem.ToString() == "Score")
            {
                isAscending = false;
                pbToggleSorting.Image = Resources.sort_desc;
            }
            else if (cbOrderBy.SelectedItem.ToString() == "Title")
            {
                isAscending = true;
                pbToggleSorting.Image = Resources.sort_asc;
            }

            WireUpLibraryForm();
        }

        private void pbFilter_Click(object sender, EventArgs e)
        {
            isFiltered = !isFiltered;

            if (isFiltered)
            {
                pbToggleFilter.Image = Resources.clear_filter;
                lbTitleSearch.Enabled = true;
                lbTitleSearch.Visible = true;
                txbTitleSearch.Enabled = true;
                txbTitleSearch.Visible = true;
                lbYearSearch.Enabled = true;
                lbYearSearch.Visible = true;
                txbYearSearch.Enabled = true;
                txbYearSearch.Visible = true;
                chFavouriteSearch.Enabled = true;
                chFavouriteSearch.Visible = true;
                if (activeListType == "Anime")
                {
                    chDubbedSearch.Enabled = true;
                    chDubbedSearch.Visible = true;
                }
                if (activeListType == "Series")
                {
                    chFinishedSearch.Enabled = true;
                    chFinishedSearch.Visible = true;
                }
                pbSearch.Enabled = true;
                pbSearch.Visible = true;
            }
            else
            {
                pbToggleFilter.Image = Resources.filter;
                lbTitleSearch.Enabled = false;
                lbTitleSearch.Visible = false;
                txbTitleSearch.Enabled = false;
                txbTitleSearch.Visible = false;
                txbTitleSearch.Text = "";
                lbYearSearch.Enabled = false;
                lbYearSearch.Visible = false;
                txbYearSearch.Enabled = false;
                txbYearSearch.Visible = false;
                txbYearSearch.Text = "";
                chFavouriteSearch.Enabled = false;
                chFavouriteSearch.Visible = false;
                chFavouriteSearch.Checked = false;
                if (activeListType == "Anime")
                {
                    chDubbedSearch.Enabled = false;
                    chDubbedSearch.Visible = false;
                    chDubbedSearch.Checked = false;
                }
                if (activeListType == "Series")
                {
                    chFinishedSearch.Enabled = false;
                    chFinishedSearch.Visible = false;
                    chFinishedSearch.Checked = false;
                }
                pbSearch.Enabled = false;
                pbSearch.Visible = false;

                WireUpLibraryForm();
            }
        }

        private void pbSorting_Click(object sender, EventArgs e)
        {
            isAscending = !isAscending;

            if(isAscending)
            {
                pbToggleSorting.Image = Resources.sort_asc;
            }
            else
            {
                pbToggleSorting.Image = Resources.sort_desc;
            }

            WireUpLibraryForm();
        }

        private void pbSearch_Click(object sender, EventArgs e)
        {
            WireUpLibraryForm();
        }

        private void pbToggleSorting_Click_1(object sender, EventArgs e)
        {
            pbOrderBy.Visible = !pbOrderBy.Visible;
            pbOrderBy.Enabled = !pbOrderBy.Enabled;
            cbOrderBy.Visible = !cbOrderBy.Visible;
            cbOrderBy.Enabled = !cbOrderBy.Enabled;
        }

        private void pbSettings_Click(object sender, EventArgs e)
        {
            OverlayForm overlay = new OverlayForm();
            overlay.Show(this);
            overlay.Location = new Point(this.Location.X + 8, this.Location.Y + 30);
            SettingsForm frm = new SettingsForm();
            frm.ShowDialog();
            pListItemPanel.Focus();
            overlay.Close();

            WireUpLibraryForm();
        }

        private void LibraryUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            SqliteDataAccess.LogLastLogin();
        }
    }
}
