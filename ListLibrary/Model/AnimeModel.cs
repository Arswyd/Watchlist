using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

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
            Year = DateTime.Now.Year;
            Favourite = false;
            Dubbed = false;
            ListGroup = "Not Aired Yet";
        }

        //public AnimeModel(string title, string animeURL, string pictureURL, decimal score, int totalEP, int watchedEP, bool dubbed, bool favourite, string notes, string listGroup)
        //{
        //    Title = title;
        //    Url = animeURL;
        //    PictureUrl = pictureURL;
        //    Score = score;
        //    TotalEp = totalEP;
        //    WatchedEp = watchedEP;
        //    Dubbed = dubbed;
        //    Favourite = favourite;
        //    Notes = notes;
        //    ListGroup = listGroup;
          
        //}
    }
}
