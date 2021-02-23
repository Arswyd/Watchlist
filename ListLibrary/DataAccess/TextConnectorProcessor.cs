using ListLibrary.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListLibrary.DataAccess
{
    public static class TextConnectorProcessor
    {
        public static string FullFilePath(this string fileName)
        {
            return $"{ConfigurationManager.AppSettings["filePath"]}//{fileName}";
        }

        public static List<string> LoadFile(this string file)
        {
            //if (!File.Exists(file))
            //{
            //    return new List<string>();
            //}

            return File.ReadAllLines(file).ToList();
        }

        public static List<AnimeModel> ConvertToAnimeModels(this List<string> lines)
        {
            List<AnimeModel> output = new List<AnimeModel>();

            foreach (string line in lines)
            {
                string[] cols = line.Split(';');

                AnimeModel p = new AnimeModel();
                p.ID = int.Parse(cols[0]);
                p.Name = cols[1];
                p.Score = decimal.Parse(cols[2]);
                p.AnimeUrl = cols[3];
                p.PictureUrl=cols[4];
                p.TotalEp = int.Parse(cols[5]);
                p.WatchedEp = int.Parse(cols[6]);
                p.Dubbed = bool.Parse(cols[7]);
                p.Favourite = bool.Parse(cols[8]);
                p.Notes = cols[9];
                p.ListGroup = cols[10];

                output.Add(p);
            }

            return output;
        }

        public static List<SeriesModel> ConvertToSeriesModels(this List<string> lines)
        {
            List<SeriesModel> output = new List<SeriesModel>();

            foreach (string line in lines)
            {
                string[] cols = line.Split(';');

                SeriesModel p = new SeriesModel();
                p.ID = int.Parse(cols[0]);
                p.Name = cols[1];
                p.Score = decimal.Parse(cols[2]);
                p.SeriesUrl = cols[3];
                p.PictureUrl = cols[4];
                p.Season = int.Parse(cols[5]);
                p.TotalEp = int.Parse(cols[6]);
                p.WatchedEp = int.Parse(cols[7]);
                p.Favourite = bool.Parse(cols[8]);
                p.Notes = cols[9];
                p.ListGroup = cols[10];

                output.Add(p);
            }

            return output;
        }

        public static List<GameModel> ConvertToGameModels(this List<string> lines)
        {
            List<GameModel> output = new List<GameModel>();

            foreach (string line in lines)
            {
                string[] cols = line.Split(';');

                GameModel p = new GameModel();
                p.ID = int.Parse(cols[0]);
                p.Name = cols[1];
                p.Score = decimal.Parse(cols[2]);
                p.GameUrl = cols[3];
                p.PictureUrl = cols[4];
                p.Favourite = bool.Parse(cols[5]);
                p.Notes = cols[6];
                p.ListGroup = cols[7];

                output.Add(p);
            }

            return output;
        }

        public static void SaveToAnimeFile(this List<AnimeModel> models, string fileName)
        {
            List<string> lines = new List<string>();

            foreach (AnimeModel p in models)
            {
                lines.Add($"{p.ID};{p.Name};{p.Score};{p.AnimeUrl};{p.PictureUrl};{p.TotalEp};{p.WatchedEp};{p.Dubbed};{p.Favourite};{p.Notes};{p.ListGroup}");
            }

            File.WriteAllLines(fileName.FullFilePath(), lines);
        }

        public static void SaveToSeriesFile(this List<SeriesModel> models, string fileName)
        {
            List<string> lines = new List<string>();

            foreach (SeriesModel p in models)
            {
                lines.Add($"{p.ID};{p.Name};{p.Score};{p.SeriesUrl};{p.PictureUrl};{p.Season};{p.TotalEp};{p.WatchedEp};{p.Favourite};{p.Notes};{p.ListGroup}");
            }

            File.WriteAllLines(fileName.FullFilePath(), lines);
        }

        public static void SaveToGameFile(this List<GameModel> models, string fileName)
        {
            List<string> lines = new List<string>();

            foreach (GameModel p in models)
            {
                lines.Add($"{p.ID};{p.Name};{p.Score};{p.GameUrl};{p.PictureUrl};{p.Favourite};{p.Notes};{p.ListGroup}");
            }

            File.WriteAllLines(fileName.FullFilePath(), lines);
        }
    }

}
