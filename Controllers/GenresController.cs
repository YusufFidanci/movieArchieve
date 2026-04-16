using Microsoft.AspNetCore.Mvc;
using movieArchieve.Data;
using movieArchieve.Entities;

namespace movieArchieve.Controllers
{
    public class GenresController : Controller
    {
        private readonly AppDbContext _context;
        public GenresController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var genres = _context.genres.ToList();
            return View(genres);
        }

         public IActionResult Delete(int ID)
         { 
             var genre = _context.genres.Find(ID);
             if (genre == null)
             {
                 return NotFound();
             }
             _context.genres.Remove(genre);
             _context.SaveChanges();
             return RedirectToAction("Index");
         }
         public IActionResult Create()
         {
             return View();
         }

         [HttpPost]
         public IActionResult Create(Genres genre)
         {
             _context.genres.Add(genre);
             _context.SaveChanges();
             return RedirectToAction("Index");
         }
         public IActionResult Edit(int ID)
         {
             var genre = _context.genres.Find(ID);
             if (genre == null)
             {
                 return NotFound();
             }
             return View(genre);
         }
         
         [HttpPost]
         public IActionResult Edit(Genres genre)
         {
             _context.genres.Update(genre);
             _context.SaveChanges();
             return RedirectToAction("Index");
        }
    }
}
