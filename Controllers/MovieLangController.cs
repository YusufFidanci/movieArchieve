using Microsoft.AspNetCore.Mvc;
using movieArchieve.Data;
using movieArchieve.Entities;

namespace movieArchieve.Controllers;

public class MovieLangController : Controller
{
    private readonly AppDbContext _context;
    public MovieLangController(AppDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        var movieLang = _context.movieLang.ToList();
        return View(movieLang);
    }

    public IActionResult Delete(int ID)
    {
        var movieLang = _context.movieLang.Find(ID);
        if (movieLang == null)
        {
            return NotFound();
        }
        _context.movieLang.Remove(movieLang);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    
    public IActionResult Create(MovieLang movieLang)
    {
        _context.movieLang.Add(movieLang);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
    public IActionResult Edit (int ID)
    {
        var movieLang = _context.movieLang.Find(ID);
        if (movieLang == null)
        {
            return NotFound();
        }
        return View(movieLang);
    }
    [HttpPost]
    public IActionResult Edit(MovieLang movieLang)
    {
        _context.movieLang.Update(movieLang);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

}
