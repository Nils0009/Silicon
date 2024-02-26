using Microsoft.AspNetCore.Mvc;
using SiliconWebApp.Models.Views;

namespace SiliconWebApp.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        var viewModel = new HomeViewModel();

        @ViewData["Title"] = viewModel.Title;

        return View(viewModel);
    }
}
