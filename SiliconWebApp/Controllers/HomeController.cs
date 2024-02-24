using Microsoft.AspNetCore.Mvc;

namespace SiliconWebApp.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        @ViewData["Title"] = "Home";

        return View();
    }
}
