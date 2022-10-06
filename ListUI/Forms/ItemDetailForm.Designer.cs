namespace ListUI.Forms
{
    partial class ItemDetailForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemDetailForm));
            this.lbTitle = new System.Windows.Forms.Label();
            this.lbListGroup = new System.Windows.Forms.Label();
            this.txbTitle = new System.Windows.Forms.TextBox();
            this.txbScore = new System.Windows.Forms.TextBox();
            this.txbNotes = new System.Windows.Forms.TextBox();
            this.txbWatchedEp = new System.Windows.Forms.TextBox();
            this.txbTotalEp = new System.Windows.Forms.TextBox();
            this.lbNotes = new System.Windows.Forms.Label();
            this.lbScore = new System.Windows.Forms.Label();
            this.lbTotalEp = new System.Windows.Forms.Label();
            this.chDubbed = new System.Windows.Forms.CheckBox();
            this.cbListGroup = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txbLenght = new System.Windows.Forms.TextBox();
            this.pbDeletePic = new System.Windows.Forms.PictureBox();
            this.pbReloadPic = new System.Windows.Forms.PictureBox();
            this.chOwned = new System.Windows.Forms.CheckBox();
            this.chFinished = new System.Windows.Forms.CheckBox();
            this.cbSeason_Platform = new System.Windows.Forms.ComboBox();
            this.lbCurrentSe = new System.Windows.Forms.Label();
            this.txbCurrentSe = new System.Windows.Forms.TextBox();
            this.lbTotalSe = new System.Windows.Forms.Label();
            this.txbTotalSe = new System.Windows.Forms.TextBox();
            this.lbSeason_Platform = new System.Windows.Forms.Label();
            this.lbYear = new System.Windows.Forms.Label();
            this.txbYear = new System.Windows.Forms.TextBox();
            this.txbPictureUrl = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbUrl = new System.Windows.Forms.TextBox();
            this.lbUrl = new System.Windows.Forms.Label();
            this.pbFavourite = new System.Windows.Forms.PictureBox();
            this.pbSave = new System.Windows.Forms.PictureBox();
            this.pbDelete = new System.Windows.Forms.PictureBox();
            this.pbPicture = new System.Windows.Forms.PictureBox();
            this.lbWatchedEp = new System.Windows.Forms.Label();
            this.lbLenght = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDeletePic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbReloadPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFavourite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbTitle.ForeColor = System.Drawing.SystemColors.Menu;
            this.lbTitle.Location = new System.Drawing.Point(196, 10);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(41, 19);
            this.lbTitle.TabIndex = 4;
            this.lbTitle.Text = "Title";
            // 
            // lbListGroup
            // 
            this.lbListGroup.AutoSize = true;
            this.lbListGroup.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbListGroup.ForeColor = System.Drawing.SystemColors.Menu;
            this.lbListGroup.Location = new System.Drawing.Point(196, 184);
            this.lbListGroup.Name = "lbListGroup";
            this.lbListGroup.Size = new System.Drawing.Size(89, 19);
            this.lbListGroup.TabIndex = 4;
            this.lbListGroup.Text = "List Group";
            // 
            // txbTitle
            // 
            this.txbTitle.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txbTitle.Font = new System.Drawing.Font("Arial", 10F);
            this.txbTitle.Location = new System.Drawing.Point(200, 30);
            this.txbTitle.Multiline = true;
            this.txbTitle.Name = "txbTitle";
            this.txbTitle.Size = new System.Drawing.Size(300, 40);
            this.txbTitle.TabIndex = 0;
            this.txbTitle.DoubleClick += new System.EventHandler(this.txbTitle_DoubleClick);
            // 
            // txbScore
            // 
            this.txbScore.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txbScore.Font = new System.Drawing.Font("Arial", 10F);
            this.txbScore.Location = new System.Drawing.Point(420, 206);
            this.txbScore.MaxLength = 4;
            this.txbScore.Name = "txbScore";
            this.txbScore.Size = new System.Drawing.Size(80, 23);
            this.txbScore.TabIndex = 4;
            this.txbScore.Text = "0";
            this.txbScore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txbNotes
            // 
            this.txbNotes.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txbNotes.Font = new System.Drawing.Font("Arial", 10F);
            this.txbNotes.Location = new System.Drawing.Point(200, 266);
            this.txbNotes.Multiline = true;
            this.txbNotes.Name = "txbNotes";
            this.txbNotes.Size = new System.Drawing.Size(300, 40);
            this.txbNotes.TabIndex = 5;
            // 
            // txbWatchedEp
            // 
            this.txbWatchedEp.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txbWatchedEp.Enabled = false;
            this.txbWatchedEp.Font = new System.Drawing.Font("Arial", 10F);
            this.txbWatchedEp.Location = new System.Drawing.Point(120, 346);
            this.txbWatchedEp.MaxLength = 3;
            this.txbWatchedEp.Name = "txbWatchedEp";
            this.txbWatchedEp.Size = new System.Drawing.Size(50, 23);
            this.txbWatchedEp.TabIndex = 11;
            this.txbWatchedEp.Text = "0";
            this.txbWatchedEp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txbWatchedEp.Visible = false;
            // 
            // txbTotalEp
            // 
            this.txbTotalEp.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txbTotalEp.Enabled = false;
            this.txbTotalEp.Font = new System.Drawing.Font("Arial", 10F);
            this.txbTotalEp.Location = new System.Drawing.Point(45, 346);
            this.txbTotalEp.MaxLength = 3;
            this.txbTotalEp.Name = "txbTotalEp";
            this.txbTotalEp.Size = new System.Drawing.Size(50, 23);
            this.txbTotalEp.TabIndex = 10;
            this.txbTotalEp.Text = "0";
            this.txbTotalEp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txbTotalEp.Visible = false;
            this.txbTotalEp.Enter += new System.EventHandler(this.txbTotalEp_Enter);
            this.txbTotalEp.Leave += new System.EventHandler(this.txbTotalEp_Leave);
            // 
            // lbNotes
            // 
            this.lbNotes.AutoSize = true;
            this.lbNotes.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbNotes.ForeColor = System.Drawing.SystemColors.Menu;
            this.lbNotes.Location = new System.Drawing.Point(196, 243);
            this.lbNotes.Name = "lbNotes";
            this.lbNotes.Size = new System.Drawing.Size(54, 19);
            this.lbNotes.TabIndex = 4;
            this.lbNotes.Text = "Notes";
            // 
            // lbScore
            // 
            this.lbScore.AutoSize = true;
            this.lbScore.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbScore.ForeColor = System.Drawing.SystemColors.Menu;
            this.lbScore.Location = new System.Drawing.Point(416, 184);
            this.lbScore.Name = "lbScore";
            this.lbScore.Size = new System.Drawing.Size(54, 19);
            this.lbScore.TabIndex = 4;
            this.lbScore.Text = "Score";
            // 
            // lbTotalEp
            // 
            this.lbTotalEp.AutoSize = true;
            this.lbTotalEp.Enabled = false;
            this.lbTotalEp.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbTotalEp.ForeColor = System.Drawing.SystemColors.Menu;
            this.lbTotalEp.Location = new System.Drawing.Point(8, 348);
            this.lbTotalEp.Name = "lbTotalEp";
            this.lbTotalEp.Size = new System.Drawing.Size(31, 19);
            this.lbTotalEp.TabIndex = 4;
            this.lbTotalEp.Text = "EP";
            this.lbTotalEp.Visible = false;
            // 
            // chDubbed
            // 
            this.chDubbed.AutoSize = true;
            this.chDubbed.Enabled = false;
            this.chDubbed.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chDubbed.ForeColor = System.Drawing.SystemColors.Menu;
            this.chDubbed.Location = new System.Drawing.Point(205, 346);
            this.chDubbed.Name = "chDubbed";
            this.chDubbed.Size = new System.Drawing.Size(89, 23);
            this.chDubbed.TabIndex = 13;
            this.chDubbed.Text = "Dubbed";
            this.chDubbed.UseVisualStyleBackColor = true;
            this.chDubbed.Visible = false;
            // 
            // cbListGroup
            // 
            this.cbListGroup.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.cbListGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbListGroup.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbListGroup.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cbListGroup.FormattingEnabled = true;
            this.cbListGroup.Location = new System.Drawing.Point(200, 206);
            this.cbListGroup.Name = "cbListGroup";
            this.cbListGroup.Size = new System.Drawing.Size(205, 24);
            this.cbListGroup.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbLenght);
            this.panel1.Controls.Add(this.txbLenght);
            this.panel1.Controls.Add(this.pbDeletePic);
            this.panel1.Controls.Add(this.pbReloadPic);
            this.panel1.Controls.Add(this.chOwned);
            this.panel1.Controls.Add(this.chFinished);
            this.panel1.Controls.Add(this.cbSeason_Platform);
            this.panel1.Controls.Add(this.lbCurrentSe);
            this.panel1.Controls.Add(this.txbCurrentSe);
            this.panel1.Controls.Add(this.lbTotalSe);
            this.panel1.Controls.Add(this.txbTotalSe);
            this.panel1.Controls.Add(this.lbSeason_Platform);
            this.panel1.Controls.Add(this.lbYear);
            this.panel1.Controls.Add(this.txbYear);
            this.panel1.Controls.Add(this.txbPictureUrl);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txbUrl);
            this.panel1.Controls.Add(this.lbUrl);
            this.panel1.Controls.Add(this.pbFavourite);
            this.panel1.Controls.Add(this.pbSave);
            this.panel1.Controls.Add(this.pbDelete);
            this.panel1.Controls.Add(this.cbListGroup);
            this.panel1.Controls.Add(this.chDubbed);
            this.panel1.Controls.Add(this.pbPicture);
            this.panel1.Controls.Add(this.lbWatchedEp);
            this.panel1.Controls.Add(this.lbTotalEp);
            this.panel1.Controls.Add(this.lbScore);
            this.panel1.Controls.Add(this.lbListGroup);
            this.panel1.Controls.Add(this.lbNotes);
            this.panel1.Controls.Add(this.lbTitle);
            this.panel1.Controls.Add(this.txbTotalEp);
            this.panel1.Controls.Add(this.txbWatchedEp);
            this.panel1.Controls.Add(this.txbNotes);
            this.panel1.Controls.Add(this.txbScore);
            this.panel1.Controls.Add(this.txbTitle);
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(520, 380);
            this.panel1.TabIndex = 10;
            // 
            // txbLenght
            // 
            this.txbLenght.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txbLenght.Enabled = false;
            this.txbLenght.Font = new System.Drawing.Font("Arial", 10F);
            this.txbLenght.Location = new System.Drawing.Point(10, 316);
            this.txbLenght.MaxLength = 6;
            this.txbLenght.Name = "txbLenght";
            this.txbLenght.Size = new System.Drawing.Size(63, 23);
            this.txbLenght.TabIndex = 26;
            this.txbLenght.Text = "1";
            this.txbLenght.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txbLenght.Visible = false;
            // 
            // pbDeletePic
            // 
            this.pbDeletePic.BackColor = System.Drawing.Color.Transparent;
            this.pbDeletePic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbDeletePic.Image = global::ListUI.Properties.Resources.delete;
            this.pbDeletePic.InitialImage = null;
            this.pbDeletePic.Location = new System.Drawing.Point(476, 154);
            this.pbDeletePic.Name = "pbDeletePic";
            this.pbDeletePic.Size = new System.Drawing.Size(24, 24);
            this.pbDeletePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbDeletePic.TabIndex = 25;
            this.pbDeletePic.TabStop = false;
            this.pbDeletePic.Click += new System.EventHandler(this.pbDeletePic_Click);
            // 
            // pbReloadPic
            // 
            this.pbReloadPic.BackColor = System.Drawing.Color.Transparent;
            this.pbReloadPic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbReloadPic.Image = global::ListUI.Properties.Resources.check;
            this.pbReloadPic.InitialImage = null;
            this.pbReloadPic.Location = new System.Drawing.Point(450, 154);
            this.pbReloadPic.Name = "pbReloadPic";
            this.pbReloadPic.Size = new System.Drawing.Size(24, 24);
            this.pbReloadPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbReloadPic.TabIndex = 24;
            this.pbReloadPic.TabStop = false;
            this.pbReloadPic.Click += new System.EventHandler(this.pbReloadPic_Click);
            // 
            // chOwned
            // 
            this.chOwned.AutoSize = true;
            this.chOwned.Enabled = false;
            this.chOwned.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chOwned.ForeColor = System.Drawing.SystemColors.Menu;
            this.chOwned.Location = new System.Drawing.Point(205, 346);
            this.chOwned.Name = "chOwned";
            this.chOwned.Size = new System.Drawing.Size(82, 23);
            this.chOwned.TabIndex = 23;
            this.chOwned.Text = "Owned";
            this.chOwned.UseVisualStyleBackColor = true;
            this.chOwned.Visible = false;
            // 
            // chFinished
            // 
            this.chFinished.AutoSize = true;
            this.chFinished.Enabled = false;
            this.chFinished.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chFinished.ForeColor = System.Drawing.SystemColors.Menu;
            this.chFinished.Location = new System.Drawing.Point(205, 346);
            this.chFinished.Name = "chFinished";
            this.chFinished.Size = new System.Drawing.Size(94, 23);
            this.chFinished.TabIndex = 12;
            this.chFinished.Text = "Finished";
            this.chFinished.UseVisualStyleBackColor = true;
            this.chFinished.Visible = false;
            this.chFinished.Enter += new System.EventHandler(this.chFinished_Enter);
            // 
            // cbSeason_Platform
            // 
            this.cbSeason_Platform.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.cbSeason_Platform.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbSeason_Platform.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbSeason_Platform.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cbSeason_Platform.FormattingEnabled = true;
            this.cbSeason_Platform.Location = new System.Drawing.Point(90, 266);
            this.cbSeason_Platform.Name = "cbSeason_Platform";
            this.cbSeason_Platform.Size = new System.Drawing.Size(80, 24);
            this.cbSeason_Platform.TabIndex = 7;
            // 
            // lbCurrentSe
            // 
            this.lbCurrentSe.AutoSize = true;
            this.lbCurrentSe.Enabled = false;
            this.lbCurrentSe.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbCurrentSe.ForeColor = System.Drawing.SystemColors.Menu;
            this.lbCurrentSe.Location = new System.Drawing.Point(101, 320);
            this.lbCurrentSe.Name = "lbCurrentSe";
            this.lbCurrentSe.Size = new System.Drawing.Size(13, 19);
            this.lbCurrentSe.TabIndex = 22;
            this.lbCurrentSe.Text = "/";
            this.lbCurrentSe.Visible = false;
            // 
            // txbCurrentSe
            // 
            this.txbCurrentSe.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txbCurrentSe.Enabled = false;
            this.txbCurrentSe.Font = new System.Drawing.Font("Arial", 10F);
            this.txbCurrentSe.Location = new System.Drawing.Point(120, 317);
            this.txbCurrentSe.MaxLength = 3;
            this.txbCurrentSe.Name = "txbCurrentSe";
            this.txbCurrentSe.Size = new System.Drawing.Size(50, 23);
            this.txbCurrentSe.TabIndex = 9;
            this.txbCurrentSe.Text = "1";
            this.txbCurrentSe.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txbCurrentSe.Visible = false;
            // 
            // lbTotalSe
            // 
            this.lbTotalSe.AutoSize = true;
            this.lbTotalSe.Enabled = false;
            this.lbTotalSe.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbTotalSe.ForeColor = System.Drawing.SystemColors.Menu;
            this.lbTotalSe.Location = new System.Drawing.Point(8, 320);
            this.lbTotalSe.Name = "lbTotalSe";
            this.lbTotalSe.Size = new System.Drawing.Size(31, 19);
            this.lbTotalSe.TabIndex = 20;
            this.lbTotalSe.Text = "SE";
            this.lbTotalSe.Visible = false;
            // 
            // txbTotalSe
            // 
            this.txbTotalSe.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txbTotalSe.Enabled = false;
            this.txbTotalSe.Font = new System.Drawing.Font("Arial", 10F);
            this.txbTotalSe.Location = new System.Drawing.Point(45, 317);
            this.txbTotalSe.MaxLength = 3;
            this.txbTotalSe.Name = "txbTotalSe";
            this.txbTotalSe.Size = new System.Drawing.Size(50, 23);
            this.txbTotalSe.TabIndex = 8;
            this.txbTotalSe.Text = "1";
            this.txbTotalSe.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txbTotalSe.Visible = false;
            // 
            // lbSeason_Platform
            // 
            this.lbSeason_Platform.AutoSize = true;
            this.lbSeason_Platform.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbSeason_Platform.ForeColor = System.Drawing.SystemColors.Menu;
            this.lbSeason_Platform.Location = new System.Drawing.Point(86, 244);
            this.lbSeason_Platform.Name = "lbSeason_Platform";
            this.lbSeason_Platform.Size = new System.Drawing.Size(67, 19);
            this.lbSeason_Platform.TabIndex = 19;
            this.lbSeason_Platform.Text = "Season";
            // 
            // lbYear
            // 
            this.lbYear.AutoSize = true;
            this.lbYear.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbYear.ForeColor = System.Drawing.SystemColors.Menu;
            this.lbYear.Location = new System.Drawing.Point(6, 244);
            this.lbYear.Name = "lbYear";
            this.lbYear.Size = new System.Drawing.Size(42, 19);
            this.lbYear.TabIndex = 17;
            this.lbYear.Text = "Year";
            // 
            // txbYear
            // 
            this.txbYear.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txbYear.Font = new System.Drawing.Font("Arial", 10F);
            this.txbYear.Location = new System.Drawing.Point(10, 266);
            this.txbYear.MaxLength = 4;
            this.txbYear.Name = "txbYear";
            this.txbYear.Size = new System.Drawing.Size(63, 23);
            this.txbYear.TabIndex = 6;
            this.txbYear.Text = "2020";
            this.txbYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txbPictureUrl
            // 
            this.txbPictureUrl.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txbPictureUrl.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txbPictureUrl.Location = new System.Drawing.Point(200, 155);
            this.txbPictureUrl.Name = "txbPictureUrl";
            this.txbPictureUrl.Size = new System.Drawing.Size(248, 23);
            this.txbPictureUrl.TabIndex = 2;
            this.txbPictureUrl.DoubleClick += new System.EventHandler(this.txbPictureUrl_DoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.SystemColors.Menu;
            this.label2.Location = new System.Drawing.Point(196, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 19);
            this.label2.TabIndex = 14;
            this.label2.Text = "Picture URL";
            // 
            // txbUrl
            // 
            this.txbUrl.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txbUrl.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txbUrl.Location = new System.Drawing.Point(200, 100);
            this.txbUrl.Name = "txbUrl";
            this.txbUrl.Size = new System.Drawing.Size(300, 23);
            this.txbUrl.TabIndex = 1;
            this.txbUrl.DoubleClick += new System.EventHandler(this.txbUrl_DoubleClick);
            // 
            // lbUrl
            // 
            this.lbUrl.AutoSize = true;
            this.lbUrl.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbUrl.ForeColor = System.Drawing.SystemColors.Menu;
            this.lbUrl.Location = new System.Drawing.Point(196, 78);
            this.lbUrl.Name = "lbUrl";
            this.lbUrl.Size = new System.Drawing.Size(79, 19);
            this.lbUrl.TabIndex = 12;
            this.lbUrl.Text = "Item URL";
            // 
            // pbFavourite
            // 
            this.pbFavourite.BackColor = System.Drawing.Color.Transparent;
            this.pbFavourite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbFavourite.Image = global::ListUI.Properties.Resources.empty;
            this.pbFavourite.InitialImage = null;
            this.pbFavourite.Location = new System.Drawing.Point(347, 323);
            this.pbFavourite.Name = "pbFavourite";
            this.pbFavourite.Size = new System.Drawing.Size(46, 46);
            this.pbFavourite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFavourite.TabIndex = 11;
            this.pbFavourite.TabStop = false;
            this.pbFavourite.Click += new System.EventHandler(this.favouritePicture_Click);
            this.pbFavourite.MouseEnter += new System.EventHandler(this.pbFavourite_MouseEnter);
            this.pbFavourite.MouseLeave += new System.EventHandler(this.pbFavourite_MouseLeave);
            // 
            // pbSave
            // 
            this.pbSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbSave.Image = global::ListUI.Properties.Resources.save;
            this.pbSave.InitialImage = null;
            this.pbSave.Location = new System.Drawing.Point(402, 323);
            this.pbSave.Name = "pbSave";
            this.pbSave.Size = new System.Drawing.Size(46, 46);
            this.pbSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSave.TabIndex = 10;
            this.pbSave.TabStop = false;
            this.pbSave.Click += new System.EventHandler(this.savePicture_Click_1);
            this.pbSave.MouseEnter += new System.EventHandler(this.pbSave_MouseEnter);
            this.pbSave.MouseLeave += new System.EventHandler(this.pbSave_MouseLeave);
            // 
            // pbDelete
            // 
            this.pbDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbDelete.Enabled = false;
            this.pbDelete.Image = global::ListUI.Properties.Resources.delete;
            this.pbDelete.InitialImage = null;
            this.pbDelete.Location = new System.Drawing.Point(454, 323);
            this.pbDelete.Name = "pbDelete";
            this.pbDelete.Size = new System.Drawing.Size(46, 46);
            this.pbDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbDelete.TabIndex = 9;
            this.pbDelete.TabStop = false;
            this.pbDelete.Visible = false;
            this.pbDelete.Click += new System.EventHandler(this.deletePicture_Click);
            this.pbDelete.MouseEnter += new System.EventHandler(this.pbDelete_MouseEnter);
            this.pbDelete.MouseLeave += new System.EventHandler(this.pbDelete_MouseLeave);
            // 
            // pbPicture
            // 
            this.pbPicture.BackColor = System.Drawing.Color.Black;
            this.pbPicture.Cursor = System.Windows.Forms.Cursors.Default;
            this.pbPicture.Location = new System.Drawing.Point(10, 10);
            this.pbPicture.Name = "pbPicture";
            this.pbPicture.Size = new System.Drawing.Size(160, 220);
            this.pbPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPicture.TabIndex = 5;
            this.pbPicture.TabStop = false;
            this.pbPicture.Click += new System.EventHandler(this.pbPicture_Click);
            // 
            // lbWatchedEp
            // 
            this.lbWatchedEp.AutoSize = true;
            this.lbWatchedEp.Enabled = false;
            this.lbWatchedEp.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbWatchedEp.ForeColor = System.Drawing.SystemColors.Menu;
            this.lbWatchedEp.Location = new System.Drawing.Point(101, 348);
            this.lbWatchedEp.Name = "lbWatchedEp";
            this.lbWatchedEp.Size = new System.Drawing.Size(13, 19);
            this.lbWatchedEp.TabIndex = 4;
            this.lbWatchedEp.Text = "/";
            this.lbWatchedEp.Visible = false;
            // 
            // lbLenght
            // 
            this.lbLenght.AutoSize = true;
            this.lbLenght.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbLenght.ForeColor = System.Drawing.SystemColors.Menu;
            this.lbLenght.Location = new System.Drawing.Point(8, 294);
            this.lbLenght.Name = "lbLenght";
            this.lbLenght.Size = new System.Drawing.Size(63, 19);
            this.lbLenght.TabIndex = 27;
            this.lbLenght.Text = "Lenght";
            this.lbLenght.Visible = false;
            // 
            // ItemDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(538, 399);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ItemDetailForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Item";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ItemDetailForm_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDeletePic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbReloadPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFavourite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.PictureBox pbPicture;
        private System.Windows.Forms.Label lbListGroup;
        private System.Windows.Forms.TextBox txbTitle;
        private System.Windows.Forms.TextBox txbScore;
        private System.Windows.Forms.TextBox txbNotes;
        private System.Windows.Forms.TextBox txbWatchedEp;
        private System.Windows.Forms.TextBox txbTotalEp;
        private System.Windows.Forms.Label lbNotes;
        private System.Windows.Forms.Label lbScore;
        private System.Windows.Forms.Label lbTotalEp;
        private System.Windows.Forms.CheckBox chDubbed;
        private System.Windows.Forms.ComboBox cbListGroup;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbWatchedEp;
        private System.Windows.Forms.PictureBox pbDelete;
        private System.Windows.Forms.PictureBox pbFavourite;
        private System.Windows.Forms.PictureBox pbSave;
        private System.Windows.Forms.TextBox txbPictureUrl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbUrl;
        private System.Windows.Forms.Label lbUrl;
        private System.Windows.Forms.Label lbCurrentSe;
        private System.Windows.Forms.TextBox txbCurrentSe;
        private System.Windows.Forms.Label lbTotalSe;
        private System.Windows.Forms.TextBox txbTotalSe;
        private System.Windows.Forms.Label lbSeason_Platform;
        private System.Windows.Forms.Label lbYear;
        private System.Windows.Forms.TextBox txbYear;
        private System.Windows.Forms.ComboBox cbSeason_Platform;
        private System.Windows.Forms.CheckBox chFinished;
        private System.Windows.Forms.CheckBox chOwned;
        private System.Windows.Forms.PictureBox pbReloadPic;
        private System.Windows.Forms.PictureBox pbDeletePic;
        private System.Windows.Forms.TextBox txbLenght;
        private System.Windows.Forms.Label lbLenght;
    }
}