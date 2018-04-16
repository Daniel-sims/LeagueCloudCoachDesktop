using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueCloudCoachDesktop.Controller.Interfaces;
using LeagueCloudCoachDesktop.HttpRequest;
using LeagueCloudCoachDesktop.Models.MatchData;

namespace LeagueCloudCoachDesktop.Controller
{
    public class MatchController : IMatchController
    {
        private const string GetMatchupInformationUrl = "/match/Matchup?{0}{1}{2}";

        private readonly IHttpRequestWrapper _httpRequestWrapper;

        public MatchController()
        {
            _httpRequestWrapper = new HttpRequestWrapper(new TokenBasedRequestWrapper());
        }

        public async Task<List<Match>> GetMatchupInformation(int usersChampionId, IEnumerable<int> teamOneChampionIds, IEnumerable<int> teamTwoChampionIds, int matchesToGet)
        {
            var getMatchupInformationUrl = new StringBuilder();

            var teamOneChampionIdsUrl = "teamOneChampionIds=" + usersChampionId;
            if (teamOneChampionIds.Any())
            {
                foreach (var championId in teamOneChampionIds)
                {
                    teamOneChampionIdsUrl += "&teamOneChampionIds=" + championId;
                }
            }

            var teamTwoChampionIdsUrls = "";
            if (teamTwoChampionIds.Any())
            {
                foreach (var championId in teamTwoChampionIds)
                {
                    teamTwoChampionIdsUrls += "&teamTwoChampionIds=" + championId;
                }
            }

            getMatchupInformationUrl.AppendFormat(GetMatchupInformationUrl, teamOneChampionIdsUrl, teamTwoChampionIdsUrls, "&maxMatchLimit=" + matchesToGet);

            return await _httpRequestWrapper.SendRequestAsync<List<Match>>(getMatchupInformationUrl.ToString());
        }
    }
}
