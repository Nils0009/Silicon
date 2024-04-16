using Infrastructure.Entities;
using Infrastructure.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SiliconWebApp.ViewModels.Sections;
using SiliconWebApp.ViewModels.Views;
using System.Diagnostics;
using System.Net;
using System.Text;



namespace SiliconWebApp.Controllers;

[Authorize(Roles = "Admin")]
public class AdminController(HttpClient http, UserManager<UserEntity> userManager, AccountService accountService) : Controller
{
    private readonly HttpClient _http = http;
    private readonly UserManager<UserEntity> _userManager = userManager;
    private readonly AccountService _accountService = accountService;
    public async Task<IActionResult> Index()
    {
        var viewModel = new AdminViewModel();
        try
        {
            var SubscriberResponse = await _http.GetAsync("https://localhost:7277/api/Subscribers");
            var SubscriberJson = await SubscriberResponse.Content.ReadAsStringAsync();
            var Subscribers = JsonConvert.DeserializeObject<IEnumerable<NewsletterEntity>>(SubscriberJson);
            if (Subscribers != null) { viewModel.newsletter = Subscribers; }


            var CourseResponse = await _http.GetAsync("https://localhost:7277/api/Courses");
            var CourseJson = await CourseResponse.Content.ReadAsStringAsync();
            var Courses = JsonConvert.DeserializeObject<IEnumerable<CourseEntity>>(CourseJson);
            if (Courses != null) { viewModel.courses = Courses; }

            viewModel.ProfileInfo = await PopulateProfileInfoAsync();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }


        return View(viewModel);
    }


    #region HttpPost-DeleteSubscriber
    [HttpDelete]
    public async Task<IActionResult> Deletesubscriber(string email)
    {
        try
        {
            var response = await _http.DeleteAsync($"https://localhost:7277/api/Subscribers/{email}");
            var json = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<CourseEntity>(json);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }

        return RedirectToAction("Index");
    }
    #endregion


    //#region HttpPost-CreateCourse
    //[HttpPost]
    //public async Task<IActionResult> CreateCourse(CourseRegistrationModel courseRegistration)
    //{
    //    if (ModelState.IsValid)
    //    {
    //        try
    //        {
    //            var content = new StringContent(JsonConvert.SerializeObject(courseRegistration), Encoding.UTF8, "application/json");
    //            var response = await _http.PostAsync("https://localhost:7277/api/Subscribers", content);

    //            if (response.IsSuccessStatusCode)
    //            {

    //            }
    //            else if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
    //            {

    //            }
    //        }

    //        catch (Exception ex)
    //        {

    //            Debug.WriteLine(ex.Message);
    //        }
    //    }
    //    else
    //    {

    //    }

    //}
    //#endregion



    [HttpPost]
    public async Task<IActionResult> UploadImage(IFormFile file)
    {
        try
        {
            var result = await _accountService.UploadUserProfileImageAsync(User, file);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return RedirectToAction("Details", "Account");
    }
    private async Task<AccountProfileInfoViewModel> PopulateProfileInfoAsync()
    {
        var existingUser = await _userManager.GetUserAsync(User);
        if (existingUser != null)
        {
            var newProfileInfo = new AccountProfileInfoViewModel
            {
                FirstName = existingUser.FirstName,
                LastName = existingUser.LastName,
                Email = existingUser.Email!,
                ProfileImgUrl = existingUser.ProfileImage,
                IsExternalAccount = existingUser.IsExternalAccount,
            };
            return newProfileInfo;
        }
        return new AccountProfileInfoViewModel();
    }
}
