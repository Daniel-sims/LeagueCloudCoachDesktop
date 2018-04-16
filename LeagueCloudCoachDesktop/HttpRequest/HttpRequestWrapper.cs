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
        private readonly ITokenBasedRequestWrapper _tokenBasedRequestWrapper;

        public HttpRequestWrapper(ITokenBasedRequestWrapper tokenBasedRequestWrapper)
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5001")
            };

            _tokenBasedRequestWrapper = tokenBasedRequestWrapper;

            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<T> SendRequestAsync<T>(string requestUri)
        {
            HttpResponseMessage response;

            try
            {
                _httpClient.SetBearerToken(await _tokenBasedRequestWrapper.GetAccessToken());
                response = await _httpClient.GetAsync(requestUri);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return await HandleResponse<T>(response);
        }

        private async Task<T> HandleResponse<T>(HttpResponseMessage httpResponse)
        {
            try
            {
                var responseString = await httpResponse.Content.ReadAsStringAsync();

                if (!string.IsNullOrEmpty(responseString))
                {
                    return JsonConvert.DeserializeObject<T>(responseString);
                }

                throw new Exception("The server didn't return anything!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
