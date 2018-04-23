using LeagueCloudCoachDesktop.Controller;
using LeagueCloudCoachDesktop.Controller.Interfaces;
using LeagueCloudCoachDesktop.DtoToModelConverter;
using LeagueCloudCoachDesktop.Models.StaticData;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LeagueCloudCoachDesktop.Providers
{
    public class StaticDataProvider
    {
        private static IStaticDataController StaticDataController { get; } = new StaticDataController();
        
        private static IEnumerable<Item> _items;
        public static async Task<IEnumerable<Item>> GetItemsStatic() => 
            _items ?? (_items = StaticDataDtoConverter.ConvertItemDtoListToItemList(await StaticDataController.GetItemData()));
        

        private static IEnumerable<Champion> _champions;
        public static async Task<IEnumerable<Champion>> GetChampionsStatic() => 
            _champions ?? (_champions = StaticDataDtoConverter.ConvertChampionDtoListToChampionList(await StaticDataController.GetChampionData()));
        

        private static IEnumerable<Rune> _runes;
        public static async Task<IEnumerable<Rune>> GetRunesStatic() =>
            _runes ?? (_runes = StaticDataDtoConverter.ConvertRuneDtoListToRunList(await StaticDataController.GetRuneData()));
        

        private static IEnumerable<SummonerSpell> _summonerSpells;
        public static async Task<IEnumerable<SummonerSpell>> GetSummonerSpellsStatic() => 
            _summonerSpells ?? (_summonerSpells = StaticDataDtoConverter.ConvertSummonerSpellDtoListToSummonerSpellList(await StaticDataController.GetSummonerSpellData()));
        
    }
}
