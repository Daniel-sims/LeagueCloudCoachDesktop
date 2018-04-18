using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueCloudCoachDesktop.Dto.StaticData;

namespace LeagueCloudCoachDesktop.Controller.Interfaces
{
    public interface IStaticDataController
    {
        Task<IEnumerable<ChampionDto>> GetChampionData();
        Task<IEnumerable<ItemDto>> GetItemData();
        Task<IEnumerable<SummonerSpellDto>> GetSummonerSpellData();
        Task<IEnumerable<RuneDto>> GetRuneData();
    }
}
