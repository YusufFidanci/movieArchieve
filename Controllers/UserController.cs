using Microsoft.AspNetCore.Mvc;
using movieArchieve.Data;
using movieArchieve.Entities;

namespace movieArchieve.Controllers;

public class UserController : Controller
{
    private readonly AppDbContext _context;
    public UserController(AppDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        var user = _context.user.ToList();
        return View(user);
    }
    public IActionResult Delete(int ID)
    {
        var user = _context.user.Find(ID);

        if (user == null)
        {
            return NotFound();
        }

        _context.user.Remove(user);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(User user)
    {
        _context.user.Add(user);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
    public IActionResult Edit(int ID)
    {
        var user = _context.user.Find(ID);
        if (user == null)
        {
            return NotFound();
        }
        return View(user);
    }
    [HttpPost]
    public IActionResult Edit(User user)
    {
        _context.user.Update(user);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}
