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

        public MatchupPlayerViewModel FriendlyPlayerOne => new MatchupPlayerViewModel {Player = UsersTeam.PlayerOne};
        public MatchupPlayerViewModel FriendlyPlayerTwo => new MatchupPlayerViewModel { Player = UsersTeam.PlayerTwo };
        public MatchupPlayerViewModel FriendlyPlayerThree => new MatchupPlayerViewModel { Player = UsersTeam.PlayerThree };
        public MatchupPlayerViewModel FriendlyPlayerFour => new MatchupPlayerViewModel { Player = UsersTeam.PlayerFour };
        public MatchupPlayerViewModel FriendlyPlayerFive => new MatchupPlayerViewModel { Player = UsersTeam.PlayerFive };

        public MatchupPlayerViewModel EnemyPlayerOne => new MatchupPlayerViewModel { Player = EnemyTeam.PlayerOne };
        public MatchupPlayerViewModel EnemyPlayerTwo => new MatchupPlayerViewModel { Player = EnemyTeam.PlayerTwo };
        public MatchupPlayerViewModel EnemyPlayerThree => new MatchupPlayerViewModel { Player = EnemyTeam.PlayerThree };
        public MatchupPlayerViewModel EnemyPlayerFour => new MatchupPlayerViewModel { Player = EnemyTeam.PlayerFour };
        public MatchupPlayerViewModel EnemyPlayerFive => new MatchupPlayerViewModel { Player = EnemyTeam.PlayerFive };

    }
}
