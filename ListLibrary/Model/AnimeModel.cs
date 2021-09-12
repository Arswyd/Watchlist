using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ListLibrary.Model
{
    public class AnimeModel : ListItemModel
    {
        public string Season { get; set; }
        public int TotalEp { get; set; }
        public int WatchedEp { get; set; }
        public bool Dubbed { get; set; }

        public override string PictureDir 
        { 
            get
            {
                var dir = @"..\Pictures\Anime\" + ID.ToString("D6") + ".jpg";
                return dir;
            } 
        }

        public AnimeModel()
        {

        }

        public AnimeModel(string title, string animeURL, string pictureURL, string score, string totalEP, string watchedEP, bool dubbed, bool favourite, string notes, string listGroup, string pictureDir)
        {
            Title = title;
            Url = animeURL;
            PictureUrl = pictureURL;

            decimal scoreValue = 0;
            decimal.TryParse(score, out scoreValue);
            Score = scoreValue;

            int totalEPValue = 0;
            int.TryParse(totalEP, out totalEPValue);
            TotalEp = totalEPValue;

            int watchedEPValue = 0;
            int.TryParse(watchedEP, out watchedEPValue);
            WatchedEp = watchedEPValue;

            Dubbed = dubbed;
            Favourite = favourite;
            Notes = notes;
            ListGroup = listGroup;
            PictureDir = pictureDir;

            //if (pictureURL.Split('/').Last() != pictureDir.Split('\\').Last() && !String.IsNullOrWhiteSpace(pictureDir) && String.IsNullOrWhiteSpace(pictureURL))
            //{
            //    File.Delete(pictureDir);
            //    pictureDir = "";
            //}
            //else if(pictureURL.Split('/').Last() != pictureDir.Split('\\').Last() && !String.IsNullOrWhiteSpace(pictureDir) && !String.IsNullOrWhiteSpace(pictureURL))
            //{
            //    File.Delete(pictureDir);

            //    var pictureName = pictureURL.Split('/').Last();

            //    PictureDir = @"..\..\..\ListLibrary\Pictures\Anime\" + pictureName;

            //    using (WebClient client = new WebClient())
            //    {
            //        client.DownloadFile(pictureURL, PictureDir);
            //    }

            //}
            //else if (String.IsNullOrWhiteSpace(pictureDir) && !String.IsNullOrWhiteSpace(pictureURL))
            //{

            //    var pictureName = pictureURL.Split('/').Last();

            //    PictureDir = @"..\..\..\ListLibrary\Pictures\Anime\" + pictureName;

            //    using (WebClient client = new WebClient())
            //    {
            //        client.DownloadFile(pictureURL, PictureDir);
            //    }

            //}
            //else
            //{
            //    PictureDir = pictureDir;
            //}
            
        }
    }
}
