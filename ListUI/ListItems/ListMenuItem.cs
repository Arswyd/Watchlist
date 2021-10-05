using System;
using System.Drawing;
using System.Linq;
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

            lbListGroupName.Parent = panel1;
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
            foreach (var c in Parent.Controls.OfType<ListMenuItem>())
            {
                c.RevertColor();
            }

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

        public void RevertColor()
        {
            if (lbListGroupName.Text != active )
            {
                panel1.BackColor = Color.FromArgb(255, 35, 35, 50);
            }
        }

        private void ListMenuItem_MouseLeave(object sender, EventArgs e)
        {
            if (lbListGroupName.Text != active)
            {
                panel1.BackColor = Color.FromArgb(255, 35, 35, 50);
            }
        }
    }
}
