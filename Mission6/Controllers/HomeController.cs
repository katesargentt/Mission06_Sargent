using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
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
        return View();
    }

    // POST method for MovieTracker
    [HttpPost]
    public IActionResult MovieTracker(Tracker response)
    {
        // Check if the model is valid before saving
        if (!ModelState.IsValid)
        {
            // If invalid, return the form with validation error messages
            return View(response);
        }

        // Add the record to the database and save changes
        _context.Trackers.Add(response);
        _context.SaveChanges();
            
        // Redirect to a confirmation view after successful form submission
        return View("Confirmation", response);
    }

    public IActionResult MovieList()
    {
         var trackers = _context.Trackers
            .Where(x => x.Edited == true);

        return View();
    }
}