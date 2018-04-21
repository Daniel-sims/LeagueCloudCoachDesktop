using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LeagueCloudCoachDesktop.Models.MatchData;
using LeagueCloudCoachDesktop.View.Matchup.Popup;
using LeagueCloudCoachDesktop.ViewModel.Matchup.Popup;
using MaterialDesignThemes.Wpf;

namespace LeagueCloudCoachDesktop.ViewModel.Matchup
{
    public class MatchupPlayerViewModel : ViewModelBase
    {
        public MatchPlayer Player { get; set; }

        private ICommand _showDetailedMatchInfoforPlayerCommand;
        public ICommand ShowDetailedMatchInfoforPlayerCommand
        {
            get
            {
                return _showDetailedMatchInfoforPlayerCommand ?? (_showDetailedMatchInfoforPlayerCommand =
                           new RelayCommand(async () => await ShowDetailedMatchInfoforPlayer()));
            }
        }

        private async Task ShowDetailedMatchInfoforPlayer()
        {
            await DialogHost.Show(new DetailedMatchupPlayerViewModel
            {
                Player = Player
            });
        }
    }
}
