using System.IdentityModel.Tokens.Jwt;

namespace HabbitTracker.Services.Interfaces;

public interface IUserAuthService
{
    public Task<JwtSecurityToken> Authenticate(string email, string password);
    
}