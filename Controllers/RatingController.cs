using Microsoft.AspNetCore.Mvc;
using movieArchieve.Data;
using movieArchieve.Entities;

namespace movieArchieve.Controllers
{
    public class RatingController : Controller
    {
        private readonly AppDbContext _context;
        public RatingController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var ratings = _context.rating.ToList();
            return View(ratings);
        }
    
        public IActionResult Delete(int ID)
        {
            var rating = _context.rating.Find(ID);
            if (rating == null)
            {
                return NotFound();
            }
            _context.rating.Remove(rating);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(Rating rating)
        {
            _context.rating.Add(rating);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Edit(int ID)
        {
            var rating = _context.rating.Find(ID);
            if (rating == null)
            {
                return NotFound();
            }
            return View(rating);
        }
        [HttpPost]
        public IActionResult Edit(Rating rating)
        {
            _context.rating.Update(rating);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
