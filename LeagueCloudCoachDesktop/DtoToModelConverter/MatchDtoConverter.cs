﻿using LeagueCloudCoachDesktop.Constants;
using LeagueCloudCoachDesktop.Dto.MatchData;
using LeagueCloudCoachDesktop.Dto.StaticData;
using LeagueCloudCoachDesktop.Models.MatchData;
using LeagueCloudCoachDesktop.Models.StaticData;
using LeagueCloudCoachDesktop.Providers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeagueCloudCoachDesktop.DtoToModelConverter
{
    public static class MatchDtoConverter
    {
        private static readonly IEnumerable<ItemDto> Items = StaticDataProvider.GetItemsStatic().Result;
        private static readonly IEnumerable<RuneDto> Runes = StaticDataProvider.GetRunesStatic().Result;
        private static readonly IEnumerable<SummonerSpellDto> SummonerSpells = StaticDataProvider.GetSummonerSpellsStatic().Result;
        private static readonly IEnumerable<ChampionDto> Champions = StaticDataProvider.GetChampionsStatic().Result;



        public static Match ConverMatchDtoToMatch(MatchDto matchDto, MatchTimelineDto matchTimelineDto)
        {
            if(matchDto == null || matchTimelineDto == null) return new Match();

            try
            {
                return new Match
                {
                    GameDuration = matchDto.GameDuration,
                    GameDate = matchDto.GameDate,
                    GamePatch = matchDto.GamePatch,
                    WinningTeamId = matchDto.WinningTeamId,

                    TeamOne = ConvertMatchTeamDtoToMatchTeam
                    (
                        matchDto.Teams.ElementAtOrDefault(0), 
                        matchTimelineDto.Events
                    ),

                    TeamTwo = ConvertMatchTeamDtoToMatchTeam
                    (
                        matchDto.Teams.ElementAtOrDefault(1),
                        matchTimelineDto.Events
                    )
                };
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception caught converting MatchDto to Match : " + e.Message);
            }

            return new Match();
        }

        private static MatchTeam ConvertMatchTeamDtoToMatchTeam(MatchTeamDto matchTeamDto, IEnumerable<MatchEventDto> matchEventsDtoList)
        {
            if (matchTeamDto == null || matchEventsDtoList == null) return new MatchTeam();

            try
            {
                return new MatchTeam
                {
                    TeamId = matchTeamDto.TeamId,
                    BaronKills = matchTeamDto.BaronKills,
                    DragonKills = matchTeamDto.DragonKills,
                    InhibitorKills = matchTeamDto.InhibitorKills,
                    RiftHeraldKills = matchTeamDto.RiftHeraldKills,
                    TeamKills = matchTeamDto.Players.Sum(x => x.Kills),
                    TeamDeaths = matchTeamDto.Players.Sum(x => x.Deaths),
                    TeamAssists = matchTeamDto.Players.Sum(x => x.Assists),

                    PlayerOne = ConvertMatchPlayerDtoToMatchPlayer(
                        matchTeamDto.Players.ElementAtOrDefault(0),
                        matchEventsDtoList.Where(x => x.ParticipantId == matchTeamDto.Players.ElementAtOrDefault(0)?.ParticipantId)),

                    PlayerTwo = ConvertMatchPlayerDtoToMatchPlayer(
                        matchTeamDto.Players.ElementAtOrDefault(1),
                        matchEventsDtoList.Where(x => x.ParticipantId == matchTeamDto.Players.ElementAtOrDefault(1)?.ParticipantId)),

                    PlayerThree = ConvertMatchPlayerDtoToMatchPlayer(
                        matchTeamDto.Players.ElementAtOrDefault(2),
                        matchEventsDtoList.Where(x => x.ParticipantId == matchTeamDto.Players.ElementAtOrDefault(2)?.ParticipantId)),

                    PlayerFour = ConvertMatchPlayerDtoToMatchPlayer(
                        matchTeamDto.Players.ElementAtOrDefault(3),
                        matchEventsDtoList.Where(x => x.ParticipantId == matchTeamDto.Players.ElementAtOrDefault(3)?.ParticipantId)),

                    PlayerFive = ConvertMatchPlayerDtoToMatchPlayer(
                        matchTeamDto.Players.ElementAtOrDefault(4),
                        matchEventsDtoList.Where(x => x.ParticipantId == matchTeamDto.Players.ElementAtOrDefault(4)?.ParticipantId))
                };
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception caught when converting MatchTeamDto to MatchTeam : " + e.Message);
            }

            return new MatchTeam();
        }

        public static MatchPlayer ConvertMatchPlayerDtoToMatchPlayer(MatchPlayerDto matchPlayerDto, IEnumerable<MatchEventDto> matchEventDtoList)
        {
            if (matchPlayerDto == null) return new MatchPlayer();
            
            try
            {
                return new MatchPlayer
                {
                    SummonerName = matchPlayerDto.SummonerName,
                    TeamId = matchPlayerDto.TeamId,
                    Champion = ConvertChampionDtoToChampion(Champions.FirstOrDefault(x => x.ChampionId == matchPlayerDto.ChampionId)),
                    ChampionLevel = matchPlayerDto.ChampionLevel,
                    Kills = matchPlayerDto.Kills,
                    Deaths = matchPlayerDto.Deaths,
                    Assists = matchPlayerDto.Assists,
                    CreepScore = matchPlayerDto.TotalMinionsKilled + matchPlayerDto.NeutralMinionsKilled,
                    ItemOne = ConvertItemDtoToItem(Items.FirstOrDefault(x => x.ItemId == matchPlayerDto.Item1Id)),
                    ItemTwo = ConvertItemDtoToItem(Items.FirstOrDefault(x => x.ItemId == matchPlayerDto.Item2Id)),
                    ItemThree = ConvertItemDtoToItem(Items.FirstOrDefault(x => x.ItemId == matchPlayerDto.Item3Id)),
                    ItemFour = ConvertItemDtoToItem(Items.FirstOrDefault(x => x.ItemId == matchPlayerDto.Item4Id)),
                    ItemFive = ConvertItemDtoToItem(Items.FirstOrDefault(x => x.ItemId == matchPlayerDto.Item5Id)),
                    ItemSix = ConvertItemDtoToItem(Items.FirstOrDefault(x => x.ItemId == matchPlayerDto.Item6Id)),
                    Trinket = ConvertItemDtoToItem(Items.FirstOrDefault(x => x.ItemId == matchPlayerDto.TrinketId)),
                    SummonerSpellOne = ConvertSummonerSpellDtoToSummonerSpell(SummonerSpells.FirstOrDefault(x => x.SummonerSpellId == matchPlayerDto.SummonerSpellOneId)),
                    SummonerSpellTwo = ConvertSummonerSpellDtoToSummonerSpell(SummonerSpells.FirstOrDefault(x => x.SummonerSpellId == matchPlayerDto.SummonerSpellTwoId)),
                    PrimaryRuneStyle = ConvertRuneDtoToRuneStyle(Runes.FirstOrDefault(x => x.RunePathId == matchPlayerDto.PrimaryRuneStyleId)),
                    PrimaryRuneSubStyleOne = ConvertRuneDtoToRuneSubStyle(Runes.FirstOrDefault(x => x.RuneId == matchPlayerDto.PrimaryRuneSubStyleOneId)),
                    PrimaryRuneSubStyleTwo = ConvertRuneDtoToRuneSubStyle(Runes.FirstOrDefault(x => x.RuneId == matchPlayerDto.PrimaryRuneSubStyleTwoId)),
                    PrimaryRuneSubStyleThree = ConvertRuneDtoToRuneSubStyle(Runes.FirstOrDefault(x => x.RuneId == matchPlayerDto.PrimaryRuneSubStyleThreeId)),
                    PrimaryRuneSubStyleFour = ConvertRuneDtoToRuneSubStyle(Runes.FirstOrDefault(x => x.RuneId == matchPlayerDto.PrimaryRuneSubStyleFourId)),
                    SecondaryRuneStyle = ConvertRuneDtoToRuneStyle(Runes.FirstOrDefault(x => x.RunePathId == matchPlayerDto.SecondaryRuneStyleId)),
                    SecondaryRuneSubStyleOne = ConvertRuneDtoToRuneSubStyle(Runes.FirstOrDefault(x => x.RuneId == matchPlayerDto.SecondaryRuneSubStyleOneId)),
                    SecondaryRuneSubStyleTwo = ConvertRuneDtoToRuneSubStyle(Runes.FirstOrDefault(x => x.RuneId == matchPlayerDto.SecondaryRuneSubStyleTwoId)),
                    MatchEvents = ConvertTimeEventsDtoToTimelineEvents(matchEventDtoList)
                };
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception caught when converting MatchPlayerDto to MatchPlayer : " + e.Message);
            }
           
            return new MatchPlayer();
        }

        private static IEnumerable<MatchEvent> ConvertTimeEventsDtoToTimelineEvents(
            IEnumerable<MatchEventDto> matchEventDtoList)
        {
            if (matchEventDtoList == null) return new List<MatchEvent>();

            try
            {
                var matchEventList = new List<MatchEvent>();

                foreach (var matchEvent in matchEventDtoList)
                {
                    matchEventList.Add(new MatchEvent
                    {
                        Type = matchEvent.Type,
                        Timestamp = matchEvent.Timestamp,
                        ParticipantId = matchEvent.ParticipantId,
                        ItemId = matchEvent.ItemId,
                        SkillSlot = matchEvent.SkillSlot,
                        LevelUpType = matchEvent.LevelUpType,
                        WardType = matchEvent.WardType,
                        CreatorId = matchEvent.CreatorId,
                        KillerId = matchEvent.KillerId,
                        VictimId = matchEvent.VictimId,
                        AfterId = matchEvent.AfterId,
                        BeforeId = matchEvent.BeforeId,
                        TeamId = matchEvent.TeamId,
                        BuildingType = matchEvent.BuildingType,
                        LaneType = matchEvent.LaneType,
                        TowerType = matchEvent.TowerType,
                        MonsterType = matchEvent.MonsterType,
                        MonsterSubType = matchEvent.MonsterSubType
                    });
                }

                return matchEventList;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception caught when converting list of MatchEventDto to list of MatchEvent : " + e.Message);
            }

            return new List<MatchEvent>();
        }

        public static Champion ConvertChampionDtoToChampion(ChampionDto championDto)
        {
            if (championDto == null) return new Champion();

            try
            {
                return new Champion
                {
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

        public static Item ConvertItemDtoToItem(ItemDto itemDto)
        {
            if(itemDto == null) return new Item { ItemName = "Empty", ItemIconPath = ImageLocationStrings.ItemsImagesPath + "3637" + ImageLocationStrings.PngFileExtension };

            try
            {
                return new Item
                {
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

        public static Rune ConvertRuneDtoToRuneStyle(RuneDto runeDto)
        {
            if (runeDto == null) return new Rune();

            try
            {
                return new Rune
                {
                    RuneName = runeDto.RunePathName,
                    RuneIconPath = ImageLocationStrings.RuneStyleImagesPath + runeDto.RunePathId + ImageLocationStrings.PngFileExtension
                };
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception caught when converting RuneDto Style to Rune Style : " + e.Message);
            }

            return new Rune();
        }

        public static Rune ConvertRuneDtoToRuneSubStyle(RuneDto runeDto)
        {
            if (runeDto == null) return new Rune();

            try
            {
                return new Rune
                {
                    RuneName = runeDto.RuneName,
                    RuneIconPath = ImageLocationStrings.RuneSubStyleImagesPath + runeDto.RuneId + ImageLocationStrings.PngFileExtension
                };
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception caught when converting RuneDto Sub Style to Rune Sub Style : " + e.Message);
            }

            return new Rune();
        }

        public static SummonerSpell ConvertSummonerSpellDtoToSummonerSpell(SummonerSpellDto summonerSpellDto)
        {
            if (summonerSpellDto == null) return new SummonerSpell();

            try
            {
                return new SummonerSpell
                {
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