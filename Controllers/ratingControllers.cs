using Microsoft.AspNetCore.Mvc;
using movieArchieve.Data;
using movieArchieve.Entities;

namespace movieArchieve.Controllers
{
    public class ratingControllers : Controller
    {
        private readonly AppDbContext _context;
        public ratingControllers(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    
        public IActionResult Delete(int ID)
        {
            var rating = _context.ratings.Find(ID);
            if (rating == null)
            {
                return NotFound();
            }
            _context.ratings.Remove(rating);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(Ratings rating)
        {
            _context.ratings.Add(rating);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Edit(int ID)
        {
            var rating = _context.ratings.Find(ID);
            if (rating == null)
            {
                return NotFound();
            }
            return View(rating);
        }
        [HttpPost]
        public IActionResult Edit(Ratings rating)
        {
            _context.ratings.Update(rating);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
