using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Interfaces
{
    public interface IHackerNewsAPIs
    {
        Task<List<long>> GetStoriesIds();
        Task<StoryDTO> GetStoryDetails(long storyId);
    }
}
