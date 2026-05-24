using Microsoft.AspNetCore.Mvc;
using movieArchieve.Data;

namespace movieArchieve.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]

    public class reviewApiController : Controller
    {
        private readonly AppDbContext _context;
        public reviewApiController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult getAll()
        {
            var reviews = _context.review.ToList();
            return Ok(reviews);
        }

        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            var review = _context.review.Find(id);
            if (review == null)
            {
                return NotFound();
            }
            return Ok(review);
        }
    }
}
