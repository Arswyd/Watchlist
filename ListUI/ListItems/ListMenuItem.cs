using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListUI.ListItems
{
    public partial class ListMenuItem : UserControl
    {
        string active;
        LibraryUI callingForm;

        public ListMenuItem(string activeGroup, LibraryUI libraryUI)
        {
            InitializeComponent();

            callingForm = libraryUI;
            active = activeGroup;
        }

        public void MenuItemName(string z)
        {
            lbListGroupName.Text = z;
        }

        public void MenuItemCount(string r)
        {
            lbListGroupCount.Text = r;
        }

        public void ActiveColor()
        {
            Color myColor = Color.FromArgb(255, 40, 40, 60);
            panel1.BackColor = myColor;
        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            if (lbListGroupName.Text != active)
            {
                Color myColor = Color.FromArgb(255, 40, 40, 60);
                panel1.BackColor = myColor;
            }
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            callingForm.WireUpRequest(lbListGroupName.Text);
        }

        private void listGroupName_Click(object sender, EventArgs e)
        {
            this.panel1_Click(sender, e);
        }

        private void listGroupCount_Click(object sender, EventArgs e)
        {
            this.panel1_Click(sender, e);
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            if (lbListGroupName.Text != active)
            {
                panel1.BackColor = Color.Transparent;
            }
        }
    }
}
