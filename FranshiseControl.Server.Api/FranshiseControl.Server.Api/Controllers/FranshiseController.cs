using Core;
using DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FranshiseControl.Server.Api.Controllers;

[Route("[controller]")]
[Authorize]
public class FranshiseController(AppDbContext dbContext) : Controller
{
    [HttpGet("{userId}")]
    public async Task<IActionResult> GetAllUsersFrnchises(long userId)
    {
        var franchises = await dbContext.Franshises.Where(x=>x.AppUserId == userId).ToListAsync();

        return Ok(franchises);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var franchises = await dbContext.Franshises.ToListAsync();

        return Ok(franchises);
    }

    [HttpPost]
    public async Task<IActionResult> Add(Franshise franshise)
    {
        await dbContext.Franshises.AddAsync(franshise);

        await dbContext.SaveChangesAsync();

        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(long id)
    {
        dbContext.Franshises.Remove(await dbContext.Franshises.FindAsync(id));

        await dbContext.SaveChangesAsync();

        return Ok();
    }
}
