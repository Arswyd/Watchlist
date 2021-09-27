using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ListLibrary.Model;

namespace ListUI.ListItems
{
    public partial class ListHeader : UserControl
    {
        public ListHeader()
        {
            InitializeComponent();
        }
        public void HeaderName(string headerText)
        {
            headerName.Text = headerText;
        }
    }
}
