using Microsoft.AspNetCore.Mvc;

namespace SiliconWebApp.Controllers;

public class AccountController : Controller
{
    public IActionResult Details()
    {
        return View();
    }
}
