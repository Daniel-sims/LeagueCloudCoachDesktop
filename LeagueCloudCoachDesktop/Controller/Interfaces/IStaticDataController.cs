using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueCloudCoachDesktop.Models.StaticData;

namespace LeagueCloudCoachDesktop.Controller.Interfaces
{
    public interface IStaticDataController
    {
        Task<IEnumerable<Champion>> GetChampionData();
        Task<IEnumerable<Item>> GetItemData();
        Task<IEnumerable<SummonerSpell>> GetSummonerSpellData();
        Task<IEnumerable<Rune>> GetRuneData();
    }
}
