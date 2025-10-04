using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using HabbitTracker.Data;
using HabbitTracker.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HabbitTracker.Services.Services;

public class UserAuthService : IUserAuthService
{
    private readonly Db _context;
    private readonly string _jwtSecret = "super-secret-key-for-dev-only-12345"; 

    public UserAuthService(Db context)
    {
        _context = context;
    }

    public async Task<JwtSecurityToken> Authenticate(string email, string password)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        if (user == null) 
            throw new Exception("Пользователь не найден");
        
        if (password != "123456") 
            throw new Exception("Неверный пароль");

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSecret));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        return new JwtSecurityToken(
            issuer: "HabitTracker",
            audience: "HabitTracker",
            claims: claims,
            expires: DateTime.Now.AddHours(2),
            signingCredentials: creds
        );
    }
}