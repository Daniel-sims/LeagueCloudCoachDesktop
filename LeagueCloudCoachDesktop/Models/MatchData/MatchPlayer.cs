using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueCloudCoachDesktop.Constants;
using LeagueCloudCoachDesktop.Dto.MatchData;
using LeagueCloudCoachDesktop.Dto.StaticData;
using LeagueCloudCoachDesktop.Providers;

namespace LeagueCloudCoachDesktop.Models.MatchData
{
    public class MatchPlayer
    {
        // Raw match data
        public MatchPlayerDto MatchPlayerDto { get; set; }

        // Data to bind to
        public IEnumerable<ItemDto> Items => StaticDataProvider.GetItemsStatic().Result;
        public IEnumerable<SummonerSpellDto> SummonerSpells => StaticDataProvider.GetSummonerSpellsStatic().Result;

        public ChampionDto Champion => StaticDataProvider.GetChampionsStatic().Result.FirstOrDefault(x => x.ChampionId == MatchPlayerDto.ChampionId);
        
        public long TotalCreepScore => MatchPlayerDto.NeutralMinionsKilled + MatchPlayerDto.TotalMinionsKilled;
        
        public string ChampionIconPath => ImageLocationStrings.ChampionsImagesPath + Champion?.ImageFull;

        public string SummonerOneIconPath => ImageLocationStrings.SummonerSpellsImagesPath + SummonerSpells?.FirstOrDefault(x => x.SummonerSpellId == MatchPlayerDto.SummonerSpellOneId)?.ImageFull;
        public string SummonerTwoIconPath => ImageLocationStrings.SummonerSpellsImagesPath + SummonerSpells?.FirstOrDefault(x => x.SummonerSpellId == MatchPlayerDto.SummonerSpellTwoId)?.ImageFull;

        public string PrimaryRuneStyleIconPath => ImageLocationStrings.RuneStyleImagesPath + MatchPlayerDto?.PrimaryRuneStyleId + ImageLocationStrings.PngFileExtension;
        public string SecondaryRuneStyleIconPath => ImageLocationStrings.RuneStyleImagesPath + MatchPlayerDto?.SecondaryRuneStyleId + ImageLocationStrings.PngFileExtension;

        public string ItemOneIconPath => ImageLocationStrings.ItemsImagesPath + (Items?.FirstOrDefault(x => x.ItemId == MatchPlayerDto.Item1Id)?.ImageFull ?? "3637" + ImageLocationStrings.PngFileExtension);
        public string ItemTwoIconPath => ImageLocationStrings.ItemsImagesPath + (Items?.FirstOrDefault(x => x.ItemId == MatchPlayerDto.Item2Id)?.ImageFull ?? "3637" + ImageLocationStrings.PngFileExtension);
        public string ItemThreeIconPath => ImageLocationStrings.ItemsImagesPath + (Items?.FirstOrDefault(x => x.ItemId == MatchPlayerDto.Item3Id)?.ImageFull ?? "3637" + ImageLocationStrings.PngFileExtension);
        public string ItemFourIconPath => ImageLocationStrings.ItemsImagesPath + (Items?.FirstOrDefault(x => x.ItemId == MatchPlayerDto.Item4Id)?.ImageFull ?? "3637" + ImageLocationStrings.PngFileExtension);
        public string ItemFiveIconPath => ImageLocationStrings.ItemsImagesPath + (Items?.FirstOrDefault(x => x.ItemId == MatchPlayerDto.Item5Id)?.ImageFull ?? "3637" + ImageLocationStrings.PngFileExtension);
        public string ItemSixIconPath => ImageLocationStrings.ItemsImagesPath + (Items?.FirstOrDefault(x => x.ItemId == MatchPlayerDto.Item6Id)?.ImageFull ?? "3637" + ImageLocationStrings.PngFileExtension);
        public string TrinketIconPath => ImageLocationStrings.ItemsImagesPath + (Items?.FirstOrDefault(x => x.ItemId == MatchPlayerDto.TrinketId)?.ImageFull ?? "3637" + ImageLocationStrings.PngFileExtension);
    }
}
