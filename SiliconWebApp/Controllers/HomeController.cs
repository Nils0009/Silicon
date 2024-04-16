using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SiliconWebApp.ViewModels.Sections;
using SiliconWebApp.ViewModels.Views;
using System.Diagnostics;
using System.Text;


namespace SiliconWebApp.Controllers;

public class HomeController(HttpClient httpClient) : Controller
{
    private readonly HttpClient _httpClient = httpClient;

    public IActionResult Index(HomeViewModel viewModel)
    {
        ViewData["Title"] = viewModel.Title;
        ViewData["Status"] = TempData["Status"];
        return View(viewModel);
    }

    #region HttpPost-Subscribe
    [HttpPost]
    public async Task<IActionResult> Subscribe(HomeSubscriberViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(viewModel), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("https://localhost:7277/api/Subscribers", content);

                if (response.IsSuccessStatusCode)
                {
                    TempData["Status"] = "Success";
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
                {
                    TempData["Status"] = "AlreadyExists";
                }
            }

            catch (Exception ex)
            {
                TempData["Status"] = "ConnectionFailed";
                Debug.WriteLine(ex.Message);
            }
        }
        else
        {
            TempData["Status"] = "Invalid";
        }

        return Redirect("/Home/Index#subscribe-section");
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
