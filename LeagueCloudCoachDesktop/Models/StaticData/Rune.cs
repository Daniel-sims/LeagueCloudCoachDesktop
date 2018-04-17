using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LeagueCloudCoachDesktop.Models.StaticData
{
    public class Rune
    {
        // Rune information
        [JsonProperty("runeId")]
        public int RuneId { get; set; }

        [JsonProperty("runeName")]
        public string RuneName { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("longDesc")]
        public string LongDesc { get; set; }

        [JsonProperty("shortDesc")]
        public string ShortDesc { get; set; }

        // Parent Rune (I.E top of the tree)
        [JsonProperty("runePathId")]
        public int RunePathId { get; set; }

        [JsonProperty("runePathName")]
        public string RunePathName { get; set; }
    }
}
