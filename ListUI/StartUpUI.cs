using ListLibrary.Database;
using System;
using System.Windows.Forms;

namespace ListUI
{
    public partial class StartUpUI : Form
    {
        string listType;
        bool isPrimaryClient;
        bool isShowingDeleted;
        public StartUpUI()
        {
            InitializeComponent();
            button1.Enabled = false;
            ApplicationStartup();
            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listType = "Anime";
            this.Enabled = false;
            this.Hide();
            LibraryUI frm = new LibraryUI(listType, isPrimaryClient, isShowingDeleted);
            frm.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listType = "Series";
            this.Enabled = false;
            this.Hide();
            LibraryUI frm = new LibraryUI(listType, isPrimaryClient, isShowingDeleted);
            frm.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listType = "Game";
            this.Enabled = false;
            this.Hide();
            LibraryUI frm = new LibraryUI(listType, isPrimaryClient, isShowingDeleted);
            frm.ShowDialog();
            this.Close();
        }

        private void StartUpUI_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        }

        private void ApplicationStartup()
        {
            isPrimaryClient = SqliteDataAccess.GetClientType() == 1;
            isShowingDeleted = SqliteDataAccess.GetShowingDeleted() == 1;
        }
    }
}
