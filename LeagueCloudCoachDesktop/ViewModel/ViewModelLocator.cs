using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
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
        }

        public MainViewModel Main { get { return ServiceLocator.Current.GetInstance<MainViewModel>(); } }

        public LoginViewModel Login { get { return ServiceLocator.Current.GetInstance<LoginViewModel>(); } }

        public static void Cleanup() { }
    }
}