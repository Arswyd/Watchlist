
namespace ListUI.Forms
{
    partial class SettingsForm
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
            this.lvHeaders = new System.Windows.Forms.ListView();
            this.colOrder = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cbListType = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pbSave = new System.Windows.Forms.PictureBox();
            this.pbDeleteRow = new System.Windows.Forms.PictureBox();
            this.pbAddRow = new System.Windows.Forms.PictureBox();
            this.pbMoveDown = new System.Windows.Forms.PictureBox();
            this.pbMoveUp = new System.Windows.Forms.PictureBox();
            this.txbHeaderEdit = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lvLogs = new System.Windows.Forms.ListView();
            this.colDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLog = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.bExportG = new System.Windows.Forms.Button();
            this.bExportS = new System.Windows.Forms.Button();
            this.bExportA = new System.Windows.Forms.Button();
            this.bDeleteGame = new System.Windows.Forms.Button();
            this.bDeleteSeries = new System.Windows.Forms.Button();
            this.bDeleteAnime = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.bImportG = new System.Windows.Forms.Button();
            this.bImportS = new System.Windows.Forms.Button();
            this.bImportA = new System.Windows.Forms.Button();
            this.bDownloadPicG = new System.Windows.Forms.Button();
            this.bDownloadPicS = new System.Windows.Forms.Button();
            this.bDownloadPicA = new System.Windows.Forms.Button();
            this.bDeleteLog = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.bExportLogs = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDeleteRow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAddRow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMoveDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMoveUp)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvHeaders
            // 
            this.lvHeaders.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lvHeaders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colOrder,
            this.colName});
            this.lvHeaders.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lvHeaders.FullRowSelect = true;
            this.lvHeaders.GridLines = true;
            this.lvHeaders.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvHeaders.HideSelection = false;
            this.lvHeaders.Location = new System.Drawing.Point(23, 58);
            this.lvHeaders.MultiSelect = false;
            this.lvHeaders.Name = "lvHeaders";
            this.lvHeaders.Size = new System.Drawing.Size(260, 328);
            this.lvHeaders.TabIndex = 1;
            this.lvHeaders.UseCompatibleStateImageBehavior = false;
            this.lvHeaders.View = System.Windows.Forms.View.Details;
            this.lvHeaders.SelectedIndexChanged += new System.EventHandler(this.lvHeaders_SelectedIndexChanged);
            // 
            // colOrder
            // 
            this.colOrder.Text = "Order";
            // 
            // colName
            // 
            this.colName.Text = "HeaderName";
            this.colName.Width = 196;
            // 
            // cbListType
            // 
            this.cbListType.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.cbListType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbListType.FormattingEnabled = true;
            this.cbListType.Location = new System.Drawing.Point(24, 24);
            this.cbListType.Name = "cbListType";
            this.cbListType.Size = new System.Drawing.Size(260, 24);
            this.cbListType.TabIndex = 0;
            this.cbListType.SelectionChangeCommitted += new System.EventHandler(this.cbListType_SelectionChangeCommitted);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pbSave);
            this.groupBox1.Controls.Add(this.pbDeleteRow);
            this.groupBox1.Controls.Add(this.pbAddRow);
            this.groupBox1.Controls.Add(this.pbMoveDown);
            this.groupBox1.Controls.Add(this.pbMoveUp);
            this.groupBox1.Controls.Add(this.txbHeaderEdit);
            this.groupBox1.Controls.Add(this.cbListType);
            this.groupBox1.Controls.Add(this.lvHeaders);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(370, 430);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Menu Setting";
            // 
            // pbSave
            // 
            this.pbSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbSave.Image = global::ListUI.Properties.Resources.save;
            this.pbSave.Location = new System.Drawing.Point(300, 375);
            this.pbSave.Name = "pbSave";
            this.pbSave.Size = new System.Drawing.Size(40, 40);
            this.pbSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSave.TabIndex = 22;
            this.pbSave.TabStop = false;
            this.pbSave.Click += new System.EventHandler(this.pbSave_Click);
            this.pbSave.MouseEnter += new System.EventHandler(this.pbSave_MouseEnter);
            this.pbSave.MouseLeave += new System.EventHandler(this.pbSave_MouseLeave);
            // 
            // pbDeleteRow
            // 
            this.pbDeleteRow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbDeleteRow.Image = global::ListUI.Properties.Resources.delete_row;
            this.pbDeleteRow.Location = new System.Drawing.Point(300, 232);
            this.pbDeleteRow.Name = "pbDeleteRow";
            this.pbDeleteRow.Size = new System.Drawing.Size(40, 40);
            this.pbDeleteRow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbDeleteRow.TabIndex = 21;
            this.pbDeleteRow.TabStop = false;
            this.pbDeleteRow.Click += new System.EventHandler(this.pbDeleteRow_Click);
            this.pbDeleteRow.MouseEnter += new System.EventHandler(this.pbDeleteRow_MouseEnter);
            this.pbDeleteRow.MouseLeave += new System.EventHandler(this.pbDeleteRow_MouseLeave);
            // 
            // pbAddRow
            // 
            this.pbAddRow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbAddRow.Image = global::ListUI.Properties.Resources.add_row;
            this.pbAddRow.Location = new System.Drawing.Point(300, 186);
            this.pbAddRow.Name = "pbAddRow";
            this.pbAddRow.Size = new System.Drawing.Size(40, 40);
            this.pbAddRow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAddRow.TabIndex = 20;
            this.pbAddRow.TabStop = false;
            this.pbAddRow.Click += new System.EventHandler(this.pbAddRow_Click);
            this.pbAddRow.MouseEnter += new System.EventHandler(this.pbAddRow_MouseEnter);
            this.pbAddRow.MouseLeave += new System.EventHandler(this.pbAddRow_MouseLeave);
            // 
            // pbMoveDown
            // 
            this.pbMoveDown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbMoveDown.Image = global::ListUI.Properties.Resources.down;
            this.pbMoveDown.Location = new System.Drawing.Point(300, 278);
            this.pbMoveDown.Name = "pbMoveDown";
            this.pbMoveDown.Size = new System.Drawing.Size(40, 40);
            this.pbMoveDown.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMoveDown.TabIndex = 19;
            this.pbMoveDown.TabStop = false;
            this.pbMoveDown.Click += new System.EventHandler(this.pbMoveDown_Click);
            this.pbMoveDown.MouseEnter += new System.EventHandler(this.pbMoveDown_MouseEnter);
            this.pbMoveDown.MouseLeave += new System.EventHandler(this.pbMoveDown_MouseLeave);
            // 
            // pbMoveUp
            // 
            this.pbMoveUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbMoveUp.Image = global::ListUI.Properties.Resources.up;
            this.pbMoveUp.Location = new System.Drawing.Point(300, 140);
            this.pbMoveUp.Name = "pbMoveUp";
            this.pbMoveUp.Size = new System.Drawing.Size(40, 40);
            this.pbMoveUp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMoveUp.TabIndex = 18;
            this.pbMoveUp.TabStop = false;
            this.pbMoveUp.Click += new System.EventHandler(this.pbMoveUp_Click);
            this.pbMoveUp.MouseEnter += new System.EventHandler(this.pbMoveUp_MouseEnter);
            this.pbMoveUp.MouseLeave += new System.EventHandler(this.pbMoveUp_MouseLeave);
            // 
            // txbHeaderEdit
            // 
            this.txbHeaderEdit.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txbHeaderEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txbHeaderEdit.Location = new System.Drawing.Point(23, 392);
            this.txbHeaderEdit.Name = "txbHeaderEdit";
            this.txbHeaderEdit.Size = new System.Drawing.Size(260, 23);
            this.txbHeaderEdit.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lvLogs);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox2.Location = new System.Drawing.Point(388, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(763, 430);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Log";
            // 
            // lvLogs
            // 
            this.lvLogs.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lvLogs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDate,
            this.colLog});
            this.lvLogs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lvLogs.FullRowSelect = true;
            this.lvLogs.GridLines = true;
            this.lvLogs.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvLogs.HideSelection = false;
            this.lvLogs.Location = new System.Drawing.Point(28, 24);
            this.lvLogs.MultiSelect = false;
            this.lvLogs.Name = "lvLogs";
            this.lvLogs.Size = new System.Drawing.Size(700, 391);
            this.lvLogs.TabIndex = 0;
            this.lvLogs.UseCompatibleStateImageBehavior = false;
            this.lvLogs.View = System.Windows.Forms.View.Details;
            // 
            // colDate
            // 
            this.colDate.Text = "Date";
            this.colDate.Width = 115;
            // 
            // colLog
            // 
            this.colLog.Text = "Log Text";
            this.colLog.Width = 579;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.bExportG);
            this.groupBox3.Controls.Add(this.bExportS);
            this.groupBox3.Controls.Add(this.bExportA);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox3.Location = new System.Drawing.Point(12, 448);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(238, 80);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Export";
            // 
            // bExportG
            // 
            this.bExportG.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bExportG.Location = new System.Drawing.Point(160, 19);
            this.bExportG.Name = "bExportG";
            this.bExportG.Size = new System.Drawing.Size(70, 50);
            this.bExportG.TabIndex = 2;
            this.bExportG.Text = "Export Games";
            this.bExportG.UseVisualStyleBackColor = true;
            this.bExportG.Click += new System.EventHandler(this.bExportG_Click);
            // 
            // bExportS
            // 
            this.bExportS.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bExportS.Location = new System.Drawing.Point(84, 19);
            this.bExportS.Name = "bExportS";
            this.bExportS.Size = new System.Drawing.Size(70, 50);
            this.bExportS.TabIndex = 1;
            this.bExportS.Text = "Export Series";
            this.bExportS.UseVisualStyleBackColor = true;
            this.bExportS.Click += new System.EventHandler(this.bExportS_Click);
            // 
            // bExportA
            // 
            this.bExportA.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bExportA.Location = new System.Drawing.Point(8, 19);
            this.bExportA.Name = "bExportA";
            this.bExportA.Size = new System.Drawing.Size(70, 50);
            this.bExportA.TabIndex = 0;
            this.bExportA.Text = "Export Anime";
            this.bExportA.UseVisualStyleBackColor = true;
            this.bExportA.Click += new System.EventHandler(this.bExportA_Click);
            // 
            // bDeleteGame
            // 
            this.bDeleteGame.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bDeleteGame.Location = new System.Drawing.Point(160, 19);
            this.bDeleteGame.Name = "bDeleteGame";
            this.bDeleteGame.Size = new System.Drawing.Size(70, 50);
            this.bDeleteGame.TabIndex = 2;
            this.bDeleteGame.Text = "Delete Games";
            this.bDeleteGame.UseVisualStyleBackColor = true;
            this.bDeleteGame.Click += new System.EventHandler(this.bDeleteGame_Click);
            // 
            // bDeleteSeries
            // 
            this.bDeleteSeries.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bDeleteSeries.Location = new System.Drawing.Point(84, 19);
            this.bDeleteSeries.Name = "bDeleteSeries";
            this.bDeleteSeries.Size = new System.Drawing.Size(70, 50);
            this.bDeleteSeries.TabIndex = 1;
            this.bDeleteSeries.Text = "Delete Series";
            this.bDeleteSeries.UseVisualStyleBackColor = true;
            this.bDeleteSeries.Click += new System.EventHandler(this.bDeleteSeries_Click);
            // 
            // bDeleteAnime
            // 
            this.bDeleteAnime.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bDeleteAnime.Location = new System.Drawing.Point(8, 19);
            this.bDeleteAnime.Name = "bDeleteAnime";
            this.bDeleteAnime.Size = new System.Drawing.Size(70, 50);
            this.bDeleteAnime.TabIndex = 0;
            this.bDeleteAnime.Text = "Delete Anime";
            this.bDeleteAnime.UseVisualStyleBackColor = true;
            this.bDeleteAnime.Click += new System.EventHandler(this.bDeleteAnime_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.bImportG);
            this.groupBox4.Controls.Add(this.bImportS);
            this.groupBox4.Controls.Add(this.bImportA);
            this.groupBox4.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox4.Location = new System.Drawing.Point(256, 448);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(238, 80);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Import";
            // 
            // bImportG
            // 
            this.bImportG.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bImportG.Location = new System.Drawing.Point(160, 19);
            this.bImportG.Name = "bImportG";
            this.bImportG.Size = new System.Drawing.Size(70, 50);
            this.bImportG.TabIndex = 2;
            this.bImportG.Text = "Import Games";
            this.bImportG.UseVisualStyleBackColor = true;
            this.bImportG.Click += new System.EventHandler(this.bImportG_Click);
            // 
            // bImportS
            // 
            this.bImportS.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bImportS.Location = new System.Drawing.Point(84, 19);
            this.bImportS.Name = "bImportS";
            this.bImportS.Size = new System.Drawing.Size(70, 50);
            this.bImportS.TabIndex = 1;
            this.bImportS.Text = "Import Series";
            this.bImportS.UseVisualStyleBackColor = true;
            this.bImportS.Click += new System.EventHandler(this.bImportS_Click);
            // 
            // bImportA
            // 
            this.bImportA.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bImportA.Location = new System.Drawing.Point(8, 19);
            this.bImportA.Name = "bImportA";
            this.bImportA.Size = new System.Drawing.Size(70, 50);
            this.bImportA.TabIndex = 0;
            this.bImportA.Text = "Import Anime";
            this.bImportA.UseVisualStyleBackColor = true;
            this.bImportA.Click += new System.EventHandler(this.bImportA_Click);
            // 
            // bDownloadPicG
            // 
            this.bDownloadPicG.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bDownloadPicG.Location = new System.Drawing.Point(160, 19);
            this.bDownloadPicG.Name = "bDownloadPicG";
            this.bDownloadPicG.Size = new System.Drawing.Size(70, 50);
            this.bDownloadPicG.TabIndex = 2;
            this.bDownloadPicG.Text = "Download Game Pics";
            this.bDownloadPicG.UseVisualStyleBackColor = true;
            this.bDownloadPicG.Click += new System.EventHandler(this.bDownloadPicG_Click);
            // 
            // bDownloadPicS
            // 
            this.bDownloadPicS.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bDownloadPicS.Location = new System.Drawing.Point(84, 19);
            this.bDownloadPicS.Name = "bDownloadPicS";
            this.bDownloadPicS.Size = new System.Drawing.Size(70, 50);
            this.bDownloadPicS.TabIndex = 1;
            this.bDownloadPicS.Text = "Download Series Pics";
            this.bDownloadPicS.UseVisualStyleBackColor = true;
            this.bDownloadPicS.Click += new System.EventHandler(this.bDownloadPicS_Click);
            // 
            // bDownloadPicA
            // 
            this.bDownloadPicA.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bDownloadPicA.Location = new System.Drawing.Point(8, 19);
            this.bDownloadPicA.Name = "bDownloadPicA";
            this.bDownloadPicA.Size = new System.Drawing.Size(70, 50);
            this.bDownloadPicA.TabIndex = 0;
            this.bDownloadPicA.Text = "Download Anime Pics";
            this.bDownloadPicA.UseVisualStyleBackColor = true;
            this.bDownloadPicA.Click += new System.EventHandler(this.bDownloadPicA_Click);
            // 
            // bDeleteLog
            // 
            this.bDeleteLog.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bDeleteLog.Location = new System.Drawing.Point(84, 19);
            this.bDeleteLog.Name = "bDeleteLog";
            this.bDeleteLog.Size = new System.Drawing.Size(70, 50);
            this.bDeleteLog.TabIndex = 1;
            this.bDeleteLog.Text = "Delete Logs";
            this.bDeleteLog.UseVisualStyleBackColor = true;
            this.bDeleteLog.Click += new System.EventHandler(this.bTruncateLog_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 540);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1139, 23);
            this.progressBar1.TabIndex = 9;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.bExportLogs);
            this.groupBox5.Controls.Add(this.bDeleteLog);
            this.groupBox5.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox5.Location = new System.Drawing.Point(988, 448);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(163, 80);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Logs";
            // 
            // bExportLogs
            // 
            this.bExportLogs.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bExportLogs.Location = new System.Drawing.Point(8, 19);
            this.bExportLogs.Name = "bExportLogs";
            this.bExportLogs.Size = new System.Drawing.Size(70, 50);
            this.bExportLogs.TabIndex = 0;
            this.bExportLogs.Text = "Export Logs";
            this.bExportLogs.UseVisualStyleBackColor = true;
            this.bExportLogs.Click += new System.EventHandler(this.bExportLogs_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.bDownloadPicA);
            this.groupBox6.Controls.Add(this.bDownloadPicS);
            this.groupBox6.Controls.Add(this.bDownloadPicG);
            this.groupBox6.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox6.Location = new System.Drawing.Point(500, 448);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(238, 80);
            this.groupBox6.TabIndex = 4;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Downlod Pics";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.bDeleteSeries);
            this.groupBox7.Controls.Add(this.bDeleteAnime);
            this.groupBox7.Controls.Add(this.bDeleteGame);
            this.groupBox7.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox7.Location = new System.Drawing.Point(744, 448);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(238, 80);
            this.groupBox7.TabIndex = 5;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Delete";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(1169, 571);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SettingsForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDeleteRow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAddRow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMoveDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMoveUp)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvHeaders;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ComboBox cbListType;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView lvLogs;
        private System.Windows.Forms.ColumnHeader colDate;
        private System.Windows.Forms.ColumnHeader colLog;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button bExportA;
        private System.Windows.Forms.Button bExportG;
        private System.Windows.Forms.Button bExportS;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button bImportG;
        private System.Windows.Forms.Button bImportS;
        private System.Windows.Forms.Button bImportA;
        private System.Windows.Forms.TextBox txbHeaderEdit;
        private System.Windows.Forms.ColumnHeader colOrder;
        private System.Windows.Forms.Button bDeleteLog;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button bDeleteGame;
        private System.Windows.Forms.Button bDeleteSeries;
        private System.Windows.Forms.Button bDeleteAnime;
        private System.Windows.Forms.Button bDownloadPicG;
        private System.Windows.Forms.Button bDownloadPicS;
        private System.Windows.Forms.Button bDownloadPicA;
        private System.Windows.Forms.PictureBox pbSave;
        private System.Windows.Forms.PictureBox pbDeleteRow;
        private System.Windows.Forms.PictureBox pbAddRow;
        private System.Windows.Forms.PictureBox pbMoveDown;
        private System.Windows.Forms.PictureBox pbMoveUp;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button bExportLogs;
    }
}