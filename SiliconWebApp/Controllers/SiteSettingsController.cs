using Microsoft.AspNetCore.Mvc;

namespace SiliconWebApp.Controllers;

public class SiteSettingsController : Controller
{
    public IActionResult ChangeTheme(string mode)
    {
        var option = new CookieOptions
        {
            Expires = DateTime.Now.AddDays(7),
        };
        Response.Cookies.Append("ThemeMode", mode, option);
        return Ok();
    }

    [HttpPost]
    public IActionResult CookieConsent()
    {
        var option = new CookieOptions
        {
            Expires = DateTime.Now.AddYears(1),
            HttpOnly = true,
            Secure = true
        };
        Response.Cookies.Append("CookieConsent", "true", option);
        return Ok();
    }
}
