using System.IdentityModel.Tokens.Jwt;
using HabbitTracker.Services.Interfaces;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace HabbitTracker.Application.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{
    private readonly IUserAuthService _userAuthService;

    public LoginController(IUserAuthService userAuthService)
    {
        _userAuthService = userAuthService;
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        try
        {
            var token = await _userAuthService.Authenticate(request.Email, request.Password);
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(new { token = tokenString });
        }
        catch (Exception ex)
        {
            return Unauthorized(ex.Message);
        }


    public class LoginRequest
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
    }
}