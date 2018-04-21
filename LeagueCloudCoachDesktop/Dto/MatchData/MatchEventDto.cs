using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LeagueCloudCoachDesktop.Dto.MatchData
{
    public class MatchEventDto
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("timestamp")]
        public TimeSpan Timestamp { get; set; }

        [JsonProperty("participantId")]
        public long? ParticipantId { get; set; }

        [JsonProperty("itemId")]
        public long? ItemId { get; set; }

        [JsonProperty("skillSlot")]
        public long? SkillSlot { get; set; }

        [JsonProperty("levelUpType")]
        public string LevelUpType { get; set; }

        [JsonProperty("wardType")]
        public string WardType { get; set; }

        [JsonProperty("creatorId")]
        public long? CreatorId { get; set; }

        [JsonProperty("killerId")]
        public long? KillerId { get; set; }

        [JsonProperty("victimId")]
        public long? VictimId { get; set; }

        [JsonProperty("afterId")]
        public long? AfterId { get; set; }

        [JsonProperty("beforeId")]
        public long? BeforeId { get; set; }

        [JsonProperty("teammId")]
        public long? TeamId { get; set; }

        [JsonProperty("buildingType")]
        public string BuildingType { get; set; }

        [JsonProperty("laneType")]
        public string LaneType { get; set; }

        [JsonProperty("towerType")]
        public string TowerType { get; set; }

        [JsonProperty("monsterType")]
        public string MonsterType { get; set; }

        [JsonProperty("monsterSubType")]
        public string MonsterSubType { get; set; }
    }
}
