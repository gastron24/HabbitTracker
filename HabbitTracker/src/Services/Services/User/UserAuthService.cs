using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using DevOne.Security.Cryptography.BCrypt;
using HabbitTracker.Data;
using HabbitTracker.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HabbitTracker.Services.Services;

public class UserAuthService : IUserAuthService
{
    private readonly Db _context;
    private readonly string _jwtSecret; 

    public UserAuthService(Db context, IConfiguration configuration)
    {
        _context = context;
        _jwtSecret = configuration["Jwt:Secret"] ?? "super-secret-key-for-dev-only-12345" ; 
    }

    public async Task<JwtSecurityToken> Authenticate(string email, string password)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        if (user == null) 
            throw new Exception("Пользователь не найден");
        
        if (BCrypt.Net.BCrypt.Verify(password, user.HashedPassword)) 
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
            expires: DateTime.UtcNow.AddHours(2),
            signingCredentials: creds
        );
    }
}