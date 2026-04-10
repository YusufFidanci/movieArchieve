using Microsoft.AspNetCore.Mvc;
using movieArchieve.Data;
using movieArchieve.Entities;

namespace movieArchieve.Controllers
{
    public class directorControllers : Controller
    {
        private readonly AppDbContext _context;
        public directorControllers(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Delete(int ID)
        { 
            var director = _context.directors.Find(ID);
            if (director == null)
            {
                return NotFound();
            }
            _context.directors.Remove(director);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(Directors director)
        {
            _context.directors.Add(director);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int ID)
        {
            var director = _context.directors.Find(ID);
            if (director == null)
            {
                return NotFound();
            }
            return View(director);
        }
        
        [HttpPost]

        public IActionResult Edit(Directors director)
        {
            _context.directors.Update(director);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

