using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SiliconWebApp.ViewModels.Sections;
using SiliconWebApp.ViewModels.Views;
using System.Diagnostics;

using System.Text;

namespace SiliconWebApp.Controllers;

public class ContactController(HttpClient http) : Controller
{
    private readonly HttpClient _http = http;

    [HttpGet]
    public IActionResult Index()
    {
        return View(new ContactViewModel());
    }

    #region HttpPost-ContactService
    [HttpPost]
    public async Task<IActionResult> ContactService(ContactRegistrationViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            try
            {
                viewModel.ContactServiceReg = new ContactServiceRegistrationModel()
                    {
                        Order = viewModel.SelectedService == "Order",
                        Support = viewModel.SelectedService == "Support"
                    };

                var content = new StringContent(JsonConvert.SerializeObject(viewModel), Encoding.UTF8, "application/json");
                var response = await _http.PostAsync("https://localhost:7277/api/Contact", content);

                if (response.IsSuccessStatusCode)
                {
                    viewModel.ConfirmMessage = "Your message has been sent";
                    return RedirectToAction("Index");
                }
                else
                {
                    viewModel.ErrorMessage = "Something went wrong, please try again later";
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                viewModel.ErrorMessage = "Something went wrong, please try again later";
            }
        }
        viewModel.ErrorMessage = "Something went wrong please try again later";
        return View("Index", new ContactViewModel { ContactServiceForm = viewModel });
    }

    #endregion
}
