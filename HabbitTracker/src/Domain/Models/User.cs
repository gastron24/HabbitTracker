using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HabbitTracker.Domain.Models;

public class User
{
    [Key]
    public int Id { get; set; }
    [Required]
    [StringLength(25), MinLength(2)]
    public string FirstName { get; set; } = string.Empty;
    [Required]
    [StringLength(25), MinLength(2)]
    public string LastName { get; set; } = string.Empty; 
    [Required]
    [EmailAddress]
    [StringLength(50), MinLength(3)]
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