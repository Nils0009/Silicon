using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SiliconWebApp.ViewModels.Views;
using System.Diagnostics;
using System.Text;


namespace SiliconWebApp.Controllers;

public class HomeController(HttpClient httpClient) : Controller
{
    private readonly HttpClient _httpClient = httpClient;

    public IActionResult Index()
    {
        var viewModel = new HomeViewModel();
        @ViewData["Title"] = viewModel.Title;
        return View(viewModel);
    }

    #region HttpGet-Subscribe
    [HttpGet]
    public IActionResult Subscribe()
    {
        return View(new NewsletterSubscriptionRegistrationModel());
    }
    #endregion

    #region HttpPost-Subscribe
    [HttpPost]
    public async Task<IActionResult> Subscribe(NewsletterSubscriptionRegistrationModel viewModel)
    {
        if (ModelState.IsValid)
        {
            try
            {
                
                var content = new StringContent(JsonConvert.SerializeObject(viewModel), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("https://localhost:7277/api/Subscribers", content);

                if (response.IsSuccessStatusCode)
                {
                    ViewData["Status"] = "Success";
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
                {
                    ViewData["Status"] = "AlreadyExists";
                }
            }

            catch (Exception ex)
            {
                ViewData["Status"] = "ConnectionFailed";
                Debug.WriteLine(ex.Message);
            }
        }
        else
        {
            ViewData["Status"] = "Invalid";
        }

        return View(viewModel);
    }
    #endregion

    #region ErrorPage
    [Route("/error")]
    public IActionResult Error404()
    {
        var viewModel = new Error404ViewModel();
        @ViewData["Title"] = viewModel.Title;
        return View(viewModel);
    }
    #endregion
}
