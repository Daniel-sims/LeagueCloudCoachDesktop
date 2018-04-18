using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueCloudCoachDesktop.Dto.MatchData;

namespace LeagueCloudCoachDesktop.Models.MatchData
{
    public class MatchTeam
    {
        public int TeamId { get; set; }

        public int BaronKills { get; set; }

        public int DragonKills { get; set; }
        
        public int InhibitorKills { get; set; }

        public int RiftHeraldKills { get; set; }

        public long TeamKills { get; set; }

        public long TeamAssists { get; set; }

        public long TeamDeaths { get; set; }

        public MatchPlayer PlayerOne { get; set; }

        public MatchPlayer PlayerTwo { get; set; }

        public MatchPlayer PlayerThree { get; set; }

        public MatchPlayer PlayerFour { get; set; }

        public MatchPlayer PlayerFive { get; set; }
    }
}
