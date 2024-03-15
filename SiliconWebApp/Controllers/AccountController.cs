using Infrastructure.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SiliconWebApp.ViewModels.Sections;
using SiliconWebApp.ViewModels.Views;
using System.Diagnostics;
namespace SiliconWebApp.Controllers;


[Authorize]
public class AccountController(UserManager<UserEntity> userManager, AddressService addressService) : Controller
{
    private readonly UserManager<UserEntity> _userManager = userManager;
    private readonly AddressService _addressService = addressService;

    [HttpGet]
    public async Task<IActionResult> Details()
    {
        try
        {
            var viewModel = new AccountDetailsViewModel();
            viewModel.BasicInfo = await PopulateBasicInfoAsync();
            viewModel.AddressInfo ??= await PopulateAddressInfoAsync();
            viewModel.ProfileInfo ??= await PopulateProfileInfoAsync();

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
            var user = await _userManager.GetUserAsync(User);

            if (viewModel.BasicInfo != null)
            {
                if (viewModel.BasicInfo.FirstName != null && viewModel.BasicInfo.LastName != null && viewModel.BasicInfo.Email != null)
                {
                    if (user != null)
                    {
                        if (viewModel.BasicInfo != null)
                        {
                            user.FirstName = viewModel.BasicInfo.FirstName;
                            user.LastName = viewModel.BasicInfo.LastName;
                            user.Email = viewModel.BasicInfo.Email;
                            user.PhoneNumber = viewModel.BasicInfo.Phone;
                            user.Bio = viewModel.BasicInfo.Bio;

                            var result = await _userManager.UpdateAsync(user);
                        }
                    }
                }
            }

            if (viewModel.AddressInfo != null)
            {
                if (viewModel.AddressInfo.AddressLine1 != null && viewModel.AddressInfo.PostalCode != null && viewModel.AddressInfo.City != null)
                {
                    if (user != null)
                    {
                        var existingAddress = await _addressService.GetAddressAsync(user.Id);
                        if (existingAddress != null)
                        {
                            existingAddress.AddressLine1 = viewModel.AddressInfo.AddressLine1;
                            existingAddress.AddressLine2 = viewModel.AddressInfo.AddressLine2;
                            existingAddress.PostalCode = viewModel.AddressInfo.PostalCode;
                            existingAddress.City = viewModel.AddressInfo.City;

                            var result = await _addressService.UpdateAddressAsync(existingAddress);

                            user.AddressId = existingAddress.Id;
                            await _userManager.UpdateAsync(user);
                        }
                        else
                        {
                            existingAddress = new AddressEntity
                            {
                                AddressLine1 = viewModel.AddressInfo.AddressLine1,
                                AddressLine2 = viewModel.AddressInfo.AddressLine2!,
                                PostalCode = viewModel.AddressInfo.PostalCode,
                                City = viewModel.AddressInfo.City,
                            };
                            user.AddressId = existingAddress.Id;
                            var newAddress = await _addressService.CreateAddressAsync(existingAddress!.AddressLine1, existingAddress.PostalCode, existingAddress.City, user.Id);
                        }

                    }
                }
            }

            viewModel.ProfileInfo = await PopulateProfileInfoAsync();
            viewModel.BasicInfo ??= await PopulateBasicInfoAsync();
            viewModel.AddressInfo ??= await PopulateAddressInfoAsync();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }

        return View(viewModel);

    }

    private async Task<AccountBasicInfoViewModel> PopulateBasicInfoAsync()
    {
        var existingUser = await _userManager.GetUserAsync(User);
        if (existingUser != null)
        {
            return new AccountBasicInfoViewModel
            {
                UserId = existingUser.Id,
                FirstName = existingUser.FirstName,
                LastName = existingUser.LastName,
                Email = existingUser.Email!,
                Phone = existingUser.PhoneNumber!,
                Bio = existingUser.Bio,
            };
        }
        return new AccountBasicInfoViewModel();
    }

    private async Task<AccountAddressInfoViewModel> PopulateAddressInfoAsync()
    {
        var existingUser = await _userManager.GetUserAsync(User);
        if (existingUser != null)
        {
            var existingAddress = await _addressService.GetAddressAsync(existingUser.Id);

            if (existingAddress != null)
            {
                return new AccountAddressInfoViewModel
                {
                    AddressLine1 = existingAddress.AddressLine1,
                    AddressLine2 = existingAddress.AddressLine2!,
                    PostalCode = existingAddress.PostalCode,
                    City = existingAddress.City,
                };
            }
        }
        return new AccountAddressInfoViewModel();
    }

    private async Task<AccountProfileInfoViewModel> PopulateProfileInfoAsync()
    {
        var existingUser = await _userManager.GetUserAsync(User);
        if (existingUser != null)
        {
            return new AccountProfileInfoViewModel
            {
                FirstName = existingUser.FirstName,
                LastName = existingUser.LastName,
                Email = existingUser.Email!,
            };
        }
        return new AccountProfileInfoViewModel();
    }

}
