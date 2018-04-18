using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueCloudCoachDesktop.Dto.MatchData;

namespace LeagueCloudCoachDesktop.Controller.Interfaces
{
    public interface IMatchController
    {
        Task<List<MatchDto>> GetMatchupInformation(int usersChampionId, IEnumerable<int> teamOneChampionIds, IEnumerable<int> teamOneChampionIdsUrl, int matchesToGet = 5);
    }
}