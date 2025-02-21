using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission6.Models;

namespace Mission6.Controllers;

public class HomeController : Controller
{
    // private readonly ILogger<HomeController> _logger; //ilogger of type homecontroller
    //
    // public HomeController(ILogger<HomeController> logger) //constructor --making another object of ILogger
    // {
    //     _logger = logger;
    // }
    
    private MovieTrackerContext _context;
    
    public HomeController(MovieTrackerContext temp) //constructor
    {
        _context = temp;
    }
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult GetToKnowYou()
    {
        return View();
    }
    
    [HttpGet]

    public IActionResult MovieTracker()
    {
        Console.WriteLine("MovieTracker action called."); // Debug log

        ViewBag.Categories = _context.Categories.ToList();
        
        return View("MovieTracker", new Tracker());
    }



    // POST method for MovieTracker
    [HttpPost]
    public IActionResult MovieTracker(Tracker response)
    {
        // Check if the model is valid before saving
        if (ModelState.IsValid)
        {
            // Add the record to the database and save changes
            _context.Movies.Add(response);
            _context.SaveChanges();
            
            // Redirect to a confirmation view after successful form submission
            return View("Confirmation", response);
        }
        else //invalid data
        {
            ViewBag.Categories = _context.Categories.ToList();

            return View(response);
        }

        
    }

    public IActionResult MovieList()
    {
        var trackers = _context.Movies
            .Include(t => t.Category) // Ensure Category data is included
            .ToList();

        return View(trackers);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var recordToEdit = _context.Movies
            .Single(x => x.MovieID == id);
        ViewBag.Categories = _context.Categories.ToList();
        
        return View("MovieTracker", recordToEdit);
    }

    [HttpPost]

    public IActionResult Edit(Tracker updatedInfo)
    {
        _context.Update(updatedInfo);
        _context.SaveChanges();
        
        return RedirectToAction("MovieList");
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var recordToDelete = _context.Movies
            .Single(x => x.MovieID == id);
        return View(recordToDelete);
    }

    [HttpPost]
    public IActionResult Delete(Tracker tracker)
    {
        _context.Movies.Remove(tracker);
        _context.SaveChanges();
        
        return RedirectToAction("MovieList");
    }
}