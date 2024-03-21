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
public class AccountController(UserManager<UserEntity> userManager, AddressService addressService, SignInManager<UserEntity> signInManager) : Controller
{
    private readonly UserManager<UserEntity> _userManager = userManager;
    private readonly SignInManager<UserEntity> _signInManager = signInManager;
    private readonly AddressService _addressService = addressService;

    #region HttpGet-Details
    [HttpGet]
    public async Task<IActionResult> Details()
    {
        try
        {
            var detailsViewModel = new AccountDetailsViewModel();
            detailsViewModel.BasicInfo = await PopulateBasicInfoAsync();
            detailsViewModel.AddressInfo ??= await PopulateAddressInfoAsync();
            detailsViewModel.ProfileInfo ??= await PopulateProfileInfoAsync();

            return View(detailsViewModel);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }
        return View();
    }
    #endregion

    #region HttpPost-Details
    [HttpPost]
    public async Task<IActionResult> Details(AccountDetailsViewModel detailsViewModel)
    {

        try
        {
            var user = await _userManager.GetUserAsync(User);

            if (detailsViewModel.BasicInfo != null)
            {
                if (detailsViewModel.BasicInfo.FirstName != null && detailsViewModel.BasicInfo.LastName != null && detailsViewModel.BasicInfo.Email != null)
                {
                    if (user != null)
                    {
                        if (detailsViewModel.BasicInfo != null)
                        {
                            user.FirstName = detailsViewModel.BasicInfo.FirstName;
                            user.LastName = detailsViewModel.BasicInfo.LastName;
                            user.Email = detailsViewModel.BasicInfo.Email;
                            user.PhoneNumber = detailsViewModel.BasicInfo.Phone;
                            user.Bio = detailsViewModel.BasicInfo.Bio;

                            var result = await _userManager.UpdateAsync(user);

                            if (result.Succeeded)
                            {
                                detailsViewModel.ConfirmMessage = "Basic information has been successfully updated";
                            }
                        }
                    }
                }
            }

            if (detailsViewModel.AddressInfo != null)
            {
                if (detailsViewModel.AddressInfo.AddressLine1 != null && detailsViewModel.AddressInfo.PostalCode != null && detailsViewModel.AddressInfo.City != null)
                {
                    if (user != null)
                    {
                        var existingAddress = await _addressService.GetAddressAsync(user.Id);
                        if (existingAddress != null)
                        {
                            existingAddress.AddressLine1 = detailsViewModel.AddressInfo.AddressLine1;
                            existingAddress.AddressLine2 = detailsViewModel.AddressInfo.AddressLine2;
                            existingAddress.PostalCode = detailsViewModel.AddressInfo.PostalCode;
                            existingAddress.City = detailsViewModel.AddressInfo.City;

                            await _addressService.UpdateAddressAsync(existingAddress);

                            user.AddressId = existingAddress.Id;
                            var result = await _userManager.UpdateAsync(user);

                            if (result.Succeeded)
                            {
                                detailsViewModel.ConfirmMessage = "Address information has been successfully updated";
                            }
                        }
                        else
                        {
                            var newAddress = new AddressEntity
                            {
                                AddressLine1 = detailsViewModel.AddressInfo.AddressLine1,
                                AddressLine2 = detailsViewModel.AddressInfo.AddressLine2!,
                                PostalCode = detailsViewModel.AddressInfo.PostalCode,
                                City = detailsViewModel.AddressInfo.City,
                            };
                            newAddress = await _addressService.CreateAddressAsync(newAddress!.AddressLine1, newAddress.PostalCode, newAddress.City, user.Id);
                            user.AddressId = newAddress.Id;
                            var result = await _userManager.UpdateAsync(user);

                            if (result.Succeeded)
                            {
                                detailsViewModel.ConfirmMessage = "A new address has been added successfully";
                            }

                        }

                    }
                }
            }

            detailsViewModel.ProfileInfo = await PopulateProfileInfoAsync();
            detailsViewModel.BasicInfo ??= await PopulateBasicInfoAsync();
            detailsViewModel.AddressInfo ??= await PopulateAddressInfoAsync();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }

        return View(detailsViewModel);

    }
    #endregion

    #region HttpGet-Security
    [HttpGet]
    public async Task<IActionResult> Security()
    {
        try
        {
            var securityViewModel = new AccountSecurityViewModel();
            securityViewModel.ProfileInfo = await PopulateProfileInfoAsync();
            securityViewModel.SecurityInfo ??= await PopulateSecurityInfoAsync();
            securityViewModel.SecurityDeleteInfo ??= await PopulateSecurityDeleteInfoAsync();

            return View(securityViewModel);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }
        return View();
    }
    #endregion

    #region HttpPost-Security
    [HttpPost]
    public async Task<IActionResult> Security(AccountSecurityViewModel securityViewModel)
    {
        try
        {
            var user = await _userManager.GetUserAsync(User);

            securityViewModel.ProfileInfo = await PopulateProfileInfoAsync();

            if (securityViewModel.SecurityInfo != null)
            {
                if (securityViewModel.SecurityInfo.CurrentPassword != null &&
                    securityViewModel.SecurityInfo.NewPassword != null &&
                    securityViewModel.SecurityInfo.ConfirmNewPassword != null)
                {
                    if (user != null)
                    {

                        var result = await _userManager.ChangePasswordAsync(user, securityViewModel.SecurityInfo.CurrentPassword, securityViewModel.SecurityInfo.NewPassword);

                        if (result.Succeeded)
                        {
                            securityViewModel.ConfirmMessage = "Password has been changed successfully";
                        }


                        else if (!result.Succeeded)
                        {
                            ModelState.AddModelError("IncorrectValues", "Incorrect values! Password has not been changed!");
                            securityViewModel.ErrorMessage = "Incorrect values! Password has not been changed!";
                            return View(securityViewModel);
                        }
                    }
                }

            }

            if (securityViewModel.SecurityDeleteInfo != null)
                {
                    if (securityViewModel.SecurityDeleteInfo.DeleteAccount == true)
                    {
                        if (user != null)
                        {
                            await _addressService.DeleteAddressAsync(user.Id);
                            await _userManager.DeleteAsync(user);
                            await _signInManager.SignOutAsync();
                            return RedirectToAction("Index", "Home");
                        }
                    }
            }

            securityViewModel.SecurityInfo ??= await PopulateSecurityInfoAsync();
            securityViewModel.SecurityDeleteInfo ??= await PopulateSecurityDeleteInfoAsync();
        }

        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }

        return View(securityViewModel);
    }

    #endregion


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

    private async Task<AccountSecurityInfoViewModel> PopulateSecurityInfoAsync()
    {
        var existingUser = await _userManager.GetUserAsync(User);
        if (existingUser != null)
        {
            return new AccountSecurityInfoViewModel
            {
                CurrentPassword = existingUser.PasswordHash!,
                NewPassword = existingUser.PasswordHash!,
                ConfirmNewPassword = existingUser.PasswordHash!,

            };
        }
        return new AccountSecurityInfoViewModel();
    }

    private async Task<AccountSecurityDeleteInfoViewModel> PopulateSecurityDeleteInfoAsync()
    {
        var existingUser = await _userManager.GetUserAsync(User);
        if (existingUser != null)
        {
            return new AccountSecurityDeleteInfoViewModel
            {
                DeleteAccount = false
            };
        }
        return new AccountSecurityDeleteInfoViewModel();
    }

}
