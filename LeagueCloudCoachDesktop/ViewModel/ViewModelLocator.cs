using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using LeagueCloudCoachDesktop.ViewModel.Application;
using LeagueCloudCoachDesktop.ViewModel.Home;
using LeagueCloudCoachDesktop.ViewModel.Login;
using LeagueCloudCoachDesktop.ViewModel.Matchup;

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
        }

        public MainViewModel Main { get { return ServiceLocator.Current.GetInstance<MainViewModel>(); } }

        public LoginViewModel Login { get { return ServiceLocator.Current.GetInstance<LoginViewModel>(); } }
        
        public MainApplicationViewModel MainApplication { get { return ServiceLocator.Current.GetInstance<MainApplicationViewModel>(); } }

        public HomeViewModel Home { get { return ServiceLocator.Current.GetInstance<HomeViewModel>(); } }

        public MatchupViewModel Matchup { get { return ServiceLocator.Current.GetInstance<MatchupViewModel>(); } }

        public static void Cleanup() { }
    }
}