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
        Task<List<Champion>> GetChampionData();
        //Task<List<Item>> GetItemData();
        //Task<List<SummonerSpell>> GetSummonerSpellData();
    }
}
