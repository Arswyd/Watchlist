using Dapper;
using ListLibrary.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;

namespace ListLibrary.Database
{
    public static class SqliteDataAccess
    {
        // AppData

        public static int GetClientType()
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

        public static int GetShowingDeleted()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.QueryFirstOrDefault<int>("SELECT IsShowingDeleted FROM AppData WHERE ID=1");
                return output;
            }
        }

        public static void ChangeShowingDeleted(bool isShowingDeleted)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                int i = isShowingDeleted ? 1 : 0;
                cnn.Execute("UPDATE AppData SET IsShowingDeleted = " + i + " WHERE ID=1");
            }
        }

        public static DateTime GetAnimeSyncDate()
        {
            string sSQL = "SELECT AnimeSyncDate FROM AppData WHERE ID=1";

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.QueryFirstOrDefault<string>(sSQL);

                if (output != null)
                    return DateTime.Parse(output);
                else
                    return DateTime.MinValue;
            }
        }
        public static void SetAnimeSyncDate()
        {
            string sSQL = "UPDATE AppData SET AnimeSyncDate = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' WHERE ID=1";

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Execute(sSQL);
            }
        }

        public static DateTime GetSeriesSyncDate()
        {
            string sSQL = "SELECT SeriesSyncDate FROM AppData WHERE ID=1";

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.QueryFirstOrDefault<string>(sSQL);

                if (output != null)
                    return DateTime.Parse(output);
                else
                    return DateTime.MinValue;
            }
        }

        public static void SetSeriesSyncDate()
        {
            string sSQL = "UPDATE AppData SET SeriesSyncDate = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' WHERE ID=1";

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Execute(sSQL);
            }
        }

        public static DateTime GetGameSyncDate()
        {
            string sSQL = "SELECT GameSyncDate FROM AppData WHERE ID=1";

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.QueryFirstOrDefault<string>(sSQL);

                if (output != null)
                    return DateTime.Parse(output);
                else
                    return DateTime.MinValue;
            }
        }

        public static void SetGameSyncDate()
        {
            string sSQL = "UPDATE AppData SET GameSyncDate = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' WHERE ID=1";

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Execute(sSQL);
            }
        }

        // Headers

        public static List<HeaderModel> LoadAnimeListHeaders(bool isShowingDeleted)
        {
            string sDelete = isShowingDeleted ? "" : "AND LH.ID <> 0 ";
            string sSQL = "SELECT LH.ID, LH.ListType, LH.ListGroup, LH.SortOrder, (SELECT COUNT(1) FROM Anime AS A WHERE A.ListGroup = LH.ListGroup) AS Count " +
                          "FROM ListHeaders AS LH " +
                          "WHERE LH.ListType = 0 " + sDelete + "ORDER BY LH.SortOrder";

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<HeaderModel>(sSQL);
                return output.ToList();
            }
        }

        public static List<HeaderModel> LoadGameListHeaders(bool isShowingDeleted)
        {
            string sDelete = isShowingDeleted ? "" : "AND LH.ID <> 0 ";
            string sSQL = "SELECT LH.ID, LH.ListType, LH.ListGroup, LH.SortOrder, (SELECT COUNT(1) FROM Games AS G WHERE G.ListGroup = LH.ListGroup) AS Count " +
                          "FROM ListHeaders AS LH " +
                          "WHERE LH.ListType = 2 " + sDelete + "ORDER BY LH.SortOrder";

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<HeaderModel>(sSQL);
                return output.ToList();
            }
        }

        public static List<HeaderModel> LoadSeriesListHeaders(bool isShowingDeleted)
        {
            string sDelete = isShowingDeleted ? "" : "AND LH.ID <> 0 ";
            string sSQL = "SELECT LH.ID, LH.ListType, LH.ListGroup, LH.SortOrder, (SELECT COUNT(1) FROM Series AS S WHERE S.ListGroup = LH.ListGroup) AS Count " +
                          "FROM ListHeaders AS LH " +
                          "WHERE LH.ListType = 1 " + sDelete + "ORDER BY LH.SortOrder";

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<HeaderModel>(sSQL);
                return output.ToList();
            }
        }

        public static void SaveHeader(HeaderModel header)
        {
            string sSQL = "INSERT INTO ListHeaders (ListType, ListGroup, SortOrder) " +
                          "VALUES (@ListType, @ListGroup, @SortOrder)";

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute(sSQL, header);
            }
        }

        public static void UpdateHeader(HeaderModel header)
        {
            string sSQL = "UPDATE ListHeaders " +
                          "SET ListGroup=@ListGroup, SortOrder=@SortOrder " +
                          "WHERE ListType=@ListType AND ID=@ID";

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute(sSQL, header);
            }
        }

        public static void DeleteHeader(HeaderModel header)
        {
            string sSQL = "DELETE FROM ListHeaders WHERE ListType=@ListType AND ID=@ID";

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute(sSQL, header);
            }
        }

        public static void UpdateAnimeListGroup(string newheader, string oldheader)
        {
            string sSQL = "UPDATE Anime SET ListGroup='" + newheader + "' WHERE ListGroup='" + oldheader + "'";

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var i = cnn.Execute(sSQL);
            }
        }

        public static void UpdateSeriesListGroup(string newheader, string oldheader)
        {
            string sSQL = "UPDATE Series SET ListGroup='" + newheader + "' WHERE ListGroup='" + oldheader + "'";

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var i = cnn.Execute(sSQL);
            }
        }

        public static void UpdateGameListGroup(string newheader, string oldheader)
        {
            string sSQL = "UPDATE Games SET ListGroup='" + newheader + "' WHERE ListGroup='" + oldheader + "'";

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var i = cnn.Execute(sSQL);
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
            string sSQL = "SELECT A.ID, A.Title, A.Url, A.PictureUrl, A.PicFormat, A.Score, A.Year, A.Favourite, A.Notes, A.ListGroup, A.Season, A.TotalEp, A.WatchedEp, A.Dubbed, A.ModDate " +
                          "FROM Anime A INNER JOIN AppData D ON D.ID = 1 " +
                          "WHERE A.ModDate > D.AnimeSyncDate ";

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<AnimeModel>(sSQL);
                return output.ToList();
            }
        }

        public static AnimeModel LoadAnimeByID(int id)
        {
            string sSQL = "SELECT A.ID, A.Title, A.Url, A.PictureUrl, A.PicFormat, A.Score, A.Year, A.Favourite, A.Notes, A.ListGroup, A.Season, A.TotalEp, A.WatchedEp, A.Dubbed, A.ModDate " +
                          "FROM Anime A " +
                          "WHERE A.ID=" + id;

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.QueryFirstOrDefault<AnimeModel>(sSQL);
                return output;
            }
        }

        public static void SaveAnime(AnimeModel anime)
        {
            string sSQL = "INSERT INTO Anime (Title, Url, PictureUrl, PicFormat, Score, Year, Favourite, Notes, ListGroup, Season, TotalEp, WatchedEp, Dubbed, ModDate) " +
                          "VALUES (@Title, @Url, @PictureUrl, @PicFormat, @Score, @Year, @Favourite, @Notes, @ListGroup, @Season, @TotalEp, @WatchedEp, @Dubbed, @ModDate)";

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute(sSQL, anime);
            }

            SaveItemPicture(anime);
        }

        public static void UpdateAnime(AnimeModel anime)
        {
            string sSQL = "UPDATE Anime " +
                          "SET " +
                            "Title=@Title, Url=@Url, PictureUrl=@PictureUrl, PicFormat=@PicFormat, Score=@Score, Year=@Year, Favourite=@Favourite, " +
                            "Notes=@Notes, ListGroup=@ListGroup, Season=@Season, TotalEp=@TotalEp, WatchedEp=@WatchedEp, Dubbed=@Dubbed, " +
                            "ModDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' " +
                          "WHERE ID=@ID";

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.QueryFirstOrDefault("SELECT 1 FROM Anime WHERE ID=@ID AND PictureUrl<>@PictureUrl", anime);
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
                            SaveItemPicture(anime);
                        }
                    }
                    catch { }
                }

                cnn.Execute(sSQL, anime);
            }
        }

        public static void DeleteAnime(AnimeModel anime)
        {
            string sSQL = "UPDATE Anime " +
                          "SET ListGroup='Deleted', ModDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' " +
                          "WHERE ID=@ID";

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute(sSQL, anime);
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
            if (CheckIfAnimeExists())
            {
                string sSQL = "SELECT MAX(ID) FROM Anime";

                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    var output = cnn.QueryFirstOrDefault<int>(sSQL);
                    return output;
                }
            }
            else
                return 0;
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
            string sSQL = "SELECT G.ID, G.Title, G.Url, G.PictureUrl, G.PicFormat, G.Score, G.Year, G.Favourite, G.Notes, G.ListGroup, G.Platform, G.Owned, G.Lenght, G.ModDate " +
                          "FROM Games G INNER JOIN AppData D ON D.ID = 1 " +
                          "WHERE G.ModDate > D.AnimeSyncDate ";

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<GameModel>(sSQL);
                return output.ToList();
            }
        }

        public static GameModel LoadGameByID(int id)
        {
            string sSQL = "SELECT G.ID, G.Title, G.Url, G.PictureUrl, G.PicFormat, G.Score, G.Year, G.Favourite, G.Notes, G.ListGroup, G.Platform, G.Owned, G.Lenght, G.ModDate " +
                          "FROM Games G " +
                          "WHERE G.ID=" + id;

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.QueryFirstOrDefault<GameModel>(sSQL);
                return output;
            }
        }

        public static void SaveGame(GameModel game)
        {
            string sSQL = "INSERT INTO Games (Title, Url, PictureUrl, PicFormat, Score, Year, Platform, Favourite, Notes, ListGroup, Owned, Lenght, ModDate) " +
                          "VALUES (@Title, @Url, @PictureUrl, @PicFormat, @Score, @Year, @Platform, @Favourite, @Notes, @ListGroup, @Owned, @Lenght, @ModDate";

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute(sSQL, game);
            }

            SaveItemPicture(game);
        }

        public static void UpdateGame(GameModel game)
        {
            string sSQL = "UPDATE Games " +
                          "SET " +
                            "Title=@Title, Url=@Url, PictureUrl=@PictureUrl, PicFormat=@PicFormat, Score=@Score, Year=@Year, Platform=@Platform, Favourite=@Favourite, " +
                            "Notes=@Notes, ListGroup=@ListGroup, Owned=@Owned, Lenght=@Lenght, ModDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' " +
                          "WHERE ID=@ID";

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.QueryFirstOrDefault("SELECT 1 FROM Games WHERE ID=@ID AND PictureUrl<>@PictureUrl", game);
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
                            SaveItemPicture(game);
                        }
                    }
                    catch { }
                }

                cnn.Execute(sSQL, game);
            }
        }

        public static void DeleteGame(GameModel game)
        {
            string sSQL = "UPDATE Games " +
                          "SET ListGroup='Deleted', ModDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' " +
                          "WHERE ID=@ID";

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute(sSQL, game);
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
            if (CheckIfGameExists())
            {
                string sSQL = "SELECT MAX(G.ID) FROM Games G";

                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    var output = cnn.QueryFirstOrDefault<int>(sSQL);
                    return output;
                }
            }
            else
                return 0;
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
            string sSQL = "SELECT S.ID, S.Title, S.Url, S.PictureUrl, S.PicFormat, S.Score, S.Year, S.Favourite, S.Notes, S.ListGroup, S.Platform, S.TotalSe, S.CurrentSe, S.TotalEp, S.WatchedEp, S.FinishedRunning, S.ModDate " +
                          "FROM Series S INNER JOIN AppData D ON D.ID = 1 " +
                          "WHERE S.ModDate > D.AnimeSyncDate";

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<SeriesModel>(sSQL);
                return output.ToList();
            }
        }

        public static SeriesModel LoadSeriesByID(int id)
        {
            string sSQL = "SELECT S.ID, S.Title, S.Url, S.PictureUrl, S.PicFormat, S.Score, S.Year, S.Favourite, S.Notes, S.ListGroup, S.Platform, S.TotalSe, S.CurrentSe, S.TotalEp, S.WatchedEp, S.FinishedRunning, S.ModDate " +
                          "FROM Series S WHERE S.ID=" + id;

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.QueryFirstOrDefault<SeriesModel>(sSQL);
                return output;
            }
        }

        public static void SaveSeries(SeriesModel series)
        {
            string sSQL = "INSERT INTO Series (Title, Url, PictureUrl, PicFormat, Score, Year, Platform, Favourite, Notes, ListGroup, CurrentSe, TotalEp, WatchedEp, FinishedRunning, ModDate) " +
                          "VALUES (@Title, @Url, @PictureUrl, @PicFormat, @Score, @Year, @Platform, @Favourite, @Notes, @ListGroup, @CurrentSe, @TotalEp, @WatchedEp, @FinishedRunning, @ModDate";

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute(sSQL, series);
            }

            SaveItemPicture(series);
        }

        public static void UpdateSeries(SeriesModel series)
        {
            string sSQL = "UPDATE Series " +
                          "SET " +
                            "Title=@Title, Url=@Url, PictureUrl=@PictureUrl, PicFormat=@PicFormat, Score=@Score, Year=@Year, Platform=@Platform, Favourite=@Favourite, Notes=@Notes, " +
                            "ListGroup=@ListGroup, CurrentSe=@CurrentSe, TotalEp=@TotalEp, WatchedEp=@WatchedEp, FinishedRunning=@FinishedRunning, ModDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' " +
                          "WHERE ID=@ID";

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.QueryFirstOrDefault("SELECT 1 FROM Series WHERE ID=@ID AND PictureUrl<>@PictureUrl", series);
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
                            SaveItemPicture(series);
                        }
                    }
                    catch { }
                }

                cnn.Execute(sSQL, series);
            }
        }

        public static void DeleteSeries(SeriesModel series)
        {
            string sSQL = "UPDATE Series " +
                          "SET ListGroup='Deleted', ModDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' " +
                          "WHERE ID=@ID";

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute(sSQL, series);

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
            if (CheckIfSeriesExists())
            {
                string sSQL = "SELECT MAX(ID) FROM Series";

                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    var output = cnn.QueryFirstOrDefault<int>(sSQL);
                    return output;
                }
            }
            else
                return 0;
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

        // Picture

        private static void SaveItemPicture(ItemModel item)
        {
            PictureBox pictureBox = new PictureBox
            {
                Height = 220,
                Width = 160,
                SizeMode = item.PicFormat == 1 ? PictureBoxSizeMode.Zoom : PictureBoxSizeMode.StretchImage
            };

            pictureBox.Load(item.PictureUrl);

            try
            {
                using (Bitmap bitmap = new Bitmap(pictureBox.Width, pictureBox.Height, PixelFormat.Format32bppRgb))
                {
                    pictureBox.DrawToBitmap(bitmap, new Rectangle(0, 0, 160, 220));
                    bitmap.Save(item.PictureDir, ImageFormat.Png);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Picture Url does not exist!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                pictureBox.Dispose();
            }
        }
    }
}
