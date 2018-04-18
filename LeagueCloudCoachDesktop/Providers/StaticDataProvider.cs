using LeagueCloudCoachDesktop.Controller;
using LeagueCloudCoachDesktop.Controller.Interfaces;
using LeagueCloudCoachDesktop.Dto.StaticData;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LeagueCloudCoachDesktop.Providers
{
    public class StaticDataProvider
    {
        private static IStaticDataController StaticDataController { get; } = new StaticDataController();
        
        private static IEnumerable<ItemDto> _items;
        public static async Task<IEnumerable<ItemDto>> GetItemsStatic()
        {
            return _items ?? (_items = await StaticDataController.GetItemData());
        }

        private static IEnumerable<ChampionDto> _champions;
        public static async Task<IEnumerable<ChampionDto>> GetChampionsStatic()
        {
            return _champions ?? (_champions = await StaticDataController.GetChampionData());
        }

        private static IEnumerable<RuneDto> _runes;
        public static async Task<IEnumerable<RuneDto>> GetRunesStatic()
        {
            return _runes ?? (_runes = await StaticDataController.GetRuneData());
        }

        private static IEnumerable<SummonerSpellDto> _summonerSpells;
        public static async Task<IEnumerable<SummonerSpellDto>> GetSummonerSpellsStatic()
        {
            return _summonerSpells ?? (_summonerSpells = await StaticDataController.GetSummonerSpellData());
        }
    }
}
