using Dapper;
using ListLibrary.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListLibrary.Database
{
    public class SqliteDataAccess
    {
        // Login

        public static List<LogModel> LoadLogs()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<LogModel>("SELECT * FROM Log ORDER BY DATE DESC LIMIT 50");
                return output.ToList();
            }
        }
        public static void LogLastLogin()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("UPDATE Log SET Date='" + DateTime.Now.ToString() + "' WHERE ID=1");
            }
        }
        public static void TruncateLog()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("DELETE FROM Log;");
                cnn.Execute("INSERT INTO Log (Date, LogText) VALUES ('" + DateTime.Now.ToString() + "', 'Last login')");
            }
        }

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
                cnn.Execute("INSERT INTO Log (Date, LogText) VALUES (@date, @logText)", new { date = DateTime.Now.ToString() , logText = "Header added to " + header.ListType + ": \"" + header.ListGroup + "\""});
            }
        }

        public static void UpdateHeader(HeaderModel header)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("UPDATE ListHeaders SET ListGroup=@ListGroup, SortOrder=@SortOrder WHERE ID=@ID", header);
                cnn.Execute("INSERT INTO Log (Date, LogText) VALUES (@date, @logText)", new { date = DateTime.Now.ToString(), logText = header.ListType + " header updated: ID=" + header.ID + ", Title=\"" + header.ListGroup + "\", SortOrder=" + header.SortOrder});
            }
        }

        public static void DeleteHeader(HeaderModel header)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("DELETE FROM ListHeaders WHERE ID=@ID", header);
                cnn.Execute("INSERT INTO Log (Date, LogText) VALUES (@date, @logText)", new { date = DateTime.Now.ToString(), logText = header.ListType + " header \"" + header.ListGroup + "\" deleted" });
            }
        }

        public static void UpdateAnimeListGroup(string newheader, string oldheader)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var i = cnn.Execute("UPDATE Anime SET ListGroup='" + newheader + "' WHERE ListGroup='" + oldheader + "'");
                cnn.Execute("INSERT INTO Log (Date, LogText) VALUES (@date, @logText)", new { date = DateTime.Now.ToString(), logText = "Anime list group changed from \"" + oldheader + "\" to \"" + newheader + "\" in " + i + " records"});
            }
        }

        public static void UpdateSeriesListGroup(string newheader, string oldheader)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var i = cnn.Execute("UPDATE Series SET ListGroup='" + newheader + "' WHERE ListGroup='" + oldheader + "'");
                cnn.Execute("INSERT INTO Log (Date, LogText) VALUES (@date, @logText)", new { date = DateTime.Now.ToString(), logText = "Series list group changed from \"" + oldheader + "\" to \"" + newheader + "\" in " + i + " records" });
            }
        }

        public static void UpdateGameListGroup(string newheader, string oldheader)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var i = cnn.Execute("UPDATE Game SET ListGroup='" + newheader + "' WHERE ListGroup='" + oldheader + "'");
                cnn.Execute("INSERT INTO Log (Date, LogText) VALUES (@date, @logText)", new { date = DateTime.Now.ToString(), logText = "Game list group changed from \"" + oldheader + "\" to \"" + newheader + "\" in " + i + " records" });
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

        public static void SaveAnime(AnimeModel anime)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("INSERT INTO Anime (Title, Url, PictureUrl, Score, Year, Favourite, Notes, ListGroup, Season, TotalEp, WatchedEp, Dubbed) " +
                    "VALUES (@Title, @Url, @PictureUrl, @Score, @Year, @Favourite, @Notes, @ListGroup, @Season, @TotalEp, @WatchedEp, @Dubbed)", anime);
                cnn.Execute("INSERT INTO Log (Date, LogText) VALUES (@date, @logText)", new { date = DateTime.Now.ToString(), logText = "Anime added: Title=\"" + anime.Title + "\""});
            }
        }

        public static void UpdateAnime(AnimeModel anime)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("UPDATE Anime SET Title=@Title, Url=@Url, PictureUrl=@PictureUrl, Score=@Score, Year=@Year, Favourite=@Favourite, " +
                    "Notes=@Notes, ListGroup=@ListGroup, Season=@Season, TotalEp=@TotalEp, WatchedEp=@WatchedEp, Dubbed=@Dubbed WHERE ID=@ID", anime);
                cnn.Execute("INSERT INTO Log (Date, LogText) VALUES (@date, @logText)", new { date = DateTime.Now.ToString(), logText = "Anime updated: ID=" + anime.ID + ", Title=\"" + anime.Title + "\"" });
            }
        }

        public static void DeleteAnime(AnimeModel anime)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("DELETE FROM Anime WHERE ID=@ID", anime);
                cnn.Execute("INSERT INTO Log (Date, LogText) VALUES (@date, @logText)", new { date = DateTime.Now.ToString(), logText = "Anime deleted: ID=" + anime.ID + ", Title=\"" + anime.Title + "\"" });
            }
        }

        public static int GetLastAnimeID()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<int>("SELECT ID FROM Anime ORDER BY ID DESC LIMIT 1").First();
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

        public static void SaveGame(GameModel game)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("INSERT INTO Games (Title, Url, PictureUrl, Score, Year, Favourite, Notes, ListGroup) " +
                    "VALUES (@Title, @Url, @PictureUrl, @Score, @Year, @Favourite, @Notes, @ListGroup)", game);
                cnn.Execute("INSERT INTO Log (Date, LogText) VALUES (@date, @logText)", new { date = DateTime.Now.ToString(), logText = "Game added: Title=\"" + game.Title + "\"" });
            }
        }

        public static void UpdateGame(GameModel game)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("UPDATE Games SET Title=@Title, Url=@Url, PictureUrl=@PictureUrl, Score=@Score, Year=@Year, Favourite=@Favourite, " +
                    "Notes=@Notes, ListGroup=@ListGroup WHERE ID=@ID", game);
                cnn.Execute("INSERT INTO Log (Date, LogText) VALUES (@date, @logText)", new { date = DateTime.Now.ToString(), logText = "Game updated: ID=" + game.ID + ", Title=\"" + game.Title + "\"" });
            }
        }

        public static void DeleteGame(GameModel game)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("DELETE FROM Games WHERE ID=@ID", game);
                cnn.Execute("INSERT INTO Log (Date, LogText) VALUES (@date, @logText)", new { date = DateTime.Now.ToString(), logText = "Game deleted: ID=" + game.ID + ", Title=\"" + game.Title + "\"" });
            }
        }

        public static int GetLastGameID()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query("SELECT ID FROM Games ORDER BY ID DESC LIMIT 1").First();
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

        public static void SaveSeries(SeriesModel series)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("INSERT INTO Anime (Title, Url, PictureUrl, Score, Year, Favourite, Notes, ListGroup, TotalSe, CurrentSe, TotalEp, WatchedEp, FinishedRunning) " +
                    "VALUES (@Title, @Url, @PictureUrl, @Score, @Year, @Favourite, @Notes, @ListGroup, @TotalSe, @CurrentSe, @TotalEp, @WatchedEp, @FinishedRunning)", series);
                cnn.Execute("INSERT INTO Log (Date, LogText) VALUES (@date, @logText)", new { date = DateTime.Now.ToString(), logText = "Series added: Title=\"" + series.Title + "\"" });
            }
        }

        public static void UpdateSeries(SeriesModel series)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("UPDATE Series SET Title=@Title, Url=@Url, PictureUrl=@PictureUrl, Score=@Score, Year=@Year, Favourite=@Favourite, Notes=@Notes, " + 
                    "ListGroup=@ListGroup, TotalSe=@TotalSe, CurrentSe=@CurrentSe, TotalEp=@TotalEp, WatchedEp=@WatchedEp, FinishedRunning=@FinishedRunning WHERE ID=@ID", series);
                cnn.Execute("INSERT INTO Log (Date, LogText) VALUES (@date, @logText)", new { date = DateTime.Now.ToString(), logText = "Series updated: ID=" + series.ID + ", Title=\"" + series.Title + "\"" });
            }
        }

        public static void DeleteSeries(SeriesModel series)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("DELETE FROM Series WHERE ID=@ID", series);
                cnn.Execute("INSERT INTO Log (Date, LogText) VALUES (@date, @logText)", new { date = DateTime.Now.ToString(), logText = "Series deleted: ID=" + series.ID + ", Title=\"" + series.Title + "\"" });
            }
        }

        public static int GetLastSeriesID()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query("SELECT ID FROM Series ORDER BY ID DESC LIMIT 1").First();
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
