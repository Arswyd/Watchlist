namespace ListUI.Forms
{
    partial class AddSeriesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddSeriesForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.nameValue = new System.Windows.Forms.TextBox();
            this.scoreValue = new System.Windows.Forms.TextBox();
            this.notesValue = new System.Windows.Forms.TextBox();
            this.watchedEpValue = new System.Windows.Forms.TextBox();
            this.totalEpValue = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.listGroupValue = new System.Windows.Forms.ComboBox();
            this.urlPanel = new System.Windows.Forms.Panel();
            this.urlButton = new System.Windows.Forms.Button();
            this.seriesUrlValue = new System.Windows.Forms.TextBox();
            this.pictureUrlValue = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.favouritePicture = new System.Windows.Forms.PictureBox();
            this.savePicture = new System.Windows.Forms.PictureBox();
            this.deletePicture = new System.Windows.Forms.PictureBox();
            this.addItemPicture = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.seasonValue = new System.Windows.Forms.TextBox();
            this.urlPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.favouritePicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.savePicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deletePicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addItemPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.SystemColors.Menu;
            this.label1.Location = new System.Drawing.Point(210, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.ForeColor = System.Drawing.SystemColors.Menu;
            this.label6.Location = new System.Drawing.Point(210, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 19);
            this.label6.TabIndex = 4;
            this.label6.Text = "Lists";
            // 
            // nameValue
            // 
            this.nameValue.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.nameValue.Font = new System.Drawing.Font("Arial", 10F);
            this.nameValue.Location = new System.Drawing.Point(215, 35);
            this.nameValue.Multiline = true;
            this.nameValue.Name = "nameValue";
            this.nameValue.Size = new System.Drawing.Size(300, 40);
            this.nameValue.TabIndex = 1;
            // 
            // scoreValue
            // 
            this.scoreValue.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.scoreValue.Font = new System.Drawing.Font("Arial", 10F);
            this.scoreValue.Location = new System.Drawing.Point(435, 120);
            this.scoreValue.MaxLength = 4;
            this.scoreValue.Multiline = true;
            this.scoreValue.Name = "scoreValue";
            this.scoreValue.Size = new System.Drawing.Size(80, 24);
            this.scoreValue.TabIndex = 3;
            this.scoreValue.Text = "0";
            this.scoreValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.scoreValue.Click += new System.EventHandler(this.scoreValue_Click);
            // 
            // notesValue
            // 
            this.notesValue.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.notesValue.Font = new System.Drawing.Font("Arial", 10F);
            this.notesValue.Location = new System.Drawing.Point(215, 190);
            this.notesValue.Multiline = true;
            this.notesValue.Name = "notesValue";
            this.notesValue.Size = new System.Drawing.Size(300, 40);
            this.notesValue.TabIndex = 4;
            // 
            // watchedEpValue
            // 
            this.watchedEpValue.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.watchedEpValue.Font = new System.Drawing.Font("Arial", 10F);
            this.watchedEpValue.Location = new System.Drawing.Point(90, 280);
            this.watchedEpValue.MaxLength = 3;
            this.watchedEpValue.Multiline = true;
            this.watchedEpValue.Name = "watchedEpValue";
            this.watchedEpValue.Size = new System.Drawing.Size(50, 20);
            this.watchedEpValue.TabIndex = 6;
            this.watchedEpValue.Text = "0";
            this.watchedEpValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.watchedEpValue.Click += new System.EventHandler(this.watchedEpValue_Click);
            // 
            // totalEpValue
            // 
            this.totalEpValue.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.totalEpValue.Font = new System.Drawing.Font("Arial", 10F);
            this.totalEpValue.Location = new System.Drawing.Point(90, 255);
            this.totalEpValue.MaxLength = 3;
            this.totalEpValue.Multiline = true;
            this.totalEpValue.Name = "totalEpValue";
            this.totalEpValue.Size = new System.Drawing.Size(50, 20);
            this.totalEpValue.TabIndex = 5;
            this.totalEpValue.Text = "0";
            this.totalEpValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.totalEpValue.Click += new System.EventHandler(this.totalEpValue_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.ForeColor = System.Drawing.SystemColors.Menu;
            this.label7.Location = new System.Drawing.Point(210, 165);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 19);
            this.label7.TabIndex = 4;
            this.label7.Text = "Notes";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.SystemColors.Menu;
            this.label3.Location = new System.Drawing.Point(430, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Score";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.ForeColor = System.Drawing.SystemColors.Menu;
            this.label5.Location = new System.Drawing.Point(10, 255);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 19);
            this.label5.TabIndex = 4;
            this.label5.Text = "Total";
            // 
            // listGroupValue
            // 
            this.listGroupValue.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.listGroupValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listGroupValue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.listGroupValue.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.listGroupValue.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.listGroupValue.FormattingEnabled = true;
            this.listGroupValue.Location = new System.Drawing.Point(215, 120);
            this.listGroupValue.Name = "listGroupValue";
            this.listGroupValue.Size = new System.Drawing.Size(180, 24);
            this.listGroupValue.TabIndex = 2;
            // 
            // urlPanel
            // 
            this.urlPanel.Controls.Add(this.urlButton);
            this.urlPanel.Controls.Add(this.seriesUrlValue);
            this.urlPanel.Controls.Add(this.pictureUrlValue);
            this.urlPanel.Controls.Add(this.label8);
            this.urlPanel.Controls.Add(this.label2);
            this.urlPanel.Enabled = false;
            this.urlPanel.Location = new System.Drawing.Point(10, 10);
            this.urlPanel.Name = "urlPanel";
            this.urlPanel.Size = new System.Drawing.Size(530, 315);
            this.urlPanel.TabIndex = 9;
            this.urlPanel.Visible = false;
            // 
            // urlButton
            // 
            this.urlButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.urlButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.urlButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.urlButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.urlButton.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.urlButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.urlButton.Location = new System.Drawing.Point(205, 210);
            this.urlButton.Name = "urlButton";
            this.urlButton.Size = new System.Drawing.Size(120, 60);
            this.urlButton.TabIndex = 3;
            this.urlButton.Text = "OK";
            this.urlButton.UseVisualStyleBackColor = false;
            this.urlButton.Click += new System.EventHandler(this.urlButton_Click);
            // 
            // seriesUrlValue
            // 
            this.seriesUrlValue.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.seriesUrlValue.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.seriesUrlValue.Location = new System.Drawing.Point(55, 75);
            this.seriesUrlValue.Name = "seriesUrlValue";
            this.seriesUrlValue.Size = new System.Drawing.Size(420, 26);
            this.seriesUrlValue.TabIndex = 1;
            // 
            // pictureUrlValue
            // 
            this.pictureUrlValue.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureUrlValue.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.pictureUrlValue.Location = new System.Drawing.Point(55, 140);
            this.pictureUrlValue.Name = "pictureUrlValue";
            this.pictureUrlValue.Size = new System.Drawing.Size(420, 26);
            this.pictureUrlValue.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.ForeColor = System.Drawing.SystemColors.Menu;
            this.label8.Location = new System.Drawing.Point(50, 115);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 19);
            this.label8.TabIndex = 1;
            this.label8.Text = "Picture URL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.SystemColors.Menu;
            this.label2.Location = new System.Drawing.Point(50, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Series URL";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.favouritePicture);
            this.panel1.Controls.Add(this.savePicture);
            this.panel1.Controls.Add(this.deletePicture);
            this.panel1.Controls.Add(this.listGroupValue);
            this.panel1.Controls.Add(this.addItemPicture);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.seasonValue);
            this.panel1.Controls.Add(this.totalEpValue);
            this.panel1.Controls.Add(this.watchedEpValue);
            this.panel1.Controls.Add(this.notesValue);
            this.panel1.Controls.Add(this.scoreValue);
            this.panel1.Controls.Add(this.nameValue);
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(530, 315);
            this.panel1.TabIndex = 10;
            // 
            // favouritePicture
            // 
            this.favouritePicture.BackColor = System.Drawing.Color.Transparent;
            this.favouritePicture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.favouritePicture.Image = global::ListUI.Properties.Resources.empty;
            this.favouritePicture.InitialImage = null;
            this.favouritePicture.Location = new System.Drawing.Point(370, 255);
            this.favouritePicture.Name = "favouritePicture";
            this.favouritePicture.Size = new System.Drawing.Size(46, 46);
            this.favouritePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.favouritePicture.TabIndex = 11;
            this.favouritePicture.TabStop = false;
            this.favouritePicture.Click += new System.EventHandler(this.favouritePicture_Click);
            // 
            // savePicture
            // 
            this.savePicture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.savePicture.Image = global::ListUI.Properties.Resources.save;
            this.savePicture.InitialImage = null;
            this.savePicture.Location = new System.Drawing.Point(420, 255);
            this.savePicture.Name = "savePicture";
            this.savePicture.Size = new System.Drawing.Size(46, 46);
            this.savePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.savePicture.TabIndex = 10;
            this.savePicture.TabStop = false;
            this.savePicture.Click += new System.EventHandler(this.savePicture_Click_1);
            // 
            // deletePicture
            // 
            this.deletePicture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deletePicture.Enabled = false;
            this.deletePicture.Image = global::ListUI.Properties.Resources.delete;
            this.deletePicture.InitialImage = null;
            this.deletePicture.Location = new System.Drawing.Point(470, 255);
            this.deletePicture.Name = "deletePicture";
            this.deletePicture.Size = new System.Drawing.Size(46, 46);
            this.deletePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.deletePicture.TabIndex = 9;
            this.deletePicture.TabStop = false;
            this.deletePicture.Visible = false;
            this.deletePicture.Click += new System.EventHandler(this.deletePicture_Click);
            // 
            // addItemPicture
            // 
            this.addItemPicture.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.addItemPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.addItemPicture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addItemPicture.Location = new System.Drawing.Point(10, 10);
            this.addItemPicture.Name = "addItemPicture";
            this.addItemPicture.Size = new System.Drawing.Size(160, 220);
            this.addItemPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.addItemPicture.TabIndex = 5;
            this.addItemPicture.TabStop = false;
            this.addItemPicture.Click += new System.EventHandler(this.addItemPicture_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.ForeColor = System.Drawing.SystemColors.Menu;
            this.label4.Location = new System.Drawing.Point(210, 255);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 19);
            this.label4.TabIndex = 4;
            this.label4.Text = "Season";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.ForeColor = System.Drawing.SystemColors.Menu;
            this.label9.Location = new System.Drawing.Point(10, 280);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 19);
            this.label9.TabIndex = 4;
            this.label9.Text = "Watched";
            // 
            // seasonValue
            // 
            this.seasonValue.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.seasonValue.Font = new System.Drawing.Font("Arial", 10F);
            this.seasonValue.Location = new System.Drawing.Point(290, 255);
            this.seasonValue.MaxLength = 3;
            this.seasonValue.Multiline = true;
            this.seasonValue.Name = "seasonValue";
            this.seasonValue.Size = new System.Drawing.Size(50, 20);
            this.seasonValue.TabIndex = 7;
            this.seasonValue.Text = "1";
            this.seasonValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.seasonValue.Click += new System.EventHandler(this.seasonValue_Click);
            // 
            // AddSeriesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(554, 336);
            this.Controls.Add(this.urlPanel);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddSeriesForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Series";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddSeriesForm_FormClosing);
            this.urlPanel.ResumeLayout(false);
            this.urlPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.favouritePicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.savePicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deletePicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addItemPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox addItemPicture;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox nameValue;
        private System.Windows.Forms.TextBox scoreValue;
        private System.Windows.Forms.TextBox notesValue;
        private System.Windows.Forms.TextBox watchedEpValue;
        private System.Windows.Forms.TextBox totalEpValue;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox listGroupValue;
        private System.Windows.Forms.Panel urlPanel;
        private System.Windows.Forms.Button urlButton;
        private System.Windows.Forms.TextBox seriesUrlValue;
        private System.Windows.Forms.TextBox pictureUrlValue;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox deletePicture;
        private System.Windows.Forms.PictureBox favouritePicture;
        private System.Windows.Forms.PictureBox savePicture;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox seasonValue;
    }
}