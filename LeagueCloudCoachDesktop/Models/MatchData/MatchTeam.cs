using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LeagueCloudCoachDesktop.Models.MatchData
{
    public class MatchTeam
    {
        [JsonProperty("players")]
        public IEnumerable<MatchPlayer> Players { get; set; } = new List<MatchPlayer>();

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
