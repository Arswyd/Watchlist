using System;

namespace ListLibrary.Model
{
    public class GameModel : ItemModel
    {
        public bool Owned { get; set; }

        public decimal Lenght { get; set; }

        public string Platform { get; set; }

        public override string PictureDir
        {
            get
            {
                var dir = String.Empty;
                if (PicFormat == 0)
                {
                    dir = @"..\..\..\ListLibrary\Pictures\Game\" + ID.ToString("D6") + ".jpg";
                }
                else
                {
                    dir = @"..\..\..\ListLibrary\Pictures\Game\" + ID.ToString("D6") + ".png";
                }
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
            Lenght = 0;
            Platform = "";
        }
    }
}
