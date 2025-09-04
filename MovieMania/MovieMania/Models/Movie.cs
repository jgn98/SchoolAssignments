using System.ComponentModel.DataAnnotations;
using EnvironmentName = Microsoft.AspNetCore.Hosting.EnvironmentName;

namespace MovieMania.Models;

public class Movie
{
    [Key]
    public int? MovieId { get; set; }
    
    [Required (ErrorMessage = "Name is required")]
    [StringLength(100, ErrorMessage = "Name must be between 1 and 100 characters")]
    public string Title { get; set; }
    
    [Required]
    [Range(1888, 2025, ErrorMessage = "Year must be between 1888 and 2025")]
    public int ReleaseYear { get; set; }
    
    [Required]
    [Range(0, 1000, ErrorMessage = "Duration cannot be negative")]   
    public int DurationInMinutes { get; set; }
    
    [StringLength(500, ErrorMessage = "Description cannot be longer than 500 characters")]
    public string? Description { get; set; }
    
    [Range(1, 10, ErrorMessage = "Rating must be between 1 and 10")]  
    public int? Rating { get; set; }
    
    [Required]
    [Display(Name = "Director")]
    public int? DirectorId { get; set; }
    
    public Director? Director { get; set; }
}