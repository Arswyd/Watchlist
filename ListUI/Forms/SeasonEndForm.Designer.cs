namespace ListUI.Forms
{
    partial class SeasonEndForm
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
            this.btnNextSeason = new System.Windows.Forms.Button();
            this.txbNextSeasonEP = new System.Windows.Forms.TextBox();
            this.btnSeasonEnd = new System.Windows.Forms.Button();
            this.btnFinishedSeries = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnNextSeason
            // 
            this.btnNextSeason.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnNextSeason.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnNextSeason.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnNextSeason.Location = new System.Drawing.Point(392, 69);
            this.btnNextSeason.Name = "btnNextSeason";
            this.btnNextSeason.Size = new System.Drawing.Size(120, 40);
            this.btnNextSeason.TabIndex = 0;
            this.btnNextSeason.Text = "Next season";
            this.btnNextSeason.UseVisualStyleBackColor = false;
            this.btnNextSeason.Click += new System.EventHandler(this.btnNextSeason_Click);
            // 
            // txbNextSeasonEP
            // 
            this.txbNextSeasonEP.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txbNextSeasonEP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txbNextSeasonEP.Location = new System.Drawing.Point(450, 15);
            this.txbNextSeasonEP.Name = "txbNextSeasonEP";
            this.txbNextSeasonEP.Size = new System.Drawing.Size(55, 26);
            this.txbNextSeasonEP.TabIndex = 2;
            this.txbNextSeasonEP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnSeasonEnd
            // 
            this.btnSeasonEnd.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSeasonEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSeasonEnd.Location = new System.Drawing.Point(12, 69);
            this.btnSeasonEnd.Name = "btnSeasonEnd";
            this.btnSeasonEnd.Size = new System.Drawing.Size(120, 40);
            this.btnSeasonEnd.TabIndex = 1;
            this.btnSeasonEnd.Text = "Season end";
            this.btnSeasonEnd.UseVisualStyleBackColor = false;
            this.btnSeasonEnd.Click += new System.EventHandler(this.btnSeasonEnd_Click);
            // 
            // btnFinishedSeries
            // 
            this.btnFinishedSeries.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnFinishedSeries.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnFinishedSeries.Location = new System.Drawing.Point(138, 69);
            this.btnFinishedSeries.Name = "btnFinishedSeries";
            this.btnFinishedSeries.Size = new System.Drawing.Size(120, 40);
            this.btnFinishedSeries.TabIndex = 3;
            this.btnFinishedSeries.Text = "Finished series";
            this.btnFinishedSeries.UseVisualStyleBackColor = false;
            this.btnFinishedSeries.Click += new System.EventHandler(this.btnFinishedSeries_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(437, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Please enter the number of episodes in the following season:";
            // 
            // SeasonEndForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(524, 121);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFinishedSeries);
            this.Controls.Add(this.txbNextSeasonEP);
            this.Controls.Add(this.btnSeasonEnd);
            this.Controls.Add(this.btnNextSeason);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SeasonEndForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SeasonEndForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNextSeason;
        private System.Windows.Forms.TextBox txbNextSeasonEP;
        private System.Windows.Forms.Button btnSeasonEnd;
        private System.Windows.Forms.Button btnFinishedSeries;
        private System.Windows.Forms.Label label1;
    }
}