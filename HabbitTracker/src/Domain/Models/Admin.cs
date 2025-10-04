using System.ComponentModel.DataAnnotations;

namespace HabbitTracker.Domain.Models;

public class Admin : User
{
    public string Role { get; set; } = "Admin";
}