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
        public static List<ListHeaderModel> LoadListHeaders()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<ListHeaderModel>("SELECT LH.ListType, LH.ListGroup, LH.SortOrder, (SELECT COUNT(1) FROM Anime AS A WHERE A.ListGroup = LH.ListGroup) AS Count FROM ListHeaders AS LH");
                return output.ToList();
            }
        }

        // Anime SQL

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
                var output = cnn.Query("SELECT ID FROM Anime ORDER BY ID DESC LIMIT 1").First();
                return output;
            }
        }

        // Game SQL

        // Series SQL

        public static void UpdateSeries(SeriesModel series)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("UPDATE Series SET Title=@Title, Url=@Url, PictureUrl=@PictureUrl, Score=@Score, Year=@Year, Favourite=@Favourite, " +
                    "Notes=@Notes, ListGroup=@ListGroup, TotalSe=@TotalSe, CurrentSe=@CurrentSe, TotalEp=@TotalEp, WatchedEp=@WatchedEp, FinishedRunning=@FinishedRunning WHERE ID=@ID", series);
            }
        }

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
