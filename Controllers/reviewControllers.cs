using Microsoft.AspNetCore.Mvc;
using movieArchieve.Data;
using movieArchieve.Entities;

namespace movieArchieve.Controllers
{
    public class reviewControllers : Controller
    {
        private readonly AppDbContext _context;
        public reviewControllers(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Delete(int ID)
        {
            var review = _context.reviews.Find(ID);
            if (review == null)
            {
                return NotFound();
            }

            _context.reviews.Remove(review);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Reviews review)
        {
            _context.reviews.Add(review);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int ID)
        {
            var review = _context.reviews.Find(ID);
            if (review == null)
            {
                return NotFound();
            }
            return View(review);
        }

        [HttpPost]
        public IActionResult Edit(Reviews review)
        {
            _context.reviews.Update(review);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
