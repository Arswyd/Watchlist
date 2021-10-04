using ListLibrary.Database;
using ListLibrary.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListUI.Forms
{
    public partial class SettingsForm : Form
    {
        List<HeaderModel> headers;
        List<LogModel> logs;
        HeaderModel selectedHeader;

        public SettingsForm()
        {
            InitializeComponent();

            WireUpDropDown();
            LoadLogs();
        }

        private void LoadLogs()
        {
            lvLogs.Items.Clear();
            logs = SqliteDataAccess.LoadLogs();

            foreach (var log in logs)
            {
                var lvitem = new ListViewItem(log.Date.ToString("yyyy.MM.dd. HH:mm"));
                lvitem.SubItems.Add(log.LogText);
                lvLogs.Items.Add(lvitem);
            }
        }

        private void WireUpDropDown()
        {
            cbListType.Items.Add("Anime");
            cbListType.Items.Add("Series");
            cbListType.Items.Add("Game");
        }

        private void cbListType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadHeaderListView();
        }

        private void LoadHeaderListView()
        {
            if (cbListType.SelectedItem.ToString() == "Anime")
                headers = SqliteDataAccess.LoadAnimeListHeaders();
            else if (cbListType.SelectedItem.ToString() == "Series")
                headers = SqliteDataAccess.LoadSeriesListHeaders();
            else if (cbListType.SelectedItem.ToString() == "Game")
                headers = SqliteDataAccess.LoadGameListHeaders();

            lvHeaders.Items.Clear();

            foreach (var header in headers)
            {
                var lvitem = new ListViewItem(header.SortOrder.ToString());
                lvitem.SubItems.Add(header.ListGroup);
                lvHeaders.Items.Add(lvitem);
            }
        }

        private void bUp_Click(object sender, EventArgs e)
        {
            var header = headers.Where(c => c.SortOrder == selectedHeader.SortOrder - 1).First();
            header.SortOrder++;
            SqliteDataAccess.UpdateHeader(header);
            selectedHeader.SortOrder--;
            SqliteDataAccess.UpdateHeader(selectedHeader);
            //txbHeaderEdit.Text = "";
            LoadHeaderListView();
            LoadLogs();
        }

        private void bDown_Click(object sender, EventArgs e)
        {
            var header = headers.Where(c => c.SortOrder == selectedHeader.SortOrder + 1).First();
            header.SortOrder--;
            SqliteDataAccess.UpdateHeader(header);
            selectedHeader.SortOrder++;
            SqliteDataAccess.UpdateHeader(selectedHeader);
            //txbHeaderEdit.Text = "";
            LoadHeaderListView();
            LoadLogs();
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            int neworder = 0;
            if (headers != null)
                neworder = headers.Max(c => c.SortOrder) + 1;

            if (headers != null && headers.Count < 15)
            {
                selectedHeader = new HeaderModel() { ListType = cbListType.Text, ListGroup = "New Group", SortOrder = neworder };
                SqliteDataAccess.SaveHeader(selectedHeader);
                LoadHeaderListView();
            }
            else
            {
                MessageBox.Show("No more headers can be added!");
            }

            LoadLogs();
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            if (lvHeaders.SelectedItems.Count != 0)
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to edit list group?", "Attention!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dialogResult == DialogResult.Yes)
                {
                    SqliteDataAccess.UpdateAnimeListGroup(txbHeaderEdit.Text, selectedHeader.ListGroup);
                    selectedHeader.ListGroup = txbHeaderEdit.Text;
                    SqliteDataAccess.UpdateHeader(selectedHeader);
                    txbHeaderEdit.Text = "";
                    LoadHeaderListView();
                }
            }
            else
            {
                MessageBox.Show("There is no selected item", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            LoadLogs();
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            if (lvHeaders.SelectedItems.Count != 0)
            {
                if(LoadList())
                {
                    MessageBox.Show("There are items in this list group!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    SqliteDataAccess.DeleteHeader(selectedHeader);
                    foreach (var header in headers.Where(c => c.SortOrder > selectedHeader.SortOrder))
                    {
                        header.SortOrder--;
                        SqliteDataAccess.UpdateHeader(header);
                    }
                    txbHeaderEdit.Text = "";
                    LoadHeaderListView();
                }
            }
            else
            {
                MessageBox.Show("There is no selected item", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            LoadLogs();
        }

        private bool LoadList()
        {
            List<ItemModel> itemlist = new List<ItemModel>();

            switch (cbListType.Text)
            {
                case "Anime":
                    itemlist.AddRange(SqliteDataAccess.LoadAnimeGroup("SELECT 1 FROM Anime WHERE ListGroup='" + selectedHeader.ListGroup + "' LIMIT 1"));
                    break;
                case "Game":
                    itemlist.AddRange(SqliteDataAccess.LoadGameGroup("SELECT 1 FROM Game WHERE ListGroup='" + selectedHeader.ListGroup + "' LIMIT 1"));
                    break;
                case "Series":
                    itemlist.AddRange(SqliteDataAccess.LoadSeriesGroup("SELECT 1 FROM Series WHERE ListGroup='" + selectedHeader.ListGroup + "' LIMIT 1"));
                    break;
            }

            return (itemlist.Count != 0) ? true : false;
          }

        private void lvHeaders_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvHeaders.SelectedItems.Count != 0)
            {
                selectedHeader = headers.Where(c => c.ListGroup == lvHeaders.SelectedItems[0].SubItems[1].Text).First();
                txbHeaderEdit.Text = selectedHeader.ListGroup;
            }
            else
            {
                selectedHeader = null;
                txbHeaderEdit.Text = "";
            }
        }

        private void bTruncateLog_Click(object sender, EventArgs e)
        {
            SqliteDataAccess.TruncateLog();
            LoadLogs();
        }
    }
}
