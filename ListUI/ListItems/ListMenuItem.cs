using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ListUI.ListItems
{
    public partial class ListMenuItem : UserControl
    {
        bool isActive = false;
        LibraryUI callingForm;
        Color highlightedMenuItemColor = Color.FromArgb(255, 50, 130, 184);
        Color defaultMenuItemColor = Color.FromArgb(255, 15, 76, 117);
        Color defaultTextColor = Color.FromArgb(255, 187, 225, 250);

        public ListMenuItem(LibraryUI libraryUI)
        {
            InitializeComponent();

            callingForm = libraryUI;

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

        public void SetActive(bool _isActive)
        {
            isActive = _isActive;

            if (_isActive)
            {
                panel1.BackColor = highlightedMenuItemColor;
                lbListGroupName.ForeColor = Color.White;
                lbListGroupCount.ForeColor = Color.White;
            }
        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            foreach (var c in Parent.Controls.OfType<ListMenuItem>())
            {
                c.RevertColor();
            }

            if (!isActive)
            {
                panel1.BackColor = highlightedMenuItemColor;
            }
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            foreach (var c in Parent.Controls.OfType<ListMenuItem>())
            {
                c.SetActive(c == this ? true : false);
                c.RevertColor();
            }

            callingForm.WireUpRequest(lbListGroupName.Text, false);
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
            if (!isActive)
            {
                panel1.BackColor = defaultMenuItemColor;
                lbListGroupName.ForeColor = defaultTextColor;
                lbListGroupCount.ForeColor = defaultTextColor;
            }
        }

        private void ListMenuItem_MouseLeave(object sender, EventArgs e)
        {
            if (!isActive)
            {
                panel1.BackColor = defaultMenuItemColor;
            }
        }
    }
}
