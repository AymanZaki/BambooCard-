using Models.DTOs;
using Models.Filters;

namespace Core.Interfaces
{
    public interface IStoriesCore
    {
        Task<List<StoryDTO>> GetTopStories(GetStoriesFilter filter);
    }
}
