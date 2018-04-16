using LeagueCloudCoachDesktop.HttpRequest.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace LeagueCloudCoachDesktop.HttpRequest
{
    public class TokenBasedRequestWrapper : ITokenBasedRequestWrapper
    {
        private readonly HttpClient _httpClient;

        private static string _accessToken;
        private static string _refreshToken;
        private static DateTimeOffset _tokenExpiresAt;

        public TokenBasedRequestWrapper()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string> GetAccessToken()
        {
            //if we're within 5 minutes of the token expiring

            if (string.IsNullOrEmpty(_accessToken) || string.IsNullOrEmpty(_refreshToken))
                throw new Exception("Failed to get acccess token because Access token or refresh token is null or empty.");

            if (_tokenExpiresAt == DateTime.MinValue || DateTime.Now >= _tokenExpiresAt.AddMinutes(-5))
            {
                await RefreshAccessToken();
            }

            return _accessToken;
        }

        public async Task GetNewAccessToken(string username, string password)
        {
            try
            {
               
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private async Task RefreshAccessToken()
        {
            try
            {
              
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void SetNewTokenValues(AccessTokenResponse tokenResponse)
        {
            _accessToken = tokenResponse?.AccessToken;
            _refreshToken = tokenResponse?.RefreshToken;
            _tokenExpiresAt = DateTime.Now.AddSeconds(int.Parse(tokenResponse?.ExpiresIn));
        }

        public void SetAccessToken(string accessToken)
        {
            _accessToken = accessToken;
        }

        public void SetRefreshToken(string refreshToken)
        {
            _refreshToken = refreshToken;
        }

        public void SetExpirationTime(int expiresIn)
        {
            _tokenExpiresAt = DateTime.Now.AddSeconds(expiresIn);
        }
    }
}
