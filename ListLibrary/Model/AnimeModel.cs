using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListLibrary.Model
{
    public class AnimeModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string AnimeUrl { get; set; }
        public string PictureUrl { get; set; }
        public decimal Score { get; set; }
        public int TotalEp { get; set; }
        public int WatchedEp { get; set; }
        public bool Dubbed { get; set; }
        public bool Favourite { get; set; }
        public string Notes { get; set; }
        public string ListGroup { get; set; }


        public AnimeModel()
        {

        }

        public AnimeModel(string name, string animeURL, string pictureURL, string score, string totalEP, string watchedEP, bool dubbed, bool favourite, string notes, string listGroup)
        {
            Name = name;
            AnimeUrl = animeURL;
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
        }
    }

}
