namespace HabbitTracker.Dto;

public class ChangeRoleRequestDto
{
    public int UserId { get; set; }
    public string NewRole { get; set; } = "User";
}