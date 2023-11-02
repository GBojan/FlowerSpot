using FlowerSpot.Service.Abstractions;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;

namespace FlowerSpot.Service
{
    public class HttpClientService : IHttpClientService
    {
        private readonly HttpClient _httpClient;

        public HttpClientService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<T> GetAsync<T>(string url, Dictionary<string, string> query) where T : class
        {
            var uri = QueryHelpers.AddQueryString(url, query);

            var result = await _httpClient.GetAsync(uri);

            return JsonConvert.DeserializeObject<T>(await result.Content.ReadAsStringAsync());
        }
    }
}