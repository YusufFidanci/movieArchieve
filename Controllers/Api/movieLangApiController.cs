using Microsoft.AspNetCore.Mvc;
using movieArchieve.Data;

namespace movieArchieve.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class movieLangApiController : Controller
    {
        private readonly AppDbContext _context;

        public movieLangApiController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult getAll()
        {
            var movieLangs = _context.movieLang.ToList();
            return Ok(movieLangs);
        }

        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            var movieLang = _context.movieLang.Find(id);
            if (movieLang == null)
            {
                return NotFound();
            }
            return Ok(movieLang);
        }
    }
}
