using System;

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
                return Convert.ToInt32(TotalEp.Split('/')[CurrentSe-1]);
            }
        }
        public override string PictureDir
        {
            get
            {
                var dir = @"..\..\..\ListLibrary\Pictures\Series\" + ID.ToString("D6") + ".jpg";
                return dir;
            }
        }

        public SeriesModel()
        {
            Score = 0;
            Year = DateTime.Now.Year;
            Favourite = false;
            FinishedRunning = false;
            ListGroup = "Not Aired Yet";
        }
    }
}
