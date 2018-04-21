using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using LeagueCloudCoachDesktop.Providers;
using LeagueCloudCoachDesktop.View.Matchup.Popup;
using LeagueCloudCoachDesktop.ViewModel.Application;
using LeagueCloudCoachDesktop.ViewModel.Home;
using LeagueCloudCoachDesktop.ViewModel.Login;
using LeagueCloudCoachDesktop.ViewModel.Matchup;
using LeagueCloudCoachDesktop.ViewModel.Matchup.Popup;

namespace LeagueCloudCoachDesktop.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            //Window
            SimpleIoc.Default.Register<MainViewModel>();

            SimpleIoc.Default.Register<LoginViewModel>();

            // Main application parent
            SimpleIoc.Default.Register<MainApplicationViewModel>();

            // Tabs 
            SimpleIoc.Default.Register<HomeViewModel>();
            SimpleIoc.Default.Register<MatchupViewModel>();

            //Matchup
            SimpleIoc.Default.Register<MatchupInformationViewModel>();
            SimpleIoc.Default.Register<MatchupPlayerViewModel>();
            SimpleIoc.Default.Register<DetailedMatchupPlayerViewModel>();
        }

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>(); 

        public LoginViewModel Login => ServiceLocator.Current.GetInstance<LoginViewModel>(); 
        
        public MainApplicationViewModel MainApplication => ServiceLocator.Current.GetInstance<MainApplicationViewModel>(); 

        public HomeViewModel Home => ServiceLocator.Current.GetInstance<HomeViewModel>(); 

        public MatchupViewModel Matchup => ServiceLocator.Current.GetInstance<MatchupViewModel>(); 

        public MatchupInformationViewModel MatchupInformation => ServiceLocator.Current.GetInstance<MatchupInformationViewModel>(); 

        public MatchupPlayerViewModel MatchupPlayer => ServiceLocator.Current.GetInstance<MatchupPlayerViewModel>();

        public DetailedMatchupPlayerView DetailedMatchupPlayer => ServiceLocator.Current.GetInstance<DetailedMatchupPlayerView>();

        public static void Cleanup() { }
    }
}