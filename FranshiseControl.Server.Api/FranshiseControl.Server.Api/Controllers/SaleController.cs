using Core;
using DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FranshiseControl.Server.Api.Controllers;

[Route("api/[controller]/{establishmentId}")]
[ApiController]
[Authorize]
public class SaleController(AppDbContext dbContext) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll(long establishmentId)
    {
        var result = await dbContext.Sales.Where(x => x.EstablishmentId == establishmentId).ToListAsync();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add(Sale sale)
    {
        await dbContext.Sales.AddAsync(sale);
        await dbContext.SaveChangesAsync();
        return Ok();
    }
}
