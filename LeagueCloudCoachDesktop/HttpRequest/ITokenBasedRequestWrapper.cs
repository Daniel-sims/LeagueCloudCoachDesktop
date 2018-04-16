using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueCloudCoachDesktop.HttpRequest
{
    public interface ITokenBasedRequestWrapper
    {
        Task<string> GetAccessToken();

        void SetAccessToken(string accessToken);
        void SetRefreshToken(string refreshToken);
        void SetExpirationTime(int expiresIn);
    }
}
