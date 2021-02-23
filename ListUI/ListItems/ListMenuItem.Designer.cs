namespace ListUI.ListItems
{
    partial class ListMenuItem
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.listGroupCount = new System.Windows.Forms.Label();
            this.listGroupName = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.panel1.Controls.Add(this.listGroupCount);
            this.panel1.Controls.Add(this.listGroupName);
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(185, 28);
            this.panel1.TabIndex = 0;
            this.panel1.Click += new System.EventHandler(this.panel1_Click);
            this.panel1.MouseEnter += new System.EventHandler(this.panel1_MouseEnter);
            // 
            // listGroupCount
            // 
            this.listGroupCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.listGroupCount.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.listGroupCount.Location = new System.Drawing.Point(150, 7);
            this.listGroupCount.Name = "listGroupCount";
            this.listGroupCount.Size = new System.Drawing.Size(28, 13);
            this.listGroupCount.TabIndex = 0;
            this.listGroupCount.Text = "999";
            this.listGroupCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.listGroupCount.Click += new System.EventHandler(this.listGroupCount_Click);
            // 
            // listGroupName
            // 
            this.listGroupName.AutoSize = true;
            this.listGroupName.BackColor = System.Drawing.Color.Transparent;
            this.listGroupName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.listGroupName.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.listGroupName.Location = new System.Drawing.Point(5, 5);
            this.listGroupName.Name = "listGroupName";
            this.listGroupName.Size = new System.Drawing.Size(84, 17);
            this.listGroupName.TabIndex = 0;
            this.listGroupName.Text = "Completed";
            this.listGroupName.Click += new System.EventHandler(this.listGroupName_Click);
            // 
            // ListMenuItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panel1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ListMenuItem";
            this.Size = new System.Drawing.Size(195, 38);
            this.MouseLeave += new System.EventHandler(this.ListMenuItem_MouseLeave);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label listGroupCount;
        private System.Windows.Forms.Label listGroupName;
    }
}
