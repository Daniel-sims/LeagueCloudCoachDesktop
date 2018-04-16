using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueCloudCoachDesktop.Models.MatchData;

namespace LeagueCloudCoachDesktop.ViewModel.Matchup
{
    public class MatchupInformationViewModel
    {
        public MatchupInformationViewModel() { }

        public int UsersChampionId { get; set; }

        public bool UsersTeamWin => Matchup?.WinningTeamId == UsersTeam?.TeamId;

        public Match Matchup { get; set; }

        public MatchTeam UsersTeam { get { return Matchup?.Teams?.FirstOrDefault(x => x.Players.Any(y => y?.ChampionId == UsersChampionId)); } }

        public MatchTeam EnemyTeam { get { return Matchup?.Teams?.FirstOrDefault(x => x.Players.All(y => y?.ChampionId != UsersChampionId)); } }
    }
}
