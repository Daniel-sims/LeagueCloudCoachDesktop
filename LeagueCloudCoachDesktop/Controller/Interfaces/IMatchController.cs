using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueCloudCoachDesktop.Models.MatchData;

namespace LeagueCloudCoachDesktop.Controller.Interfaces
{
    public interface IMatchController
    {
        Task<List<Match>> GetMatchupInformation(int usersChampionId, IEnumerable<int> teamOneChampionIds, IEnumerable<int> teamOneChampionIdsUrl, int matchesToGet = 5);
    }
}