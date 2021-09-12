namespace ListUI.ListItems
{
    partial class SeriesListItem
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
            this.listItemName = new System.Windows.Forms.Label();
            this.listItemScore = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.plusWatched = new System.Windows.Forms.Label();
            this.listItemWatchedEp = new System.Windows.Forms.Label();
            this.listItemSeason = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.menuPicture = new System.Windows.Forms.PictureBox();
            this.noteIcon = new System.Windows.Forms.PictureBox();
            this.listItemPicture = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.menuPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.noteIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listItemPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // listItemName
            // 
            this.listItemName.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.listItemName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listItemName.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.listItemName.Location = new System.Drawing.Point(0, 176);
            this.listItemName.Name = "listItemName";
            this.listItemName.Size = new System.Drawing.Size(160, 44);
            this.listItemName.TabIndex = 1;
            this.listItemName.Text = "dsadsa";
            this.listItemName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.listItemName.Click += new System.EventHandler(this.listItemName_Click);
            this.listItemName.MouseEnter += new System.EventHandler(this.listItemName_MouseEnter);
            this.listItemName.MouseLeave += new System.EventHandler(this.listItemName_MouseLeave);
            // 
            // listItemScore
            // 
            this.listItemScore.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.listItemScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.listItemScore.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.listItemScore.Location = new System.Drawing.Point(110, 0);
            this.listItemScore.Name = "listItemScore";
            this.listItemScore.Size = new System.Drawing.Size(50, 50);
            this.listItemScore.TabIndex = 2;
            this.listItemScore.Text = "7,8";
            this.listItemScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.listItemScore.MouseEnter += new System.EventHandler(this.listItemScore_MouseEnter);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.plusWatched);
            this.panel1.Controls.Add(this.listItemWatchedEp);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.listItemSeason);
            this.panel1.Location = new System.Drawing.Point(0, 90);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(160, 40);
            this.panel1.TabIndex = 4;
            this.panel1.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(74, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "E";
            // 
            // plusWatched
            // 
            this.plusWatched.AutoSize = true;
            this.plusWatched.BackColor = System.Drawing.Color.Transparent;
            this.plusWatched.Cursor = System.Windows.Forms.Cursors.Hand;
            this.plusWatched.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.plusWatched.ForeColor = System.Drawing.Color.White;
            this.plusWatched.Location = new System.Drawing.Point(120, 9);
            this.plusWatched.Name = "plusWatched";
            this.plusWatched.Size = new System.Drawing.Size(22, 24);
            this.plusWatched.TabIndex = 1;
            this.plusWatched.Text = "+";
            this.plusWatched.Click += new System.EventHandler(this.plusWatched_Click);
            this.plusWatched.MouseEnter += new System.EventHandler(this.plusWatched_MouseEnter);
            this.plusWatched.MouseLeave += new System.EventHandler(this.plusWatched_MouseLeave);
            // 
            // listItemWatchedEp
            // 
            this.listItemWatchedEp.BackColor = System.Drawing.Color.Transparent;
            this.listItemWatchedEp.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.listItemWatchedEp.ForeColor = System.Drawing.Color.White;
            this.listItemWatchedEp.Location = new System.Drawing.Point(81, 9);
            this.listItemWatchedEp.Name = "listItemWatchedEp";
            this.listItemWatchedEp.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.listItemWatchedEp.Size = new System.Drawing.Size(44, 24);
            this.listItemWatchedEp.TabIndex = 0;
            this.listItemWatchedEp.Text = "00";
            this.listItemWatchedEp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // listItemSeason
            // 
            this.listItemSeason.BackColor = System.Drawing.Color.Transparent;
            this.listItemSeason.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.listItemSeason.ForeColor = System.Drawing.Color.White;
            this.listItemSeason.Location = new System.Drawing.Point(36, 9);
            this.listItemSeason.Name = "listItemSeason";
            this.listItemSeason.Size = new System.Drawing.Size(36, 24);
            this.listItemSeason.TabIndex = 0;
            this.listItemSeason.Text = "01";
            this.listItemSeason.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.menuPicture);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.noteIcon);
            this.panel2.Controls.Add(this.listItemName);
            this.panel2.Controls.Add(this.listItemScore);
            this.panel2.Controls.Add(this.listItemPicture);
            this.panel2.Location = new System.Drawing.Point(7, 7);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(166, 226);
            this.panel2.TabIndex = 5;
            this.panel2.MouseLeave += new System.EventHandler(this.panel2_MouseLeave);
            // 
            // menuPicture
            // 
            this.menuPicture.BackColor = System.Drawing.Color.Black;
            this.menuPicture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.menuPicture.Image = global::ListUI.Properties.Resources.menu;
            this.menuPicture.Location = new System.Drawing.Point(54, 3);
            this.menuPicture.Name = "menuPicture";
            this.menuPicture.Size = new System.Drawing.Size(50, 50);
            this.menuPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.menuPicture.TabIndex = 5;
            this.menuPicture.TabStop = false;
            this.menuPicture.Visible = false;
            this.menuPicture.Click += new System.EventHandler(this.menuPicture_Click);
            this.menuPicture.MouseLeave += new System.EventHandler(this.menuPicture_MouseLeave);
            // 
            // noteIcon
            // 
            this.noteIcon.BackColor = System.Drawing.Color.Transparent;
            this.noteIcon.Image = global::ListUI.Properties.Resources.note;
            this.noteIcon.Location = new System.Drawing.Point(2, 2);
            this.noteIcon.Name = "noteIcon";
            this.noteIcon.Size = new System.Drawing.Size(20, 20);
            this.noteIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.noteIcon.TabIndex = 3;
            this.noteIcon.TabStop = false;
            this.noteIcon.Visible = false;
            // 
            // listItemPicture
            // 
            this.listItemPicture.Location = new System.Drawing.Point(3, 3);
            this.listItemPicture.Name = "listItemPicture";
            this.listItemPicture.Size = new System.Drawing.Size(160, 220);
            this.listItemPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.listItemPicture.TabIndex = 0;
            this.listItemPicture.TabStop = false;
            this.listItemPicture.MouseEnter += new System.EventHandler(this.listItemPicture_MouseEnter);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(24, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "S";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SeriesListItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Name = "SeriesListItem";
            this.Size = new System.Drawing.Size(180, 240);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.menuPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.noteIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listItemPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox listItemPicture;
        private System.Windows.Forms.Label listItemName;
        private System.Windows.Forms.Label listItemScore;
        private System.Windows.Forms.PictureBox noteIcon;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label listItemWatchedEp;
        private System.Windows.Forms.Label listItemSeason;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label plusWatched;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox menuPicture;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label2;
    }
}
