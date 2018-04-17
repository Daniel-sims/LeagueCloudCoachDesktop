using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LeagueCloudCoachDesktop.Models.StaticData
{
    public class Item
    {
        [JsonProperty("itemId")]
        public int ItemId { get; set; }

        [JsonProperty("itemName")]
        public string ItemName { get; set; }

        [JsonProperty("imageFull")]
        public string ImageFull { get; set; }

        [JsonProperty("plainText")]
        public string PlainText { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("sanitizedDescription")]
        public string SanitizedDescription { get; set; }
    }
}
