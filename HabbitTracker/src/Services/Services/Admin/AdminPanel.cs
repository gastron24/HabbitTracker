using System.Runtime.InteropServices.JavaScript;
using HabbitTracker.Data;
using HabbitTracker.Dto;
using HabbitTracker.Services.Interfaces.Admin;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HabbitTracker.Services.Services.Admin;

public class AdminPanel : IAdminPanel
{
    private readonly Db _db;

    public AdminPanel(Db db)
    {
        _db = db;
    }

    public async Task<IActionResult> CheckAdminId(AdminPanelDto dto)
    {
        if (dto.Role != "Admin")
            return NotFound("Роль");

        if (dto.Role == "Admin")
            return Accepted();
    }
}