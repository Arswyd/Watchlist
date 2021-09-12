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
        private string active;
        IWireUpRequest callingForm;
        public ListMenuItem(string activeGroup, IWireUpRequest caller)
        {
            InitializeComponent();

            callingForm = caller;
            active = activeGroup;

        }

        public void MenuItemName(string z)
        {
            listGroupName.Text = z;
        }

        public void MenuItemCount(string r)
        {
            listGroupCount.Text = r;
        }

        public void ActiveColor()
        {
            Color myColor = Color.FromArgb(255, 40, 40, 60);
            panel1.BackColor = myColor;
        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            if (listGroupName.Text != active)
            {
                Color myColor = Color.FromArgb(255, 40, 40, 60);
                panel1.BackColor = myColor;
                //listGroupCount.Visible = true;
            }
        }

        private void ListMenuItem_MouseLeave(object sender, EventArgs e)
        {
            if (listGroupName.Text != active)
            {
                panel1.BackColor = Color.Transparent;
                //listGroupCount.Visible = false;
            }
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            callingForm.WireUpRequest(listGroupName.Text);
        }

        private void listGroupName_Click(object sender, EventArgs e)
        {
            this.panel1_Click(sender, e);
        }

        private void listGroupCount_Click(object sender, EventArgs e)
        {
            this.panel1_Click(sender, e);
        }
    }
}
