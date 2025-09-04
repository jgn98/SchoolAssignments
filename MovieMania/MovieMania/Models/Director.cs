using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace MovieMania.Models;

public class Director
{
    [Key]
    public int? DirectorId { get; set; }
    
    [Required]
    [StringLength(200, ErrorMessage = "Name must be between 1 and 200 characters")]   
    public string FirstName { get; set; }
    
    [Required]
    [StringLength(200, ErrorMessage = "Name must be between 1 and 200 characters")]
    public string LastName { get; set; }
    
    public string? FullName => $"{FirstName} {LastName}";
}