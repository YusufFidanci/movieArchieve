using Microsoft.AspNetCore.Mvc;
using movieArchieve.Data;

namespace movieArchieve.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]


    public class genreApiController : Controller
    {
        private readonly AppDbContext _context;
        public genreApiController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult getAll()
        {
            var genres = _context.genre.ToList();
            return Ok(genres);
        }

        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            var genre = _context.genre.Find(id);
            if (genre == null)
            {
                return NotFound();
            }
            return Ok(genre);
        }
    }
}
