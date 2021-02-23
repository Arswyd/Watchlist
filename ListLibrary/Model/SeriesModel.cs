using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListLibrary.Model
{
    public class SeriesModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string SeriesUrl { get; set; }
        public string PictureUrl { get; set; }
        public decimal Score { get; set; }
        public int Season { get; set; }
        public int TotalEp { get; set; }
        public int WatchedEp { get; set; }
        public bool Favourite { get; set; }
        public string Notes { get; set; }
        public string ListGroup { get; set; }


        public SeriesModel()
        {

        }

        public SeriesModel(string name, string seriesURL, string pictureURL, string score, string season, string totalEP, string watchedEP, bool favourite, string notes, string listGroup)
        {
            Name = name;
            SeriesUrl = seriesURL;
            PictureUrl = pictureURL;

            decimal scoreValue = 0;
            decimal.TryParse(score, out scoreValue);
            Score = scoreValue;

            int seasonValue = 0;
            int.TryParse(season, out seasonValue);
            Season = seasonValue;

            int totalEPValue = 0;
            int.TryParse(totalEP, out totalEPValue);
            TotalEp = totalEPValue;

            int watchedEPValue = 0;
            int.TryParse(watchedEP, out watchedEPValue);
            WatchedEp = watchedEPValue;

            Favourite = favourite;
            Notes = notes;
            ListGroup = listGroup;
        }
    }

}
