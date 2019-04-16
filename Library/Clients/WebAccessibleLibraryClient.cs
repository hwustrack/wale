using Library.Common;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Clients
{
    /// <summary>
    /// Client that makes requests to the WebAccessibleLibrary in Azure Functions
    /// </summary>
    public class WebAccessibleLibraryClient : IWebAccessibleLibraryClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public WebAccessibleLibraryClient(IConfiguration configuration, HttpClient httpClient)
        {
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));

            _httpClient.BaseAddress = !string.IsNullOrWhiteSpace(configuration[Constants.Configuration_WebAccessibleLibraryBaseUrl])
                ? new Uri(configuration[Constants.Configuration_WebAccessibleLibraryBaseUrl])
                : throw new KeyNotFoundException($"Key {Constants.Configuration_WebAccessibleLibraryBaseUrl} not found in {nameof(configuration)}.");
            _apiKey = !string.IsNullOrWhiteSpace(configuration[Constants.Configuration_WebAccessibleLibraryApiKey])
                ? configuration[Constants.Configuration_WebAccessibleLibraryApiKey]
                : throw new KeyNotFoundException($"Key {Constants.Configuration_WebAccessibleLibraryApiKey} not found in {nameof(configuration)}.");
        }

        public async Task<string> Function1(CancellationToken cancellationToken)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, $"api/Function1?code={_apiKey}");
            Dictionary<string, string> payload = new Dictionary<string, string>()
            {
                { "name", "Hans" }
            };
            request.Content = new StringContent(JsonConvert.SerializeObject(payload));

            HttpResponseMessage response = await _httpClient.SendAsync(request, cancellationToken);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<int> GetMostFrequentElementInArrayLinq(int[] nums, CancellationToken cancellationToken)
        {
            string functionName = "MostFrequentElementInArrayLinq";
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, $"api/{functionName}?code={_apiKey}");
            request.Content = new StringContent(JsonConvert.SerializeObject(nums));

            HttpResponseMessage response = await _httpClient.SendAsync(request, cancellationToken);

            return int.Parse(await response.Content.ReadAsStringAsync());
        }
    }
}
