using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LeagueCloudCoachDesktop.HttpRequest
{
    public interface IHttpRequestWrapper
    {
        Task<T> SendRequestAsync<T>(string requestUri);
    }
}
