using HabbitTracker.Data;
using HabbitTracker.Domain.Models;
using HabbitTracker.Dto.User;
using HabbitTracker.Services.Interfaces;

public class UserPanelService : IUserPanel
{
    private readonly Db _context;

    public UserPanelService(Db context)
    {
        _context = context;
    }

    public async Task<User?> GetUser(UserPanelDto dto)
    {
        var user = await _context.Users.FindAsync(dto.UserId);
        return user;
    }

    public async Task<User?> ChangeProfile(UserPanelDto dto)
    {
        var user = await _context.Users.FindAsync(dto.UserId);
        if (user == null)
            return null;
        
        user.FirstName = dto.UserName;
        user.Email = dto.Email;

        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User?> UpBalance(UserPanelDto dto)
    {
        var user = await _context.Users.FindAsync(dto.UserId);
        if (user == null)
            return null;

        user.Balance += dto.Amount; // доделать
        await _context.SaveChangesAsync();
        return user;
    }
}