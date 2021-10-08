using ListLibrary.Model;
using ListUI.Forms;
using ListUI.ListItems;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ListLibrary.Database;
using ListUI.Properties;

namespace ListUI
{
    public partial class LibraryUI : Form
    {
        public List<HeaderModel> headerList;
        public List<ItemModel> itemlist = new List<ItemModel>();
        private string activeGroup;
        private string activeListType;
        bool isFiltered = false;
        bool isAscending = false;

        public LibraryUI(string startuplist)
        {
            InitializeComponent();

            activeListType = startuplist;

            activeGroup = (activeListType == "Game") ? "Playing" : "Watching";

            cbOrderBy.Items.Add("Score");
            cbOrderBy.Items.Add("Title");
            cbOrderBy.Text = "Score";

            WireUpLibraryForm();
        }

        public void WireUpLibraryForm()
        {
            LoadList();
            CheckButtons();
            CreateMenuItems();
            fpListHeaderPanel.Refresh();
            InitializeListLoading();
            fpListItemPanel.Focus();
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
                return "SELECT G.ID, G.Title, G.Url, G.PictureUrl, G.Score, G.Year, G.Favourite, G.Notes, G.ListGroup, G.Owned " +
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
                    sWhere = sWhere + " AND " + c +".Title LIKE '%" + txbTitleSearch.Text.Replace("'", "'+CHAR(39)+'") + "%'";
                if (txbYearSearch.Text != "")
                    sWhere = sWhere + " AND " + c + ".Year =" + Convert.ToInt32(txbYearSearch.Text);
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
                if (activeListType == "Game")
                {
                    if (chOwnedSearch.CheckState == CheckState.Checked)
                        sWhere = sWhere + " AND " + c + ".Owned = 1";
                    else if (chOwnedSearch.CheckState == CheckState.Unchecked)
                        sWhere = sWhere + " AND " + c + ".Owned = 0";
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
            fpListHeaderPanel.Controls.Clear();

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
            fpListHeaderPanel.Controls.Add(allMenuItem);

            foreach (HeaderModel listsetting in headerList.OrderBy(n => n.SortOrder))
            {
                ListMenuItem menuItem = new ListMenuItem(activeGroup, this);
                menuItem.MenuItemName(listsetting.ListGroup);
                menuItem.MenuItemCount(listsetting.Count.ToString());
                if (listsetting.ListGroup == activeGroup)
                {
                    menuItem.ActiveColor();
                }
                fpListHeaderPanel.Controls.Add(menuItem);
            }
        }

        public void InitializeListLoading()
        {
            int yscroll = fpListItemPanel.AutoScrollPosition.Y;

            fpListItemPanel.Controls.Clear();
            fpListItemPanel.SuspendLayout();

            if (activeGroup == "All")
            {
                foreach (HeaderModel listsetting in headerList.Where(n => n.ListType == activeListType && n.ListGroup != "Completed"))
                {
                    LoadListItems(listsetting.ListGroup);
                }
            }
            else
            {
                LoadListItems(activeGroup);
            }

            fpListItemPanel.ResumeLayout();
            fpListItemPanel.VerticalScroll.Value = (-1) * yscroll;
        }

        private void LoadListItems(string headerText)
        {
            ListHeader listHeader = new ListHeader();
            listHeader.HeaderName(headerText);
            fpListItemPanel.Controls.Add(listHeader);

            progressBar1.Visible = true;
            progressBar1.Value = 0;
            progressBar1.Maximum = itemlist.Where(n => n.ListGroup == headerText).Count();

            foreach (ItemModel item in itemlist.Where(n => n.ListGroup == headerText))
            {
                ListItem listItem = new ListItem(this);
                listItem.AddItem(item);
                fpListItemPanel.Controls.Add(listItem);
                progressBar1.PerformStep();
            }

            progressBar1.Visible = false;
        }

        public void ModifyItem(ItemModel item, int index)
        {
            OverlayForm overlay = new OverlayForm();
            overlay.Show(this);
            overlay.Location = new Point(this.Location.X + 8, this.Location.Y + 30);
            ItemDetailForm frm = new ItemDetailForm(activeListType, item, index, this);
            frm.ShowDialog();
            fpListItemPanel.Focus();
            overlay.Close();
        }

        public void WireUpRequest(string listGroup)
        {
            fpListItemPanel.VerticalScroll.Value = 0;
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
            fpListItemPanel.Focus();
            overlay.Close();
        }

        private void CheckButtons()
        {
            pbSelectAnime.Enabled = (activeListType == "Anime") ? true : false;
            pbSelectSeries.Enabled = (activeListType == "Series") ? true : false;
            pbSelectGame.Enabled = (activeListType == "Game") ? true : false;
        }
        private void pbSelectAnime_Click(object sender, EventArgs e)
        {
            SwitchListType("Anime", "Watching");
        }

        private void pbSelectSeries_Click(object sender, EventArgs e)
        {
            SwitchListType("Series", "Watching");
        }


        private void pbSelectGame_Click(object sender, EventArgs e)
        {
            SwitchListType("Game", "Playing");
        }

        private void SwitchListType(string type, string group)
        {
            fpListItemPanel.VerticalScroll.Value = 0;
            activeListType = type;
            activeGroup = group;
            if (isFiltered) isFiltered = !isFiltered;
            CheckFilters();
            WireUpLibraryForm();
        }

        private void flowLayoutPanel1_Click(object sender, EventArgs e)
        {
            fpListItemPanel.Focus();
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

            CheckFilters();

            if (!isFiltered)
            {
                if (activeGroup == "All")
                    activeGroup = (activeListType == "Game") ? "Playing" : "Watching";
                WireUpLibraryForm();
            }

            txbTitleSearch.Focus();
        }

        private void CheckFilters()
        {
            if (isFiltered)
            {
                ShowFilterControls();
            }
            else
            {
                HideFilterControls();
            }
        }

        private void ShowFilterControls()
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
            else if (activeListType == "Series")
            {
                chFinishedSearch.Enabled = true;
                chFinishedSearch.Visible = true;
            }
            else if (activeListType == "Game")
            {
                chOwnedSearch.Enabled = true;
                chOwnedSearch.Visible = true;
            }
            pbSearch.Enabled = true;
            pbSearch.Visible = true;
        }

        private void HideFilterControls()
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
            chDubbedSearch.Enabled = false;
            chDubbedSearch.Visible = false;
            chDubbedSearch.CheckState = CheckState.Indeterminate;
            chFinishedSearch.Enabled = false;
            chFinishedSearch.Visible = false;
            chFinishedSearch.CheckState = CheckState.Indeterminate;
            chOwnedSearch.Enabled = false;
            chOwnedSearch.Visible = false;
            chOwnedSearch.CheckState = CheckState.Indeterminate;
            pbSearch.Enabled = false;
            pbSearch.Visible = false;
        }

        private void pbSorting_Click(object sender, EventArgs e)
        {
            isAscending = !isAscending;
            pbToggleSorting.Image = isAscending ? Resources.sort_asc : Resources.sort_desc;

            WireUpLibraryForm();
        }

        private void pbSearch_Click(object sender, EventArgs e)
        {
            InitializeFiltering();
        }

        private void InitializeFiltering()
        {
            if (txbYearSearch.Text.All(c => c >= '0' && c <= '9'))
            {
                WireUpLibraryForm();
            }
            else
            {
                MessageBox.Show("Inputs are invalid!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
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
            fpListItemPanel.Focus();
            overlay.Close();

            WireUpLibraryForm();
        }

        private void LibraryUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            SqliteDataAccess.LogLastLogin();
        }

        private void pbSelectAnime_MouseEnter(object sender, EventArgs e)
        {
            IncreasePic(pbSelectAnime);
        }

        private void pbSelectAnime_MouseLeave(object sender, EventArgs e)
        {
            DecreasePic(pbSelectAnime);
        }

        private void pbSelectSeries_MouseEnter(object sender, EventArgs e)
        {
            IncreasePic(pbSelectSeries);
        }

        private void pbSelectSeries_MouseLeave(object sender, EventArgs e)
        {
            DecreasePic(pbSelectSeries);
        }

        private void pbSelectGame_MouseEnter(object sender, EventArgs e)
        {
            IncreasePic(pbSelectGame);
        }

        private void pbSelectGame_MouseLeave(object sender, EventArgs e)
        {
            DecreasePic(pbSelectGame);
        }

        private void pbToggleFilter_MouseEnter(object sender, EventArgs e)
        {
            IncreasePic(pbToggleFilter);
        }

        private void pbToggleFilter_MouseLeave(object sender, EventArgs e)
        {
            DecreasePic(pbToggleFilter);
        }

        private void pbToggleSorting_MouseEnter(object sender, EventArgs e)
        {
            IncreasePic(pbToggleSorting);
        }

        private void pbToggleSorting_MouseLeave(object sender, EventArgs e)
        {
            DecreasePic(pbToggleSorting);
        }

        private void pbSettings_MouseEnter(object sender, EventArgs e)
        {
            IncreasePic(pbSettings);
        }

        private void pbSettings_MouseLeave(object sender, EventArgs e)
        {
            DecreasePic(pbSettings);
        }

        private void pbSearch_MouseEnter(object sender, EventArgs e)
        {
            IncreasePic(pbSearch);
        }

        private void pbSearch_MouseLeave(object sender, EventArgs e)
        {
            DecreasePic(pbSearch);
        }

        private void DecreasePic(PictureBox pb)
        {
            pb.Size = new Size(pb.Width - 2, pb.Height - 2);
            pb.Location = new Point(pb.Location.X + 1, pb.Location.Y + 1);
        }

        private void IncreasePic(PictureBox pb)
        {
            pb.Size = new Size(pb.Width + 2, pb.Height + 2);
            pb.Location = new Point(pb.Location.X - 1, pb.Location.Y - 1);
        }

        private void txbTitleSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InitializeFiltering();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txbYearSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InitializeFiltering();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}
