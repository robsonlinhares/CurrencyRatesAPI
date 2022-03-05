using CurrencyRates.Domain.Interfaces.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Polly;
using Polly.Retry;
using System.Net.Http.Headers;
using System.Text;

namespace CurrencyRates.Domain.Services
{
    public class BaseRequestService : IBaseRequestService
    {

        public HttpClient CreateHttpClient()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.Timeout = TimeSpan.FromSeconds(30);

            return httpClient;
        }

        public async Task<T> PostAsync<T>(object objeto, string url)
        {
            var httpClient = CreateHttpClient();
            var uri = new Uri(url);
            var resiliencePolicy = await ResiliencePolicy();

            var json = JsonConvert.SerializeObject(objeto, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await resiliencePolicy.ExecuteAsync(() => httpClient.PostAsync(uri, httpContent));

            var content = response.Content.ReadAsStringAsync().Result;

            if (!response.IsSuccessStatusCode)
                throw new Exception(content);

            return await Task.Run(() => JsonConvert.DeserializeObject<T>(content));
        }

        public async Task<T> GetAsync<T>(string url)
        {
            var httpClient = CreateHttpClient();
            var uri = new Uri(url);
            var resiliencePolicy = await ResiliencePolicy();

            var response = await resiliencePolicy.ExecuteAsync(() => httpClient.GetAsync(uri));
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                throw new Exception(content);

            return await Task.Run(() => JsonConvert.DeserializeObject<T>(content));
        }

        private static async Task<AsyncRetryPolicy> ResiliencePolicy()
        {
            return await Task.FromResult(Policy.Handle<HttpRequestException>()
                                               .RetryAsync(3, (ex, retryCnt) =>
                                               {
                                                   Console.WriteLine($"Retry count {retryCnt}");
                                               }));
        }
    }
}
