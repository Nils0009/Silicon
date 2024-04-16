using Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiliconWebApp.ViewModels.Views;
using System.Security.Claims;

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
                    await _userManager.AddToRoleAsync(newUser, "User");
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

    #region SignOut
    [HttpGet]
    public new async Task<IActionResult> SignOut()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
    #endregion

    #region Facebook-SignIn
    [HttpGet]
    public IActionResult Facebook()
    {
        var externalAuthOptions = _signInManager.ConfigureExternalAuthenticationProperties("Facebook", Url.Action("Callback"));
        return new ChallengeResult("Facebook", externalAuthOptions);
    }
    #endregion

    #region Google-SignIn
    [HttpGet]
    public IActionResult Google()
    {
        var externalAuthOptions = _signInManager.ConfigureExternalAuthenticationProperties("Google", Url.Action("Callback"));
        return new ChallengeResult("Google", externalAuthOptions);
    }
    #endregion

    #region ExternalSignIn-Callback
    [HttpGet]
    public async Task<IActionResult> Callback()
    {
        var info = await _signInManager.GetExternalLoginInfoAsync();
        if (info != null) 
        {
            var userEntity = new UserEntity
            {
                FirstName = info.Principal.FindFirstValue(ClaimTypes.GivenName)!,
                LastName = info.Principal.FindFirstValue(ClaimTypes.Surname)!,
                Email = info.Principal.FindFirstValue(ClaimTypes.Email)!,
                UserName = info.Principal.FindFirstValue(ClaimTypes.Email)!,
                IsExternalAccount = true,
            };

            var user = await _userManager.FindByEmailAsync(userEntity.Email);
            if (user == null) 
            {              
                var result = await _userManager.CreateAsync(userEntity);
                if (result.Succeeded)
                    user = await _userManager.FindByEmailAsync(userEntity.Email);
            }

            if (user != null)
            {
                if (user.FirstName != userEntity.FirstName || user.LastName != userEntity.LastName || user.Email != userEntity.Email) 
                { 
                    user.FirstName = userEntity.FirstName;
                    user.LastName = userEntity.LastName;
                    user.Email = userEntity.Email;
                    user.IsExternalAccount = userEntity.IsExternalAccount;
                    await _userManager.UpdateAsync(user);
                }

                await _signInManager.SignInAsync(user, isPersistent: false);

                if (HttpContext.User != null)
                {
                    return RedirectToAction("Details", "Account");
                }
            }
        }
        var viewModel = new SignInViewModel();
        ModelState.AddModelError("InvalidAuthentication", "Failed to authenticate with external sign in");
        viewModel.ErrorMessage = "Failed to authenticate with external sign in";
        return RedirectToAction("SignIn", "Account");
    }
    #endregion
}
