using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ListLibrary.Model
{
    public class SeriesModel : ItemModel
    {

        public int CurrentSe { get; set; }
        public int WatchedEp { get; set; }
        public int TotalSe { get; set; }
        public string TotalEp { get; set; }
        public bool FinishedRunning { get; set; }

        public int CurrentSeasonTotalEp
        {
            get
            {
                return Convert.ToInt32(TotalEp.Split(';')[CurrentSe]);
            }
        }
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

        public SeriesModel(string title, string seriesURL, string pictureURL, decimal score, int totalSe, string totalEp, int watchedSe, int watchedEp, bool favourite, string notes, string listGroup)
        {
            Title = title;
            Url = seriesURL;
            PictureUrl = pictureURL;
            Score = score;
            TotalSe = totalSe;
            TotalEp = totalEp;
            CurrentSe = watchedSe;
            WatchedEp = watchedEp;
            Favourite = favourite;
            Notes = notes;
            ListGroup = listGroup;
        }
    }

}
