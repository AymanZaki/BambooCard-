using Gateway.Interfaces;
using Microsoft.Extensions.Options;
using Models;
using Models.ConfigKeys;
using Models.DTOs;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Gateway.Services
{
    public class HackerNewsAPIs : IHackerNewsAPIs
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HackerNewsConfigs _hackerNewsConfigs;
        public HackerNewsAPIs(IHttpClientFactory httpClientFactory, IOptions<HackerNewsConfigs> hackerNewsConfigs)
        {
            _httpClientFactory = httpClientFactory;
            _httpClient = _httpClientFactory.CreateClient(HttpClients.HackerNewsHttpClientName);
            _hackerNewsConfigs = hackerNewsConfigs.Value;
        }
        public async Task<List<long>> GetStoriesIds()
        {
            var url = _hackerNewsConfigs.GetStoriesIdsUrl;
            List<long> storiesIds = new();
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                storiesIds = JsonConvert.DeserializeObject<List<long>>(await response.Content.ReadAsStringAsync());
            }
            return storiesIds;
        }
        public async Task<StoryDTO> GetStoryDetails(long storyId)
        {
            var url = _hackerNewsConfigs.GetStoryUrl;
            url = url.Replace("{id}", storyId.ToString());
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<StoryDTO>(responseContent);
            }
            return new();
        }
    }
}
