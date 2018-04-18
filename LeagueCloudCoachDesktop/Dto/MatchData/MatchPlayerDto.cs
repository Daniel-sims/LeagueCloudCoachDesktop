using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LeagueCloudCoachDesktop.Dto.MatchData
{
    public class MatchPlayerDto
    {
        // General player data
        [JsonProperty("summonerName")]
        public string SummonerName { get; set; }

        [JsonProperty("profileIconId")]
        public long ProfileIconId { get; set; }

        [JsonProperty("summonerId")]
        public long SummonerId { get; set; }

        [JsonProperty("accountId")]
        public long AccountId { get; set; }

        [JsonProperty("highestAcheivedTierLastSeason")]
        public string HighestAcheivedTierLastSeason { get; set; }

        // Game specific data
        [JsonProperty("teamId")]
        public int TeamId { get; set; }

        [JsonProperty("participantId")]
        public int ParticipantId { get; set; }

        [JsonProperty("kills")]
        public long Kills { get; set; }

        [JsonProperty("deaths")]
        public long Deaths { get; set; }

        [JsonProperty("assists")]
        public long Assists { get; set; }

        [JsonProperty("totalMinionsKilled")]
        public long TotalMinionsKilled { get; set; }

        [JsonProperty("championId")]
        public int ChampionId { get; set; }

        [JsonProperty("championLevel")]
        public long ChampionLevel { get; set; }

        [JsonProperty("trinketId")]
        public long TrinketId { get; set; }

        [JsonProperty("item1Id")]
        public long Item1Id { get; set; }

        [JsonProperty("item2Id")]
        public long Item2Id { get; set; }

        [JsonProperty("item3Id")]
        public long Item3Id { get; set; }

        [JsonProperty("item4Id")]
        public long Item4Id { get; set; }

        [JsonProperty("item5Id")]
        public long Item5Id { get; set; }

        [JsonProperty("item6Id")]
        public long Item6Id { get; set; }

        [JsonProperty("primaryRuneStyleId")]
        public long PrimaryRuneStyleId { get; set; }

        [JsonProperty("primaryRuneSubStyleOneId")]
        public long PrimaryRuneSubStyleOneId { get; set; }

        [JsonProperty("primaryRuneSubStyleTwoId")]
        public long PrimaryRuneSubStyleTwoId { get; set; }

        [JsonProperty("primaryRuneSubStyleThreeId")]
        public long PrimaryRuneSubStyleThreeId { get; set; }

        [JsonProperty("primaryRuneSubStyleFourId")]
        public long PrimaryRuneSubStyleFourId { get; set; }

        [JsonProperty("secondaryRuneStyleId")]
        public long SecondaryRuneStyleId { get; set; }

        [JsonProperty("secondaryRuneSubStyleOneId")]
        public long SecondaryRuneSubStyleOneId { get; set; }

        [JsonProperty("secondaryRuneSubStyleTwoId")]
        public long SecondaryRuneSubStyleTwoId { get; set; }

        [JsonProperty("summonerSpellOneId")]
        public long SummonerSpellOneId { get; set; }

        [JsonProperty("summonerSpellTwoId")]
        public long SummonerSpellTwoId { get; set; }
        
        //Gold
        [JsonProperty("goldEarned")]
        public long GoldEarned { get; set; }

        [JsonProperty("goldSpent")]
        public long GoldSpent { get; set; }

        //Vision
        [JsonProperty("visionScore")]
        public long VisionScore { get; set; }

        [JsonProperty("wardsPlaced")]
        public long WardsPlaced { get; set; }

        [JsonProperty("visionWardsBoughtInGame")]
        public long VisionWardsBoughtInGame { get; set; }

        [JsonProperty("sightWardsBoughtInGame")]
        public long SightWardsBoughtInGame { get; set; }

        //Damage dealt/taken
        [JsonProperty("totalDamageTaken")]
        public long TotalDamageTaken { get; set; }

        [JsonProperty("totalDamageDealt")]
        public long TotalDamageDealt { get; set; }

        [JsonProperty("totalDamageDealtToChampions")]
        public long TotalDamageDealtToChampions { get; set; }

        [JsonProperty("trueDamageTaken")]
        public long TrueDamageTaken { get; set; }

        [JsonProperty("trueDamageDealt")]
        public long TrueDamageDealt { get; set; }

        [JsonProperty("TrueDamageDealtToChampions")]
        public long TrueDamageDealtToChampions { get; set; }

        [JsonProperty("magicDamageTaken")]
        public long MagicDamageTaken { get; set; }

        [JsonProperty("magicDamageDealt")]
        public long MagicDamageDealt { get; set; }

        [JsonProperty("magicDamageDealtToChampions")]
        public long MagicDamageDealtToChampions { get; set; }

        [JsonProperty("physicalDamageTaken")]
        public long PhysicalDamageTaken { get; set; }

        [JsonProperty("physicalDamageDealt")]
        public long PhysicalDamageDealt { get; set; }

        [JsonProperty("physicalDamageDealtToChampions")]
        public long PhysicalDamageDealtToChampions { get; set; }

        [JsonProperty("largestCriticalStrike")]
        public long LargestCriticalStrike { get; set; }

        // Objectives
        [JsonProperty("firstTowerAssist")]
        public bool FirstTowerAssist { get; set; }

        [JsonProperty("firstTowerKill")]
        public bool FirstTowerKill { get; set; }

        [JsonProperty("turretKills")]
        public long TurretKills { get; set; }

        [JsonProperty("damageDealtToTurrets")]
        public long DamageDealtToTurrets { get; set; }

        [JsonProperty("firstInhibitorAssist")]
        public bool FirstInhibitorAssist { get; set; }

        [JsonProperty("firstInhibitorKill")]
        public bool FirstInhibitorKill { get; set; }

        [JsonProperty("inhibitorKills")]
        public long InhibitorKills { get; set; }

        [JsonProperty("damageDealtToObjectives")]
        public long DamageDealtToObjectives { get; set; }

        [JsonProperty("objectivePlayerScore")]
        public long ObjectivePlayerScore { get; set; }

        //Kills
        [JsonProperty("firstBloodAssist")]
        public bool FirstBloodAssist { get; set; }

        [JsonProperty("firstBloodKill")]
        public bool FirstBloodKill { get; set; }

        [JsonProperty("largestMultiKill")]
        public long LargestMultiKill { get; set; }

        [JsonProperty("largestKillingSpree")]
        public long LargestKillingSpree { get; set; }

        [JsonProperty("pentaKills")]
        public long PentaKills { get; set; }

        [JsonProperty("quadraKills")]
        public long QuadraKills { get; set; }

        [JsonProperty("killingSprees")]
        public long KillingSprees { get; set; }

        [JsonProperty("doubleKills")]
        public long DoubleKills { get; set; }

        //Farming
        [JsonProperty("neutralMinionsKilled")]
        public long NeutralMinionsKilled { get; set; }

        [JsonProperty("neutralMinionsKilledEnemyJungle")]
        public long NeutralMinionsKilledEnemyJungle { get; set; }

        [JsonProperty("neutralMinionsKilledTeamJungle")]
        public long NeutralMinionsKilledTeamJungle { get; set; }

        //Nusc
        [JsonProperty("timeCCingOthers")]
        public long TimeCCingOthers { get; set; }

        [JsonProperty("totalTimeCrowdControlDealt")]
        public long TotalTimeCrowdControlDealt { get; set; }

        [JsonProperty("totalHeal")]
        public long TotalHeal { get; set; }

        [JsonProperty("totalUnitsHealed")]
        public long TotalUnitsHealed { get; set; }

        [JsonProperty("totalScoreRank")]
        public long TotalScoreRank { get; set; }

    }
}
