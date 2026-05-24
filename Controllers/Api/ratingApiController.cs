using Microsoft.AspNetCore.Mvc;
using movieArchieve.Data;


namespace movieArchieve.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]

    public class ratingApiController : Controller
    {
        private readonly AppDbContext _context;
        public ratingApiController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult getAll()
        {
            var ratings = _context.rating.ToList();
            return Ok(ratings);
        }

        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            var rating = _context.rating.Find(id);
            if (rating == null)
            {
                return NotFound();
            }
            return Ok(rating);
        }
    }
}
