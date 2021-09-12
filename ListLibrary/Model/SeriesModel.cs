using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ListLibrary.Model
{
    public class SeriesModel : ListItemModel
    {

        public int WatchedSe { get; set; }
        public int WatchedEp { get; set; }
        public int TotalSe { get; set; }
        public string TotalEp { get; set; }
        public override string PictureDir
        {
            get
            {
                var dir = @"..\Pictures\Series\" + ID.ToString("D6") + ".jpg";
                return dir;
            }
        }



        public SeriesModel()
        {

        }

        public SeriesModel(string title, string seriesURL, string pictureURL, string score, string totalSe, string totalEp, string watchedSe, string watchedEp, bool favourite, string notes, string listGroup, string pictureDir)
        {
            Title = title;
            Url = seriesURL;
            PictureUrl = pictureURL;

            decimal scoreValue = 0;
            decimal.TryParse(score, out scoreValue);
            Score = scoreValue;

            int totalSeValue = 0;
            int.TryParse(totalSe, out totalSeValue);
            TotalSe = totalSeValue;

            TotalEp = totalEp;

            int watchedSeValue = 0;
            int.TryParse(watchedSe, out watchedSeValue);
            WatchedSe = watchedSeValue;

            int watchedEpValue = 0;
            int.TryParse(watchedSe, out watchedEpValue);
            WatchedEp = watchedEpValue;

            Favourite = favourite;
            Notes = notes;
            ListGroup = listGroup;
            PictureDir = pictureDir;
        }
    }

}
