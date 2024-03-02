using Core.Interfaces;
using Gateway.Interfaces;
using Models.DTOs;
using Models.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class StoriesCore : IStoriesCore
    {
        private readonly IHackerNewsAPIs _hackerNewsAPIs;
        public StoriesCore(IHackerNewsAPIs hackerNewsAPIs) 
        {
            _hackerNewsAPIs = hackerNewsAPIs;
        }
        public async Task<List<StoryDTO>> GetTopStories(GetStoriesFilter filter)
        {
            var storyIds = await _hackerNewsAPIs.GetStoriesIds();
            var tasks = new List<Task<StoryDTO>>();
            foreach (var storyId in storyIds)
            {
                tasks.Add(_hackerNewsAPIs.GetStoryDetails(storyId));
            }
            var results = await Task.WhenAll(tasks);
            var stories = results.ToList().OrderByDescending(x => x.Score).Take(filter.Limit);
            return stories.ToList();
        }
    }
}
