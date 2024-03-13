using Infrastructure.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SiliconWebApp.ViewModels.Sections;
using SiliconWebApp.ViewModels.Views;
using System.Diagnostics;
using System.Numerics;
namespace SiliconWebApp.Controllers;


[Authorize]
public class AccountController(SignInManager<UserEntity> signInManager, UserManager<UserEntity> userManager) : Controller
{
    private readonly SignInManager<UserEntity> _signInManager = signInManager;
    private readonly UserManager<UserEntity> _userManager = userManager;

    [HttpGet]
    public async Task<IActionResult> Details()
    {
        try
        {
            var viewModel = new AccountDetailsViewModel();
            viewModel = await PopulateAccountAsync();
            return View(viewModel);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Details(AccountDetailsViewModel viewModel)
    {

        try
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(viewModel.Email);
                {
                    if (user != null)
                    {
                        user.FirstName = viewModel.FirstName;
                        user.LastName = viewModel.LastName;
                        user.Email = viewModel.Email;
                        user.FirstName = viewModel.BasicInfo!.FirstName;
                        user.LastName = viewModel.BasicInfo.LastName;
                        user.Email = viewModel.BasicInfo.Email;
                        user.PhoneNumber = viewModel.BasicInfo!.Phone;
                        user.Bio = viewModel.BasicInfo!.Bio;
                        user.Address!.AddressLine1 = viewModel.AddressInfo!.AddressLine1!;
                        user.Address.AddressLine2 = viewModel.AddressInfo.AddressLine2!;
                        user.Address.PostalCode = viewModel.AddressInfo.PostalCode!;
                        user.Address.City = viewModel.AddressInfo.City!;

                        var result = await _userManager.UpdateAsync(user);
                     }
                }
                
            }
            viewModel = await PopulateAccountAsync();


        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }

        return View(viewModel);

    }

    private async Task<AccountDetailsViewModel> PopulateAccountAsync()
    {
        var existingUser = await _userManager.GetUserAsync(User);

        if (existingUser != null)
        {
            var viewModel = new AccountDetailsViewModel
            {

                FirstName = existingUser.FirstName,
                LastName = existingUser.LastName,
                Email = existingUser.Email!,

                BasicInfo = new AccountBasicInfoViewModel
                {
                    UserId = existingUser.Id,
                    FirstName = existingUser.FirstName,
                    LastName = existingUser.LastName,
                    Email = existingUser.Email!,
                    Phone = existingUser.PhoneNumber,
                    Bio = existingUser.Bio,
                },

                AddressInfo = new AccountAddressInfoViewModel 
                {
                    AddressLine1 = existingUser.Address!.AddressLine1,
                    AddressLine2 = existingUser.Address!.AddressLine2,
                    PostalCode = existingUser.Address!.PostalCode,
                    City = existingUser.Address!.City,
                }

            };

            return viewModel;
        }
     
        return new AccountDetailsViewModel { BasicInfo = new AccountBasicInfoViewModel(), AddressInfo = new AccountAddressInfoViewModel()};
    }
}
