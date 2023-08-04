using System;

namespace ListLibrary.Model
{
    public class SeriesModel : ItemModel
    {

        public int CurrentSe { get; set; }
        public int WatchedEp { get; set; }
        public int TotalEp { get; set; }
        public bool FinishedRunning { get; set; }
        public string Platform { get; set; }
        public override string PictureDir
        {
            get
            {
                var dir = String.Empty;
                if (PicFormat == 0)
                {
                    dir = @"..\..\..\ListLibrary\Pictures\Series\" + ID.ToString("D6") + ".jpg";
                }
                else
                {
                    dir = @"..\..\..\ListLibrary\Pictures\Series\" + ID.ToString("D6") + ".png";
                }
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
            TotalEp = 0;
            CurrentSe = 1;
            WatchedEp = 0;
            Platform = "";
            ModDate = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss"); ;
        }
    }
}
