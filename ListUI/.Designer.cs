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
            this.addButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pbSelectGame = new System.Windows.Forms.PictureBox();
            this.pbSelectSeries = new System.Windows.Forms.PictureBox();
            this.pbSelectAnime = new System.Windows.Forms.PictureBox();
            this.chOwnedSearch = new System.Windows.Forms.CheckBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.pbToggleSorting = new System.Windows.Forms.PictureBox();
            this.pbSettings = new System.Windows.Forms.PictureBox();
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
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSelectGame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSelectSeries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSelectAnime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbToggleSorting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSettings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOrderBy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbToggleFilter)).BeginInit();
            this.SuspendLayout();
            // 
            // fpListItemPanel
            // 
            this.fpListItemPanel.AutoScroll = true;
            this.fpListItemPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.fpListItemPanel.Location = new System.Drawing.Point(202, 72);
            this.fpListItemPanel.Name = "fpListItemPanel";
            this.fpListItemPanel.Size = new System.Drawing.Size(1152, 689);
            this.fpListItemPanel.TabIndex = 2;
            this.fpListItemPanel.Click += new System.EventHandler(this.flowLayoutPanel1_Click);
            // 
            // txbTitleSearch
            // 
            this.txbTitleSearch.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txbTitleSearch.Enabled = false;
            this.txbTitleSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txbTitleSearch.ForeColor = System.Drawing.SystemColors.Control;
            this.txbTitleSearch.Location = new System.Drawing.Point(520, 30);
            this.txbTitleSearch.Multiline = true;
            this.txbTitleSearch.Name = "txbTitleSearch";
            this.txbTitleSearch.Size = new System.Drawing.Size(200, 28);
            this.txbTitleSearch.TabIndex = 5;
            this.txbTitleSearch.Visible = false;
            // 
            // fpListHeaderPanel
            // 
            this.fpListHeaderPanel.BackColor = System.Drawing.Color.Transparent;
            this.fpListHeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.fpListHeaderPanel.Name = "fpListHeaderPanel";
            this.fpListHeaderPanel.Size = new System.Drawing.Size(199, 628);
            this.fpListHeaderPanel.TabIndex = 5;
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.addButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.addButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addButton.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.addButton.Location = new System.Drawing.Point(10, 631);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(178, 50);
            this.addButton.TabIndex = 3;
            this.addButton.Text = "Add New";
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.panel1.Controls.Add(this.addButton);
            this.panel1.Controls.Add(this.fpListHeaderPanel);
            this.panel1.Location = new System.Drawing.Point(0, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 689);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.pbSelectGame);
            this.panel2.Controls.Add(this.pbSelectSeries);
            this.panel2.Controls.Add(this.pbSelectAnime);
            this.panel2.Controls.Add(this.chOwnedSearch);
            this.panel2.Controls.Add(this.progressBar1);
            this.panel2.Controls.Add(this.pbToggleSorting);
            this.panel2.Controls.Add(this.pbSettings);
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
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1354, 70);
            this.panel2.TabIndex = 6;
            // 
            // pbSelectGame
            // 
            this.pbSelectGame.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbSelectGame.Image = global::ListUI.Properties.Resources.game;
            this.pbSelectGame.Location = new System.Drawing.Point(140, 10);
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
            this.pbSelectSeries.Location = new System.Drawing.Point(75, 10);
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
            this.pbSelectAnime.Location = new System.Drawing.Point(10, 10);
            this.pbSelectAnime.Name = "pbSelectAnime";
            this.pbSelectAnime.Size = new System.Drawing.Size(50, 50);
            this.pbSelectAnime.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSelectAnime.TabIndex = 24;
            this.pbSelectAnime.TabStop = false;
            this.pbSelectAnime.Click += new System.EventHandler(this.pbSelectAnime_Click);
            this.pbSelectAnime.MouseEnter += new System.EventHandler(this.pbSelectAnime_MouseEnter);
            this.pbSelectAnime.MouseLeave += new System.EventHandler(this.pbSelectAnime_MouseLeave);
            // 
            // chOwnedSearch
            // 
            this.chOwnedSearch.AutoSize = true;
            this.chOwnedSearch.Checked = true;
            this.chOwnedSearch.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chOwnedSearch.Enabled = false;
            this.chOwnedSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chOwnedSearch.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.chOwnedSearch.Location = new System.Drawing.Point(980, 30);
            this.chOwnedSearch.Name = "chOwnedSearch";
            this.chOwnedSearch.Size = new System.Drawing.Size(83, 24);
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
            // pbToggleSorting
            // 
            this.pbToggleSorting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbToggleSorting.Image = global::ListUI.Properties.Resources.sort;
            this.pbToggleSorting.Location = new System.Drawing.Point(1248, 14);
            this.pbToggleSorting.Name = "pbToggleSorting";
            this.pbToggleSorting.Size = new System.Drawing.Size(40, 40);
            this.pbToggleSorting.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbToggleSorting.TabIndex = 21;
            this.pbToggleSorting.TabStop = false;
            this.pbToggleSorting.Click += new System.EventHandler(this.pbToggleSorting_Click_1);
            this.pbToggleSorting.MouseEnter += new System.EventHandler(this.pbToggleSorting_MouseEnter);
            this.pbToggleSorting.MouseLeave += new System.EventHandler(this.pbToggleSorting_MouseLeave);
            // 
            // pbSettings
            // 
            this.pbSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbSettings.Image = global::ListUI.Properties.Resources.settings;
            this.pbSettings.Location = new System.Drawing.Point(1295, 14);
            this.pbSettings.Name = "pbSettings";
            this.pbSettings.Size = new System.Drawing.Size(40, 40);
            this.pbSettings.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSettings.TabIndex = 20;
            this.pbSettings.TabStop = false;
            this.pbSettings.Click += new System.EventHandler(this.pbSettings_Click);
            this.pbSettings.MouseEnter += new System.EventHandler(this.pbSettings_MouseEnter);
            this.pbSettings.MouseLeave += new System.EventHandler(this.pbSettings_MouseLeave);
            // 
            // pbOrderBy
            // 
            this.pbOrderBy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbOrderBy.Enabled = false;
            this.pbOrderBy.Image = global::ListUI.Properties.Resources.sort_desc;
            this.pbOrderBy.Location = new System.Drawing.Point(375, 30);
            this.pbOrderBy.Name = "pbOrderBy";
            this.pbOrderBy.Size = new System.Drawing.Size(30, 30);
            this.pbOrderBy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbOrderBy.TabIndex = 19;
            this.pbOrderBy.TabStop = false;
            this.pbOrderBy.Visible = false;
            this.pbOrderBy.Click += new System.EventHandler(this.pbSorting_Click);
            // 
            // pbSearch
            // 
            this.pbSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbSearch.Enabled = false;
            this.pbSearch.Image = global::ListUI.Properties.Resources.search;
            this.pbSearch.Location = new System.Drawing.Point(1080, 25);
            this.pbSearch.Name = "pbSearch";
            this.pbSearch.Size = new System.Drawing.Size(30, 30);
            this.pbSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSearch.TabIndex = 18;
            this.pbSearch.TabStop = false;
            this.pbSearch.Visible = false;
            this.pbSearch.Click += new System.EventHandler(this.pbSearch_Click);
            this.pbSearch.MouseEnter += new System.EventHandler(this.pbSearch_MouseEnter);
            this.pbSearch.MouseLeave += new System.EventHandler(this.pbSearch_MouseLeave);
            // 
            // pbToggleFilter
            // 
            this.pbToggleFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbToggleFilter.Image = global::ListUI.Properties.Resources.filter;
            this.pbToggleFilter.Location = new System.Drawing.Point(1201, 14);
            this.pbToggleFilter.Name = "pbToggleFilter";
            this.pbToggleFilter.Size = new System.Drawing.Size(40, 40);
            this.pbToggleFilter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbToggleFilter.TabIndex = 17;
            this.pbToggleFilter.TabStop = false;
            this.pbToggleFilter.Click += new System.EventHandler(this.pbFilter_Click);
            this.pbToggleFilter.MouseEnter += new System.EventHandler(this.pbToggleFilter_MouseEnter);
            this.pbToggleFilter.MouseLeave += new System.EventHandler(this.pbToggleFilter_MouseLeave);
            // 
            // cbOrderBy
            // 
            this.cbOrderBy.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.cbOrderBy.Enabled = false;
            this.cbOrderBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbOrderBy.FormattingEnabled = true;
            this.cbOrderBy.Location = new System.Drawing.Point(250, 30);
            this.cbOrderBy.Name = "cbOrderBy";
            this.cbOrderBy.Size = new System.Drawing.Size(121, 28);
            this.cbOrderBy.TabIndex = 4;
            this.cbOrderBy.Visible = false;
            this.cbOrderBy.SelectionChangeCommitted += new System.EventHandler(this.cbOrderBy_SelectionChangeCommitted);
            // 
            // chDubbedSearch
            // 
            this.chDubbedSearch.AutoSize = true;
            this.chDubbedSearch.Checked = true;
            this.chDubbedSearch.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chDubbedSearch.Enabled = false;
            this.chDubbedSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chDubbedSearch.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.chDubbedSearch.Location = new System.Drawing.Point(980, 30);
            this.chDubbedSearch.Name = "chDubbedSearch";
            this.chDubbedSearch.Size = new System.Drawing.Size(91, 24);
            this.chDubbedSearch.TabIndex = 8;
            this.chDubbedSearch.Text = "Dubbed";
            this.chDubbedSearch.ThreeState = true;
            this.chDubbedSearch.UseVisualStyleBackColor = true;
            this.chDubbedSearch.Visible = false;
            // 
            // chFavouriteSearch
            // 
            this.chFavouriteSearch.AutoSize = true;
            this.chFavouriteSearch.Enabled = false;
            this.chFavouriteSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chFavouriteSearch.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.chFavouriteSearch.Location = new System.Drawing.Point(870, 30);
            this.chFavouriteSearch.Name = "chFavouriteSearch";
            this.chFavouriteSearch.Size = new System.Drawing.Size(103, 24);
            this.chFavouriteSearch.TabIndex = 7;
            this.chFavouriteSearch.Text = "Favourite";
            this.chFavouriteSearch.UseVisualStyleBackColor = true;
            this.chFavouriteSearch.Visible = false;
            // 
            // lbYearSearch
            // 
            this.lbYearSearch.AutoSize = true;
            this.lbYearSearch.Enabled = false;
            this.lbYearSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbYearSearch.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lbYearSearch.Location = new System.Drawing.Point(725, 30);
            this.lbYearSearch.Name = "lbYearSearch";
            this.lbYearSearch.Size = new System.Drawing.Size(70, 26);
            this.lbYearSearch.TabIndex = 11;
            this.lbYearSearch.Text = "Year:";
            this.lbYearSearch.Visible = false;
            // 
            // lbTitleSearch
            // 
            this.lbTitleSearch.AutoSize = true;
            this.lbTitleSearch.BackColor = System.Drawing.Color.Transparent;
            this.lbTitleSearch.Enabled = false;
            this.lbTitleSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbTitleSearch.ForeColor = System.Drawing.SystemColors.Control;
            this.lbTitleSearch.Location = new System.Drawing.Point(450, 30);
            this.lbTitleSearch.Name = "lbTitleSearch";
            this.lbTitleSearch.Size = new System.Drawing.Size(64, 26);
            this.lbTitleSearch.TabIndex = 10;
            this.lbTitleSearch.Text = "Title:";
            this.lbTitleSearch.Visible = false;
            // 
            // txbYearSearch
            // 
            this.txbYearSearch.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txbYearSearch.Enabled = false;
            this.txbYearSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txbYearSearch.ForeColor = System.Drawing.SystemColors.Control;
            this.txbYearSearch.Location = new System.Drawing.Point(800, 30);
            this.txbYearSearch.MaxLength = 4;
            this.txbYearSearch.Multiline = true;
            this.txbYearSearch.Name = "txbYearSearch";
            this.txbYearSearch.Size = new System.Drawing.Size(60, 28);
            this.txbYearSearch.TabIndex = 6;
            this.txbYearSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txbYearSearch.Visible = false;
            // 
            // chFinishedSearch
            // 
            this.chFinishedSearch.AutoSize = true;
            this.chFinishedSearch.Checked = true;
            this.chFinishedSearch.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chFinishedSearch.Enabled = false;
            this.chFinishedSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chFinishedSearch.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.chFinishedSearch.Location = new System.Drawing.Point(980, 30);
            this.chFinishedSearch.Name = "chFinishedSearch";
            this.chFinishedSearch.Size = new System.Drawing.Size(96, 24);
            this.chFinishedSearch.TabIndex = 9;
            this.chFinishedSearch.Text = "Finished";
            this.chFinishedSearch.UseVisualStyleBackColor = true;
            this.chFinishedSearch.Visible = false;
            // 
            // LibraryUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1354, 761);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.fpListItemPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "LibraryUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "My Little Library";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LibraryUI_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSelectGame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSelectSeries)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSelectAnime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbToggleSorting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSettings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOrderBy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbToggleFilter)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel fpListItemPanel;
        private System.Windows.Forms.TextBox txbTitleSearch;
        private System.Windows.Forms.FlowLayoutPanel fpListHeaderPanel;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Panel panel1;
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
        private System.Windows.Forms.PictureBox pbToggleSorting;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.CheckBox chOwnedSearch;
        private System.Windows.Forms.PictureBox pbSelectGame;
        private System.Windows.Forms.PictureBox pbSelectSeries;
        private System.Windows.Forms.PictureBox pbSelectAnime;
    }
}

