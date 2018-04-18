using System;
using GalaSoft.MvvmLight;
using LeagueCloudCoachDesktop.Dto.StaticData;
using LeagueCloudCoachDesktop.Providers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight.Command;
using LeagueCloudCoachDesktop.Controller;
using LeagueCloudCoachDesktop.Controller.Interfaces;
using LeagueCloudCoachDesktop.Dto.MatchData;
using LeagueCloudCoachDesktop.Models.MatchData;

namespace LeagueCloudCoachDesktop.ViewModel.Matchup
{
    public class MatchupViewModel : ViewModelBase
    {
        //TODO This needs to come in through DI/CI for testability
        private IStaticDataProvider StaticDataProvider { get; }= new StaticDataProvider();
        private IMatchController MatchController { get; } = new MatchController();

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

        private IEnumerable<ChampionDto> ChampionsStaticData { get; set; }

        private ObservableCollection<string> _championStrings = new ObservableCollection<string>();
        public ObservableCollection<string> ChampionStrings
        {
            get => _championStrings;
            set => Set(ref _championStrings, value);
        }

        private ObservableCollection<MatchupInformationViewModel> _matchups = new ObservableCollection<MatchupInformationViewModel>();
        public ObservableCollection<MatchupInformationViewModel> Matchups
        {
            get => _matchups;
            set => Set(ref _matchups, value);
        }

        private RelayCommand _resetCommand;
        public RelayCommand ResetCommand
        {
            get
            {
                if (_resetCommand == null)
                    _resetCommand = new RelayCommand(
                        () =>
                        {
                            Matchups = null;
                        });

                return _resetCommand;
            }
        }

        private RelayCommand _onSearchCommand;
        public RelayCommand OnSearchCommand
        {
            get
            {
                if (_onSearchCommand == null)
                    _onSearchCommand = new RelayCommand(
                        async () =>
                        {
                            var returnedMatchups = await Task.Run(() => OnSearch());
                            if (returnedMatchups != null)
                            {
                                Matchups = returnedMatchups;
                            }
                        });

                return _onSearchCommand;
            }
        }

        private async Task<ObservableCollection<MatchupInformationViewModel>> OnSearch()
        {
            if (ChampionsStaticData == null)
            {
                MessageBox.Show("There's no champion static data, something must be wrong with the service.", "Please....", MessageBoxButton.OK, MessageBoxImage.Information);
                return null;
            }

            if (!FriendlyTeamIdsAsList.Any() && string.IsNullOrEmpty(UsersChampion))
            {
                MessageBox.Show("Please enter atleast one friendly champion.", "Please....", MessageBoxButton.OK, MessageBoxImage.Information);
                return null;
            }

            if (Convert.ToInt32(NumberOfMatches) > 50)
            {
                MessageBox.Show("For testing purposes request no more than 5 matches at a time, due to limits with the API key.", "Please....", MessageBoxButton.OK, MessageBoxImage.Information);
                return null;
            }

            SearchButtonEnabled = false;
            var matchupsCache = new ObservableCollection<MatchupInformationViewModel>();

            var returnedMatches = await MatchController.GetMatchupInformation(Convert.ToInt32(ChampionsStaticData.FirstOrDefault(x => x.ChampionName == UsersChampion)?.ChampionId), FriendlyTeamIdsAsList, EnemyTeamIdsAsList, Convert.ToInt32(NumberOfMatches));

            if (returnedMatches?.Count > 0)
            {
                foreach (var matchup in returnedMatches)
                {
                    var newMatchupInformation = new MatchupInformationViewModel()
                    {
                        Match = new Match()
                        {
                            MatchDto = matchup,
                            UsersChampionId = Convert.ToInt32(ChampionsStaticData.FirstOrDefault(x => x.ChampionName == UsersChampion)?.ChampionId)
                        }
                    };

                    matchupsCache.Add(newMatchupInformation);
                }
            }

            SearchButtonEnabled = true;
            return matchupsCache;
        }

        private bool _searchButtonEnabled = true;
        public bool SearchButtonEnabled
        {
            get => _searchButtonEnabled;
            set => Set(ref _searchButtonEnabled, value);
        }

        private string _numberOfMatches = "5";
        public string NumberOfMatches
        {
            get => _numberOfMatches;
            set => Set(ref _numberOfMatches, value);
        }

        private IList<int> _friendlyTeamIds;
        public IEnumerable<int> FriendlyTeamIdsAsList
        {
            get
            {
                _friendlyTeamIds = new List<int>();

                try
                {
                    if (!string.IsNullOrEmpty(FriendlyTwo))
                        _friendlyTeamIds.Add(Convert.ToInt32(ChampionsStaticData.FirstOrDefault(x => x.ChampionName == FriendlyTwo)?.ChampionId));

                    if (!string.IsNullOrEmpty(FriendlyThree))
                        _friendlyTeamIds.Add(Convert.ToInt32(ChampionsStaticData.FirstOrDefault(x => x.ChampionName == FriendlyThree)?.ChampionId));

                    if (!string.IsNullOrEmpty(FriendlyFour))
                        _friendlyTeamIds.Add(Convert.ToInt32(ChampionsStaticData.FirstOrDefault(x => x.ChampionName == FriendlyFour)?.ChampionId));

                    if (!string.IsNullOrEmpty(FriendlyFive))
                        _friendlyTeamIds.Add(Convert.ToInt32(ChampionsStaticData.FirstOrDefault(x => x.ChampionName == FriendlyFive)?.ChampionId));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                
                return _friendlyTeamIds;
            }
        }

        public string UsersChampion { get; set; }
        public string FriendlyTwo { get; set; }
        public string FriendlyThree { get; set; }
        public string FriendlyFour { get; set; }
        public string FriendlyFive { get; set; }

        private IList<int> _enemyTeamIdsAsList;
        public IEnumerable<int> EnemyTeamIdsAsList
        {
            get
            {
                _enemyTeamIdsAsList = new List<int>();

                try
                {
                    if (!string.IsNullOrEmpty(EnemyOne))
                        _enemyTeamIdsAsList.Add(Convert.ToInt32(ChampionsStaticData.FirstOrDefault(x => x.ChampionName == EnemyOne)?.ChampionId));

                    if (!string.IsNullOrEmpty(EnemyTwo))
                        _enemyTeamIdsAsList.Add(Convert.ToInt32(ChampionsStaticData.FirstOrDefault(x => x.ChampionName == EnemyTwo)?.ChampionId));

                    if (!string.IsNullOrEmpty(EnemyThree))
                        _enemyTeamIdsAsList.Add(Convert.ToInt32(ChampionsStaticData.FirstOrDefault(x => x.ChampionName == EnemyThree)?.ChampionId));

                    if (!string.IsNullOrEmpty(EnemyFour))
                        _enemyTeamIdsAsList.Add(Convert.ToInt32(ChampionsStaticData.FirstOrDefault(x => x.ChampionName == EnemyFour)?.ChampionId));

                    if (!string.IsNullOrEmpty(EnemyFive))
                        _enemyTeamIdsAsList.Add(Convert.ToInt32(ChampionsStaticData.FirstOrDefault(x => x.ChampionName == EnemyFive)?.ChampionId));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                return _enemyTeamIdsAsList;
            }
        }
        public string EnemyOne { get; set; }
        public string EnemyTwo { get; set; }
        public string EnemyThree { get; set; }
        public string EnemyFour { get; set; }
        public string EnemyFive { get; set; }
    }
}
