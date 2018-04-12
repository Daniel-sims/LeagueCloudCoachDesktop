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
            SimpleIoc.Default.Register<LoginSignUpViewModel>();
            SimpleIoc.Default.Register<LoginSignInViewModel>();
        }

        public MainViewModel Main { get { return ServiceLocator.Current.GetInstance<MainViewModel>(); } }

        public LoginViewModel Login { get { return ServiceLocator.Current.GetInstance<LoginViewModel>(); } }

        public LoginSignUpViewModel LoginSignUp { get { return ServiceLocator.Current.GetInstance<LoginSignUpViewModel>(); } }

        public LoginSignInViewModel LoginSignIn { get { return ServiceLocator.Current.GetInstance<LoginSignInViewModel>(); } }

        public static void Cleanup() { }
    }
}