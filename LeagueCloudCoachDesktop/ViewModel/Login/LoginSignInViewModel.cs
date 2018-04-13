using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using IdentityModel.Client;
using LeagueCloudCoachDesktop.Interfaces.Login;
using Newtonsoft.Json.Linq;

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
            var disco = await DiscoveryClient.GetAsync("http://localhost:5000");
            if (disco.IsError)
            {
                Console.WriteLine(disco.Error);
                return;
            }

            var tokenClient = new TokenClient(disco.TokenEndpoint, "client", "secret");
            var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");

            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                return;
            }

            var client = new HttpClient();
            client.SetBearerToken(tokenResponse.AccessToken);

            var response = await client.GetAsync("http://localhost:5001/StaticData/Items");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(JArray.Parse(content));
            }

            //if (parameter is PasswordBox passwordContainer)
            //{
            //    var username = UserName;
            //    var password = passwordContainer.Password;

            //    //Sign in logic here
            //}

            //Send message to login successfuly if succesful login

        }
    }
}
