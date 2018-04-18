using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LeagueCloudCoachDesktop.Dto.MatchData
{
    public class MatchTeamDto
    {
        [JsonProperty("players")]
        public IEnumerable<MatchPlayerDto> Players { get; set; } = new List<MatchPlayerDto>();

        [JsonProperty("teamId")]
        public int TeamId { get; set; }

        [JsonProperty("baronKills")]
        public int BaronKills { get; set; }

        [JsonProperty("dragonKills")]
        public int DragonKills { get; set; }

        [JsonProperty("riftHeraldKills")]
        public int RiftHeraldKills { get; set; }

        [JsonProperty("inhibitorKills")]
        public int InhibitorKills { get; set; }

    }
}
