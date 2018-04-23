using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueCloudCoachDesktop.Models.StaticData
{
    public class Rune
    {
        public int RuneId { get; set; }

        public string RuneName { get; set; }

        public string RuneIconPath { get; set; }

        public int RunePathId { get; set; }

        public string RunePathName { get; set; }

        public string RunePathIconPath { get; set; }

        public string ShortDesc { get; set; }

        public string LongDesc { get; set; }

        public string Key { get; set; }
    }
}
