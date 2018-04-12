using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace LeagueCloudCoachDesktop.ViewModel.Login
{
    public class LoginSignUpViewModel : ViewModelBase
    {
        public LoginSignUpViewModel(){ }

        private string _username;
        public string UserName
        {
            get => _username;
            set => Set(ref _username, value);
        }

        private string _email;
        public string Email
        {
            get => _email;
            set => Set(ref _email, value);
        }
        
        private RelayCommand _signUpCommand;
        public RelayCommand SignUpCommand
        {
            get { return _signUpCommand ?? (_signUpCommand = new RelayCommand(async () => { await SignUp(); })); }
        }

        private async Task SignUp()
        {
            await Task.Run(() => Thread.Sleep(10000));
        }
    }
}
