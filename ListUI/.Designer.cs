namespace ListUI
{
    partial class LibraryUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LibraryUI));
            this.fpListItemPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.txbTitleSearch = new System.Windows.Forms.TextBox();
            this.fpListHeaderPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbPages = new System.Windows.Forms.Label();
            this.pbLastPage = new System.Windows.Forms.PictureBox();
            this.pbNextPage = new System.Windows.Forms.PictureBox();
            this.pbPreviousPage = new System.Windows.Forms.PictureBox();
            this.pbFirstPage = new System.Windows.Forms.PictureBox();
            this.chOwnedSearch = new System.Windows.Forms.CheckBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.pbOrderBy = new System.Windows.Forms.PictureBox();
            this.pbSearch = new System.Windows.Forms.PictureBox();
            this.pbToggleFilter = new System.Windows.Forms.PictureBox();
            this.cbOrderBy = new System.Windows.Forms.ComboBox();
            this.chDubbedSearch = new System.Windows.Forms.CheckBox();
            this.chFavouriteSearch = new System.Windows.Forms.CheckBox();
            this.lbYearSearch = new System.Windows.Forms.Label();
            this.lbTitleSearch = new System.Windows.Forms.Label();
            this.txbYearSearch = new System.Windows.Forms.TextBox();
            this.chFinishedSearch = new System.Windows.Forms.CheckBox();
            this.pbSelectGame = new System.Windows.Forms.PictureBox();
            this.pbSelectSeries = new System.Windows.Forms.PictureBox();
            this.pbSelectAnime = new System.Windows.Forms.PictureBox();
            this.pbSettings = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pbAddItem = new System.Windows.Forms.PictureBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLastPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNextPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreviousPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFirstPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOrderBy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbToggleFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSelectGame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSelectSeries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSelectAnime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSettings)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAddItem)).BeginInit();
            this.SuspendLayout();
            // 
            // fpListItemPanel
            // 
            this.fpListItemPanel.AutoScroll = true;
            this.fpListItemPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.fpListItemPanel.Location = new System.Drawing.Point(0, 72);
            this.fpListItemPanel.Margin = new System.Windows.Forms.Padding(0);
            this.fpListItemPanel.Name = "fpListItemPanel";
            this.fpListItemPanel.Size = new System.Drawing.Size(1155, 621);
            this.fpListItemPanel.TabIndex = 2;
            this.fpListItemPanel.Click += new System.EventHandler(this.flowLayoutPanel1_Click);
            // 
            // txbTitleSearch
            // 
            this.txbTitleSearch.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txbTitleSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txbTitleSearch.ForeColor = System.Drawing.SystemColors.Control;
            this.txbTitleSearch.Location = new System.Drawing.Point(84, 16);
            this.txbTitleSearch.Name = "txbTitleSearch";
            this.txbTitleSearch.Size = new System.Drawing.Size(200, 26);
            this.txbTitleSearch.TabIndex = 5;
            this.txbTitleSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbTitleSearch_KeyDown);
            // 
            // fpListHeaderPanel
            // 
            this.fpListHeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.fpListHeaderPanel.Location = new System.Drawing.Point(73, 0);
            this.fpListHeaderPanel.Name = "fpListHeaderPanel";
            this.fpListHeaderPanel.Size = new System.Drawing.Size(199, 761);
            this.fpListHeaderPanel.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.panel2.Controls.Add(this.lbPages);
            this.panel2.Controls.Add(this.pbLastPage);
            this.panel2.Controls.Add(this.pbNextPage);
            this.panel2.Controls.Add(this.pbPreviousPage);
            this.panel2.Controls.Add(this.pbFirstPage);
            this.panel2.Controls.Add(this.chOwnedSearch);
            this.panel2.Controls.Add(this.progressBar1);
            this.panel2.Controls.Add(this.fpListItemPanel);
            this.panel2.Controls.Add(this.pbOrderBy);
            this.panel2.Controls.Add(this.pbSearch);
            this.panel2.Controls.Add(this.pbToggleFilter);
            this.panel2.Controls.Add(this.cbOrderBy);
            this.panel2.Controls.Add(this.chDubbedSearch);
            this.panel2.Controls.Add(this.chFavouriteSearch);
            this.panel2.Controls.Add(this.lbYearSearch);
            this.panel2.Controls.Add(this.lbTitleSearch);
            this.panel2.Controls.Add(this.txbYearSearch);
            this.panel2.Controls.Add(this.txbTitleSearch);
            this.panel2.Controls.Add(this.chFinishedSearch);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(278, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1170, 761);
            this.panel2.TabIndex = 6;
            // 
            // lbPages
            // 
            this.lbPages.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbPages.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lbPages.Location = new System.Drawing.Point(526, 717);
            this.lbPages.Name = "lbPages";
            this.lbPages.Size = new System.Drawing.Size(85, 26);
            this.lbPages.TabIndex = 29;
            this.lbPages.Text = "99 / 99";
            this.lbPages.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbLastPage
            // 
            this.pbLastPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbLastPage.Image = global::ListUI.Properties.Resources.last_page;
            this.pbLastPage.Location = new System.Drawing.Point(663, 709);
            this.pbLastPage.Name = "pbLastPage";
            this.pbLastPage.Size = new System.Drawing.Size(40, 40);
            this.pbLastPage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLastPage.TabIndex = 28;
            this.pbLastPage.TabStop = false;
            this.pbLastPage.Click += new System.EventHandler(this.pbLastPage_Click);
            // 
            // pbNextPage
            // 
            this.pbNextPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbNextPage.Image = global::ListUI.Properties.Resources.next_page;
            this.pbNextPage.Location = new System.Drawing.Point(617, 709);
            this.pbNextPage.Name = "pbNextPage";
            this.pbNextPage.Size = new System.Drawing.Size(40, 40);
            this.pbNextPage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbNextPage.TabIndex = 27;
            this.pbNextPage.TabStop = false;
            this.pbNextPage.Click += new System.EventHandler(this.pbNextPage_Click);
            // 
            // pbPreviousPage
            // 
            this.pbPreviousPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbPreviousPage.Image = global::ListUI.Properties.Resources.prev_page;
            this.pbPreviousPage.Location = new System.Drawing.Point(480, 709);
            this.pbPreviousPage.Name = "pbPreviousPage";
            this.pbPreviousPage.Size = new System.Drawing.Size(40, 40);
            this.pbPreviousPage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPreviousPage.TabIndex = 26;
            this.pbPreviousPage.TabStop = false;
            this.pbPreviousPage.Click += new System.EventHandler(this.pbPreviousPage_Click);
            // 
            // pbFirstPage
            // 
            this.pbFirstPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbFirstPage.Image = global::ListUI.Properties.Resources.first_page;
            this.pbFirstPage.Location = new System.Drawing.Point(434, 709);
            this.pbFirstPage.Name = "pbFirstPage";
            this.pbFirstPage.Size = new System.Drawing.Size(40, 40);
            this.pbFirstPage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFirstPage.TabIndex = 25;
            this.pbFirstPage.TabStop = false;
            this.pbFirstPage.Click += new System.EventHandler(this.pbFirstPage_Click);
            // 
            // chOwnedSearch
            // 
            this.chOwnedSearch.AutoSize = true;
            this.chOwnedSearch.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chOwnedSearch.Checked = true;
            this.chOwnedSearch.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chOwnedSearch.Enabled = false;
            this.chOwnedSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chOwnedSearch.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.chOwnedSearch.Location = new System.Drawing.Point(574, 18);
            this.chOwnedSearch.Name = "chOwnedSearch";
            this.chOwnedSearch.Size = new System.Drawing.Size(105, 30);
            this.chOwnedSearch.TabIndex = 23;
            this.chOwnedSearch.Text = "Owned";
            this.chOwnedSearch.ThreeState = true;
            this.chOwnedSearch.UseVisualStyleBackColor = true;
            this.chOwnedSearch.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.progressBar1.Location = new System.Drawing.Point(0, 0);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1357, 3);
            this.progressBar1.TabIndex = 22;
            this.progressBar1.Visible = false;
            // 
            // pbOrderBy
            // 
            this.pbOrderBy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbOrderBy.Image = global::ListUI.Properties.Resources.sort_desc;
            this.pbOrderBy.Location = new System.Drawing.Point(1128, 12);
            this.pbOrderBy.Name = "pbOrderBy";
            this.pbOrderBy.Size = new System.Drawing.Size(30, 30);
            this.pbOrderBy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbOrderBy.TabIndex = 19;
            this.pbOrderBy.TabStop = false;
            this.pbOrderBy.Click += new System.EventHandler(this.pbSorting_Click);
            // 
            // pbSearch
            // 
            this.pbSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbSearch.Image = global::ListUI.Properties.Resources.search;
            this.pbSearch.Location = new System.Drawing.Point(829, 16);
            this.pbSearch.Name = "pbSearch";
            this.pbSearch.Size = new System.Drawing.Size(30, 30);
            this.pbSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSearch.TabIndex = 18;
            this.pbSearch.TabStop = false;
            this.pbSearch.Click += new System.EventHandler(this.pbSearch_Click);
            this.pbSearch.MouseEnter += new System.EventHandler(this.pbSearch_MouseEnter);
            this.pbSearch.MouseLeave += new System.EventHandler(this.pbSearch_MouseLeave);
            // 
            // pbToggleFilter
            // 
            this.pbToggleFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbToggleFilter.Image = global::ListUI.Properties.Resources.clear_filter;
            this.pbToggleFilter.Location = new System.Drawing.Point(865, 12);
            this.pbToggleFilter.Name = "pbToggleFilter";
            this.pbToggleFilter.Size = new System.Drawing.Size(40, 40);
            this.pbToggleFilter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbToggleFilter.TabIndex = 17;
            this.pbToggleFilter.TabStop = false;
            this.pbToggleFilter.Visible = false;
            this.pbToggleFilter.Click += new System.EventHandler(this.pbFilter_Click);
            this.pbToggleFilter.MouseEnter += new System.EventHandler(this.pbToggleFilter_MouseEnter);
            this.pbToggleFilter.MouseLeave += new System.EventHandler(this.pbToggleFilter_MouseLeave);
            // 
            // cbOrderBy
            // 
            this.cbOrderBy.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.cbOrderBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbOrderBy.FormattingEnabled = true;
            this.cbOrderBy.Location = new System.Drawing.Point(1042, 12);
            this.cbOrderBy.Name = "cbOrderBy";
            this.cbOrderBy.Size = new System.Drawing.Size(80, 28);
            this.cbOrderBy.TabIndex = 4;
            this.cbOrderBy.SelectionChangeCommitted += new System.EventHandler(this.cbOrderBy_SelectionChangeCommitted);
            // 
            // chDubbedSearch
            // 
            this.chDubbedSearch.AutoSize = true;
            this.chDubbedSearch.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chDubbedSearch.Checked = true;
            this.chDubbedSearch.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chDubbedSearch.Enabled = false;
            this.chDubbedSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chDubbedSearch.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.chDubbedSearch.Location = new System.Drawing.Point(574, 18);
            this.chDubbedSearch.Name = "chDubbedSearch";
            this.chDubbedSearch.Size = new System.Drawing.Size(113, 30);
            this.chDubbedSearch.TabIndex = 8;
            this.chDubbedSearch.Text = "Dubbed";
            this.chDubbedSearch.ThreeState = true;
            this.chDubbedSearch.UseVisualStyleBackColor = true;
            this.chDubbedSearch.Visible = false;
            // 
            // chFavouriteSearch
            // 
            this.chFavouriteSearch.AutoSize = true;
            this.chFavouriteSearch.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chFavouriteSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chFavouriteSearch.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.chFavouriteSearch.Location = new System.Drawing.Point(434, 16);
            this.chFavouriteSearch.Name = "chFavouriteSearch";
            this.chFavouriteSearch.Size = new System.Drawing.Size(130, 30);
            this.chFavouriteSearch.TabIndex = 7;
            this.chFavouriteSearch.Text = "Favourite";
            this.chFavouriteSearch.UseVisualStyleBackColor = true;
            // 
            // lbYearSearch
            // 
            this.lbYearSearch.AutoSize = true;
            this.lbYearSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbYearSearch.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lbYearSearch.Location = new System.Drawing.Point(289, 16);
            this.lbYearSearch.Name = "lbYearSearch";
            this.lbYearSearch.Size = new System.Drawing.Size(70, 26);
            this.lbYearSearch.TabIndex = 11;
            this.lbYearSearch.Text = "Year:";
            // 
            // lbTitleSearch
            // 
            this.lbTitleSearch.AutoSize = true;
            this.lbTitleSearch.BackColor = System.Drawing.Color.Transparent;
            this.lbTitleSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbTitleSearch.ForeColor = System.Drawing.SystemColors.Control;
            this.lbTitleSearch.Location = new System.Drawing.Point(14, 16);
            this.lbTitleSearch.Name = "lbTitleSearch";
            this.lbTitleSearch.Size = new System.Drawing.Size(64, 26);
            this.lbTitleSearch.TabIndex = 10;
            this.lbTitleSearch.Text = "Title:";
            // 
            // txbYearSearch
            // 
            this.txbYearSearch.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txbYearSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txbYearSearch.ForeColor = System.Drawing.SystemColors.Control;
            this.txbYearSearch.Location = new System.Drawing.Point(364, 16);
            this.txbYearSearch.MaxLength = 4;
            this.txbYearSearch.Name = "txbYearSearch";
            this.txbYearSearch.Size = new System.Drawing.Size(60, 26);
            this.txbYearSearch.TabIndex = 6;
            this.txbYearSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txbYearSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbYearSearch_KeyDown);
            // 
            // chFinishedSearch
            // 
            this.chFinishedSearch.AutoSize = true;
            this.chFinishedSearch.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chFinishedSearch.Checked = true;
            this.chFinishedSearch.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chFinishedSearch.Enabled = false;
            this.chFinishedSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chFinishedSearch.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.chFinishedSearch.Location = new System.Drawing.Point(574, 18);
            this.chFinishedSearch.Name = "chFinishedSearch";
            this.chFinishedSearch.Size = new System.Drawing.Size(121, 30);
            this.chFinishedSearch.TabIndex = 9;
            this.chFinishedSearch.Text = "Finished";
            this.chFinishedSearch.UseVisualStyleBackColor = true;
            this.chFinishedSearch.Visible = false;
            // 
            // pbSelectGame
            // 
            this.pbSelectGame.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbSelectGame.Image = global::ListUI.Properties.Resources.game;
            this.pbSelectGame.Location = new System.Drawing.Point(12, 144);
            this.pbSelectGame.Name = "pbSelectGame";
            this.pbSelectGame.Size = new System.Drawing.Size(50, 50);
            this.pbSelectGame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSelectGame.TabIndex = 26;
            this.pbSelectGame.TabStop = false;
            this.pbSelectGame.Click += new System.EventHandler(this.pbSelectGame_Click);
            this.pbSelectGame.MouseEnter += new System.EventHandler(this.pbSelectGame_MouseEnter);
            this.pbSelectGame.MouseLeave += new System.EventHandler(this.pbSelectGame_MouseLeave);
            // 
            // pbSelectSeries
            // 
            this.pbSelectSeries.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbSelectSeries.Image = global::ListUI.Properties.Resources.series;
            this.pbSelectSeries.Location = new System.Drawing.Point(12, 78);
            this.pbSelectSeries.Name = "pbSelectSeries";
            this.pbSelectSeries.Size = new System.Drawing.Size(50, 50);
            this.pbSelectSeries.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSelectSeries.TabIndex = 25;
            this.pbSelectSeries.TabStop = false;
            this.pbSelectSeries.Click += new System.EventHandler(this.pbSelectSeries_Click);
            this.pbSelectSeries.MouseEnter += new System.EventHandler(this.pbSelectSeries_MouseEnter);
            this.pbSelectSeries.MouseLeave += new System.EventHandler(this.pbSelectSeries_MouseLeave);
            // 
            // pbSelectAnime
            // 
            this.pbSelectAnime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbSelectAnime.Image = global::ListUI.Properties.Resources.anime;
            this.pbSelectAnime.Location = new System.Drawing.Point(12, 12);
            this.pbSelectAnime.Name = "pbSelectAnime";
            this.pbSelectAnime.Size = new System.Drawing.Size(50, 50);
            this.pbSelectAnime.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSelectAnime.TabIndex = 24;
            this.pbSelectAnime.TabStop = false;
            this.pbSelectAnime.Click += new System.EventHandler(this.pbSelectAnime_Click);
            this.pbSelectAnime.MouseEnter += new System.EventHandler(this.pbSelectAnime_MouseEnter);
            this.pbSelectAnime.MouseLeave += new System.EventHandler(this.pbSelectAnime_MouseLeave);
            // 
            // pbSettings
            // 
            this.pbSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbSettings.Image = global::ListUI.Properties.Resources.settings;
            this.pbSettings.Location = new System.Drawing.Point(12, 699);
            this.pbSettings.Name = "pbSettings";
            this.pbSettings.Size = new System.Drawing.Size(50, 50);
            this.pbSettings.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSettings.TabIndex = 20;
            this.pbSettings.TabStop = false;
            this.pbSettings.Click += new System.EventHandler(this.pbSettings_Click);
            this.pbSettings.MouseEnter += new System.EventHandler(this.pbSettings_MouseEnter);
            this.pbSettings.MouseLeave += new System.EventHandler(this.pbSettings_MouseLeave);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pbAddItem);
            this.panel3.Controls.Add(this.pbSelectGame);
            this.panel3.Controls.Add(this.pbSelectAnime);
            this.panel3.Controls.Add(this.pbSelectSeries);
            this.panel3.Controls.Add(this.pbSettings);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(73, 761);
            this.panel3.TabIndex = 7;
            // 
            // pbAddItem
            // 
            this.pbAddItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbAddItem.Image = global::ListUI.Properties.Resources.add_item;
            this.pbAddItem.Location = new System.Drawing.Point(12, 643);
            this.pbAddItem.Name = "pbAddItem";
            this.pbAddItem.Size = new System.Drawing.Size(50, 50);
            this.pbAddItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAddItem.TabIndex = 29;
            this.pbAddItem.TabStop = false;
            this.pbAddItem.Click += new System.EventHandler(this.pbAddItem_Click);
            // 
            // LibraryUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1448, 761);
            this.Controls.Add(this.fpListHeaderPanel);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "LibraryUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "My Little Library";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLastPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNextPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreviousPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFirstPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOrderBy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbToggleFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSelectGame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSelectSeries)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSelectAnime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSettings)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbAddItem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel fpListItemPanel;
        private System.Windows.Forms.TextBox txbTitleSearch;
        private System.Windows.Forms.FlowLayoutPanel fpListHeaderPanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cbOrderBy;
        private System.Windows.Forms.CheckBox chFinishedSearch;
        private System.Windows.Forms.CheckBox chDubbedSearch;
        private System.Windows.Forms.CheckBox chFavouriteSearch;
        private System.Windows.Forms.Label lbYearSearch;
        private System.Windows.Forms.Label lbTitleSearch;
        private System.Windows.Forms.TextBox txbYearSearch;
        private System.Windows.Forms.PictureBox pbToggleFilter;
        private System.Windows.Forms.PictureBox pbOrderBy;
        private System.Windows.Forms.PictureBox pbSearch;
        private System.Windows.Forms.PictureBox pbSettings;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.CheckBox chOwnedSearch;
        private System.Windows.Forms.PictureBox pbSelectGame;
        private System.Windows.Forms.PictureBox pbSelectSeries;
        private System.Windows.Forms.PictureBox pbSelectAnime;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pbLastPage;
        private System.Windows.Forms.PictureBox pbNextPage;
        private System.Windows.Forms.PictureBox pbPreviousPage;
        private System.Windows.Forms.PictureBox pbFirstPage;
        private System.Windows.Forms.PictureBox pbAddItem;
        private System.Windows.Forms.Label lbPages;
    }
}

