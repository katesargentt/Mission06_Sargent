using System.ComponentModel.DataAnnotations;

namespace Mission6.Models;

public class Tracker
{
    [Key]
    [Required]
    public int MovieID { get; set; } //ApplicationID
    
    [Required]
    public string Category { get; set; }
    
    [Required]
    public string Title { get; set; }
    
    [Required]
    public int Year { get; set; }
    
    [Required]
    public string Director { get; set; }
    
    [Required]
    public string Rating { get; set; }
    public string LentTo { get; set; }
    public bool Edit { get; set; }
    
    [MaxLength(25, ErrorMessage = "Notes cannot exceed 25 characters.")]
    public string Notes { get; set; }
}


// public int GetApplicationID()
//     {
//         return ApplicationID;
//     }
//
//     public void SetApplicationID(int num)
//     {
//         ApplicationID = num;
//     }
//     
    