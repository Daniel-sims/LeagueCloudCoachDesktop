using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueCloudCoachDesktop.Constants;
using LeagueCloudCoachDesktop.Dto.MatchData;
using LeagueCloudCoachDesktop.Dto.StaticData;
using LeagueCloudCoachDesktop.Models.StaticData;
using LeagueCloudCoachDesktop.Providers;

namespace LeagueCloudCoachDesktop.Models.MatchData
{
    public class MatchPlayer
    {

        public string SummonerName { get; set; }

        public int TeamId { get; set; }

        public Champion Champion { get; set; }

        public long ChampionLevel { get; set; }

        public long Kills { get; set; }

        public long Deaths { get; set; }

        public long Assists { get; set; }

        public long CreepScore { get; set; }

        public Item ItemOne { get; set; }

        public Item ItemTwo { get; set; }

        public Item ItemThree { get; set; }

        public Item ItemFour { get; set; }

        public Item ItemFive { get; set; }

        public Item ItemSix { get; set; }

        public Item Trinket { get; set; }

        public SummonerSpell SummonerSpellOne { get; set; }

        public SummonerSpell SummonerSpellTwo { get; set; }

        public Rune PrimaryRuneStyle { get; set; }

        public Rune PrimaryRuneSubStyleOne { get; set; }

        public Rune PrimaryRuneSubStyleTwo { get; set; }

        public Rune PrimaryRuneSubStyleThree { get; set; }

        public Rune PrimaryRuneSubStyleFour { get; set; }

        public Rune SecondaryRuneStyle { get; set; }

        public Rune SecondaryRuneSubStyleOne { get; set; }

        public Rune SecondaryRuneSubStyleTwo { get; set; }

        public IEnumerable<MatchEvent> MatchEvents { get; set; }
    }
}
