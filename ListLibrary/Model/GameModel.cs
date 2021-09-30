using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ListLibrary.Model
{
    public class GameModel : ItemModel
    {
        public override string PictureDir
        {
            get
            {
                var dir = @"..\..\..\ListLibrary\Pictures\Game\" + ID.ToString("D6") + ".jpg";
                return dir;
            }
        }

        public GameModel()
        {

        }

        public GameModel(string title, string url, string pictureURL, decimal score, bool favourite, string notes, string listGroup)
        {
            Title = title;
            Url = url;
            PictureUrl = pictureURL;
            Score = score;
            Favourite = favourite;
            Notes = notes;
            ListGroup = listGroup;
        }
    }
}
