using Microsoft.AspNetCore.Mvc;
using movieArchieve.Data;
using movieArchieve.Entities;
namespace movieArchieve.Controllers
{
    public class movieController : Controller
    {
        private readonly AppDbContext _context;
        public movieController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var movies = _context.movies.ToList();
            return View(movies);
        }

        public IActionResult Delete(int ID)
        { 
            var movie = _context.movies.Find(ID);
            if (movie == null)
            {
                return NotFound();
            }

            _context.movies.Remove(movie);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Movies movie)
        {
            _context.movies.Add(movie);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult Edit(int ID)
        {
            var movie = _context.movies.Find(ID);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        [HttpPost]
        public IActionResult Edit (Movies movie)
        {
            _context.movies.Update(movie);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }

    

}
