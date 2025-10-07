using HabbitTracker.Domain.Models;
using HabbitTracker.Dto.User;

namespace HabbitTracker.Services.Interfaces;

public interface IUserPanel
{
    public Task<User> GetUser(UserPanelDto dto);
    public Task<User> ChangeProfile(UserPanelDto dto);
    public Task<User> UpBalance(UserPanelDto dto);
    
}