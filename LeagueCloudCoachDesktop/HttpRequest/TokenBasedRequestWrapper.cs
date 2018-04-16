using IdentityModel.Client;
using System;
using System.Threading.Tasks;

namespace LeagueCloudCoachDesktop.HttpRequest
{
    public class TokenBasedRequestWrapper : ITokenBasedRequestWrapper
    {
        private static string _accessToken;
        private static string _refreshToken;
        private static DateTimeOffset _tokenExpiresAt;
        
        public async Task<string> GetAccessToken()
        {
            if (string.IsNullOrEmpty(_accessToken) || string.IsNullOrEmpty(_refreshToken))
                throw new Exception("Failed to get acccess token because Access token or refresh token is null or empty.");

            if (_tokenExpiresAt == DateTime.MinValue || DateTime.Now >= _tokenExpiresAt.AddMinutes(-5))
                await RefreshAccessToken();

            return _accessToken;
        }

        private async Task RefreshAccessToken()
        {
            try
            {
                var discoveryClient = await DiscoveryClient.GetAsync("http://localhost:5000");
                if (discoveryClient.IsError)
                {
                    throw new Exception("Error in discovery client - " + discoveryClient.Error);
                }

                using (var tokenClient = new TokenClient(discoveryClient.TokenEndpoint, "ro.LccDesktopApplication", "5CD49741-DD56-4B26-8D03-9CF4AAAF9596"))
                {
                    SetNewTokenValues(await tokenClient.RequestRefreshTokenAsync(_refreshToken));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private void SetNewTokenValues(TokenResponse tokenResponse)
        {
            if(tokenResponse == null || tokenResponse.IsError)
                throw new Exception("Exception caught while setting token values, tokenResponse is null.");

            _accessToken = tokenResponse.AccessToken;
            _refreshToken = tokenResponse.RefreshToken;
            _tokenExpiresAt = DateTime.Now.AddSeconds(tokenResponse.ExpiresIn);
        }

        public void SetAccessToken(string accessToken) => _accessToken = accessToken;

        public void SetRefreshToken(string refreshToken) => _refreshToken = refreshToken;

        public void SetExpirationTime(int expiresIn) => _tokenExpiresAt = DateTime.Now.AddSeconds(expiresIn);
    }
}
