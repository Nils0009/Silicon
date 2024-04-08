using Microsoft.AspNetCore.Mvc;
using SiliconWebApp.ViewModels.Views;

namespace SiliconWebApp.Controllers;

public class ContactController : Controller
{
    public IActionResult Index()
    {
        var viewModel = new ContactViewModel();
        return View(viewModel);
    }

    public IActionResult ContactMainForm()
    {
        return View();
    }
}
