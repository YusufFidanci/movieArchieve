using Microsoft.AspNetCore.Mvc;
using movieArchieve.Data;

namespace movieArchieve.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class actorApiController : Controller
    {
        private readonly AppDbContext _context;
        public actorApiController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult getAll()
        {
            var actor = _context.actor.ToList();
            return Ok(actor);    
        }

        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            var actor = _context.actor.Find(id);
            if (actor == null)
            {
                return NotFound();
            }
            return Ok(actor);
        }
    }
}
