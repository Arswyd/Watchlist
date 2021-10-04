﻿
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
            this.bUp = new System.Windows.Forms.Button();
            this.bDown = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bDelete = new System.Windows.Forms.Button();
            this.txbHeaderEdit = new System.Windows.Forms.TextBox();
            this.bSave = new System.Windows.Forms.Button();
            this.bAdd = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lvLogs = new System.Windows.Forms.ListView();
            this.colDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLog = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.bDeleteGame = new System.Windows.Forms.Button();
            this.bDeleteSeries = new System.Windows.Forms.Button();
            this.bDeleteAnime = new System.Windows.Forms.Button();
            this.bExportG = new System.Windows.Forms.Button();
            this.bExportS = new System.Windows.Forms.Button();
            this.bExportA = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.bDownloadPicG = new System.Windows.Forms.Button();
            this.bDownloadPicS = new System.Windows.Forms.Button();
            this.bDownloadPicA = new System.Windows.Forms.Button();
            this.bImportG = new System.Windows.Forms.Button();
            this.bImportS = new System.Windows.Forms.Button();
            this.bImportA = new System.Windows.Forms.Button();
            this.bDeleteLog = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvHeaders
            // 
            this.lvHeaders.BackColor = System.Drawing.SystemColors.Window;
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
            this.lvHeaders.Size = new System.Drawing.Size(261, 362);
            this.lvHeaders.TabIndex = 0;
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
            this.cbListType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbListType.FormattingEnabled = true;
            this.cbListType.Location = new System.Drawing.Point(24, 24);
            this.cbListType.Name = "cbListType";
            this.cbListType.Size = new System.Drawing.Size(261, 24);
            this.cbListType.TabIndex = 1;
            this.cbListType.SelectionChangeCommitted += new System.EventHandler(this.cbListType_SelectionChangeCommitted);
            // 
            // bUp
            // 
            this.bUp.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bUp.Location = new System.Drawing.Point(311, 137);
            this.bUp.Name = "bUp";
            this.bUp.Size = new System.Drawing.Size(78, 33);
            this.bUp.TabIndex = 2;
            this.bUp.Text = "Up";
            this.bUp.UseVisualStyleBackColor = true;
            this.bUp.Click += new System.EventHandler(this.bUp_Click);
            // 
            // bDown
            // 
            this.bDown.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bDown.Location = new System.Drawing.Point(311, 176);
            this.bDown.Name = "bDown";
            this.bDown.Size = new System.Drawing.Size(78, 33);
            this.bDown.TabIndex = 3;
            this.bDown.Text = "Down";
            this.bDown.UseVisualStyleBackColor = true;
            this.bDown.Click += new System.EventHandler(this.bDown_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bDelete);
            this.groupBox1.Controls.Add(this.txbHeaderEdit);
            this.groupBox1.Controls.Add(this.bSave);
            this.groupBox1.Controls.Add(this.bAdd);
            this.groupBox1.Controls.Add(this.bDown);
            this.groupBox1.Controls.Add(this.bUp);
            this.groupBox1.Controls.Add(this.cbListType);
            this.groupBox1.Controls.Add(this.lvHeaders);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(408, 480);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Menu Setting";
            // 
            // bDelete
            // 
            this.bDelete.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bDelete.Location = new System.Drawing.Point(311, 301);
            this.bDelete.Name = "bDelete";
            this.bDelete.Size = new System.Drawing.Size(78, 33);
            this.bDelete.TabIndex = 7;
            this.bDelete.Text = "Delete";
            this.bDelete.UseVisualStyleBackColor = true;
            this.bDelete.Click += new System.EventHandler(this.bDelete_Click);
            // 
            // txbHeaderEdit
            // 
            this.txbHeaderEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txbHeaderEdit.Location = new System.Drawing.Point(23, 430);
            this.txbHeaderEdit.Name = "txbHeaderEdit";
            this.txbHeaderEdit.Size = new System.Drawing.Size(260, 23);
            this.txbHeaderEdit.TabIndex = 6;
            // 
            // bSave
            // 
            this.bSave.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bSave.Location = new System.Drawing.Point(311, 425);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(78, 33);
            this.bSave.TabIndex = 5;
            this.bSave.Text = "Save";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // bAdd
            // 
            this.bAdd.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bAdd.Location = new System.Drawing.Point(311, 262);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(78, 33);
            this.bAdd.TabIndex = 4;
            this.bAdd.Text = "Add new";
            this.bAdd.UseVisualStyleBackColor = true;
            this.bAdd.Click += new System.EventHandler(this.bAdd_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lvLogs);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox2.Location = new System.Drawing.Point(426, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(763, 480);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Log";
            // 
            // lvLogs
            // 
            this.lvLogs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDate,
            this.colLog});
            this.lvLogs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lvLogs.FullRowSelect = true;
            this.lvLogs.GridLines = true;
            this.lvLogs.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvLogs.HideSelection = false;
            this.lvLogs.Location = new System.Drawing.Point(28, 28);
            this.lvLogs.MultiSelect = false;
            this.lvLogs.Name = "lvLogs";
            this.lvLogs.Size = new System.Drawing.Size(700, 430);
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
            this.groupBox3.Controls.Add(this.bDeleteGame);
            this.groupBox3.Controls.Add(this.bDeleteSeries);
            this.groupBox3.Controls.Add(this.bDeleteAnime);
            this.groupBox3.Controls.Add(this.bExportG);
            this.groupBox3.Controls.Add(this.bExportS);
            this.groupBox3.Controls.Add(this.bExportA);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox3.Location = new System.Drawing.Point(12, 498);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(318, 100);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Export";
            // 
            // bDeleteGame
            // 
            this.bDeleteGame.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bDeleteGame.Location = new System.Drawing.Point(215, 58);
            this.bDeleteGame.Name = "bDeleteGame";
            this.bDeleteGame.Size = new System.Drawing.Size(90, 33);
            this.bDeleteGame.TabIndex = 11;
            this.bDeleteGame.Text = "Delete Games";
            this.bDeleteGame.UseVisualStyleBackColor = true;
            this.bDeleteGame.Click += new System.EventHandler(this.bDeleteGame_Click);
            // 
            // bDeleteSeries
            // 
            this.bDeleteSeries.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bDeleteSeries.Location = new System.Drawing.Point(119, 58);
            this.bDeleteSeries.Name = "bDeleteSeries";
            this.bDeleteSeries.Size = new System.Drawing.Size(90, 33);
            this.bDeleteSeries.TabIndex = 10;
            this.bDeleteSeries.Text = "Delete Series";
            this.bDeleteSeries.UseVisualStyleBackColor = true;
            this.bDeleteSeries.Click += new System.EventHandler(this.bDeleteSeries_Click);
            // 
            // bDeleteAnime
            // 
            this.bDeleteAnime.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bDeleteAnime.Location = new System.Drawing.Point(23, 58);
            this.bDeleteAnime.Name = "bDeleteAnime";
            this.bDeleteAnime.Size = new System.Drawing.Size(90, 33);
            this.bDeleteAnime.TabIndex = 9;
            this.bDeleteAnime.Text = "Delete Anime";
            this.bDeleteAnime.UseVisualStyleBackColor = true;
            this.bDeleteAnime.Click += new System.EventHandler(this.bDeleteAnime_Click);
            // 
            // bExportG
            // 
            this.bExportG.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bExportG.Location = new System.Drawing.Point(212, 19);
            this.bExportG.Name = "bExportG";
            this.bExportG.Size = new System.Drawing.Size(90, 33);
            this.bExportG.TabIndex = 6;
            this.bExportG.Text = "Export Games";
            this.bExportG.UseVisualStyleBackColor = true;
            this.bExportG.Click += new System.EventHandler(this.bExportG_Click);
            // 
            // bExportS
            // 
            this.bExportS.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bExportS.Location = new System.Drawing.Point(128, 19);
            this.bExportS.Name = "bExportS";
            this.bExportS.Size = new System.Drawing.Size(78, 33);
            this.bExportS.TabIndex = 4;
            this.bExportS.Text = "Export Series";
            this.bExportS.UseVisualStyleBackColor = true;
            this.bExportS.Click += new System.EventHandler(this.bExportS_Click);
            // 
            // bExportA
            // 
            this.bExportA.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bExportA.Location = new System.Drawing.Point(23, 19);
            this.bExportA.Name = "bExportA";
            this.bExportA.Size = new System.Drawing.Size(78, 33);
            this.bExportA.TabIndex = 2;
            this.bExportA.Text = "Export Anime";
            this.bExportA.UseVisualStyleBackColor = true;
            this.bExportA.Click += new System.EventHandler(this.bExportA_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.bDownloadPicG);
            this.groupBox4.Controls.Add(this.bDownloadPicS);
            this.groupBox4.Controls.Add(this.bDownloadPicA);
            this.groupBox4.Controls.Add(this.bImportG);
            this.groupBox4.Controls.Add(this.bImportS);
            this.groupBox4.Controls.Add(this.bImportA);
            this.groupBox4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox4.Location = new System.Drawing.Point(336, 498);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(556, 100);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Import";
            // 
            // bDownloadPicG
            // 
            this.bDownloadPicG.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bDownloadPicG.Location = new System.Drawing.Point(342, 58);
            this.bDownloadPicG.Name = "bDownloadPicG";
            this.bDownloadPicG.Size = new System.Drawing.Size(78, 33);
            this.bDownloadPicG.TabIndex = 10;
            this.bDownloadPicG.Text = "S Pic Games";
            this.bDownloadPicG.UseVisualStyleBackColor = true;
            this.bDownloadPicG.Click += new System.EventHandler(this.bDownloadPicG_Click);
            // 
            // bDownloadPicS
            // 
            this.bDownloadPicS.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bDownloadPicS.Location = new System.Drawing.Point(174, 58);
            this.bDownloadPicS.Name = "bDownloadPicS";
            this.bDownloadPicS.Size = new System.Drawing.Size(78, 33);
            this.bDownloadPicS.TabIndex = 9;
            this.bDownloadPicS.Text = "D Pic Series";
            this.bDownloadPicS.UseVisualStyleBackColor = true;
            this.bDownloadPicS.Click += new System.EventHandler(this.bDownloadPicS_Click);
            // 
            // bDownloadPicA
            // 
            this.bDownloadPicA.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bDownloadPicA.Location = new System.Drawing.Point(6, 58);
            this.bDownloadPicA.Name = "bDownloadPicA";
            this.bDownloadPicA.Size = new System.Drawing.Size(78, 33);
            this.bDownloadPicA.TabIndex = 8;
            this.bDownloadPicA.Text = "D Pic Anime";
            this.bDownloadPicA.UseVisualStyleBackColor = true;
            this.bDownloadPicA.Click += new System.EventHandler(this.bDownloadPicA_Click);
            // 
            // bImportG
            // 
            this.bImportG.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bImportG.Location = new System.Drawing.Point(342, 19);
            this.bImportG.Name = "bImportG";
            this.bImportG.Size = new System.Drawing.Size(83, 33);
            this.bImportG.TabIndex = 7;
            this.bImportG.Text = "Import Games";
            this.bImportG.UseVisualStyleBackColor = true;
            this.bImportG.Click += new System.EventHandler(this.bImportG_Click);
            // 
            // bImportS
            // 
            this.bImportS.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bImportS.Location = new System.Drawing.Point(174, 19);
            this.bImportS.Name = "bImportS";
            this.bImportS.Size = new System.Drawing.Size(78, 33);
            this.bImportS.TabIndex = 5;
            this.bImportS.Text = "Import Series";
            this.bImportS.UseVisualStyleBackColor = true;
            this.bImportS.Click += new System.EventHandler(this.bImportS_Click);
            // 
            // bImportA
            // 
            this.bImportA.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bImportA.Location = new System.Drawing.Point(6, 19);
            this.bImportA.Name = "bImportA";
            this.bImportA.Size = new System.Drawing.Size(78, 33);
            this.bImportA.TabIndex = 3;
            this.bImportA.Text = "Import Anime";
            this.bImportA.UseVisualStyleBackColor = true;
            this.bImportA.Click += new System.EventHandler(this.bImportA_Click);
            // 
            // bDeleteLog
            // 
            this.bDeleteLog.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bDeleteLog.Location = new System.Drawing.Point(1099, 556);
            this.bDeleteLog.Name = "bDeleteLog";
            this.bDeleteLog.Size = new System.Drawing.Size(90, 33);
            this.bDeleteLog.TabIndex = 8;
            this.bDeleteLog.Text = "Delete Logs";
            this.bDeleteLog.UseVisualStyleBackColor = true;
            this.bDeleteLog.Click += new System.EventHandler(this.bTruncateLog_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(898, 509);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(291, 23);
            this.progressBar1.TabIndex = 9;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(1237, 611);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.bDeleteLog);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SettingsForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvHeaders;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ComboBox cbListType;
        private System.Windows.Forms.Button bUp;
        private System.Windows.Forms.Button bDown;
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
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Button bAdd;
        private System.Windows.Forms.Button bDelete;
        private System.Windows.Forms.ColumnHeader colOrder;
        private System.Windows.Forms.Button bDeleteLog;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button bDeleteGame;
        private System.Windows.Forms.Button bDeleteSeries;
        private System.Windows.Forms.Button bDeleteAnime;
        private System.Windows.Forms.Button bDownloadPicG;
        private System.Windows.Forms.Button bDownloadPicS;
        private System.Windows.Forms.Button bDownloadPicA;
    }
}