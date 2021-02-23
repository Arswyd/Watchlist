namespace ListUI.ListItems
{
    partial class AnimeListItem
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
            this.listItemTotalEp = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.menuPicture = new System.Windows.Forms.PictureBox();
            this.noteIcon = new System.Windows.Forms.PictureBox();
            this.dubbedIcon = new System.Windows.Forms.PictureBox();
            this.listItemPicture = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.menuPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.noteIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dubbedIcon)).BeginInit();
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
            this.panel1.Controls.Add(this.listItemTotalEp);
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
            this.label1.Location = new System.Drawing.Point(66, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "/";
            // 
            // plusWatched
            // 
            this.plusWatched.AutoSize = true;
            this.plusWatched.BackColor = System.Drawing.Color.Transparent;
            this.plusWatched.Cursor = System.Windows.Forms.Cursors.Hand;
            this.plusWatched.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.plusWatched.ForeColor = System.Drawing.Color.White;
            this.plusWatched.Location = new System.Drawing.Point(115, 9);
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
            this.listItemWatchedEp.Location = new System.Drawing.Point(76, 9);
            this.listItemWatchedEp.Name = "listItemWatchedEp";
            this.listItemWatchedEp.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.listItemWatchedEp.Size = new System.Drawing.Size(44, 24);
            this.listItemWatchedEp.TabIndex = 0;
            this.listItemWatchedEp.Text = "000";
            this.listItemWatchedEp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // listItemTotalEp
            // 
            this.listItemTotalEp.BackColor = System.Drawing.Color.Transparent;
            this.listItemTotalEp.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.listItemTotalEp.ForeColor = System.Drawing.Color.White;
            this.listItemTotalEp.Location = new System.Drawing.Point(28, 9);
            this.listItemTotalEp.Name = "listItemTotalEp";
            this.listItemTotalEp.Size = new System.Drawing.Size(44, 24);
            this.listItemTotalEp.TabIndex = 0;
            this.listItemTotalEp.Text = "999";
            this.listItemTotalEp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.menuPicture);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.noteIcon);
            this.panel2.Controls.Add(this.dubbedIcon);
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
            this.noteIcon.Location = new System.Drawing.Point(22, 2);
            this.noteIcon.Name = "noteIcon";
            this.noteIcon.Size = new System.Drawing.Size(20, 20);
            this.noteIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.noteIcon.TabIndex = 3;
            this.noteIcon.TabStop = false;
            this.noteIcon.Visible = false;
            // 
            // dubbedIcon
            // 
            this.dubbedIcon.BackColor = System.Drawing.Color.Transparent;
            this.dubbedIcon.Image = global::ListUI.Properties.Resources.checkmark;
            this.dubbedIcon.Location = new System.Drawing.Point(2, 2);
            this.dubbedIcon.Name = "dubbedIcon";
            this.dubbedIcon.Size = new System.Drawing.Size(20, 20);
            this.dubbedIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.dubbedIcon.TabIndex = 3;
            this.dubbedIcon.TabStop = false;
            this.dubbedIcon.Visible = false;
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
            // AnimeListItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Name = "AnimeListItem";
            this.Size = new System.Drawing.Size(180, 240);
            this.MouseLeave += new System.EventHandler(this.AnimeListItem_MouseLeave);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.menuPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.noteIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dubbedIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listItemPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox listItemPicture;
        private System.Windows.Forms.Label listItemName;
        private System.Windows.Forms.Label listItemScore;
        private System.Windows.Forms.PictureBox dubbedIcon;
        private System.Windows.Forms.PictureBox noteIcon;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label listItemWatchedEp;
        private System.Windows.Forms.Label listItemTotalEp;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label plusWatched;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox menuPicture;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
