using Microsoft.AspNetCore.Mvc;
using movieArchieve.Data;
using movieArchieve.Entities;
namespace movieArchieve.Controllers
{
    public class MovieController : Controller
    {
        private readonly AppDbContext _context;
        public MovieController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var movies = _context.movie.ToList();
            return View(movies);
        }

        public IActionResult Delete(int ID)
        { 
            var movie = _context.movie.Find(ID);
            if (movie == null)
            {
                return NotFound();
            }

            _context.movie.Remove(movie);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            _context.movie.Add(movie);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult Edit(int ID)
        {
            var movie = _context.movie.Find(ID);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        [HttpPost]
        public IActionResult Edit (Movie movie)
        {
            _context.movie.Update(movie);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }

    

}
