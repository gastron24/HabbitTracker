using HabbitTracker.Domain.Models;

namespace HabbitTracker.Dto.User;

public class UserPanelDto
{
    public int UserId { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Role { get; set; } = "User";
    public decimal Amount { get; set; }
}