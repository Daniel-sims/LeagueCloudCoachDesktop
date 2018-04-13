using GalaSoft.MvvmLight;
using LeagueCloudCoachDesktop.ViewModel.Login;

namespace LeagueCloudCoachDesktop.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            CurrentPage = new LoginViewModel();
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