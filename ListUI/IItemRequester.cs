using ListLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListUI
{
    public interface IItemRequester
    {
        void AnimeItemComplete(AnimeModel model);
        void SeriesItemComplete(SeriesModel model);
        void GameItemComplete(GameModel model);
        void AnimeDeleteComplete(List<AnimeModel> modifylist);
        void SeriesDeleteComplete(List<SeriesModel> modifylist);
        void GameDeleteComplete(List<GameModel> modifylist);
    }
}
