using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueCloudCoachDesktop.Dto.StaticData;

namespace LeagueCloudCoachDesktop.Providers
{
    public interface IStaticDataProvider
    {
        Task<IEnumerable<ItemDto>> GetItemsStatic();
        Task<IEnumerable<ChampionDto>> GetChampionsStatic();
        Task<IEnumerable<RuneDto>> GetRunesStatic();
        Task<IEnumerable<SummonerSpellDto>> GetSummonerSpellsStatic();
    }
}
