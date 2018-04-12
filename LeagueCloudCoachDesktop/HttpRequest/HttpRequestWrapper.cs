using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LeagueCloudCoachDesktop.HttpRequest
{
    public class HttpRequestWrapper : IHttpRequestWrapper
    {
        private readonly HttpClient _httpClient;

        public HttpRequestWrapper()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:54547")
            };

            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<T> SendRequestAsync<T>(HttpRequestMessage request)
        {
            var response = await _httpClient.SendAsync(request);

            return await HandleResponse<T>(response);
        }

        private async Task<T> HandleResponse<T>(HttpResponseMessage httpResponse)
        {
            var responseString = await httpResponse.Content.ReadAsStringAsync();

            if (!string.IsNullOrEmpty(responseString))
            {
                return JsonConvert.DeserializeObject<T>(responseString);
            }

            throw new Exception("The server didn't return anything!");
        }
    }
}
