using ListLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListLibrary.DataAccess
{
    public class TextConnector : IDataConnection
    {
        private const string AnimeFile = "AnimeList.csv";
        private const string SeriesFile = "SeriesList.csv";
        private const string GameFile = "GameList.csv";
        public AnimeModel AddAnime(AnimeModel model)
        {
            List<AnimeModel> animes = AnimeFile.FullFilePath().LoadFile().ConvertToAnimeModels();

            int i = 1;

            animes.Add(model);

            foreach (AnimeModel a in animes.OrderBy(v => v.Name))
            {
                a.ID = i;
                i++;
            }

            var newlist = animes.OrderBy(x => x.ID).ToList();

            newlist.SaveToAnimeFile(AnimeFile);

            return model;
        }

        public SeriesModel AddSeries(SeriesModel model)
        {
            List<SeriesModel> series = SeriesFile.FullFilePath().LoadFile().ConvertToSeriesModels();

            int i = 1;

            series.Add(model);

            foreach (SeriesModel s in series.OrderBy(v => v.Name))
            {
                s.ID = i;
                i++;
            }

            var newlist = series.OrderBy(x => x.ID).ToList();

            newlist.SaveToSeriesFile(SeriesFile);

            return model;
        }

        public GameModel AddGame(GameModel model)
        {
            List<GameModel> game = GameFile.FullFilePath().LoadFile().ConvertToGameModels();

            int i = 1;

            game.Add(model);

            foreach (GameModel g in game.OrderBy(v => v.Name))
            {
                g.ID = i;
                i++;
            }

            var newlist = game.OrderBy(x => x.ID).ToList();

            newlist.SaveToGameFile(GameFile);

            return model;
        }

        public AnimeModel RemoveAnime(AnimeModel model)
        {
            List<AnimeModel> animelist = AnimeFile.FullFilePath().LoadFile().ConvertToAnimeModels();

            AnimeModel removemodel = new AnimeModel();

            removemodel = animelist.Find(n => n.Name == model.Name && n.Score == model.Score);

            animelist.Remove(removemodel);

            int i = 1;

            foreach (AnimeModel a in animelist.OrderBy(v => v.Name))
            {
                a.ID = i;
                i++;
            }

            var newlist = animelist.OrderBy(x => x.ID).ToList();

            newlist.SaveToAnimeFile(AnimeFile);

            return removemodel;
        }

        public SeriesModel RemoveSeries(SeriesModel model)
        {
            List<SeriesModel> serieslist = SeriesFile.FullFilePath().LoadFile().ConvertToSeriesModels();

            SeriesModel removemodel = new SeriesModel();

            removemodel = serieslist.Find(n => n.Name == model.Name && n.Score == model.Score);

            serieslist.Remove(removemodel);

            int i = 1;

            foreach (SeriesModel s in serieslist.OrderBy(v => v.Name))
            {
                s.ID = i;
                i++;
            }

            var newlist = serieslist.OrderBy(x => x.ID).ToList();

            newlist.SaveToSeriesFile(SeriesFile);

            return removemodel;
        }

        public GameModel RemoveGame(GameModel model)
        {
            List<GameModel> gamelist = GameFile.FullFilePath().LoadFile().ConvertToGameModels();

            GameModel removemodel = new GameModel();

            removemodel = gamelist.Find(n => n.Name == model.Name && n.Score == model.Score);

            gamelist.Remove(removemodel);

            int i = 1;

            foreach (GameModel g in gamelist.OrderBy(v => v.Name))
            {
                g.ID = i;
                i++;
            }

            var newlist = gamelist.OrderBy(x => x.ID).ToList();

            newlist.SaveToGameFile(GameFile);

            return removemodel;
        }

        public List<AnimeModel> GetAnime_All()
        {
            return AnimeFile.FullFilePath().LoadFile().ConvertToAnimeModels();
        }

        public List<SeriesModel> GetSeries_All()
        {
            return SeriesFile.FullFilePath().LoadFile().ConvertToSeriesModels();
        }

        public List<GameModel> GetGame_All()
        {
            return GameFile.FullFilePath().LoadFile().ConvertToGameModels();
        }
    }

}
