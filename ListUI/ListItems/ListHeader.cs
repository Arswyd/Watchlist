using System.Windows.Forms;

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
