using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SiliconWebApp.ViewModels.Views;
using System.Diagnostics;

using System.Text;

namespace SiliconWebApp.Controllers;

public class ContactController(HttpClient http) : Controller
{
    private readonly HttpClient _http = http;

    public IActionResult Index()
    {
        return View(new ContactViewModel());
    }

    #region HttpPost-ContactService
    [HttpPost]
    public async Task<IActionResult> ContactServiceForm(ContactReqistrationModel contactReqistrationModel)
    {
        if (ModelState.IsValid)
        {
            try
            {
                contactReqistrationModel.ContactServiceReg = new ContactServiceRegistrationModel
                {
                    Order = contactReqistrationModel.SelectedService == "Order",
                    Support = contactReqistrationModel.SelectedService == "Support"
                };

                var content = new StringContent(JsonConvert.SerializeObject(contactReqistrationModel), Encoding.UTF8, "application/json");
                var response = await _http.PostAsync("https://localhost:7277/api/Contact", content);

                if (response.IsSuccessStatusCode)
                {
                    TempData["ConfirmMessage"] = "Your message has been sent";
                }
            }

            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Something went wrong please try agen later";
                Debug.WriteLine(ex.Message);
            }
        }

        return RedirectToAction("Index");
    }
    #endregion
}
