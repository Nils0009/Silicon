using Microsoft.AspNetCore.Mvc;
using SiliconWebApp.ViewModels.Views;

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
    public IActionResult Error404(int statusCode)
    {
        var viewModel = new Error404ViewModel();
        @ViewData["Title"] = viewModel.Title;
        return View(viewModel);
    }
}
