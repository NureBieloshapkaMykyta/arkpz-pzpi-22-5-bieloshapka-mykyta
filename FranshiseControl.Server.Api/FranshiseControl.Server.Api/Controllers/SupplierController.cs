using Core;
using DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FranshiseControl.Server.Api.Controllers;

[Route("[controller]")]
[Authorize]
public class SupplierController(AppDbContext dbContext) : Controller
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await dbContext.Suppliers.ToListAsync();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add(Supplier entity)
    {
        await dbContext.Suppliers.AddAsync(entity);
        await dbContext.SaveChangesAsync();
        return Ok();
    }
}
