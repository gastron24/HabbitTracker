using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HabbitTracker.Domain.Models;

public class User
{
    [Key]
    public int Id { get; set; }
    public List<Habbit> Habits { get; set; } = new();
    [Required]
    [StringLength(30, MinimumLength = 2, ErrorMessage = "Имя должно быть от 2 до 30 символов")]
    public string FirstName { get; set; } = string.Empty;
    [Required]
    [EmailAddress]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Email должен быть от 2 до 50 символов")]
    public string Email { get; set; } = string.Empty;
    [Required]
    [StringLength(256)]
    public string HashedPassword { get; set; } = string.Empty;
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Balance { get; set; }
    [Required]
    [StringLength(20)]
    public string Role { get; set; } = "User";
    
}