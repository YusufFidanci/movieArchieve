using Microsoft.AspNetCore.Mvc;
using movieArchieve.Data;
using movieArchieve.Entities;

namespace movieArchieve.Controllers
{
    public class UsersControllers : Controller
    {
        private readonly AppDbContext _context;
        public UsersControllers(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var users = _context.users.ToList();
            return View(users);
        }
        public IActionResult Delete(int ID)
        {
            var user = _context.users.Find(ID);
            if (user == null)
            {
                return NotFound();
            }
            _context.users.Remove(user);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Users user)
        {
            _context.users.Add(user);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int ID)
        {
            var user = _context.users.Find(ID);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }
        [HttpPost]
        public IActionResult Edit(Users user)
        {
            _context.users.Update(user);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
