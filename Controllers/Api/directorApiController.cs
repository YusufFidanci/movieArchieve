using Microsoft.AspNetCore.Mvc;
using movieArchieve.Data;

namespace movieArchieve.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]

    public class directorApiController : Controller
    {
        private readonly AppDbContext _context;
        public directorApiController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult getAll()
        {
            var director = _context.director.ToList();
            return Ok(director);
        }

        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            var director = _context.director.Find(id);
            if (director == null)
            {
                return NotFound();
            }
            return Ok(director);
        }
    }
}
