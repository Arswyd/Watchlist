namespace ListUI.ListItems
{
    partial class ListHeader
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
            this.headerName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // headerName
            // 
            this.headerName.AutoSize = true;
            this.headerName.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.headerName.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.headerName.Location = new System.Drawing.Point(5, 20);
            this.headerName.Name = "headerName";
            this.headerName.Size = new System.Drawing.Size(108, 32);
            this.headerName.TabIndex = 0;
            this.headerName.Text = "Header";
            // 
            // ListHeader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.Controls.Add(this.headerName);
            this.Name = "ListHeader";
            this.Size = new System.Drawing.Size(1100, 55);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label headerName;
    }
}
