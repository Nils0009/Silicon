using Infrastructure.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SiliconWebApp.ViewModels.Views;
using System.Diagnostics;

namespace SiliconWebApp.Controllers;


[Authorize]
public class AccountController(SignInManager<UserEntity> signInManager, UserManager<UserEntity> userManager) : Controller
{
    private readonly SignInManager<UserEntity> _signInManager = signInManager;
    private readonly UserManager<UserEntity> _userManager = userManager;

    [HttpGet]
    public async Task<IActionResult> Details()
    {
        if (!_signInManager.IsSignedIn(User))
            return RedirectToAction("SignIn", "Auth");
        
        var existingUser = await _userManager.GetUserAsync(User);
        
        var viewModel = new AccountDetailsViewModel() 
        {
            User = existingUser!
        };


        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> BasicInfo(AccountDetailsViewModel viewModel)
    {

        try
        {
            if (ModelState.IsValid)
            {
                var updatedUser = await _userManager.UpdateAsync(viewModel.User);

                if (!updatedUser.Succeeded)
                {
                    ModelState.AddModelError("Failed to save data", "Unable to save data");
                    ViewData["ErrorMessage"] = "Unable to save data";
                }

                return RedirectToAction("Details", "Account", viewModel);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }

        return View(viewModel);

    }
}
