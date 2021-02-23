namespace ListUI.ListItems
{
    partial class GameListItem
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.menuPicture = new System.Windows.Forms.PictureBox();
            this.noteIcon = new System.Windows.Forms.PictureBox();
            this.listItemPicture = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
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
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.menuPicture);
            this.panel2.Controls.Add(this.noteIcon);
            this.panel2.Controls.Add(this.listItemName);
            this.panel2.Controls.Add(this.listItemScore);
            this.panel2.Controls.Add(this.listItemPicture);
            this.panel2.Location = new System.Drawing.Point(7, 7);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(166, 226);
            this.panel2.TabIndex = 5;
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
            this.listItemPicture.BackColor = System.Drawing.Color.Transparent;
            this.listItemPicture.Location = new System.Drawing.Point(3, 3);
            this.listItemPicture.Name = "listItemPicture";
            this.listItemPicture.Size = new System.Drawing.Size(160, 220);
            this.listItemPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.listItemPicture.TabIndex = 0;
            this.listItemPicture.TabStop = false;
            // 
            // GameListItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Name = "GameListItem";
            this.Size = new System.Drawing.Size(180, 240);
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
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox menuPicture;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
