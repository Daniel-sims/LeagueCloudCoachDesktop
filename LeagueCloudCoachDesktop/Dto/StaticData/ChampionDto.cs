﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LeagueCloudCoachDesktop.Dto.StaticData
{
    public class ChampionDto
    {
        [JsonProperty("championId")]
        public int ChampionId { get; set; }

        [JsonProperty("championName")]
        public string ChampionName { get; set; }

        [JsonProperty("imageFull")]
        public string ImageFull { get; set; }
    }
}
