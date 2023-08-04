using Dapper;
using Dropbox.Api.Users;
using ListLibrary.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using static Dropbox.Api.Files.ListRevisionsMode;

namespace ListLibrary.Database
{
    public static class SqliteDataAccess
    {
        // AppData

        public static int GetAppClientType()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.QueryFirstOrDefault<int>("SELECT IsPrimaryClient FROM AppData WHERE ID=1");
                return output;
            }
        }

        public static void ChangeClientType(bool isPrimaryClient)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                int i = isPrimaryClient ? 1 : 0;
                cnn.Execute("UPDATE AppData SET IsPrimaryClient = " + i + " WHERE ID=1");
            }
        }

        // Headers

        public static List<HeaderModel> LoadAnimeListHeaders()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<HeaderModel>("SELECT LH.ID, LH.ListType, LH.ListGroup, LH.SortOrder, (SELECT COUNT(1) FROM Anime AS A WHERE A.ListGroup = LH.ListGroup) AS Count FROM ListHeaders AS LH WHERE LH.ListType = 0 AND LH.ID <> 0 ORDER BY LH.SortOrder");
                return output.ToList();
            }
        }

        public static List<HeaderModel> LoadGameListHeaders()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<HeaderModel>("SELECT LH.ID, LH.ListType, LH.ListGroup, LH.SortOrder, (SELECT COUNT(1) FROM Games AS G WHERE G.ListGroup = LH.ListGroup) AS Count FROM ListHeaders AS LH WHERE LH.ListType = 2 AND LH.ID <> 0 ORDER BY LH.SortOrder");
                return output.ToList();
            }
        }

        public static List<HeaderModel> LoadSeriesListHeaders()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<HeaderModel>("SELECT LH.ID, LH.ListType, LH.ListGroup, LH.SortOrder, (SELECT COUNT(1) FROM Series AS S WHERE S.ListGroup = LH.ListGroup) AS Count FROM ListHeaders AS LH WHERE LH.ListType = 1 AND LH.ID <> 0 ORDER BY LH.SortOrder");
                return output.ToList();
            }
        }

        public static void SaveHeader(HeaderModel header)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("INSERT INTO ListHeaders (ListType, ListGroup, SortOrder) VALUES (@ListType, @ListGroup, @SortOrder)", header);
            }
        }

        public static void UpdateHeader(HeaderModel header)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("UPDATE ListHeaders SET ListGroup=@ListGroup, SortOrder=@SortOrder WHERE ListType=@ListType AND ID=@ID", header);
            }
        }

        public static void DeleteHeader(HeaderModel header)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("DELETE FROM ListHeaders WHERE ListType=@ListType AND ID=@ID", header);
            }
        }

        public static void UpdateAnimeListGroup(string newheader, string oldheader)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var i = cnn.Execute("UPDATE Anime SET ListGroup='" + newheader + "' WHERE ListGroup='" + oldheader + "'");
            }
        }

        public static void UpdateSeriesListGroup(string newheader, string oldheader)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var i = cnn.Execute("UPDATE Series SET ListGroup='" + newheader + "' WHERE ListGroup='" + oldheader + "'");
            }
        }

        public static void UpdateGameListGroup(string newheader, string oldheader)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var i = cnn.Execute("UPDATE Games SET ListGroup='" + newheader + "' WHERE ListGroup='" + oldheader + "'");
            }
        }

        // Global

        public static int LoadGroupCount(string sqlString)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<int>(sqlString).First();
                return output;
            }
        }

        public static List<int> LoadIDGroup(string sqlString)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<int>(sqlString);
                return output.ToList();
            }
        }
       
        // Anime SQL

        #region Anime SQL

        public static List<AnimeModel> LoadAnimeGroup(string sqlString)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<AnimeModel>(sqlString);
                return output.ToList();
            }
        }

        public static List<AnimeModel> LoadAnimeForSync()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<AnimeModel>("SELECT A.ID, A.Title, A.Url, A.PictureUrl, A.PicFormat, A.Score, A.Year, A.Favourite, A.Notes, A.ListGroup, A.Season, A.TotalEp, A.WatchedEp, A.Dubbed, A.ModDate " +
                                                   "FROM Anime A INNER JOIN AppData D ON D.ID = 1 WHERE A.ModDate > D.AnimeSyncDate ");
                return output.ToList();
            }
        }

        public static AnimeModel LoadAnimeByID(int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.QueryFirstOrDefault<AnimeModel>("SELECT A.ID, A.Title, A.Url, A.PictureUrl, A.PicFormat, A.Score, A.Year, A.Favourite, A.Notes, A.ListGroup, A.Season, A.TotalEp, A.WatchedEp, A.Dubbed, A.ModDate " + 
                                                                 "FROM Anime A WHERE A.ID=" + id);
                return output;
            }
        }

        public static void SaveAnime(AnimeModel anime)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("INSERT INTO Anime (Title, Url, PictureUrl, PicFormat, Score, Year, Favourite, Notes, ListGroup, Season, TotalEp, WatchedEp, Dubbed, ModDate) " +
                            "VALUES (@Title, @Url, @PictureUrl, @PicFormat, @Score, @Year, @Favourite, @Notes, @ListGroup, @Season, @TotalEp, @WatchedEp, @Dubbed, @ModDate)", anime);
            }
        }

        public static void UpdateAnime(AnimeModel anime)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.QueryFirstOrDefault("SELECT 1 FROM Anime SET WHERE ID=@ID AND PictureUrl<>@PictureUrl", anime);
                if (output != null)
                {
                    try
                    {
                        if (anime.PictureUrl == "" && File.Exists(anime.PictureDir))
                        {
                            File.Delete(anime.PictureDir);
                        }
                        else if (anime.PictureUrl != "")
                        {
                            anime.PicFormat = 0;
                            using (WebClient client = new WebClient())
                            {
                                client.DownloadFile(anime.PictureUrl, anime.PictureDir);
                            }
                        }
                    }
                    catch { }
                }

                cnn.Execute("UPDATE Anime SET Title=@Title, Url=@Url, PictureUrl=@PictureUrl, PicFormat=@PicFormat, Score=@Score, Year=@Year, Favourite=@Favourite, " +
                            "Notes=@Notes, ListGroup=@ListGroup, Season=@Season, TotalEp=@TotalEp, WatchedEp=@WatchedEp, Dubbed=@Dubbed, ModDate=" + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss") + " WHERE ID=@ID", anime);
            }
        }

        public static void DeleteAnime(AnimeModel anime)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("UPDATE Anime SET ListGroup='Deleted', ModDate=" + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss") + " WHERE ID=@ID", anime);
                if (File.Exists(anime.PictureDir))
                {
                    File.Delete(anime.PictureDir);
                }
            }
        }

        public static void DeleteAllAnime()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("DELETE FROM Anime");
                cnn.Execute("VACUUM");
                cnn.Execute("DELETE FROM sqlite_sequence WHERE name='Anime'");
            }
        }

        public static int GetLastAnimeID()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<int>("SELECT seq FROM sqlite_sequence WHERE name = 'Anime' LIMIT 1").First();
                return output;
            }
        }

        public static bool CheckIfAnimeExists()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.QueryFirstOrDefault<int>("SELECT 1 FROM Anime");
                return output == 1 ? true : false;
            }
        }

        public static bool CheckIfAnimeExists(AnimeModel anime)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.QueryFirstOrDefault<int>("SELECT 1 FROM Anime WHERE ID=@ID", anime);
                return output == 1 ? true : false;
            }
        }

        public static void SyncAnime(AnimeModel anime)
        {
            if (CheckIfAnimeExists(anime))
            {
                if (anime.ListGroup == "Deleted")
                {
                    DeleteAnime(anime);
                }
                else
                {
                    UpdateAnime(anime);
                }
            }
            else
            {
                SaveAnime(anime);
            }
        }

        #endregion

        // Game SQL

        #region Game SQL

        public static List<GameModel> LoadGameGroup(string sqlString)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<GameModel>(sqlString);
                return output.ToList();
            }
        }

        public static List<GameModel> LoadGameForSync()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<GameModel>("SELECT G.ID, G.Title, G.Url, G.PictureUrl, G.PicFormat, G.Score, G.Year, G.Favourite, G.Notes, G.ListGroup, G.Platform, G.Owned, G.Lenght, G.ModDate " +
                                                   "FROM Games G INNER JOIN AppData D ON D.ID = 1 WHERE G.ModDate > D.AnimeSyncDate ");
                return output.ToList();
            }
        }

        public static GameModel LoadGameByID(int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.QueryFirstOrDefault<GameModel>("SELECT G.ID, G.Title, G.Url, G.PictureUrl, G.PicFormat, G.Score, G.Year, G.Favourite, G.Notes, G.ListGroup, G.Platform, G.Owned, G.Lenght, G.ModDate " + 
                                                                "FROM Games G WHERE G.ID=" + id);
                return output;
            }
        }

        public static void SaveGame(GameModel game)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("INSERT INTO Games (Title, Url, PictureUrl, PicFormat, Score, Year, Platform, Favourite, Notes, ListGroup, Owned, Lenght, ModDate) " +
                            "VALUES (@Title, @Url, @PictureUrl, @PicFormat, @Score, @Year, @Platform, @Favourite, @Notes, @ListGroup, @Owned, @Lenght, @ModDate", game);
            }
        }

        public static void UpdateGame(GameModel game)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.QueryFirstOrDefault("SELECT 1 FROM Games SET WHERE ID=@ID AND PictureUrl<>@PictureUrl", game);
                if (output != null)
                {
                    try
                    {
                        if (game.PictureUrl == "" && File.Exists(game.PictureDir))
                        {
                            File.Delete(game.PictureDir);
                        }
                        else if (game.PictureUrl != "")
                        {
                            game.PicFormat = 0;
                            using (WebClient client = new WebClient())
                            {
                                client.DownloadFile(game.PictureUrl, game.PictureDir);
                            }
                        }
                    }
                    catch { }
                }

                cnn.Execute("UPDATE Games SET Title=@Title, Url=@Url, PictureUrl=@PictureUrl, PicFormat=@PicFormat, Score=@Score, Year=@Year, Platform=@Platform, Favourite=@Favourite, " +
                            "Notes=@Notes, ListGroup=@ListGroup, Owned=@Owned, Lenght=@Lenght, ModDate=" + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss") + " WHERE ID=@ID", game);
            }
        }

        public static void DeleteGame(GameModel game)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("UPDATE Games SET ListGroup='Deleted', ModDate=" + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss") + " WHERE ID=@ID", game);
                if (File.Exists(game.PictureDir))
                {
                    File.Delete(game.PictureDir);
                }
            }
        }

        public static void DeleteAllGame()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("DELETE FROM Games");
                cnn.Execute("VACUUM");
                cnn.Execute("DELETE FROM sqlite_sequence WHERE name='Games'");
            }
        }

        public static int GetLastGameID()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<int>("SELECT seq FROM sqlite_sequence WHERE name = 'Games' LIMIT 1").First();
                return output;
            }
        }

        public static bool CheckIfGameExists()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.QueryFirstOrDefault<int>("SELECT 1 FROM Games");
                return output == 1 ? true : false;
            }
        }

        public static bool CheckIfGameExists(GameModel game)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.QueryFirstOrDefault<int>("SELECT 1 FROM Games WHERE ID=@ID", game);
                return output == 1 ? true : false;
            }
        }

        public static void SyncGame(GameModel game)
        {
            if (CheckIfGameExists(game))
            {
                if (game.ListGroup == "Deleted")
                {
                    DeleteGame(game);
                }
                else
                {
                    UpdateGame(game);
                }
            }
            else
            {
                SaveGame(game);
            }
        }

        #endregion

        // Series SQL

        #region Series SQL

        public static List<SeriesModel> LoadSeriesGroup(string sqlString)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<SeriesModel>(sqlString);
                return output.ToList();
            }
        }

        public static List<SeriesModel> LoadSeriesForSync()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<SeriesModel>("SELECT S.ID, S.Title, S.Url, S.PictureUrl, S.PicFormat, S.Score, S.Year, S.Favourite, S.Notes, S.ListGroup, S.Platform, S.TotalSe, S.CurrentSe, S.TotalEp, S.WatchedEp, S.FinishedRunning, S.ModDate " +
                                                    "FROM Series S INNER JOIN AppData D ON D.ID = 1 WHERE S.ModDate > D.AnimeSyncDate ");
                return output.ToList();
            }
        }

        public static SeriesModel LoadSeriesByID(int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.QueryFirstOrDefault<SeriesModel>("SELECT S.ID, S.Title, S.Url, S.PictureUrl, S.PicFormat, S.Score, S.Year, S.Favourite, S.Notes, S.ListGroup, S.Platform, S.TotalSe, S.CurrentSe, S.TotalEp, S.WatchedEp, S.FinishedRunning, S.ModDate " +
                                                                  "FROM Series S WHERE S.ID=" + id);
                return output;
            }
        }

        public static void SaveSeries(SeriesModel series)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("INSERT INTO Series (Title, Url, PictureUrl, PicFormat, Score, Year, Platform, Favourite, Notes, ListGroup, CurrentSe, TotalEp, WatchedEp, FinishedRunning, ModDate) " +
                            "VALUES (@Title, @Url, @PictureUrl, @PicFormat, @Score, @Year, @Platform, @Favourite, @Notes, @ListGroup, @CurrentSe, @TotalEp, @WatchedEp, @FinishedRunning, @ModDate", series);
            }
        }

        public static void UpdateSeries(SeriesModel series)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.QueryFirstOrDefault("SELECT 1 FROM Series SET WHERE ID=@ID AND PictureUrl<>@PictureUrl", series);
                if (output != null)
                {
                    try
                    {
                        if (series.PictureUrl == "" && File.Exists(series.PictureDir))
                        {
                            File.Delete(series.PictureDir);
                        }
                        else if (series.PictureUrl != "")
                        {
                            series.PicFormat = 0;
                            using (WebClient client = new WebClient())
                            {
                                client.DownloadFile(series.PictureUrl, series.PictureDir);
                            }
                        }
                    }
                    catch { }
                }

                cnn.Execute("UPDATE Series SET Title=@Title, Url=@Url, PictureUrl=@PictureUrl, PicFormat=@PicFormat, Score=@Score, Year=@Year, Platform=@Platform, Favourite=@Favourite, Notes=@Notes, " +
                            "ListGroup=@ListGroup, CurrentSe=@CurrentSe, TotalEp=@TotalEp, WatchedEp=@WatchedEp, FinishedRunning=@FinishedRunning, ModDate=" + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss") + " WHERE ID=@ID", series);
            }
        }

        public static void DeleteSeries(SeriesModel series)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("UPDATE Series SET ListGroup='Deleted', ModDate=" + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss") + " WHERE ID=@ID", series);

                if (File.Exists(series.PictureDir))
                {
                    File.Delete(series.PictureDir);
                }
            }
        }

        public static void DeleteAllSeries()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("DELETE FROM Series");
                cnn.Execute("VACUUM");
                cnn.Execute("DELETE FROM sqlite_sequence WHERE name='Series'");
            }
        }

        public static int GetLastSeriesID()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<int>("SELECT seq FROM sqlite_sequence WHERE name = 'Series' LIMIT 1").First();
                return output;
            }
        }

        public static bool CheckIfSeriesExists()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.QueryFirstOrDefault<int>("SELECT 1 FROM Series");
                return output == 1 ? true : false;
            }
        }

        public static bool CheckIfSeriesExists(SeriesModel series)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.QueryFirstOrDefault<int>("SELECT 1 FROM Series WHERE ID=@ID", series);
                return output == 1 ? true : false;
            }
        }

        public static void SyncSeries(SeriesModel series)
        {
            if (CheckIfSeriesExists(series))
            {
                if (series.ListGroup == "Deleted")
                {
                    DeleteSeries(series);
                }
                else
                {
                    UpdateSeries(series);
                }
            }
            else
            {
                SaveSeries(series);
            }
        }

        #endregion

        // Connection String

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
