using Microsoft.AspNetCore.Mvc;

namespace FranshiseControl.Server.Api.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
} 