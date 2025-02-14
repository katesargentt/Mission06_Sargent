using Microsoft.EntityFrameworkCore;

namespace Mission6.Models;

public class MovieTrackerContext : DbContext
{
    public MovieTrackerContext(DbContextOptions<MovieTrackerContext> options) : base(options)
    {
        
    }
    
    public DbSet<Tracker> Trackers { get; set; }
}