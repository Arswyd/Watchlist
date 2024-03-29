﻿using Dropbox.Api.Users;
using ListLibrary.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ListLibrary.Database
{
    public static class DataImportExportProcessor
    {
        public static List<string> LoadFile(string file)
        {
            return File.ReadAllLines(file).ToList();
        }

        public static List<ItemModel> ConvertToAnimeModel(this List<string> lines)
        {
            List<ItemModel> output = new List<ItemModel>();

            foreach (string line in lines)
            {
                string[] cols = line.Split(';');

                AnimeModel p = new AnimeModel();
                p.ID = int.Parse(cols[0]);
                p.Title = cols[1];
                p.Url = cols[2];
                p.PictureUrl = cols[3];
                p.PicFormat = int.Parse(cols[4]);
                p.Score = decimal.Parse(cols[5]);
                p.Year = int.Parse(cols[6]);
                p.Favourite = bool.Parse(cols[7]);
                p.Notes = cols[8];
                p.ListGroup = cols[9];
                p.Season = cols[10];
                p.TotalEp = int.Parse(cols[11]);
                p.WatchedEp = int.Parse(cols[12]);
                p.Dubbed = bool.Parse(cols[13]);
                p.ModDate = cols[14];

                output.Add(p);
            }

            return output;
        }

        public static List<ItemModel> ConvertToSeriesModel(this List<string> lines)
        {
            List<ItemModel> output = new List<ItemModel>();

            foreach (string line in lines)
            {
                string[] cols = line.Split(';');

                SeriesModel p = new SeriesModel();
                p.ID = int.Parse(cols[0]);
                p.Title = cols[1];
                p.Url = cols[2];
                p.PictureUrl = cols[3];
                p.PicFormat = int.Parse(cols[4]);
                p.Score = decimal.Parse(cols[5]);
                p.Year = int.Parse(cols[6]);
                p.Favourite = bool.Parse(cols[7]);
                p.Notes = cols[8];
                p.ListGroup = cols[9];
                p.Platform = cols[10];
                p.CurrentSe = int.Parse(cols[11]);
                p.TotalEp = int.Parse(cols[12]);
                p.WatchedEp = int.Parse(cols[13]);
                p.FinishedRunning = bool.Parse(cols[14]);
                p.ModDate = cols[15];

                output.Add(p);
            }

            return output;
        }

        public static List<ItemModel> ConvertToGameModel(this List<string> lines)
        {
            List<ItemModel> output = new List<ItemModel>();

            foreach (string line in lines)
            {
                string[] cols = line.Split(';');

                GameModel p = new GameModel();
                p.ID = int.Parse(cols[0]);
                p.Title = cols[1];
                p.Url = cols[2];
                p.PictureUrl = cols[3];
                p.PicFormat = int.Parse(cols[4]);
                p.Score = decimal.Parse(cols[5]);
                p.Year = int.Parse(cols[6]);
                p.Favourite = bool.Parse(cols[7]);
                p.Notes = cols[8];
                p.ListGroup = cols[9];
                p.Platform = cols[10];
                p.Owned = bool.Parse(cols[11]);
                p.ModDate = cols[12];

                output.Add(p);
            }

            return output;
        }

        public static void ExportAnime(bool isSyncing)
        {
            List<AnimeModel> anime;

            if (isSyncing)
            {
                anime = SqliteDataAccess.LoadAnimeForSync();
            }
            else
            {
                anime = SqliteDataAccess.LoadAnimeGroup("SELECT A.ID, A.Title, A.Url, A.PictureUrl, A.PicFormat, A.Score, A.Year, A.Favourite, A.Notes, " +
                    "A.ListGroup, A.Season, A.TotalEp, A.WatchedEp, A.Dubbed, A.ModDate FROM Anime AS A");
            }

            List<string> lines = new List<string>();

            foreach (AnimeModel p in anime)
            {
                lines.Add($"{p.ID};{p.Title};{p.Url};{p.PictureUrl};{p.PicFormat};{p.Score};{p.Year};{p.Favourite};{p.Notes};{p.ListGroup};{p.Season};{p.TotalEp};{p.WatchedEp};{p.Dubbed};{p.ModDate}");
            }

            if (isSyncing)
            {
                string localFilePath = @"..\..\..\ListLibrary\ListBackup\SyncFiles\" + DateTime.Now.ToString("yyyy_MM_dd") + "_Anime_Sync.csv";
                //string dropboxFilePath = @"/WatchListSyncFiles/" + DateTime.Now.ToString("yyyy_MM_dd") + "_Anime_Sync.csv";

                File.WriteAllLines(localFilePath, lines);
                //DropboxSyncProcessor.UploadSyncFiles(localFilePath, dropboxFilePath);
            }
            else
            {
                string localFilePath = @"..\..\..\ListLibrary\ListBackup\" + DateTime.Now.ToString("yyyy_MM_dd") + "_Anime_Backup.csv";

                File.WriteAllLines(localFilePath, lines);
            }
        }

        public static void ExportSeries(bool isSyncing)
        {
            List<SeriesModel> series;

            if (isSyncing)
            {
                series = SqliteDataAccess.LoadSeriesForSync();
            }
            else
            {
                series = SqliteDataAccess.LoadSeriesGroup("SELECT S.ID, S.Title, S.Url, S.PictureUrl, S.PicFormat, S.Score, S.Year, S.Favourite, S.Notes, " +
                  "S.ListGroup, S.Platform, S.CurrentSe, S.TotalEp, S.WatchedEp, S.FinishedRunning, S.ModDate FROM Series AS S");
            }

            List<string> lines = new List<string>();

            foreach (SeriesModel p in series)
            {
                lines.Add($"{p.ID};{p.Title};{p.Url};{p.PictureUrl};{p.PicFormat};{p.Score};{p.Year};{p.Favourite};{p.Notes};{p.ListGroup};{p.Platform};{p.CurrentSe};{p.TotalEp};{p.WatchedEp};{p.FinishedRunning};{p.ModDate}");
            }

            if (isSyncing)
            {
                string localFilePath = @"..\..\..\ListLibrary\ListBackup\SyncFiles\" + DateTime.Now.ToString("yyyy_MM_dd") + "_Series_Sync.csv";
                //string dropboxFilePath = @"/WatchListSyncFiles/" + DateTime.Now.ToString("yyyy_MM_dd") + "_Series_Sync.csv";

                File.WriteAllLines(localFilePath, lines);
                //DropboxSyncProcessor.UploadSyncFiles(localFilePath, dropboxFilePath);
            }
            else
            {
                string localFilePath = @"..\..\..\ListLibrary\ListBackup\" + DateTime.Now.ToString("yyyy_MM_dd") + "_Series_Backup.csv";

                File.WriteAllLines(localFilePath, lines);
            }
        }

        public static void ExportGame(bool isSyncing)
        {
            List<GameModel> game;

            if (isSyncing)
            {
                game = SqliteDataAccess.LoadGameForSync();
            }
            else
            {
                game = SqliteDataAccess.LoadGameGroup("SELECT G.ID, G.Title, G.Url, G.PictureUrl, G.PicFormat, G.Score, G.Year, G.Favourite, G.Notes, " +
                  "G.ListGroup, G.Platform, G.Owned, G.ModDate FROM Games AS G");
            }

            List<string> lines = new List<string>();

            foreach (GameModel p in game)
            {
                lines.Add($"{p.ID};{p.Title};{p.Url};{p.PictureUrl};{p.PicFormat};{p.Score};{p.Year};{p.Favourite};{p.Notes};{p.ListGroup};{p.Platform};{p.Owned};{p.ModDate}");
            }

            if (isSyncing)
            {
                string localFilePath = @"..\..\..\ListLibrary\ListBackup\SyncFiles\" + DateTime.Now.ToString("yyyy_MM_dd") + "_Game_Sync.csv";
                //string dropboxFilePath = @"/WatchListSyncFiles/" + DateTime.Now.ToString("yyyy_MM_dd") + "_Game_Sync.csv";

                File.WriteAllLines(localFilePath, lines);
                //DropboxSyncProcessor.UploadSyncFiles(localFilePath, dropboxFilePath);
            }
            else
            {
                string localFilePath = @"..\..\..\ListLibrary\ListBackup\" + DateTime.Now.ToString("yyyy_MM_dd") + "_Game_Backup.csv";

                File.WriteAllLines(localFilePath, lines);
            }
        }
    }
}

