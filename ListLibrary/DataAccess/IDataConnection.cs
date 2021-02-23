using ListLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListLibrary.DataAccess
{
    public interface IDataConnection
    {
        AnimeModel AddAnime(AnimeModel model);

        SeriesModel AddSeries(SeriesModel model);

        GameModel AddGame(GameModel model);

        List<AnimeModel> GetAnime_All();

        List<SeriesModel> GetSeries_All();

        List<GameModel> GetGame_All();

        AnimeModel RemoveAnime(AnimeModel model);

        SeriesModel RemoveSeries(SeriesModel model);

        GameModel RemoveGame(GameModel model);
    }

}
