using System.IdentityModel.Tokens.Jwt;
using HabbitTracker.Dto;
using HabbitTracker.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HabbitTracker.Application.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorizationController : ControllerBase
{
    private readonly IUserAuthService _userAuthService;

    public AuthorizationController(IUserAuthService userAuthService)
    {
        _userAuthService = userAuthService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        try
        {
            var token = await _userAuthService.Authenticate(dto.Email, dto.Password);
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(new { Token = tokenString });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
}