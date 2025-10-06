using HabbitTracker.Domain.Models;
using HabbitTracker.Dto;
using Microsoft.AspNetCore.Mvc;

namespace HabbitTracker.Services.Interfaces.Admin;

public interface IAdminPanel
{
     Task<IActionResult> GetAllUser();
     Task<IActionResult> BanUser(BanUserRequestDto dto);
     Task<IActionResult> ChangeRoleUser(ChangeRoleRequestDto dto);
}