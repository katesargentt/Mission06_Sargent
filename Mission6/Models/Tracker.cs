using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission6.Models;

public class Tracker
{
    [Key]
    [Required]
    public int MovieID { get; set; } // Primary key, auto-increment

    [Required(ErrorMessage = "Category is required.")]
    [ForeignKey("CategoryId")]
    public int CategoryId { get; set; }
    public Category Category { get; set; }

    [Required(ErrorMessage = "Title is required.")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Year is required.")]
    public int Year { get; set; }

    [Required(ErrorMessage = "Director is required.")]
    public string Director { get; set; }

    [Required(ErrorMessage = "Rating is required.")]
    public string Rating { get; set; }

    // Nullable fields
    public string? LentTo { get; set; }
    public bool? Edited { get; set; }  // Nullable bool
     
    [MaxLength(25, ErrorMessage = "Notes cannot exceed 25 characters.")]
    public string? Notes { get; set; }
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
    