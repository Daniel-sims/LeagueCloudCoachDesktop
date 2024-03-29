﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LeagueCloudCoachDesktop.Controller;
using LeagueCloudCoachDesktop.Controller.Interfaces;
using LeagueCloudCoachDesktop.Dto.StaticData;
using LeagueCloudCoachDesktop.DtoToModelConverter;
using LeagueCloudCoachDesktop.Providers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using LeagueCloudCoachDesktop.Dto.MatchData;
using LeagueCloudCoachDesktop.Models.MatchData;
using LeagueCloudCoachDesktop.Models.StaticData;

namespace LeagueCloudCoachDesktop.ViewModel.Matchup
{
    public class MatchupViewModel : ViewModelBase
    {
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

        private IEnumerable<Champion> ChampionsStaticData { get; set; }

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
        public RelayCommand ResetCommand => _resetCommand ?? (_resetCommand = new RelayCommand(() => { Matchups = null; }));

        private RelayCommand _onSearchCommand;
        public RelayCommand OnSearchCommand
        {
            get
            {
                return _onSearchCommand ?? (_onSearchCommand = new RelayCommand(
                           async () =>
                           {
                               var returnedMatchups = await Task.Run(OnSearch);
                               if (returnedMatchups != null)
                               {
                                   Matchups = returnedMatchups;
                               }
                           }));
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

            if (returnedMatches?.Count() > 0)
            {
                foreach (var matchup in returnedMatches)
                {
                    var matchTimeline = await MatchController.GetMatchTimelineForGameId(matchup.GameId);

                    if (matchTimeline != null)
                    {
                        var newMatchupInformation = new MatchupInformationViewModel
                        {
                            Match = MatchDtoConverter.ConverMatchDtoToMatch(matchup, matchTimeline),
                            UsersPlayer = await GetPlayersChampionFromMatchDto(matchup, matchTimeline, Convert.ToInt32(ChampionsStaticData.FirstOrDefault(x => x.ChampionName == UsersChampion)?.ChampionId))
                        };

                        matchupsCache.Add(newMatchupInformation);
                    }
                }
            }

            SearchButtonEnabled = true;
            return matchupsCache;
        }

        private async Task<MatchPlayer> GetPlayersChampionFromMatchDto(MatchDto matchup, MatchTimelineDto matchTimlineDto,  int usersChampionId)
        {
            if (matchup == null) return new MatchPlayer();

            var matchPlayerDto = matchup
                .Teams?
                .FirstOrDefault(x => x.Players
                    .Any(y => y.ChampionId == usersChampionId))
                ?.Players?.FirstOrDefault(x => x.ChampionId == usersChampionId);
            
            return MatchDtoConverter.ConvertMatchPlayerDtoToMatchPlayer(
                matchPlayerDto,
                matchTimlineDto.Events.Where(x => x.ParticipantId == matchPlayerDto?.ParticipantId));
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
