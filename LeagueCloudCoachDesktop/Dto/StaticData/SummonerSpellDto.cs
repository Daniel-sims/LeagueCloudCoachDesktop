using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LeagueCloudCoachDesktop.Dto.StaticData
{
    public class SummonerSpellDto
    {
        [JsonProperty("summonerSpellId")]
        public int SummonerSpellId { get; set; }

        [JsonProperty("summonerSpellName")]
        public string SummonerSpellName { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("imageFull")]
        public string ImageFull { get; set; }
    }
}
