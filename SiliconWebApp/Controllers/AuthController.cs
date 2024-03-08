using Microsoft.AspNetCore.Mvc;
using SiliconWebApp.ViewModels.Views;

namespace SiliconWebApp.Controllers;

public class AuthController : Controller
{
    #region SignUp
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
    #endregion


    #region SignIn
    [HttpGet]
    public IActionResult SignIn()
    {
        var viewModel = new SignInViewModel();

        @ViewData["Title"] = viewModel.Title;

        return View(viewModel);
    }

    [HttpPost]
    public IActionResult SignIn(SignInViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            viewModel.ErrorMessage = "Incorrect email or password";
            return View(viewModel);
        }
        else
        {
            return RedirectToAction("Account", "Index");
        }
            
    }
    #endregion
}
