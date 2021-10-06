using System;

namespace ListLibrary.Model
{
    public class GameModel : ItemModel
    {
        public bool Owned { get; set; }
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
            Score = 0;
            Year = DateTime.Now.Year;
            Favourite = false;
            ListGroup = "Not Released Yet";
            Owned = false;
        }
    }
}
