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
            this.addButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gameButton = new System.Windows.Forms.Panel();
            this.seriesButton = new System.Windows.Forms.Panel();
            this.animeButton = new System.Windows.Forms.Panel();
            this.listMenuPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.searchBar = new System.Windows.Forms.TextBox();
            this.searchPicture = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.addButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.addButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addButton.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.addButton.Location = new System.Drawing.Point(12, 699);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(178, 50);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "Add New";
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.flowLayoutPanel1.Location = new System.Drawing.Point(206, 68);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1148, 693);
            this.flowLayoutPanel1.TabIndex = 2;
            this.flowLayoutPanel1.Click += new System.EventHandler(this.flowLayoutPanel1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.addButton);
            this.panel1.Controls.Add(this.gameButton);
            this.panel1.Controls.Add(this.seriesButton);
            this.panel1.Controls.Add(this.animeButton);
            this.panel1.Controls.Add(this.listMenuPanel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 761);
            this.panel1.TabIndex = 3;
            // 
            // gameButton
            // 
            this.gameButton.BackgroundImage = global::ListUI.Properties.Resources.game;
            this.gameButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gameButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gameButton.Location = new System.Drawing.Point(140, 10);
            this.gameButton.Name = "gameButton";
            this.gameButton.Size = new System.Drawing.Size(50, 50);
            this.gameButton.TabIndex = 8;
            this.gameButton.Click += new System.EventHandler(this.gameButton_Click);
            this.gameButton.MouseEnter += new System.EventHandler(this.gameButton_MouseEnter);
            this.gameButton.MouseLeave += new System.EventHandler(this.gameButton_MouseLeave);
            // 
            // seriesButton
            // 
            this.seriesButton.BackgroundImage = global::ListUI.Properties.Resources.series;
            this.seriesButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.seriesButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.seriesButton.Location = new System.Drawing.Point(75, 10);
            this.seriesButton.Name = "seriesButton";
            this.seriesButton.Size = new System.Drawing.Size(50, 50);
            this.seriesButton.TabIndex = 7;
            this.seriesButton.Click += new System.EventHandler(this.seriesButton_Click);
            this.seriesButton.MouseEnter += new System.EventHandler(this.seriesButton_MouseEnter);
            this.seriesButton.MouseLeave += new System.EventHandler(this.seriesButton_MouseLeave);
            // 
            // animeButton
            // 
            this.animeButton.BackgroundImage = global::ListUI.Properties.Resources.anime;
            this.animeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.animeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.animeButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.animeButton.Location = new System.Drawing.Point(10, 10);
            this.animeButton.Name = "animeButton";
            this.animeButton.Size = new System.Drawing.Size(50, 50);
            this.animeButton.TabIndex = 6;
            this.animeButton.Click += new System.EventHandler(this.animeButton_Click);
            this.animeButton.MouseEnter += new System.EventHandler(this.animeButton_MouseEnter);
            this.animeButton.MouseLeave += new System.EventHandler(this.animeButton_MouseLeave);
            // 
            // listMenuPanel
            // 
            this.listMenuPanel.BackColor = System.Drawing.Color.Transparent;
            this.listMenuPanel.Location = new System.Drawing.Point(0, 68);
            this.listMenuPanel.Name = "listMenuPanel";
            this.listMenuPanel.Size = new System.Drawing.Size(199, 625);
            this.listMenuPanel.TabIndex = 5;
            // 
            // searchBar
            // 
            this.searchBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.searchBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.searchBar.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.searchBar.Location = new System.Drawing.Point(1142, 12);
            this.searchBar.Multiline = true;
            this.searchBar.Name = "searchBar";
            this.searchBar.Size = new System.Drawing.Size(200, 40);
            this.searchBar.TabIndex = 4;
            this.searchBar.TextChanged += new System.EventHandler(this.searchBar_TextChanged);
            // 
            // searchPicture
            // 
            this.searchPicture.Image = global::ListUI.Properties.Resources.search2;
            this.searchPicture.Location = new System.Drawing.Point(1106, 18);
            this.searchPicture.Name = "searchPicture";
            this.searchPicture.Size = new System.Drawing.Size(30, 30);
            this.searchPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.searchPicture.TabIndex = 5;
            this.searchPicture.TabStop = false;
            // 
            // LibraryUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(1354, 761);
            this.Controls.Add(this.searchPicture);
            this.Controls.Add(this.searchBar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "LibraryUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "My Little Library";
            this.Load += new System.EventHandler(this.LibraryUI_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.searchPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel listMenuPanel;
        private System.Windows.Forms.Panel animeButton;
        private System.Windows.Forms.Panel gameButton;
        private System.Windows.Forms.Panel seriesButton;
        private System.Windows.Forms.TextBox searchBar;
        private System.Windows.Forms.PictureBox searchPicture;
    }
}

