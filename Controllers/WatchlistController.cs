using Microsoft.AspNetCore.Mvc;
using movieArchieve.Data;
using movieArchieve.Entities;

namespace movieArchieve.Controllers
{
    public class WatchlistController : Controller
    {
        private readonly AppDbContext _context;
        public WatchlistController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var watchlists = _context.watchlist.ToList();
            return View(watchlists);
        }
        public IActionResult Delete(int ID)
        {
            var watchlist = _context.watchlist.Find(ID);
            if (watchlist == null)
            {
                return NotFound();
            }
            _context.watchlist.Remove(watchlist);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Watchlist watchlist)
        {
            _context.watchlist.Add(watchlist);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int ID)
        {
            var watchlist = _context.watchlist.Find(ID);
            if (watchlist == null)
            {
                return NotFound();
            }
            return View(watchlist);
        }
        [HttpPost]
        public IActionResult Edit(Watchlist watchlist)
        {
            _context.watchlist.Update(watchlist);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
