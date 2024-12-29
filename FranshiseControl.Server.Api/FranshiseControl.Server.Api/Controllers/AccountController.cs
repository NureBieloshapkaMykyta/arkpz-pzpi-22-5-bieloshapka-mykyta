using Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FranshiseControl.Server.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager) : Controller
{
    [HttpPost("login")]
    public async Task<IActionResult> Login(string email, string password)
    {
        var user = await userManager.FindByEmailAsync(email);
        var result = user.PasswordHash == password;
        if (!result)
        {
            return BadRequest("Invalid email or password");
        }

        await signInManager.SignInAsync(user, isPersistent: true);

        return Ok();
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(string username, string email, string password)
    {
        var user = new AppUser() { UserName = username, Email = email, PasswordHash = password };
        var result = await userManager.CreateAsync(user);
        if (!result.Succeeded)
        {
            return BadRequest(result.Errors);
        }

        return Ok(result);
    }

    [HttpGet("log-out")]
    public async Task<IActionResult> Logout()
    {
        if (signInManager.IsSignedIn(User))
        {
            await signInManager.SignOutAsync();
        }

        return Ok();
    }
}
