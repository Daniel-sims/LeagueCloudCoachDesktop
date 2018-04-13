using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using LeagueCloudCoachDesktop.HttpRequest.Models;

namespace LeagueCloudCoachDesktop.HttpRequest
{
    public class TokenBasedRequestWrapper
    {
        private const string TokenEndpoint = "/connect/token";



        private const string ClientIdHeaderKey = "client_id";
        private const string ClientSecretHeaderKey = "client_secret";
        private const string RefreshTokenHeaderKey = "refresh_token";
        private const string GrantTypeHeaderKey = "grant_type";
        private const string UsernameHeaderKey = "username";
        private const string PasswordHeaderKey = "password";
        private const string ScopeHeaderKey = "scope";

        private const string ClientId = "LccDeskApplication";
        private const string ClientSecret = "A9445FF7-A793-429C-8B07-10CF8DB7F6F9";
        private const string ScopeLccApiOfflineAccess = "LccApi offline_access";

        private const string GrantTypeRefreshToken = "refresh_token";
        private const string GrantTypePassword = "password";

        private readonly IHttpRequestWrapper _httpRequestWrapper;

        private string AccessToken;
        private string RefreshToken;
        private DateTimeOffset TokenExpiresAt { get; set; }

        public TokenBasedRequestWrapper(IHttpRequestWrapper httpRequestWrapper)
        {
            _httpRequestWrapper = httpRequestWrapper;
        }

        public async Task<string> GetAccessToken()
        {
            //if we're within 5 minutes of the token expiring

            if (RefreshToken == null) return string.Empty;

            if (TokenExpiresAt == DateTime.MinValue || DateTime.Now >= TokenExpiresAt.AddMinutes(-5))
            {
                await RefreshAccessToken();
            }

            return AccessToken;
        }

        public async Task GetNewAccessToken(string username, string password)
        {
            try
            {
                var requestMessage = new HttpRequestMessage(HttpMethod.Post, TokenEndpoint);
                
                var contentValues = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>(GrantTypeHeaderKey, GrantTypePassword),
                    new KeyValuePair<string, string>(UsernameHeaderKey, username),
                    new KeyValuePair<string, string>(PasswordHeaderKey, password),
                    new KeyValuePair<string, string>(ScopeHeaderKey, ScopeLccApiOfflineAccess),
                    new KeyValuePair<string, string>(ClientIdHeaderKey, ClientId),
                    new KeyValuePair<string, string>(ClientSecretHeaderKey, ClientSecret)
                };

                var multipartFormDataContent = new MultipartFormDataContent();

                foreach (var contentVal in contentValues)
                {
                    multipartFormDataContent.Add(new StringContent(contentVal.Value), String.Format("\"{0}\"", contentVal.Key));
                }

                requestMessage.Content = multipartFormDataContent;
                
                var newToken = await _httpRequestWrapper.SendRequestAsync<AccessTokenResponse>(requestMessage);

                if (newToken.AccessToken == null)
                {
                    throw new InvalidCredentialException("Couldn't retreive access token for this user, probably invalid credentials.");
                }

                SetNewTokenValues(newToken);
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
                var requestMessage = new HttpRequestMessage(HttpMethod.Post, TokenEndpoint);

                var contentValues = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>(ClientIdHeaderKey, ClientId),
                    new KeyValuePair<string, string>(ClientSecretHeaderKey, ClientSecret),
                    new KeyValuePair<string, string>(RefreshTokenHeaderKey, RefreshToken),
                    new KeyValuePair<string, string>(GrantTypeHeaderKey, GrantTypeRefreshToken)
                };

                requestMessage.Content = new FormUrlEncodedContent(contentValues);

                var newToken = await _httpRequestWrapper.SendRequestAsync<AccessTokenResponse>(requestMessage);
                SetNewTokenValues(newToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void SetNewTokenValues(AccessTokenResponse tokenResponse)
        {
            AccessToken = tokenResponse?.AccessToken;
            RefreshToken = tokenResponse?.RefreshToken;
            TokenExpiresAt = DateTime.Now.AddSeconds(int.Parse(tokenResponse?.ExpiresIn));
        }
    }
}
