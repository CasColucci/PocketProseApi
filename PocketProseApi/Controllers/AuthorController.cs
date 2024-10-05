using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PocketProseApi.Models;

namespace PocketProseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly DataContext _context;

        public AuthorController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Author>>> GetAuthors()
        {
            var authors = await _context.Authors.ToListAsync();
            return Ok(authors);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Author>> GetAuthor(int id)
        {
            var author = await _context.Authors.FindAsync(id);

            if (author == null)
            {
                return NotFound("Author not found.");
            }
            return Ok(author);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAuthor(AuthorDto author)
        {
            var newAuthor = new Author
            {
                FirstName = author.FirstName,
                LastName = author.LastName,
                CreatedDate = DateTime.Now

            };
            _context.Authors.Add(newAuthor);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAuthor(AuthorDto author)
        {
            var dbAuthor = await _context.Authors.FindAsync(author.Id);

            if (dbAuthor == null)
            {
                return NotFound("Author not found.");
            }
            dbAuthor.FirstName = author.FirstName;
            dbAuthor.LastName = author.LastName;
            dbAuthor.UpdatedDate = DateTime.Now;

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAuthor(int id)
        {
            var dbAuthor = await _context.Authors.FindAsync(id);

            if (dbAuthor == null)
            {
                return NotFound("Author not found.");
            }
            _context.Authors.Remove(dbAuthor);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
