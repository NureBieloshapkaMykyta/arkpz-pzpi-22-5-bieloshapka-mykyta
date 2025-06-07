using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Queues;
using Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FranshiseControl.Server.Api.Controllers;

public class AccountController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly BlobServiceClient _blobServiceClient;
    private readonly QueueServiceClient _queueServiceClient;

    public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, BlobServiceClient blobService, QueueServiceClient queueServiceClient)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _blobServiceClient = blobService;
        _queueServiceClient = queueServiceClient;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(string email, string password, string? returnUrl = null)
    {
        returnUrl ??= Url.Content("~/");

        var user = await _userManager.FindByEmailAsync(email);
        if (user == null)
        {
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View();
        }

        var result = user.PasswordHash == password;
        if (!result)
        {
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View();
        }

        await _signInManager.SignInAsync(user, isPersistent: true);
        return LocalRedirect(returnUrl);
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(string username, string email, string password, IFormFile file, string? returnUrl = null)
    {
        returnUrl ??= Url.Content("~/");

        //blob client
        var containerClient = _blobServiceClient.GetBlobContainerClient(username);
        await containerClient.CreateIfNotExistsAsync(PublicAccessType.Blob);
        var newBlobName = $"{Guid.NewGuid().ToString()}.jpg";
        var uploadBlobResult = await containerClient.UploadBlobAsync(newBlobName, file.OpenReadStream());
        var blobClient = containerClient.GetBlobClient(newBlobName);


        //queue client
        const string reviewAvatarsTopic = "review-avatars";
        var queueCleint = _queueServiceClient.GetQueueClient(reviewAvatarsTopic);
        await queueCleint.CreateIfNotExistsAsync();
        await queueCleint.SendMessageAsync($"{email}: {newBlobName}");

        var user = new AppUser { UserName = username, Email = email, PasswordHash = password, PhotoUrl = blobClient.Uri.ToString() };
        var result = await _userManager.CreateAsync(user);

        if (result.Succeeded)
        {
            await _signInManager.SignInAsync(user, isPersistent: false);
            return LocalRedirect(returnUrl);
        }

        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }

    // API endpoints
    [HttpPost("api/[controller]/login")]
    public async Task<IActionResult> ApiLogin(string email, string password)
    {
        var user = await _userManager.FindByEmailAsync(email);
        var result = user?.PasswordHash == password;
        if (!result)
        {
            return BadRequest("Invalid email or password");
        }

        await _signInManager.SignInAsync(user!, isPersistent: true);
        return Ok();
    }

    [HttpPost("api/[controller]/register")]
    public async Task<IActionResult> ApiRegister(string username, string email, string password)
    {
        var user = new AppUser { UserName = username, Email = email, PasswordHash = password };
        var result = await _userManager.CreateAsync(user);
        if (!result.Succeeded)
        {
            return BadRequest(result.Errors);
        }

        return Ok(result);
    }

    [HttpGet("api/[controller]/log-out")]
    public async Task<IActionResult> ApiLogout()
    {
        if (_signInManager.IsSignedIn(User))
        {
            await _signInManager.SignOutAsync();
        }

        return Ok();
    }
}
