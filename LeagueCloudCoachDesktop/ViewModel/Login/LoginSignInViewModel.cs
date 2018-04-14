using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using IdentityModel.Client;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;

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
            // discover endpoints from metadata
            var disco = await DiscoveryClient.GetAsync("http://localhost:5000");
            if (disco.IsError)
            {
                Console.WriteLine(disco.Error);
                return;
            }

            //ClientCredentials grant type, no username/password
            //var tokenClient = new TokenClient(disco.TokenEndpoint, "client", "secret");
            //var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");

            //if (tokenResponse.IsError)
            //{
            //    Console.WriteLine(tokenResponse.Error);
            //    return;
            //}

            // ResourceOwnerPassword grant type
            var tokenClient = new TokenClient(disco.TokenEndpoint, "ro.client", "secret");
            var tokenResponse = await tokenClient.RequestResourceOwnerPasswordAsync("alice", "password", "api1");

            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                return;
            }
           
            Console.WriteLine(tokenResponse.Json);

            // call api
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
        }
    }
}
