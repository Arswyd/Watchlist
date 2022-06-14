using Dapper;
using ListLibrary.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace ListLibrary.Database
{
    public class SqliteDataAccess
    {
        // Headers

        public static List<HeaderModel> LoadAnimeListHeaders()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<HeaderModel>("SELECT LH.ID, LH.ListType, LH.ListGroup, LH.SortOrder, (SELECT COUNT(1) FROM Anime AS A WHERE A.ListGroup = LH.ListGroup) AS Count FROM ListHeaders AS LH WHERE LH.ListType = 'Anime' ORDER BY LH.SortOrder");
                return output.ToList();
            }
        }

        public static List<HeaderModel> LoadGameListHeaders()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<HeaderModel>("SELECT LH.ID, LH.ListType, LH.ListGroup, LH.SortOrder, (SELECT COUNT(1) FROM Games AS G WHERE G.ListGroup = LH.ListGroup) AS Count FROM ListHeaders AS LH WHERE LH.ListType = 'Game' ORDER BY LH.SortOrder");
                return output.ToList();
            }
        }

        public static List<HeaderModel> LoadSeriesListHeaders()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<HeaderModel>("SELECT LH.ID, LH.ListType, LH.ListGroup, LH.SortOrder, (SELECT COUNT(1) FROM Series AS S WHERE S.ListGroup = LH.ListGroup) AS Count FROM ListHeaders AS LH WHERE LH.ListType = 'Series' ORDER BY LH.SortOrder");
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
                cnn.Execute("UPDATE ListHeaders SET ListGroup=@ListGroup, SortOrder=@SortOrder WHERE ID=@ID", header);
            }
        }

        public static void DeleteHeader(HeaderModel header)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("DELETE FROM ListHeaders WHERE ID=@ID", header);
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
                var i = cnn.Execute("UPDATE Game SET ListGroup='" + newheader + "' WHERE ListGroup='" + oldheader + "'");
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

        public static AnimeModel LoadAnimeByID(int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<AnimeModel>("SELECT * FROM Anime WHERE ID=" + id).First();
                return output;
            }
        }

        public static void SaveAnime(AnimeModel anime, int isSingleSave)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("INSERT INTO Anime (Title, Url, PictureUrl, PicFormat, Score, Year, Favourite, Notes, ListGroup, Season, TotalEp, WatchedEp, Dubbed) " +
                    "VALUES (@Title, @Url, @PictureUrl, @PicFormat, @Score, @Year, @Favourite, @Notes, @ListGroup, @Season, @TotalEp, @WatchedEp, @Dubbed)", anime);
            }
        }

        public static void ImportAnime(AnimeModel anime)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("INSERT OR IGNORE INTO Anime (Title, Url, PictureUrl, PicFormat, Score, Year, Favourite, Notes, ListGroup, Season, TotalEp, WatchedEp, Dubbed) " +
                    "VALUES (@Title, @Url, @PictureUrl, @PicFormat, @Score, @Year, @Favourite, @Notes, @ListGroup, @Season, @TotalEp, @WatchedEp, @Dubbed)", anime);
            }
        }

        public static void UpdateAnime(AnimeModel anime)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("UPDATE Anime SET Title=@Title, Url=@Url, PictureUrl=@PictureUrl, PicFormat=@PicFormat, Score=@Score, Year=@Year, Favourite=@Favourite, " +
                    "Notes=@Notes, ListGroup=@ListGroup, Season=@Season, TotalEp=@TotalEp, WatchedEp=@WatchedEp, Dubbed=@Dubbed WHERE ID=@ID", anime);
            }
        }

        public static void DeleteAnime(AnimeModel anime)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("DELETE FROM Anime WHERE ID=@ID", anime);
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

        public static int CheckIfEmptyAnime()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<int>("SELECT COUNT(1) FROM Anime LIMIT 1").First();
                return output;
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

        public static void SaveGame(GameModel game, int isSingleSave)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("INSERT INTO Games (Title, Url, PictureUrl, PicFormat, Score, Year, Favourite, Notes, ListGroup, Owned, Lenght) " +
                    "VALUES (@Title, @Url, @PictureUrl, @PicFormat, @Score, @Year, @Favourite, @Notes, @ListGroup, @Owned, @Lenght)", game);
            }
        }

        public static void ImportGame(GameModel game)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("INSERT OR IGNORE INTO Games (Title, Url, PictureUrl, PicFormat, Score, Year, Favourite, Notes, ListGroup, Owned, Lenght) " +
                    "VALUES (@Title, @Url, @PictureUrl, @PicFormat, @Score, @Year, @Favourite, @Notes, @ListGroup, @Owned, @Lenght)", game);
            }
        }

        public static void UpdateGame(GameModel game)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("UPDATE Games SET Title=@Title, Url=@Url, PictureUrl=@PictureUrl, PicFormat=@PicFormat, Score=@Score, Year=@Year, Favourite=@Favourite, " +
                    "Notes=@Notes, ListGroup=@ListGroup, Owned=@Owned, Lenght=@Lenght WHERE ID=@ID", game);
            }
        }

        public static void DeleteGame(GameModel game)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("DELETE FROM Games WHERE ID=@ID", game);
            }
        }

        public static void DeleteAllGame()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("DELETE FROM Games");
                cnn.Execute("VACUUM");
                cnn.Execute("DELETE FROM sqlite_sequence WHERE name='Game'");
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

        public static int CheckIfEmptyGame()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<int>("SELECT COUNT(1) FROM Game LIMIT 1").First();
                return output;
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

        public static void SaveSeries(SeriesModel series, int isSingleSave)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("INSERT INTO Series (Title, Url, PictureUrl, PicFormat, Score, Year, Favourite, Notes, ListGroup, TotalSe, CurrentSe, TotalEp, WatchedEp, FinishedRunning) " +
                    "VALUES (@Title, @Url, @PictureUrl, @PicFormat, @Score, @Year, @Favourite, @Notes, @ListGroup, @TotalSe, @CurrentSe, @TotalEp, @WatchedEp, @FinishedRunning)", series);
            }
        }

        public static void ImportSeries(SeriesModel series)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("INSERT OR IGNORE INTO Series (Title, Url, PictureUrl, PicFormat, Score, Year, Favourite, Notes, ListGroup, TotalSe, CurrentSe, TotalEp, WatchedEp, FinishedRunning) " +
                    "VALUES (@Title, @Url, @PictureUrl, @PicFormat, @Score, @Year, @Favourite, @Notes, @ListGroup, @TotalSe, @CurrentSe, @TotalEp, @WatchedEp, @FinishedRunning)", series);
            }
        }

        public static void UpdateSeries(SeriesModel series)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("UPDATE Series SET Title=@Title, Url=@Url, PictureUrl=@PictureUrl, PicFormat=@PicFormat, Score=@Score, Year=@Year, Favourite=@Favourite, Notes=@Notes, " + 
                    "ListGroup=@ListGroup, TotalSe=@TotalSe, CurrentSe=@CurrentSe, TotalEp=@TotalEp, WatchedEp=@WatchedEp, FinishedRunning=@FinishedRunning WHERE ID=@ID", series);
            }
        }

        public static void DeleteSeries(SeriesModel series)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("DELETE FROM Series WHERE ID=@ID", series);
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

        public static int CheckIfEmptySeries()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<int>("SELECT COUNT(1) FROM Series LIMIT 1").First();
                return output;
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
