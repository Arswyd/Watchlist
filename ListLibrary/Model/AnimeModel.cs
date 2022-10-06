﻿using System;
using System.IO;
using System.Net;

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
                var dir = String.Empty;
                if (PicFormat == 0)
                {
                    dir = @"..\..\..\ListLibrary\Pictures\Anime\" + ID.ToString("D6") + ".jpg";
                }
                else
                {
                    dir = @"..\..\..\ListLibrary\Pictures\Anime\" + ID.ToString("D6") + ".png";
                }                
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
            TotalEp = 12;
        }
    }
}
