using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission6.Models
{
    public class Tracker
    {
        [Key]
        [Required]
        public int MovieID { get; set; } // Primary key, auto-increment

        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        // Title is required with custom error message
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        // Year is required with custom error message
        [Required(ErrorMessage = "Year is required.")]
        [Range(1888, int.MaxValue, ErrorMessage = "Year must be greater than or equal to 1888.")]
        public int Year { get; set; }

        // Director is no longer required
        public string Director { get; set; }

        // Rating is no longer required
        public string Rating { get; set; }

        // Nullable fields
        public string? LentTo { get; set; }

        // Edited is required as a boolean
        [Required(ErrorMessage = "Edited field is required.")]
        public bool? Edited { get; set; }

        // Notes cannot exceed 25 characters
        [MaxLength(25, ErrorMessage = "Notes cannot exceed 25 characters.")]
        public string? Notes { get; set; }

        // CopiedToPlex is required as a boolean
        [Required(ErrorMessage = "Copied to Plex field is required.")]
        public bool? CopiedToPlex { get; set; }
    }
}