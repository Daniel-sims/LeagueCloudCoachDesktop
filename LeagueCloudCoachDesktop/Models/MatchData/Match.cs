using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LeagueCloudCoachDesktop.Models.MatchData
{
    public class Match
    {
        [JsonProperty("gameId")]
        public long GameId { get; set; }

        [JsonProperty("gameDate")]
        public DateTime GameDate { get; set; }

        [JsonProperty("gameDuration")]
        public TimeSpan GameDuration { get; set; }

        [JsonProperty("gamePatch")]
        public string GamePatch { get; set; }

        [JsonProperty("winningTeamId")]
        public int? WinningTeamId { get; set; }

        [JsonProperty("teams")]
        public IEnumerable<MatchTeam> Teams { get; set; } = new List<MatchTeam>();
    }
}
