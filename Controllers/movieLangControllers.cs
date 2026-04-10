using Microsoft.AspNetCore.Mvc;
using movieArchieve.Data;
using movieArchieve.Entities;

namespace movieArchieve.Controllers
{
    public class movieLangControllers : Controller
    {
        private readonly AppDbContext _context;
        public movieLangControllers(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Delete(int ID)
        {
            var movieLang = _context.movieLangs.Find(ID);
            if (movieLang == null)
            {
                return NotFound();
            }
            _context.movieLangs.Remove(movieLang);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        
        public IActionResult Create(MovieLangs movieLang)
        {
            _context.movieLangs.Add(movieLang);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit (int ID)
        {
            var movieLang = _context.movieLangs.Find(ID);
            if (movieLang == null)
            {
                return NotFound();
            }
            return View(movieLang);
        }
        [HttpPost]
        public IActionResult Edit(MovieLangs movieLang)
        {
            _context.movieLangs.Update(movieLang);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
