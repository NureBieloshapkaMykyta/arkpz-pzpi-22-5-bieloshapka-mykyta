using Core;
using DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FranshiseControl.Server.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class EstablishmentController(AppDbContext dbContext) : Controller
{
    [HttpGet("{franshiseId}")]
    public async Task<IActionResult> GetAll(long franshiseId)
    {
        var result = await dbContext.Establishments.Where(x => x.FranshiseId == franshiseId).ToListAsync();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add(Establishment establishment)
    {
        await dbContext.Establishments.AddAsync(establishment);
        await dbContext.SaveChangesAsync();
        return Ok();
    }
}
