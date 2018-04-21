using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using LeagueCloudCoachDesktop.Models.MatchData;

namespace LeagueCloudCoachDesktop.ViewModel.Matchup.Popup
{
    public class DetailedMatchupPlayerViewModel : ViewModelBase
    {
        public MatchPlayer Player { get; set; }
    }
}
