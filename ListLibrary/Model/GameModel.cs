using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListLibrary.Model
{
    public class GameModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string GameUrl { get; set; }
        public string PictureUrl { get; set; }
        public decimal Score { get; set; }
        public bool Favourite { get; set; }
        public string Notes { get; set; }
        public string ListGroup { get; set; }


        public GameModel()
        {

        }

        public GameModel(string name, string gameURL, string pictureURL, string score, bool favourite, string notes, string listGroup)
        {
            Name = name;
            GameUrl = gameURL;
            PictureUrl = pictureURL;

            decimal scoreValue = 0;
            decimal.TryParse(score, out scoreValue);
            Score = scoreValue;

            Favourite = favourite;
            Notes = notes;
            ListGroup = listGroup;
        }
    }

}
