using Microsoft.AspNetCore.Mvc;
using movieArchieve.Data;
using movieArchieve.Entities;

namespace movieArchieve.Controllers
{
    public class ActorController : Controller
    {
        private readonly AppDbContext _context;
        public ActorController(AppDbContext context)
        {
            _context = context;
        }   

        public IActionResult Index()
        {
            var actors = _context.actor.ToList();
            return View(actors);
        }
         

        public IActionResult Delete(int ID)
        { 
            var actor = _context.actor.Find(ID);
            if (actor == null)
            {
                return NotFound();
            }
            _context.actor.Remove(actor);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Actor actor)
        {
            _context.actor.Add(actor);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int ID)
        {
            var actor = _context.actor.Find(ID);
            if (actor == null)
            {
                return NotFound();
            }
            return View(actor);
        }
        
        [HttpPost]
        public IActionResult Edit(Actor actor)
        {
            _context.actor.Update(actor);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        
    }
}
