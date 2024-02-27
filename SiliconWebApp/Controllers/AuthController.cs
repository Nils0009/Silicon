using Microsoft.AspNetCore.Mvc;
using SiliconWebApp.Models.Views;

namespace SiliconWebApp.Controllers;

public class AuthController : Controller
{
    [HttpGet]
    public IActionResult SignUp()
    {
        var viewModel = new SignUpViewModel();

        @ViewData["Title"] = viewModel.Title;

        return View(viewModel);
    }

    [HttpPost]
    public IActionResult SignUp(SignUpViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(viewModel);
        }
        else
        {
            return RedirectToAction("SignIn", "Auth");
        }
        
    }

    public IActionResult SignIn()
    {
        return View();
    }
}
