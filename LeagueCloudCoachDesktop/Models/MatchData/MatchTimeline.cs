using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueCloudCoachDesktop.Models.MatchData
{
    public class MatchTimeline
    {
        public long GameId { get; set; }

        public IEnumerable<MatchEvent> Events { get; set; } = new List<MatchEvent>();
    }
}
