using Core;
using DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FranshiseControl.Server.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class MarketingController(AppDbContext dbContext) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await dbContext.MarketingCampaigns.ToListAsync();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add(MarketingCampaigns marketing)
    {
        await dbContext.AddAsync(marketing);
        await dbContext.SaveChangesAsync();
        return Ok();
    }
}
