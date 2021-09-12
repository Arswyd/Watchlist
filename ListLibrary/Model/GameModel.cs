using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ListLibrary.Model
{
    public class GameModel : ListItemModel
    {
        public override string PictureDir
        {
            get
            {
                var dir = @"..\Pictures\Game\" + ID.ToString("D6") + ".jpg";
                return dir;
            }
        }

        public GameModel()
        {

        }

        public GameModel(string title, string gameURL, string pictureURL, string score, bool favourite, string notes, string listGroup, string pictureDir)
        {
            Title = title;
            Url = gameURL;
            PictureUrl = pictureURL;

            decimal scoreValue = 0;
            decimal.TryParse(score, out scoreValue);
            Score = scoreValue;

            Favourite = favourite;
            Notes = notes;
            ListGroup = listGroup;
            PictureDir = pictureDir;
        }
    }
}
