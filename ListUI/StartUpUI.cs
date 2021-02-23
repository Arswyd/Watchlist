using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListUI
{
    public partial class StartUpUI : Form
    {
        string startuplist;
        public StartUpUI()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            startuplist = "Anime";
            this.Enabled = false;
            this.Hide();
            LibraryUI frm = new LibraryUI(startuplist);
            frm.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            startuplist = "Series";
            this.Enabled = false;
            this.Hide();
            LibraryUI frm = new LibraryUI(startuplist);
            frm.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            startuplist = "Game";
            this.Enabled = false;
            this.Hide();
            LibraryUI frm = new LibraryUI(startuplist);
            frm.ShowDialog();
            this.Close();
        }

        private void StartUpUI_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
