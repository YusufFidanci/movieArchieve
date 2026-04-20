using Microsoft.AspNetCore.Mvc;
using movieArchieve.Data;
using movieArchieve.Entities;

namespace movieArchieve.Controllers
{
    public class ReviewController : Controller
    {
        private readonly AppDbContext _context;
        public ReviewController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var reviews = _context.review.ToList();
            return View(reviews);
        }

        public IActionResult Delete(int ID)
        {
            var review = _context.review.Find(ID);
            if (review == null)
            {
                return NotFound();
            }

            _context.review.Remove(review);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Review review)
        {
            _context.review.Add(review);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int ID)
        {
            var review = _context.review.Find(ID);
            if (review == null)
            {
                return NotFound();
            }   
            return View(review);
        }

        [HttpPost]
        public IActionResult Edit(Review review)
        {
            _context.review.Update(review);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
