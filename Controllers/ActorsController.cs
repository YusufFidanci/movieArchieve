using Microsoft.AspNetCore.Mvc;
using movieArchieve.Data;
using movieArchieve.Entities;

namespace movieArchieve.Controllers
{
    public class ActorsController : Controller
    {
        private readonly AppDbContext _context;
        public ActorsController(AppDbContext context)
        {
            _context = context;
        }   

        public IActionResult Index()
        {
            var actors = _context.actors.ToList();
            return View(actors);
        }
         

        public IActionResult Delete(int ID)
        { 
            var actor = _context.actors.Find(ID);
            if (actor == null)
            {
                return NotFound();
            }
            _context.actors.Remove(actor);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Actors actor)
        {
            _context.actors.Add(actor);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int ID)
        {
            var actor = _context.actors.Find(ID);
            if (actor == null)
            {
                return NotFound();
            }
            return View(actor);
        }
        
        [HttpPost]
        public IActionResult Edit(Actors actor)
        {
            _context.actors.Update(actor);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        
    }
}
