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
                var output = cnn.Query<ListHeaderModel>("SELECT * FROM ListHeaders", new DynamicParameters());
                return output.ToList();
            }
        }

        // Anime SQL
   
        public static List<AnimeModel> LoadAllAnime()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<AnimeModel>("SELECT * FROM Anime", new DynamicParameters());
                return output.ToList();
            }
        }
        public static List<AnimeModel> LoadAnimeGroup(string listGroup)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<AnimeModel>("SELECT * FROM Anime WHERE ListGroup=" + listGroup, new DynamicParameters());
                return output.ToList();
            }
        }

        public static void SaveAnime(AnimeModel anime)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("INSERT INTO Anime (Title) VALUES (@Title)", anime);
            }
        }

        public static void UpdateAnime(AnimeModel anime)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("UPDATE Anime SET Title=@Title WHERE ID=@ID", anime);
            }
        }

        public static void DeleteAnime(AnimeModel anime)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("DELETE FROM Anime (Title) WHERE ID=@ID", anime);
            }
        }

        // Game SQL

        // Series SQL

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
