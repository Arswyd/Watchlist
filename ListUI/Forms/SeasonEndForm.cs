using ListLibrary.Database;
using ListLibrary.Model;
using ListUI.ListItems;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ListUI.Forms
{
    public partial class SeasonEndForm : Form
    {
        private SeriesModel seriesModel;
        private ListItem listItem;
        private LibraryUI mainForm;

        public SeasonEndForm(LibraryUI libraryUI, ListItem currentListItem, SeriesModel seasonEndSeriesModel)
        {
            InitializeComponent();

            seriesModel = seasonEndSeriesModel;
            listItem = currentListItem;
            mainForm = libraryUI;
        }

        private void btnSeasonEnd_Click(object sender, EventArgs e)
        {
            seriesModel.WatchedEp++;
            seriesModel.ListGroup = "Season Completed";

            SqliteDataAccess.UpdateSeries(seriesModel);
            mainForm.WireUpLibraryForm();
            this.Close();
        }

        private void btnFinishedSeries_Click(object sender, EventArgs e)
        {
            seriesModel.WatchedEp++;
            seriesModel.ListGroup = "Completed";

            SqliteDataAccess.UpdateSeries(seriesModel);
            mainForm.WireUpLibraryForm();
            this.Close();
        }

        private void btnNextSeason_Click(object sender, EventArgs e)
        {
            int nextSeasonEp;
            bool nextSeasonEpValid = int.TryParse(txbNextSeasonEP.Text, out nextSeasonEp);

            if (!nextSeasonEpValid)
            {
                txbNextSeasonEP.BackColor = Color.LightCoral;
                return;
            }

            seriesModel.CurrentSe++;
            seriesModel.TotalEp = nextSeasonEp;
            seriesModel.WatchedEp = 0;

            SqliteDataAccess.UpdateSeries(seriesModel);

            listItem.SetItemEpisodeText("S" + seriesModel.CurrentSe.ToString() + " E" + seriesModel.WatchedEp.ToString());
            this.Close();
        }
    }
}
