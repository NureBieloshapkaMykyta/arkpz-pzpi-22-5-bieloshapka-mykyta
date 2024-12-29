using Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FranshiseControl.Server.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UserController(UserManager<AppUser> userManager) : Controller
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await userManager.Users.ToListAsync();
        return Ok(result);
    }

    [HttpGet("{email}")]
    public async Task<IActionResult> GetByEmail(string email)
    {
        var result = await userManager.FindByEmailAsync(email);
        return Ok(result);
    }
}
