using Microsoft.AspNetCore.Mvc;
using movieArchieve.Data;
using movieArchieve.Entities;

namespace movieArchieve.Controllers
{
    public class GenreController : Controller
    {
        private readonly AppDbContext _context;
        public GenreController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var genres = _context.genre.ToList();
            return View(genres);
        }

         public IActionResult Delete(int ID)
         { 
             var genre = _context.genre.Find(ID);
             if (genre == null)
             {
                 return NotFound();
             }
             _context.genre.Remove(genre);
             _context.SaveChanges();
             return RedirectToAction("Index");
         }
         public IActionResult Create()
         {
             return View();
         }

         [HttpPost]
         public IActionResult Create(Genre genre)
         {
             _context.genre.Add(genre);
             _context.SaveChanges();
             return RedirectToAction("Index");
         }
         public IActionResult Edit(int ID)
         {
             var genre = _context.genre.Find(ID);
             if (genre == null)
             {
                 return NotFound();
             }
             return View(genre);
         }
         
         [HttpPost]
         public IActionResult Edit(Genre genre)
         {
             _context.genre.Update(genre);
             _context.SaveChanges();
             return RedirectToAction("Index");
        }
    }
}
