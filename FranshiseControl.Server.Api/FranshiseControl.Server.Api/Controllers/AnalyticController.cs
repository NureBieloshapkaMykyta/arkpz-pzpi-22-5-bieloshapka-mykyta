using DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FranshiseControl.Server.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class AnalyticController(AppDbContext dbContext) : ControllerBase
{
    [HttpGet("sales-trends-from/{establishmentId}")]
    public async Task<IActionResult> SalesTrends(long establishmentId, DateTime start)
    {
        var sales = await dbContext.Sales
            .Include(x=>x.Product)
            .ThenInclude(x=>x.Supplier)
            .Where(x => x.Date > start && establishmentId == x.EstablishmentId).ToListAsync();

        return Ok(sales);
    }
}
