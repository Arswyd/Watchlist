namespace ListUI.ListItems
{
    partial class ListItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lbItemTitle = new System.Windows.Forms.Label();
            this.lbItemScore = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbPlusEp = new System.Windows.Forms.Label();
            this.lbItemEpisodes = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pbDetails = new System.Windows.Forms.PictureBox();
            this.pbNotes = new System.Windows.Forms.PictureBox();
            this.pbDubbed = new System.Windows.Forms.PictureBox();
            this.pbListItem = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNotes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDubbed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbListItem)).BeginInit();
            this.SuspendLayout();
            // 
            // lbItemTitle
            // 
            this.lbItemTitle.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbItemTitle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbItemTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbItemTitle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbItemTitle.Location = new System.Drawing.Point(0, 176);
            this.lbItemTitle.Name = "lbItemTitle";
            this.lbItemTitle.Size = new System.Drawing.Size(160, 44);
            this.lbItemTitle.TabIndex = 1;
            this.lbItemTitle.Text = "dsadsa";
            this.lbItemTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbItemTitle.Click += new System.EventHandler(this.listItemName_Click);
            this.lbItemTitle.MouseEnter += new System.EventHandler(this.listItemName_MouseEnter);
            this.lbItemTitle.MouseLeave += new System.EventHandler(this.listItemName_MouseLeave);
            // 
            // lbItemScore
            // 
            this.lbItemScore.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbItemScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbItemScore.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbItemScore.Location = new System.Drawing.Point(110, 0);
            this.lbItemScore.Name = "lbItemScore";
            this.lbItemScore.Size = new System.Drawing.Size(50, 50);
            this.lbItemScore.TabIndex = 2;
            this.lbItemScore.Text = "7,8";
            this.lbItemScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbItemScore.MouseEnter += new System.EventHandler(this.listItemScore_MouseEnter);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbPlusEp);
            this.panel1.Controls.Add(this.lbItemEpisodes);
            this.panel1.Location = new System.Drawing.Point(0, 90);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(160, 40);
            this.panel1.TabIndex = 4;
            this.panel1.Visible = false;
            // 
            // lbPlusEp
            // 
            this.lbPlusEp.AutoSize = true;
            this.lbPlusEp.BackColor = System.Drawing.Color.Transparent;
            this.lbPlusEp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbPlusEp.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbPlusEp.ForeColor = System.Drawing.Color.White;
            this.lbPlusEp.Location = new System.Drawing.Point(123, 9);
            this.lbPlusEp.Name = "lbPlusEp";
            this.lbPlusEp.Size = new System.Drawing.Size(22, 24);
            this.lbPlusEp.TabIndex = 1;
            this.lbPlusEp.Text = "+";
            this.lbPlusEp.Click += new System.EventHandler(this.plusWatched_Click);
            this.lbPlusEp.MouseEnter += new System.EventHandler(this.plusWatched_MouseEnter);
            this.lbPlusEp.MouseLeave += new System.EventHandler(this.plusWatched_MouseLeave);
            // 
            // lbItemEpisodes
            // 
            this.lbItemEpisodes.BackColor = System.Drawing.Color.Transparent;
            this.lbItemEpisodes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbItemEpisodes.ForeColor = System.Drawing.Color.White;
            this.lbItemEpisodes.Location = new System.Drawing.Point(40, 9);
            this.lbItemEpisodes.Name = "lbItemEpisodes";
            this.lbItemEpisodes.Size = new System.Drawing.Size(89, 24);
            this.lbItemEpisodes.TabIndex = 0;
            this.lbItemEpisodes.Text = "999/000";
            this.lbItemEpisodes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.pbDetails);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.pbNotes);
            this.panel2.Controls.Add(this.pbDubbed);
            this.panel2.Controls.Add(this.lbItemTitle);
            this.panel2.Controls.Add(this.lbItemScore);
            this.panel2.Controls.Add(this.pbListItem);
            this.panel2.Location = new System.Drawing.Point(7, 7);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(166, 226);
            this.panel2.TabIndex = 5;
            this.panel2.MouseEnter += new System.EventHandler(this.panel2_MouseEnter);
            this.panel2.MouseLeave += new System.EventHandler(this.panel2_MouseLeave);
            // 
            // pbDetails
            // 
            this.pbDetails.BackColor = System.Drawing.Color.Black;
            this.pbDetails.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbDetails.Image = global::ListUI.Properties.Resources.menu;
            this.pbDetails.Location = new System.Drawing.Point(54, 3);
            this.pbDetails.Name = "pbDetails";
            this.pbDetails.Size = new System.Drawing.Size(50, 50);
            this.pbDetails.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbDetails.TabIndex = 5;
            this.pbDetails.TabStop = false;
            this.pbDetails.Visible = false;
            this.pbDetails.Click += new System.EventHandler(this.menuPicture_Click);
            this.pbDetails.MouseLeave += new System.EventHandler(this.menuPicture_MouseLeave);
            // 
            // pbNotes
            // 
            this.pbNotes.BackColor = System.Drawing.Color.Transparent;
            this.pbNotes.Image = global::ListUI.Properties.Resources.note;
            this.pbNotes.Location = new System.Drawing.Point(22, 2);
            this.pbNotes.Name = "pbNotes";
            this.pbNotes.Size = new System.Drawing.Size(20, 20);
            this.pbNotes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbNotes.TabIndex = 3;
            this.pbNotes.TabStop = false;
            this.pbNotes.Visible = false;
            // 
            // pbDubbed
            // 
            this.pbDubbed.BackColor = System.Drawing.Color.Transparent;
            this.pbDubbed.Image = global::ListUI.Properties.Resources.check;
            this.pbDubbed.Location = new System.Drawing.Point(2, 2);
            this.pbDubbed.Name = "pbDubbed";
            this.pbDubbed.Size = new System.Drawing.Size(20, 20);
            this.pbDubbed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbDubbed.TabIndex = 3;
            this.pbDubbed.TabStop = false;
            this.pbDubbed.Visible = false;
            // 
            // pbListItem
            // 
            this.pbListItem.Location = new System.Drawing.Point(3, 3);
            this.pbListItem.Name = "pbListItem";
            this.pbListItem.Size = new System.Drawing.Size(160, 220);
            this.pbListItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbListItem.TabIndex = 0;
            this.pbListItem.TabStop = false;
            this.pbListItem.MouseEnter += new System.EventHandler(this.pbListItem_MouseEnter);
            this.pbListItem.MouseLeave += new System.EventHandler(this.pbListItem_MouseLeave);
            // 
            // ListItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Name = "ListItem";
            this.Size = new System.Drawing.Size(180, 240);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNotes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDubbed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbListItem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbListItem;
        private System.Windows.Forms.Label lbItemTitle;
        private System.Windows.Forms.Label lbItemScore;
        private System.Windows.Forms.PictureBox pbDubbed;
        private System.Windows.Forms.PictureBox pbNotes;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbItemEpisodes;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbPlusEp;
        private System.Windows.Forms.PictureBox pbDetails;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
