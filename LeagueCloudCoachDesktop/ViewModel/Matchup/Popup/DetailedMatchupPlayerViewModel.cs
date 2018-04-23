using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using LeagueCloudCoachDesktop.Constants;
using LeagueCloudCoachDesktop.Models.MatchData;

namespace LeagueCloudCoachDesktop.ViewModel.Matchup.Popup
{
    public class DetailedMatchupPlayerViewModel : ViewModelBase
    {
        public MatchPlayer Player { get; set; }

        public IEnumerable<MatchEvent> ItemEvents
        {
            get { return Player.MatchEvents.Where(x => x.Type == UserEventType.ItemDestroyed || 
                                                       x.Type == UserEventType.ItemPurchased || 
                                                       x.Type == UserEventType.ItemUndo).OrderBy(x => x.Timestamp); }
        }
    }
}
