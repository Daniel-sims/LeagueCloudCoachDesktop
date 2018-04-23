using LeagueCloudCoachDesktop.Constants;
using LeagueCloudCoachDesktop.Dto.MatchData;
using LeagueCloudCoachDesktop.Dto.StaticData;
using LeagueCloudCoachDesktop.Models.MatchData;
using LeagueCloudCoachDesktop.Models.StaticData;
using LeagueCloudCoachDesktop.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using LeagueCloudCoachDesktop.Utils;

namespace LeagueCloudCoachDesktop.DtoToModelConverter
{
    public static class MatchDtoConverter
    {
        private static readonly IEnumerable<Item> Items = StaticDataProvider.GetItemsStatic().Result;
        private static readonly IEnumerable<Rune> Runes = StaticDataProvider.GetRunesStatic().Result;
        private static readonly IEnumerable<SummonerSpell> SummonerSpells = StaticDataProvider.GetSummonerSpellsStatic().Result;
        private static readonly IEnumerable<Champion> Champions = StaticDataProvider.GetChampionsStatic().Result;

        public static Match ConverMatchDtoToMatch(MatchDto matchDto, MatchTimelineDto matchTimelineDto)
        {
            if(matchDto == null || matchTimelineDto == null) return new Match();

            try
            {
                return new Match
                {
                    GameDuration = TimeSpanUtils.ConvertTimespanToFriendly(Convert.ToInt32(matchDto.GameDuration.TotalSeconds)),
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
            if (matchPlayerDto == null || matchEventDtoList == null) return new MatchPlayer();
            
            try
            {
                return new MatchPlayer
                {
                    SummonerName = matchPlayerDto.SummonerName,
                    TeamId = matchPlayerDto.TeamId,
                    Champion = Champions.FirstOrDefault(x => x.ChampionId == matchPlayerDto.ChampionId),
                    ChampionLevel = matchPlayerDto.ChampionLevel,
                    Kills = matchPlayerDto.Kills,
                    Deaths = matchPlayerDto.Deaths,
                    Assists = matchPlayerDto.Assists,
                    CreepScore = matchPlayerDto.TotalMinionsKilled + matchPlayerDto.NeutralMinionsKilled,
                    ItemOne = GetItemForId(matchPlayerDto.Item1Id),
                    ItemTwo = GetItemForId(matchPlayerDto.Item2Id),
                    ItemThree = GetItemForId(matchPlayerDto.Item3Id),
                    ItemFour = GetItemForId(matchPlayerDto.Item4Id),
                    ItemFive = GetItemForId(matchPlayerDto.Item5Id),
                    ItemSix = GetItemForId(matchPlayerDto.Item6Id),
                    Trinket = GetItemForId(matchPlayerDto.TrinketId),
                    SummonerSpellOne = SummonerSpells.FirstOrDefault(x => x.SummonerSpellId == matchPlayerDto.SummonerSpellOneId),
                    SummonerSpellTwo = SummonerSpells.FirstOrDefault(x => x.SummonerSpellId == matchPlayerDto.SummonerSpellTwoId),
                    PrimaryRuneStyle = Runes.FirstOrDefault(x => x.RunePathId == matchPlayerDto.PrimaryRuneStyleId),
                    PrimaryRuneSubStyleOne = Runes.FirstOrDefault(x => x.RuneId == matchPlayerDto.PrimaryRuneSubStyleOneId),
                    PrimaryRuneSubStyleTwo = Runes.FirstOrDefault(x => x.RuneId == matchPlayerDto.PrimaryRuneSubStyleTwoId),
                    PrimaryRuneSubStyleThree = Runes.FirstOrDefault(x => x.RuneId == matchPlayerDto.PrimaryRuneSubStyleThreeId),
                    PrimaryRuneSubStyleFour = Runes.FirstOrDefault(x => x.RuneId == matchPlayerDto.PrimaryRuneSubStyleFourId),
                    SecondaryRuneStyle = Runes.FirstOrDefault(x => x.RunePathId == matchPlayerDto.SecondaryRuneStyleId),
                    SecondaryRuneSubStyleOne = Runes.FirstOrDefault(x => x.RuneId == matchPlayerDto.SecondaryRuneSubStyleOneId),
                    SecondaryRuneSubStyleTwo = Runes.FirstOrDefault(x => x.RuneId == matchPlayerDto.SecondaryRuneSubStyleTwoId),
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

                foreach (var matchEventDto in matchEventDtoList)
                {
                    matchEventList.Add(new MatchEvent
                    {
                        Type = matchEventDto.Type,
                        TimeStamp = matchEventDto.Timestamp,
                        UserFriendlyTimestamp = TimeSpanUtils.ConvertTimespanToFriendly(Convert.ToInt32(matchEventDto.Timestamp.TotalSeconds)),
                        ParticipantId = matchEventDto.ParticipantId,
                        ItemId = matchEventDto.ItemId,
                        SkillSlot = matchEventDto.SkillSlot,
                        LevelUpType = matchEventDto.LevelUpType,
                        WardType = matchEventDto.WardType,
                        CreatorId = matchEventDto.CreatorId,
                        KillerId = matchEventDto.KillerId,
                        VictimId = matchEventDto.VictimId,
                        AfterId = matchEventDto.AfterId,
                        BeforeId = matchEventDto.BeforeId,
                        TeamId = matchEventDto.TeamId,
                        BuildingType = matchEventDto.BuildingType,
                        LaneType = matchEventDto.LaneType,
                        TowerType = matchEventDto.TowerType,
                        MonsterType = matchEventDto.MonsterType,
                        MonsterSubType = matchEventDto.MonsterSubType
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

        private static Item GetItemForId(long itemId)
        {
            return Items.FirstOrDefault(x => x.ItemId == itemId) ?? new Item()
            {
                ItemId = 3637,
                ItemName = "Empty",
                ItemIconPath = ImageLocationStrings.ItemsImagesPath + "3637" + ImageLocationStrings.PngFileExtension

            };
        }
    }
}
