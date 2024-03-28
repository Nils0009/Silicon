using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SiliconWebApp.ViewModels.Views;
using System.Diagnostics;
using System.Text;

namespace SiliconWebApp.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        var viewModel = new HomeViewModel();
        @ViewData["Title"] = viewModel.Title;

        return View(viewModel);
    }

    [Route("/error")]
    public IActionResult Error404()
    {
        var viewModel = new Error404ViewModel();
        @ViewData["Title"] = viewModel.Title;
        return View(viewModel);
    }

    [Route("/subscribe")]
    [HttpGet]
    public IActionResult Subscribe()
    {
        var viewModel = new HomeViewModel();
        ViewData["Subscribed"] = false;
        return View(viewModel);
    }


    [Route("/subscribe")]
    [HttpPost]
    public async Task<IActionResult> Subscribe(NewsletterSubscriptionRegistrationModel newsletter)
    {
        try
        {
            if (ModelState.IsValid)
            {
                using var http = new HttpClient();

                var json = JsonConvert.SerializeObject(newsletter);
                using var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await http.PostAsync("https://localhost:7277/api/Subscribers", content);

                if (response.IsSuccessStatusCode)
                {
                    ViewData["Subscribed"] = true;
                }
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return View();
    }
}
