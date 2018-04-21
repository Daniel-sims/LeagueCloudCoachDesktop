using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueCloudCoachDesktop.Controller.Interfaces;
using LeagueCloudCoachDesktop.HttpRequest;
using LeagueCloudCoachDesktop.Dto.MatchData;

namespace LeagueCloudCoachDesktop.Controller
{
    public class MatchController : IMatchController
    {
        private const string GetMatchupInformationUrl = "/match/Matchup?{0}{1}{2}";
        private const string GetMatchTimelineUrl = "/match/MatchTimeline?gameId={0}";

        private readonly IHttpRequestWrapper _httpRequestWrapper;

        public MatchController()
        {
            _httpRequestWrapper = new HttpRequestWrapper(new TokenBasedRequestWrapper());
        }

        public async Task<IEnumerable<MatchDto>> GetMatchupInformation(int usersChampionId, IEnumerable<int> teamOneChampionIds, IEnumerable<int> teamTwoChampionIds, int matchesToGet)
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

            return await _httpRequestWrapper.SendRequestAsync<List<MatchDto>>(getMatchupInformationUrl.ToString());
        }

        public async Task<MatchTimelineDto> GetMatchTimelineForGameId(long gameId)
        {
            var getMatchTimelineByGameIdUrl = new StringBuilder();

            getMatchTimelineByGameIdUrl.AppendFormat(GetMatchTimelineUrl, gameId);

            return await _httpRequestWrapper.SendRequestAsync<MatchTimelineDto>(getMatchTimelineByGameIdUrl.ToString());
        }
    }
}
