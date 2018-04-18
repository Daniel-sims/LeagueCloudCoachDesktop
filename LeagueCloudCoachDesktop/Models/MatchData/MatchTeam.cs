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
        // Raw data
        public MatchTeamDto MatchTeamDto { get; set; }

        public IEnumerable<MatchPlayer> MatchPlayer { get; set; }
       
        
    }
}
