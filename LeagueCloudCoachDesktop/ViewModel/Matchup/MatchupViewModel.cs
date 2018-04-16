using GalaSoft.MvvmLight;
using LeagueCloudCoachDesktop.Models.StaticData;
using LeagueCloudCoachDesktop.Providers;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace LeagueCloudCoachDesktop.ViewModel.Matchup
{
    public class MatchupViewModel : ViewModelBase
    {
        //TODO This needs to come in through DI/CI for testability
        private IStaticDataProvider StaticDataProvider { get; }= new StaticDataProvider();

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
            ChampionsStaticData = await StaticDataProvider.GetChampionsStatic();
            SetChampionStrings();
        }

        private void SetChampionStrings()
        {
            foreach (var champ in ChampionsStaticData)
            {
                ChampionStrings.Add(champ.ChampionName);
            }
        }

        private IEnumerable<Champion> ChampionsStaticData { get; set; }

        private ObservableCollection<string> _championStrings = new ObservableCollection<string>();
        public ObservableCollection<string> ChampionStrings
        {
            get => _championStrings;
            set => Set(ref _championStrings, value);
        }
    }
}
