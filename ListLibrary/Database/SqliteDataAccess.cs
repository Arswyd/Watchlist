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
        // Headers

        public static List<ListHeaderModel> LoadAnimeListHeaders()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<ListHeaderModel>("SELECT LH.ListType, LH.ListGroup, LH.SortOrder, (SELECT COUNT(1) FROM Anime AS A WHERE A.ListGroup = LH.ListGroup) AS Count FROM ListHeaders AS LH WHERE LH.ListType = 'Anime'");
                return output.ToList();
            }
        }
        public static List<ListHeaderModel> LoadGameListHeaders()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<ListHeaderModel>("SELECT LH.ListType, LH.ListGroup, LH.SortOrder, (SELECT COUNT(1) FROM Games AS G WHERE G.ListGroup = LH.ListGroup) AS Count FROM ListHeaders AS LH WHERE LH.ListType = 'Game'");
                return output.ToList();
            }
        }

        public static List<ListHeaderModel> LoadSeriesListHeaders()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<ListHeaderModel>("SELECT LH.ListType, LH.ListGroup, LH.SortOrder, (SELECT COUNT(1) FROM Series AS S WHERE S.ListGroup = LH.ListGroup) AS Count FROM ListHeaders AS LH WHERE LH.ListType = 'Series'");
                return output.ToList();
            }
        }

        // Anime SQL

        #region Anime SQL

        public static List<AnimeModel> LoadAllAnime()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<AnimeModel>("SELECT * FROM Anime");
                return output.ToList();
            }
        }
        public static List<AnimeModel> LoadAnimeGroup(string sqlString)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<AnimeModel>(sqlString);
                return output.ToList();
            }
        }

        public static void SaveAnime(AnimeModel anime)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("INSERT INTO Anime (Title, Url, PictureUrl, Score, Year, Favourite, Notes, ListGroup, Season, TotalEp, WatchedEp, Dubbed) " +
                    "VALUES (@Title, @Url, @PictureUrl, @Score, @Year, @Favourite, @Notes, @ListGroup, @Season, @TotalEp, @WatchedEp, @Dubbed)", anime);
            }
        }

        public static void UpdateAnime(AnimeModel anime)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("UPDATE Anime SET Title=@Title, Url=@Url, PictureUrl=@PictureUrl, Score=@Score, Year=@Year, Favourite=@Favourite, " +
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

        public static List<GameModel> LoadAllGame()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<GameModel>("SELECT * FROM Games");
                return output.ToList();
            }
        }

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
            }
        }

        public static void UpdateGame(GameModel game)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("UPDATE Games SET Title=@Title, Url=@Url, PictureUrl=@PictureUrl, Score=@Score, Year=@Year, Favourite=@Favourite, " +
                    "Notes=@Notes, ListGroup=@ListGroup WHERE ID=@ID", game);
            }
        }

        public static void DeleteGame(GameModel game)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("DELETE FROM Games WHERE ID=@ID", game);
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

        public static List<SeriesModel> LoadAllSeries()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<SeriesModel>("SELECT * FROM Series");
                return output.ToList();
            }
        }
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
            }
        }

        public static void UpdateSeries(SeriesModel series)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("UPDATE Series SET Title=@Title, Url=@Url, PictureUrl=@PictureUrl, Score=@Score, Year=@Year, Favourite=@Favourite, Notes=@Notes, " + 
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
