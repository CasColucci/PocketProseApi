using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PocketProseApi.Models;

namespace PocketProseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoryController : ControllerBase
    {

        private readonly DataContext _context;

        public StoryController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Story>>> GetStories()
        {
            var stories = await _context.Stories.ToListAsync();
            return Ok(stories);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Story>> GetStory(int id)
        {
            var story = await _context.Stories.FindAsync(id);

            if (story == null)
            {
                return NotFound("Story not found.");
            }
            return Ok(story);
        }

        [HttpPost]
        public async Task<ActionResult> CreateStory(StoryDto story)
        {
            var newStory = new Story
            {
                Title = story.Title,
                Content = story.Content,
                Author = await _context.Authors.FindAsync(story.Author.Id),
                Genre = story.Genre
            };
            _context.Stories.Add(newStory);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
