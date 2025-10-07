using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HabbitTracker.Application.Controllers;

[ApiController]
[Route("api/adm")]
[Authorize(Roles = "Admin")]
public class AdminController
{
    
    
}