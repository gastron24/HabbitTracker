using HabbitTracker.Data;
using HabbitTracker.Dto;
using HabbitTracker.Services.Interfaces.Admin;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HabbitTracker.Services.Services.Admin;

public class AdminPanel : IAdminPanel
{
    private readonly Db _db;

    public AdminPanel(Db db)
    {
        _db = db;
    }
    public async Task<IActionResult> GetAllUser()
    {
        
        return new OkObjectResult("Список пользователей (заглушка)");
    }

    public async Task<IActionResult> BanUser(BanUserRequestDto dto)
    {
        return new OkObjectResult("Пользователь забанен (заглушка)");
    }

    public async Task<IActionResult> ChangeRoleUser(ChangeRoleRequestDto dto)
    {
        return new OkObjectResult("Роль изменена (заглушка)");
    }
}