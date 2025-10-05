namespace HabbitTracker.Dto;

public class AdminPanelDto
{
    public string AdminName { get; set; } = string.Empty;
    public string HashedPassword { get; set; } =  string.Empty;
    public int User { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string Role {get; set; } = string.Empty;
}