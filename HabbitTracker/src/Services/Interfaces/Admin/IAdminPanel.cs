using HabbitTracker.Domain.Models;
using HabbitTracker.Dto;
using Microsoft.AspNetCore.Mvc;

namespace HabbitTracker.Services.Interfaces.Admin;

public interface IAdminPanel
{
    public async Task<IActionResult> CheckAdminId(AdminPanelDto dto);
    public async Task<IActionResult> GetAllUser(AdminPanelDto dto);
    public async Task<IActionResult> BanUser(AdminPanelDto dto);
    public async Task<IActionResult> ChangeRoleUser(AdminPanelDto dto);
}