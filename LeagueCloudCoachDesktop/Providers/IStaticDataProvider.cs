using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueCloudCoachDesktop.Models.StaticData;

namespace LeagueCloudCoachDesktop.Providers
{
    public interface IStaticDataProvider
    {
        Task<IEnumerable<Item>> GetItemsStatic();
        Task<IEnumerable<Champion>> GetChampionsStatic();
        Task<IEnumerable<Rune>> GetRunesStatic();
        Task<IEnumerable<SummonerSpell>> GetSummonerSpellsStatic();
    }
}
