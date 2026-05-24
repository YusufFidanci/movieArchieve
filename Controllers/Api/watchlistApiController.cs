using Microsoft.AspNetCore.Mvc;
using movieArchieve.Data;

namespace movieArchieve.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]

    public class watchlistApiController : Controller
    {
        private readonly AppDbContext _context;
        public watchlistApiController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult getAll()
        {
            var watchlists = _context.watchlist.ToList();
            return Ok(watchlists);
        }

        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            var watchlist = _context.watchlist.Find(id);
            if (watchlist == null)
            {
                return NotFound();
            }
            return Ok(watchlist);
        }
    }
}
