using Microsoft.AspNetCore.Mvc;
using movieArchieve.Data;
namespace movieArchieve.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class userApiController : Controller
    {
        private readonly AppDbContext _context;
        public userApiController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult getAll()
        {
            var users = _context.user.ToList();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            var user = _context.user.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
    }
}
