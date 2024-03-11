using Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiliconWebApp.ViewModels.Views;

namespace SiliconWebApp.Controllers;

public class AuthController(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager) : Controller
{
    private readonly UserManager<UserEntity> _userManager = userManager;
    private readonly SignInManager<UserEntity> _signInManager = signInManager;


    #region SignUp
    [HttpGet]
    public IActionResult SignUp()
    {
        var viewModel = new SignUpViewModel();
        if (_signInManager.IsSignedIn(User))
        {
            return RedirectToAction("Details", "Account");
        }
        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> SignUp(SignUpViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            var existingUser = await _userManager.Users.AnyAsync(x => x.Email == viewModel.Form.EmailAddress);
            if (existingUser)
            {
                ModelState.AddModelError("AlreadyExists", "User with the same email address already exists");
                ViewData["ErrorMessage"] = "User with the same email address already exists";
                return View(viewModel);
            }

            else
            {
                var newUser = new UserEntity
                {
                    FirstName = viewModel.Form.FirstName,
                    LastName = viewModel.Form.LastName,
                    Email = viewModel.Form.EmailAddress,
                    UserName = viewModel.Form.EmailAddress
                };

                var createResult = await _userManager.CreateAsync(newUser, viewModel.Form.Password);
                if (createResult.Succeeded)
                {
                    return RedirectToAction("SignIn", "Auth");
                }
            }

        }

        return View(viewModel);

    }
    #endregion


    #region SignIn
    [HttpGet]
    public IActionResult SignIn()
    {
        var viewModel = new SignInViewModel();
        if (_signInManager.IsSignedIn(User))
        {
            return RedirectToAction("Details", "Account");
        }
        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> SignIn(SignInViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            var signInResult = await _signInManager.PasswordSignInAsync(viewModel.Form.EmailAddress, viewModel.Form.Password, viewModel.Form.RememberMe, false);
            if (signInResult.Succeeded)
            {
                return RedirectToAction("Details", "Account");
            }       
        }

        ModelState.AddModelError("IncorrectValues", "Incorrect email or password");
        viewModel.ErrorMessage = "Incorrect email or password";
        return View(viewModel);

    }
    #endregion

    [HttpGet]
    public new async Task<IActionResult> SignOut()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
}
