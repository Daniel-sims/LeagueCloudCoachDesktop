using LeagueCloudCoachDesktop.Constants;
using LeagueCloudCoachDesktop.Dto.StaticData;
using LeagueCloudCoachDesktop.Models.StaticData;
using System;
using System.Collections.Generic;

namespace LeagueCloudCoachDesktop.DtoToModelConverter
{
    public static class StaticDataDtoConverter
    {
        public static IEnumerable<Champion> ConvertChampionDtoListToChampionList(IEnumerable<ChampionDto> championDtoList)
        {
            var championList = new List<Champion>();

            foreach (var championDto in championDtoList)
            {
                championList.Add(ConvertChampionDtoToChampion(championDto));
            }

            return championList;
        }
        
        public static Champion ConvertChampionDtoToChampion(ChampionDto championDto)
        {
            if (championDto == null) return new Champion();

            try
            {
                return new Champion
                {
                    ChampionId = championDto.ChampionId,
                    ChampionName = championDto.ChampionName,
                    ChampionIconPath = ImageLocationStrings.ChampionsImagesPath + championDto.ImageFull
                };
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception caught when converting ChampionDto to Champion : " + e.Message);
            }

            return new Champion();
        }

        public static IEnumerable<Item> ConvertItemDtoListToItemList(IEnumerable<ItemDto> itemDtoList)
        {
            var itemList = new List<Item>();

            foreach (var itemDto in itemDtoList)
            {
                itemList.Add(ConvertItemDtoToItem(itemDto));
            }

            return itemList;
        }

        public static Item ConvertItemDtoToItem(ItemDto itemDto)
        {
            if (itemDto == null) return new Item { ItemName = "Empty", ItemIconPath = ImageLocationStrings.ItemsImagesPath + "3637" + ImageLocationStrings.PngFileExtension };

            try
            {
                return new Item
                {
                    ItemId = itemDto.ItemId,
                    ItemName = itemDto.ItemName,
                    ItemIconPath = ImageLocationStrings.ItemsImagesPath + itemDto.ItemId + ImageLocationStrings.PngFileExtension
                };
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception caught when converting ItemDto to Item : " + e.Message);
            }

            return new Item();
        }

        public static IEnumerable<Rune> ConvertRuneDtoListToRunList(IEnumerable<RuneDto> runeDtoList)
        {
            var runeList = new List<Rune>();

            foreach (var runeDto in runeDtoList)
            {
                runeList.Add(ConvertRuneDtoToRune(runeDto));
            }

            return runeList;
        }

        public static Rune ConvertRuneDtoToRune(RuneDto runeDto)
        {
            if (runeDto == null) return new Rune();

            try
            {
                return new Rune
                {
                    //Sub rune
                    RuneId = runeDto.RuneId,
                    RuneName = runeDto.RuneName,
                    RuneIconPath = ImageLocationStrings.RuneSubStyleImagesPath + runeDto.RuneId + ImageLocationStrings.PngFileExtension,
                    //Parent rune
                    RunePathId = runeDto.RunePathId,
                    RunePathName = runeDto.RunePathName,
                    RunePathIconPath = ImageLocationStrings.RuneStyleImagesPath + runeDto.RunePathId + ImageLocationStrings.PngFileExtension,
                };
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception caught when converting RuneDto Style to Rune Style : " + e.Message);
            }

            return new Rune();
        }
        
        public static IEnumerable<SummonerSpell> ConvertSummonerSpellDtoListToSummonerSpellList(
            IEnumerable<SummonerSpellDto> summonerSpellDtoList)
        {
            var summonerSpellList = new List<SummonerSpell>();

            foreach (var summonerSpellDto in summonerSpellDtoList)
            {
                summonerSpellList.Add(ConvertSummonerSpellDtoToSummonerSpell(summonerSpellDto));
            }

            return summonerSpellList;
        }

        public static SummonerSpell ConvertSummonerSpellDtoToSummonerSpell(SummonerSpellDto summonerSpellDto)
        {
            if (summonerSpellDto == null) return new SummonerSpell();

            try
            {
                return new SummonerSpell
                {
                    SummonerSpellId = summonerSpellDto.SummonerSpellId,
                    SummonerSpellName = summonerSpellDto.SummonerSpellName,
                    SummonerSpellIconPath = ImageLocationStrings.SummonerSpellsImagesPath + summonerSpellDto.ImageFull
                };
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception caught when converting SummonerSpellDto to SummonerSpell : " + e.Message);
            }

            return new SummonerSpell();
        }
    }
}
