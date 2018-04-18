using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueCloudCoachDesktop.Dto.MatchData;
using LeagueCloudCoachDesktop.Dto.StaticData;
using LeagueCloudCoachDesktop.Models.MatchData;
using LeagueCloudCoachDesktop.Providers;

namespace LeagueCloudCoachDesktop.ViewModel.Matchup
{
    public class MatchupInformationViewModel
    {
        public Match Match { get; set; }

        public MatchPlayer UsersPlayer { get; set; }

        public MatchTeam UsersTeam => Match.TeamOne.TeamId == UsersPlayer.TeamId ? Match.TeamOne : Match.TeamTwo;

        public MatchTeam EnemyTeam => Match.TeamOne.TeamId != UsersPlayer.TeamId ? Match.TeamOne : Match.TeamTwo;

        public bool UsersTeamWin => Match.WinningTeamId == UsersPlayer.TeamId;
        
    }
}
