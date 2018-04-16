using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using IdentityModel.Client;
using LeagueCloudCoachDesktop.Constants.MessageTypes;
using LeagueCloudCoachDesktop.HttpRequest;
using LeagueCloudCoachDesktop.ViewModel.Application;
using System;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace LeagueCloudCoachDesktop.ViewModel.Login
{
    public class LoginViewModel : ViewModelBase
    {
        private string _username;
        public string UserName
        {
            get => _username;
            set => Set(ref _username, value);
        }

        private RelayCommand<object> _signInCommand;
        public RelayCommand<object> SignInCommand => _signInCommand ?? (_signInCommand = new RelayCommand<object>(async (param) => { await SignIn(param); }));

        private RelayCommand _registerCommand;
        public RelayCommand RegisterCommand => _registerCommand ?? (_registerCommand = new RelayCommand(LauncRegisterBrowser));

        private void LauncRegisterBrowser()
        {
            System.Diagnostics.Process.Start("https://localhost:44300/Account/Register");
        }

        private async Task SignIn(object parameter)
        {
            if (parameter is PasswordBox p && (UserName != null || UserName != ""))
            {
                var disco = await DiscoveryClient.GetAsync("http://localhost:5000");
                if (disco.IsError)
                {
                    Console.WriteLine(disco.Error);
                    return;
                }
                
                var tokenClient = new TokenClient(disco.TokenEndpoint, "ro.LccDesktopApplication", "5CD49741-DD56-4B26-8D03-9CF4AAAF9596");
                var tokenResponse = await tokenClient.RequestResourceOwnerPasswordAsync(UserName, p.Password, "LccApi offline_access");

                if (tokenResponse.IsError)
                {
                    Console.WriteLine(tokenResponse.Error);
                }
                else
                {
                    var tokenBasedWrapper = new TokenBasedRequestWrapper();
                    tokenBasedWrapper.SetAccessToken(tokenResponse.AccessToken);
                    tokenBasedWrapper.SetRefreshToken(tokenResponse.RefreshToken);
                    tokenBasedWrapper.SetExpirationTime(tokenResponse.ExpiresIn);

                    MessengerInstance.Send(new ChangeMainPageMessage(new MainApplicationViewModel()));
                }
            }
        }
    }
}
