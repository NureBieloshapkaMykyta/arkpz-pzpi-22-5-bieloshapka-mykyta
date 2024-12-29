using Core;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FranshiseControl.Server.Api.Controllers;

public class ProductController(AppDbContext dbContext) : Controller
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await dbContext.Products.ToListAsync();
        return Ok(result);
    }

    [HttpGet("{supplierId}")]
    public async Task<IActionResult> GetAllFromSupplier(long supplierId)
    {
        var result = await dbContext.Products.Where(x=>x.SupplierId==supplierId).ToListAsync();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add(Product entity)
    {
        await dbContext.Products.AddAsync(entity);
        await dbContext.SaveChangesAsync();
        return Ok();
    }
}
