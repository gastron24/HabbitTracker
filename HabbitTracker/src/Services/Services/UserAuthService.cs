using System.IdentityModel.Tokens.Jwt;
using HabbitTracker.Data;
using HabbitTracker.Services.Interfaces;

namespace HabbitTracker.Services.Services;

public class UserAuthService : IUserAuthService
{
   private readonly Db _context;
    public UserAuthService(Db context)
    {
       _context = context; 
    }
    public Task<JwtSecurityToken> Authenticate(string email, string password)
    {
        
    }
}