using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using LeagueCloudCoachDesktop.ViewModel.Application;
using LeagueCloudCoachDesktop.ViewModel.Login;

namespace LeagueCloudCoachDesktop.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<MainViewModel>();

            SimpleIoc.Default.Register<LoginViewModel>();
            SimpleIoc.Default.Register<MainApplicationViewModel>();
        }

        public MainViewModel Main { get { return ServiceLocator.Current.GetInstance<MainViewModel>(); } }

        public LoginViewModel Login { get { return ServiceLocator.Current.GetInstance<LoginViewModel>(); } }
        
        public MainApplicationViewModel MainApplication { get { return ServiceLocator.Current.GetInstance<MainApplicationViewModel>(); } }

        public static void Cleanup() { }
    }
}