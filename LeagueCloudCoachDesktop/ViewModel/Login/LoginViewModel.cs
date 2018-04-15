using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using IdentityModel.Client;
using LeagueCloudCoachDesktop.Constants.MessageTypes;
using LeagueCloudCoachDesktop.ViewModel.Application;
using Newtonsoft.Json.Linq;

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
        public RelayCommand<object> SignInCommand
        {
            get { return _signInCommand ?? (_signInCommand = new RelayCommand<object>(async (param) => { await SignIn(param); })); }
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

                // ResourceOwnerPassword grant type
                var tokenClient = new TokenClient(disco.TokenEndpoint, "ro.LccDesktopApplication", "5CD49741-DD56-4B26-8D03-9CF4AAAF9596");
                var tokenResponse = await tokenClient.RequestResourceOwnerPasswordAsync(UserName, p.Password, "LccApi");

                if (tokenResponse.IsError)
                {
                    Console.WriteLine(tokenResponse.Error);
                }
                else
                {
                    MessengerInstance.Send(new ChangeMainPageMessage(new MainApplicationViewModel()));
                }

                //Console.WriteLine(tokenResponse.Json);

                //// call api
                //var client = new HttpClient();
                //client.SetBearerToken(tokenResponse.AccessToken);

                //var response = await client.GetAsync("http://localhost:5001/StaticData/Items");
                //if (!response.IsSuccessStatusCode)
                //{
                //    Console.WriteLine(response.StatusCode);
                //}
                //else
                //{
                //    var content = await response.Content.ReadAsStringAsync();
                //    Console.WriteLine(JArray.Parse(content));
                //}
            }
        }
    }
}
