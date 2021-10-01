
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
            this.button6 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
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
            this.groupBox2.Size = new System.Drawing.Size(458, 480);
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
            this.lvLogs.Location = new System.Drawing.Point(22, 31);
            this.lvLogs.MultiSelect = false;
            this.lvLogs.Name = "lvLogs";
            this.lvLogs.Size = new System.Drawing.Size(414, 427);
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
            this.colLog.Width = 295;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button6);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox3.Location = new System.Drawing.Point(12, 498);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(408, 100);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Export";
            // 
            // button6
            // 
            this.button6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button6.Location = new System.Drawing.Point(206, 40);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(78, 33);
            this.button6.TabIndex = 6;
            this.button6.Text = "Up";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button2.Location = new System.Drawing.Point(120, 40);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(78, 33);
            this.button2.TabIndex = 4;
            this.button2.Text = "Up";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button4.Location = new System.Drawing.Point(26, 40);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(78, 33);
            this.button4.TabIndex = 2;
            this.button4.Text = "Up";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button7);
            this.groupBox4.Controls.Add(this.button9);
            this.groupBox4.Controls.Add(this.button11);
            this.groupBox4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox4.Location = new System.Drawing.Point(426, 498);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(408, 100);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Import";
            // 
            // button7
            // 
            this.button7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button7.Location = new System.Drawing.Point(238, 32);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(78, 33);
            this.button7.TabIndex = 7;
            this.button7.Text = "Down";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button9.Location = new System.Drawing.Point(129, 32);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(78, 33);
            this.button9.TabIndex = 5;
            this.button9.Text = "Down";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // button11
            // 
            this.button11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button11.Location = new System.Drawing.Point(28, 32);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(78, 33);
            this.button11.TabIndex = 3;
            this.button11.Text = "Down";
            this.button11.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(906, 611);
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
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.TextBox txbHeaderEdit;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Button bAdd;
        private System.Windows.Forms.Button bDelete;
        private System.Windows.Forms.ColumnHeader colOrder;
    }
}