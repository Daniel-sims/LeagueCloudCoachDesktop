using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueCloudCoachDesktop.Models.MatchData;
using LeagueCloudCoachDesktop.Models.StaticData;
using LeagueCloudCoachDesktop.Providers;

namespace LeagueCloudCoachDesktop.ViewModel.Matchup
{
    public class MatchupInformationViewModel
    {
        private IStaticDataProvider StaticDataProvider { get; } = new StaticDataProvider();
        private IEnumerable<Item> Items { get; }
        private IEnumerable<SummonerSpell> SummonerSpells { get; }
        private IEnumerable<Rune> Runes { get; }

        public MatchupInformationViewModel()
        {
            Items = StaticDataProvider.GetItemsStatic().Result.ToList();
            SummonerSpells = StaticDataProvider.GetSummonerSpellsStatic().Result.ToList();
            Runes = StaticDataProvider.GetRunesStatic().Result.ToList();
        }
        
        public int UsersChampionId { get; set; }
        public MatchPlayer UserMatchPlayer { get { return UsersTeam.Players.FirstOrDefault(x => x.ChampionId == UsersChampionId); } }
        public Champion UsersChampion
        {
            get
            {
                return StaticDataProvider.GetChampionsStatic().Result
                    .FirstOrDefault(x => x.ChampionId == UsersChampionId);
            }
        }
        
        public Match Matchup { get; set; }

        public MatchTeam UsersTeam { get { return Matchup?.Teams?.FirstOrDefault(x => x.Players.Any(y => y?.ChampionId == UsersChampionId)); } }

        public MatchTeam EnemyTeam { get { return Matchup?.Teams?.FirstOrDefault(x => x.Players.All(y => y?.ChampionId != UsersChampionId)); } }

        // Expander header bindings
        public bool UsersTeamWin => Matchup?.WinningTeamId == UsersTeam?.TeamId;

        private const string ChampionsImagesPath = @"\Images\Champion\";
        private const string SummonerSpellsImagesPath = @"\Images\SummonerSpell\";
        private const string RuneStyleImagesPath = @"\Images\Rune\Style\";
        private const string ItemsImagesPath = @"\Images\Item\";

        private const string PngFileExtension = ".png";

        public string UsersChampionIconPath => ChampionsImagesPath + UsersChampion?.ImageFull;

        public string UsersSummonerOneIconPath => SummonerSpellsImagesPath + SummonerSpells?.FirstOrDefault(x => x.SummonerSpellId == UserMatchPlayer.SummonerSpellOneId)?.ImageFull;
        public string UsersSummonerTwoIconPath => SummonerSpellsImagesPath + SummonerSpells?.FirstOrDefault(x => x.SummonerSpellId == UserMatchPlayer.SummonerSpellTwoId)?.ImageFull;

        public string UsersPrimaryRuneStyleIconPath => RuneStyleImagesPath + UserMatchPlayer?.PrimaryRuneStyleId + PngFileExtension;
        public string UsersSecondaryRuneStyleIconPath => RuneStyleImagesPath + UserMatchPlayer?.SecondaryRuneStyleId + PngFileExtension;
        
        public string ItemOneIconPath => ItemsImagesPath + (Items?.FirstOrDefault(x => x.ItemId == UserMatchPlayer.Item1Id)?.ImageFull ?? "3637" + PngFileExtension);
        public string ItemTwoIconPath => ItemsImagesPath + (Items?.FirstOrDefault(x => x.ItemId == UserMatchPlayer.Item2Id)?.ImageFull ?? "3637" + PngFileExtension);
        public string ItemThreeIconPath => ItemsImagesPath + (Items?.FirstOrDefault(x => x.ItemId == UserMatchPlayer.Item3Id)?.ImageFull ?? "3637" + PngFileExtension);
        public string ItemFourIconPath => ItemsImagesPath + (Items?.FirstOrDefault(x => x.ItemId == UserMatchPlayer.Item4Id)?.ImageFull ?? "3637" + PngFileExtension);
        public string ItemFiveIconPath => ItemsImagesPath + (Items?.FirstOrDefault(x => x.ItemId == UserMatchPlayer.Item5Id)?.ImageFull ?? "3637" + PngFileExtension);
        public string ItemSixIconPath => ItemsImagesPath + (Items?.FirstOrDefault(x => x.ItemId == UserMatchPlayer.Item6Id)?.ImageFull ?? "3637" + PngFileExtension);
        public string TrinketIconPath => ItemsImagesPath + (Items?.FirstOrDefault(x => x.ItemId == UserMatchPlayer.TrinketId)?.ImageFull ?? "3637" + PngFileExtension);
        
    }
}
