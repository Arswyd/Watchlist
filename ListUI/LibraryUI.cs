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
using ListItem = ListUI.ListItems.ListItem;

namespace ListUI
{
    public partial class LibraryUI : Form
    {
        public List<HeaderModel> headerList;
        public List<ItemModel> itemlist = new List<ItemModel>();
        private List<int> randomItemIDList = new List<int>();
        private string activeGroup;
        private string activeListType;
        private string lastActiveGroup;
        private string lastActiveListType;
        private bool lastIsFiltered;
        bool isPrimaryClient = false;
        bool isFiltered = false;
        bool isAscending = false;
        bool wasRandom = false;
        int currentPage = 1;
        int pageCount = 1;
        Random random = new Random();

        public LibraryUI(string listType, bool isPrimaryClient)
        {
            InitializeComponent();

            SetIsPrimaryClient(isPrimaryClient);

            activeListType = listType;

            activeGroup = (activeListType == "Game") ? "Playing" : "Watching";

            rbScore.Checked = true;

            WireUpLibraryForm(true, false);
        }

        /* Get/Set isPrimaryClient */

        public void SetIsPrimaryClient(bool _isPrimaryClient)
        {
            isPrimaryClient = _isPrimaryClient;

            pbAddItem.Enabled = _isPrimaryClient;
            pbAddItem.Visible = _isPrimaryClient;
        }

        public bool GetIsPrimaryClient()
        {
            return isPrimaryClient;
        }

        /* Wire up form */

        public void WireUpLibraryForm(bool refreshMenu, bool loadRandom)
        {
            if (refreshMenu)
                CreateMenuItems();
            LoadItemList(loadRandom);
            fpListHeaderPanel.Refresh();
            InitializeMainFlowlayoutPopulation();
            fpListItemPanel.Focus();
            CheckButtons();
            SetupFilterControls();
            lbPages.Text = currentPage.ToString() + " / " + pageCount.ToString();
            if (!loadRandom)
                randomItemIDList.Clear();
        }

        /* Populating the menu flowlayout with the menu */

        public void CreateMenuItems()
        {
            for (int i = fpListHeaderPanel.Controls.Count - 1; i >= 0; --i)
            {
                fpListHeaderPanel.Controls[i].Dispose();
            }
            fpListHeaderPanel.Controls.Clear();

            if (activeListType == "Anime")
                headerList = SqliteDataAccess.LoadAnimeListHeaders();
            else if (activeListType == "Game")
                headerList = SqliteDataAccess.LoadGameListHeaders();
            else if (activeListType == "Series")
                headerList = SqliteDataAccess.LoadSeriesListHeaders();

            ListMenuItem allMenuItem = new ListMenuItem(activeGroup, this);
            allMenuItem.MenuItemName("All");
            allMenuItem.MenuItemCount(headerList.Where(n => n.ListGroup != "Completed").Sum(n => n.Count).ToString());
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

        /* List loading */

        public void LoadItemList(bool loadRandom)
        {
            if (loadRandom && randomItemIDList.Count == 0)
            {
                randomItemIDList.AddRange(SqliteDataAccess.LoadIDGroup(CreateRandomSqlString()));
            }

            itemlist.Clear();

            if (loadRandom)
            {

                int randomID = randomItemIDList[random.Next(0, randomItemIDList.Count - 1)];

                switch (activeListType)
                {
                    case "Anime":
                        itemlist.Add(SqliteDataAccess.LoadAnimeByID(randomID));
                        break;
                    case "Game":
                        itemlist.Add(SqliteDataAccess.LoadGameByID(randomID));
                        break;
                    case "Series":
                        itemlist.Add(SqliteDataAccess.LoadSeriesByID(randomID));
                        break;
                }

                randomItemIDList.Remove(randomID);

                pageCount = 1;
                wasRandom = true;
            }
            else
            {
                switch (activeListType)
                {
                    case "Anime":
                        itemlist.AddRange(SqliteDataAccess.LoadAnimeGroup(CreateFilteredSqlString()));
                        break;
                    case "Game":
                        itemlist.AddRange(SqliteDataAccess.LoadGameGroup(CreateFilteredSqlString()));
                        break;
                    case "Series":
                        itemlist.AddRange(SqliteDataAccess.LoadSeriesGroup(CreateFilteredSqlString()));
                        break;
                }

                if (activeGroup != lastActiveGroup || activeListType != lastActiveListType || isFiltered != lastIsFiltered || wasRandom)
                    pageCount = (int)Math.Ceiling(SqliteDataAccess.LoadGroupCount(CreateFilteredSqlCountString()) / 60.0);

                lastActiveGroup = activeGroup;
                lastActiveListType = activeListType;
                lastIsFiltered = isFiltered;
                wasRandom = false;
            }
        }

        private string CreateFilteredSqlCountString()
        {
            if (activeListType == "Anime")
            {
                return "SELECT COUNT(*) FROM Anime AS A" + CreateWhereString(false);
            }
            if (activeListType == "Game")
            {
                return "SELECT COUNT(*) FROM Games AS G" + CreateWhereString(false);
            }
            if (activeListType == "Series")
            {
                return "SELECT COUNT(*) FROM Series AS S" + CreateWhereString(false);
            }
            else
            {
                return "";
            }
        }

        private string CreateFilteredSqlString()
        {
            if (activeListType == "Anime")
            {
                return "SELECT A.ID, A.Title, A.Url, A.PictureUrl, A.PicFormat, A.Score, A.Year, A.Favourite, A.Notes, A.ListGroup, A.Season, A.TotalEp, A.WatchedEp, A.Dubbed " +
                       "FROM Anime AS A" + CreateWhereString(true);
            }
            if (activeListType == "Game")
            {
                return "SELECT G.ID, G.Title, G.Url, G.PictureUrl, G.PicFormat, G.Score, G.Year, G.Favourite, G.Notes, G.ListGroup, G.Platform, G.Owned, G.Lenght " +
                       "FROM Games AS G" + CreateWhereString(true);
            }
            if (activeListType == "Series")
            {
                return "SELECT S.ID, S.Title, S.Url, S.PictureUrl, S.PicFormat, S.Score, S.Year, S.Favourite, S.Notes, S.ListGroup, S.Platform, S.TotalSe, S.CurrentSe, S.TotalEp, S.WatchedEp, S.FinishedRunning " +
                       "FROM Series AS S" + CreateWhereString(true);
            }
            else
            {
                return "";
            }
        }

        private string CreateRandomSqlString()
        {
            if (activeListType == "Anime")
            {
                return "SELECT A.ID FROM Anime AS A" + CreateWhereString(false);
            }
            if (activeListType == "Game")
            {
                return "SELECT G.ID FROM Games AS G" + CreateWhereString(false);
            }
            if (activeListType == "Series")
            {
                return "SELECT S.ID FROM Series AS S" + CreateWhereString(false);
            }
            else
            {
                return "";
            }
        }

        private string CreateWhereString(bool hasOrderAndPaging)
        {
            string c = "";
            string sWhere = " WHERE (1=1)";

            if (activeListType == "Anime")
                c = "A";
            else if (activeListType == "Game")
                c = "G";
            else if (activeListType == "Series")
                c = "S";

            if (activeGroup != "All")
            {
                sWhere = sWhere + " AND ListGroup = '" + activeGroup + "'";
            }
            else
            {
                sWhere = sWhere + " AND NOT ListGroup = 'Completed'";
            }

            if (isFiltered)
            {
                if (txbTitleSearch.Text != "")
                    sWhere = sWhere + " AND " + c + ".Title LIKE '%" + txbTitleSearch.Text.Replace("'", "'+CHAR(39)+'") + "%'";
                if (txbYearSearch.Text != "")
                    sWhere = sWhere + " AND " + c + ".Year =" + Convert.ToInt32(txbYearSearch.Text);
                if (chFavouriteSearch.CheckState == CheckState.Checked)
                    sWhere = sWhere + " AND " + c + ".Favourite = 1";
                if (activeListType == "Anime")
                {
                    if (cbSeasonPlatformSearch.Text != "")
                        sWhere = sWhere + " AND " + c + ".Season = '" + cbSeasonPlatformSearch.Text + "'";

                    if (chFinOwnDubSearch.CheckState == CheckState.Checked)
                        sWhere = sWhere + " AND " + c + ".Dubbed = 1";
                    else if (chFinOwnDubSearch.CheckState == CheckState.Unchecked)
                        sWhere = sWhere + " AND " + c + ".Dubbed = 0";
                }
                if (activeListType == "Series")
                {
                    if (cbSeasonPlatformSearch.Text != "")
                        sWhere = sWhere + " AND " + c + ".Platform = '" + cbSeasonPlatformSearch.Text + "'";

                    if (chFinOwnDubSearch.CheckState == CheckState.Checked)
                        sWhere = sWhere + " AND " + c + ".FinishedRunning = 1";
                    else if (chFinOwnDubSearch.CheckState == CheckState.Unchecked)
                        sWhere = sWhere + " AND " + c + ".FinishedRunning = 0";
                }
                if (activeListType == "Game")
                {
                    if (cbSeasonPlatformSearch.Text != "")
                        sWhere = sWhere + " AND " + c + ".Platform = '" + cbSeasonPlatformSearch.Text + "'";

                    if (chFinOwnDubSearch.CheckState == CheckState.Checked)
                        sWhere = sWhere + " AND " + c + ".Owned = 1";
                    else if (chFinOwnDubSearch.CheckState == CheckState.Unchecked)
                        sWhere = sWhere + " AND " + c + ".Owned = 0";
                }
            }

            if (hasOrderAndPaging)
            { 
                if (rbScore.Checked)
                {
                    if (isAscending)
                        sWhere = sWhere + " ORDER BY " + c + ".Score ASC, " + c + ".Title ASC";
                    else
                        sWhere = sWhere + " ORDER BY " + c + ".Score DESC, " + c + ".Title ASC";
                }
                else if (rbTitle.Checked)
                {
                    if (isAscending)
                        sWhere = sWhere + " ORDER BY " + c + ".Title ASC";
                    else
                        sWhere = sWhere + " ORDER BY " + c + ".Title DESC";
                }

                sWhere = sWhere + " LIMIT 60 OFFSET " + (currentPage - 1) * 60;
            }

            return sWhere;
        }


        /* Populating the main flowlayout with the items */

        public void InitializeMainFlowlayoutPopulation()
        {
            int yscroll = fpListItemPanel.AutoScrollPosition.Y;

            for (int i = fpListItemPanel.Controls.Count - 1; i >= 0; --i)
            {
                fpListItemPanel.Controls[i].Dispose();
            }
            fpListItemPanel.Controls.Clear();
            fpListItemPanel.SuspendLayout();

            PopulateMainFlowlayout();

            fpListItemPanel.ResumeLayout();
            fpListItemPanel.AutoScrollPosition = new Point(0, (-1) * yscroll);
            //fpListItemPanel.VerticalScroll.Value = (-1) * yscroll;
        }

        private void PopulateMainFlowlayout()
        {
            progressBar1.Visible = true;
            progressBar1.Value = 0;
            progressBar1.Maximum = itemlist.Count();

            foreach (ItemModel item in itemlist)
            {
                ListItem listItem = new ListItem(this);
                listItem.AddItem(item);
                fpListItemPanel.Controls.Add(listItem);
                progressBar1.PerformStep();
            }

            progressBar1.Visible = false;
        }

        /* Modify item and add new item */

        public void ModifyItem(ItemModel item, ListItem listItem)
        {
            ShowItemDetailForm(activeListType, item, this, listItem);
        }

        private void pbAddItem_Click(object sender, EventArgs e)
        {
            ShowItemDetailForm(activeListType, null, this, null);
        }

        private void ShowItemDetailForm(string activeListType, ItemModel item, LibraryUI libraryUI, ListItem listItem)
        {
            OverlayForm overlay = ShowOverlay();
            ItemDetailForm frm;
            if (item == null)
            {
                frm = new ItemDetailForm(activeListType, libraryUI);
            }
            else
            {
                frm = new ItemDetailForm(activeListType, item, libraryUI, listItem);
            }
            frm.ShowDialog(this);
            frm.Dispose();
            ReturnFocusToFlowlayout();
            overlay.Dispose();
        }

        public OverlayForm ShowOverlay()
        {
            OverlayForm overlay = new OverlayForm();
            overlay.Show(this);
            overlay.Location = new Point(this.Location.X + 8, this.Location.Y + 30);
            return overlay;
        }

        public void ReturnFocusToFlowlayout()
        {
            fpListItemPanel.Focus();
        }

        /*Check buttons*/

        private void CheckButtons()
        {
            pbSelectAnime.Enabled = (activeListType == "Anime") ? false : true;
            pAnime.BackColor = (activeListType == "Anime") ? Color.LightSteelBlue : SystemColors.ActiveCaption;
            pbIndicatorA.BackColor = (activeListType == "Anime") ? Color.White : SystemColors.ActiveCaption;

            pbSelectSeries.Enabled = (activeListType == "Series") ? false : true;
            pSeries.BackColor = (activeListType == "Series") ? Color.LightSteelBlue : SystemColors.ActiveCaption;
            pbIndicatorS.BackColor = (activeListType == "Series") ? Color.White : SystemColors.ActiveCaption;

            pbSelectGame.Enabled = (activeListType == "Game") ? false : true;
            pGames.BackColor = (activeListType == "Game") ? Color.LightSteelBlue : SystemColors.ActiveCaption;
            pbIndicatorG.BackColor = (activeListType == "Game") ? Color.White : SystemColors.ActiveCaption;

            pbFirstPage.Enabled = (currentPage == 1) ? false : true;
            pbFirstPage.Image = (currentPage == 1) ? Resources.first_page_inactive : Resources.first_page;

            pbPreviousPage.Enabled = (currentPage == 1) ? false : true;
            pbPreviousPage.Image = (currentPage == 1) ? Resources.prev_page_inactive : Resources.prev_page;

            pbNextPage.Enabled = (currentPage == pageCount) ? false : true;
            pbNextPage.Image = (currentPage == pageCount) ? Resources.next_page_inactive : Resources.next_page;

            pbLastPage.Enabled = (currentPage == pageCount) ? false : true;
            pbLastPage.Image = (currentPage == pageCount) ? Resources.last_page_inactive : Resources.last_page;

        }

        /* Showing filter controls according to list type */

        private void SetupFilterControls()
        {
            cbSeasonPlatformSearch.Items.Clear();

            if (activeListType == "Anime")
            {
                chFinOwnDubSearch.Text = "Dubbed";
                cbSeasonPlatformSearch.Items.Add("Spring");
                cbSeasonPlatformSearch.Items.Add("Summer");
                cbSeasonPlatformSearch.Items.Add("Fall");
                cbSeasonPlatformSearch.Items.Add("Winter");
                cbSeasonPlatformSearch.Items.Add("-");
            }
            else if(activeListType == "Series")
            {
                chFinOwnDubSearch.Text = "Finished";
                cbSeasonPlatformSearch.Items.Add("Netflix");
                cbSeasonPlatformSearch.Items.Add("HBO");
                cbSeasonPlatformSearch.Items.Add("");
            }
            else if(activeListType == "Game")
            {
                chFinOwnDubSearch.Text = "Owned";
                cbSeasonPlatformSearch.Items.Add("Steam");
                cbSeasonPlatformSearch.Items.Add("Epic");
                cbSeasonPlatformSearch.Items.Add("GoG");
                cbSeasonPlatformSearch.Items.Add("Ubisoft");
                cbSeasonPlatformSearch.Items.Add("");
            }
        }

        /* Wireup request*/

        public void WireUpRequest(string listGroup)
        {
            //fpListItemPanel.VerticalScroll.Value = 0;
            fpListItemPanel.AutoScrollPosition = new Point(0, 0);
            if (activeGroup != listGroup)
            {
                activeGroup = listGroup;
                currentPage = 1;
            }

            WireUpLibraryForm(true, false);
        }

        public void WireUpRequest(ItemModel itemModel)
        {
            if (activeGroup != itemModel.ListGroup)
            {
                CreateMenuItems();
                return;
            }

            if (itemlist.Count < 60)
            {
                fpListItemPanel.AutoScrollPosition = new Point(0, 0);
                WireUpLibraryForm(true, false);
                return;
            }

            ItemModel firstItem = itemlist.First();
            ItemModel lastItem = itemlist.Last();


            if (rbScore.Checked)
            {
                if(isAscending)
                {
                    if(currentPage != 1 && firstItem.Score > itemModel.Score || currentPage != pageCount && lastItem.Score < itemModel.Score || currentPage != 1 && firstItem.Score == itemModel.Score && string.CompareOrdinal(firstItem.Title, itemModel.Title) > 0 || currentPage != pageCount &&  lastItem.Score == itemModel.Score && string.CompareOrdinal(lastItem.Title, itemModel.Title) < 0)
                    {
                        CreateMenuItems();
                        return;
                    }
                    else
                    {
                        fpListItemPanel.AutoScrollPosition = new Point(0, 0);
                        WireUpLibraryForm(true, false);
                    }
                }
                else
                {
                    if (currentPage != 1 && firstItem.Score < itemModel.Score || currentPage != pageCount && lastItem.Score > itemModel.Score || currentPage != 1 && firstItem.Score == itemModel.Score && string.CompareOrdinal(firstItem.Title, itemModel.Title) > 0 || currentPage != pageCount && lastItem.Score == itemModel.Score && string.CompareOrdinal(lastItem.Title, itemModel.Title) < 0)
                    {
                        CreateMenuItems();
                        return;
                    }
                    else
                    {
                        fpListItemPanel.AutoScrollPosition = new Point(0, 0);
                        WireUpLibraryForm(true, false);
                    }
                }
            }
            else if(rbTitle.Checked)
            {
                if (isAscending)
                {
                    if (currentPage != 1 && string.CompareOrdinal(firstItem.Title, itemModel.Title) > 0 || currentPage != pageCount && string.CompareOrdinal(lastItem.Title, itemModel.Title) < 0)
                    {
                        CreateMenuItems();
                        return;
                    }
                    else
                    {
                        fpListItemPanel.AutoScrollPosition = new Point(0, 0);
                        WireUpLibraryForm(true, false);
                    }
                }
                else
                {
                    if (currentPage != 1 && string.CompareOrdinal(firstItem.Title, itemModel.Title) < 0 || currentPage != pageCount && string.CompareOrdinal(lastItem.Title, itemModel.Title) > 0)
                    {
                        CreateMenuItems();
                        return;
                    }
                    else
                    {
                        fpListItemPanel.AutoScrollPosition = new Point(0, 0);
                        WireUpLibraryForm(true, false);
                    }
                }
            }
        }

        /* Switch list type */

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
            //fpListItemPanel.VerticalScroll.Value = 0;
            fpListItemPanel.AutoScrollPosition = new Point(0, 0);
            currentPage = 1;
            activeListType = type;
            activeGroup = group;
            isFiltered = false;

            ClearFilters();
            WireUpLibraryForm(true, false);
        }

        /* Clear filters */

        private void pbFilter_Click(object sender, EventArgs e)
        {
            isFiltered = false;
            currentPage = 1;

            ClearFilters();          
            WireUpLibraryForm(false, false);

            fpListItemPanel.Focus();
        }

        private void ClearFilters()
        {
            pbToggleFilter.Visible = false;
            txbTitleSearch.Text = "";
            txbYearSearch.Text = "";
            cbSeasonPlatformSearch.Text = "";
            lbTitleSearch.Visible = true;
            lbYearSearch.Visible = true;
            chFavouriteSearch.Checked = false;
            chFinOwnDubSearch.CheckState = CheckState.Indeterminate;
        }

        /* Filtering */

        private void pbSearch_Click(object sender, EventArgs e)
        {
            InitializeFiltering();
        }

        private void InitializeFiltering()
        {
            if (txbYearSearch.Text.All(c => c >= '0' && c <= '9'))
            {
                isFiltered = true;
                currentPage = 1;
                pbToggleFilter.Visible = true;
                WireUpLibraryForm(false, false);
            }
            else
            {
                MessageBox.Show("Inputs are invalid!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        /* Show settings form */

        private void pbSettings_Click(object sender, EventArgs e)
        {
            OverlayForm overlay = ShowOverlay();
            SettingsForm frm = new SettingsForm(this, activeListType);
            frm.ShowDialog(this);
            frm.Dispose();
            fpListItemPanel.Focus();

            WireUpLibraryForm(true, false);
            overlay.Dispose();
        }

        /* Switching pages */

        private void pbFirstPage_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage = 1;
                //fpListItemPanel.VerticalScroll.Value = 0;
                fpListItemPanel.AutoScrollPosition = new Point(0, 0);
                WireUpLibraryForm(false, false);
            }
        }

        private void pbPreviousPage_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                //fpListItemPanel.VerticalScroll.Value = 0;
                fpListItemPanel.AutoScrollPosition = new Point(0, 0);
                WireUpLibraryForm(false, false);
            }
        }

        private void pbNextPage_Click(object sender, EventArgs e)
        {
            if (currentPage < pageCount)
            {
                currentPage++;
                //fpListItemPanel.VerticalScroll.Value = 0;
                fpListItemPanel.AutoScrollPosition = new Point(0, 0);
                WireUpLibraryForm(false, false);
            }
        }

        private void pbLastPage_Click(object sender, EventArgs e)
        {
            if (currentPage < pageCount)
            {
                currentPage = pageCount;
                //fpListItemPanel.VerticalScroll.Value = 0;
                fpListItemPanel.AutoScrollPosition = new Point(0, 0);
                WireUpLibraryForm(false, false);
            }
        }

        /* Filter color change OnCheckStateChanged */

        private void chFavouriteSearch_CheckStateChanged(object sender, EventArgs e)
        {
            chFavouriteSearch.ForeColor = (chFavouriteSearch.CheckState == CheckState.Unchecked) ? SystemColors.ControlDarkDark : Color.White;
        }

        private void chFinishedSearch_CheckStateChanged(object sender, EventArgs e)
        {
            chFinOwnDubSearch.ForeColor = (chFinOwnDubSearch.CheckState == CheckState.Indeterminate) ? SystemColors.ControlDarkDark : Color.White;
        }

        /* Sorting */

        private void pbSorting_Click(object sender, EventArgs e)
        {
            isAscending = !isAscending;
            pbOrderBy.Image = isAscending ? Resources.sort_asc : Resources.sort_desc;

            WireUpLibraryForm(false, false);
        }

        private void rbScore_MouseClick(object sender, MouseEventArgs e)
        {
            InitializeSorting();
        }

        private void rbTitle_MouseClick(object sender, MouseEventArgs e)
        {
            InitializeSorting();
        }

        private void InitializeSorting()
        {
            if (rbScore.Checked)
            {
                isAscending = false;
                rbScore.ForeColor = Color.White;
                rbTitle.ForeColor = SystemColors.ControlDarkDark;
                pbOrderBy.Image = Resources.sort_desc;
            }
            if (rbTitle.Checked)
            {
                isAscending = true;
                rbTitle.ForeColor = Color.White;
                rbScore.ForeColor = SystemColors.ControlDarkDark;
                pbOrderBy.Image = Resources.sort_asc;
            }
            WireUpLibraryForm(false, false);
        }

        // Increase/Decrease button size OnMouseEnter/Leave

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

        private void pbAddItem_MouseEnter(object sender, EventArgs e)
        {
            IncreasePic(pbAddItem);
        }

        private void pbAddItem_MouseLeave(object sender, EventArgs e)
        {
            DecreasePic(pbAddItem);
        }

        private void pbFirstPage_MouseEnter(object sender, EventArgs e)
        {
            IncreasePic(pbFirstPage);
        }

        private void pbFirstPage_MouseLeave(object sender, EventArgs e)
        {
            DecreasePic(pbFirstPage);
        }

        private void pbPreviousPage_MouseEnter(object sender, EventArgs e)
        {
            IncreasePic(pbPreviousPage);
        }

        private void pbPreviousPage_MouseLeave(object sender, EventArgs e)
        {
            DecreasePic(pbPreviousPage);
        }

        private void pbNextPage_MouseEnter(object sender, EventArgs e)
        {
            IncreasePic(pbNextPage);
        }

        private void pbNextPage_MouseLeave(object sender, EventArgs e)
        {
            DecreasePic(pbNextPage);
        }

        private void pbLastPage_MouseEnter(object sender, EventArgs e)
        {
            IncreasePic(pbLastPage);
        }

        private void pbLastPage_MouseLeave(object sender, EventArgs e)
        {
            DecreasePic(pbLastPage);
        }

        private void pbRandom_MouseEnter(object sender, EventArgs e)
        {
            IncreasePic(pbRandom);
        }

        private void pbRandom_MouseLeave(object sender, EventArgs e)
        {
            DecreasePic(pbRandom);
        }

        private void flowLayoutPanel1_Click(object sender, EventArgs e)
        {
            fpListItemPanel.Focus();
        }

        /* Title search events */

        private void txbTitleSearch_Enter(object sender, EventArgs e)
        {
            lbTitleSearch.Visible = false;
        }

        private void txbTitleSearch_Leave(object sender, EventArgs e)
        {
            if (txbTitleSearch.Text == "")
            {
                lbTitleSearch.Visible = true;
            }
        }

        private void lbTitleSearch_MouseClick(object sender, MouseEventArgs e)
        {
            txbTitleSearch.Focus();
        }

        private void txbTitleSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InitializeFiltering();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.Escape)
            {
                txbTitleSearch.Text = "";
                fpListItemPanel.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        /* Year search events */

        private void txbYearSearch_Enter(object sender, EventArgs e)
        {
            lbYearSearch.Visible = false;
        }

        private void txbYearSearch_Leave(object sender, EventArgs e)
        {
            if (txbYearSearch.Text == "")
            {
                lbYearSearch.Visible = true;
            }
        }

        private void lbYearSearch_MouseClick(object sender, MouseEventArgs e)
        {
            txbYearSearch.Focus();
        }

        private void txbYearSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InitializeFiltering();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.Escape)
            {
                txbYearSearch.Text = "";
                fpListItemPanel.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        /* Random item wire up form */

        private void pbRandom_Click(object sender, EventArgs e)
        {
            WireUpLibraryForm(false, true);
        }
    }
}
