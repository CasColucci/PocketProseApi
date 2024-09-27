using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PocketProseApi.Models;

namespace PocketProseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Author>>> GetAuthors()
        {
            return Ok();
        }
    }
}
