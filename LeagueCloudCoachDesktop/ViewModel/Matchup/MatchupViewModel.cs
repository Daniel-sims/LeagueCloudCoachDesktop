using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using LeagueCloudCoachDesktop.Controller;
using LeagueCloudCoachDesktop.Controller.Interfaces;
using LeagueCloudCoachDesktop.Models.StaticData;

namespace LeagueCloudCoachDesktop.ViewModel.Matchup
{
    public class MatchupViewModel : ViewModelBase
    {
        private IStaticDataController StaticDataController { get; } = new StaticDataController();

        public MatchupViewModel()
        {
            GetStaticData();
        }

        private void GetStaticData()
        {
            SetChampions();
        }

        private async void SetChampions()
        {
            ChampionsStaticData = await StaticDataController.GetChampionData();
            SetChampionStrings();
        }

        private void SetChampionStrings()
        {
            foreach (var champ in ChampionsStaticData)
            {
                ChampionStrings.Add(champ.ChampionName);
            }
        }

        private IList<Champion> ChampionsStaticData { get; set; }

        private ObservableCollection<string> _championStrings = new ObservableCollection<string>();
        public ObservableCollection<string> ChampionStrings
        {
            get => _championStrings;
            set => Set(ref _championStrings, value);
        }
    }
}
