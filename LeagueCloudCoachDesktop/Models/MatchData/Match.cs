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
        public int UsersChampionId { get; set; }
        
        // Raw match data
        public MatchDto MatchDto { get; set; }

        // Data to bind to
        public bool UsersTeamWin => MatchDto?.WinningTeamId == UsersTeam?.MatchTeamDto.TeamId;

        public MatchTeam UsersTeam => new MatchTeam() { MatchTeamDto = MatchDto.Teams.FirstOrDefault(x => x.Players.All(y => y?.ChampionId == UsersChampionId)) };

        public MatchTeam EnemyTeam => new MatchTeam() { MatchTeamDto = MatchDto.Teams.FirstOrDefault(x => x.Players.All(y => y?.ChampionId != UsersChampionId)) };

        public MatchPlayer User => new MatchPlayer() { MatchPlayerDto = UsersTeam.MatchTeamDto.Players.First(x => x.ChampionId == UsersChampionId) };
    }
}
