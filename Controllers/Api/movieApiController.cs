using Microsoft.AspNetCore.Mvc;
using movieArchieve.Data;
namespace movieArchieve.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class movieApiController : Controller
    {
        private readonly AppDbContext _context;
        public movieApiController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult getAll() {
            var movie = _context.movie.ToList();
            return Ok(movie);
        }

        [HttpGet("{id}")]
        public ActionResult getById(int id) {
            var movie = _context.movie.Find(id);
            if (movie == null) {
                return NotFound();
            }
            return Ok(movie);
        }

    }
}
