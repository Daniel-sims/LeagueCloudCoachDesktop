using LeagueCloudCoachDesktop.Controller;
using LeagueCloudCoachDesktop.Controller.Interfaces;
using LeagueCloudCoachDesktop.Models.StaticData;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LeagueCloudCoachDesktop.Providers
{
    public class StaticDataProvider : IStaticDataProvider
    {
        private IStaticDataController StaticDataController { get; } = new StaticDataController();
        
        private static IEnumerable<Item> _items;
        public async Task<IEnumerable<Item>> GetItemsStatic()
        {
            return _items ?? (_items = await StaticDataController.GetItemData());
        }

        private static IEnumerable<Champion> _champions;
        public async Task<IEnumerable<Champion>> GetChampionsStatic()
        {
            return _champions ?? (_champions = await StaticDataController.GetChampionData());
        }

        private static IEnumerable<Rune> _runes;
        public async Task<IEnumerable<Rune>> GetRunesStatic()
        {
            return _runes ?? (_runes = await StaticDataController.GetRuneData());
        }

        private static IEnumerable<SummonerSpell> _summonerSpells;
        public async Task<IEnumerable<SummonerSpell>> GetSummonerSpellsStatic()
        {
            return _summonerSpells ?? (_summonerSpells = await StaticDataController.GetSummonerSpellData());
        }
    }
}
