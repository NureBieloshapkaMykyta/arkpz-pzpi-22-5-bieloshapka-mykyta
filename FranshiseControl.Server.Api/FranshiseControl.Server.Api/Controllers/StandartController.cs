using Core;
using DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FranshiseControl.Server.Api.Controllers;

[Route("[controller]")]
[Authorize]
public class StandartController(AppDbContext dbContext) : Controller
{
    [HttpGet("{establishmentId}")]
    public async Task<IActionResult> GetAll(long establishmentId)
    {
        var standarts = await dbContext.StandartCompliances.Where(x => x.EstablishmentId == establishmentId).ToListAsync();

        return Ok(standarts);
    }

    [HttpPost]
    public async Task<IActionResult> Add(StandartCompliance standart)
    {
        await dbContext.StandartCompliances.AddAsync(standart);

        await dbContext.SaveChangesAsync();

        return Ok();
    }
}
