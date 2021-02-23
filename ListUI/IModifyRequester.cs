using ListLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListUI
{
    public interface IModifyRequester
    {
        void ModifyAnimeRequest(AnimeModel model);
        void ModifySeriesRequest(SeriesModel model);
        void ModifyGameRequest(GameModel model);
        void AddAnimeWatchedEpisode(List<AnimeModel> modifylist);
        void AddSeriesWatchedEpisode(List<SeriesModel> modifylist);
    }
}
