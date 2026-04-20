using Microsoft.AspNetCore.Mvc;
using movieArchieve.Data;
using movieArchieve.Entities;

namespace movieArchieve.Controllers
{
    public class DirectorController : Controller
    {
        private readonly AppDbContext _context;
        public DirectorController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var directors = _context.director.ToList();
            return View(directors);
        }

        public IActionResult Delete(int ID)
        { 
            var director = _context.director.Find(ID);
            if (director == null)
            {
                return NotFound();
            }
            _context.director.Remove(director);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(Director director)
        {
            _context.director.Add(director);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int ID)
        {
            var director = _context.director.Find(ID);
            if (director == null)
            {
                return NotFound();
            }
            return View(director);
        }
        
        [HttpPost]

        public IActionResult Edit(Director director)
        {
            _context.director.Update(director);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

