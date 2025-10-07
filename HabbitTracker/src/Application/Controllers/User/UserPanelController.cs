using HabbitTracker.Data;
using HabbitTracker.Dto.User;
using HabbitTracker.Services.Interfaces;
using HabbitTracker.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace HabbitTracker.Application.Controllers.User;

[ApiController]
[Route("api/{controller}")]
public class UserPanelController : ControllerBase
{
    private readonly IUserPanel _userPanelService;

    public UserPanelController(IUserPanel userPanelService)
    {
        _userPanelService = userPanelService;
    }

    [HttpGet("/profile")]
    public async Task<ActionResult<Domain.Models.User>> GetProfile([FromQuery] UserPanelDto dto)
    {
        var user = await _userPanelService.GetUser(dto);
        if (user == null)
            return NotFound();
        
        return Ok(user);
    }
    [HttpPut("/profile")]

    public async Task<ActionResult<Domain.Models.User>> ChangeProfile(UserPanelDto dto)
    {
        var updatedUser = await _userPanelService.ChangeProfile(dto);
        if (updatedUser == null)
            return NotFound();
       
        return Ok(updatedUser);
    }
    
    
    
    
}