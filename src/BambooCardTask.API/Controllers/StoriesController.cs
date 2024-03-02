using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Filters;

namespace BambooCardTask.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoriesController : ControllerBase
    {
        private readonly IStoriesCore _storiesCore;
        public StoriesController(IStoriesCore storiesCore) 
        {
            _storiesCore = storiesCore;
        }

        [HttpGet("best")]
        public async Task<IActionResult> GetStories([FromQuery] GetStoriesFilter request)
        { 
            var stories = await _storiesCore.GetTopStories(request);
            return Ok(stories);
        }
    }
}
