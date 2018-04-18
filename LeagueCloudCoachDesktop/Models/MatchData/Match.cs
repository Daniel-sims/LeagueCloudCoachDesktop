using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueCloudCoachDesktop.Dto.MatchData;
using LeagueCloudCoachDesktop.Dto.StaticData;
using LeagueCloudCoachDesktop.Providers;

namespace LeagueCloudCoachDesktop.Models.MatchData
{
    /* Matchup object to bind to kind of like a business object I suppose?*/
    public class Match
    {
        public TimeSpan GameDuration { get; set; }

        public DateTime GameDate { get; set; }

        public string GamePatch { get; set; }

        public int? WinningTeamId { get; set; }

        public MatchTeam TeamOne { get; set; }

        public MatchTeam TeamTwo { get; set; }
    }
}
