using System.ComponentModel.DataAnnotations;

namespace HabbitTracker.Domain.Models;

public class Habbit
{
    [Required]
    [StringLength(maximumLength: 50, MinimumLength = 2, ErrorMessage = "Название от 2 - до 50 символов")]
    public string Name { get; set; } = string.Empty;
   
    [Required]
    public DateTime StartDate { get; set; }
    
    [Required]
    public DateTime? EndDate { get; set; }
    
    [Required]
    public bool Completed { get; set; } 
    
    [Required]
    public bool Active { get; set; }
    
   
    public int UserId { get; set; }
    public User User { get; set; } = null!;
}