using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LeagueCloudCoachDesktop.Dto.MatchData
{
    public class MatchTimelineDto
    {
        [JsonProperty("gameId")]
        public long GameId { get; set; }

        [JsonProperty("events")]
        public IEnumerable<MatchEventDto> Events { get; set; } = new List<MatchEventDto>();
    }
}
