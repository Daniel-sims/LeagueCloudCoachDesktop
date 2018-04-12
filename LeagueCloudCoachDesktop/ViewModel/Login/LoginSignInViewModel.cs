using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LeagueCloudCoachDesktop.Interfaces.Login;

namespace LeagueCloudCoachDesktop.ViewModel.Login
{
    public class LoginSignInViewModel : ViewModelBase
    {
        public LoginSignInViewModel() { }
        
        private string _username;
        public string UserName
        {
            get => _username;
            set => Set(ref _username, value);
        }
        
        private RelayCommand<object> _signInCommand;
        public RelayCommand<object> SignInCommand
        {
            get { return _signInCommand ?? (_signInCommand = new RelayCommand<object>(async (param) => { await SignIn(param); })); }
        }

        private async Task SignIn(object parameter)
        {
            if (parameter is PasswordBox passwordContainer)
            {
                var username = UserName;
                var password = passwordContainer.Password;

                //Sign in logic here
            }

            //Send message to login successfuly if succesful login

            await Task.Run(() => Thread.Sleep(10000));
        }
    }
}
