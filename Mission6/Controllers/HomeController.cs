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

    [HttpPost]
    public IActionResult MovieTracker(Tracker response)
    {
        _context.Trackers.Add(response); //add record to database
        _context.SaveChanges(); //commit changes
        
        
        return View("Confirmation", response);
    }
}