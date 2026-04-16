using Microsoft.AspNetCore.Mvc;
using movieArchieve.Data;
using movieArchieve.Entities;

namespace movieArchieve.Controllers
{
    public class WatchlistsControllers : Controller
    {
        private readonly AppDbContext _context;
        public WatchlistsControllers(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var watchlists = _context.watchlists.ToList();
            return View(watchlists);
        }
        public IActionResult Delete(int ID)
        {
            var watchlist = _context.watchlists.Find(ID);
            if (watchlist == null)
            {
                return NotFound();
            }
            _context.watchlists.Remove(watchlist);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Watchlists watchlist)
        {
            _context.watchlists.Add(watchlist);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int ID)
        {
            var watchlist = _context.watchlists.Find(ID);
            if (watchlist == null)
            {
                return NotFound();
            }
            return View(watchlist);
        }
        [HttpPost]
        public IActionResult Edit(Watchlists watchlist)
        {
            _context.watchlists.Update(watchlist);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
