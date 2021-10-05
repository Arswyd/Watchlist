using System;

namespace ListLibrary.Model
{
    public class AnimeModel : ItemModel
    {
        public string Season { get; set; }
        public int TotalEp { get; set; }
        public int WatchedEp { get; set; }
        public bool Dubbed { get; set; }

        public override string PictureDir 
        { 
            get
            {
                var dir = @"..\..\..\ListLibrary\Pictures\Anime\" + ID.ToString("D6") + ".jpg";
                return dir;
            } 
        }

        public AnimeModel()
        {
            Score = 0;
            Year = DateTime.Now.Year;
            Favourite = false;
            Dubbed = false;
            ListGroup = "Not Aired Yet";
            Season = "Spring";
        }
    }
}
