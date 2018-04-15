using GalaSoft.MvvmLight;
using LeagueCloudCoachDesktop.Constants.MessageTypes;
using LeagueCloudCoachDesktop.ViewModel.Login;

namespace LeagueCloudCoachDesktop.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            CurrentPage = new LoginViewModel();

            MessengerInstance.Register<ChangeMainPageMessage>(this, (m) => { CurrentPage = m.NewPage; });
        }

        private ViewModelBase _currentPage;
        public ViewModelBase CurrentPage
        {
            get => _currentPage; 
            set
            {
                if (_currentPage == value) { return; }
                Set(ref _currentPage, value);
            }
        }
    }
}